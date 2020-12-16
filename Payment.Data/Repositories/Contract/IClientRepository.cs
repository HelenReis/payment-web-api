using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public interface IClientRepository
    {
        Client Create(Client bank);

        Client Update(Client bank);

        void Delete(Client bank);
    }
}
