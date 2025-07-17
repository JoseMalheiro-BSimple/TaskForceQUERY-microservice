using Domain.Interfaces;
using Domain.ValueObjects;
using Domain.Visitor;

namespace Domain.IRepository;

public interface ITaskForceRepository : IGenericRepositoryEF<ITaskForce, ITaskForce, ITaskForceVisitor> 
{
    Task<IEnumerable<ITaskForce>> GetByProject(Guid projectId);
    Task<IEnumerable<ITaskForce>> GetByPeriod(PeriodDate period);
    Task<IEnumerable<ITaskForce>> GetByDescription(string description);
    Task<IEnumerable<ITaskForce>> GetBySubject(Guid subjectId);
}
