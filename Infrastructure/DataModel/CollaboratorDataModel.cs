using Domain.Interfaces;
using Domain.Visitor;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataModel;

[Table("Collaborator")]
public class CollaboratorDataModel : ICollaboratorVisitor
{
    public Guid Id { get; set; }

    public CollaboratorDataModel()
    {
    }

    public CollaboratorDataModel(ICollaborator collaborator)
    {
        Id = collaborator.Id;
    }
}
