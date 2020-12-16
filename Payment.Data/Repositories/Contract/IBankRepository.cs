using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public interface IBankRepository
    {
        Bank Create(Bank bank);

        Bank Update(Bank bank);

        void Delete(Bank bank);

        Task<Bank> Get(int bankId);

        Bank GetNo(int bankId);
    }
}
