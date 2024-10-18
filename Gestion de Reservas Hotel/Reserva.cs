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
        public string FechaReserva { get; private set; }
        #endregion Propiedades

        #region Constructores
        public Reserva(int nroHabitacion, DateTime fechaCheckIn, DateTime fechaCheckOut)
        {
            IDReserva = idReservaGenerator++;
            NroHabitacion = nroHabitacion;
            FechaCheckIn = fechaCheckIn;
            FechaCheckOut = fechaCheckOut;
            FechaReserva = GestorReserva.FormatoFecha(date);

        }
        #endregion Constructores
    }


}
