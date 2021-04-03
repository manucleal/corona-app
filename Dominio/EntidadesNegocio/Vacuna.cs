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
        public int RangoEdad { get; set; }
        public int EfPrev { get; set; }
        public int EfHosp { get; set; }
        public int EfCti { get; set; }
        public int RangoTemp { get; set; }
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
