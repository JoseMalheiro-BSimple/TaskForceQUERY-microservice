using AutoMapper;
using Domain.Factory;
using Domain.Interfaces;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers;

public class TaskForceCollaboratorDataModelConverter : ITypeConverter<TaskForceCollaboratorDataModel, ITaskForceCollaborator>
{
    private readonly ITaskForceCollaboratorFactory _factory;

    public TaskForceCollaboratorDataModelConverter(ITaskForceCollaboratorFactory factory)
    {
        _factory = factory;
    }

    public ITaskForceCollaborator Convert(TaskForceCollaboratorDataModel source, ITaskForceCollaborator destination, ResolutionContext context)
    {
        return _factory.Create(source);
    }
}
