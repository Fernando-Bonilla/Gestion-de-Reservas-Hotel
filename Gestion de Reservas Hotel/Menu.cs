using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class Menu
    {
        
        public static void MostrarMenu()
        {

            bool salir = false;

            while (!salir)
            {              

                Console.WriteLine("****** Menu Inicio Sesion ******");
                Console.WriteLine("");                

                Console.WriteLine("1. Iniciar Sesion");
                Console.WriteLine("");
                Console.WriteLine("2. Registrarse");
                Console.WriteLine("");
                Console.WriteLine("3. Recuperar Contraseña");
                Console.WriteLine("");

                Console.WriteLine("0. Salir");

                string ingreso = Console.ReadLine();
                int opcion;

                bool success = int.TryParse(ingreso, out opcion);
                while (success == false)
                {
                    Console.WriteLine("Por favor ingrese una opcion valida");
                    success = int.TryParse(Console.ReadLine(), out opcion);
                }               


                switch (opcion)
                {
                    case 1:
                        GestorUsuario.IniciarSesion();
                        break;

                    case 2:
                        GestorUsuario.CrearUsuario();
                        break;

                    case 3:
                        GestorUsuario.RecuperarPassword();
                        break;

                    case 0:
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opcion no valida");
                        break;


                }

            }

        }

        public static void MostrarMenuLogueado()
        {
            bool salir = false;

            while (!salir)
            {               
                
                Console.WriteLine("*********** Menu Principal ***********");
                Console.WriteLine("");
                
                Console.WriteLine("1. Reservas y cancelaciones");
                Console.WriteLine("");
                Console.WriteLine("2. Gestion de pagos");
                Console.WriteLine("");
                Console.WriteLine("3. Estadisticas y reportes");
                Console.WriteLine("");
                Console.WriteLine("0. Volver al Menu de inicio de sesion");

                int opcion;

                bool success = int.TryParse(Console.ReadLine(), out opcion);
                while (success == false)
                {
                    Console.WriteLine("Por favor ingrese una opcion valida");
                    success = int.TryParse(Console.ReadLine(), out opcion);
                }

                switch (opcion)
                {
                    
                    case 1:
                        MostrarSubmenuReservasYCancelaciones();
                        break;

                    case 2:
                        MostrarSubmenuGestionDePagos();
                        break;

                    case 3:
                        MostrarSubmenuEstadisticasYReportes();
                        break;

                    case 0:
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opcion no valida");
                        break;


                }

            }

        }        

        public static void MostrarSubmenuReservasYCancelaciones()
        {
            bool salir = false;      

            while (!salir)
            {
                Console.WriteLine("* Reservas y Cancelaciones *");
                Console.WriteLine("");

                Console.WriteLine("1. Consultar habitaciones disponibles");
                Console.WriteLine("");
                Console.WriteLine("2. Realizar reserva");
                Console.WriteLine("");
                Console.WriteLine("3. Modificar reserva");
                Console.WriteLine("");                
                Console.WriteLine("4. Listar mis reservas activas");
                Console.WriteLine("");
                Console.WriteLine("5. Cancelar reserva");
                Console.WriteLine("");
                Console.WriteLine("0. Volver al menu principal");

                int opcion;

                bool success = int.TryParse(Console.ReadLine(), out opcion);
                while (success == false)
                {
                    Console.WriteLine("Por favor ingrese una opcion valida");
                    success = int.TryParse(Console.ReadLine(), out opcion);
                }

                switch (opcion)
                {
                    case 1: GestorHabitaciones.ListarHabitaciones(); 
                        break;

                    case 2:GestorReserva.RealizarReserva();                        
                        break;  

                    case 3: GestorReserva.ModificarReserva();
                        break;

                    case 4: GestorReserva.MostrarMisRerservasActivas(GestorUsuario.currentUser.Email);                        
                        break;

                    case 5: GestorReserva.CancelarReserva();
                        break;  

                    case 0: salir = true;
                        break;

                }

            }

        }

        public static void MostrarSubmenuGestionDePagos()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("* Gestion de Pagos *");
                Console.WriteLine("");

                Console.WriteLine("1. Realizar pago");
                Console.WriteLine("");                
                Console.WriteLine("0. Volver al menu principal");

                int opcion;

                bool success = int.TryParse(Console.ReadLine(), out opcion);
                while (success == false)
                {
                    Console.WriteLine("Por favor ingrese una opcion valida");
                    success = int.TryParse(Console.ReadLine(), out opcion);
                }

                switch (opcion)
                {
                    case 1:
                        GestorPagos.RealizarPago();
                        break;                    

                    case 0:
                        salir = true;
                        break;

                }

            }

        }

        public static void MostrarSubmenuEstadisticasYReportes()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("* Estadisticas y reportes *");
                Console.WriteLine("");

                Console.WriteLine("1. Listar huespedes/usuarios");
                Console.WriteLine("");
                Console.WriteLine("2. Listar habitaciones disponibles");
                Console.WriteLine("");
                Console.WriteLine("3. Historial de reservas por usuario");
                Console.WriteLine("");
                Console.WriteLine("4. Ranking habitaciones mas reservadas");
                Console.WriteLine("");
                Console.WriteLine("0. Volver al menu principal");

                int opcion;

                bool success = int.TryParse(Console.ReadLine(), out opcion);
                while (success == false)
                {
                    Console.WriteLine("Por favor ingrese una opcion valida");
                    success = int.TryParse(Console.ReadLine(), out opcion);
                }

                switch (opcion)
                {
                    case 1:
                        GestorReportes.ListarUsuarios();
                        break;

                    case 2:
                        GestorReportes.ListarHabitacionesDisponibles();
                        break;

                    case 3:
                        GestorReportes.HistorialReservas();
                        break;

                    case 4:
                        GestorReportes.RankingHabitaciones();
                        break;

                    case 0:
                        salir = true;
                        break;

                }

            }

        }   

        public static void LimpiarPantalla()
        {
            Console.WriteLine("");
            Console.WriteLine("Presiones una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
    }

}



    
       
