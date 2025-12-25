using Pearogram.BuildingBlocks.Domain.Contract;
using Pearogram.BuildingBlocks.Domain.Enums;
using System.Text.Json.Serialization;

namespace Pearogram.BuildingBlocks.Application.Dtos.Settings;

public abstract record  TranslatableDto : ITranslatable
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public abstract EEntityType GetEntityType();
}