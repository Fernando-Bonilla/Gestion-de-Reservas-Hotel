using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    class GestorReserva
    {

        #region Metodos
        public static string FormatoFecha(DateTime fecha)
        {
            return fecha.ToShortDateString();
        }
        #endregion Metodos
    }
}
