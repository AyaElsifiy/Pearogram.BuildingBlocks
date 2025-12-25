using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.Domain.Contract;

public interface ILanguageContext
{
    ELanguageCode GetCurrentLanguage();
}