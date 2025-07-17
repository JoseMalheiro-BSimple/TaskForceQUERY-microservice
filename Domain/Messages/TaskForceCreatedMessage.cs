using Domain.ValueObjects;

namespace Domain.Messages;

public record TaskForceCreatedMessage(Guid Id, Guid SubjectId, Guid ProjectId, Description Description, PeriodDate PeriodDate);
