<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SendMouldToMaintenance.aspx.vb" Inherits="E_Management.SendMouldToMaintenance" MasterPageFile="~/ems.Master" Title="Send Mould to Maintenance" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding=0 cellspacing=0 align="center">
	<tr>
					<td width="16"><IMG height="16" src="../images/top_lef.gif" width="16"></td>
					<td background="/images/top_mid.gif" height="16"><IMG height="16" src="../images/top_mid.gif" width="16"></td>
					<td width="24"><IMG height="16" src="../images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="../images/cen_lef.gif"><IMG height="11" src="../images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">

                        <%--##Design--%>
                        
                        <TABLE align=center><TBODY><TR><TD 
style="FONT-WEIGHT: bold; BACKGROUND: #5d7b9d; COLOR: white" align=center 
colSpan=4><asp:Label id="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text="Mould Repairing Requirement Sheet" meta:resourcekey="Label2Resource1"></asp:Label></TD></TR><TR><TD><asp:Label id="Label5" runat="server" Text="Product" meta:resourcekey="Label5Resource1"></asp:Label></TD><TD 
style="WIDTH: 261px"><asp:DropDownList id="DrpdwnProduct" runat="server" DataValueField="fg_desc" DataTextField="fg_desc" DataSourceID="SqlDataSource3" AutoPostBack="True" meta:resourcekey="DrpdwnProductResource1">
        </asp:DropDownList><br />
      <asp:SqlDataSource id="SqlDataSource3" runat="server" SelectCommand="select Distinct  fg_desc from productmaster where fg_group = @fgid order by fg_desc" ConnectionString="<%$ ConnectionStrings:mmCRMConnectionString %>">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="21" Name="fgid" SessionField="fgid"  />
            </SelectParameters>
        </asp:SqlDataSource> </TD><TD>
            &nbsp;<asp:Label id="Label6" runat="server" Text="Press Machine:" meta:resourcekey="Label6Resource1"></asp:Label></TD><TD>
            <asp:DropDownList id="CmbPressMachine" runat="server" DataValueField="mouldno" DataTextField="mouldno"  AutoPostBack="True" meta:resourcekey="CmbPressMachineResource1">
            </asp:DropDownList>
                <asp:TextBox id="TxtBoxMName" runat="server" Width="138px" MaxLength="50" meta:resourcekey="TxtBoxMNameResource1" Visible="False"></asp:TextBox></TD></TR><TR><TD>
            <asp:Label ID="Label1" runat="server" Text="Mould No:" meta:resourcekey="Label1Resource1"></asp:Label></TD><TD 
style="WIDTH: 261px"><asp:DropDownList id="DrpDwnMould" runat="server" DataValueField="mouldno" DataTextField="mouldno" AutoPostBack="True" meta:resourcekey="DrpDwnMouldResource1">
</asp:DropDownList>
            <asp:TextBox id="TxtBoxMould" runat="server" Width="32px" MaxLength="50" meta:resourcekey="TxtBoxMouldResource1" Visible="False"></asp:TextBox>
        </TD><TD><asp:Label id="Label3" runat="server" Text="Mould Name:" meta:resourcekey="Label3Resource1"></asp:Label></TD><TD>  &nbsp; &nbsp;
            <asp:DropDownList id="DrpDwnMouldName" runat="server" DataValueField="mouldno" DataTextField="mouldno" AutoPostBack="True" Width="175px" meta:resourcekey="DrpDwnMouldNameResource1">
        </asp:DropDownList>
            &nbsp;</TD></TR><TR><TD 
style="FONT-WEIGHT: bold; BACKGROUND: #eeccee; COLOR: white; HEIGHT: 17px" 
align=center colSpan=4><asp:Label id="Label7" runat="server" Font-Bold="True" Font-Size="Small" Text="Repairing method" meta:resourcekey="Label7Resource1" ForeColor="#000099"></asp:Label>
                                    <asp:CheckBox ID="ChkBxInternal" runat="server" Text="Internal Service" AutoPostBack="True" meta:resourcekey="ChkBxInternalResource1" ForeColor="#000099" />
                                    <asp:CheckBox ID="ChkBxJapan" runat="server" Text="Send Mould to Japan" AutoPostBack="True" meta:resourcekey="ChkBxJapanResource1" ForeColor="#000099" /></TD></TR>
                            <TR><TD style="HEIGHT: 22px"><asp:CheckBox id="ChkRenew" runat="server" Text="Renew" meta:resourcekey="ChkRenewResource1"></asp:CheckBox></TD><TD 
