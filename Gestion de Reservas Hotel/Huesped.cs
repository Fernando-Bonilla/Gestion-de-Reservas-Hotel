using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class Huesped : Persona
    {
        public static List<Huesped> huespedes = new List<Huesped>();

        #region Propiedades
        public string ?Pais {  get; set; }
        #endregion Propiedades

        #region Constructores
        public Huesped(string nombre, string apellido, string tipoDocumento, int numDocumento, DateTime fechaNacimiento, int telefono, string email, string pais) : base(nombre, apellido, tipoDocumento, numDocumento, fechaNacimiento, telefono, email) 
        {
            Pais = pais;
        }
        #endregion Constructores

        #region Metodos
        #endregion Metodos
    }
}
