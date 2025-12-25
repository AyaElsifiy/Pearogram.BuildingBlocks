namespace Pearogram.BuildingBlocks.IntegrationEvents.MessageContracts.EducationsCore;

public sealed class ApplicationApprovedIntegrationEvent : ApplicationStatusIntegrationEvent
{
    public ApplicationApprovedIntegrationEvent(string email, string phone, string name,
        Guid applicationId, string? studentName, Guid parentId, string? academicYear,
       string? gradeLevel,string applicationCode) :
        base(email, phone, name, applicationId, parentId)
    {
       StudentName = studentName;
        AcademicYear = academicYear;
        GradeLevel = gradeLevel;
        ApplicationCode = applicationCode;
    }

    public string? StudentName { get; set; }
    public string? AcademicYear { get; set; }
    public string? GradeLevel { get; set; }
    public string ApplicationCode { get; set; }
}


