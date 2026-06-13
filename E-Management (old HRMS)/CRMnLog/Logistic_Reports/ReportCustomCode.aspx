<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportCustomCode.aspx.vb" Inherits="E_Management.ReportCustomCode" Title="Custom Code"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Custom Code</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/home1.png" /><br />
        <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="True" ToolbarImagesFolderUrl="../../images/" DisplayGroupTree="False" DisplayToolbar="False" Height="1080px" SeparatePages="False" Width="751px" ReportSourceID="CrystalReportSource1"></cr:crystalreportviewer>
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="D:\E-Management\CRMnLog\Logistic_Reports\Report_CustomCode.rpt">
            </Report>
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>
