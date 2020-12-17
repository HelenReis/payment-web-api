using Microsoft.EntityFrameworkCore;
using Payment.Domain.DTOs;
using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Create(BankAccount bankAccount)
        {
            _context.Add(bankAccount);
        }

        public void Delete(BankAccount bankAccount)
        {
            _context.Remove(bankAccount);
        }

        public void Update(BankAccount bankAccount)
        {
            _context.Update(bankAccount);
        }

        public async Task<BankAccountDTO> GetById(long bankAccountId)
        {
            var imported = await _context.BankAccount
                .Where(bc => bc.Id == bankAccountId)
                .Select(n => new BankAccountDTO
                {
                    Id = n.Id,
                    Bank = n.Bank,
                    FinancialPostings = n.FinancialPostings
                })
                .FirstOrDefaultAsync();

            return imported;
        }


        public IQueryable<BankAccount> Query()
        {
            return _context.BankAccount.AsQueryable();
        }
    }

}
