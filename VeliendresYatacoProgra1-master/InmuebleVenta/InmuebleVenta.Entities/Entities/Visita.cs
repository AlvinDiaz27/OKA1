
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities
{
    public class Visita
    {
        public int VisitaId { get; set; }
        public DateTime FechaVisita { get; set; }

        //Empleado

        public Empleado Empleado { get; set; }

        public int EmpleadoId { get; set; }
        //Cliente

        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }

        //Inmueble
        public List<Inmueble> Inmuebles { get; set; }

        public Visita()
        {
            Inmuebles = new List<Inmueble>();
        }
    }
}
