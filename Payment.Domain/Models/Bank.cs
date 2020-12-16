namespace Payment.Domain.Models
{
    public class Bank
    {
        public Bank(int id, string org)
        {
            Id = id;
            Org = org;
        }

        /// <summary>
        /// bank id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// bank org
        /// </summary>
        public string Org { get; set; }
    }
}
