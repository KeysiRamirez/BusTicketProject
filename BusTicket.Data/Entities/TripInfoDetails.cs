using BusTicket.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusTicket.Data.Entities
{
    [Table("ReservaDetalle")]
    public sealed class TripInfoDetails : AuditEntity<int>
    {
        [Key]
        [Column("IdReservaDetalle")]
        public override int Id { get; set; }
        public int IdReserva { get; set; }
        public int IdAsiento { get; set; }

    }
}
