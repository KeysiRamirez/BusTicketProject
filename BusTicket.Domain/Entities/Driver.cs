using BusTicket.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusTicket.Domain.Entities
{
    [Table ("Conductor")]
    public sealed class Driver : AuditEntity<int>
    {
        [Key]
        [Column("ConductorID")]
        public override int Id {  get; set; }
        public int Telefono { get; set; }
        public string NumeroLicencia { get; set; }
        public DateTime FechaContratacio { get; set; }

    }
}
