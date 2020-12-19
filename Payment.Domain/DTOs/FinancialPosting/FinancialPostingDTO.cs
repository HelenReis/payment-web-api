using Payment.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payment.Domain.DTOs.FinancialPosting
{
    public class FinancialPostingDTO
    {
        /// <summary>
        /// financial posting id
        /// </summary>
        public int Id { get; set; }

        [Required(ErrorMessage = "Trnamt é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        /// <summary>
        /// financial posting amount
        /// </summary>
        public double Trnamt { get; set; }

        [Required(ErrorMessage = "Dtposted é obrigatório")]
        [Range(typeof(DateTime), "01/01/1753", "31/12/9999", ErrorMessage = "Dtposted não é uma data válida")]
        /// <summary>
        /// financial posting date
        /// </summary>
        public DateTime Dtposted { get; set; }

        [Required(ErrorMessage = "Fitid é obrigatório")]
        /// <summary>
        /// financial posting fitid
        /// </summary>
        public long Fitid { get; set; }

        [Required(ErrorMessage = "Memo é obrigatório")]
        /// <summary>
        /// financial posting description
        /// </summary>
        public string Memo { get; set; }

        [Required(ErrorMessage = "Trntype é obrigatório")]
        [Range(1, 4, ErrorMessage = "Trntype deve estar entre 1 e 4")]
        /// <summary>
        /// financial posting type
        /// </summary>
        public TypeFinancial Trntype { get; set; }

        /// <summary>
        /// BankAccountId
        /// </summary>
        public long BankAccountId { get; set; }
    }
}
