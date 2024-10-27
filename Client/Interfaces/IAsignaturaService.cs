using Shared;

namespace Client.Interfaces;

public interface IAsignaturaService
{
    Task<ServiceResponse<bool>> AssignAlumno(int alumnoId, int gradoId);
    Task<ServiceResponse<bool>> UnAssignAlumno(int alumnoId, int gradoId);
}