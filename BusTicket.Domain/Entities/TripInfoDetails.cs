
using BusTicket.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusTicket.Domain.Entities
{
    [Table ("ReservaDetalle")]
    public sealed class TripInfoDetails : AuditEntity<int>
    {
        [Column ("IdReservaDetalle")]
        public override int Id { get; set; }
        public int IdReserva {  get; set; }
        public int IdAsiento {  get; set; }

    }
}
