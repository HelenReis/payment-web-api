using System.Collections.Generic;

namespace Payment.Domain.FileModels
{
    public class BankAccountFile
    {
        /// <summary>
        /// bank account id
        /// </summary>
        public int Id
        {
            get
            {
                IdFromFile = IdFromFile.Replace("-", "");
                return int.Parse(IdFromFile);
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

        public string IdFromFile { get; set; }

        public string BankIdFromFile { get; set; }
    }
}
