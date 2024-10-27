using System.Net.Http.Json;
using Client.Interfaces;
using Shared;

namespace Client.Services;

public class AsignaturaService(HttpClient httpClient): IAsignaturaService
{
    public async Task<ServiceResponse<bool>> AssignAlumno(int alumnoId, int gradoId)
    {
        try
        {
            var request = await httpClient
                .GetAsync($"http://localhost:5267/api/api/GradoAlumno/Assignar?AlumnoId={alumnoId}&GradoId={gradoId}");
            var response = new ServiceResponse<bool>();
            if (request.IsSuccessStatusCode)
            {
                var alumnos = request.Content.ReadFromJsonAsync<ServiceResponse<List<Alumno>>>().Result;
                if (alumnos.Data != null)
                {
                    response.Success = true;
                    response.Data = true;
                }
                else
                {
                    response.Success = false;
                    response.Data = false;
                }
            }

            return response;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            throw;
        }
    }

    public async Task<ServiceResponse<bool>> UnAssignAlumno(int alumnoId, int gradoId)
    {
        var request = await httpClient
            .GetAsync($"http://localhost:5267/api/api/GradoAlumno/Remover?AlumnoId={alumnoId}&GradoId={gradoId}");
        var response = new ServiceResponse<bool>();
        if (request.IsSuccessStatusCode)
        {
            var alumnos = request.Content.ReadFromJsonAsync<ServiceResponse<List<Alumno>>>().Result;
            if (alumnos.Data != null)
            {
                response.Success = true;
                response.Data = true;
            }
            else
            {
                response.Success = false;
                response.Data = false;
            }
        }

        return response;
    }
}