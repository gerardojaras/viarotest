using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradoAlumnoController(IGradoAlumnoService gradoAlumnoService):ControllerBase
{
    [HttpPost]
    public async Task<ServiceResponse<Alumno>> PostGrado(int idAlumno, int idGrado)
    {
        try
        {
            var newGrado = await gradoAlumnoService.AssignAlumnoToGrado(idAlumno, idGrado);
            return newGrado;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}