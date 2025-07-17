using Application.DTO;
using Application.IServices;
using Domain.Factory;
using Domain.Interfaces;
using Domain.IRepository;

namespace Application.Services;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _subjectRepository;
    private readonly ISubjectFactory _subjectFactory;

    public SubjectService(ISubjectRepository subjectRepository, ISubjectFactory subjectFactory)
    {
        _subjectRepository = subjectRepository;
        _subjectFactory = subjectFactory;
    }

    public async Task AddConsumed(CreateSubjectDTO createDTO)
    {
        ISubject subject = await _subjectFactory.Create(createDTO.Id);
        subject = await _subjectRepository.AddAsync(subject);

        if (subject == null)
            throw new Exception("Internal Error!");
    }
}
