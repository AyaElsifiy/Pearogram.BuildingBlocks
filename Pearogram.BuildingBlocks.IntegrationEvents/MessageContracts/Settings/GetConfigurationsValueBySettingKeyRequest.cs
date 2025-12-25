using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.Settings
{
    public record GetConfigurationsValueBySettingKeyRequest(ESettingsKey SettingsKey);
}
