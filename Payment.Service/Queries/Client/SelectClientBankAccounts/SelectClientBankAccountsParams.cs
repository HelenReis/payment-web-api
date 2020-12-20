using Payment.Service.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Queries.Client.SelectClientBankAccounts
{
    public class SelectClientBankAccountsParams : IBaseParams
    {
        public SelectClientBankAccountsParams(int clientId)
        {
            ClientId = clientId;
        }

        public int ClientId { get; set; }
    }
}
