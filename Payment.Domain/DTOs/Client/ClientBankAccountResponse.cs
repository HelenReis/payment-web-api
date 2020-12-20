using Payment.Domain.DTOs.BankAccount;
using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.DTOs.Client
{
    public class ClientBankAccountResponse
    {
        /// <summary>
        /// client id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Client bankAccounts
        /// </summary>
        public virtual IEnumerable<BankAccountFinancialPostings> BankAccounts { get; set; }
    }
}
