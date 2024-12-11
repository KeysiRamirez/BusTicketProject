using BusTicket.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusTicket.Data.Entities
{

    [Table("Asiento")]
    public sealed class Seat : AuditEntity<int>
    {
        [Key]
        [Column("IdAsiento")]
        public override int Id { get; set; }
        public int IdBus { get; set; }
        public int NumeroPiso { get; set; }
        public int NumeroAsiento { get; set; }

    }
}
