using Dominio.EntidadesNegocio;
using System.Collections.Generic;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioUsuario
    {
        bool Add(Usuario unUsuario);

        bool Remove(int documento);

        bool Update(Usuario unUsuario);

        Usuario FindById(string documento);

        IEnumerable<Usuario> FindAll();

        Usuario FindByAll(string nombre);
    }
}
