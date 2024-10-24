using Gestion_de_Reservas_Hotel;
QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

PrecargaDatos.PrecargarDatos();

DateTime date = DateTime.Today;
date.ToShortDateString();

Console.WriteLine(date.ToShortDateString());
Menu.MostrarMenu();