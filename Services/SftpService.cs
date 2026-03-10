using Microsoft.Extensions.Options;
using Renci.SshNet;
using CustomerApi.Configuration;

namespace CustomerApi.Services;

public class SftpService
{
    private readonly SftpSettings _settings;

    public SftpService(IOptions<SftpSettings> settings)
    {
        _settings = settings.Value;
    }

    public void UploadFile(string localFilePath, string fileName)
    {
        using var sftp = new SftpClient(
            _settings.Host,
            _settings.Port,
            _settings.Username,
            _settings.Password);

        sftp.Connect();

        using var fileStream = new FileStream(localFilePath, FileMode.Open);
        sftp.UploadFile(fileStream, $"{_settings.RemotePath}/{fileName}");

        sftp.Disconnect();
    }
}