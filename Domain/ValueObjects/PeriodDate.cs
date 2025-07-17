namespace Domain.ValueObjects;
public record PeriodDate
{
    public DateOnly InitDate { get; private set; }
    public DateOnly EndDate { get; private set; }

    public PeriodDate() { }

    public PeriodDate(DateOnly initDate, DateOnly endDate)
    {
        if (initDate > endDate)
            throw new ArgumentException("Invalid Arguments");
        InitDate = initDate;
        EndDate = endDate;
    }

    public bool Contains(PeriodDate periodDate)
    {
        return InitDate <= periodDate.InitDate
        && EndDate >= periodDate.EndDate;
    }

}

