using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradoAlumnoController(IGradoAlumnoService gradoAlumnoService):ControllerBase
{
    [HttpGet, Route("Assignar")]
    public async Task<ServiceResponse<Alumno>> PostGrado(int AlumnoId, int GradoId)
    {
        try
        {
            var newGrado = await gradoAlumnoService.AssignAlumnoToGrado(AlumnoId, GradoId);
            return newGrado;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}