namespace Application.DTO;

public record TaskForceCollaboratorDTO
{
    public Guid Id { get; }
    public Guid TaskForceId { get; }
    public Guid CollaboratorId { get; }

    public TaskForceCollaboratorDTO(Guid id, Guid taskForceId, Guid collaboratorId)
    {
        Id = id;
        TaskForceId = taskForceId;
        CollaboratorId = collaboratorId;
    }
}
