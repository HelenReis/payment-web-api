using Microsoft.EntityFrameworkCore;
using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly PaymentContext _context;

        public ClientRepository(PaymentContext context)
        {
            _context = context;
        }

        public void Create(Client client)
        {
            _context.Add(client);
        }

        public void Update(Client client)
        {
            _context.Update(client);
        }

        public void Delete(Client client)
        {
            _context.Remove(client);
        }

        public async Task<Client> GetById(int clientId)
        {
            return await _context.FindAsync<Client>(clientId);
        }

        public async Task<bool> AnyAsync(int clientId)
        {
            return await _context.Client.AnyAsync(c => c.Id == clientId);
        }
    }
}
