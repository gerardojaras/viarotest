using System.Net;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Api.Services;

public class AlumnoService(ColegioContext context) : IAlumnoService
{

    public async Task<ServiceResponse<Alumno>> GetAlumno(int id)
    {
        try
        {
            var response = new ServiceResponse<Alumno>();
            var alumno = await context.Alumnos.FirstOrDefaultAsync(a => a.Id == id);
            if (alumno != null)
            {
                response.StatusCode = 200;
                response.Success = true;
                response.Message = "Alumno se ha encontrado";
                response.Data = alumno;
            }
            else
            {
                response.StatusCode = 204;
                response.Success = false;
                response.Message = "Alumno no se ha encontrado";
            }

            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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
                existingAlumno.Nombre = newAlumno.Nombre;
                existingAlumno.Apellidos = newAlumno.Apellidos;
                existingAlumno.Grados = newAlumno.Grados;
                existingAlumno.Genero = newAlumno.Genero;
                existingAlumno.FechaDeNacimiento = newAlumno.FechaDeNacimiento;
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
        try
        {
            var existingAlumno = await context.Alumnos.FirstOrDefaultAsync(a => a.Id == id);
            var response = new ServiceResponse<Alumno>();
            if (existingAlumno != null)
            {
                context.Alumnos.Remove(existingAlumno);
                await context.SaveChangesAsync();
                response.Data = existingAlumno;
                response.Success = true;
                response.StatusCode = 201;
            }
            else
            {
                response.StatusCode = 204;
                response.Success = false;
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