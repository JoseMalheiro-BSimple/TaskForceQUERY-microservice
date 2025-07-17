using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory;

public class SubjectFactory : ISubjectFactory
{
    private readonly ISubjectRepository _subjectRepository;

    public SubjectFactory(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task<ISubject> Create(Guid id)
    {
        ISubject? subject = await _subjectRepository.GetByIdAsync(id);

        if (subject != null)
            throw new ArgumentException("Subject already exisit!");

        return new Subject(id);
    }

    public ISubject Create(ISubjectVisitor visitor)
    {
        return new Subject(visitor.Id);
    }
}
