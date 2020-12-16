using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public interface IClientRepository
    {
        void Create(Client bank);

        void Update(Client bank);

        void Delete(Client bank);
    }
}
