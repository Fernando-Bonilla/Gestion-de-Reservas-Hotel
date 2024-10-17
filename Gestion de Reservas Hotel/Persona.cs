using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class Persona
    {
        private static int idGenerator = 200;

        #region Propiedades
        public int Id { get; private set; }
        public string ?Nombre { get; set; }
        public string ?Apellido { get; set; }
        public string ?TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public string ?Email { get; set; }
        #endregion Propiedades

        #region Constructores

        public Persona()
        {
            
        }

        public Persona(string nombre, string apellido, string email)
        {
            Nombre = nombre;
            Apellido = apellido;                   
            Email = email;
        }

        public Persona(string nombre, string apellido, string tipoDocumento, int numeroDocumento, DateOnly fechaNacimiento, int telefono, string email)
        {
            Id = idGenerator++;
            Nombre = nombre;
            Apellido = apellido;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            FechaNacimiento = fechaNacimiento;
            Telefono = telefono;
            Email = email;            
        }
        #endregion Constructores

        #region Metodos
        #endregion Metodos
    }
}
