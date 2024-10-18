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


            Habitacion habitacion1 = new Habitacion(101, "Simple", 2);
            GestorHabitaciones.AgregarHabitaciones(habitacion1);

            Habitacion habitacion2 = new Habitacion(102, "Simple", 2);
            GestorHabitaciones.AgregarHabitaciones(habitacion2);

            Habitacion habitacion3 = new Habitacion(103, "Doble", 4);
            GestorHabitaciones.AgregarHabitaciones(habitacion3);

        }
        
    }
}
