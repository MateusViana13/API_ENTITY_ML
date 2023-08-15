using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_ENTITY_FRAMEWORK.Models.Banco_Destinos;

public class PontoTuristico
{
    [Key]
    public int Id { get; set; }
    public Guid ExternalKey { get; set; }
    [Column(TypeName = "varchar(150)")]
    public string Nome { get; set; } = string.Empty;
    public int DestinoId { get; set; }
    [JsonIgnore]
    public virtual Destino Destino { get; set; } = new();
    [JsonIgnore]
    public virtual List<PontoTuristicoReview> PontoTuristicoReviews { get; set; } = new();
}

