using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.EntidadesNegocio
{
    public class Vacuna : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CantidadDosis { get; set; }
        public int LapsoDiasDosis { get; set; }

        [Range(18, 90, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int MinEdad { get; set; }

        [Range(18, 90, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int MaxEdad { get; set; }

        [Range(0, 100, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int EficaciaPrev { get; set; }

        [Range(0, 100, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int EficaciaHosp { get; set; }

        [Range(0, 100, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int EficaciaCti { get; set; }

        [Range(-100, 50, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int MinTemp { get; set; }

        [Range(-100, 50, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int MaxTemp { get; set; }

        public int ProduccionAnual { get; set; }

        [Range(1, 4, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int FaseClinicaAprob { get; set; }

        public bool Emergencia { get; set; }
        public string EfectosAdversos { get; set; }
        public decimal Precio { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public string IdUsuario { get; set; }
        public string IdTipo { get; set; }
        public int[] Laboratorios { get; set; }

        public Vacuna()
        {

        }
    }
}
