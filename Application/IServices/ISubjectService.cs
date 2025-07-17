using Application.DTO;

namespace Application.IServices;

public interface ISubjectService
{
    Task AddConsumed(CreateSubjectDTO createDTO);
}
