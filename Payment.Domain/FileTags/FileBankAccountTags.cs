using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.FileTags
{
    public class FileBankAccountTags
    {
        private FileBankAccountTags(string value) { Value = value; }

        public string Value { get; set; }

        public static FileBankAccountTags Id { get { return new FileBankAccountTags("ACCTID"); } }
        public static FileBankAccountTags BankId { get { return new FileBankAccountTags("BANKID"); } }
        public static FileBankAccountTags TypeAccount { get { return new FileBankAccountTags("ACCTTYPE"); } }
    }
}
