<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="frmReqMould.aspx.vb" Inherits="E_Management.frmReqMould" 
    title="Mould Request Form" %>
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
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text="Mould Request Form"></asp:Label></td>
</tr>
    <tr>
        <td style="background-color: beige">
            <asp:Label ID="Label6" runat="server" Text="Department"></asp:Label></td>
        <td>
            <asp:DropDownList ID="CMBDepartment" runat="server" AutoPostBack="True" Width="200px">
            </asp:DropDownList></td>
    </tr>
<tr><td style="background-color: beige">
    <asp:Label ID="Label5" runat="server" Text="Product"></asp:Label></td><td>
        <asp:DropDownList ID="DrpdwnProduct" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3"
            DataTextField="fg_desc" DataValueField="fg_desc" Width="200px">
        </asp:DropDownList>
    </td></tr>

<tr><td style="background-color: beige">
    <asp:Label ID="Label1" runat="server" Text="Mould Name:"></asp:Label></td><td>
        <asp:DropDownList ID="DrpDwnMould" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="MouldName" DataValueField="MouldName" Width="200px">
        </asp:DropDownList>
        </td></tr>
    <tr>
        <td style="background-color: beige">
            <asp:Label ID="Label4" runat="server" Text="Press Machine"></asp:Label></td>
        <td>
            <asp:DropDownList ID="DrpDwnPressMc_CV" runat="server" AutoPostBack="True" Width="200px" DataSourceID="SqlDataSource4" DataTextField="Press" DataValueField="Press" Visible="False">
            </asp:DropDownList>
            <asp:DropDownList ID="DrpDwnPressMC_Sub" runat="server" DataSourceID="SqlDataSource1"
                DataTextField="Press" DataValueField="Press" Visible="False" Width="200px">
            </asp:DropDownList>
            <asp:DropDownList ID="DrpDwnPressMC_Mag" runat="server" Visible="False" Width="200px">
                <asp:ListItem Value="DRY"></asp:ListItem>
                <asp:ListItem Value="WET"></asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DrpDwnPressMC_TPH" runat="server" DataSourceID="SqlDataSource5"
                DataTextField="Press" DataValueField="Press" Visible="False" Width="200px">
            </asp:DropDownList></td>
    </tr>
         <tr><td style="background-color: beige">
    <asp:Label ID="Label3" runat="server" Text="Date Needed" Width="91px"></asp:Label></td><td>
        <asp:TextBox ID="TxtBoxExpDate" runat="server" Width="175px"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/calender.png" />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC"
            BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
            Font-Size="8pt" ForeColor="#003399" Height="160px" Visible="False" Width="160px">
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
         <tr><td style="text-align: right">
    </td><td>
        <asp:Button ID="Button1" runat="server" Text="View" CausesValidation="False" Width="50px" />
        <asp:Button ID="BtnSave" runat="server" Text="Save" Width="50px" /></td>
         </tr>
<tr><td style="height: 21px"></td><td style="height: 21px">
    </td>
</tr>
    <tr><td id="Td1" runat="server" colspan="2">
        <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>
    </tr>
    </table>
    <table><tr><td style="height: 47px"><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:mmCRMConnectionString %>"
            SelectCommand="select  distinct fg_desc from productmaster where fg_group = @fgid order by fg_desc">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="21" Name="fgid" SessionField="fgid" />
            </SelectParameters>
        </asp:SqlDataSource>
    </td><td style="height: 47px"><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MMaintenanceConnectionString %>"
            SelectCommand="Select Distinct MouldName From MouldMaster Where Product = @Product and FGID=@FGID">
            <SelectParameters>
                <asp:ControlParameter ControlID="DrpdwnProduct" Name="Product" PropertyName="SelectedValue"
                    Type="String" />
                <asp:SessionParameter DefaultValue="21" Name="FGID" SessionField="fgid" />
            </SelectParameters>
        </asp:SqlDataSource>
        </td><td style="width: 3px; height: 47px;"><asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:CVPackingSystemConnectionString %>"
                SelectCommand="SELECT DISTINCT Press&#13;&#10;FROM         QA_Table_SN&#13;&#10;ORDER BY Press">
            </asp:SqlDataSource>
        </td></tr>
        <tr>
            <td style="height: 47px">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RankingSystemConnectionString %>"
                    SelectCommand="SELECT DISTINCT Press&#13;&#10;FROM         QA_Table_SN&#13;&#10;ORDER BY Press"></asp:SqlDataSource>
            </td>
            <td style="height: 47px">
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:NewTPHPackingSystemConnectionString %>"
                    SelectCommand="SELECT DISTINCT Press&#13;&#10;FROM   QA_Table_SN&#13;&#10;ORDER BY Press">
                </asp:SqlDataSource>
            </td>
            <td style="width: 3px; height: 47px">
                &nbsp;</td>
        </tr>
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
