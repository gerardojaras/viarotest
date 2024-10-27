using System.Net.Http.Json;
using Client.Interfaces;
using Shared;

namespace Client.Services;

public class ProfesorService(HttpClient httpClient): IProfesorService
{
    public async Task<ServiceResponse<List<Profesor>>> GetAllProfesorsAsync()
    {
        try
        {
            var request = await httpClient.GetAsync("http://localhost:5267/api/Profesor/Todos");
            var response = new ServiceResponse<List<Profesor>>();
            if (request.IsSuccessStatusCode)
            {
                var Profesors = request.Content.ReadFromJsonAsync<ServiceResponse<List<Profesor>>>().Result;
                if (Profesors != null)
                {
                    response.Success = true;
                    response = Profesors;
                }
            }

            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Profesor> GetProfesorByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Profesor> AddProfesorAsync(Profesor Profesor)
    {
        throw new NotImplementedException();
    }

    public async Task<Profesor> UpdateProfesorAsync(Profesor Profesor)
    {
        throw new NotImplementedException();
    }

    public async Task<Profesor> DeleteProfesorAsync(Profesor Profesor)
    {
        throw new NotImplementedException();
    }
}