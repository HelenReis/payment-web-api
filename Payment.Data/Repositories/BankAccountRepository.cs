using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly PaymentContext _context;

        public BankAccountRepository(PaymentContext context)
        {
            _context = context;
        }

        public BankAccount Create(BankAccount bankAccount)
        {
            _context.Add(bankAccount);
            return bankAccount;
        }

        public void Delete(BankAccount bankAccount)
        {
            _context.Remove(bankAccount);
        }

        public async Task<BankAccount> Get(int bankAccountId)
        {
            return await _context.FindAsync<BankAccount>(bankAccountId);
        }

        public BankAccount Update(BankAccount bankAccount)
        {
            _context.Update(bankAccount);
            return bankAccount;
        }
    }
}
