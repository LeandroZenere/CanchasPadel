using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Cancha")]
    public class Cancha
    {
        public int Id { get; set; }
        [Display(Name = "Nombre de la Cancha")]
        public string Nombre { get; set; }
        public bool Disponible { get; set; }
        public decimal Precio { get; set; }
    }
}

