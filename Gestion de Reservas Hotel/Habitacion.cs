using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class Habitacion
    {
        public static List<Habitacion> habitacions = new List<Habitacion>();

        #region Propiedades
        public int NumHabitacion {  get; set; }
        public string ?TipoHabitacion { get; set; }
        public int CapacidadHabitacion { get; set; }
        public int PrecioDiario { get; set; }
        public string Estado {  get; set; } // Aca debo chequear en reservas y sacar el estado de ahi
        #endregion Propiedades

        #region Constructores
        public Habitacion(int numHabitacion, string tipoHabitacion, int capacidad, int precioDiario, string estado)
        {
            NumHabitacion = numHabitacion;
            TipoHabitacion = tipoHabitacion;
            CapacidadHabitacion = capacidad;
            PrecioDiario = precioDiario;
            Estado = estado;
        }
        #endregion Constructores

        #region Metodos
        public static void ListarHabitaciones()
        {
            foreach (Habitacion habitacion in habitacions) 
            {
                Console.WriteLine($"N° Hab.: {habitacion.NumHabitacion}, Tipo Hab.: {habitacion.TipoHabitacion}, Capacidad: {habitacion.CapacidadHabitacion}, Precio: {habitacion.PrecioDiario}, Estado: {habitacion.Estado}");
            }
        }

        public static void ListaDeFechasReservadas()
        {

        }
        #endregion Metodos
    }
}
