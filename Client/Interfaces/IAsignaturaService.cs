using Shared;

namespace Client.Interfaces;

public interface IAsignaturaService
{
    Task<ServiceResponse<Alumno>> AssignAlumno(int alumnoId, int gradoId);
    Task<ServiceResponse<Alumno>> UnAssignAlumno(int alumnoId, int gradoId);
}