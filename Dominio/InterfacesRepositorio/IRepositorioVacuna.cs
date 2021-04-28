using Dominio.EntidadesNegocio;
using System.Collections.Generic;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioVacuna
    {
        bool Add(Vacuna unaVacuna);

        bool Remove(int idVacuna);

        bool Update(Vacuna unaVacuna);

        Vacuna FindById(int idVacuna);

        IEnumerable<Vacuna> FindAll();

        Vacuna FindByAll(string nombre);

        IEnumerable<Vacuna> FindAllByName(string nombre);

        IEnumerable<Vacuna> FindAllByApprovalPhase(int FaseClinicaAprob);

        IEnumerable<Vacuna> FindAllByCountry(string pais);

        IEnumerable<Vacuna> FindAllByMaxPrice(int precioMax);

        IEnumerable<Vacuna> FindAllByMinPrice(int precioMin);

        IEnumerable<Vacuna> FindAllByIdTypeVac(int idVac);

        IEnumerable<Vacuna> FindAllByLabName(string nombreLab);
    }
}
