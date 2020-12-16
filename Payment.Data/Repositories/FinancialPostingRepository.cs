using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Repositories
{
    public class FinancialPostingRepository : IFinancialPostingRepository
    {
        private readonly PaymentContext _context;

        public FinancialPostingRepository(PaymentContext context)
        {
            _context = context;
        }

        public void Create(FinancialPosting financial)
        {
            _context.Add(financial);
        }

        public void Update(FinancialPosting financial)
        {
            _context.Update(financial);
        }

        public void Delete(FinancialPosting financial)
        {
            _context.Remove(financial);
        }

        public void CreateCollection(IEnumerable<FinancialPosting> financialPosting)
        {
            _context.AddRange(financialPosting);
        }
    }
}
