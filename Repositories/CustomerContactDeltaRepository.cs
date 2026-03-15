using Microsoft.EntityFrameworkCore;
using CustomerApi.Data;
using CustomerApi.Models;
namespace CustomerApi.Repositories;

public class CustomerContactDeltaRepository 
    : ICustomerDeltaRepository<CRMCustomerContactDelta>
{
    private readonly AppDbContext _context;

    public CustomerContactDeltaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CRMCustomerContactDelta>> GetTodayDeltasAsync()
    {
        var todayStart = DateTime.Today;
        var tomorrowStart = todayStart.AddDays(1);

        return await _context.CRMCustomerContactDelta
            .Where(x => x.LoadTs >= todayStart && x.LoadTs < tomorrowStart)
            .AsNoTracking()
            .ToListAsync();
    }
}