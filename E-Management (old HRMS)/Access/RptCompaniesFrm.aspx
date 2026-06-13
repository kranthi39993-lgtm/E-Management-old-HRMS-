<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="RptCompaniesFrm.aspx.vb" Inherits="E_Management.RptCompaniesFrm" 
    title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" Height="1115px" ReportSourceID="CrystalReportSource1" Width="760px" ToolbarImagesFolderUrl="../images/toolbar/" GroupTreeImagesFolderUrl="../images/tree/" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="G:\E-Management\Access\RptCompanies.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>
