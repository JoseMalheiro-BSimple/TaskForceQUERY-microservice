using Domain.ValueObjects;

namespace Domain.Interfaces;

public interface ITaskForce
{
    Guid Id { get; }
    Guid SubjectId { get; }
    Guid ProjectId { get; }
    Description Description { get; set; }
    PeriodDate PeriodDate { get; set; }
}
