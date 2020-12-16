using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public interface IFinancialPostingRepository
    {
        FinancialPosting Create(FinancialPosting financialPosting);

        FinancialPosting Update(FinancialPosting financialPosting);

        IEnumerable<FinancialPosting> CreateCollection(IEnumerable<FinancialPosting> financialPosting);

        void Delete(FinancialPosting financialPosting);
    }
}
