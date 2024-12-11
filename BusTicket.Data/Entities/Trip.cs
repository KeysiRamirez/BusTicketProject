using BusTicket.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusTicket.Data.Entities
{
    [Table("Viaje")]
    public sealed class Trip : AuditEntity<int>
    {
        [Key]
        [Column("IdViaje")]
        public override int Id { get; set; }
        public int IdBus { get; set; }
        public int IdRuta { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public DateTime HoraLlegada { get; set; }
        public decimal Precio { get; set; }
        public int TotalAsientos { get; set; }
        public int AsientosReservados { get; set; }
        public int AsientoDisponibles { get; set; }
        public bool Completo { get; set; }

    }
}
