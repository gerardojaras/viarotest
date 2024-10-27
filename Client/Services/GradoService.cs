using System.Net.Http.Json;
using Client.Interfaces;
using Shared;

namespace Client.Services;

public class GradoService(HttpClient httpClient): IGradoService
{
    public async Task<ServiceResponse<List<Grado>>> GetAllGradosAsync()
    {
        try
        {
            var request = await httpClient.GetAsync("http://localhost:5267/api/Grado/Todos");
            var response = new ServiceResponse<List<Grado>>();
            if (request.IsSuccessStatusCode)
            {
                var grados = request.Content.ReadFromJsonAsync<ServiceResponse<List<Grado>>>().Result;
                if (grados != null)
                {
                    response.Success = true;
                    response = grados;
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

    public async Task<Grado> GetGradoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Grado> AddAlumnoAsync(Grado Grado)
    {
        throw new NotImplementedException();
    }

    public async Task<Grado> UpdateAlumnoAsync(Grado Grado)
    {
        throw new NotImplementedException();
    }

    public async Task<Grado> DeleteAlumnoAsync(Grado Grado)
    {
        throw new NotImplementedException();
    }
}