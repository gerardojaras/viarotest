using Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Api.Services;

public class GradoService(ColegioContext context) : IGradoService
{

    public async Task<ServiceResponse<Grado>> GetGrado(int id)
    {
        try
        {
            var response = new ServiceResponse<Grado>();
            var grado = await context.Grados.FirstOrDefaultAsync(g => g.Id == id);
            if (grado != null)
            {
                response.Data = grado;
                response.Success = true;
                response.Message = "Grado retornado con exito!";
                response.StatusCode = 200;
            }
            else
            {
                response.Success = false;
                response.Message = "Grado No encontrado!";
                response.StatusCode = 204;
            }
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<List<Grado>>> GetGrados()
    {
        try
        {
            var response = new ServiceResponse<List<Grado>>();
            var grados = await context.Grados.ToListAsync();
            if (grados.Count != 0)
            {
                response.Data = grados;
                response.Success = true;
                response.StatusCode = 200;
                response.Message = "Grados retornados con exito";
            }
            else
            {
                response.Success = false;
                response.Message = "Grados no encontrados";
                response.StatusCode = 204;
            }
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<Grado>> AddGrado(Grado grado)
    {
        try
        {
            var response = new ServiceResponse<Grado>();
            var newGrado = await context.Grados.AddAsync(grado);
            await context.SaveChangesAsync();
            response.Data = newGrado.Entity;
            response.Success = true;
            return response;
            
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<Grado>> UpdateGrado(Grado grado)
    {
        try
        {
            var response = new ServiceResponse<Grado>();
            var existingGrado = context.Grados.FirstOrDefault(x => x.Id == grado.Id);
            if (existingGrado != null)
            {
                existingGrado.Nombre = grado.Nombre;
                existingGrado.Seccion = grado.Seccion;
                existingGrado.ProfesorId = grado.ProfesorId;
                await context.SaveChangesAsync();
                response.Data = existingGrado;
                response.Success = true;
                response.Message = "Grado actualizado éxito";
                response.StatusCode = 201;
            }
            else
            {
                response.Success = false;
                response.Message = "Grado no fue actualizado";
                response.StatusCode = 204;
            }
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<Grado>> DeleteGrado(int id)
    {
        try
        {
            var response = new ServiceResponse<Grado>();
            var exisitingGrado = context.Grados.FirstOrDefault(x => x.Id == id);
            if (exisitingGrado != null)
            {
                context.Grados.Remove(exisitingGrado);
                await context.SaveChangesAsync();
                response.Data = exisitingGrado;
                response.Success = true;
                response.StatusCode = 201;
                response.Message = "Grado eliminado";
            }
            else
            {
                response.Success = false;
                response.StatusCode = 204;
                response.Message = "Grado no fue eliminado";
            }
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}