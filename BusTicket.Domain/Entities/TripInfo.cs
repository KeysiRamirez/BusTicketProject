using BusTicket.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BusTicket.Domain.Entities
{
    [Table ("Reserva")]
    public sealed class TripInfo : AuditEntity<int>
    {
        [Key]
        [Column ("IdReserva")]
        public override int Id { get; set; }
        public int IdViaje { get; set; } 
        public int IdPasajero { get; set; }
        public int AsientosReservados {  get; set; }
        public decimal MontoTotal {  get; set; }

    }
}
