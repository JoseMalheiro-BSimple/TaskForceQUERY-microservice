using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProjectRepository : GenericRepositoryEF<IProject, Project, ProjectDataModel>, IProjectRepository
{
    private readonly IMapper _mapper;
    public ProjectRepository(TaskForceCMDContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }

    public override IProject? GetById(Guid id)
    {
        var pDM = _context.Set<ProjectDataModel>()
                .FirstOrDefault(p => p.Id == id);

        if (pDM == null)
            return null;

        return _mapper.Map<ProjectDataModel, IProject>(pDM);
    }

    public override async Task<IProject?> GetByIdAsync(Guid id)
    {
        var pDM = await _context.Set<ProjectDataModel>()
                .FirstOrDefaultAsync(p => p.Id == id);

        if (pDM == null)
            return null;

        return _mapper.Map<ProjectDataModel, IProject>(pDM);
    }
}
