using Microsoft.EntityFrameworkCore;
using CustomerApi.Data;
using CustomerApi.Models;

namespace CustomerApi.Repositories;

public class CustomerContactNotesDeltaRepository
    : ICustomerDeltaRepository<CRMCustomerContactNotesDelta>
{
    private readonly AppDbContext _context;

    public CustomerContactNotesDeltaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CRMCustomerContactNotesDelta>> GetTodayDeltasAsync()
    {
        var todayStart = DateTime.Today;
        var tomorrowStart = todayStart.AddDays(1);

        return await _context.CRMCustomerContactNotesDelta
            .Where(x => x.LoadTs >= todayStart && x.LoadTs < tomorrowStart)
            .AsNoTracking()
            .ToListAsync();
    }
}
