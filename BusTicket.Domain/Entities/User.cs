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
    [Table ("Usuario")]
    public sealed class User : AuditEntity<int>
    {
        [Key]
        [Column("IdUsuario")]
        public override int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }    
        public string TipoUsuario { get; set; }
    }
}
