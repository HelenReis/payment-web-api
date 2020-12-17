using Payment.Service.Shared;
using System.Threading.Tasks;

namespace Payment.Service.Queries.Contract
{
    public interface IQueryService<TParams, TResults> 
        where TParams : IBaseParams
        where TResults : IBaseResult
    {
        Task<TResults> Query(TParams param);
    }
}
