using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities
{
    public abstract class Contrato
    {
        public int ContratoId { get; set; }

        public DateTime Fecha { get; set; }


        ////Contrato Reserva
        //public ContratoReserva ContratoReserva { get; set; }
        //public int ContratoReservaId { get; set; }


        //// Contrato Alquiler
        //public ContratoAlquiler ContratoAlquiler { get; set; }
        //public int ContratoAlquilerId { get; set; }

        ////Contrato Venta
        //public ContratoVenta ContratoVenta { get; set; }
        //public int ContratoVentaId { get; set; }


        //Cliente
        public int ClienteDNI { get; set; }
        public Cliente Cliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApeCliente { get; set; }

        //Propietario
        public Propietario Propietario { get; set; }
        public int PropietarioDNI { get; set; }

        public string ApePropietario { get; set; }
        public string NombrePropietario { get; set; }


        //Inmueble

        public int InmuebleId { get; set; }

        public Inmueble Inmueble { get; set; }
        public double PrecioInmueble { get; set; }

        //Empleado

        public Empleado Empleado { get; set; }

        public int EmpleadoDNI { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApeEmpleado { get; set; }
    }
}
