using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public interface IFinancialPostingRepository
    {
        void Create(FinancialPosting financialPosting);

        void Update(FinancialPosting financialPosting);

        void Delete(FinancialPosting financialPosting);

        void CreateCollection(IEnumerable<FinancialPosting> financialPosting);

        IQueryable<FinancialPosting> Query();
    }
}
