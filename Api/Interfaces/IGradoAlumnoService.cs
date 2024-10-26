using Shared;

namespace Api.Interfaces;

public interface IGradoAlumnoService
{
    public Task<ServiceResponse<Alumno>> AssignAlumnoToGrado(int alumnoId, int gradoId);
    public Task<ServiceResponse<Alumno>> UnAssignAlumnoToGrado(int alumnoId, int gradoId);
}