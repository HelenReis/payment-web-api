using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public interface IImportedFileRepository
    {
        void Create(ImportedFile financialPosting);

        void Update(ImportedFile financialPosting);

        void Delete(ImportedFile financialPosting);

        //Task<bool> Any(long bankAccountId, DateTime dtserver);

        IQueryable<ImportedFile> Query();
    }
}
