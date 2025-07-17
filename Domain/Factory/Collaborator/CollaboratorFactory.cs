using Domain.Interfaces;
using Domain.Visitor;
using Domain.Models;
using Domain.IRepository;

namespace Domain.Factory;
public class CollaboratorFactory : ICollaboratorFactory
{
    private readonly ICollaboratorRepository _collaboratorRepository;

    public CollaboratorFactory(ICollaboratorRepository collaboratorRepository) 
    { 
        _collaboratorRepository = collaboratorRepository;
    }

    public async Task<ICollaborator> Create(Guid id)
    {
        ICollaborator? collaborator = await _collaboratorRepository.GetByIdAsync(id);

        if (collaborator != null)
            throw new ArgumentException("Collaborator already exists!");

        return new Collaborator(id);
    }

    public ICollaborator Create(ICollaboratorVisitor visitor)
    {
        return new Collaborator(visitor.Id);
    }
}
