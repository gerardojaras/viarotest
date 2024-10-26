using Shared;

namespace Client.Interfaces;

public interface IAlumnosService
{
    Task<ServiceResponse<List<Alumno>>> GetAllAlumnosAsync();
    Task<Alumno> GetAlumnoByIdAsync(int id);
    Task<Alumno> AddAlumnoAsync(Alumno alumno);
    Task<Alumno> UpdateAlumnoAsync(Alumno alumno);
    Task<Alumno> DeleteAlumnoAsync(Alumno alumno);
}