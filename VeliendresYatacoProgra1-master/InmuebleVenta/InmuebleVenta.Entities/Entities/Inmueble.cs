using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities
{
    public abstract class Inmueble
    {
        public int InmuebleId { get; set; }

        public string Estado { get; set; }
        public double PrecioInmueble { get; set; }
        public string DireccionInmueble { get; set; }
        //Tipo Inmueble
        public int TipoInmuebleId { get; set; }
        public TipoInmueble TipoInmueble { get; set; }
        public List<TipoInmueble> TipoInmuebles { get; set; }

        //Ubigeo
        public int UbigeoId { get; set; }

        public Ubigeo Ubigeo { get; set; }

        //Propietario
        public Propietario Propietario { get; set; }

        public int PropietarioId { get; set; }

        //Contrato
        public int ContratoId { get; set; }

        public Contrato Contrato { get; set; }

        //Visitas
        public Visita Visita { get; set; }
        public int VisitaId { get; set; }
        public ICollection<Visita> Visitas { get; set; }

        //Creacion de Lista de Visitas y Tipo de inmueble
        public Inmueble()
        {
            Visitas = new HashSet<Visita>();
            TipoInmuebles = new List<TipoInmueble>();
        }


    }
}
