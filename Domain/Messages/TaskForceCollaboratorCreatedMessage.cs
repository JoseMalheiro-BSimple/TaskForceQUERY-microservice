namespace Domain.Messages;

public record TaskForceCollaboratorCreatedMessage(Guid Id, Guid TaskForceId, Guid CollaboratorId);
