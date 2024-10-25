namespace Shared;

public class Grado: ColegioEntity
{
    public string Nombre { get; set; } = string.Empty;
    public int ProfesorId { get; set; }
    public string Seccion { get; set; } = String.Empty;
    
    public ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
    public Profesor Profesor { get; set; } = new Profesor();
}