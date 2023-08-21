using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_ENTITY_FRAMEWORK.Models.Banco_Destinos;

public class Destino
{
    [Key]
    public int Id { get; set; }
    public Guid ExternalKey { get; set; }
    [Column(TypeName = "varchar(150)")]
    public string LocalDestino { get; set; } = string.Empty;
    [Column(TypeName = "varchar(100)")]
    public string Pais { get; set; } = string.Empty;
    [Column(TypeName = "varchar(100)")]
    public string Cidade { get; set; } = string.Empty;
    [JsonIgnore]
    public virtual List<PontoTuristico> PontosTuristicos { get; set; } = new();
    public Destino()
    {
        
    }

    public Destino(string localDestino, string pais, string cidade)
    {
        LocalDestino = localDestino;
        Pais = pais;
        Cidade = cidade;
    }
}

