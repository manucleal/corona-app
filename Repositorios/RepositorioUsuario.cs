using System;
using System.Data.SqlClient;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;
using Repositorios.UtilidadesBD;

namespace Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public bool Add(Usuario unUsuario)
        {
            if (unUsuario == null || !unUsuario.VerificoPass(unUsuario.Password)) return false;
            try
            {
                Conexion handler = new Conexion();
                SqlConnection con = new Conexion().CrearConexion();

                SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios VALUES (@Documento,@Nombre,@Password)", con);

                cmd.Parameters.AddWithValue("@Documento", unUsuario.Documento);
                cmd.Parameters.AddWithValue("@Nombre", unUsuario.Nombre);
                cmd.Parameters.AddWithValue("@Password", Usuario.EncodePasswordToBase64(unUsuario.Password));

                if (handler.AbrirConexion(con))
                {
                    int filas = cmd.ExecuteNonQuery();
                    handler.CerrarConexion(con);
                    return filas >= 1;
                }
                return false;
            }
            catch (Exception exp)
            {
                System.Diagnostics.Debug.Assert(false, "Error al ingresar Usuario" + exp.Message);
                return false;
            }
        }

        public Usuario FindById(string documento)
        {
            try
            {
                Conexion handler = new Conexion();
                SqlConnection con = new Conexion().CrearConexion();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE Documento=@documento", con);
                cmd.Parameters.AddWithValue("@documento", documento);

                if (handler.AbrirConexion(con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Usuario unUsuario = new Usuario();
                        if (reader.Read())
                        {
                            unUsuario.Documento = reader["Documento"].ToString();
                            unUsuario.Nombre = reader["Nombre"].ToString();
                            unUsuario.Password = reader["Password"].ToString();
                        }

                        return unUsuario;
                    }
                }
            }
            catch (Exception exp)
            {
                System.Diagnostics.Debug.Assert(false, "Error al ingresar Vacuna" + exp.Message);
                return new Usuario();
            }

            return new Usuario();
        }

        public Usuario Login(Usuario unUsuario)
        {
            Usuario usuariobd = this.FindById(unUsuario.Documento);

            if (usuariobd != null && usuariobd.Password == Usuario.EncodePasswordToBase64(unUsuario.Password))
            {
                return usuariobd;
            }

            return new Usuario();
        }
    }
}
