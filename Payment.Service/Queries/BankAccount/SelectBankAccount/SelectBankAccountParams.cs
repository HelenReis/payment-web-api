using Payment.Service.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Queries.BankAccount.SelectBankAccount
{
    public class SelectBankAccountParams : IBaseParams
    {
        public SelectBankAccountParams(long bankAccountId)
        {
            BankAccountId = bankAccountId;
        }

        public long BankAccountId { get; set; }
    }
}
