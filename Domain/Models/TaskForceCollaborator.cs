using Domain.Interfaces;

namespace Domain.Models;

public class TaskForceCollaborator : ITaskForceCollaborator
{
    public Guid Id { get; private set; }

    public Guid TaskForceId {  get; private set; }

    public Guid CollaboratorId { get; private set; }

    public TaskForceCollaborator(Guid id, Guid taskForceId, Guid collaboratorId)
    {
        Id = id;
        TaskForceId = taskForceId;
        CollaboratorId = collaboratorId;
    }
}
