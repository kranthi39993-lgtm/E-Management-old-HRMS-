<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="frmSetStatus.aspx.vb" Inherits="E_Management.frmSetStatus" 
    title="Set Mould Status" %>
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
<tr><td colspan="2" align="center"  style="background: #5D7B9D; font-weight:bold; color:White">
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text="Set Mould Status"></asp:Label></td></tr>
<tr><td>
    <asp:Label ID="Label5" runat="server" Text="Product"></asp:Label></td><td>
        <asp:DropDownList ID="DrpdwnProduct" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3"
            DataTextField="fg_desc" DataValueField="fg_desc">
        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:mmCRMConnectionString %>"
            SelectCommand="select  distinct fg_desc from productmaster where fg_group = @fgid order by fg_desc">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="21" Name="fgid" SessionField="fgid" />
            </SelectParameters>
        </asp:SqlDataSource>
    </td></tr>

<tr><td>
    <asp:Label ID="Label1" runat="server" Text="Mould No:"></asp:Label></td><td>
        <asp:DropDownList ID="DrpDwnMould" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="MouldNo" DataValueField="MouldNo">
        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MMaintenanceConnectionString %>"
            SelectCommand="Sp_GetMouldsbyProd" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="Product" SessionField="product" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:TextBox ID="TxtBoxMould" runat="server" MaxLength="50" Width="32px"></asp:TextBox></td></tr>
        <tr><td style="height: 65px">
            <asp:Label ID="Status" runat="server" Text="Status"></asp:Label></td><td style="height: 65px">
            <asp:DropDownList ID="DrpDwnStatus" runat="server" AutoPostBack="True">
                <asp:ListItem>Select Status</asp:ListItem>
                <asp:ListItem Value="P">Press</asp:ListItem>
                <asp:ListItem Value="M">Internal Repair (Malaysia)</asp:ListItem>
                <asp:ListItem Value="J">External Repair (Japan)</asp:ListItem>
                <asp:ListItem Value="S">Stand by</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DrpDwnPressMC" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource4"
                DataTextField="PressMC" DataValueField="PressMC" Visible="False">
            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:MMaintenanceConnectionString %>"
                SelectCommand="Sp_GetPressMC" SelectCommandType="StoredProcedure">
            </asp:SqlDataSource>
        </td></tr>
         <tr><td>
    <asp:Label ID="Label3" runat="server" Text="Expected Date"></asp:Label></td><td>
        &nbsp;<asp:TextBox ID="TxtBoxExpDate" runat="server"></asp:TextBox>
        &nbsp;
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calender.png" />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC"
            BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
            Font-Size="8pt" ForeColor="#003399" Height="200px" Visible="False" Width="220px">
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <WeekendDayStyle BackColor="#CCCCFF" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
        </asp:Calendar>
        </td></tr>
         <tr><td>
    </td><td>
        &nbsp;<asp:Button ID="BtnSave" runat="server" Text="Add" /></td></tr>
<tr><td></td><td>
    </td></tr>
    <tr><td id="Td1" runat="server" colspan="2">
        <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td></tr>
        <tr><td colspan="2">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" DataKeyNames="Product,MouldNo"
        AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AutoGenerateDeleteButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="394px">
        <Columns>
            <asp:BoundField DataField="Product" HeaderText="Product" ReadOnly="True" SortExpression="Product" />
            <asp:BoundField DataField="MouldNo" HeaderText="MouldNo" ReadOnly="True" SortExpression="MouldNo" />
            <asp:BoundField DataField="MouldType" HeaderText="MouldType" SortExpression="MouldType" />
            <asp:BoundField DataField="PressLimit" HeaderText="PressLimit" SortExpression="PressLimit" />
            <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
            <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
            <asp:BoundField DataField="expdate" HeaderText="expdate" SortExpression="expdate" />
            <asp:BoundField DataField="pressmc" HeaderText="pressmc" SortExpression="pressmc" />
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
        SelectCommand="Sp_GetMoulds" SelectCommandType="StoredProcedure"
        deletecommand="Sp_DelMoulds" DeleteCommandType="StoredProcedure">
        <DeleteParameters>
            <asp:Parameter Name="Product" Type="String" />
            <asp:Parameter Name="MouldNo" Type="String" />
        </DeleteParameters>
        
    </asp:SqlDataSource></td></tr>
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
