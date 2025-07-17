namespace Domain.ValueObjects;

public record Description
{
    public string Value { get; private set; }

    public Description() 
    {
        Value = "Description";
    }

    public Description(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Description can't be empty!");

        if (value.Length < 10 && value.Length > 50)
            throw new ArgumentException("Description has min 10 and max 50 characters!");

        Value = value;
    }
}
