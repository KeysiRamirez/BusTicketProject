using BusTicket.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Domain.Entities
{
    [Table ("Bus")]
    public sealed class Bus : AuditEntity<int>
    {
        [Key]
        [Column ("IdBus")]
        public override int Id { get; set; }
        public string NumeroPlaca { get; set; }
        public string Nombre { get; set; }
        public int CapacidadPiso1 { get; set; }
        public int CapacidadPiso2 { get; set; }
        public int CapacidadTotal { get; set; }
        public int Disponible { get; set; }

    }
}
