using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class GestorHabitaciones
    {
        public static List<Habitacion> habitaciones = new List<Habitacion>();
        public static List<Habitacion> habitacionesReservadas = new List<Habitacion>();


        #region Metodos
        public static void AgregarHabitaciones(Habitacion habitacion)
        {
            habitaciones.Add(habitacion);
        }

        public static void ListarHabitaciones()
        {
            foreach (Habitacion habitacion in habitaciones)
            {
                Console.WriteLine($"N° Hab.: {habitacion.NumHabitacion}, Tipo Hab.: {habitacion.TipoHabitacion}, Capacidad: {habitacion.CapacidadHabitacion}");
            }
        }

        public static void ListaDeFechasReservadas()
        {

        }
        #endregion Metodos
    }
}
