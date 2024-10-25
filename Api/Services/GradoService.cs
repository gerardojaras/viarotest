using Api.Interfaces;
using Shared;

namespace Api.Services;

public class GradoService: IGradoService
{
    public async Task<ServiceResponse<Grado>> GetGrado(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<List<Grado>>> GetGrados()
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<Grado>> AddGrado(Grado grado)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<Grado>> UpdateGrado(Grado grado)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<Grado>> DeleteGrado(int id)
    {
        throw new NotImplementedException();
    }
}