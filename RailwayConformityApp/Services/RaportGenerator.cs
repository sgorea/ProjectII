using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SelectPdf;
using RailwayConformityApp.Models;
using System.Windows.Forms;

namespace RailwayConformityApp.Services
{
    public class ReportGenerator
    {
        public void GeneratePdfReport(TrackElement element, List<Measurement> measurements)
        {
            // 1. Construim șablonul HTML cu stiluri CSS moderne
            StringBuilder sb = new StringBuilder();
            sb.Append("<html><head><style>");
            sb.Append("body { font-family: 'Segoe UI', Arial; margin: 30px; color: #333; }");
            sb.Append(".header { text-align: center; border-bottom: 2px solid #2c3e50; padding-bottom: 15px; }");
            sb.Append(".info { margin-top: 20px; padding: 10px; background: #f8f9fa; border-radius: 5px; }");
            sb.Append("table { width: 100%; border-collapse: collapse; margin-top: 25px; }");
            sb.Append("th { background-color: #2c3e50; color: white; padding: 12px; }");
            sb.Append("td { padding: 10px; border-bottom: 1px solid #ddd; text-align: center; }");
            sb.Append(".pass { color: #27ae60; font-weight: bold; }");
            sb.Append(".fail { color: #e74c3c; font-weight: bold; }");
            sb.Append("</style></head><body>");

            // Antet
            sb.Append("<div class='header'><h1>Raport Tehnic de Conformitate Cale</h1>");
            sb.Append($"<p>Data emiterii: {DateTime.Now:dd.MM.yyyy HH:mm}</p></div>");

            // Detalii Element
            sb.Append("<div class='info'>");
            sb.Append($"<p><b>Element:</b> {element.Name} | <b>Locație:</b> {element.LineSection} (km {element.Position})</p>");
            sb.Append($"<p><b>Inspector:</b> {Session.CurrentUser.Username} ({Session.CurrentUser.Role})</p>");
            sb.Append("</div>");

            // Tabel Date
            sb.Append("<table><thead><tr>");
            sb.Append("<th>Data</th><th>Ecartament (mm)</th><th>Nivel (mm)</th><th>Săgeată (mm)</th><th>Status</th>");
            sb.Append("</tr></thead><tbody>");

            foreach (var m in measurements)
            {
                // Verificare tehnică bazată pe toleranțele discutate
                bool isGaugeOk = m.Gauge >= 1432 && m.Gauge <= 1448;
                bool isLevelOk = Math.Abs(m.Level) <= 3;
                bool isArrowOk = Math.Abs(m.Arrow) <= 4;

                bool isOk = isGaugeOk && isLevelOk && isArrowOk;
                string statusText = isOk ? "<span class='pass'>ADMIS</span>" : "<span class='fail'>RESPINS</span>";

                sb.Append("<tr>");
                sb.Append($"<td>{m.MeasuredAt:dd.MM.yyyy}</td>");
                sb.Append($"<td>{m.Gauge}</td><td>{m.Level}</td><td>{m.Arrow}</td><td>{statusText}</td>");
                sb.Append("</tr>");
            }

            sb.Append("</tbody></table></body></html>");

            // 2. Conversia HTML -> PDF
            HtmlToPdf converter = new HtmlToPdf();
            converter.Options.PdfPageSize = PdfPageSize.A4;

            PdfDocument doc = converter.ConvertHtmlString(sb.ToString());

            // 3. Salvare pe Desktop
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Raport_{element.Name}.pdf");
            doc.Save(path);
            doc.Close();

            MessageBox.Show($"Raportul PDF a fost generat pe Desktop!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}