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

        }

        public static void HistorialReservas()
        {

        }

        public static void RankingHabitaciones()
        {

        }
    }
}
