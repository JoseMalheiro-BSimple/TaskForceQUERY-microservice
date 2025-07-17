namespace Application.DTO;

public record PeriodDTO
{
    public DateOnly InitDate { get; }
    public DateOnly EndDate { get; }

    public PeriodDTO(DateOnly initDate, DateOnly endDate)
    {
        InitDate = initDate;
        EndDate = endDate;
    }
}
