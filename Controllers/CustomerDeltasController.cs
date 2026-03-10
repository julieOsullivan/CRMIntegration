using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerApi.Data;
using CustomerApi.Models;
using CustomerApi.Services;
using System.Reflection;

namespace CustomerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerDeltasController : ControllerBase
{
    private readonly ICustomerDeltaRepository _repository;
    private readonly SftpService _sftpService;

   public CustomerDeltasController(ICustomerDeltaRepository repository, SftpService sftpService)
    {
        _repository = repository;
        _sftpService = sftpService;
    }

    [HttpGet("today")]
    public async Task<IActionResult> GetTodayDeltas()
    {
        var deltas = await _repository.GetTodayDeltasAsync();

        if (!deltas.Any())
            return Ok("No deltas found.");

        // ======================
        // 1️⃣ CREATE CSV FILE
        // ======================

        var fileName = $"CustomerDelta_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
        var tempPath = Path.Combine(Path.GetTempPath(), fileName);

        var properties = typeof(CRMCustomerDelta).GetProperties();
        var lines = new List<string>();

        lines.Add(string.Join(",", properties.Select(p => p.Name)));

        foreach (var d in deltas)
        {
            var values = properties.Select(p =>
            {
                var value = p.GetValue(d);

                if (value == null)
                    return "";

                if (value is DateTime dt)
                    return EscapeCsv(dt.ToString("yyyy-MM-dd HH:mm:ss"));

                return EscapeCsv(value.ToString());
            });

            lines.Add(string.Join(",", values));
        }

        await System.IO.File.WriteAllLinesAsync(tempPath, lines);

        // ======================
        // 2️⃣ UPLOAD TO SFTP
        // ======================

        _sftpService.UploadFile(tempPath, fileName);

        // ======================
        // 3️⃣ RETURN JSON STRUCTURE
        // ======================

        var grouped = deltas
            .GroupBy(x => new { x.CustomerAccount, x.DeliverySequence })
            .Select(g => new CustomerResponse
            {
                CustomerAccount = g.Key.CustomerAccount,
                DeliverySequence = g.Key.DeliverySequence,
                CustomerStatus = g.First().CustomerStatus,
                CustomerStatusDesc = g.First().CustomerStatusDesc,
                CustomerName = g.First().CustomerName,
                AddressLine1 = g.First().AddressLine1,
                AddressLine2 = g.First().AddressLine2,
                AddressLine3 = g.First().AddressLine3,
                AddressLine4 = g.First().AddressLine4,
                AddressLine5 = g.First().AddressLine5,
                PostCodePart1 = g.First().PostCodePart1,
                PostCodePart2 = g.First().PostCodePart2,
                WebsiteUrl = g.First().WebsiteUrl,
                PrimaryContact = g.First().PrimaryContact,

                Divisions = g.Select(d => new DivisionResponse
                {
                    BusinessUnitCode = d.BusinessUnitCode,
                    TradeChannelCode = d.TradeChannelCode,
                    CustomerPricing = d.CustomerPricing,
                    PriceCode = d.PriceCode,
                    TradingStatus = d.TradingStatus,
                    CustomerClass = d.CustomerClass,
                    DeliveryLeadTime = d.DeliveryLeadTime,
                    ProofOfDeliveryReq = d.ProofOfDeliveryReq,
                    InvoiceFlag = d.InvoiceFlag,
                    OutletCode = d.OutletCode,
                    OeCustomer = d.OeCustomer,
                    EqCustomer = d.EqCustomer,
                    CsCustomer = d.CsCustomer
                }).ToList()
            })
            .ToList();

        return Ok(grouped);
    }
    

    private string EscapeCsv(string? value)
    {
        if (string.IsNullOrEmpty(value))
            return "";

        if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
        {
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        return value;
    }
}