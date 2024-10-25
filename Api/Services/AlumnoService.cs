using System.Net;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Api.Services;

public class AlumnoService(ColegioContext context) : IAlumnoService
{

    public async Task<ServiceResponse<Alumno>> GetAlumno(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<List<Alumno>>> GetAlumnos()
    {
        try
        {
            var response = new ServiceResponse<List<Alumno>>();
            var alumnos = await context.Alumnos.ToListAsync();
            if (alumnos.Count != 0)
            {
                response.Data = alumnos;
                response.Success = true;
                response.Message = "Alumnos listados con exito!";
                response.StatusCode = 200;
            }
            else
            {
                response.Success = false;
                response.StatusCode = 404;
            }
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<Alumno>> AddAlumno(Alumno alumno)
    {
        try
        {
            var response = new ServiceResponse<Alumno>();
            var newAlumno = await context.Alumnos.AddAsync(alumno);
            await context.SaveChangesAsync();
            response.Data = newAlumno.Entity;
            response.Success = true;
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<Alumno>> UpdateAlumno(Alumno newAlumno)
    {
        try
        {
            var response = new ServiceResponse<Alumno>();
            var existingAlumno = await context.Alumnos.FirstOrDefaultAsync(a => a.Id == newAlumno.Id);
            if (existingAlumno != null)
            {
                existingAlumno = newAlumno;
                await context.SaveChangesAsync();
                response.Data = existingAlumno;
                response.Success = true;
                response.StatusCode = 201;
            }
            else
            {
                response.StatusCode = 404;
            }
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ServiceResponse<Alumno>> DeleteAlumno(int id)
    {
        throw new NotImplementedException();
    }
}