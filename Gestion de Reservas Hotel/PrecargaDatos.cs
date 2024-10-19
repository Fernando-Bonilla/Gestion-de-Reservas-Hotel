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


            Habitacion habitacion1 = new Habitacion(101, "simple", 2);
            GestorHabitaciones.AgregarHabitaciones(habitacion1);

            Habitacion habitacion2 = new Habitacion(102, "simple", 2);
            GestorHabitaciones.AgregarHabitaciones(habitacion2);

            Habitacion habitacion3 = new Habitacion(103, "doble", 4);
            GestorHabitaciones.AgregarHabitaciones(habitacion3);

            Habitacion habitacion4 = new Habitacion(104, "suite", 6);
            GestorHabitaciones.AgregarHabitaciones(habitacion4);


            Reserva reserva1 = new Reserva(101, new DateTime(2024, 11, 25), new DateTime(2024, 11, 29), 200, "asd@gmail.com");
            GestorReserva.reservas.Add(reserva1);

            Reserva reserva2 = new Reserva(103, new DateTime(2024, 12, 5), new DateTime(2024, 12, 9), 201, "galli@gmail.com");
            GestorReserva.reservas.Add(reserva2);
        }
        
    }
}
