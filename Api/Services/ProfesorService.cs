using Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Api.Services;

public class ProfesorService(ColegioContext context): IProfesorService
{
    public async Task<ServiceResponse<Profesor>> GetProfesor(int id)
    {
        try
        {
            var response = new ServiceResponse<Profesor>();
            var profesor = await context.Profesores.FirstOrDefaultAsync(p => p.Id == id);
            if (profesor != null)
            {
                response.Data = profesor;
                response.Success = true;
                response.Message = "Profesor encontrado";
                response.StatusCode = 200;
            }
            else
            {
                response.Success = false;
                response.Message = "Profesor No encontrado";
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

    public async Task<ServiceResponse<List<Profesor>>> GetProfesores()
    {
        try
        {
            var response = new ServiceResponse<List<Profesor>>();
            var profesores = await context.Profesores.ToListAsync();
            if (profesores.Count != 0)
            {
                response.Data = profesores;
                response.Success = true;
                response.Message = "Profesores encontrados";
                response.StatusCode = 200;
            }
            else
            {
                response.Success = false;
                response.StatusCode = 204;
                response.Message = "Profesores no encontrados";
            }
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<Profesor>> AddProfesor(Profesor profesor)
    {
        try
        {
            var response = new ServiceResponse<Profesor>();
            var newProfesor = await context.Profesores.AddAsync(profesor);
            await context.SaveChangesAsync();
            response.Data = newProfesor.Entity;
            response.Success = true;
            response.StatusCode = 200;
            response.Message = "Profesor creado correctamente";
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<Profesor>> UpdateProfesor(Profesor profesor)
    {
        var response = new ServiceResponse<Profesor>();
        var existingProfesor = await context.Profesores.FirstOrDefaultAsync(p => p.Id == profesor.Id);
        if (existingProfesor != null)
        {
            existingProfesor.Nombre = profesor.Nombre;
            existingProfesor.Apellido = profesor.Apellido;
            existingProfesor.Genero = profesor.Genero;
            await context.SaveChangesAsync();
            response.Data = existingProfesor;
            response.StatusCode = 200;
            response.Message = "Profesor actualizado correctamente";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.StatusCode = 204;
            response.Message = "Profesor no encontrado";
        }
        return response;
    }

    public async Task<ServiceResponse<Profesor>> DeleteProfesor(int id)
    {
        try
        {
            var response = new ServiceResponse<Profesor>();
            var deletedProfesor = await context.Profesores.FirstOrDefaultAsync(p => p.Id == id);
            if (deletedProfesor != null)
            {
                context.Profesores.Remove(deletedProfesor);
                await context.SaveChangesAsync();
                response.Data = deletedProfesor;
                response.StatusCode = 201;
                response.Message = "Profesor eliminado correctamente";
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.StatusCode = 204;
                response.Message = "Profesor no encontrado";
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