using Gestion_de_Reservas_Hotel;

PrecargaDatos.PrecargarDatos();

DateTime date = DateTime.Today;
date.ToShortDateString();

Console.WriteLine(date.ToShortDateString());
Menu.MostrarMenu();