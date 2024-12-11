using BusTicket.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusTicket.Data.Entities
{
    [Table("Usuario")]
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
