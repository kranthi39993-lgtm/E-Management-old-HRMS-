<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PrintMouldMaintenanceData.aspx.vb" Inherits="E_Management.PrintMouldMaintenanceData"  MasterPageFile="~/ems.Master" Title="Print Mould Maintenance Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding=0 cellspacing=0 align="center">
	<tr>
					<td width="16"><IMG height="16" src="../images/top_lef.gif" width="16"></td>
					<td background="/images/top_mid.gif" height="16"><IMG height="16" src="../images/top_mid.gif" width="16"></td>
					<td width="24"><IMG height="16" src="../images/top_rig.gif" width="24"></td>
				</tr>
    <tr>
        <td background="../images/cen_lef.gif" width="16">
        </td>
        <td bgcolor="#6699cc" style="text-align: center" valign="top">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Print Mould Maintenance Repair Data" ForeColor="#FFFFFF"></asp:Label></td>
        <td background="../images/cen_rig.gif" width="24">
        </td>
    </tr>
				<tr>
					<td width="16" background="../images/cen_lef.gif"><IMG height="11" src="../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">

                        <%--##Design--%>
         <table><tr><td style="text-align: center">
        <asp:GridView AutoGenerateColumns=false  ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
            BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None"  OnSelectedIndexChanged="Fun1">
            <FooterStyle BackColor="Tan" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            
             <Columns>
                 <asp:BoundField DataField="SLNO" HeaderText="Ref No" />
                  <asp:BoundField DataField="Product" HeaderText="Product" />
                   <asp:BoundField DataField="PressingMachine" HeaderText="PressingMachine"  />
                   <asp:BoundField DataField="MouldNo" HeaderText="Mould No"  />
                   <asp:BoundField DataField="MouldName" HeaderText="Mould Name"  />
                   
                 <asp:CommandField SelectText="Print" ShowSelectButton="True" />
                </Columns>
                
        </asp:GridView>
        
    </td></tr></table>
    
       <%--Design##--%>

  </td>
					<td width="24" background="../images/cen_rig.gif">
					<IMG height="11" src="../images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="../images/bot_lef.gif" width="16"></td>
					<td background="../images/bot_mid.gif" height="16"><IMG height="16" src="../images/bot_mid.gif" width="16"></td>
					<td width="24" height="16"><IMG height="16" src="../images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
</asp:Content>