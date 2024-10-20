using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    class GestorReserva
    {
        public static List <Reserva> reservas = new List <Reserva> ();

        #region Metodos
        public static string FormatoFecha(DateTime fecha)
        {
            return fecha.ToShortDateString();
        }

        public static void MostrarReservas()
        {
            foreach (Reserva reserva in reservas) 
            {
                Console.WriteLine($"ID Reserva: {reserva.IDReserva}, ID Usuario: {reserva.IDUsuario} Email: {reserva.EmailUsuario}, N° Hab: {reserva.NroHabitacion}, " +
                    $"Fech.Reserva: {reserva.FechaReserva}, " +
                    $"Fech. Check-In: {reserva.FechaCheckIn}, F. Check-Out: {reserva.FechaCheckOut}");
            }
            
        }

        public static string RealizarReserva()
        {
            // Verifica si hay un usuario logueado
            if (GestorUsuario.currentUser == null)
            {
                Console.WriteLine("Debe iniciar sesión antes de realizar una reserva.");
                return "No se pudo crear la reserva";
            }

            Console.WriteLine("Ingrese N° hab.: ");
            int numHabitacion;
            bool success = int.TryParse(Console.ReadLine(), out numHabitacion);
            while (!success) 
            {
                Console.WriteLine("Por favor ingrese un N° de hab. valido");
                success = int.TryParse(Console.ReadLine(), out numHabitacion);
            }

            // Pidiendo la fecha de Check-in
            Console.WriteLine("Ingrese la Fecha de Check-In (formato: dd/MM/yyyy):");

            DateTime fechaCheckIn;
            success = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaCheckIn);
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
            double duracionReserva = (fechaCheckOut - fechaCheckIn).TotalDays;
            while (!success || duracionReserva > 30 || fechaCheckOut <= fechaCheckIn)
            {
                if (!success)
                {
                    Console.WriteLine("Formato de fecha inválido. Ingrese nuevamente en formato dd/MM/yyyy:");

                }
                else if(duracionReserva > 30)
                {
                    Console.WriteLine("La reserva no puede ser mayor a 30 dias seguidos");
                }                
                else 
                {
                    Console.WriteLine("La fecha de Check-Out debe ser posterior a la fecha de Check-In. Inténtelo de nuevo:");
                }
                success = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaCheckOut); //el metodo TryParseExact obliga al usuario a que ingrese formato "dd/MM/yyyy", y luego dos paramentros 1- IFormatProvider = null, para la cultura, y 2- DateTimeStyles = None, controla cómo se deben interpretar las fechas (si se permiten espacios en blanco)
            }

            
            if (GestorReserva.CkeckStatusHabitacion(numHabitacion, fechaCheckIn, fechaCheckOut) == "Disponible")
            {
                Reserva reserva = new Reserva(numHabitacion, fechaCheckIn, fechaCheckOut, GestorUsuario.currentUser.Id, GestorUsuario.currentUser.Email);
                GestorReserva.reservas.Add(reserva);

                string mensajeResCreada = $"Reserva Creada: Cod.Reserva: {reserva.IDReserva}, N° Hab.: {reserva.NroHabitacion}, Fecha Check-In: {FormatoFecha(reserva.FechaCheckIn)}, " +
                    $"Fecha Check-Out: {FormatoFecha(reserva.FechaCheckOut)}";

                Console.WriteLine(mensajeResCreada);

                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();

                return mensajeResCreada;
            } else
            {
                string mensajeFailReserva = "La habitacion no se encuentra disponible para ese rango de fechas";
                return mensajeFailReserva;
            }       


        }

        public static string CkeckStatusHabitacion(int numHabitacion, DateTime fechaCheckIn, DateTime fechaCheckOut)
        { 
            List<int> habitacionesReservadas = new List<int>();
            foreach (Reserva reserva in reservas)
            {

                double duracionReserva = (reserva.FechaCheckOut - reserva.FechaCheckIn).TotalDays; //Uso la propiedad .TotalDays de la clase DateTime, ya que las fechas son de este tipo de dato
                double duracionReservaDeseada = (fechaCheckOut - fechaCheckIn).TotalDays;

                if (numHabitacion == reserva.NroHabitacion && fechaCheckIn >= reserva.FechaCheckIn && fechaCheckIn <= reserva.FechaCheckOut && fechaCheckOut >= reserva.FechaCheckIn && fechaCheckOut <= reserva.FechaCheckOut)
                {
                    habitacionesReservadas.Add(numHabitacion);
                }
            }

            if(habitacionesReservadas.Contains(numHabitacion))
            {
                return "Ocupada";
            }else
            {
                return "Disponible";
            }

        }

        public static void ModificarReserva()
        {
            Console.WriteLine("Ingrese el N° de reserva");
            int numReserva = 0;

            bool successNumReserva = int.TryParse(Console.ReadLine(), out numReserva);
            while (!successNumReserva) 
            {
                Console.WriteLine("Formato incorrecto, debe ingresar un registro numerico de al menos 5 digitos");
                successNumReserva = int.TryParse(Console.ReadLine(), out numReserva);
            }

            Console.WriteLine("Ingrese la Fecha de Check-In (formato: dd/MM/yyyy):");

            DateTime fechaCheckIn;
            bool successFechaCheckIn = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaCheckIn);
            while (!successFechaCheckIn || fechaCheckIn < DateTime.Today)
            {
                if (!successFechaCheckIn)
                {
                    Console.WriteLine("Formato de fecha inválido. Ingrese nuevamente en formato dd/MM/yyyy:");
                }
                else
                {
                    Console.WriteLine("La fecha de Check-In no puede ser anterior al día de hoy. Inténtelo de nuevo:");
                }
                successFechaCheckIn = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaCheckIn);
            }

            // Pidiendo la fecha de Check-Out
            Console.WriteLine("Ingrese la fecha de Check-Out (formato: dd/MM/yyyy):");
            DateTime fechaCheckOut;
            bool successFechaCheckOut = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaCheckOut);
            double duracionReserva = (fechaCheckOut - fechaCheckIn).TotalDays;
            while (!successFechaCheckOut || duracionReserva > 30 || fechaCheckOut <= fechaCheckIn)
            {
                if (!successFechaCheckOut)
                {
                    Console.WriteLine("Formato de fecha inválido. Ingrese nuevamente en formato dd/MM/yyyy:");

                }
                else if (duracionReserva > 30)
                {
                    Console.WriteLine("La reserva no puede ser mayor a 30 dias seguidos");
                }
                else
                {
                    Console.WriteLine("La fecha de Check-Out debe ser posterior a la fecha de Check-In. Inténtelo de nuevo:");
                }
                successFechaCheckOut = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaCheckOut); //el metodo TryParseExact obliga al usuario a que ingrese formato "dd/MM/yyyy", y luego dos paramentros 1- IFormatProvider = null, para la cultura, y 2- DateTimeStyles = None, controla cómo se deben interpretar las fechas (si se permiten espacios en blanco)
            }



        }

        public static void CancelarReserva()
        {
            Console.WriteLine("Ingrese el codigo de Reserva");
            int codigoReserva;
            bool success = int.TryParse(Console.ReadLine(), out codigoReserva);

            while (!success)
            {
                Console.WriteLine("Por favor debe ingresar un valor numerico de al menos 5 digitos");
                success = int.TryParse(Console.ReadLine(), out codigoReserva);
            }


            //Como C# no me deja eliminar mientras recorro una colleccion, si el n° reserva matchea con uno existente la guarda en una nueva list
            List<Reserva> reservaAEliminar = new List<Reserva>();
            
            DateTime today = DateTime.Today;
            int counter = 0;

            foreach(Reserva reserva in reservas)
            {                

                if (reserva.IDReserva == codigoReserva)
                {
                    double diasAntesDeComienzoReserva = (reserva.FechaCheckIn - today).TotalDays; //Chekeo que la cancelacion sea 48 hs antes del comienzo de la reserva

                    if(diasAntesDeComienzoReserva > 2)
                    {
                        reservaAEliminar.Add(reserva);
                    }                                                        
                    
                }else
                {
                    Console.WriteLine("Las reservas solo pueden ser canceladas 24 hs previas a la fecha de Check-in");
                    counter++;
                    break;
                }
            }

            if (reservaAEliminar.Count == 0 && counter == 0)
            {
                Console.WriteLine("No se encontraron coincidencias con el N° de reserva proporcionado");
            }else
            {
                foreach (Reserva reserva in reservaAEliminar)
                {

                    Console.WriteLine($"Reserva N°: {reserva.IDReserva} cancelada");
                    reservas.Remove(reserva);

                }
            }            

        }
        #endregion Metodos
    }
}
