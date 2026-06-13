<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="frmMouldList.aspx.vb" Inherits="E_Management.frmMouldList" 
    title="Mould List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding=0 cellspacing=0 align="center">


	<tr>
					<td width="16"><IMG height="16" src="/images/top_lef.gif" width="16"></td>
					<td background="/images/top_mid.gif" height="16" style="width: 480px"><IMG height="16" src="/images/top_mid.gif" width="16"></td>
					<td width="24"><IMG height="16" src="/images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="/images/cen_lef.gif"><IMG height="11" src="/images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff" style="width: 480px">
<table align="center">
<tr><td colspan="2" align="center"  style="background: #5D7B9D; font-weight:bold; color:White">
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text="Mould List"></asp:Label></td></tr>

        <tr><td colspan="2">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" Width="394px" DataKeyNames="product,mouldno">
        <Columns>
            <asp:BoundField DataField="product" HeaderText="product" ReadOnly="True" SortExpression="product" />
            <asp:BoundField DataField="mouldno" HeaderText="mouldno" ReadOnly="True" SortExpression="mouldno" />
            <asp:BoundField DataField="mouldtype" HeaderText="mouldtype" SortExpression="mouldtype" />
            <asp:BoundField DataField="mouldtype1" HeaderText="mouldtype1" SortExpression="mouldtype1" />
            <asp:BoundField DataField="presslimit" HeaderText="presslimit" SortExpression="presslimit" />
            <asp:BoundField DataField="remarks" HeaderText="remarks" SortExpression="remarks" />
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
            <asp:BoundField DataField="expdate" HeaderText="expdate" SortExpression="expdate" />
            <asp:BoundField DataField="pressmc" HeaderText="pressmc" SortExpression="pressmc" />
            <asp:BoundField DataField="fgid" HeaderText="fgid" SortExpression="fgid" />
        </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MMaintenanceConnectionString %>"
        SelectCommand="select  product, mouldno, mouldtype, mouldtype1, presslimit, remarks, status, expdate, pressmc, fgid from MouldMaster where fgid=@fgid order by fgid, Product, mouldno"
        deletecommand="Sp_DelMoulds" DeleteCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="Product" Type="String" />
            <asp:Parameter Name="MouldNo" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter Name="fgid" SessionField="fgid" />
        </SelectParameters>
        
    </asp:SqlDataSource></td></tr>
    <tr><td></td><td>
    <asp:Button ID="BtnSave" runat="server" Text="Save" Visible="False" /></td></tr>
    <tr><td id="Td1" runat="server" colspan="2">
        <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td></tr>
    </table>
    </td>
					<td width="24" background="/images/cen_rig.gif">
					<IMG height="11" src="/images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="/images/bot_lef.gif" width="16"></td>
					<td background="/images/bot_mid.gif" height="16" style="width: 480px"><IMG height="16" src="/images/bot_mid.gif" width="16"></td>
					<td width="24" height="16"><IMG height="16" src="/images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
</asp:Content>
