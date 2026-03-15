using Microsoft.AspNetCore.Mvc;
using CustomerApi.Models;
using CustomerApi.Repositories;
using CustomerApi.Services;

namespace CustomerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerContactNotesDeltasController : ControllerBase
{
    private readonly ICustomerDeltaRepository<CRMCustomerContactNotesDelta> _repository;
    private readonly CsvExportService _csv;
    private readonly SftpService _sftp;

    public CustomerContactNotesDeltasController(
        ICustomerDeltaRepository<CRMCustomerContactNotesDelta> repository,
        CsvExportService csv,
        SftpService sftp)
    {
        _repository = repository;
        _csv = csv;
        _sftp = sftp;
    }

    [HttpGet("today")]
    public async Task<IActionResult> GetTodayDeltas()
    {
        var deltas = await _repository.GetTodayDeltasAsync();

        if (!deltas.Any())
            return Ok("No deltas found.");

        var filePath = await _csv.WriteCsvAsync(deltas, "CustomerContactNotesDelta");

        _sftp.UploadFile(filePath, Path.GetFileName(filePath));

        return Ok(deltas);
    }
}
