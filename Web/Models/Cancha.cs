using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    [Table("Cancha")]
    public class Cancha
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}

