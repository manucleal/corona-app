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
    }
}
