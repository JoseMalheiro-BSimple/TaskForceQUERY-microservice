using Domain.Interfaces;
using Domain.Visitor;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataModel;

[Table("Subject")]
public class SubjectDataModel : ISubjectVisitor
{
    public Guid Id { get; set; }

    public SubjectDataModel()
    {
    }

    public SubjectDataModel(ISubject subject)
    {
        Id = subject.Id;
    }
}
