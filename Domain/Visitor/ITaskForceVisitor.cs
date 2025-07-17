using Domain.Models;
using Domain.ValueObjects;

namespace Domain.Visitor;

public interface ITaskForceVisitor
{
    Guid Id { get; }
    Guid SubjectId { get; }
    Guid ProjectId { get; }
    Description Description { get; }
    PeriodDate PeriodDate { get; }
}
