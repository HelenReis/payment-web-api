using Payment.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.DTOs
{
    public class BankAccountDTO
    {
        /// <summary>
        /// type account
        /// </summary>
        public TypeAccount TypeAccount { get; set; }
    }
}
