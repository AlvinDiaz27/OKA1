using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities
{
    public class Provincia
    {
        //Atributos Provincia 
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }

        //Ubigeo
        public List<Ubigeo> Ubigeos { get; set; }

        //Creacion de Lista de Ubigeo
        public Provincia()
        {
            Ubigeos = new List<Ubigeo>();
        }
    }
}

