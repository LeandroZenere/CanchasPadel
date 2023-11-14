using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    [Table("Reserva")]
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }


        public int idCancha { get; set; }
        public int idPersona { get; set; }
        public int idEstado { get; set; }

        [ForeignKey("idCancha")]
        public Cancha Cancha { get; set; }
        [ForeignKey("idPersona")]
        public Persona Persona { get; set; }

        [ForeignKey("idEstado")]
        public Estado Estado { get; set; }
    }

}