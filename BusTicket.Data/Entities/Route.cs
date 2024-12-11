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
    [Table("Ruta")]
    public sealed class Route : AuditEntity<int>
    {
        [Key]
        [Column("IdRuta")]
        public override int Id { get; set; }
        public string PickUpLocation { get; set; }
        public string Destination { get; set; }

    }
}
