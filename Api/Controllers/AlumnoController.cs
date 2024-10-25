using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnoController(IAlumnoService alumnoService) : ControllerBase
{
   
   [HttpGet]
   public async Task<ServiceResponse<List<Alumno>>> GetAlumnos()
   {
      var alumnos = await alumnoService.GetAlumnos();
      return alumnos;
   }

   [HttpPost]
   public async Task<ServiceResponse<Alumno>> PostAlumno(Alumno alumno)
   {
      var newAlumno = await alumnoService.AddAlumno(alumno);
      return newAlumno;
   }

   [HttpPut]
   public async Task<ServiceResponse<Alumno>> PutAlumno(Alumno alumno)
   {
      var updatedAlumno = await alumnoService.UpdateAlumno(alumno);
      return updatedAlumno;
   }
}