using AutoMapper;
using Domain.Interfaces;
using Infrastructure.DataModel;
using Infrastructure.Resolvers;

namespace Infrastructure;

public class DataModelMappingProfile : Profile
{
    public DataModelMappingProfile()
    {
        CreateMap<ICollaborator, CollaboratorDataModel>();
        CreateMap<CollaboratorDataModel, ICollaborator>()
            .ConvertUsing<CollaboratorDataModelConverter>();
        
        CreateMap<IProject, ProjectDataModel>();
        CreateMap<ProjectDataModel, IProject>()
            .ConvertUsing<ProjectDataModelConverter>();
        
        CreateMap<ISubject, SubjectDataModel>();
        CreateMap<SubjectDataModel, ISubject>()
            .ConvertUsing<SubjectDataModelConverter>();

        CreateMap<ITaskForce, TaskForceDataModel>();
        CreateMap<TaskForceDataModel, ITaskForce>()
            .ConvertUsing<TaskForceDataModelConverter>();

        CreateMap<ITaskForceCollaborator, TaskForceCollaboratorDataModel>();
        CreateMap<TaskForceCollaboratorDataModel, ITaskForceCollaborator>()
            .ConvertUsing<TaskForceCollaboratorDataModelConverter>();
    }
}
