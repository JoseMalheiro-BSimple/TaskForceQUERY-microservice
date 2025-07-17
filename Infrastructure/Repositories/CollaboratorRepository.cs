using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CollaboratorRepository : GenericRepositoryEF<ICollaborator, Collaborator, CollaboratorDataModel>, ICollaboratorRepository
{
    private readonly IMapper _mapper;
    public CollaboratorRepository(TaskForceCMDContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }

    public override ICollaborator? GetById(Guid id)
    {
        var cDM = _context.Set<CollaboratorDataModel>()
                .FirstOrDefault(c => c.Id == id);

        if (cDM == null)
            return null;

        return _mapper.Map<CollaboratorDataModel, ICollaborator>(cDM);
    }

    public override async Task<ICollaborator?> GetByIdAsync(Guid id)
    {
        var cDM = await _context.Set<CollaboratorDataModel>()
                .FirstOrDefaultAsync(c => c.Id == id);

        if (cDM == null)
            return null;

        return _mapper.Map<CollaboratorDataModel, ICollaborator>(cDM);
    }
}
