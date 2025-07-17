using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Domain.ValueObjects;
using Domain.Visitor;

namespace Domain.Factory;

public class TaskForceFactory : ITaskForceFactory
{
    private readonly ITaskForceRepository _taskForceRepository;
    private readonly ISubjectRepository _subjectRepository;
    private readonly IProjectRepository _projectRepository;

    public TaskForceFactory(ITaskForceRepository taskForceRepository, ISubjectRepository subjectRepository, IProjectRepository projectRepository)
    {
        _taskForceRepository = taskForceRepository;
        _subjectRepository = subjectRepository;
        _projectRepository = projectRepository;
    }

    public async Task<ITaskForce> Create(Guid id, Guid subjectId, Guid projectId, string descriptionString, DateOnly taskForceInitDate, DateOnly taskForceEndDate)
    {
        ITaskForce? taskforce = await _taskForceRepository.GetByIdAsync(id);
        ISubject? subject = await _subjectRepository.GetByIdAsync(subjectId);
        IProject? project = await _projectRepository.GetByIdAsync(projectId);
        
        // Unicity Testing
        if (taskforce != null)
            throw new ArgumentException("Taskforce already exists!");

        // Subject has to exist
        if (subject == null)
            throw new ArgumentException("Subject doesn't exist!");

        // Project has to exist
        if (project == null)
            throw new ArgumentException("Project doesn't exist!");

        Description description = new Description(descriptionString);
        PeriodDate taskForcePeriod = new PeriodDate(taskForceInitDate, taskForceEndDate);

        return new TaskForce(id, subjectId, projectId, description, taskForcePeriod);
    }
    public ITaskForce Create(Guid id, Guid subjectId, Guid projectId, Description description, PeriodDate periodDate)
    {
        return new TaskForce(id, subjectId, projectId, description, periodDate);
    }

    public ITaskForce Create(ITaskForceVisitor visitor)
    {
        return new TaskForce(visitor.Id, visitor.SubjectId, visitor.ProjectId, visitor.Description, visitor.PeriodDate);
    }

}
