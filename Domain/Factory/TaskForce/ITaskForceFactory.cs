using Domain.Interfaces;
using Domain.ValueObjects;
using Domain.Visitor;

namespace Domain.Factory;

public interface ITaskForceFactory
{
    Task<ITaskForce> Create(Guid id, Guid subjectId, Guid projectId, string descriptionString, DateOnly taskForceInitDate, DateOnly taskForceEndDate);
    ITaskForce Create(Guid id, Guid subjectId, Guid projectId, Description description, PeriodDate periodDate);
    ITaskForce Create(ITaskForceVisitor visitor);
}
