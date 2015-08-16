using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSMWeb
{
    public partial class PrintBarcodes : System.Web.UI.Page
    {
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

        }


    }
}