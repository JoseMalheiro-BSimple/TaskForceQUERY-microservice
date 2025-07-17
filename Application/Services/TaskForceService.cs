using Application.DTO;
using Application.IServices;
using Domain.Factory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.ValueObjects;

namespace Application.Services;

public class TaskForceService : ITaskForceService
{
    private readonly ITaskForceRepository _taskForceRepository;
    private readonly ITaskForceFactory _taskForceFactory;

    public TaskForceService(ITaskForceRepository taskForceRepository, ITaskForceFactory taskForceFactory)
    {
        _taskForceRepository = taskForceRepository;
        _taskForceFactory = taskForceFactory;
    }

    public async Task AddConsumed(ConsumeTaskForceDTO createDTO)
    {
        ITaskForce? taskforce = await _taskForceRepository.GetByIdAsync(createDTO.Id);

        if (taskforce != null)
            return;

        Description description = new Description(createDTO.Description);
        PeriodDate period = new PeriodDate(createDTO.InitDate, createDTO.EndDate);
        
        ITaskForce toAdd = _taskForceFactory.Create(createDTO.Id, createDTO.SubjectId, createDTO.ProjectId, description, period);

        if (toAdd == null)
            throw new Exception("Internal Error!");
    }

    public async Task<Result<IEnumerable<TaskForceDTO>>> GetAll()
    {
        try
        {
            var taskforces = await _taskForceRepository.GetAllAsync();

            if (taskforces == null || !taskforces.Any())
                return Result<IEnumerable<TaskForceDTO>>.Failure(Error.NotFound("No task forces match the given description."));

            var dtos = taskforces.Select(t => new TaskForceDTO(
                t.Id,
                t.SubjectId,
                t.ProjectId,
                t.Description.Value,
                t.PeriodDate.InitDate,
                t.PeriodDate.EndDate
            ));

            return Result<IEnumerable<TaskForceDTO>>.Success(dtos);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<TaskForceDTO>>.Failure(Error.InternalServerError(ex.Message));
        }
    }

    public async Task<Result<IEnumerable<TaskForceDTO>>> GetAllByDescription(string description)
    {
        try
        {
            var taskforces = await _taskForceRepository.GetByDescription(description);

            if (taskforces == null || !taskforces.Any())
                return Result<IEnumerable<TaskForceDTO>>.Failure(Error.NotFound("No task forces match the given description."));

            var dtos = taskforces.Select(t => new TaskForceDTO(
                t.Id,
                t.SubjectId,
                t.ProjectId,
                t.Description.Value,
                t.PeriodDate.InitDate,
                t.PeriodDate.EndDate
            ));

            return Result<IEnumerable<TaskForceDTO>>.Success(dtos);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<TaskForceDTO>>.Failure(Error.InternalServerError(ex.Message));
        }
    }

    public async Task<Result<IEnumerable<TaskForceDTO>>> GetAllByPeriod(PeriodDTO periodDate)
    {
        try
        {
            var period = new PeriodDate(periodDate.InitDate, periodDate.EndDate);
            var taskforces = await _taskForceRepository.GetByPeriod(period);

            if (taskforces == null || !taskforces.Any())
                return Result<IEnumerable<TaskForceDTO>>.Failure(Error.NotFound("No task forces found in the given period."));

            var dtos = taskforces.Select(t => new TaskForceDTO(
                t.Id,
                t.SubjectId,
                t.ProjectId,
                t.Description.Value,
                t.PeriodDate.InitDate,
                t.PeriodDate.EndDate
            ));

            return Result<IEnumerable<TaskForceDTO>>.Success(dtos);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<TaskForceDTO>>.Failure(Error.InternalServerError(ex.Message));
        }
    }

    public async Task<Result<IEnumerable<TaskForceDTO>>> GetAllByProject(Guid projectId)
    {
        try
        {
            var taskforces = await _taskForceRepository.GetByProject(projectId);

            if (taskforces == null || !taskforces.Any())
                return Result<IEnumerable<TaskForceDTO>>.Failure(Error.NotFound("No task forces found for the given project."));

            var dtos = taskforces.Select(t => new TaskForceDTO(
                t.Id,
                t.SubjectId,
                t.ProjectId,
                t.Description.Value,
                t.PeriodDate.InitDate,
                t.PeriodDate.EndDate
            ));

            return Result<IEnumerable<TaskForceDTO>>.Success(dtos);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<TaskForceDTO>>.Failure(Error.InternalServerError(ex.Message));
        }
    }

    public async Task<Result<IEnumerable<TaskForceDTO>>> GetAllBySubject(Guid subjectId)
    {
        try
        {
            var taskforces = await _taskForceRepository.GetBySubject(subjectId);

            if (taskforces == null || !taskforces.Any())
                return Result<IEnumerable<TaskForceDTO>>.Failure(Error.NotFound("No task forces found for the given subject."));

            var dtos = taskforces.Select(t => new TaskForceDTO(
                t.Id,
                t.SubjectId,
                t.ProjectId,
                t.Description.Value,
                t.PeriodDate.InitDate,
                t.PeriodDate.EndDate
            ));

            return Result<IEnumerable<TaskForceDTO>>.Success(dtos);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<TaskForceDTO>>.Failure(Error.InternalServerError(ex.Message));
        }
    }
}
