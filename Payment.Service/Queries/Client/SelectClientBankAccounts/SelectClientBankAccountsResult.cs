using Payment.Domain.DTOs;
using Payment.Domain.DTOs.Client;
using Payment.Service.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Queries.Client.SelectClientBankAccounts
{
    public class SelectClientBankAccountsResult : IBaseResult
    {
        public SelectClientBankAccountsResult(bool sucesso, string msg, ClientBankAccountResponse clientBankAccount)
        {
            Sucesso = sucesso;
            Msg = msg;
            ClientBankAccount = clientBankAccount;
        }

        public bool Sucesso { get; set; }

        public string Msg { get; set; }

        public ClientBankAccountResponse ClientBankAccount { get; set; }
    }
}
