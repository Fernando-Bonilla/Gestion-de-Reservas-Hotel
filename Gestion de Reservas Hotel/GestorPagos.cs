using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class GestorPagos
    {
        //Lista con los pagos realizados
        public List<Pago> pagos = new List<Pago>();        

        #region Metodos
        public static void RealizarPago()
        {
            Console.WriteLine("Ingrese el N° de reserva");
            int numReserva = 0;

            string metodoPago = "";

            bool successNumReserva = int.TryParse(Console.ReadLine(), out numReserva);
            while (!successNumReserva)
            {
                Console.WriteLine("Formato incorrecto, debe ingresar un registro numerico de al menos 5 digitos");
                successNumReserva = int.TryParse(Console.ReadLine(), out numReserva);
            }

            // Chequeo que N° reserva exista
            bool numReservaExiste = GestorReserva.reservas.Any(reserva => reserva.IDReserva == numReserva); //Uso el metodo Linq Any, para check si existen reservas con el codigo proporcionado

            if (!numReservaExiste)
            {
                Console.WriteLine("No existen reservas con el codigo proporcionado");
                return;
            }

            // Chequeo que la reserva no este ya paga
            foreach (Reserva reserva in GestorReserva.reservas)
            {
                if (numReserva == reserva.IDReserva && reserva.EstadoReserva == "Paga")
                {
                    Console.WriteLine("La reserva ya esta paga");
                    return;
                }
            };


            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("* Elija un Metodo de pago *");
                Console.WriteLine("");

                Console.WriteLine("1. Tarjeta credito");
                Console.WriteLine("");
                Console.WriteLine("2. Transferencia bancaria");

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
                        metodoPago = "Tarjeta credito";
                        salir = true;
                        break;

                    case 2:
                        metodoPago = "Transferencia bancaria";
                        salir = true;
                        break;

                }

            }

            Console.WriteLine($"Usted a elegido el metodo de pago: {metodoPago}");
            return;

        }
        #endregion Metodos
    }
}
