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

        public FinancialPosting Create(FinancialPosting financial)
        {
            _context.Add(financial);
            return financial;
        }

        public FinancialPosting Update(FinancialPosting financial)
        {
            _context.Update(financial);
            return financial;
        }

        public void Delete(FinancialPosting financial)
        {
            _context.Remove(financial);
        }

        public IEnumerable<FinancialPosting> CreateCollection(IEnumerable<FinancialPosting> financialPosting)
        {
            _context.AddRange(financialPosting);
            return financialPosting;
        }
    }
}
