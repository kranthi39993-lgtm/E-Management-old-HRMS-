<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Abnormalityrpt.aspx.vb" Inherits="E_Management.Abnormalityrpt" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Abnormality Reports</title>
</head>
<body>
    <form id="form1" runat="server">
    &nbsp;<strong><span style="font-size: 11pt; font-family: Calibri">Report From : </span>
        </strong>
        <asp:Label ID="fromdate" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="11pt"
            Width="76px"></asp:Label>
        <strong><span style="font-size: 11pt; font-family: Calibri">to</span></strong>&nbsp;<asp:Label ID="Todate" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="11pt"
            Width="82px"></asp:Label><br />
        &nbsp;
        <div>
        &nbsp;<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
        DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
        Height="815px" ReportSourceID="CrystalReportSource1" Width="1022px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="AbnormalityRpttbymcno.rpt">
        </Report>
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
