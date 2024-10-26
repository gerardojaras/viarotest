using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfesorController(IProfesorService profesorService) : ControllerBase
{
    [HttpGet, Route("Todos")]
    public async Task<ServiceResponse<List<Profesor>>> GetProfesores()
    {
        try
        {
            var profesores = await profesorService.GetProfesores();
            return profesores;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    public async Task<ServiceResponse<Profesor>> GetProfesor(int id)
    {
        try
        {
            var profesor = await profesorService.GetProfesor(id);
            return profesor;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]
    public async Task<ServiceResponse<Profesor>> PostProfesor(Profesor profesor)
    {
        try
        {
            var newProfesor = await profesorService.AddProfesor(profesor);
            return newProfesor;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut]
    public async Task<ServiceResponse<Profesor>> PutProfesor(Profesor profesor)
    {
        try
        {
            var updateProfesor = await profesorService.UpdateProfesor(profesor);
            return updateProfesor;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete]
    public async Task<ServiceResponse<Profesor>> DeleteProfesor(int id)
    {
        try
        {
            var deleteProfesor = await profesorService.DeleteProfesor(id);
            return deleteProfesor;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}