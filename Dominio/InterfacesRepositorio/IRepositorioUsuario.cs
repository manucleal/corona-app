using Dominio.EntidadesNegocio;
namespace Dominio.InterfacesRepositorio
{
    public interface IRepositorioUsuario
    {
        bool Add(Usuario unUsuario);

        Usuario FindById(string documento);

        Usuario Login(Usuario unUsuario);
    }
}
