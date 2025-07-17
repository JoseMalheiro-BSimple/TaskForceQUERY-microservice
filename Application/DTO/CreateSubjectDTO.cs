namespace Application.DTO;

public record CreateSubjectDTO
{
    public Guid Id { get; }

    public CreateSubjectDTO(Guid id)
    {
        Id = id;
    }
}
