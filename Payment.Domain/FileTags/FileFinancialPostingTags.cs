using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.FileTags
{
    public class FileFinancialPostingTags
    {
        private FileFinancialPostingTags(string value) { Value = value; }

        public string Value { get; set; }

        public static FileFinancialPostingTags Trnamt { get { return new FileFinancialPostingTags("TRNAMT"); } }
        public static FileFinancialPostingTags Dtposted { get { return new FileFinancialPostingTags("DTPOSTED"); } }
        public static FileFinancialPostingTags Fitid { get { return new FileFinancialPostingTags("FITID"); } }
        public static FileFinancialPostingTags Trntype { get { return new FileFinancialPostingTags("TRNTYPE"); } }
        public static FileFinancialPostingTags Memo { get { return new FileFinancialPostingTags("MEMO"); } }
    }
}
