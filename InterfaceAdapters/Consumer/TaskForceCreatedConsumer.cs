using Application.DTO;
using Application.IServices;
using Domain.Messages;
using MassTransit;

namespace InterfaceAdapters.Consumer;

public class TaskForceCreatedConsumer : IConsumer<TaskForceCreatedMessage>
{
    private readonly ITaskForceService _taskForceService;

    public TaskForceCreatedConsumer(ITaskForceService taskForceService)
    {
        _taskForceService = taskForceService;
    }

    public async Task Consume(ConsumeContext<TaskForceCreatedMessage> context)
    {
        var msg = context.Message;
        ConsumeTaskForceDTO taskForceDTO = new ConsumeTaskForceDTO(msg.Id, msg.SubjectId, msg.ProjectId, msg.Description.Value, msg.PeriodDate.InitDate, msg.PeriodDate.EndDate);
        await _taskForceService.AddConsumed(taskForceDTO);
    }
}
