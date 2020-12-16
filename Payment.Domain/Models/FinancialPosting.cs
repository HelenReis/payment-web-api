using Payment.Domain.Enum;
using System;
namespace Payment.Domain.Models
{
    public class FinancialPosting
    {
        public FinancialPosting(double trnamt, DateTime dtposted, long fitid, string memo, TypeFinancial trntype, int bankAccountId)
        {
            Trnamt = trnamt;
            Dtposted = dtposted;
            Fitid = fitid;
            Memo = memo;
            Trntype = trntype;
            BankAccountId = bankAccountId;
        }

        /// <summary>
        /// financial posting id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// financial posting amount
        /// </summary>
        public double Trnamt { get; set; }

        /// <summary>
        /// financial posting date
        /// </summary>
        public DateTime Dtposted { get; set; }

        /// <summary>
        /// financial posting fitid
        /// </summary>
        public long Fitid { get; set; }

        /// <summary>
        /// financial posting description
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// financial posting type
        /// </summary>
        public TypeFinancial Trntype { get; set; }

        /// <summary>
        /// BankAccountId
        /// </summary>
        public int BankAccountId { get; set; }

        /// <summary>
        /// BankAccount
        /// </summary>
        public virtual BankAccount BankAccount { get; set; }
    }
}
