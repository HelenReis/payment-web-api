using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Service.Shared
{
    public interface IBaseResult
    {
        public bool Sucesso { get; set; }

        public string Msg { get; set; }
    }
}
