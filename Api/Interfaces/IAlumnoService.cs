using Shared;

namespace Api.Interfaces;

public interface IAlumnoService
{
    public Task<ServiceResponse<Alumno>> GetAlumno(int id);
    public Task<ServiceResponse<List<Alumno>>> GetAlumnos();
    public Task<ServiceResponse<Alumno>> AddAlumno(Alumno alumnoService);
    public Task<ServiceResponse<Alumno>> UpdateAlumno(Alumno newAlumno);
    public Task<ServiceResponse<Alumno>> DeleteAlumno(int id);
}