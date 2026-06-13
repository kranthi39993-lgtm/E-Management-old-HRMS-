<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MaintenanceData.aspx.vb" Inherits="E_Management.MaintenanceData" MasterPageFile="~/ems.Master" Title="Maintenance Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
                         
 <TABLE cellSpacing=0 cellPadding=0 align=center><TBODY><TR><TD width=16><IMG height=16 src="../images/top_lef.gif" 
width=16 /></TD><TD 
background="/images/top_mid.gif" height=16><IMG height=16 src="../images/top_mid.gif" 
width=16 /></TD><TD width=24><IMG height=16 src="../images/top_rig.gif" 
width=24 /></TD></TR><TR><TD width=16 
background="../images/cen_lef.gif"><IMG 
height=11 src="../images/cen_lef.gif" width=16 /></TD><TD vAlign=top bgColor=#ffffff><%--##Design--%><TABLE align=center><TBODY><TR><TD 
style="FONT-WEIGHT: bold; BACKGROUND: #5d7b9d; COLOR: white" align=center 
colSpan=4><asp:Label id="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text="Mould Repair Data" meta:resourcekey="Label2Resource1"></asp:Label></TD></TR><TR><TD><asp:Label id="Label20" runat="server" Font-Bold="True" Font-Size="Small" Text="SlNo: " meta:resourcekey="Label20Resource1"></asp:Label><asp:Label id="LblSlNo" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="LblSlNoResource1"></asp:Label></TD><TD><asp:DropDownList id="CmbSLNO" runat="server" Width="147px" meta:resourcekey="DrpdwnProductResource1" AutoPostBack="True">
        </asp:DropDownList></TD><TD></TD><TD></TD></TR><TR><TD><asp:Label id="Label5" runat="server" Text="Product" meta:resourcekey="Label5Resource1"></asp:Label></TD><TD 
style="WIDTH: 261px"><asp:TextBox id="TxtProduct" runat="server" Width="138px" meta:resourcekey="TxtBoxMNameResource1" MaxLength="50"></asp:TextBox></TD><TD>   
    <asp:Label id="Label6" runat="server" Text="Press Machine:" meta:resourcekey="Label6Resource1"></asp:Label></TD><TD><asp:TextBox id="TxtPressingMachine" runat="server" Width="138px" meta:resourcekey="TxtBoxMNameResource1" MaxLength="50"></asp:TextBox></TD></TR><TR><TD><asp:Label id="Label1" runat="server" Text="Mould No:" meta:resourcekey="Label1Resource1"></asp:Label></TD><TD 
style="WIDTH: 261px"><asp:TextBox id="TxtBoxMould" runat="server" Width="136px" meta:resourcekey="TxtBoxMouldResource1" MaxLength="50"></asp:TextBox></TD><TD><asp:Label id="Label3" runat="server" Text="Mould Name:" meta:resourcekey="Label3Resource1"></asp:Label></TD><TD style="text-align: left">                
    <asp:TextBox id="TxtBoxMName" runat="server" Width="138px" meta:resourcekey="TxtBoxMNameResource1" MaxLength="50"></asp:TextBox></TD></TR><TR><TD 
style="FONT-WEIGHT: bold; BACKGROUND: #eeccee; COLOR: white; HEIGHT: 17px" 
align=center colSpan=4><asp:Label id="Label7" runat="server" Font-Bold="True" Font-Size="Small" Text="Repairing Method" meta:resourcekey="Label7Resource1" ForeColor="#000099"></asp:Label> &nbsp;&nbsp; &nbsp;&nbsp;
   <asp:CheckBox id="ChkBxInternal" runat="server" Text="Internal Service" meta:resourcekey="ChkBxInternalResource1" AutoPostBack="True" ForeColor="#000099"></asp:CheckBox>&nbsp;
