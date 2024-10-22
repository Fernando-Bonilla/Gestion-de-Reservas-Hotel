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
        public static Usuario currentUser;

        public static void CrearUsuario()
        {
            Menu.LimpiarPantalla();

            Console.WriteLine("");
            Console.WriteLine("Nombre: ");
            string ?nombre = Console.ReadLine();

            while (ChequearInformacionNoEsVaciaONula(nombre))
            {
                Console.WriteLine("El campo no puede estar vacio: ");
                nombre = Console.ReadLine();
            }

            Console.WriteLine("Apellido: ");
            string ?apellido = Console.ReadLine();

            while (ChequearInformacionNoEsVaciaONula(apellido))
            {
                Console.WriteLine("El campo no puede estar vacio: ");
                apellido = Console.ReadLine();
            }

            Console.WriteLine("Email: ");
            string ?email = Console.ReadLine();            

            // Valida si el email ya existe o si su formato es incorrecto
            while (true)
            {
                if (string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("El campo no puede estar vacío. Ingrese un email válido:");
                }
                else if (!ChequearFormatoEmail(email)) // Aquí se chequea solo el formato, no si está vacío
                {
                    Console.WriteLine("El correo electrónico no tiene un formato válido. Ingrese uno correcto:");
                }
                else if (ChequearSiUsuarioExiste(email))
                {
                    Console.WriteLine("Email no disponible, por favor ingrese otro:");
                }
                else
                {
                    break; // Si todas las validaciones pasan, sale del bucle
                }

                email = Console.ReadLine(); // Pide el email nuevamente si falló alguna validación
            }

            Console.WriteLine("Contraseña: ");
            string ?password = Console.ReadLine();

            Console.WriteLine("Confirmar contraseña: ");
            string confirmPassword = Console.ReadLine();

            while (password != confirmPassword || ChequearInformacionNoEsVaciaONula(password) || ChequearInformacionNoEsVaciaONula(confirmPassword))
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

            while (true)
            {
                if (string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("El campo no puede estar vacío. Ingrese un email válido:");
                }
                else if (!ChequearFormatoEmail(email)) // Aquí se chequea solo el formato, no si está vacío
                {
                    Console.WriteLine("El correo electrónico no tiene un formato válido. Ingrese uno correcto:");
                }
                else if (!ChequearSiUsuarioExiste(email))
                {
                    Console.WriteLine("Email incorrecto:");
                }
                else
                {
                    break; // Si todas las validaciones pasan, sale del bucle
                }

                email = Console.ReadLine(); // Pide el email nuevamente si falló alguna validación
            }


            Console.WriteLine("Contraseña: ");
            string password = Console.ReadLine();

            foreach(Usuario usuario in usuarios)
            {
                if(usuario.Email == email && usuario.Password == password)
                {
                    currentUser = usuario; //Guardo los datos del usuario que esta logueado actualmente para poder pasar estos datos al momento de generar una reserva

                    Console.WriteLine($"Bienvenido {usuario.Nombre}");
                    Menu.LimpiarPantalla();
                    Menu.MostrarMenuLogueado();
                    return;
                }           

            }
            Console.WriteLine("Error de logueo");
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

        public static bool ChequearSiUsuarioExiste(string email)
        {
            if(usuarios.Any(usuario => usuario.Email == email))
            {                
                return true;
            }else
            {
                return false;
            }
        }

        public static bool ChequearInformacionNoEsVaciaONula(string dato)
        {
            return string.IsNullOrEmpty(dato);
        }

        public static bool ChequearFormatoEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
            {                
                return false;
            }
            try
            {
                string formatoEmail = new System.Net.Mail.MailAddress(email).ToString(); //Chequeo que el mail tenga el formato adecuado usando el metodo .MailAddress() de la clase System.Net
                
                if (formatoEmail == email)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FormatException)
            {                
                return false;
            }
        }
    }
}
