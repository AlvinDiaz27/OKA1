using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities
{
    public class Ubigeo
    {
        //Atributos
        public int UbigeoId { get; set; }
        //Departamento
        public Departamento Departamento { get; set; }

        public int DepartamentoId { get; set; }
        //Provincia

        public Provincia Provincia { get; set; }
        public int ProvinciaId { get; set; }

        //Distrito
        public Distrito Distrito { get; set; }
        public int DistritoId { get; set; }


        public Ubigeo()
        {



        }
        // Inicializacion de las Entidades
        public Ubigeo(Departamento departamento, Provincia provincia, Distrito distrito)
        {
            Departamento = departamento;
            Provincia = provincia;
            Distrito = distrito;

        }


    }
}
