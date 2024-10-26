using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradoAlumnoController(IGradoAlumnoService gradoAlumnoService):ControllerBase
{
    [HttpGet, Route("Asignar")]
    public async Task<ServiceResponse<Alumno>> PostGrado(int alumnoId, int gradoId)
    {
        try
        {
            var newGrado = await gradoAlumnoService.AssignAlumnoToGrado(alumnoId, gradoId);
            return newGrado;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet, Route("Remover")]
    public async Task<ServiceResponse<Alumno>> DeleteGrado(int alumnoId, int gradoId)
    {
        try
        {
            var removeGrado = await gradoAlumnoService.UnAssignAlumnoToGrado(alumnoId, gradoId);
            return removeGrado;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}