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
                success = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaCheckOut);
            }

            Reserva reserva = new Reserva(numHabitacion, fechaCheckIn, fechaCheckOut, GestorUsuario.currentUser.Id, GestorUsuario.currentUser.Email);
            GestorReserva.reservas.Add(reserva);

            string mensajeResCreada = $"Reserva Creada: Cod.Reserva: {reserva.IDReserva}, N° Hab.: {reserva.NroHabitacion}, Fecha Check-In: {FormatoFecha(reserva.FechaCheckIn)}, " +
                $"Fecha Check-Out: {FormatoFecha(reserva.FechaCheckOut)}";

            Console.WriteLine (mensajeResCreada);

            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();

            return mensajeResCreada;            
            
        }


        #endregion Metodos
    }
}
