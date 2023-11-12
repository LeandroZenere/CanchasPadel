using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    [Table("Estado")]
    public class Estado
    {
        public int Id { get; set; }

        public string Nombre { get; set; }
    }
}
