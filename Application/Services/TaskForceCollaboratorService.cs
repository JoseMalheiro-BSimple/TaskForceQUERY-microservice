using Application.DTO;
using Application.IServices;
using Domain.Factory;
using Domain.Interfaces;
using Domain.IRepository;

namespace Application.Services;

public class TaskForceCollaboratorService : ITaskForceCollaboratorService
{
    private readonly ITaskForceCollaboratorRepository _taskForceCollaboratorRepository;
    private readonly ITaskForceCollaboratorFactory _taskForceCollaboratorFactory;

    public TaskForceCollaboratorService(ITaskForceCollaboratorRepository taskForceCollaboratorRepository, ITaskForceCollaboratorFactory taskForceCollaboratorFactory)
    {
        _taskForceCollaboratorRepository = taskForceCollaboratorRepository;
        _taskForceCollaboratorFactory = taskForceCollaboratorFactory;
    }

    public async Task AddConsumed(TaskForceCollaboratorDTO taskForceCollabDTO)
    {
        ITaskForceCollaborator? taskForceCollaborator = await _taskForceCollaboratorRepository.GetByIdAsync(taskForceCollabDTO.Id);

        if (taskForceCollaborator != null)
            return;

        ITaskForceCollaborator toAdd = await _taskForceCollaboratorFactory.Create(taskForceCollabDTO.Id, taskForceCollabDTO.TaskForceId, taskForceCollabDTO.CollaboratorId);
        toAdd = await _taskForceCollaboratorRepository.AddAsync(toAdd);

        if (toAdd == null)
            throw new Exception("Internal Error!");
    }

    public async Task<Result<IEnumerable<TaskForceCollaboratorDTO>>> GetAllByCollaborator(Guid collaboratorId)
    {
        try
        {
            var collaborators = await _taskForceCollaboratorRepository.GetByCollaborator(collaboratorId);

            if (collaborators == null || !collaborators.Any())
                return Result<IEnumerable<TaskForceCollaboratorDTO>>.Failure(Error.NotFound("No collaborators found for the given ID."));

            var dtos = collaborators.Select(c => new TaskForceCollaboratorDTO(c.Id, c.TaskForceId, c.CollaboratorId));

            return Result<IEnumerable<TaskForceCollaboratorDTO>>.Success(dtos);
        } catch (Exception ex)
        {
            return Result<IEnumerable<TaskForceCollaboratorDTO>>.Failure(Error.InternalServerError(ex.Message));
        }
    }

    public async Task<Result<IEnumerable<TaskForceCollaboratorDTO>>> GetAllByTaskForceId(Guid taskForceId)
    {
        try
        {
            var taskForceCollaborators = await _taskForceCollaboratorRepository.GetAllForTaskForce(taskForceId);

            if (taskForceCollaborators == null || !taskForceCollaborators.Any())
                return Result<IEnumerable<TaskForceCollaboratorDTO>>.Failure(Error.NotFound("No task forces found for the given ID."));

            var dtos = taskForceCollaborators.Select(c => new TaskForceCollaboratorDTO(c.Id, c.TaskForceId, c.CollaboratorId));


            return Result<IEnumerable<TaskForceCollaboratorDTO>>.Success(dtos);

        }
        catch (Exception ex)
        {
            return Result<IEnumerable<TaskForceCollaboratorDTO>>.Failure(Error.InternalServerError(ex.Message));
        }
    }
}
