using System.ComponentModel.DataAnnotations;

namespace API_ENTITY_FRAMEWORK.Models.Banco_Destinos;

public class Destino
{
    [Key]
    public int Id { get; set; }
    public Guid ExternalKey { get; set; }
    public string LocalDestino { get; set; } = string.Empty;
    public string Pais { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public virtual List<PontoTuristico> PontosTuristicos { get; set; } = new();
}

