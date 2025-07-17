using Application.DTO;
using Application.IServices;
using Domain.Messages;
using MassTransit;

namespace InterfaceAdapters.Consumer;

public class SubjectCreatedConsumer : IConsumer<SubjectCreatedMessage>
{
    private readonly ISubjectService _subjectService;

    public SubjectCreatedConsumer(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    public async Task Consume(ConsumeContext<SubjectCreatedMessage> context)
    {
        var msg = context.Message;
        CreateSubjectDTO createSubjectDTO = new CreateSubjectDTO(msg.Id);
        await _subjectService.AddConsumed(createSubjectDTO);
    }
}
