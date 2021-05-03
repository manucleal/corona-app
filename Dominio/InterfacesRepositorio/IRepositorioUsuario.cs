using Dominio.EntidadesNegocio;
using System.Collections.Generic;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioUsuario
    {
        bool Add(Usuario unUsuario);

        Usuario FindById(string documento);
    }
}
