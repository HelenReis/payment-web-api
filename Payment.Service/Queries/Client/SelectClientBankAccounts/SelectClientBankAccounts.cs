using Microsoft.EntityFrameworkCore;
using Payment.Data.Repositories;
using Payment.Domain.DTOs;
using Payment.Domain.DTOs.BankAccount;
using Payment.Domain.DTOs.Client;
using Payment.Service.Queries.Contract;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Service.Queries.Client.SelectClientBankAccounts
{
    public class SelectClientBankAccounts : IQueryService<SelectClientBankAccountsParams, SelectClientBankAccountsResult>
    {
        private readonly IClientRepository _repoClient;
        public SelectClientBankAccounts(IClientRepository repoClient)
        {
            _repoClient = repoClient;
        }

        public async Task<SelectClientBankAccountsResult> Query(SelectClientBankAccountsParams param)
        {
            try
            {
                if(!await ExistingClient(param.ClientId))
                    return new SelectClientBankAccountsResult(false, "Cliente não encontrado na base de dados", null);

                var clientReport = await _repoClient.Query()
                    .Where(c => c.Id == param.ClientId)
                    .Select(c => new ClientBankAccountResponse
                    {
                        Id = c.Id,
                        Name = c.Name,
                        BankAccounts = c.BankAccounts.Select(bc => new BankAccountFinancialPostings { 
                            Id = bc.Id,
                            BankId = bc.BankId,
                            TypeAccount = bc.TypeAccount,
                            FinancialPostings = bc.FinancialPostings
                        })
                    })
                    .FirstOrDefaultAsync();

                return new SelectClientBankAccountsResult(true, "OK", clientReport);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> ExistingClient(int clientId)
            => await _repoClient.AnyAsync(clientId);
        
    }
}
