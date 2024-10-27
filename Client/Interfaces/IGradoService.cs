using Shared;

namespace Client.Interfaces;

public interface IGradoService
{
    Task<ServiceResponse<List<Grado>>> GetAllGradosAsync();
    Task<Grado> GetGradoAsync(int id);
    Task<Grado> AddAlumnoAsync(Grado Grado);
    Task<Grado> UpdateAlumnoAsync(Grado Grado);
    Task<Grado> DeleteAlumnoAsync(Grado Grado);
}