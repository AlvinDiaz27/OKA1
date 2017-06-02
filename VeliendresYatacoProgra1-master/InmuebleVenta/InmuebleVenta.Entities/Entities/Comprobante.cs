using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities
{
    public abstract class Comprobante
    {
        //Atributos Comprobante
        public int ComprobanteId { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }


        //Contrato Reserva
        public ContratoReserva ContratoReserva { get; set; }
        public int ContratoResarvaId { get; set; }

        //Contrato Alquiler
        public ContratoAlquiler ContratoAlquiler { get; set; }
        public int ContratoAlquilerId { get; set; }
    }
}
