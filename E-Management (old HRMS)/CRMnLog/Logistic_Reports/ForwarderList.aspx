<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ForwarderList.aspx.vb" Inherits="E_Management.ForwarderList" Title="Forwarder List" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ForwarderList</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
            &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/home1.png" /><br />
            <hr />
            Forwarder Type:&nbsp;
            <asp:DropDownList ID="CmbForwarderType" runat="server" Width="250px">
            </asp:DropDownList>&nbsp;
            <asp:Button ID="Button1" runat="server" Text="View" />&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Print" Visible="False" />&nbsp;
            <asp:Button ID="Button3" runat="server" Text="Export" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            
            <hr />
            <br />
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
                ToolbarImagesFolderUrl="../../images/" Height="1080px" ReportSourceID="CrystalReportSource1" Width="751px" DisplayGroupTree="False" DisplayToolbar="False" SeparatePages="False" />
            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                <Report FileName="D:\E-Management\CRMnLog\Logistic_Reports\forwarderslistrpt.rpt">
                </Report>
            </CR:CrystalReportSource>
            &nbsp;
		</form>
	</body>
</HTML>
