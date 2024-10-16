using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class Servicio
    {
        #region Propiedades
        public string NombreServicio { get; set; }
        #endregion Propiedades

        #region Constructores
        public Servicio(string nombreServicio)
        {
            NombreServicio = nombreServicio;
        }
        #endregion Constructores
    }
}
