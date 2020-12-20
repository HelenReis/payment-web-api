using Microsoft.EntityFrameworkCore;
using Payment.Data.Repositories;
using Payment.Domain.DTOs;
using Payment.Service.Queries.Contract;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Service.Queries.BankAccount.SelectBankAccount
{
    public class SelectBankAccount : IQueryService<SelectBankAccountParams, SelectBankAccountResult>
    {
        private readonly IBankAccountRepository _repoBankAccount;
        public SelectBankAccount(IBankAccountRepository repoBankAccount)
        {
            _repoBankAccount = repoBankAccount;
        }

        public async Task<SelectBankAccountResult> Query(SelectBankAccountParams param)
        {
            try
            {
                if (!await ExistingBankAccount(param.BankAccountId))
                    return new SelectBankAccountResult(false, "Conta bancária não encontrada na base de dados", null);

                var bankAccount = await _repoBankAccount.GetById(param.BankAccountId);
                return new SelectBankAccountResult(true, "OK", bankAccount);
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
