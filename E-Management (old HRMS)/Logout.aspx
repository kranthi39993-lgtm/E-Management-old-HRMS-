<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Logout.aspx.vb" Inherits="E_Management.Logout" 
    title="Log Out" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<%
session.abandon()
%>
<script language="vbscript">
 window.open "http://mmsbsql1/emgmt/hrmis/login.aspx","_top"
</script>
</asp:Content>
