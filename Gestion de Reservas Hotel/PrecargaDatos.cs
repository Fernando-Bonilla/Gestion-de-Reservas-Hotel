using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class PrecargaDatos
    {

        public static void PrecargarDatos() 
        {
            // Creo un par de usuarios para tener para testear
            Usuario usuario1 = new Usuario("Fernando", "Bonilla", "asd@gmail.com", "123", "123");
            GestorUsuario.usuarios.Add(usuario1);

            Usuario usuario2 = new Usuario("Nacho", "Bolso", "galli@gmail.com", "321", "321");
            GestorUsuario.usuarios.Add(usuario2);

            Usuario usuario3 = new Usuario("Jorge", "Alvarez", "jorge@gmail.com", "123", "123");
            GestorUsuario.usuarios.Add(usuario3);

            Usuario usuario4 = new Usuario("Japo", "Rodriguez", "japo@gmail.com", "123", "123");
            GestorUsuario.usuarios.Add(usuario4);

            // Instancio habitaciones
            Habitacion habitacion1 = new Habitacion(101, "simple", 2);
            GestorHabitaciones.AgregarHabitaciones(habitacion1);

            Habitacion habitacion2 = new Habitacion(102, "simple", 2);
            GestorHabitaciones.AgregarHabitaciones(habitacion2);

            Habitacion habitacion3 = new Habitacion(103, "simple", 4);
            GestorHabitaciones.AgregarHabitaciones(habitacion3);

            Habitacion habitacion4 = new Habitacion(104, "simple", 6);
            GestorHabitaciones.AgregarHabitaciones(habitacion4);

            Habitacion habitacion5 = new Habitacion(105, "simple", 2);
            GestorHabitaciones.AgregarHabitaciones(habitacion5);

            Habitacion habitacion6 = new Habitacion(106, "simple", 2);
            GestorHabitaciones.AgregarHabitaciones(habitacion6);

            Habitacion habitacion7 = new Habitacion(107, "simple", 2);
            GestorHabitaciones.AgregarHabitaciones(habitacion5);

            Habitacion habitacion8 = new Habitacion(108, "simple", 2);
            GestorHabitaciones.AgregarHabitaciones(habitacion8);

            Habitacion habitacion9 = new Habitacion(109, "simple", 2);
            GestorHabitaciones.AgregarHabitaciones(habitacion9);

            Habitacion habitacion10 = new Habitacion(110, "simple", 2);
            GestorHabitaciones.AgregarHabitaciones(habitacion10);

            Habitacion habitacion11 = new Habitacion(201, "doble", 4);
            GestorHabitaciones.AgregarHabitaciones(habitacion11);

            Habitacion habitacion12 = new Habitacion(202, "doble", 4);
            GestorHabitaciones.AgregarHabitaciones(habitacion12);

            Habitacion habitacion21 = new Habitacion(301, "suite", 6);
            GestorHabitaciones.AgregarHabitaciones(habitacion21);

            Habitacion habitacion22 = new Habitacion(302, "suite", 6);
            GestorHabitaciones.AgregarHabitaciones(habitacion22);




            // Genero un par de reservas para tener para testear
            Reserva reserva1 = new Reserva(101, new DateTime(2024, 11, 25), new DateTime(2024, 11, 29), 200, "asd@gmail.com", "Impaga");
            GestorReserva.reservas.Add(reserva1);

            Reserva reserva2 = new Reserva(103, new DateTime(2024, 12, 5), new DateTime(2024, 12, 9), 201, "galli@gmail.com", "Impaga");
            GestorReserva.reservas.Add(reserva2);

            Reserva reserva3 = new Reserva(302, new DateTime(2024, 11, 20), new DateTime(2024, 11, 23), 201, "galli@gmail.com","Impaga");
            GestorReserva.reservas.Add(reserva3);

            Reserva reserva4 = new Reserva(101, new DateTime(2025, 02, 02), new DateTime(2025, 02, 05), 200, "asd@gmail.com", "Impaga");
            GestorReserva.reservas.Add(reserva4);

            Reserva reserva5 = new Reserva(201, new DateTime(2024, 10, 24), new DateTime(2024, 10, 28), 200, "asd@gmail.com", "Impaga");
            GestorReserva.reservas.Add(reserva5);
        }
        
    }
}
