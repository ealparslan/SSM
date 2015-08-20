using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace SSMWeb
{
    public partial class PrintBarcodes : System.Web.UI.Page
    {

        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        protected void Page_Load(object sender, EventArgs e)
        {
            String entity = Request.QueryString["entity"];
            String id = Request.QueryString["id"];
            String command = "SELECT p.SKU, b.BoxUnitOfTotal, b.BoxTotalOfTotal, b.BarcodeId, b.BarcodeImage, b.PartCapOfBox, b.PartQtyUnitID, b.PartQtyLeft, s.ContainerName, d.Date FROM Boxes AS b"
                + " INNER JOIN DeliveryLists AS dl ON b.DeliveryListId = dl.Id INNER JOIN Deliveries AS d ON dl.DeliveryId = d.Id INNER JOIN Shipments AS s ON d.ShipmentId = s.Id INNER JOIN Products AS p ON b.ProductId = p.Id";

            if (entity.Equals("Deliveries"))
                command = command + " WHERE d.Id = " + id;
            else if (entity.Equals("DeliveryLists"))
                command = command + " WHERE dl.Id = " + id;

            command = command + " order by b.DeliveryListId, b.BoxUnitOfTotal;";
            SqlDataSource1.SelectCommand = command;
            SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            SqlDataSource1.DataBind();

            ReportViewer1.ShowPrintButton = true;

            



        }

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            //Stream stream = new FileStream(HttpContext.Current.Server.MapPath(".") + "/" + name + "." + fileNameExtension, FileMode.Create);
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }


        private void Export(LocalReport report)
        {
            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>4in</PageWidth>" +
              "  <PageHeight>6in</PageHeight>" +
              "  <MarginTop>0.1in</MarginTop>" +
              "  <MarginLeft>0.1in</MarginLeft>" +
              "  <MarginRight>0.1in</MarginRight>" +
              "  <MarginBottom>0.1in</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            const string printerName =
               "Microsoft Print To PDF";
            if (m_streams == null || m_streams.Count == 0)
                return;
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format(
                   "Can't find printer \"{0}\".", printerName);
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Export(ReportViewer1.LocalReport);
            m_currentPageIndex = 0;
            Print();
        }
    }
}