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
        public static List<Pago> pagos = new List<Pago>();        

        #region Metodos
        public static void RealizarPago()
        {
            Console.WriteLine("Ingrese el N° de reserva");
            uint numReserva = 0;
            string metodoPago = "";
            int costoTotal = 0; 

            bool successNumReserva = uint.TryParse(Console.ReadLine(), out numReserva);
            while (!successNumReserva)
            {
                Console.WriteLine("Formato incorrecto, debe ingresar un registro numerico de al menos 5 digitos");
                successNumReserva = uint.TryParse(Console.ReadLine(), out numReserva);
            }

            // Chequeo que N° reserva exista
            bool numReservaExiste = GestorReserva.reservas.Any(reserva => reserva.IDReserva == numReserva); //Uso el metodo Linq Any, para check si existen reservas con el codigo proporcionado

            if (!numReservaExiste)
            {
                Console.WriteLine("No existen reservas con el codigo proporcionado");
                return;
            }

            // Chequeo que la reserva esté a nombre del usuario que desea pagar y que no este ya paga
            foreach (Reserva reserva in GestorReserva.reservas)
            {
                if (numReserva == reserva.IDReserva && reserva.EmailUsuario != GestorUsuario.currentUser.Email)
                {                    

                    Console.WriteLine("No se encontraron reservas a su nombre con el codigo proporcionado");
                    return;
                }
                else if (numReserva == reserva.IDReserva && reserva.EstadoReserva == "Paga")
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

            Console.WriteLine($"Usted ha elegido el metodo de pago: {metodoPago}");

            //Busco el costo total de la estadia con el metodo que lo calcula
            costoTotal = GestorReserva.CalcularCostoReserva(numReserva);

            Console.WriteLine("");
            Console.WriteLine($"N° Reserva: {numReserva}, Total: ${costoTotal}");

            //Pregunto si desea confirmar elpago
            Console.WriteLine("");
            Console.WriteLine("Desea confirmar el pago? Ingrese Y para si, o N para salir");
            string? confirmaPago = Console.ReadLine();

            //Chequeo que la opcion ingresada sea si o no
            while (confirmaPago != "y" && confirmaPago != "n" || (string.IsNullOrEmpty(confirmaPago)) == true)
            {
                Console.WriteLine("Debe ingresar una opcion valida");
                confirmaPago = Console.ReadLine();
            }
            
            //Si confirma el pago ejecuto el sistema de pago
            if (confirmaPago == "y")
            {
                Console.WriteLine($"La reserva N°: {numReserva} ha sido pagada exitosamente");
                Pago pago = new(costoTotal, metodoPago, numReserva);                
                GestorPagos.pagos.Add(pago);
                PdfCreator.CreatePdfPago($"PagoConfirmado_{DateTime.Now:yyyyMMddHHmmss}.pdf", pago);

                //Recorro la lista de reservas y busco la que coincida para cambiarle el estado a Pago
                foreach (Reserva reserva in GestorReserva.reservas) 
                {
                    if (reserva.IDReserva == numReserva)
                    {
                        reserva.EstadoReserva = "Pago";
                    }
                }                

            }else
            {
                return;
            }

            Menu.LimpiarPantalla();

        }
        #endregion Metodos
    }
}
