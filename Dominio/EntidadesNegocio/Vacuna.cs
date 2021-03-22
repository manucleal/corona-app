using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    public class Vacuna: IValidable
    {
        public int id { get; }
        public string nombre { get; set; }
        public int cantidadDosis { get; set; }
        public int lapsoDiasDosis { get; set; }
        public int rangoEdad { get; set; }
        public int efPrev { get; set; }
        public int efHosp { get; set; }
        public int efCti { get; set; }
        public int rangoTemp { get; set; }
        public int produccionAnual { get; set; }
        public int faseClinicaAprob { get; set; }
        public bool emergencia { get; set; }
        public string efectosAdversos { get; set; }
        public decimal precio { get; set; }
        public DateTime ultimaModificacion { get; set; }
        //List<Pais> status;
        //Usuario usuario;
        //List<Laboratorio> laboratorios;
        //TipoVacuna tipoVacuna;

    }
}
