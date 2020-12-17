using Payment.Domain.Models.Enum;
using System.Collections.Generic;

namespace Payment.Domain.FileModels
{
    public class BankAccountFile
    {
        /// <summary>
        /// bank account id
        /// </summary>
        public long Id
        {
            get
            {
                IdFromFile = IdFromFile.Replace("-", "");
                return long.Parse(IdFromFile);
            }
        }

        /// <summary>
        /// bank id
        /// </summary>
        public int BankId
        {
            get
            {
                return int.Parse(BankIdFromFile);
            }
        }

        public TypeAccount TypeAccount
        {
            get
            {
                switch (TypeAccountFile)
                {
                    case "CHECKING":
                        return TypeAccount.Checking;
                    case "PREMIUM":
                        return TypeAccount.Premium;
                    case "BUSINESS":
                        return TypeAccount.Business;
                    default:
                        return TypeAccount.Other;
                }
            }
        }

        public string IdFromFile { get; set; }

        public string BankIdFromFile { get; set; }

        public string TypeAccountFile { get; set; }
    }
}
