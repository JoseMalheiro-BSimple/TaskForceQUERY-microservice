using Domain.ValueObjects;

namespace Domain.Messages;

public record ProjectCreatedMessage(Guid Id, string Title, string Acronym, PeriodDate PeriodDate);
