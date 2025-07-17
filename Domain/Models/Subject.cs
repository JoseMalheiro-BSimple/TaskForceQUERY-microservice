using Domain.Interfaces;

namespace Domain.Models;

public class Subject : ISubject
{
    public Guid Id { get; private set; }

    public Subject(Guid id)
    {
        Id = id;
    }
}
