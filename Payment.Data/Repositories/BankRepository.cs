using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly PaymentContext _context;

        public BankRepository(PaymentContext context)
        {
            _context = context;
        }

        public void Create(Bank bank)
        {
            _context.Add(bank);
        }

        public void Delete(Bank bank)
        {
            _context.Remove(bank);
        }

        public void Update(Bank bank)
        {
            _context.Update(bank);
        }

        public async Task<Bank> GetById(int bankId)
        {
            return await _context.FindAsync<Bank>(bankId);
        }
    }
}
