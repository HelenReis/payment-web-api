using Microsoft.EntityFrameworkCore;
using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public class ImportedFileRepository : IImportedFileRepository
    {
        private readonly PaymentContext _context;

        public ImportedFileRepository(PaymentContext context)
        {
            _context = context;
        }

        public void Create(ImportedFile importedFile)
        {
            _context.Add(importedFile);
        }

        public void Update(ImportedFile importedFile)
        {
            _context.Update(importedFile);
        }

        public void Delete(ImportedFile importedFile)
        {
            _context.Remove(importedFile);
        }

        /*public async Task<bool> Any(long bankAccountId, DateTime dtserver)
        {
            var imported = await _context.ImportedFile
                .Where(i => i.DtServer.Equals(dtserver) && i.BankAccountId == bankAccountId)
                .ToListAsync();

            return imported.Any();
        }*/

        public IQueryable<ImportedFile> Query()
        {
            return _context.ImportedFile.AsQueryable();
        }
    }
}
