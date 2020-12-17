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
        private readonly IImportedFileRepository _repoImportedFile;
        private readonly IUnitOfWork _unitOfWork;

        private ImportFileParams _params;

        public ImportFile(
            IFinancialPostingRepository repoFinancialPosting,
            IBankAccountRepository repoBankAccount,
            IBankRepository repoBank,
            IClientRepository repoClient,
            IImportedFileRepository repoImportedFile,
            IUnitOfWork unitOfWork)
        {
            _repoFinancialPosting = repoFinancialPosting;
            _repoBankAccount = repoBankAccount;
            _repoBank = repoBank;
            _repoClient = repoClient;
            _repoImportedFile = repoImportedFile;
            _unitOfWork = unitOfWork;
        }

        public async Task<ImportFileResult> ExecutarComando(ImportFileParams param)
        {
            _params = param;

            try
            {
                if (!FileValidation())
                    return new ImportFileResult(false, "Formato de arquivo não suportado.");

                var (importedFile, bank, bankAccount, financialPosting) = await ReadFile();
                return await InsertData(importedFile, bank, bankAccount, financialPosting);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region[Validação da extensão do arquivo]
        private bool FileValidation() => Path.GetExtension(_params.File.FileName).Equals(".ofx");
        #endregion

        #region[Ler arquivo]
        private async Task<(ImportedFileFile, BankFile, BankAccountFile, IEnumerable<FinancialPostingFile>)> ReadFile()
        {
            var helper = new ImportFileHelper(_params.File);
            return await helper.ReadFile();   
        }
        #endregion

        #region[Insere dados das tags nos objetos e no banco]
        private async Task<ImportFileResult> InsertData(ImportedFileFile importedFile, BankFile bank, BankAccountFile bankAccount, IEnumerable<FinancialPostingFile> financialPosting)
        {
            if (await ExistingImportedFile(importedFile, bankAccount))
                return new ImportFileResult(false, "Arquivo já importado na base de dados.");

            await SaveObject();
            await SaveObject(bank);
            await SaveObject(bankAccount, bank); 
            SaveObject(financialPosting, bankAccount);
            SaveObject(importedFile, bankAccount);
            await _unitOfWork.Commit();

            return new ImportFileResult(true, "OK");
        }
        #endregion

        #region[Verifica se o arquivo foi importado antes]
        private async Task<bool> ExistingImportedFile(ImportedFileFile importedFile, BankAccountFile bankAccount)
            => await _repoImportedFile.Any(bankAccount.Id, importedFile.Dtserver);
        #endregion

        #region [Insere arquivo importado]
        private void SaveObject(ImportedFileFile importedFile, BankAccountFile bankAccount)
        {
            var importFile = new ImportedFile(importedFile.Dtserver, bankAccount.Id);
            _repoImportedFile.Create(importFile);
        }
        #endregion]

        #region [Insere cliente]
        private async Task SaveObject()
        {
            var existingClient = await _repoClient.Any(_params.ClientId);
            if (!existingClient)
            {
                var newBankAccount = new Client(_params.ClientId, "Aleatório");
                _repoClient.Create(newBankAccount);
            }
        }
        #endregion

        #region [Insere banco]
        private async Task SaveObject(BankFile bank)
        {
            var existingBank = await _repoBank.GetById(bank.Id);
            if (existingBank is null)
            {
                var newBank = new Bank(bank.Id, bank.Org);
                _repoBank.Create(newBank);
            }
        }
        #endregion

        #region [Insere conta bancária]
        private async Task SaveObject(BankAccountFile bankAccount, BankFile bank)
        {
            var existingBankAccount = await _repoBankAccount.GetById(bankAccount.Id);
            if (existingBankAccount is null)
            {
                var newBankAccount = new BankAccount(bankAccount.Id, bank.Id, _params.ClientId);
                _repoBankAccount.Create(newBankAccount);
            }
        }
        #endregion

        #region[Insere lançamentos financeiros]
        private void SaveObject(IEnumerable<FinancialPostingFile> financialPosting, BankAccountFile bankAccount)
        {
            var financials = financialPosting.Select(
                t => new FinancialPosting(
                    t.Trnamt, t.Dtposted,
                    t.Fitid, t.Memo,
                    t.Trntype, bankAccount.Id));

            _repoFinancialPosting.CreateCollection(financials);
        }
        #endregion
    }
}
