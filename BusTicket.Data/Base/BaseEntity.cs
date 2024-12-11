using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Base
{
    /// <summary>
    /// Entidad base que deben heradar todas las entidades
    /// </summary>
    /// <typeparam name="TType">tipo de dato del pk de la tabla</typeparam>
    public abstract class BaseEntity<TType>
    {
        public abstract TType Id { get; set; }
    }
}
