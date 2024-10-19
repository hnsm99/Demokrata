using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestJelmi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z]+$")]
        public string? PrimerNombre { get; set; }
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z]+$")]
        public string? SegundoNombre { get; set; }
        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z]+$")]
        public string? PrimerApellido { get; set; }
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z]+$")]
        public string? SegundoApellido { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Salario debe ser mayor a 0")]
        public decimal Sueldo { get; set; }
        [JsonIgnore]
        public DateTime FechaCreacion { get; set; }
        [JsonIgnore]
        public DateTime FechaModificacion { get; set; }
    }
}
