public class CsvExportService
{
    public async Task<string> WriteCsvAsync<T>(List<T> records, string filePrefix)
    {
        var fileName = $"{filePrefix}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
        var tempPath = Path.Combine(Path.GetTempPath(), fileName);

        var properties = typeof(T).GetProperties();

        var lines = new List<string>
        {
            string.Join(",", properties.Select(p => p.Name))
        };

        foreach (var record in records)
        {
            var values = properties.Select(p =>
            {
                var value = p.GetValue(record);

                if (value == null)
                    return "";

                if (value is DateTime dt)
                    return dt.ToString("yyyy-MM-dd HH:mm:ss");

                return value.ToString();
            });

            lines.Add(string.Join(",", values));
        }

        await File.WriteAllLinesAsync(tempPath, lines);

        return tempPath;
    }
}