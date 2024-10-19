using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_Reservas_Hotel
{
    internal class Habitacion
    {
        
        #region Propiedades
        public int NumHabitacion {  get; set; }
        public string ?TipoHabitacion { get; set; }
        public int CapacidadHabitacion { get; set; }        
        
        #endregion Propiedades

        #region Constructores
        public Habitacion(int numHabitacion, string tipoHabitacion, int capacidad)
        {
            NumHabitacion = numHabitacion;
            TipoHabitacion = tipoHabitacion;
            CapacidadHabitacion = capacidad;         
            
        }
        #endregion Constructores

        #region Metodos
        public override string ToString()
        {
            int tarifa = 0;
            if (GestorHabitaciones.tarifas.TryGetValue(TipoHabitacion, out tarifa))
            {
                
                
            } else
            {
                tarifa = 0;
            }
            
            return $"N° Hab.: {NumHabitacion}, Tipo Hab.: {TipoHabitacion}, Capacidad: {CapacidadHabitacion}, Tarifa: ${tarifa} por dia";
        }
        #endregion Metodos
    }
}
