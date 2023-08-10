using System.ComponentModel.DataAnnotations;

namespace API_ENTITY_FRAMEWORK.Models.Banco_Destinos;

public class PontoTuristicoReview
{
    [Key]
    public int Id { get; set; }
    public Guid ExternalKey { get; set; }
    public int PontoTuristicoId { get; set; }
    public virtual PontoTuristico PontoTuristico { get; set; } = new();
    public string NomeUsuario { get; set; } = string.Empty;
    public string Review { get; set; } = string.Empty;
    public int Nota { get; set; }
    public DateTime DataReview { get; set; } = DateTime.Now;
}
