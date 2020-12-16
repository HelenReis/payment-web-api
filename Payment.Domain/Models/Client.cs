using System.Collections.Generic;

namespace Payment.Domain.Models
{
    public class Client
    {
        public Client(int id, string name)
        {
            Id = id;
            Name = name;
        }

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
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
