using Domain.Interfaces;
using Domain.Visitor;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataModel;

[Table("TaskForceCollaborator")]
public class TaskForceCollaboratorDataModel : ITaskForceCollaboratorVisitor
{
    public Guid Id { get; set; }

    public Guid TaskForceId { get; set; }

    public Guid CollaboratorId  { get; set; }

    public TaskForceCollaboratorDataModel()
    {
    }

    public TaskForceCollaboratorDataModel(ITaskForceCollaborator taskForceCollaborator)
    {
        Id = taskForceCollaborator.Id;
        TaskForceId = taskForceCollaborator.TaskForceId;
        CollaboratorId = taskForceCollaborator.CollaboratorId;
    }
}
