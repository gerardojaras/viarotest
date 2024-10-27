using Shared;

namespace Client.Interfaces;

public interface IGradoService
{
    Task<ServiceResponse<List<Grado>>> GetAllGradosAsync();
    Task<Grado> GetGradoAsync(int id);
    Task<Grado> AddGradoAsync(Grado grado);
    Task<Grado> UpdateGradoAsync(Grado Grado);
    Task<Grado> DeleteGradoAsync(int id);
}