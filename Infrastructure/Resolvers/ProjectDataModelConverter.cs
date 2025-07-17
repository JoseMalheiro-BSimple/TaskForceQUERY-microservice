using AutoMapper;
using Domain.Factory;
using Domain.Interfaces;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers;

public class ProjectDataModelConverter : ITypeConverter<ProjectDataModel, IProject>
{
    private readonly IProjectFactory _projectFactory;

    public ProjectDataModelConverter(IProjectFactory projectFactory)
    {
        _projectFactory = projectFactory;
    }

    public IProject Convert(ProjectDataModel source, IProject destination, ResolutionContext context)
    {
        return _projectFactory.Create(source);
    }
}
