using System.ComponentModel.DataAnnotations;

namespace API_ENTITY_FRAMEWORK.Models.Banco_Destinos;

public class PontoTuristico
{
    [Key]
    public int Id { get; set; }
    public Guid ExternalKey { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int DestinoId { get; set; }
    public virtual Destino Destino { get; set; } = new();
    public virtual List<PontoTuristicoReview> PontoTuristicoReviews { get; set; } = new();
}

