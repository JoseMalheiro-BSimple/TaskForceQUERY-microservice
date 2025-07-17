using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SubjectRepository : GenericRepositoryEF<ISubject, Subject, SubjectDataModel>, ISubjectRepository
{
    private readonly IMapper _mapper;
    public SubjectRepository(TaskForceCMDContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }

    public override ISubject? GetById(Guid id)
    {
        var sDM = _context.Set<SubjectDataModel>()
                .FirstOrDefault(s => s.Id == id);

        if (sDM == null)
            return null;

        return _mapper.Map<SubjectDataModel, ISubject>(sDM);
    }

    public override async Task<ISubject?> GetByIdAsync(Guid id)
    {
        var sDM = await _context.Set<SubjectDataModel>()
                .FirstOrDefaultAsync(s => s.Id == id);

        if (sDM == null)
            return null;

        return _mapper.Map<SubjectDataModel, ISubject>(sDM);
    }
}
