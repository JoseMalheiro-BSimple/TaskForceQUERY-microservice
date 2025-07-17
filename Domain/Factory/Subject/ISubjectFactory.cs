using Domain.Interfaces;
using Domain.Visitor;

namespace Domain.Factory;

public interface ISubjectFactory
{
    Task<ISubject> Create(Guid id);
    ISubject Create(ISubjectVisitor visitor);
}
