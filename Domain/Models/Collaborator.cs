﻿using Domain.Interfaces;

namespace Domain.Models;

public class Collaborator : ICollaborator
{
    public Guid Id { get; private set; }

    public Collaborator(Guid id)
    {
        Id = id;
    }
}
