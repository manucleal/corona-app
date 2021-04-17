using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.EntidadesNegocio
{
    class Laboratorio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PaisOrigen { get; set; }
        public bool Experiencia { get; set; }


        public bool Validar()
        {
            return this.Id > 0 && this.Nombre != "" && this.PaisOrigen != "";
        }




    }
}
