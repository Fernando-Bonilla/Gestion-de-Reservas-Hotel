using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class Pago
    {        
        private static int  IdPagoGenerator = 50321;
        DateTime fechaPago = DateTime.Today;

        #region Propiedades        
        public string FechaPago { get; private set; }
        public int Monto { get; set; }
        public string ?MetodoDePago { get; set; }

        public int IdPago { get; private set; }

        //IDReserva viene de la clase reserva
        public uint IdReserva {  get; set; }
        #endregion Propiedades

        #region Constructores
        public Pago(int monto, string metodoPago, uint idReserva)
        {
            IdPago = IdPagoGenerator++;
            FechaPago = GestorReserva.FormatoFecha( fechaPago);
            Monto = monto;
            IdReserva = idReserva;

        }
        #endregion Constructores

        #region Metodos    
        public override string ToString()
        {
            string mensaje = $"N° Pago: {IdPago}, N° Reserva.: {IdReserva}, Fech. de pago: {FechaPago}";
            return mensaje;
        }
        #endregion Metodos
    }
}
