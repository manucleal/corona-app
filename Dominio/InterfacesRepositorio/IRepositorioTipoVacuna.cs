using Dominio.EntidadesNegocio;
using System.Collections.Generic;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioTipoVacuna
    {
        bool Add(TipoVacuna unTipoVacuna);

        bool Remove(int idTipoVacuna);

        bool Update(TipoVacuna unTipoVacuna);

        TipoVacuna FindById(string idTipoVacuna);

        IEnumerable<TipoVacuna> FindAll();
    }
}
