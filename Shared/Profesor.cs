namespace Shared;

public class Profesor: ColegioEntity
{
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public int Genero { get; set; }

    public ICollection<Grado> Grados { get; set; } = new List<Grado>();
    
}