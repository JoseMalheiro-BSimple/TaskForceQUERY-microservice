using Application.DTO;

namespace Application.IServices;

public interface ITaskForceService
{
    Task AddConsumed(ConsumeTaskForceDTO createDTO);
    Task<Result<IEnumerable<TaskForceDTO>>> GetAll();
    Task<Result<IEnumerable<TaskForceDTO>>> GetAllByProject(Guid projectId);
    Task<Result<IEnumerable<TaskForceDTO>>> GetAllBySubject(Guid subjectId);
    Task<Result<IEnumerable<TaskForceDTO>>> GetAllByPeriod(PeriodDTO periodDate);
    Task<Result<IEnumerable<TaskForceDTO>>> GetAllByDescription(string description);
}
