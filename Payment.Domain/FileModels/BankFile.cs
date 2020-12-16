namespace Payment.Domain.FileModels
{
    public class BankFile
    {
        /// <summary>
        /// bank id
        /// </summary>
        public int Id
        {
            get
            {
                return int.Parse(IdFromFile);
            }
        }

        /// <summary>
        /// bank org
        /// </summary>
        public string Org
        {
            get
            {
                return OrgFromFile;
            }
        }


        public string IdFromFile { get; set; }

        public string OrgFromFile { get; set; }
    }
}
