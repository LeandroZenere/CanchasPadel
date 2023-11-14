using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Persona")]
    public class Persona
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Dni { get; set; }

        [Display(Name = "Foto")]
        public string? FotoDni { get; set; }

        public string Telefono { get; set; }
        public string NombreCompleto => $"{Nombre} {Apellido}";
    }

}
