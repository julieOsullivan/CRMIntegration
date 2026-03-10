using CustomerApi.Models;

public interface ICustomerDeltaRepository
{
    Task<List<CRMCustomerDelta>> GetTodayDeltasAsync();
}