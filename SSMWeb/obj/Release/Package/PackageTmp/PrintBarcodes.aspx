<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintBarcodes.aspx.cs" Inherits="SSMWeb.PrintBarcodes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 465px; width: 923px">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="427px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="916px" SizeToReportContent="False">
            <LocalReport ReportPath="Report\BarcodeReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="BarcodeDataSetl" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SSMConnectionStringForReport %>" ></asp:SqlDataSource>

    </div>

    </form>

</body>
</html>
