﻿using Application.DTO;
using Application.IServices;
using Domain.Factory;
using Domain.Interfaces;
using Domain.IRepository;

namespace Application.Services;

public class CollaboratorService : ICollaboratorService
{
    private readonly ICollaboratorRepository _collaboratorRepository;
    private readonly ICollaboratorFactory _collaboratorFactory;

    public CollaboratorService(ICollaboratorRepository collaboratorRepository, ICollaboratorFactory collaboratorFactory)
    {
        _collaboratorRepository = collaboratorRepository;
        _collaboratorFactory = collaboratorFactory;
    }

    public async Task AddConsumed(CreateCollaboratorDTO createDTO)
    {
        ICollaborator collaborator = collaborator = await _collaboratorFactory.Create(createDTO.Id);
        collaborator = await _collaboratorRepository.AddAsync(collaborator);

        if (collaborator == null)
            throw new Exception("Internal Error!");
    }
}
