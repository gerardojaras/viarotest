using Shared;

namespace Client.Interfaces;

public interface IProfesorService
{
    Task<ServiceResponse<List<Profesor>>> GetAllProfesorsAsync();
    Task<Profesor> GetProfesorByIdAsync(int id);
    Task<Profesor> AddProfesorAsync(Profesor Profesor);
    Task<Profesor> UpdateProfesorAsync(Profesor Profesor);
    Task<Profesor> DeleteProfesorAsync(int id);
}