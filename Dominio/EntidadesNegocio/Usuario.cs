using System;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Dominio.EntidadesNegocio
{
    public class Usuario
    {
        [Required(ErrorMessage = "El documento es obligatorio")]
        [StringLength(8, ErrorMessage = "Documento incorrecto")]
        public string Documento { get; set; }

        [MinLength(3, ErrorMessage = "Debe superar 3 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El password es obligatorio")]
        [MinLength(6, ErrorMessage = "Debe superar 6 caracteres")]
        public string Password { get; set; }

        public Usuario()
        {

        }        

        public static string EncodePasswordToBase64(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }

        public bool VerificoPass(string password)
        {
            int contMay = 0;
            int contMin = 0;
            int contDig = 0;
            if (password.Length >= 6)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (char.IsUpper(password[i]))
                    {
                        contMay++;
                    }
                    if (char.IsLower(password[i]))
                    {
                        contMin++;
                    }
                    if (char.IsNumber(password[i]))
                    {
                        contDig++;
                    }
                }
            }
            return (contMay > 0 && contMin > 0 && contDig > 0);
        }
    }
}
