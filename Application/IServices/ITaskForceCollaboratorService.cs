using Application.DTO;

namespace Application.IServices;

public interface ITaskForceCollaboratorService
{
    Task AddConsumed(TaskForceCollaboratorDTO taskForceCollabDTO);
    Task<Result<IEnumerable<TaskForceCollaboratorDTO>>> GetAllByCollaborator(Guid collaboratorId);
    Task<Result<IEnumerable<TaskForceCollaboratorDTO>>> GetAllByTaskForceId(Guid taskForceId);
}
