using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public interface IBankAccountRepository
    {
        void Create(BankAccount bankAccount);

        void Update(BankAccount bankAccount);

        void Delete(BankAccount bankAccount);

        Task<BankAccount> GetById(long bankAccountId);
    }
}
