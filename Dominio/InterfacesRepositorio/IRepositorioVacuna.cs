using Dominio.EntidadesNegocio;
using System.Collections.Generic;

namespace Dominio.InterfacesRepositorio
{
    interface IRepositorioVacuna
    {
        bool Add(Vacuna unaVacuna);

        bool Remove(int idVacuna);

        bool Update(Vacuna unaVacuna);

        Vacuna FingById(int idVacuna);

        IEnumerable<Vacuna> FindAll();

        Vacuna FindByAll(string nombre);
    }
}
