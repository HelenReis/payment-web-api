using Payment.Data.Repositories;
using Payment.Data.Repositories.Transaction.UnitOfWork;
using Payment.Domain.FileModels;
using Payment.Domain.Models;
using Payment.Service.Comandos.Contract;
using Payment.Service.Comandos.FinancialPostingCommand.ImportFile.Helper;
using Payment.Service.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Comandos.FinancialPostingCommand.ImportFile
{
    public class ImportFile : ICommandService<ImportFileParams, ImportFileResult>
    {
        private readonly IFinancialPostingRepository _repoFinancialPosting;
        private readonly IBankRepository _repoBank;
        private readonly IBankAccountRepository _repoBankAccount;
        private readonly IClientRepository _repoClient;
        private readonly IUnitOfWork _unitOfWork;

        private ImportFileParams _params;

        public ImportFile(
            IFinancialPostingRepository repoFinancialPosting,
            IBankAccountRepository repoBankAccount,
            IBankRepository repoBank,
            IClientRepository repoClient,
            IUnitOfWork unitOfWork)
        {
            _repoFinancialPosting = repoFinancialPosting;
            _repoBankAccount = repoBankAccount;
            _repoBank = repoBank;
            _repoClient = repoClient;
            _unitOfWork = unitOfWork;
        }

        public async Task<ImportFileResult> ExecutarComando(ImportFileParams param)
        {
            _params = param;

            try
            {
                /* FAZER ANY NO REPO */
                /* CRIAR PRIMEIRO CLIENTE AUTOMATICO CASO NÃO EXISTIR, COM NOME ALEATÓRIO. */
                /*  */
                if (!FileValidation())
                    return new ImportFileResult
                    { Sucesso = false, Msg = "Formato de arquivo não suportado." };

                await ReadFile();

                return new ImportFileResult { Sucesso = true, Msg = "OK." };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool FileValidation()
        {
            if (!Path.GetExtension(_params.File.FileName).Equals(".ofx"))
                return false;

            return true;
        }

        private async Task ReadFile()
        {
            var helper = new ImportFileHelper(_params.File);
            var (bank, bankAccount, financialPosting) = await helper.ImportFile();
            await InsertData(bank, bankAccount, financialPosting);
        }

        private async Task InsertData(BankFile bank, BankAccountFile bankAccount, IEnumerable<FinancialPostingFile> financialPosting)
        {
            await SaveObject();
            await SaveObject(bank);
            await SaveObject(bankAccount, bank);
            SaveObject(financialPosting, bankAccount);

            await _unitOfWork.Commit();
        }

        private async Task SaveObject()
        {
            var existingClient = await _repoClient.Any(_params.ClientId);
            if (!existingClient)
            {
                var newBankAccount = new Client(_params.ClientId, "Aleatório");
                _repoClient.Create(newBankAccount);
            }
        }

        private async Task SaveObject(BankFile bank)
        {
            var existingBank = await _repoBank.GetById(bank.Id);
            if (existingBank is null)
            {
                var newBank = new Bank(bank.Id, bank.Org);
                _repoBank.Create(newBank);
            }
        }

        private async Task SaveObject(BankAccountFile bankAccount, BankFile bank)
        {
            var existingBankAccount = await _repoBankAccount.GetById(bankAccount.Id);
            if (existingBankAccount is null)
            {
                var newBankAccount = new BankAccount(bankAccount.Id, bank.Id, _params.ClientId);
                _repoBankAccount.Create(newBankAccount);
            }
        }

        private void SaveObject(IEnumerable<FinancialPostingFile> financialPosting, BankAccountFile bankAccount)
        {
            /* VALIDAR SE ARQUIVO JÁ FOI SALVO */
            var financials = financialPosting.Select(
                t => new FinancialPosting(
                    t.Trnamt, t.Dtposted,
                    t.Fitid, t.Memo,
                    t.Trntype, bankAccount.Id));

            _repoFinancialPosting.CreateCollection(financials);
        }
    }
}
