using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.IO;


namespace Gestion_de_Reservas_Hotel
{
    
    internal class PdfCreator
    {

        public static void CreatePdfReserva(string fileName, Reserva reserva)
        {
            // Obtener la ruta del escritorio del usuario actual
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Construir la ruta completa donde se guardará el PDF
            string fullPath = System.IO.Path.Combine(desktopPath, fileName);

            // Generar el documento PDF
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Header().Text("Hotel Estrella de Mar").Bold().FontSize(20);   
                    page.Margin(2, Unit.Centimetre);

                    page.Content()

                    .Column(column =>
                    {
                        column.Item().Text($"Reserva creado exitosamente");
                        column.Item().Text($"Detalles de la Reserva: {reserva.ToString()}");
                        // Agregar más detalles de la reserva si es necesario
                    });
                });
            });

            // Guardar el PDF en la ruta especificada
            document.GeneratePdf(fullPath);
            Console.WriteLine($"PDF creado exitosamente y guardado en: {fullPath}");

            // Abrir el archivo PDF automáticamente
            Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
        }

        public static void CreatePdfPago(string fileName, Pago pago)
        {
            // Obtener la ruta del escritorio del usuario actual
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Construir la ruta completa donde se guardará el PDF
            string fullPath = System.IO.Path.Combine(desktopPath, fileName);

            // Generar el documento PDF
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Header().Text("Hotel Estrella de Mar").Bold().FontSize(20);
                    page.Margin(2, Unit.Centimetre);

                    page.Content()

                    .Column(column =>
                    {
                        column.Item().Text($"Pago realizado exitosamente");
                        column.Item().Text($"Detalles del pago: {pago.ToString()}");
                        
                    });
                });
            });

            // Guardar el PDF en la ruta especificada
            document.GeneratePdf(fullPath);
            Console.WriteLine($"PDF creado exitosamente y guardado en: {fullPath}");

            // Abrir el archivo PDF automáticamente
            Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
        }
    }
}
