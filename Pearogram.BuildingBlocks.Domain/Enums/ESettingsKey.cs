namespace Pearogram.BuildingBlocks.Domain.Enums;

public enum ESettingsKey
{
    // Email Server Settings
    Port = 1,

    SmtpServer,
    SmtpPassword,
    From,

    //Application Settings
    AppName,
    SupportLanguage,
    DefaultLanguage,
    AppUrl,
    DefaultCompanyId,

    // Communication Settings
    SupportEmail,

    //Worklog Settings
    IsTimeRestrictedMood,

    //Academic Settings
    MaxNumberOfClasses,
    MaxNumberOfHomeroomTeacherIds,
    MaxPortalAccessParentAccouants,
    

}
