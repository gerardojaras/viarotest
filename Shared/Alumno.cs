namespace Shared;

public class Alumno:ColegioEntity
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public int Genero { get; set; } 
    public DateTime FechaDeNacimiento { get; set; }

    public Grado? Grado { get; set; } = null;
}