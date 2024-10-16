using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class Pago
    {
        public static List<Pago> pagos = new List<Pago>();
        private static int  IdPagoGenerator = 10250;

        #region Propiedades        
        public DateOnly FechaPago { get; set; }
        public int Monto { get; set; }
        public string ?MetodoDePago { get; set; }

        public int IdPago { get; private set; }

        //IDReserva viene de la clase reserva
        public int IdReserva {  get; set; }
        #endregion Propiedades

        #region Constructores
        public Pago(DateOnly fechaPago, int monto, string metodoPago, int idReserva)
        {
            IdPago = IdPagoGenerator++;
            FechaPago = fechaPago;
            Monto = monto;
            IdReserva = idReserva;

        }
        #endregion Constructores

        #region Metodos
        public void CancelarPago()
        {

        }

        public void GenerarComprobantePago() // Por ahora lo pongo Void, pero ver despues que devuelve si genera un recibo en formato pdf
        {

        }
        #endregion Metodos
    }
}
