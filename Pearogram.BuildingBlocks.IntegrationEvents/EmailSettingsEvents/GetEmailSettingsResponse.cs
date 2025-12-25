namespace Pearogram.BuildingBlocks.IntegrationEvents.EmailSettingsEvents;

public class GetEmailSettingsResponse
{
    public string From { get; set; }
    public string SmtpPassword { get; set; }
    public string SmtpServer { get; set; }
    public int Port { get; set; }
}
