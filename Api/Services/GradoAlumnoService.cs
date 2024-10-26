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
            var grado = await context.Grados.FirstOrDefaultAsync(a => a.Id == gradoId);
            alumno.Grados.Add(grado);
            grado.Alumnos.Add(alumno);
            await context.SaveChangesAsync();
            response.Data = alumno;
            response.Success = true;
            response.Message = "Alumno Assignado con exito!";
            response.StatusCode = 200;
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<List<Alumno>>> UnAssignAlumnoToGrado(int alumnoId, int gradoId)
    {
        throw new NotImplementedException();
    }
}