using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public interface IClientRepository
    {
        void Create(Client client);

        void Update(Client client);

        void Delete(Client client);

        Task<Client> GetById(int clientId);

        Task<bool> AnyAsync(int clientId);
    }
}
