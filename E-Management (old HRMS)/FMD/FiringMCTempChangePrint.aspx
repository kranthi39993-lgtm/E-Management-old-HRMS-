<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FiringMCTempChangePrint.aspx.vb" Inherits="E_Management.FiringMCTempChangePrint"MasterPageFile="~/ems.Master"  Title="Temperature Change"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	

<table  cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../images/top_lef.gif" width="16" alt="" /></td>
            <td background="../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../images/top_mid.gif" width="16" alt="" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../images/top_rig.gif" width="24" alt="" /></td>
        </tr>
        <tr>
            <td background="../images/cen_lef.gif"  width="16" style="height: 438px">
                <img height="11" src="../images/cen_lef.gif" width="16" alt="" /></td>
            <td bgcolor="#ffffff" valign="top" style="height: 438px">
                <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px">
                            <asp:Panel ID="Panel1" runat="server">




<table>
    <tr>
        <td colspan="2" style="background-color: #336699;">
            <asp:Label ID="Label2" runat="server" Text="Print Approved Temperature Request Form" Font-Bold="True" ForeColor="White" Width="350px"></asp:Label></td>
    </tr>
    <tr>
<td style="background-color: beige; text-align: left">
    <asp:Label ID="Label1" runat="server" Text="Department"></asp:Label></td><td style="text-align: left">
        <asp:DropDownList ID="dept_ddl" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
            DataSourceID="SqlDataSource1" DataTextField="dept" DataValueField="departmentcode"
            Width="174px">
            <asp:ListItem Value="-1">---Select---</asp:ListItem>
        </asp:DropDownList></td>
</tr>
    <tr>
        <td style="text-align: left" >
    </td>
        <td style="text-align: left">
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"  
                BorderWidth="1px" CellPadding="15" CellSpacing="2" ForeColor="Black" GridLines="None" AutoGenerateColumns=false  OnSelectedIndexChanged="Fun1" >
                 
                <FooterStyle BackColor="Tan" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                 <asp:BoundField DataField="BatchNo" HeaderText="BatchNo" />
                  <asp:BoundField DataField="MachineNo" HeaderText="MachineNo" />
                   <asp:BoundField DataField="SMSMessage" HeaderText="Temperature_Change_Details_Print"  />
                   
                 <asp:CommandField SelectText="Print" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td colspan="2" >
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td >
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                SelectCommand="SELECT ( [departmentcode] +'-'+ [departmentname]) as dept ,departmentcode FROM [department]  where office = 'P' ORDER BY [departmentcode], [departmentname]">
            </asp:SqlDataSource>
        </td>
    </tr>
</table>






         
	</asp:Panel>
                            &nbsp;
                        </td>
                    </tr>
                </table>
</td>                
  <td background="../images/cen_rig.gif" style="width: 24px; height: 438px;">
                <img height="11" src="../images/cen_rig.gif" width="24" alt="" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../images/bot_lef.gif" width="16" alt="" /></td>
            <td background="../images/bot_mid.gif" height="16">
                <img height="16" src="../images/bot_mid.gif" width="16" alt="" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../images/bot_rig.gif" width="24" alt="" /></td>
        </tr>
    </table>
</asp:Content>
                            
