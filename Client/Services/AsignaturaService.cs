using System.Net.Http.Json;
using Client.Interfaces;
using Shared;

namespace Client.Services;

public class AsignaturaService(HttpClient httpClient): IAsignaturaService
{
    public async Task<ServiceResponse<Alumno>> AssignAlumno(int alumnoId, int gradoId)
    {
        var response = new ServiceResponse<Alumno>();
        try
        {
            var request = await httpClient
                .GetAsync($"http://localhost:5267/api/GradoAlumno/Asignar?AlumnoId={alumnoId}&GradoId={gradoId}");
           
            if (request.IsSuccessStatusCode)
            {
                var alumnos = request.Content.ReadFromJsonAsync<ServiceResponse<Alumno>>().Result;
                if (alumnos.Data != null)
                {
                    response.Success = true;
                    response.Data = alumnos.Data;
                    response.Message = alumnos.Message;
                }
                else
                {
                    response.Success = false;
                    response.Data = new Alumno();
                    response.Message = alumnos.Message;
                }
            }

           
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Data = new Alumno();
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<ServiceResponse<Alumno>> UnAssignAlumno(int alumnoId, int gradoId)
    {
        var response = new ServiceResponse<Alumno>();
        try
        {
            var request = await httpClient
                .GetAsync($"http://localhost:5267/api/GradoAlumno/Remover?AlumnoId={alumnoId}&GradoId={gradoId}");

            if (request.IsSuccessStatusCode)
            {
                var alumnos = request.Content.ReadFromJsonAsync<ServiceResponse<Alumno>>().Result;
                if (alumnos.Data != null)
                {
                    response.Success = true;
                    response.Data = alumnos.Data;
                    response.Message = alumnos.Message;
                }
                else
                {
                    response.Success = false;
                    response.Data = new Alumno();
                    response.Message = alumnos.Message;
                }
            }
        }
        catch (Exception e)
        {
           response.Success = false;
           response.Message = e.Message;
           response.Data = new Alumno();
           response.StatusCode = 500;
        }

        return response;
    }
}