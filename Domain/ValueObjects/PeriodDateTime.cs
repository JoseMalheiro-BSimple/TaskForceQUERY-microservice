namespace Domain.ValueObjects;

public record PeriodDateTime
{
    public DateTime InitDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public PeriodDateTime() {}

    public PeriodDateTime(DateTime initDate, DateTime finalDate)
    {
        if (initDate > finalDate)
            throw new ArgumentException("Invalid Arguments");

        InitDate = initDate;
        EndDate = finalDate;
    }

    public PeriodDateTime(PeriodDate periodDate) : this(
        periodDate.InitDate.ToDateTime(TimeOnly.MinValue),
        periodDate.EndDate.ToDateTime(TimeOnly.MinValue))
    { }

    public bool Contains(PeriodDateTime periodDateTime)
    {
        return InitDate <= periodDateTime.InitDate
            && EndDate >= periodDateTime.EndDate;
    }
}

