using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities
{
    public class ContratoAlquiler : Contrato
    {
        public int CantMeses { get; set; }
        public double MontoMensual { get; set; }
    }
}
