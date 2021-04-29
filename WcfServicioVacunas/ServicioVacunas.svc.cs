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

        public IEnumerable<DtoVacunas> GetTodasLasVacunasPorFaseAprob(int faseClinicaAprob)
        {
            IEnumerable<Vacuna> vacunas = repositorioVacuna.FindAllByApprovalPhase(faseClinicaAprob);
            if (vacunas == null) return null;            return ConvertirListaDtosDesdeVacunas(vacunas);
        }

        public IEnumerable<DtoVacunas> GetTodasLasVacunasPorNombre(string nombre)
        {
            IEnumerable<Vacuna> vacunas = repositorioVacuna.FindAllByName(nombre);
            if (vacunas == null) return null;            return ConvertirListaDtosDesdeVacunas(vacunas);
        }

        public IEnumerable<DtoVacunas> GetTodasLasVacunasPorNombreLab(string nombre)
        {
            IEnumerable<Vacuna> vacunas = repositorioVacuna.FindAllByLabName(nombre);
            if (vacunas == null) return null;            return ConvertirListaDtosDesdeVacunas(vacunas);
        }

        public IEnumerable<DtoVacunas> GetTodasLasVacunasPorPaisLab(string pais)
        {
            IEnumerable<Vacuna> vacunas = repositorioVacuna.FindAllByCountry(pais);
            if (vacunas == null) return null;            return ConvertirListaDtosDesdeVacunas(vacunas);
        }

        public IEnumerable<DtoVacunas> GetTodasLasVacunasPorTipoVac(string idTipo)
        {
            IEnumerable<Vacuna> vacunas = repositorioVacuna.FindAllByTypeVac(idTipo);
            if (vacunas == null) return null;            return ConvertirListaDtosDesdeVacunas(vacunas);
        }

        public IEnumerable<DtoVacunas> GetTodasLasVacunasPorTopeInferior(decimal precio)
        {
            IEnumerable<Vacuna> vacunas = repositorioVacuna.FindAllByMinPrice(precio);
            if (vacunas == null) return null;            return ConvertirListaDtosDesdeVacunas(vacunas);
        }

        public IEnumerable<DtoVacunas> GetTodasLasVacunasPorTopeSuperior(decimal precio)
        {
            IEnumerable<Vacuna> vacunas = repositorioVacuna.FindAllByMaxPrice(precio);
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
