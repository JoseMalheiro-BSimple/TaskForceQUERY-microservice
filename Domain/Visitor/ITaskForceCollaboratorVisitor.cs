namespace Domain.Visitor;

public interface ITaskForceCollaboratorVisitor
{
    Guid Id { get; }
    Guid TaskForceId { get; }
    Guid CollaboratorId { get; }
}
