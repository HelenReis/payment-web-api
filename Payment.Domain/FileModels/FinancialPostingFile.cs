using Payment.Domain.Enum;
using System;
using System.Globalization;
using System.Threading;

namespace Payment.Domain.FileModels
{
    public class FinancialPostingFile
    {
        /// <summary>
        /// financial posting amount
        /// </summary>
        public double Trnamt
        {
            get
            {
                return double.Parse(TrnamtFromFile);
            }
        }

        /// <summary>
        /// financial posting date
        /// </summary>
        public DateTime Dtposted
        {
            get
            {
                var date = DtpostedFromFile.AsSpan().Slice(0, 14);
                var formatInfo = CultureInfo.InvariantCulture;
                DateTime.TryParseExact(date, "yyyyMMddHHmmss", formatInfo, DateTimeStyles.None, out var dateParsed);
                return dateParsed;
            }
        }

        /// <summary>
        /// financial posting fitid
        /// </summary>
        public long Fitid
        {
            get
            {
                return long.Parse(FitidFromFile);
            }
        }

        /// <summary>
        /// financial posting description
        /// </summary>
        public string Memo
        {
            get
            {
                return MemoFromFile;
            }
        }

        /// <summary>
        /// financial posting type
        /// </summary>
        public TypeFinancial Trntype
        {
            get
            {
                switch (TrntypeFromFile)
                {
                    case "DEBIT":
                        return TypeFinancial.Debit;
                    case "CREDIT":
                        return TypeFinancial.Credit;
                    case "PAYMENT":
                        return TypeFinancial.Payment;
                    default:
                        return TypeFinancial.Other;
                }
            }
        }

        public string TrnamtFromFile { get; set; }

        public string DtpostedFromFile { get; set; }

        public string FitidFromFile { get; set; }

        public string MemoFromFile { get; set; }

        public string TrntypeFromFile { get; set; }
    }
}
