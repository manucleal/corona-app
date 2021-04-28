using System.Collections.Generic;
using Repositorios;
using Dominio.EntidadesNegocio;

namespace WcfServicioCoronApp
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioVacunas" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioVacunas.svc o ServicioVacunas.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioVacunas : IServicioVacunas
    {
        private RepositorioVacuna repositorioVacuna = new RepositorioVacuna();

        public IEnumerable<DtoVacunas> GetTodasLasVacunas()
        {
            IEnumerable<Vacuna> vacunas = repositorioVacuna.FindAll();
            if (vacunas == null) return null;            return ConvertirListaDtosDesdeVacunas(vacunas);
        }

        private IEnumerable<DtoVacunas> ConvertirListaDtosDesdeVacunas(IEnumerable<Vacuna> vacunas)
        {
            List<DtoVacunas> lista = new List<DtoVacunas>();
            foreach (Vacuna vacuna in vacunas)
            {
                DtoVacunas unDtoVacuna = new DtoVacunas();
                unDtoVacuna.ConvertirDesdeVacuna(vacuna);
                lista.Add(unDtoVacuna);
            }
            return lista;
        }

    }
}
