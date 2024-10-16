using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class ServicioPago : Servicio
    {
        #region Propiedades
        public int PrecioServicio { get; set; }
        #endregion Propiedades

        #region Constructores
        public ServicioPago(string nombreServicio, int precioServicio) : base(nombreServicio)
        {
            PrecioServicio = precioServicio;
        }
        #endregion Constructores
    }
}
