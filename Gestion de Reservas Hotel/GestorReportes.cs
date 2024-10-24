using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class GestorReportes
    {

        public static void ListarUsuarios()
        {
            List<Usuario> usuariosOrdenadosPorApellido = GestorUsuario.usuarios.OrderBy(usuario => usuario.Apellido).ToList();            
            Console.WriteLine("***** Lista de usuarios *****");
            Console.WriteLine("");
            foreach(Usuario usuario in usuariosOrdenadosPorApellido)
            {
                Console.WriteLine($"{usuario.Apellido} {usuario.Nombre} - {usuario.Email}");
            }

        }

        public static void ListarHabitacionesDisponibles() 
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

            foreach (Habitacion habitacion in GestorHabitaciones.habitaciones)
            {
                if (GestorHabitaciones.CheckStatusHabitacion(habitacion.NumHabitacion, fechaCheckIn, fechaCheckOut) == "Disponible")
                {
                    Console.WriteLine(habitacion.ToString());
                }
            }


        }

        public static void HistorialReservasPorUsuario()
        {
            Console.WriteLine("Ingrese un Email: ");
            string? email = Console.ReadLine();

            // Valida si el email existe o si su formato es incorrecto
            while (true)
            {
                if (string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("El campo no puede estar vacío. Ingrese un email válido:");
                }
                else if (!GestorUsuario.ChequearFormatoEmail(email)) // Aquí se chequea solo el formato, no si está vacío
                {
                    Console.WriteLine("El correo electrónico no tiene un formato válido. Ingrese uno correcto:");
                }
                else if (!GestorUsuario.ChequearSiUsuarioExiste(email))
                {
                    Console.WriteLine("No existen registros asociados a este email");
                    break;
                }
                else
                {
                    break; // Si todas las validaciones pasan, sale del bucle
                }

                email = Console.ReadLine(); // Pide el email nuevamente si falló alguna validación
            }
            
            foreach(Reserva reserva in GestorReserva.reservas)
            {
                if(email == reserva.EmailUsuario)
                {
                    Console.WriteLine($"N° Reserva: {reserva.IDReserva}, N° Hab.: {reserva.NroHabitacion}, Fech. Check-in: {GestorReserva.FormatoFecha(reserva.FechaCheckIn)}, Fech. Check-Out: {GestorReserva.FormatoFecha(reserva.FechaCheckOut)}, Fecha reserva: {reserva.FechaReserva}, Estado: {reserva.EstadoReserva}");
                }
            }
        }

        public static void RankingHabitaciones()
        {

        }
    }
}
