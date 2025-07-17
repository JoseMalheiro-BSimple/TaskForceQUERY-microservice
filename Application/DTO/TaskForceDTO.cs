namespace Application.DTO;

public record TaskForceDTO
{
    public Guid Id { get; }
    public Guid SubjectId { get; }
    public Guid ProjectId { get; }
    public string Description { get; }
    public DateOnly InitDate { get; }
    public DateOnly EndDate { get; }

    public TaskForceDTO(Guid id, Guid subjectId, Guid projectId, string description, DateOnly initDate, DateOnly endDate)
    {
        Id = id;
        SubjectId = subjectId;
        ProjectId = projectId;
        Description = description;
        InitDate = initDate;
        EndDate = endDate;
    }
}