<asp:CheckBox id="ChkBxJapan" runat="server" Text="Send Mould to Japan" meta:resourcekey="ChkBxJapanResource1" AutoPostBack="True" ForeColor="#000099"></asp:CheckBox></TD></TR><TR><TD style="HEIGHT: 22px"><asp:CheckBox id="ChkRenew" runat="server" Text="Renew" meta:resourcekey="ChkRenewResource1"></asp:CheckBox></TD><TD><asp:CheckBox id="ChkShallow" runat="server" Text="Slit Line Shallow" meta:resourcekey="ChkShallowResource1"></asp:CheckBox></TD><TD><asp:CheckBox id="ChkOP" runat="server" Text="Outline Problem" meta:resourcekey="ChkOPResource1"></asp:CheckBox></TD><TD><asp:CheckBox id="ChkWashing" runat="server" Text="Washing" meta:resourcekey="ChkWashingResource1"></asp:CheckBox></TD></TR><TR><TD><asp:CheckBox id="ChkService" runat="server" Text="Service" meta:resourcekey="ChkServiceResource1"></asp:CheckBox></TD><TD><asp:CheckBox id="ChkDeep" runat="server" Text="Slit Line Deep" meta:resourcekey="ChkDeepResource1"></asp:CheckBox></TD><TD><asp:CheckBox id="ChkBurr" runat="server" Text="T.Hole Burr" meta:resourcekey="ChkBurrResource1"></asp:CheckBox></TD><TD>      <asp:CheckBox id="ChkBar" runat="server" Text="Pumping Bar" meta:resourcekey="ChkBarResource1"></asp:CheckBox></TD></TR><TR><TD><asp:CheckBox id="ChkShedderMark" runat="server" Text="Shedder Mark" meta:resourcekey="ChkShedderMarkResource1"></asp:CheckBox></TD><TD><asp:CheckBox id="ChkPinBreak" runat="server" Text="Pin Break" meta:resourcekey="ChkPinBreakResource1"></asp:CheckBox></TD><TD>      <asp:CheckBox id="ChkTHoleShifted" runat="server" Text="T.Hole Shifted" meta:resourcekey="ChkTHoleShiftedResource1"></asp:CheckBox></TD><TD>       <asp:CheckBox id="ChkEdgeChip" runat="server" Text="Edge Chip" meta:resourcekey="ChkEdgeChipResource1"></asp:CheckBox></TD></TR><TR><TD style="HEIGHT: 22px"><asp:CheckBox id="ChkShedderBreak" runat="server" Text="Shedder Break" meta:resourcekey="ChkShedderBreakResource1"></asp:CheckBox></TD><TD><asp:CheckBox id="ChkShifted" runat="server" Text="Slit Line Shifted" meta:resourcekey="ChkShiftedResource1"></asp:CheckBox></TD><TD 
colSpan=2><asp:CheckBox id="ChkNampakShallow" runat="server" Text="Slit Line Nampak Shallow" meta:resourcekey="ChkNampakShallowResource1"></asp:CheckBox></TD></TR><TR><TD><asp:Label id="Label8" runat="server" Text="Reason" meta:resourcekey="Label8Resource1"></asp:Label></TD><TD 
colSpan=3><asp:TextBox id="TxtReason" runat="server" Height="54px" Width="601px" meta:resourcekey="TxtReasonResource1" MaxLength="100" TextMode="MultiLine"></asp:TextBox></TD></TR><TR><TD><asp:Label id="Label19" runat="server" Text="Operator ID (Mould Handled By)" meta:resourcekey="Label19Resource1"></asp:Label></TD><TD 
style="WIDTH: 261px"><asp:TextBox id="TxtOperatorID" runat="server" meta:resourcekey="TxtOperatorIDResource1"></asp:TextBox></TD><TD><asp:Label id="Label23" runat="server" Text="Mould Last Used On" meta:resourcekey="Label23Resource1"></asp:Label></TD><TD><asp:TextBox id="TxtLastUsedOn" runat="server" meta:resourcekey="TxtLastUsedOnResource1"></asp:TextBox><asp:ImageButton id="ImageButton1" runat="server" ImageUrl="~/Images/calender.png" meta:resourcekey="ImageButton1Resource1"></asp:ImageButton><asp:Calendar id="Calendar1" runat="server" Height="200px" Width="220px" ForeColor="#003399" Font-Size="8pt" BackColor="White" meta:resourcekey="Calendar1Resource1" Visible="False" Font-Names="Verdana" DayNameFormat="Shortest" CellPadding="1" BorderWidth="1px" BorderColor="#3366CC">
                  <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"    />
                  <SelectorStyle BackColor="#99CCCC" ForeColor="#336666"    />
                  <WeekendDayStyle BackColor="#CCCCFF"    />
                  <TodayDayStyle BackColor="#99CCCC" ForeColor="White"    />
                  <OtherMonthDayStyle ForeColor="#999999"    />
                  <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF"    />
                  <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px"    />
                  <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                      Font-Size="10pt" ForeColor="#CCCCFF" Height="25px"    />
              </asp:Calendar> </TD></TR><TR><TD><asp:Label id="Label22" runat="server" Text="Press Incharge" meta:resourcekey="Label22Resource1"></asp:Label></TD><TD 
