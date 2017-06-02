using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities
{
    public class Propietario
    {
        public int PropietarioDNI { get; set; }
        public string NombrePropietario { get; set; }
        public string ApePropietario { get; set; }
        public int TelefonoPropietario { get; set; }
        public string DireccionPropietario { get; set; }


        //Inmueble
        public Inmueble Inmueble { get; set; }
        public int InmuebleId { get; set; }
        public List<Inmueble> Inmuebles { get; set; }

        public Propietario()
        {
            Inmuebles = new List<Inmueble>();
            Contratos = new List<Contrato>();
        }
        //Contrato
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public List<Contrato> Contratos { get; set; }

       

    }
}
