using System.Net.Http.Json;
using Client.Interfaces;
using Shared;

namespace Client.Services;

public class AlumnoService(HttpClient httpClient): IAlumnosService
{
    public async Task<ServiceResponse<List<Alumno>>> GetAllAlumnosAsync()
    {
        try
        {
            var request = await httpClient.GetAsync("http://localhost:5267/api/Alumno/Todos");
            var response = new ServiceResponse<List<Alumno>>();
            if (request.IsSuccessStatusCode)
            {
                var alumnos = request.Content.ReadFromJsonAsync<ServiceResponse<List<Alumno>>>().Result;
                if (alumnos.Data != null)
                {
                    response.Success = true;
                    response.Data = alumnos.Data;
                }
                else
                {
                    response.Success = false;
                    response.Data = new List<Alumno>();
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

    public async Task<Alumno> GetAlumnoByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Alumno> AddAlumnoAsync(Alumno alumno)
    {
        try
        {
            var request = await httpClient.PostAsJsonAsync("http://localhost:5267/api/Alumno", alumno);
            var response = request.Content.ReadFromJsonAsync<ServiceResponse<Alumno>>().Result;
            return response.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Alumno?> UpdateAlumnoAsync(Alumno alumno)
    {
        try
        {
            var request = await httpClient.PutAsJsonAsync($"http://localhost:5267/api/Alumno", alumno);
            ServiceResponse<Alumno?>? response = request.Content.ReadFromJsonAsync<ServiceResponse<Alumno>>().Result;
            return response?.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Alumno?> DeleteAlumnoAsync(int id)
    {
        try
        {
            var request = await httpClient.DeleteAsync($"http://localhost:5267/api/Alumno?id={id}");
            var response = request.Content.ReadFromJsonAsync<ServiceResponse<Alumno>>().Result;
            return response?.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}