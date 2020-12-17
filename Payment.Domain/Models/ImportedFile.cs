using System;

namespace Payment.Domain.Models
{
    public class ImportedFile
    {
        public ImportedFile(DateTime dtServer, long bankAccountId)
        {
            DtServer = dtServer;
            BankAccountId = bankAccountId;
        }

        /// <summary>
        /// bank id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// bank org
        /// </summary>
        public DateTime DtServer { get; set; }

        /// <summary>
        /// BankAccountId
        /// </summary>
        public long BankAccountId { get; set; }

        /// <summary>
        /// BankAccount
        /// </summary>
        public virtual BankAccount BankAccount { get; set; }
    }
}
