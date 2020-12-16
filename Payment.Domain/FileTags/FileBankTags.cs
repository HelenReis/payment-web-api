using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.FileTags
{
    public class FileBankTags
    {
        private FileBankTags(string value) { Value = value; }

        public string Value { get; set; }

        public static FileBankTags Id { get { return new FileBankTags("FID"); } }
        public static FileBankTags Org { get { return new FileBankTags("ORG"); } }
    }
}
