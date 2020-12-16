using Payment.Service.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Comandos.Contract
{
    public interface ICommandService<TParams, TResults> 
        where TParams : IBaseParams
        where TResults : IBaseResult
    {
        Task<TResults> ExecutarComando(TParams param);
    }
}
