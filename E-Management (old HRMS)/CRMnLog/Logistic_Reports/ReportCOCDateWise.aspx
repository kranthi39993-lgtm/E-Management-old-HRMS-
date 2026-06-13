<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportCOCDateWise.aspx.vb" Inherits="E_Management.ReportCOCDateWise" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>COC Datewise</title>
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
        <br />
        <table width="60%">
            <tr>
                <td style="width: 100px; height: 22px; text-align: left;">
                    <asp:Label ID="Label1" runat="server" Text="Custom Form Report:    From " Width="172px"></asp:Label>
                    <asp:TextBox ID="TxtFrom" runat="server" Width="80px"></asp:TextBox><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/calender.png" /></td>
                <td style="width: 100px; height: 22px;">
                    <asp:Label ID="Label2" runat="server" Text="To" Width="24px"></asp:Label>
                    <asp:TextBox ID="TxtTo" runat="server" Width="80px"></asp:TextBox><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/calender.png" /></td>
                <td style="width: 100px; height: 22px; text-align: left;">
                    <asp:Button ID="Button1" runat="server" Text="View" Width="60px" /><asp:Button
                        ID="Button2" runat="server" Text="Export" Width="60px" /></td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="3">
                    <asp:Label ID="Label3" runat="server" Width="587px"></asp:Label><br />
                    <asp:Label ID="Label4" runat="server" Width="579px"></asp:Label></td>
            </tr>
        </table>
        <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
            BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
            ForeColor="#663399" Height="53px" ShowGridLines="True" Style="z-index: 100; left: 197px;
            position: absolute; top: 82px" Visible="False" Width="95px">
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
        </asp:Calendar>
        <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
            BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
            ForeColor="#663399" Height="22px" ShowGridLines="True" Style="z-index: 102; left: 335px;
            position: absolute; top: 80px" Visible="False" Width="53px">
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
        </asp:Calendar>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
            DisplayGroupTree="False" DisplayToolbar="False" Height="2155px" SeparatePages="False" Width="751px" ReportSourceID="CrystalReportSource1" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="D:\E-Management\CRMnLog\Logistic_Reports\Report_COCDateWise.rpt">
            </Report>
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>
