using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class GestorUsuario
    {
        public static List<Usuario> usuarios = new List<Usuario>();

        public static void CrearUsuario()
        {
            Menu.LimpiarPantalla();

            Console.WriteLine("");
            Console.WriteLine("Nombre: ");
            string ?nombre = Console.ReadLine();

            Console.WriteLine("Apellido: ");
            string ?apellido = Console.ReadLine();

            /*Console.WriteLine("Telefono: ");
            string telefono = Console.ReadLine();

            int numeroTelefono;
            bool successTelefono = int.TryParse(telefono, out numeroTelefono);

            while (!successTelefono || numeroTelefono < 10000000) 
            {
                Console.WriteLine("El numero de telefono debe tener al menos 8 digitos");
                telefono = Console.ReadLine();
                successTelefono = int.TryParse(telefono, out numeroTelefono);
            }*/

            Console.WriteLine("Email: ");
            string ?email = Console.ReadLine();

            Console.WriteLine("Contraseña: ");
            string ?password = Console.ReadLine();

            Console.WriteLine("Confirmar contraseña: ");
            string confirmPassword = Console.ReadLine();

            while (password != confirmPassword)
            {
                Console.WriteLine("La contraseña y confirmacion deben coincidir");
                Console.WriteLine("Nueva Contraseña: ");
                password = Console.ReadLine();
                Console.WriteLine("Confirmar Nueva Contraseña: ");
                confirmPassword = Console.ReadLine();
            }

            Usuario usuario = new Usuario(nombre, apellido, email, password, confirmPassword);
            usuarios.Add(usuario);

            Console.WriteLine("Usuario creado");
            
        }

        public static void IniciarSesion()
        {
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();  
            Console.WriteLine("Contraseña: ");
            string password = Console.ReadLine();

            foreach(Usuario usuario in usuarios)
            {
                if(usuario.Email == email && usuario.Password == password)
                {
                    Menu.LimpiarPantalla();
                    Menu.MostrarMenuLogueado();
                }
                else
                {
                    Console.WriteLine("Error de logueo");
                }
            }           
            

        }

        public static void RecuperarPassword()
        {
            Console.WriteLine("Email: ");
            string? email = Console.ReadLine();

            Console.WriteLine("Nueva Contraseña: ");
            string? password = Console.ReadLine();

            Console.WriteLine("Confirmar Nueva Contraseña: ");
            string confirmPassword = Console.ReadLine();

            while(password != confirmPassword)
            {
                Console.WriteLine("La contraseña y confirmacion deben coincidir");
                Console.WriteLine("Nueva Contraseña: ");
                password = Console.ReadLine();
                Console.WriteLine("Confirmar Nueva Contraseña: ");
                confirmPassword = Console.ReadLine();
            }

            foreach(Usuario usuario in usuarios)
            {
                if (usuario.Email == email)
                {
                    usuario.Password = password;
                }
            }

            Console.WriteLine("Contraseña cambiada");
        }
    }
}
