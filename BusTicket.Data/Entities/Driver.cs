using BusTicket.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Entities
{
    [Table("Conductor")]
    public sealed class Driver : AuditEntity<int>
    {
        [Key]
        [Column("ConductorID")]
        public override int Id { get; set; }
        public int Telefono { get; set; }
        public string NumeroLicencia { get; set; }
        public DateTime FechaContratacion { get; set; }

    }
}
