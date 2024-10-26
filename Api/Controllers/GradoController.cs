using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradoController(IGradoService gradoService) : ControllerBase
{
    [HttpGet, Route("Todos")]
    public async Task<ServiceResponse<List<Grado>>> GetGrados()
    {
        try
        {
            var grados = await gradoService.GetGrados();
            return grados;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    public async Task<ServiceResponse<Grado>> GetGrados(int id)
    {
        try
        {
            var grado = await gradoService.GetGrado(id);
            return grado;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]
    public async Task<ServiceResponse<Grado>> PostGrado(Grado grado)
    {
        try
        {
            var newGrado = await gradoService.AddGrado(grado);
            return newGrado;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut]
    public async Task<ServiceResponse<Grado>> PutGrado(Grado grado)
    {
        try
        {
            var updatedGrado = await gradoService.UpdateGrado(grado);
            return updatedGrado;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete]
    public async Task<ServiceResponse<Grado>> DeleteGrado(int id)
    {
        try
        {
            var deleteGrado = await gradoService.DeleteGrado(id);
            return deleteGrado;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}