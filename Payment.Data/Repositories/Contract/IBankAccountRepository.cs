using Payment.Domain.DTOs;
using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public interface IBankAccountRepository
    {
        void Create(BankAccount bankAccount);

        void Update(BankAccount bankAccount);

        void Delete(BankAccount bankAccount);

        Task<BankAccountDTO> GetById(long bankAccountId);

        IQueryable<BankAccount> Query();
    }
}
