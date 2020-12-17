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
                var bankAccount = await _repoBankAccount.Query()
                    .Where(bc => bc.Id == param.BankAccountId)
                    .Select(n => new BankAccountDTO
                    {
                        Id = n.Id,
                        Bank = n.Bank,
                        FinancialPostings = n.FinancialPostings
                    })
                    .FirstOrDefaultAsync();

                return new SelectBankAccountResult(true, "OK", bankAccount);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
