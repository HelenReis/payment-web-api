using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.DTOs
{
    public class BankAccountDTO
    {
        /// <summary>
        /// bank account id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Bank
        /// </summary>
        public virtual Bank Bank { get; set; }


        /// <summary>
        /// FinancialPosting
        /// </summary>
        public virtual ICollection<FinancialPosting> FinancialPostings { get; set; }
    }
}
