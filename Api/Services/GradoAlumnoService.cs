using Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Api.Services;

public class GradoAlumnoService(ColegioContext context): IGradoAlumnoService
{
    public async Task<ServiceResponse<Alumno>> AssignAlumnoToGrado(int alumnoId, int gradoId)
    {
        try
        {
            var response = new ServiceResponse<Alumno>();
            var alumno = await context.Alumnos.FirstOrDefaultAsync(a => a.Id == alumnoId);
            if (alumno == null)
            {
                response.Message = "Alumno inexistente";
                response.StatusCode = 204;
                response.Success = false;
                return response;
            }
            var grado = await context.Grados.FirstOrDefaultAsync(a => a.Id == gradoId);
            if (grado == null)
            {
                response.Message = "Grado inexistente";
                response.StatusCode = 204;
                response.Success = false;
                return response;
            }
            alumno.Grados.Add(grado);
            await context.SaveChangesAsync();
            response.Data = alumno;
            response.Success = true;
            response.Message = "Alumno assignado a grado con exito!";
            response.StatusCode = 200;
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<Alumno>> UnAssignAlumnoToGrado(int alumnoId, int gradoId)
    {
        try
        {
            var response = new ServiceResponse<Alumno>();
            var alumno = await context.Alumnos
                .Include(x => x.Grados)
                .FirstOrDefaultAsync(a => a.Id == alumnoId);
            if (alumno == null)
            {
                response.Message = "Alumno inexistente";
                response.StatusCode = 204;
                response.Success = false;
                return response;
            }
            var grado = await context.Grados.FirstOrDefaultAsync(a => a.Id == gradoId);
            if (grado == null)
            {
                response.Message = "Grado inexistente";
                response.StatusCode = 204;
                response.Success = false;
                return response;
            }
            alumno.Grados.Remove(grado);
            var result = await context.SaveChangesAsync();
            response.Data = alumno;
            response.Success = true;
            response.Message = "Alumno removido de grado con exito!";
            response.StatusCode = 200;
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}