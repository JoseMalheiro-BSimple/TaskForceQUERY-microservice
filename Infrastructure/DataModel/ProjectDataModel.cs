using Domain.Interfaces;
using Domain.Visitor;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataModel;

[Table("Project")]
public class ProjectDataModel : IProjectVisitor
{
    public Guid Id { get; set; }

    public ProjectDataModel()
    {
    }

    public ProjectDataModel(IProject project)
    {
        Id = project.Id;
    }
}
