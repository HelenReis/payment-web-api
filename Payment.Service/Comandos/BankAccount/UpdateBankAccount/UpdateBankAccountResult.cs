using Payment.Domain.DTOs;
using Payment.Service.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Comandos.BankAccount.UpdateBankAccount
{
    public class UpdateBankAccountResult : IBaseResult
    {
        public UpdateBankAccountResult(bool sucesso, string msg)
        {
            Sucesso = sucesso;
            Msg = msg;
        }

        public bool Sucesso { get; set; }

        public string Msg { get; set; }
    }
}
