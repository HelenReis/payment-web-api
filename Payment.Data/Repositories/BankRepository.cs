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

        public Bank Create(Bank bank)
        {
            try
            {
                _context.Add(bank);
                //await _context.SaveChangesAsync();
                Console.WriteLine("ok");
                return bank;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }

        }

        public void Delete(Bank bank)
        {
            _context.Remove(bank);
        }

        public Bank Update(Bank bank)
        {
            _context.Update(bank);
            return bank;
        }

        public async Task<Bank> Get(int bankId)
        {
            try
            {
                return await _context.Bank.FindAsync(bankId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }

        public Bank GetNo(int bankId)
        {
            try
            {
                var t = _context.Bank.Find(bankId);
                return t;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
