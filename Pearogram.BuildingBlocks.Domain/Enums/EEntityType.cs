namespace Pearogram.BuildingBlocks.Domain.Enums;

/// <summary>
/// Represents all major entity types used across the system for generic operations 
/// such as Documents, Logging, Notifications, Education, etc.
/// Grouped by module for maintainability.
/// </summary>

// Updated values of entities with database 28/10/2025
public enum EEntityType
{
    #region Organization Module

    User = 1,
    Roles,
    Company,
    Department,
    Feature,
    Operation,
    RoleOperation,
    Template = 8,

    #endregion

    #region Attachment Module

    Document = 9,
    RequiredFileSubmission,
    RequiredFilesConfig = 11,

    #endregion

    #region Communications Module (Notification Module)

    Announcements = 12,
    CommunicationLogs,
    CommunicationTypes,
    CommunicationConfigurations,
    CommunicationTemplate,
    CommunicationType,
    CommunicationContentType,
    DeviceToken = 19,
    #endregion

    #region Settings Module 

    EntityTranslation,
    SettingsGroups,
    SettingsDetails,
    MasterData,
    MasterDataType,
    RecentlyDeleted,

    #endregion

    #region Task Manamgnet [TM] Module

    Task,
    Client,
    Comment,
    CommentMention,
    Logs,
    Member,
    MenusMain,
    MenusMainDetails,
    Project,
    Team,
    TeamMember,
    TeamProjects,
    TenantInfo,
    Ticket,
    WorkLog,

    #endregion

    #region Education Core Module [LMS]

    AcademicTerm,
    AcademicYear,
    AcademicYearTerm,
    AdmissionApplicationLogs,
    AssessmentSlot,
    AssessmentSlotApplications,
    AssessmentSlotCoordinators,
    Class,
    EducationTrack,
    Grade,
    GradingCategory,
    GradingScale,
    GradingScaleLevel,
    GradingScheme,
    GradingSubjectSystem,
    GradingSubjectSystemLevel,
    Group,
    GroupCoordinators,
    GroupStudents,
    HomeRoomTeacher,
    Lesson,
    LessonSection,
    Material,
    StudentAcademicData,
    StudentExtraData,
    StudentParent,
    StudyPath,
    StudyPathTrack,
    Subject,
    SubjectGradeConfig,
    TeacherSubjectGrades,
    Topic,
    Student,
    Parent,
    Teacher,
    AdmissionApplication,
    Question,
    QuestionAnswer,
    Exam,
    StudentAnswer,
    #endregion
}