namespace Pearogram.BuildingBlocks.Domain.Enums;

/// <summary>
/// Maps to a shared enum for cross-system references 
/// </summary>
public enum ECommunicationTypes
{
    // TM Module
    NotifyMe = 1,
    NotifyMyTeam,
    NewTaskCreated,
    TaskUpdated,
    TaskAssigned,
    TaskReopened,
    TaskOverdue,
    TaskDueDateChanged,
    TaskCompleted,
    TaskPending,

    // Org & Auth Module
    NewUserCreated,
    ForgetPassword,

    // LMS Module
    ApplicationApproved,
    ApplicationRefused,
    ApplicationWaitingList,
    ApplicationMissedAction
}
