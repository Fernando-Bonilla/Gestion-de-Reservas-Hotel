using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class Usuario : Persona 
    {
        public static List<Usuario> usuarios = new List<Usuario>();

        #region Propiedades
        private string ?Password {  get; set; }
        private string? ConfirmPassword { get; set; }
        #endregion Propiedades

        #region Constructores
        public Usuario(string nombre, string apellido, string tipoDocumento, int numDocumento, DateTime fechaNacimiento, int telefono, string email, string password, string confirmPassword) : base(nombre, apellido, tipoDocumento, numDocumento, fechaNacimiento, telefono, email)
        {
            Password = password;
            ConfirmPassword = confirmPassword;            
        }
        #endregion Constructores

        #region Metodos
        public static string AltaUsuario()
        {
            string mensaje = "Usuario Creado";
            return mensaje; // Se utiliza un metodo que devuelve string, ya que si se desea usar interfaz de usuario el metodo no necesita modificarse
            //Console.WriteLine(mensaje); 
        }
        #endregion Metodos

    }
}
