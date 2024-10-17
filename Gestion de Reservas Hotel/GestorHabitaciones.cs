using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class GestorHabitaciones
    {
        public List<Habitacion> habitaciones = new List<Habitacion>();
        public List<Habitacion> habitacionesReservadas = new List<Habitacion>();


        #region Metodos
        public void AgregarHabitaciones(Habitacion habitacion)
        {
            habitaciones.Add(habitacion);
        }
        #endregion Metodos
    }
}
