using Api.Interfaces;
using Shared;

namespace Api.Services;

public class ProfesorService: IProfesorService
{
    public async Task<ServiceResponse<Profesor>> GetProfesor(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<List<Profesor>>> GetProfesores()
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<Profesor>> AddProfesor(Profesor profesor)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<Profesor>> UpdateProfesor(Profesor profesor)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<Profesor>> DeleteProfesor(int id)
    {
        throw new NotImplementedException();
    }
}