using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public static void RealizarReserva()
        {      

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
                    Console.WriteLine("La reserva no puede ser mayor a 30 dias seguidos, Por favor ingrese una fecha de Check-Out correcta:");   
                    
                }                
                else 
                {
                    Console.WriteLine("La fecha de Check-Out debe ser posterior a la fecha de Check-In. Inténtelo de nuevo:");
                }
                success = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaCheckOut); //el metodo TryParseExact obliga al usuario a que ingrese formato "dd/MM/yyyy", y luego dos paramentros 1- IFormatProvider = null, para la cultura, y 2- DateTimeStyles = None, controla cómo se deben interpretar las fechas (si se permiten espacios en blanco)
                duracionReserva = (fechaCheckOut - fechaCheckIn).TotalDays;
            }

            //Console.WriteLine(GestorHabitaciones.CheckStatusHabitacion(numHabitacion, fechaCheckIn, fechaCheckOut) + "Aca antes del if");
            if (GestorHabitaciones.CheckStatusHabitacion(numHabitacion, fechaCheckIn, fechaCheckOut) == "Disponible")
            {                
                Reserva reserva = new Reserva(numHabitacion, fechaCheckIn, fechaCheckOut, GestorUsuario.currentUser.Id, GestorUsuario.currentUser.Email, "Impaga");
                GestorReserva.reservas.Add(reserva);

                string mensajeResCreada = $"Reserva Creada: Cod.Reserva: {reserva.IDReserva}, N° Hab.: {reserva.NroHabitacion}, Fecha Check-In: {FormatoFecha(reserva.FechaCheckIn)}, " +
                    $"Fecha Check-Out: {FormatoFecha(reserva.FechaCheckOut)}";

                Console.WriteLine(mensajeResCreada);               
                
                
                //return mensajeResCreada; //Ver como resolver esto, estoy mostrando el mensaje arriba con el Console.WriteLine() y despues uso el return
            }
            else
            {                
                string mensajeFailReserva = "La habitacion no se encuentra disponible para ese rango de fechas";
                Console.WriteLine(mensajeFailReserva);

                

                //return mensajeFailReserva; //Ver como resolver esto, estoy mostrando el mensaje arriba con el Console.WriteLine() y despues uso el return
            }

            Menu.LimpiarPantalla();

        }

        public static void MostrarMisRerservasActivas(string email)
        {
            DateTime today = new DateTime();
            foreach(Reserva reserva in reservas)
            {
                if(reserva.EmailUsuario == email && reserva.FechaCheckIn > today)
                {                    
                    
                    //llamo al metodo que me calcula el costo de la reserva 
                    int costoEstadia = CalcularCostoReserva(reserva.IDReserva);

                    //Console.WriteLine($"N° Reserva: {reserva.IDReserva}, N° Hab.: {reserva.NroHabitacion}, Fech. Check-in: {GestorReserva.FormatoFecha(reserva.FechaCheckIn)}, Fech. Check-Out: {GestorReserva.FormatoFecha(reserva.FechaCheckOut)}, Fecha reserva: {reserva.FechaReserva}, Total: ${costoEstadia}, Estado: {reserva.EstadoReserva}");
                    Console.WriteLine(reserva.ToString() + $", Costo total: ${costoEstadia}, {reserva.EmailUsuario}");
                }
            }

            Menu.LimpiarPantalla();
        }        

        public static void ModificarReserva()
        {
            //Ingreso de N° reserva y chequeo que sea formato correcto
            Console.WriteLine("Ingrese el N° de reserva");
            int numReserva = 0;            

            bool successNumReserva = int.TryParse(Console.ReadLine(), out numReserva);
            while (!successNumReserva) 
            {
                Console.WriteLine("Formato incorrecto, debe ingresar un registro numerico de al menos 5 digitos");
                successNumReserva = int.TryParse(Console.ReadLine(), out numReserva);
            }

            // Chequeo que N° reserva exista
            bool numReservaExiste = reservas.Any(reserva => reserva.IDReserva == numReserva); //Uso el metodo Linq Any, para check si existen reservas con el codigo proporcionado
            

            if (!numReservaExiste) 
            {
                Console.WriteLine("No existen reservas con el codigo proporcionado");
                return;
            }

            // Si la reserva esta paga no se puede modificar, solo cancelar
            foreach (Reserva reserva in reservas)
            {
                if (numReserva == reserva.IDReserva && reserva.EstadoReserva == "Paga")
                {
                    Console.WriteLine("No se pueden modificar Reservas ya abonadas");
                    return;
                }
            }

            //Si N° reserva existe procede a pedir las nuevas fechas
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

            //Pregunto si desea modificar tambien la habitacion
            Console.WriteLine("Desea cambiar de Habitacion? Ingrese Y para cambiar, o N para continuar");
            string ?cambioHab = Console.ReadLine();

            //Chequeo que la opcion ingresada sea si o no
            while(cambioHab != "y" && cambioHab != "n" || (string.IsNullOrEmpty(cambioHab)) == true)
            {
                Console.WriteLine("Debe ingresar una opcion valida");
                cambioHab = Console.ReadLine();
            }

            Reserva ?reservaActual = reservas.FirstOrDefault(reserva => reserva.IDReserva == numReserva); //busco la reserva actual para saber el numero de habitacion de esa reserva
            int numHabitacion = reservaActual.NroHabitacion;
            //int nuevoNumHabitacion = numHabitacion;
            if (cambioHab == "y")
            {                
                Console.WriteLine("Ingrese el nuevo N° hab.: ");
                
                bool successNumHab = int.TryParse(Console.ReadLine(), out numHabitacion);
                while (!successNumHab)
                {
                    Console.WriteLine("Por favor ingrese un N° de hab. valido");
                    successNumHab = int.TryParse(Console.ReadLine(), out numHabitacion);
                }
            }
            
            int nuevoNumHabitacion = numHabitacion;

            //Si desea cambiar chequeo que la unidad exista y este disponible en ese rango de fecha, ya sea que decida cambiar de hab o no
            if ((cambioHab == "y" || cambioHab == "n") && GestorHabitaciones.NumHabitacionExiste(nuevoNumHabitacion) == true &&
                GestorHabitaciones.CheckStatusHabitacion(nuevoNumHabitacion, fechaCheckIn, fechaCheckOut) == "Disponible")                
            {
                //Console.WriteLine("fech CI" + fechaCheckIn);
                //Busco la reserva en la lista reservas y la modifico
                foreach (Reserva reserva in reservas)
                {
                    if (reserva.IDReserva == numReserva)                        
                    {
                        reserva.NroHabitacion = nuevoNumHabitacion;
                        reserva.FechaCheckIn = fechaCheckIn;
                        reserva.FechaCheckOut = fechaCheckOut;

                        Console.WriteLine($"Reserva {reserva.IDReserva} correctamente modificada \n" +
                            $"N° Hab: {reserva.NroHabitacion}, Fech. Check-In: {FormatoFecha(reserva.FechaCheckIn)}, Fech. Check-Out: {FormatoFecha(reserva.FechaCheckOut)}");
                    }
                }
            
            }else
            {
                Console.WriteLine("Habitacion no disponible en ese rango de fechas");
            }

            Menu.LimpiarPantalla();

        }

        public static int CalcularCostoReserva(uint numeroReserva) //Este metodo calcula el costo de la estadia, pero no toma en cuenta el ultimo dia ya que el checkOut es en la mañana y no se cobra
        {
            int costoTotal = 0;
            string tipoHabitacion = "";
            int duracionEstadia = 0;

            foreach (Reserva reserva in reservas)
            {
                if(reserva.IDReserva == numeroReserva)
                {
                    // Calculo la duracion de la estadia
                    duracionEstadia = (int)(reserva.FechaCheckOut - reserva.FechaCheckIn).TotalDays;

                    //Consigo que tipo de habitacion es la reserva
                    foreach (Habitacion habitacion in GestorHabitaciones.habitaciones)
                    {
                        if (habitacion.NumHabitacion == reserva.NroHabitacion && reserva.IDReserva == numeroReserva)
                        {
                            tipoHabitacion = habitacion.TipoHabitacion;
                        }
                    }
                }
                

            }            

            foreach (KeyValuePair <string, int> tarifa in GestorHabitaciones.tarifas)
            {
                if (tipoHabitacion == tarifa.Key)
                {
                    costoTotal = tarifa.Value * duracionEstadia;
                }
                
            }
            return costoTotal;
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
                    else
                    {
                        Console.WriteLine("Las reservas solo pueden ser canceladas 24 hs previas a la fecha de Check-in");
                        counter++;
                        break;
                    }

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

            Menu.LimpiarPantalla();

        }
        #endregion Metodos
    }
}
