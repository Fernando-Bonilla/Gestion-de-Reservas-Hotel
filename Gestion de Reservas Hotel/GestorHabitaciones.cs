using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class GestorHabitaciones
    {
        public Dictionary<string,int> tarifas = new Dictionary<string,int>{

            { "simple", 100 },
            { "doble", 150 },
            { "suite", 200 }
        };

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
