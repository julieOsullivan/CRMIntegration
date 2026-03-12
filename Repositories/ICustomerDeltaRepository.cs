using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerApi.Repositories;

public interface ICustomerDeltaRepository<T>
{
    Task<List<T>> GetTodayDeltasAsync();
}