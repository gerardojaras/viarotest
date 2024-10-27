namespace Shared;

public class AlumnoDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public int Genero { get; set; } 
    public DateTime? FechaDeNacimiento { get; set; }

    public ICollection<Grado> Grados { get; set; } = [];
}