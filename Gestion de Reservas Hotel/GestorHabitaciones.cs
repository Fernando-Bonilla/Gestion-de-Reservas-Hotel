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
            //En esta variable voy a guardar lo que el usuario elija a la hora de pickear un tipo de hab.
            string tipoHabitacion = "";

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

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("* Elija un tipo de habitacion *");
                Console.WriteLine("");

                Console.WriteLine("1. Simple (capacidad: 2 huespedes)");
                Console.WriteLine("");
                Console.WriteLine("2. Doble (capacidad: 4 huespedes)");
                Console.WriteLine("");
                Console.WriteLine("3. Suit (capacidad: 6 huespedes)");
                Console.WriteLine("");                

                int opcion;                

                bool successTipoHab = int.TryParse(Console.ReadLine(), out opcion);
                while (successTipoHab == false)
                {
                    Console.WriteLine("Por favor seleccione una opcion valida");
                    successTipoHab = int.TryParse(Console.ReadLine(), out opcion);
                }

                switch (opcion)
                {
                    case 1:
                        tipoHabitacion = "simple";
                        salir = true;
                        break;

                    case 2:
                        tipoHabitacion = "doble";
                        salir = true;
                        break;

                    case 3:
                        tipoHabitacion = "suit";
                        salir = true;
                        break;                    

                }

            }


            foreach (Habitacion habitacion in habitaciones) 
            {
                if(GestorHabitaciones.CheckStatusHabitacion(habitacion.NumHabitacion, fechaCheckIn, fechaCheckOut) == "Disponible" && habitacion.TipoHabitacion == tipoHabitacion)
                {
                    Console.WriteLine(habitacion.ToString());
                } 
            }

        }

        public static string CheckStatusHabitacion(int numHabitacion, DateTime fechaCheckIn, DateTime fechaCheckOut)
        {            
            List<int> habitacionesReservadas = new List<int>();

            foreach (Reserva reserva in GestorReserva.reservas)
            {

                if (numHabitacion == reserva.NroHabitacion && fechaCheckIn >= reserva.FechaCheckIn &&
                    fechaCheckIn <= reserva.FechaCheckOut || numHabitacion == reserva.NroHabitacion && fechaCheckOut <= reserva.FechaCheckOut &&
                    fechaCheckOut >= reserva.FechaCheckIn || numHabitacion == reserva.NroHabitacion && fechaCheckIn <= reserva.FechaCheckOut && fechaCheckOut >= reserva.FechaCheckIn)
                {                    
                    habitacionesReservadas.Add(numHabitacion); 
                    
                }
            }

            if (habitacionesReservadas.Contains(numHabitacion))
            {                
                return "Ocupada";                
            }
            else
            {
                return "Disponible";
            }

        }

        public static void ListaDeFechasReservadas()
        {

        }
        #endregion Metodos
    }
}
