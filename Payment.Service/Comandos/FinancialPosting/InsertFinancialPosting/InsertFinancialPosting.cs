using Microsoft.EntityFrameworkCore;
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

namespace Payment.Service.Comandos.FinancialPosting.InsertFinancialPosting
{
    public class InsertFinancialPosting : ICommandService<InsertFinancialPostingParams, InsertFinancialPostingResult>
    {
        private readonly IFinancialPostingRepository _repoFinancialPosting;
        private readonly IBankRepository _repoBank;
        private readonly IBankAccountRepository _repoBankAccount;
        private readonly IClientRepository _repoClient;
        private readonly IImportedFileRepository _repoImportedFile;
        private readonly IUnitOfWork _unitOfWork;

        private InsertFinancialPostingParams _params;

        public InsertFinancialPosting(
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

        public async Task<InsertFinancialPostingResult> ExecutarComando(InsertFinancialPostingParams param)
        {
            _params = param;

            try
            {
                if (!await ValidateExistingBankAccount())
                    return new InsertFinancialPostingResult(false, "Conta bancária não existente na base de dados");

                if (await ValidateExistingFinancialPosting())
                    return new InsertFinancialPostingResult(false, "Lançamento financeiro já existente");

                var financialPosting =
                    new Domain.Models.FinancialPosting(
                        _params.FinancialPostingDTO.Trnamt, _params.FinancialPostingDTO.Dtposted,
                        _params.FinancialPostingDTO.Fitid, _params.FinancialPostingDTO.Memo,
                        _params.FinancialPostingDTO.Trntype, _params.BankAccountId); ;

                _repoFinancialPosting.Create(financialPosting);
                await _unitOfWork.Commit();

                return new InsertFinancialPostingResult(true, "OK");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> ValidateExistingFinancialPosting()
        {
            return await _repoFinancialPosting.Query()
                .Where(f => f.BankAccountId == _params.BankAccountId &&
                            f.Dtposted.Equals(_params.FinancialPostingDTO.Dtposted))
                .AnyAsync();
        }

        private async Task<bool> ValidateExistingBankAccount()
        {
            return await _repoBankAccount.AnyAsync(_params.BankAccountId);
        }
    }
}
