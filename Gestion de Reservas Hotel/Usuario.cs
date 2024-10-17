using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class Usuario : Persona 
    {        

        #region Propiedades
        public string ?Password { get; set; }
        public string? ConfirmPassword { get; set; }
        #endregion Propiedades

        #region Constructores
        public Usuario(string nombre, string apellido, string email, string password, string confirmPassword) : base(nombre, apellido, email)
        {
            Password = password;
            ConfirmPassword = confirmPassword;            
        }
        #endregion Constructores

        #region Metodos       
        #endregion Metodos

    }
}
