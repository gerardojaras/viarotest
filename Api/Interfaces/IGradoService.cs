using Shared;

namespace Api.Interfaces;

public interface IGradoService
{
    public Task<ServiceResponse<Grado>> GetGrado(int id); 
    public Task<ServiceResponse<List<Grado>>> GetGrados();
    public Task<ServiceResponse<Grado>> AddGrado(Grado grado);
    public Task<ServiceResponse<Grado>> UpdateGrado(Grado grado);
    public Task<ServiceResponse<Grado>> DeleteGrado(int id);
}