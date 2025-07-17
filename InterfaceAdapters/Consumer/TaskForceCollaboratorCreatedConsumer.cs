using Application.DTO;
using Application.IServices;
using Domain.Messages;
using MassTransit;

namespace InterfaceAdapters.Consumer;

public class TaskForceCollaboratorCreatedConsumer : IConsumer<TaskForceCollaboratorCreatedMessage>
{
    private readonly ITaskForceCollaboratorService _taskForceCollaboratorRepository;

    public TaskForceCollaboratorCreatedConsumer(ITaskForceCollaboratorService taskForceCollaboratorRepository)
    {
        _taskForceCollaboratorRepository = taskForceCollaboratorRepository;
    }

    public async Task Consume(ConsumeContext<TaskForceCollaboratorCreatedMessage> context)
    {
        var msg = context.Message;
        TaskForceCollaboratorDTO taskForceCollaboratorDTO = new TaskForceCollaboratorDTO(msg.Id, msg.TaskForceId, msg.CollaboratorId);
        await _taskForceCollaboratorRepository.AddConsumed(taskForceCollaboratorDTO);
    }
}
