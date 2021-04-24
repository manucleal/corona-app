using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio.EntidadesNegocio;
using Dominio.InterfacesRepositorio;
using Repositorios.UtilidadesBD;

namespace Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario

    {

        public bool Add(Usuario unaUsuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindByAll(string nombre)
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(string documento)
        {
            try
            {
                Conexion handler = new Conexion();
                SqlConnection con = new Conexion().crearConexion();

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

        public bool Remove(int documento)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario unUsuario)
        {
            throw new NotImplementedException();
        }

        public bool Login(Usuario unUsuario)
        {
            bool logged = false;
            Usuario usuariobd = this.FindById(unUsuario.Documento);

            if (usuariobd != null && usuariobd.Password == unUsuario.Password)
            {
                logged = true;
            }

            return logged;
        }
    }
}