style="WIDTH: 261px; HEIGHT: 22px"> &nbsp;<asp:CheckBox id="ChkShallow" runat="server" Text="Slit Line Shallow" meta:resourcekey="ChkShallowResource1"></asp:CheckBox></TD><TD 
style="HEIGHT: 22px"><asp:CheckBox id="ChkOP" runat="server" Text="Outline Problem" meta:resourcekey="ChkOPResource1"></asp:CheckBox></TD><TD 
style="HEIGHT: 22px"> &nbsp;<asp:CheckBox id="ChkWashing" runat="server" Text="Washing" meta:resourcekey="ChkWashingResource1"></asp:CheckBox></TD></TR><TR><TD style="height: 22px"><asp:CheckBox id="ChkService" runat="server" Text="Service" meta:resourcekey="ChkServiceResource1"></asp:CheckBox></TD><TD 
style="WIDTH: 261px; height: 22px;"> &nbsp;<asp:CheckBox id="ChkDeep" runat="server" Text="Slit Line Deep" meta:resourcekey="ChkDeepResource1"></asp:CheckBox></TD><TD style="height: 22px"><asp:CheckBox id="ChkBurr" runat="server" Text="T.Hole Burr" meta:resourcekey="ChkBurrResource1"></asp:CheckBox></TD><TD style="height: 22px"> &nbsp;<asp:CheckBox id="ChkBar" runat="server" Text="Pumping Bar" meta:resourcekey="ChkBarResource1"></asp:CheckBox></TD></TR><TR><TD><asp:CheckBox id="ChkShedderMark" runat="server" Text="Shedder Mark" meta:resourcekey="ChkShedderMarkResource1"></asp:CheckBox></TD><TD 
style="WIDTH: 261px"> &nbsp;<asp:CheckBox id="ChkPinBreak" runat="server" Text="Pin Break" meta:resourcekey="ChkPinBreakResource1"></asp:CheckBox></TD><TD> &nbsp;<asp:CheckBox id="ChkTHoleShifted" runat="server" Text="T.Hole Shifted" meta:resourcekey="ChkTHoleShiftedResource1"></asp:CheckBox></TD><TD> &nbsp;<asp:CheckBox id="ChkEdgeChip" runat="server" Text="Edge Chip" meta:resourcekey="ChkEdgeChipResource1"></asp:CheckBox></TD></TR><TR><TD style="height: 22px"><asp:CheckBox id="ChkShedderBreak" runat="server" Text="Shedder Break" meta:resourcekey="ChkShedderBreakResource1"></asp:CheckBox></TD><TD 
style="WIDTH: 261px; height: 22px;"> &nbsp;<asp:CheckBox id="ChkShifted" runat="server" Text="Slit Line Shifted" meta:resourcekey="ChkShiftedResource1"></asp:CheckBox></TD>
    <td colspan="2" style="height: 22px">
        <asp:CheckBox id="ChkNampakShallow" runat="server" Text="Slit Line Nampak Shallow" meta:resourcekey="ChkNampakShallowResource1"></asp:CheckBox>&nbsp;</td>
</TR><TR><TD 
style="FONT-WEIGHT: bold; BACKGROUND: #eeccee; COLOR: white; HEIGHT: 17px" 
align=center colSpan=4><asp:Label id="Label4" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="Label4Resource1"></asp:Label></TD></TR><TR><TD><asp:Label id="Label8" runat="server" Text="Reason" meta:resourcekey="Label8Resource1"></asp:Label></TD>
    <td colspan="3">
        <asp:TextBox id="TxtReason" runat="server" Height="54px" Width="601px" MaxLength="100" TextMode="MultiLine" meta:resourcekey="TxtReasonResource1"></asp:TextBox></td>
</TR><TR><TD><asp:Label id="Label19" runat="server" Text="Operator ID (Mould Handled By)" meta:resourcekey="Label19Resource1"></asp:Label></TD><TD 
style="WIDTH: 261px"><asp:TextBox id="TxtOperatorID" runat="server" meta:resourcekey="TxtOperatorIDResource1"></asp:TextBox></TD><TD><asp:Label id="Label23" runat="server" Text="Date" meta:resourcekey="Label23Resource1"></asp:Label></TD><TD><asp:TextBox id="TxtLastUsedOn" runat="server" meta:resourcekey="TxtLastUsedOnResource1"></asp:TextBox><asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/Images/calender.png" meta:resourcekey="ImageButton1Resource1"></asp:ImageButton><asp:Calendar id="Calendar1" runat="server" Height="200px" Width="220px" ForeColor="#003399" Font-Size="8pt" BackColor="White" Visible="False" Font-Names="Verdana" DayNameFormat="Shortest" CellPadding="1" BorderWidth="1px" BorderColor="#3366CC" meta:resourcekey="Calendar1Resource1">
                  <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"  />
                  <SelectorStyle BackColor="#99CCCC" ForeColor="#336666"  />
                  <WeekendDayStyle BackColor="#CCCCFF"  />
                  <TodayDayStyle BackColor="#99CCCC" ForeColor="White"  />
                  <OtherMonthDayStyle ForeColor="#999999"  />
                  <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF"  />
                  <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px"  />
                  <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                      Font-Size="10pt" ForeColor="#CCCCFF" Height="25px"  />
              </asp:Calendar> </TD></TR><TR><TD><asp:Label id="Label22" runat="server" Text="Press Incharge" meta:resourcekey="Label22Resource1"></asp:Label></TD><TD 
style="WIDTH: 261px"><asp:TextBox id="TxtPressIncharge" runat="server" meta:resourcekey="TxtPressInchargeResource1"></asp:TextBox></TD><TD><asp:Label id="Label27" runat="server" Text="MM Incharge" meta:resourcekey="Label27Resource1"></asp:Label></TD><TD><asp:TextBox id="TxtMMIncharge" runat="server" meta:resourcekey="TxtMMInchargeResource1"></asp:TextBox></TD></TR><TR>
    <td colspan="2">
        <asp:Label id="LblMsg" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="LblMsgResource1"></asp:Label></td>
    <TD></TD><TD style="text-align: right"><asp:Button id="BtnSave" runat="server" Text="Save" meta:resourcekey="BtnSaveResource1"></asp:Button></TD></TR></TBODY></TABLE>



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



