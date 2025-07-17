using Application.DTO;
using Application.IServices;
using Domain.Messages;
using MassTransit;

namespace InterfaceAdapters.Consumer;

public class ProjectCreatedConsumer : IConsumer<ProjectCreatedMessage>
{
    private readonly IProjectService _projectService;

    public ProjectCreatedConsumer(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task Consume(ConsumeContext<ProjectCreatedMessage> context)
    {
        var msg = context.Message;
        CreateProjectDTO createProjectDTO = new CreateProjectDTO(msg.Id);
        await _projectService.AddConsumed(createProjectDTO);
    }
}
