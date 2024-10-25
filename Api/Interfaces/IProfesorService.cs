using Shared;

namespace Api.Interfaces;

public interface IProfesorService
{
    public Task<ServiceResponse<Profesor>> GetProfesor(int id);
    public Task<ServiceResponse<List<Profesor>>> GetProfesores();
    public Task<ServiceResponse<Profesor>> AddProfesor(Profesor profesor);
    public Task<ServiceResponse<Profesor>> UpdateProfesor(Profesor profesor);
    public Task<ServiceResponse<Profesor>> DeleteProfesor(int id);
}