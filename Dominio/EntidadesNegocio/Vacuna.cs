using System;
using System.Collections.Generic;

namespace Dominio.EntidadesNegocio
{
    public class Vacuna: IValidable
    {
        public int Id { get; }
        public string Nombre { get; set; }
        public int CantidadDosis { get; set; }
        public int LapsoDiasDosis { get; set; }
        public int MinEdad { get; set; }
        public int MaxEdad { get; set; }
        public int EficaciaPrev { get; set; }
        public int EficaciaHosp { get; set; }
        public int EficaciaCti { get; set; }
        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }
        public int ProduccionAnual { get; set; }
        public int FaseClinicaAprob { get; set; }
        public bool Emergencia { get; set; }
        public string EfectosAdversos { get; set; }
        public decimal Precio { get; set; }
        public DateTime UltimaModificacion { get; set; }
        //List<Pais> status;
        //Usuario usuario;
        //List<Laboratorio> laboratorios;
        //TipoVacuna tipoVacuna;

        public Vacuna()
        {

        }

        public bool AddVacuna(Vacuna unaVacuna)
        {
            bool response = false;

            return response;
        }
    }
}
