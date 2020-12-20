using Payment.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.DTOs.BankAccount
{
    public class BankAccountFinancialPostings
    {
        /// <summary>
        /// bank account id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// bank id
        /// </summary>
        public int BankId { get; set; }

        /// <summary>
        /// type account
        /// </summary>
        public TypeAccount TypeAccount { get; set; }

        /// <summary>
        /// FinancialPosting
        /// </summary>
        public virtual ICollection<Models.FinancialPosting> FinancialPostings { get; set; }
    }
}
