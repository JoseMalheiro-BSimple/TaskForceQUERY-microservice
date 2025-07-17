namespace Application.DTO;

public record CreateCollaboratorDTO
{
    public Guid Id { get; }

    public CreateCollaboratorDTO(Guid id)
    {
        Id = id;
    }
}
