using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities
{
    public class Cliente
    {
  //Atributos Cliente
        public int ClienteDNI{ get; set; }
        public string NombreCliente { get; set; }
        public string ApeCliente { get; set; }
        public int TelefonoCliente { get; set; }
        public int DireccionCliente { get; set; }

        // Visita
        public Visita Visita { get; set; }
        public int VisitaId { get; set; }
        public List<Visita> Visitas { get; set; }
        // Contrato
        public Contrato Contrato { get; set; }
        public int ContratoId { get; set; }
        public List<Contrato> Contratos { get; set; }

        //Creacion de Lista Contrato y Lista Visita
        public Cliente()
        {
            Visitas = new List<Visita>();
            Contratos = new List<Contrato>();
        }
    }
}
