﻿using Payment.Domain.DTOs;
using Payment.Service.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Queries.BankAccount.SelectBankAccount
{
    public class SelectBankAccountResult : IBaseResult
    {
        public SelectBankAccountResult(bool sucesso, string msg, Domain.Models.BankAccount bankAccount)
        {
            Sucesso = sucesso;
            Msg = msg;
            BankAccount = bankAccount;
        }

        public bool Sucesso { get; set; }

        public string Msg { get; set; }

        public Domain.Models.BankAccount BankAccount { get; set; }
    }
}
