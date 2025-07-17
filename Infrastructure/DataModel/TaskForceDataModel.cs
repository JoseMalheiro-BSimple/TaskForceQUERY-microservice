using Domain.Interfaces;
using Domain.ValueObjects;
using Domain.Visitor;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataModel;

[Table("TaskForce")]
public class TaskForceDataModel : ITaskForceVisitor
{
    public Guid Id { get; set; }

    public Guid SubjectId { get; set; }

    public Guid ProjectId { get; set; }

    public Description Description { get; set; }

    public PeriodDate PeriodDate { get; set; }

    public TaskForceDataModel()
    {
    }

    public TaskForceDataModel(ITaskForce taskForce)
    {
        Id = taskForce.Id;
        SubjectId = taskForce.SubjectId;
        Description = taskForce.Description;
        PeriodDate = taskForce.PeriodDate;
    }
}
