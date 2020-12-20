using Payment.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payment.Domain.DTOs
{
    public class BankAccountDTO
    {
        [Required(ErrorMessage = "TypeAccount é obrigatório")]
        [Range(1, 4, ErrorMessage = "TypeAccount deve estar entre 1 e 4")]
        /// <summary>
        /// type account
        /// </summary>
        public TypeAccount TypeAccount { get; set; }
    }
}
