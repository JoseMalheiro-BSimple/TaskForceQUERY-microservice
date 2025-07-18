using Application.DTO;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace InterfaceAdapters.Controller
{
    [Route("api/taskForces")]
    [ApiController]
    public class TaskForceController : ControllerBase
    {
        private readonly ITaskForceService _taskForceService;
        private readonly ITaskForceCollaboratorService _taskForceCollaboratorService;

        public TaskForceController(ITaskForceService taskForceService, ITaskForceCollaboratorService taskForceCollaboratorService)
        {
            _taskForceService = taskForceService;
            _taskForceCollaboratorService = taskForceCollaboratorService;
        }

        // 1. GetAllTaskForces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskForceDTO>>> GetAll()
        {
            var result = await _taskForceService.GetAll();

            return result.ToActionResult();
        }

        // 2. GetTaskForcesByProjectId
        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<IEnumerable<TaskForceDTO>>> GetByProjectId(Guid projectId)
        {
            var result = await _taskForceService.GetAllByProject(projectId);
            return result.ToActionResult();
        }

        // 3. GetTaskForcesByPeriod
        [HttpGet("period")]
        public async Task<ActionResult<IEnumerable<TaskForceDTO>>> GetByPeriod([FromQuery] DateOnly initDate, [FromQuery] DateOnly endDate)
        {
            var result = await _taskForceService.GetAllByPeriod(new PeriodDTO(initDate, endDate));
            return result.ToActionResult();
        }

        // 4. GetTaskForcesByDescription
        [HttpGet("description")]
        public async Task<ActionResult<IEnumerable<TaskForceDTO>>> GetByDescription([FromQuery] string value)
        {
            var result = await _taskForceService.GetAllByDescription(value);
            return result.ToActionResult();
        }

        // 5. GetTaskForcesBySubjectId
        [HttpGet("subject/{subjectId}")]
        public async Task<ActionResult<IEnumerable<TaskForceDTO>>> GetBySubjectId(Guid subjectId)
        {
            var result = await _taskForceService.GetAllBySubject(subjectId);
            return result.ToActionResult();
        }

        // 6. GetTaskForcesCollaboratorByCollaboratorId
        [HttpGet("collaborator/{collaboratorId}")]
        public async Task<ActionResult<IEnumerable<TaskForceCollaboratorDTO>>> GetCollaboratorsByCollaboratorId(Guid collaboratorId)
        {
            var result = await _taskForceCollaboratorService.GetAllByCollaborator(collaboratorId);
            return result.ToActionResult();
        }

        // 7. GetTaskForcesCollaboratorByTaskForceId
        [HttpGet("{taskForceId}/collaborators")]
        public async Task<ActionResult<IEnumerable<TaskForceCollaboratorDTO>>> GetCollaboratorsByTaskForceId(Guid taskForceId)
        {
            var result = await _taskForceCollaboratorService.GetAllByTaskForceId(taskForceId);
            return result.ToActionResult();
        }
    }
}
