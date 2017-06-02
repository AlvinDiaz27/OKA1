using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities
{
    public class Empleado
    {
        //Atributos Empleado
        public int EmpleadoDNI { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApeEmpleado { get; set; }
        public int TelefonoEmpleado { get; set; }
        public string DireccionEmpleado { get; set; }
        //Visita
        public List<Visita> Visitas { get; set; }
        public Visita Visita { get; set; }
        public int VisitaId { get; set; }
        //Contrato
        public Contrato Contrato { get; set; }
        public int ContratoId { get; set; }
        public List<Contrato> Contratos { get; set; }
        //Creacion de Lista de Visita y Contrato
        public Empleado()
        {
            Visitas = new List<Visita>();
            Contratos = new List<Contrato>();
        }



    }
}
