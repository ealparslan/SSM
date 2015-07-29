

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Barcode.aspx.cs" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<script runat="server">

    protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 465px; width: 923px">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="427px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="916px">
            <LocalReport ReportPath="Report\BarcodeReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="BarcodesDS" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SSMConnectionStringForReport %>" SelectCommand="SELECT p.SKU, b.BoxUnitOfTotal, b.BoxTotalOfTotal, b.BarcodeId, b.BarcodeImage, b.PartCapOfBox, b.PartQtyUnitID, b.PartQtyLeft, s.ContainerName, d.Date FROM Boxes AS b INNER JOIN DeliveryLists AS dl ON b.DeliveryListId = dl.Id INNER JOIN Deliveries AS d ON dl.DeliveryId = d.Id INNER JOIN Shipments AS s ON d.ShipmentId = s.Id INNER JOIN Products AS p ON b.ProductId = p.Id"></asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
