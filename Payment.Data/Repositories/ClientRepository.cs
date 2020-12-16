using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly PaymentContext _context;

        public ClientRepository(PaymentContext context)
        {
            _context = context;
        }

        public Client Create(Client client)
        {
            _context.Add(client);
            return client;
        }

        public Client Update(Client client)
        {
            _context.Update(client);
            return client;
        }

        public void Delete(Client client)
        {
            _context.Remove(client);
        }
    }
}
