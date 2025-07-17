using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Domain.ValueObjects;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TaskForceRepository : GenericRepositoryEF<ITaskForce, TaskForce, TaskForceDataModel>, ITaskForceRepository
{
    private readonly IMapper _mapper;
    public TaskForceRepository(TaskForceCMDContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }

    public override ITaskForce? GetById(Guid id)
    {
        var tfDM = _context.Set<TaskForceDataModel>()
                .FirstOrDefault(tf => tf.Id == id);

        if (tfDM == null)
            return null;

        return _mapper.Map<TaskForceDataModel, ITaskForce>(tfDM);
    }

    public override async Task<ITaskForce?> GetByIdAsync(Guid id)
    {
        var tfDM = await _context.Set<TaskForceDataModel>()
                .FirstOrDefaultAsync(tf => tf.Id == id);

        if (tfDM == null)
            return null;

        return _mapper.Map<TaskForceDataModel, ITaskForce>(tfDM);
    }

    public async Task<IEnumerable<ITaskForce>> GetByPeriod(PeriodDate period)
    {
        var tfDMs = await _context.Set<TaskForceDataModel>()
                          .Where(tf => tf.PeriodDate.InitDate <= period.EndDate && tf.PeriodDate.EndDate >= period.InitDate)
                          .ToListAsync();

        return tfDMs.Select(_mapper.Map<TaskForceDataModel, ITaskForce>);
    }

    public async Task<IEnumerable<ITaskForce>> GetByProject(Guid projectId)
    {
        var tfDMs = await _context.Set<TaskForceDataModel>()
                                  .Where(tf => tf.ProjectId == projectId)
                                  .ToListAsync();

        return tfDMs.Select(_mapper.Map<TaskForceDataModel, ITaskForce>);
    }

    public async Task<IEnumerable<ITaskForce>> GetByDescription(string description)
    {
        var tfDMs = await _context.Set<TaskForceDataModel>()
                                  .Where(tf => tf.Description.Value == description)
                                  .ToListAsync();

        return tfDMs.Select(_mapper.Map<TaskForceDataModel, ITaskForce>);
    }

    public async Task<IEnumerable<ITaskForce>> GetBySubject(Guid subjectId)
    {
        var tfDMs = await _context.Set<TaskForceDataModel>()
                                  .Where(tf => tf.SubjectId == subjectId)
                                  .ToListAsync();

        return tfDMs.Select(_mapper.Map<TaskForceDataModel, ITaskForce>);
    }
}
