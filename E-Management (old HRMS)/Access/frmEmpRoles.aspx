<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="frmEmpRoles.aspx.vb" Inherits="E_Management.frmEmpRoles" 
    title="Assign Rights to the Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
  <table cellpadding=0 cellspacing=0 align="center">
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
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text="Assign Roles to Employee"></asp:Label></td></tr>

    <tr><td id="Td1" runat="server" colspan="3">
        <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td></tr>
        <tr><td id="Td2" runat="server" align="center" style="background-color: beige">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" Text="Employee"></asp:Label></td><td align="center" id="Td3" runat="server" style="background-color: beige">
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Small" Text="Roles"></asp:Label></td><td style="background-color: beige" align="center">
            </td></tr>
        <tr><td valign="top" style="background-color: beige" align="left">
            &nbsp;&nbsp;
            <br />
            <asp:Label ID="Label4" runat="server" BackColor="#5D7B9D" ForeColor="White" Text="assign by Individual"
                Width="154px"></asp:Label><br />
            <asp:Label ID="Label5" runat="server" BackColor="OldLace" Text="Enter Employee Code"></asp:Label><br />
            <asp:TextBox ID="TxtBoxEmpCode" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="[OR]"></asp:Label><br />
            <br />
            <asp:Label ID="Label7" runat="server" BackColor="OldLace" Text="Select Department"></asp:Label><br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                DataTextField="departmentname" DataValueField="departmentcode" Font-Size="X-Small">
            </asp:DropDownList><br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:E_Management.My.MySettings.hrmisConnectionString %>"
                SelectCommand="Sp_GetDepts" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            <asp:Label ID="Label8" runat="server" BackColor="OldLace" Text="Select Employee"></asp:Label><br />
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource4"
                DataTextField="empname" DataValueField="empcode" AutoPostBack="True">
            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:E_Management.My.MySettings.hrmisConnectionString %>"
                SelectCommand="Sp_GetEmpbyDepts" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="deptcode" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Label ID="Label9" runat="server" BackColor="#5D7B9D" ForeColor="White" Text="assign by designation"
                Width="154px"></asp:Label><br />
            <asp:Label ID="Label10" runat="server" BackColor="OldLace" Text="Select designation"></asp:Label><br />
            <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3"
                DataTextField="designationname" DataValueField="designationname" AutoPostBack="True">
            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:E_Management.My.MySettings.hrmisConnectionString %>"
                SelectCommand="Sp_GetDesignations" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </td><td valign="top" style="background-color: beige">
    &nbsp;&nbsp;
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="Roleid" HeaderText="Role Id" SortExpression="Roleid" />
                    <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role" />
                    <asp:BoundField DataField="Roledesc" HeaderText="Description" SortExpression="Roledesc" />
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
                SelectCommand="Sp_GetRoles" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:Button ID="BtnSave" runat="server" Text="Save" /></td><td align="top" valign="top" style="background-color: beige">
    <br />
    <br />
        &nbsp;</td></tr>
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
