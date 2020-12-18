using Payment.Domain.DTOs;
using Payment.Service.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Comandos.BankAccount.UpdateBankAccount
{
    public class UpdateBankAccountParams : IBaseParams
    {
        public UpdateBankAccountParams(long bankAccountId, BankAccountDTO bankAccountPatch)
        {
            BankAccountId = bankAccountId;
            BankAccountPatch = bankAccountPatch;
        }

        public long BankAccountId { get; set; }

        public BankAccountDTO BankAccountPatch { get; set; }
    }
}
