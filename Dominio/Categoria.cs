using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int tasaDescuento = -1;

        public int TasaDescuento
        {
            get { return tasaDescuento; }
            set { if (tasaDescuento == -1) tasaDescuento = value; }
        }

        public Categoria()
        {
            //string conn = System.Configuration.ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
        }

    }
}
