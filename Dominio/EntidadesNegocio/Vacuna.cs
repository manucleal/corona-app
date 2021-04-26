using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio.EntidadesNegocio
{
    public class Vacuna : IValidable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cantidad dosis es obligatorio")]
        public int CantidadDosis { get; set; }

        [Required(ErrorMessage = "El lapso días es obligatorio")]
        public int LapsoDiasDosis { get; set; }

        [Required(ErrorMessage = "El Min Edad es obligatorio")]
        [Range(18, 90, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int MinEdad { get; set; }

        [Required(ErrorMessage = "El Max Edad es obligatorio")]
        [Range(18, 90, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int MaxEdad { get; set; }

        [Required(ErrorMessage = "La Eficacía. prev es obligatorio")]
        [Range(0, 100, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int EficaciaPrev { get; set; }

        [Required(ErrorMessage = "La Efic. hos es obligatorio")]
        [Range(0, 100, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int EficaciaHosp { get; set; }

        [Required(ErrorMessage = "La Efic. CTI es obligatorio")]
        [Range(0, 100, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int EficaciaCti { get; set; }

        [Required(ErrorMessage = "La Min temp. es obligatorio")]
        [Range(-100, 50, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int MinTemp { get; set; }

        [Required(ErrorMessage = "La Max temp. es obligatorio")]
        [Range(-100, 50, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int MaxTemp { get; set; }

        [Required(ErrorMessage = "La Produccion anual es obligatorio")]
        public int ProduccionAnual { get; set; }

        [Required(ErrorMessage = "La Fase Clínica aprob. es obligatorio")]
        [Range(1, 4, ErrorMessage = "El valor {0} debe estar entr {1} y {2}.")]
        public int FaseClinicaAprob { get; set; }

        public bool Emergencia { get; set; }
        public string EfectosAdversos { get; set; }
        public decimal Precio { get; set; }
        public DateTime UltimaModificacion { get; set; }
        public string IdUsuario { get; set; }
        public string IdTipo { get; set; }
        public int[] Laboratorios { get; set; }
        public bool Covax { get; set; }

        public Vacuna()
        {

        }
    }
}