style="WIDTH: 261px"><asp:TextBox id="TxtPressIncharge" runat="server" meta:resourcekey="TxtPressInchargeResource1"></asp:TextBox></TD><TD><asp:Label id="Label27" runat="server" Text="MM Incharge" meta:resourcekey="Label27Resource1"></asp:Label></TD><TD><asp:TextBox id="TxtMMIncharge" runat="server" meta:resourcekey="TxtMMInchargeResource1"></asp:TextBox></TD></TR><TR><TD></TD><TD style="WIDTH: 261px"></TD><TD><asp:Label id="Label9" runat="server" Text="Delivery Date" meta:resourcekey="Label23Resource1"></asp:Label></TD><TD><asp:TextBox id="TxtDeliveryDate" runat="server" meta:resourcekey="TxtLastUsedOnResource1"></asp:TextBox><asp:ImageButton id="ImageButton2" runat="server" ImageUrl="~/Images/calender.png" meta:resourcekey="ImageButton1Resource1"></asp:ImageButton><asp:Calendar id="Calendar2" runat="server" Height="200px" Width="220px" ForeColor="#003399" Font-Size="8pt" BackColor="White" meta:resourcekey="Calendar1Resource1" Visible="False" Font-Names="Verdana" DayNameFormat="Shortest" CellPadding="1" BorderWidth="1px" BorderColor="#3366CC">
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"    />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666"    />
                    <WeekendDayStyle BackColor="#CCCCFF"    />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White"    />
                    <OtherMonthDayStyle ForeColor="#999999"    />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF"    />
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px"    />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                      Font-Size="10pt" ForeColor="#CCCCFF" Height="25px"    />
                </asp:Calendar> </TD></TR><TR><TD colSpan=2><asp:Label id="LblMsg" runat="server" Font-Bold="True" Font-Size="Small" meta:resourcekey="LblMsgResource1"></asp:Label></TD><TD></TD><TD style="TEXT-ALIGN: right"><asp:Button id="BtnSave" runat="server" Text="Save" meta:resourcekey="BtnSaveResource1"></asp:Button></TD></TR></TBODY></TABLE><%--Design##--%></TD><TD 
width=24 background="../images/cen_rig.gif"><IMG height=11 src="../images/cen_rig.gif" 
width=24 /></TD></TR><TR><TD width=16 height=16><IMG height=16 src="../images/bot_lef.gif" 
width=16 /></TD><TD 
background="../images/bot_mid.gif" height=16><IMG height=16 src="../images/bot_mid.gif" 
width=16 /></TD><TD width=24 height=16><IMG height=16 src="../images/bot_rig.gif" 
width=24 /></TD></TR></TBODY></TABLE>

    
</asp:Content>