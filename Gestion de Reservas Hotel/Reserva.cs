using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    
    internal class Reserva
    {
        public static uint idReservaGenerator = 10250;
        DateTime date = DateTime.Today;        

        #region Propiedades
        public uint IDReserva { get; private set; }
        public int NroHabitacion { get; set; }
        public DateTime FechaCheckIn { get; set; }
        public DateTime FechaCheckOut { get; set; }
        public string ?FechaReserva { get; private set; }
        public int IDUsuario { get; private set; }
        public string ?EmailUsuario { get; private set; }

        public string ?EstadoReserva {  get; set; }
        #endregion Propiedades

        #region Constructores
        public Reserva(int nroHabitacion, DateTime fechaCheckIn, DateTime fechaCheckOut, int IdUsuario, string emailUsuario, string estadoReserva)
        {
            IDReserva = idReservaGenerator++;
            NroHabitacion = nroHabitacion;
            FechaCheckIn = fechaCheckIn;
            FechaCheckOut = fechaCheckOut;
            FechaReserva = GestorReserva.FormatoFecha(date);
            IDUsuario = IdUsuario;
            EmailUsuario = emailUsuario;
            EstadoReserva = estadoReserva;


        }
        public Reserva()
        {
            
        }
        #endregion Constructores

        #region Metodos
        public override string ToString()
        {
            string mensaje = $"N° Reserva: {IDReserva}, N° Hab.: {NroHabitacion}, Fech. Check-in: {GestorReserva.FormatoFecha(FechaCheckIn)}, Fech. Check-Out: {GestorReserva.FormatoFecha(FechaCheckOut)}, Fecha reserva: {FechaReserva}, Estado: {EstadoReserva}";
            return mensaje;
        }
        #endregion Metodos
    }


}
