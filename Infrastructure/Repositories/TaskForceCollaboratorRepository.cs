using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TaskForceCollaboratorRepository : GenericRepositoryEF<ITaskForceCollaborator, TaskForceCollaborator, TaskForceCollaboratorDataModel>, ITaskForceCollaboratorRepository
{
    private readonly IMapper _mapper;
    public TaskForceCollaboratorRepository(TaskForceCMDContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<ITaskForceCollaborator>> GetAllForTaskForce(Guid taskForceId)
    {
        var tfcDMs = await _context.Set<TaskForceCollaboratorDataModel>()
                             .Where(tfc => tfc.TaskForceId == taskForceId)
                             .ToListAsync();

        var tfcs = tfcDMs.Select(_mapper.Map<TaskForceCollaboratorDataModel, ITaskForceCollaborator>);

        return tfcs;
    }

    public async Task<IEnumerable<ITaskForceCollaborator>> GetByCollaborator(Guid collaboratorId)
    {
        var tfDMs = await _context.Set<TaskForceCollaboratorDataModel>()
                          .Where(tf => tf.CollaboratorId == collaboratorId)
                          .ToListAsync();

        return tfDMs.Select(_mapper.Map<TaskForceCollaboratorDataModel, ITaskForceCollaborator>);
    }

    public override ITaskForceCollaborator? GetById(Guid id)
    {
        var tfcDM = _context.Set<TaskForceCollaboratorDataModel>()
                .FirstOrDefault(tfc => tfc.Id == id);

        if (tfcDM == null)
            return null;

        return _mapper.Map<TaskForceCollaboratorDataModel, ITaskForceCollaborator>(tfcDM);
    }

    public override async Task<ITaskForceCollaborator?> GetByIdAsync(Guid id)
    {
        var tfcDM = await _context.Set<TaskForceCollaboratorDataModel>()
                .FirstOrDefaultAsync(tfc => tfc.Id == id);

        if (tfcDM == null)
            return null;

        return _mapper.Map<TaskForceCollaboratorDataModel, ITaskForceCollaborator>(tfcDM);
    }

}
