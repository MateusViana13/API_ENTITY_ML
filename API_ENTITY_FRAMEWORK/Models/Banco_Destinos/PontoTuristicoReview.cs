using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_ENTITY_FRAMEWORK.Models.Banco_Destinos;

public class PontoTuristicoReview
{
    [Key]
    public int Id { get; set; }
    public Guid ExternalKey { get; set; }
    public int PontoTuristicoId { get; set; }
    [JsonIgnore]
    public virtual PontoTuristico PontoTuristico { get; set; } = new();
    [Column(TypeName = "varchar(150)")]
    public string NomeUsuario { get; set; } = string.Empty;
    [Column(TypeName = "varchar(MAX)")]
    public string Review { get; set; } = string.Empty;
    public int Nota { get; set; }
    public DateTime DataReview { get; set; } = DateTime.Now;
}
