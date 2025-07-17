using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Models;

public class TaskForce : ITaskForce
{
    public Guid Id { get; private set; }
    public Guid SubjectId { get; private set; }
    public Guid ProjectId { get; private set; }
    public Description Description { get; set; }
    public PeriodDate PeriodDate { get; set; }

    public TaskForce(Guid id, Guid subjectId, Guid projectId, Description description, PeriodDate periodDate)
    {
        Id = id;
        SubjectId = subjectId;
        ProjectId = projectId;
        Description = description;
        PeriodDate = periodDate;
    }
}
