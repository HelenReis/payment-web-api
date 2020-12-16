using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public interface IBankRepository
    {
        void Create(Bank bank);

        void Update(Bank bank);

        void Delete(Bank bank);

        Task<Bank> GetById(int bankId);
    }
}
