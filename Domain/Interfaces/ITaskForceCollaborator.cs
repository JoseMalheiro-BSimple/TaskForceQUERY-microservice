namespace Domain.Interfaces;

public interface ITaskForceCollaborator
{
    Guid Id { get; }
    Guid TaskForceId { get; }
    Guid CollaboratorId { get; }
}
