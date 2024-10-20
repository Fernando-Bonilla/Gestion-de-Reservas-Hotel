using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class GestorHabitaciones
    {
        public static Dictionary<string,int> tarifas = new Dictionary<string,int>{

            { "simple", 100 },
            { "doble", 150 },
            { "suite", 200 }
        };

        public static List<Habitacion> habitaciones = new List<Habitacion>();
        //public static List<Habitacion> habitacionesReservadas = new List<Habitacion>();


        #region Metodos
        public static void AgregarHabitaciones(Habitacion habitacion)
        {
            habitaciones.Add(habitacion);
        }

        public static bool NumHabitacionExiste(int numHabitacion)
        {
            
            if(habitaciones.Any(habitacion => habitacion.NumHabitacion == numHabitacion))
            {
                return true;
            }else
            {
                return false;
            }
            
        }

        public static void ListarHabitaciones()
        {
            // Pidiendo la fecha de Check-in
            Console.WriteLine("Ingrese la Fecha de Check-In (formato: dd/MM/yyyy):");

            DateTime fechaCheckIn;
            bool success = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaCheckIn);
            while (!success || fechaCheckIn < DateTime.Today)
            {
                if (!success)
                {
                    Console.WriteLine("Formato de fecha inválido. Ingrese nuevamente en formato dd/MM/yyyy:");
                }
                else
                {
                    Console.WriteLine("La fecha de Check-In no puede ser anterior al día de hoy. Inténtelo de nuevo:");
                }
                success = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaCheckIn);
            }

            // Pidiendo la fecha de Check-Out
            Console.WriteLine("Ingrese la fecha de Check-Out (formato: dd/MM/yyyy):");
            DateTime fechaCheckOut;
            success = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaCheckOut);
            while (!success || fechaCheckOut <= fechaCheckIn)
            {
                if (!success)
                {
                    Console.WriteLine("Formato de fecha inválido. Ingrese nuevamente en formato dd/MM/yyyy:");
                }
                else
                {
                    Console.WriteLine("La fecha de Check-Out debe ser posterior a la fecha de Check-In. Inténtelo de nuevo:");
                }
                success = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaCheckOut); //el metodo TryParseExact obliga al usuario a que ingrese formato "dd/MM/yyyy", y luego dos paramentros 1- IFormatProvider = null, para la cultura, y 2- DateTimeStyles = None, controla cómo se deben interpretar las fechas (si se permiten espacios en blanco)
            }

            foreach (Habitacion habitacion in habitaciones) 
            {
                if(GestorReserva.CkeckStatusHabitacion(habitacion.NumHabitacion, fechaCheckIn, fechaCheckOut) == "Disponible")
                {
                    Console.WriteLine(habitacion.ToString());
                } 
            }

        }

        public static void ListaDeFechasReservadas()
        {

        }
        #endregion Metodos
    }
}
