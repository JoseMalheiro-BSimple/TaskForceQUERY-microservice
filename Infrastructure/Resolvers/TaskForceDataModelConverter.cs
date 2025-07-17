using AutoMapper;
using Domain.Factory;
using Domain.Interfaces;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers;

public class TaskForceDataModelConverter : ITypeConverter<TaskForceDataModel, ITaskForce>
{
    private readonly ITaskForceFactory _factory;

    public TaskForceDataModelConverter(ITaskForceFactory factory)
    {
        _factory = factory;
    }

    public ITaskForce Convert(TaskForceDataModel source, ITaskForce destination, ResolutionContext context)
    {
        return _factory.Create(source);
    }
}
