using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory;

public class ProjectFactory : IProjectFactory
{
    private readonly IProjectRepository _projectRepository;

    public ProjectFactory(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IProject> Create(Guid id)
    {
        IProject? project = await _projectRepository.GetByIdAsync(id);

        if (project != null)
            throw new ArgumentException("Project already exists!");

        return new Project(id);
    }

    public IProject Create(IProjectVisitor visitor)
    {
        return new Project(visitor.Id);
    }
}
