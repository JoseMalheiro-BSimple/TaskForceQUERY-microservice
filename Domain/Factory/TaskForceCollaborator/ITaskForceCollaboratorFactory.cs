using Domain.Interfaces;
using Domain.Visitor;

namespace Domain.Factory;

public interface ITaskForceCollaboratorFactory
{
    Task<ITaskForceCollaborator> Create(Guid id, Guid taskForceId, Guid collaboratorId);
    ITaskForceCollaborator Create(ITaskForceCollaboratorVisitor visitor);
}
