using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.IRepository;

public interface IProjectRepository : IGenericRepositoryEF<IProject, Project, IProjectVisitor> { }
