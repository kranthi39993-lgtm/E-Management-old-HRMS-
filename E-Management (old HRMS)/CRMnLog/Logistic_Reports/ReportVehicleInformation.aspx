<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportVehicleInformation.aspx.vb" Inherits="E_Management.ReportVehicleInformation" Title="Vehicle Information" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Vehicle Information</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/home1.png" /><br />
        <hr />
        Vehicle Type &nbsp; &nbsp; &nbsp;:&nbsp;
        <asp:DropDownList ID="CmbVehicleType" runat="server" Width="180px">
        </asp:DropDownList>&nbsp;
        <asp:Button ID="Button1" runat="server" Text="View" />&nbsp;<asp:Button ID="Button2"
            runat="server" Text="Print" Visible="False" />&nbsp;<asp:Button ID="Button9" runat="server" Text="Export" />
        <asp:Label ID="Label3" runat="server"></asp:Label><br />
        &nbsp;<br />
        Transport Name :&nbsp;
        <asp:DropDownList ID="CmbTName" runat="server" Width="180px">
        </asp:DropDownList>&nbsp;
        <asp:Button ID="Button3" runat="server" Text="View" />&nbsp;<asp:Button ID="Button4"
            runat="server" Text="Print" Visible="False" />&nbsp;<asp:Button ID="Button8" runat="server" Text="Export" />
        <asp:Label ID="Label2" runat="server"></asp:Label><br />
        <br />
        Arrival Place &nbsp; &nbsp;&nbsp; &nbsp;:&nbsp;<asp:DropDownList ID="CmbAPlace" runat="server"
            Width="180px">
        </asp:DropDownList>
        &nbsp;<asp:Button ID="Button5" runat="server" Text="View" />&nbsp;<asp:Button ID="Button6"
            runat="server" Text="Print" Visible="False" />&nbsp;<asp:Button ID="Button7" runat="server" Text="Export" />
        <asp:Label ID="Label1" runat="server"></asp:Label><br />
        <hr />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" ToolbarImagesFolderUrl="../../images/" DisplayGroupTree="False" DisplayToolbar="False" Height="1080px" SeparatePages="False" Width="751px" ReportSourceID="CrystalReportSource1" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="D:\E-Management\CRMnLog\Logistic_Reports\Report_VehicleInformation.rpt">
            </Report>
        </CR:CrystalReportSource>
        </div>
    </form>
</body>
</html>
