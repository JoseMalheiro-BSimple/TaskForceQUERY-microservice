using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.IRepository;

public interface ITaskForceCollaboratorRepository : IGenericRepositoryEF<ITaskForceCollaborator, TaskForceCollaborator, ITaskForceCollaboratorVisitor>
{
    Task<IEnumerable<ITaskForceCollaborator>> GetAllForTaskForce(Guid taskForceId);
    Task<IEnumerable<ITaskForceCollaborator>> GetByCollaborator(Guid collaboratorId);
}
