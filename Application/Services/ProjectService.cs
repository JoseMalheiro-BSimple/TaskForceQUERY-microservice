using Application.DTO;
using Application.IServices;
using Domain.Factory;
using Domain.Interfaces;
using Domain.IRepository;

namespace Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IProjectFactory _projectFactory;

    public ProjectService(IProjectRepository projectRepository, IProjectFactory projectFactory)
    {
        _projectRepository = projectRepository;
        _projectFactory = projectFactory;
    }

    public async Task AddConsumed(CreateProjectDTO createDTO)
    {
        IProject project = await _projectFactory.Create(createDTO.Id);
        project = await _projectRepository.AddAsync(project);

        if (project == null)
            throw new Exception("Internal Error!");
    }
}
