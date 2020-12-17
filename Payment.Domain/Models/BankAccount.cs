
using Payment.Domain.Models.Enum;
using System.Collections.Generic;

namespace Payment.Domain.Models
{
    public class BankAccount
    {
        public BankAccount(long id, int bankId, int clientId, TypeAccount typeAccount)
        {
            Id = id;
            BankId = bankId;
            ClientId = clientId;
            TypeAccount = typeAccount;
        }

        /// <summary>
        /// bank account id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// bank id
        /// </summary>
        public int BankId { get; set; }

        /// <summary>
        /// client id
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// type account
        /// </summary>
        public TypeAccount TypeAccount { get; set; }

        /// <summary>
        /// Bank
        /// </summary>
        public virtual Bank Bank { get; set; }

        /// <summary>
        /// Client
        /// </summary>
        public virtual Client Client { get; set; }

        /// <summary>
        /// FinancialPosting
        /// </summary>
        public virtual ICollection<FinancialPosting> FinancialPostings { get; set; }
    }
}
