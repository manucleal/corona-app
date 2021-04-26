using Dominio.EntidadesNegocio;
using System.Collections.Generic;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioLaboratorio
    {
        bool Add(Laboratorio unLaboratorio);

        bool Remove(int idLaboratorio);

        bool Update(Laboratorio unLaboratorio);

        Laboratorio FindById(int idLaboratorio);

        IEnumerable<Laboratorio> FindAll();

        Laboratorio FindByAll(string nombre);
    }
}
