using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public interface IBankAccountRepository
    {
        BankAccount Create(BankAccount bankAccount);

        BankAccount Update(BankAccount bankAccount);

        void Delete(BankAccount bankAccount);

        Task<BankAccount> Get(int bankAccountId);
    }
}
