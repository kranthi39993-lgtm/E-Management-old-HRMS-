<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="RptRolesRightsFrm.aspx.vb" Inherits="E_Management.RptRolesRightsFrm" 
    title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" ToolbarImagesFolderUrl="../images/toolbar/" GroupTreeImagesFolderUrl="../images/tree/" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" Height="1115px" ReportSourceID="CrystalReportSource1" Width="886px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="G:\E-Management\Access\RptRolesRights.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>
