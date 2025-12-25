using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.Application.Helpers;

public static class EntityTypeHelper
{
    public static IEnumerable<EEntityType> GetEntityTypesForModule(EModuleType moduleType)
    {
        return moduleType switch
        {
            EModuleType.Organization => new[]
            {
                EEntityType.User,
                EEntityType.Roles,
                EEntityType.Company,
                EEntityType.Department,
                EEntityType.Feature,
                EEntityType.Operation,
                EEntityType.RoleOperation,
                EEntityType.Template
            },

            EModuleType.Attachment => new[]
            {
                EEntityType.Document,
                EEntityType.RequiredFileSubmission,
                EEntityType.RequiredFilesConfig
            },

            EModuleType.Notification => new[]
            {
                EEntityType.Announcements,
                EEntityType.CommunicationLogs,
                EEntityType.CommunicationTypes,
                EEntityType.CommunicationConfigurations,
                EEntityType.CommunicationTemplate,
                EEntityType.CommunicationType,
                EEntityType.CommunicationContentType,
                EEntityType.DeviceToken
            },

            EModuleType.Settings => new[]
            {
                EEntityType.EntityTranslation,
                EEntityType.SettingsGroups,
                EEntityType.SettingsDetails,
                EEntityType.MasterData,
                EEntityType.MasterDataType,
                EEntityType.RecentlyDeleted
            },

            EModuleType.TaskManagement => new[]
            {
                EEntityType.Task,
                EEntityType.Client,
                EEntityType.Comment,
                EEntityType.CommentMention,
                EEntityType.Logs,
                EEntityType.Member,
                EEntityType.MenusMain,
                EEntityType.MenusMainDetails,
                EEntityType.Project,
                EEntityType.Team,
                EEntityType.TeamMember,
                EEntityType.TeamProjects,
                EEntityType.TenantInfo,
                EEntityType.Ticket,
                EEntityType.WorkLog
            },

            EModuleType.EducationCore => new[]
            {
                EEntityType.AcademicTerm,
                EEntityType.AcademicYear,
                EEntityType.AcademicYearTerm,
                EEntityType.AdmissionApplicationLogs,
                EEntityType.AssessmentSlot,
                EEntityType.AssessmentSlotApplications,
                EEntityType.AssessmentSlotCoordinators,
                EEntityType.Class,
                EEntityType.EducationTrack,
                EEntityType.Grade,
                EEntityType.GradingCategory,
                EEntityType.GradingScale,
                EEntityType.GradingScaleLevel,
                EEntityType.GradingScheme,
                EEntityType.GradingSubjectSystem,
                EEntityType.GradingSubjectSystemLevel,
                EEntityType.Group,
                EEntityType.GroupCoordinators,
                EEntityType.GroupStudents,
                EEntityType.HomeRoomTeacher,
                EEntityType.Lesson,
                EEntityType.LessonSection,
                EEntityType.Material,
                EEntityType.StudentAcademicData,
                EEntityType.StudentExtraData,
                EEntityType.StudentParent,
                EEntityType.StudyPath,
                EEntityType.StudyPathTrack,
                EEntityType.Subject,
                EEntityType.SubjectGradeConfig,
                EEntityType.TeacherSubjectGrades,
                EEntityType.Topic,
                EEntityType.Student,
                EEntityType.Parent,
                EEntityType.Teacher
            },

            _ => Array.Empty<EEntityType>()
        };
    }
}
