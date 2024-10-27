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
                if (grados.Data != null)
                {
                    response.Success = true;
                    response.Data = grados.Data;
                }
                else
                {
                    response.Success = false;
                    response.Data = new List<Grado>();
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

    public async Task<ServiceResponse<Grado>> AddGradoAsync(Grado grado)
    {
        try
        {
            var request = await httpClient.PostAsJsonAsync("http://localhost:5267/api/Grado", grado);
            var response = request.Content.ReadFromJsonAsync<ServiceResponse<Grado>>().Result;
            var message = response.Message;
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Grado> UpdateGradoAsync(Grado grado)
    {
        try
        {
            var request = await httpClient.PutAsJsonAsync($"http://localhost:5267/api/Grado", grado);
            var response = request.Content.ReadFromJsonAsync<ServiceResponse<Grado>>().Result;
            return response?.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Grado> DeleteGradoAsync(int id)
    {
        try
        {
            var request = await httpClient.DeleteAsync($"http://localhost:5267/api/Grado?id={id}");
            var response = request.Content.ReadFromJsonAsync<ServiceResponse<Grado>>().Result;
            return response?.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}