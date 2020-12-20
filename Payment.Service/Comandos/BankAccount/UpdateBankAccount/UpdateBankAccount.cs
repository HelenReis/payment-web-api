using Microsoft.EntityFrameworkCore;
using Payment.Data.Repositories;
using Payment.Data.Repositories.Transaction.UnitOfWork;
using Payment.Domain.DTOs;
using Payment.Service.Comandos.Contract;
using Payment.Service.Queries.Contract;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Service.Comandos.BankAccount.UpdateBankAccount
{
    public class UpdateBankAccount : ICommandService<UpdateBankAccountParams, UpdateBankAccountResult>
    {
        private readonly IBankAccountRepository _repoBankAccount;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateBankAccount(IBankAccountRepository repoBankAccount, IUnitOfWork unitOfWork)
        {
            _repoBankAccount = repoBankAccount;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateBankAccountResult> ExecutarComando(UpdateBankAccountParams param)
        {
            try
            {
                if (!await ExistingBankAccount(param.BankAccountId))
                    return new UpdateBankAccountResult(false, "Conta bancária não encontrada na base de dados");

                var bankAccount = await _repoBankAccount.GetById(param.BankAccountId);
                bankAccount.TypeAccount = param.BankAccountPatch.TypeAccount;
                await _unitOfWork.Commit();

                return new UpdateBankAccountResult(true, "OK");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> ExistingBankAccount(long bankAccountId)
            => await _repoBankAccount.AnyAsync(bankAccountId);
    }
}
