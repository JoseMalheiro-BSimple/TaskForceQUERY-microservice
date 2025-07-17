using Domain.Interfaces;
using Domain.Visitor;

namespace Domain.Factory;

public interface IProjectFactory
{
    Task<IProject> Create(Guid id);
    IProject Create(IProjectVisitor visitor);
}
