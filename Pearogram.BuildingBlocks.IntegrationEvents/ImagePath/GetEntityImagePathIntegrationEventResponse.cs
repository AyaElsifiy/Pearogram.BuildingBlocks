namespace Pearogram.BuildingBlocks.IntegrationEvents.ImagePath;

public class GetEntityImagePathIntegrationEventResponse
{
    public string Path { get; }
    public string FileName { get; }

    public GetEntityImagePathIntegrationEventResponse(string path, string fileName)
    {
        Path = path;
        FileName = fileName;
    }
}

