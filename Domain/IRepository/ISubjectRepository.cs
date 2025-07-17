using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.IRepository;

public interface ISubjectRepository : IGenericRepositoryEF<ISubject, Subject, ISubjectVisitor> { }
