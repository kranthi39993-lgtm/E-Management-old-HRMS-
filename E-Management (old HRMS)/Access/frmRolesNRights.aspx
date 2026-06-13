<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="frmRolesNRights.aspx.vb" Inherits="E_Management.frmRolesNRights" 
    title="Assign Rights to the Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
  <table cellpadding="0" cellspacing="0" align="center">
	<tr>
					<td width="16"><IMG height="16" src="/images/top_lef.gif" width="16"></td>
					<td background="/images/top_mid.gif" height="16"><IMG height="16" src="/images/top_mid.gif" width="16"></td>
					<td width="24"><IMG height="16" src="/images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="/images/cen_lef.gif"><IMG height="11" src="/images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">
<table align="center">
<tr><td colspan="3" align="center"  style="background: #5D7B9D; font-weight:bold; color:White">
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text="Roles and Rights"></asp:Label></td></tr>

    <tr><td id="Td1" runat="server" colspan="3">
        <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td></tr>
        <tr><td id="Td2" runat="server" align="center" style="background-color: beige">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" Text="Roles"></asp:Label></td><td align="center" id="Td3" runat="server" style="background-color: beige">
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" Text="Modules"></asp:Label></td><td style="background-color: beige" align="center">
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" Text="Rgihts"></asp:Label></td></tr>
        <tr><td valign="top" style="background-color: beige">
            &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" AllowSorting="True">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                <asp:BoundField DataField="Roleid" HeaderText="Role Id" SortExpression="Roleid">
                    <ControlStyle Width="1px" />
                </asp:BoundField>
                    <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role" />
                    <asp:BoundField DataField="RoleDesc" HeaderText="Description" SortExpression="Roledesc" />
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:E_Management.My.MySettings.hrmisConnectionString %>"
                SelectCommand="Sp_GetRoles" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </td><td valign="top" style="background-color: beige">
    &nbsp;<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" AllowSorting="True">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
        <asp:BoundField DataField="SystemId" HeaderText="System Id" SortExpression="systemid" />
            <asp:BoundField DataField="SystemName" HeaderText="System" SortExpression="systemname" />
            <asp:BoundField DataField="ModuleId" HeaderText="Module Id" SortExpression="moduleid" />
            <asp:BoundField DataField="ModuleName" HeaderText="Module" SortExpression="ModuleName" />
            <asp:BoundField DataField="ModuleDesc" HeaderText="Description" SortExpression="ModuleDesc" />
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:E_Management.My.MySettings.hrmisConnectionString %>"
        SelectCommand="Sp_GetModules" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
</td><td align="top" valign="top" style="background-color: beige">
    <br />
    <br />
    <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource3"
        DataTextField="ScrType" DataValueField="ScrTypeid">
    </asp:CheckBoxList><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:E_Management.My.MySettings.hrmisConnectionString %>"
        SelectCommand="Sp_GetScrTypes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:Button ID="BtnSave" runat="server" Text="Save" /></td></tr>
    </table>
     </td>
					<td width="24" background="/images/cen_rig.gif">
					<IMG height="11" src="/images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="/images/bot_lef.gif" width="16"></td>
					<td background="/images/bot_mid.gif" height="16"><IMG height="16" src="/images/bot_mid.gif" width="16"></td>
					<td width="24" height="16"><IMG height="16" src="/images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
</asp:Content>
