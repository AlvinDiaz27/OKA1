using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities
{
    public class TipoInmueble : Inmueble
    {
        //Atributos Tipo de Inmueble
        public string Descripcion { get; set; }
        public int Tipo { get; set; }
    }
}
