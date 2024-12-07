using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Domain.Base
{
    public abstract class AuditEntity<TType> : BaseEntity<TType>    
    { 
        public AuditEntity() 
        {
           FechaCreacion = DateTime.Now; 
           IsDeleted = false;
        }

        public int CreationUser {  get; set; }  
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioModificacion {  get; set; }   
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool Estatus { get; set; }

    }
}
