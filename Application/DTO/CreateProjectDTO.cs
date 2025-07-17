namespace Application.DTO;

public record CreateProjectDTO
{
    public Guid Id { get; }

    public CreateProjectDTO(Guid id)
    {
        Id = id;
    }
}
