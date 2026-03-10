using Microsoft.EntityFrameworkCore;
using CustomerApi.Data;
using CustomerApi.Models;

public class CustomerDeltaRepository : ICustomerDeltaRepository
{
    private readonly AppDbContext _context;

    public CustomerDeltaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CRMCustomerDelta>> GetTodayDeltasAsync()
    {
        var todayStart = DateTime.Today;
        var tomorrowStart = todayStart.AddDays(1);

        return await _context.CRMCustomerDelta
            .Where(x => x.LoadTs >= todayStart && x.LoadTs < tomorrowStart)
            .ToListAsync();
    }
}