using Dominio.EntidadesNegocio;
using System.Collections.Generic;

namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioPais
    {
        IEnumerable<Pais> FindAll();
    }
}
