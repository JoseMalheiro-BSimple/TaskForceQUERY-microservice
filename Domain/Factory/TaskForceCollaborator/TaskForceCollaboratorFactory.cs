using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory;
public class TaskForceCollaboratorFactory : ITaskForceCollaboratorFactory
{
    private readonly ITaskForceCollaboratorRepository _taskForceCollaboratorRepository;
    private readonly ITaskForceRepository _taskForceRepository;
    private readonly ICollaboratorRepository _collaboratorRepository;

    public TaskForceCollaboratorFactory(ITaskForceCollaboratorRepository taskForceCollaboratorRepository, ITaskForceRepository taskForceRepository, ICollaboratorRepository collaboratorRepository)
    {
        _taskForceCollaboratorRepository = taskForceCollaboratorRepository;
        _taskForceRepository = taskForceRepository;
        _collaboratorRepository = collaboratorRepository;
    }

    public async Task<ITaskForceCollaborator> Create(Guid id, Guid taskForceId, Guid collaboratorId)
    {
        ITaskForceCollaborator? taskForceCollaborator = await _taskForceCollaboratorRepository.GetByIdAsync(id);
        ITaskForce? taskForce = await _taskForceRepository.GetByIdAsync(taskForceId);
        ICollaborator? collaborator = await _collaboratorRepository.GetByIdAsync(collaboratorId);

        if (taskForceCollaborator != null)
            throw new ArgumentException("Association between task force and collaborator with this id already exisits!");

        if (taskForce != null)
            throw new ArgumentNullException("Task force doesn't exist!");

        if (collaborator == null)
            throw new ArgumentException("Collaborator doesn't exist!");

        return new TaskForceCollaborator(id, taskForceId, collaboratorId);
    }

    public ITaskForceCollaborator Create(ITaskForceCollaboratorVisitor visitor)
    {
        return new TaskForceCollaborator(visitor.Id, visitor.TaskForceId, visitor.CollaboratorId);
    }
}
