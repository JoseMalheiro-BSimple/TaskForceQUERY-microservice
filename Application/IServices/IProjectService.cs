using Application.DTO;

namespace Application.IServices;

public interface IProjectService
{
    Task AddConsumed(CreateProjectDTO createDTO);
}
