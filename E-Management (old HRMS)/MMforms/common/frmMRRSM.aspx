<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="frmMRRS.aspx.vb" Inherits="E_Management.frmMRRSM" 
    title="Mould Repairing Requirement Sheet" %>
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
<tr><td colspan="4" align="center"  style="background: #5D7B9D; font-weight:bold; color:White">
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text="Mould Repairing Requirement Sheet"></asp:Label></td></tr>
<tr><td>
    <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Small" Text="SlNo: "></asp:Label>
    &nbsp;
    <asp:Label ID="LblSlNo" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td><td></td><td></td><td></td></tr>
<tr><td>
    <asp:Label ID="Label5" runat="server" Text="Product"></asp:Label></td><td style="width: 261px">
        <asp:DropDownList ID="DrpdwnProduct" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3"
            DataTextField="fg_desc" DataValueField="fg_desc">
        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:mmCRMConnectionString %>"
            SelectCommand="select  fg_code, fg_desc from productmaster where fg_group = @fgid order by fg_desc">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="21" Name="fgid" SessionField="fgid" />
            </SelectParameters>
        </asp:SqlDataSource>
    </td><td>
    <asp:Label ID="Label1" runat="server" Text="Mould No:"></asp:Label></td><td><asp:DropDownList ID="DrpDwnMould" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="mouldno" DataValueField="mouldno">
        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MMaintenanceConnectionString %>"
        SelectCommand="select mouldno from mouldmaster where product = @product and status = 'P'">
        <SelectParameters>
            <asp:ControlParameter ControlID="DrpdwnProduct" Name="product" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:TextBox ID="TxtBoxMould" runat="server" MaxLength="50" Width="32px" Visible="False"></asp:TextBox></td></tr>

<tr><td>
    <asp:Label ID="Label3" runat="server" Text="Mould Name:"></asp:Label></td><td style="width: 261px">
        <asp:TextBox ID="TxtBoxMName" runat="server" MaxLength="50" Width="138px"></asp:TextBox></td><td>
    </td><td>
        &nbsp;
    </td></tr>
    <tr><td colspan="4" align="center"  style="background: #EECCEE; font-weight:bold; color:White; height: 17px;">
    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" Text="repairing method"></asp:Label></td></tr>
         <tr><td style="height: 22px">
             <asp:CheckBox ID="ChkBoxRenew" runat="server" Text="Renew" /></td><td style="height: 22px; width: 261px;">
        &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Text="Slit Line Shallow" /></td><td style="height: 22px">
            <asp:CheckBox ID="CheckBox2" runat="server" Text="Outline Problem" /></td><td style="height: 22px">
        &nbsp;<asp:CheckBox ID="CheckBox3" runat="server" Text="Washing" /></td></tr>
         <tr><td>
             <asp:CheckBox ID="CheckBox4" runat="server" Text="Service" /></td><td style="width: 261px">
        &nbsp;<asp:CheckBox ID="CheckBox5" runat="server" Text="Slit Line Deep" /></td><td>
            <asp:CheckBox ID="CheckBox6" runat="server" Text="Send Mould to Japan" /></td><td>
        &nbsp;<asp:TextBox ID="TextBox20" runat="server" MaxLength="50" Width="138px"></asp:TextBox></td></tr>
        <tr><td>
            <asp:CheckBox ID="CheckBox8" runat="server" Text="Shedder Mark" /></td><td style="width: 261px">
        &nbsp;<asp:CheckBox ID="CheckBox9" runat="server" Text="Pin Break" /></td><td>
            <asp:CheckBox ID="CheckBox10" runat="server" Text="T.Hole Burr" /></td><td>
        &nbsp;<asp:TextBox ID="TextBox21" runat="server" MaxLength="50" Width="138px"></asp:TextBox></td></tr>
         <tr><td>
             <asp:CheckBox ID="CheckBox12" runat="server" Text="Shedder Break" /></td><td style="width: 261px">
        &nbsp;<asp:CheckBox ID="CheckBox13" runat="server" Text="Slit Line Shifted" /></td><td>
            <asp:CheckBox ID="CheckBox14" runat="server" Text="Edge Chip" /></td><td>
        &nbsp;<asp:TextBox ID="TextBox22" runat="server" MaxLength="50" Width="138px"></asp:TextBox></td></tr>
        <tr><td>
            <asp:CheckBox ID="CheckBox16" runat="server" Text="Slit Line Nampak Shallow" /></td><td style="width: 261px">
        &nbsp;<asp:CheckBox ID="CheckBox17" runat="server" Text="T.Hole Shifted" /></td><td>
            <asp:CheckBox ID="CheckBox18" runat="server" Text="Pumping Bar" /></td><td>
        &nbsp;<asp:TextBox ID="TextBox23" runat="server" MaxLength="50" Width="138px"></asp:TextBox></td></tr>
        <tr><td colspan="4" align="center"  style="background: #EECCEE; font-weight:bold; color:White; height: 17px;">
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" Text=""></asp:Label></td></tr>
         <tr><td>
             <asp:Label ID="Label6" runat="server" Text="Defective Point"></asp:Label></td><td style="width: 261px">
        &nbsp;<asp:TextBox ID="TextBox1" runat="server" Height="54px" TextMode="MultiLine"
                 Width="167px" MaxLength="100"></asp:TextBox></td><td>
            <asp:Label ID="Label8" runat="server" Text="Reason"></asp:Label></td><td>
        &nbsp;<asp:TextBox ID="TextBox2" runat="server" Height="54px" TextMode="MultiLine"
                Width="167px" MaxLength="100"></asp:TextBox></td></tr>
                <tr><td colspan="4" align="center"  style="background: #EECCEE; font-weight:bold; color:White; height: 17px;">
    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" Text="Press Shot Data"></asp:Label></td></tr>
    <tr><td>
        <asp:Label ID="Label10" runat="server" BackColor="Goldenrod" Text="Total Shot"></asp:Label></td><td style="width: 261px"></td><td><asp:CheckBox ID="CheckBox20" runat="server" Text="Outline" /></td><td><asp:CheckBox ID="CheckBox21" runat="server" Text="Green Sheet (5Pcs)" /></td></tr>
    <tr><td>
        <asp:Label ID="Label11" runat="server" Text="WD Upper"></asp:Label></td><td style="width: 261px">
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td><td>
        <asp:Label ID="Label15" runat="server" Text="After Washing"></asp:Label></td><td>
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></td></tr>
    <tr><td>
        <asp:Label ID="Label12" runat="server" Text="WD Lower"></asp:Label></td><td style="width: 261px">
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td><td>
        <asp:Label ID="Label16" runat="server" Text="After Pin Shaving"></asp:Label></td><td>
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td></tr>
    <tr><td>
        <asp:Label ID="Label13" runat="server" Text="LD Upper"></asp:Label></td><td style="width: 261px">
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td><td>
        <asp:Label ID="Label17" runat="server" Text="After Renew"></asp:Label></td><td>
        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></td></tr>
        
    <tr><td>
        <asp:Label ID="Label14" runat="server" Text="LD Lower"></asp:Label></td><td style="width: 261px">
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td><td></td><td></td></tr>
        <tr><td>
          <asp:Label ID="Label22" runat="server" Text="Press Incharge"></asp:Label></td><td style="width: 261px">
          <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox></td><td>
          <asp:Label ID="Label25" runat="server" Text="Date"></asp:Label></td><td>
          <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox><asp:ImageButton ID="ImageButton3"
              runat="server" ImageUrl="~/Images/calender.png" /><asp:Calendar ID="Calendar3" runat="server"
                  BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest"
                  Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Visible="False"
                  Width="220px">
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
       <tr><td colspan="4" align="center"  style="background: #EECCEE; font-weight:bold; color:White; height: 17px;">
    <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="Small" Text="to be keyed in by Mould Maintenance"></asp:Label></td></tr>
        <tr><td>
        <asp:Label ID="Label18" runat="server" Text="Repairing Recommendation"></asp:Label></td><td style="width: 261px"><asp:CheckBox ID="CheckBox22" runat="server" Text="Malaysia" AutoPostBack="True" /></td><td><asp:CheckBox ID="CheckBox23" runat="server" Text="Japan" AutoPostBack="True" /></td><td><asp:CheckBox ID="CheckBox24" runat="server" Text="Stand by" AutoPostBack="True" /></td></tr>
  <tr><td colspan="4" align="center"  style="font-weight:bold; color:White; height: 17px;">
      <asp:Label ID="Label29" runat="server" ForeColor="Black" Text="Repairing Recommendation"></asp:Label><br />
      &nbsp;<asp:TextBox ID="TextBox10" runat="server" Height="54px" TextMode="MultiLine" Width="535px" MaxLength="500"></asp:TextBox></td></tr>  
   
  <tr><td colspan="4" align="center"  style="font-weight:bold; color:White; height: 17px;">
      <asp:Label ID="Label30" runat="server" ForeColor="Black" Text="Repairing Method"></asp:Label><br />
      <asp:TextBox ID="TextBox11" runat="server" Height="54px" TextMode="MultiLine" Width="535px" MaxLength="500"></asp:TextBox></td></tr>
      <tr><td>
          <asp:Label ID="Label19" runat="server" Text="Mould Checked by"></asp:Label></td><td style="width: 261px">
          <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox></td><td>
              <asp:Label ID="Label23" runat="server" Text="Date"></asp:Label></td><td>
          <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox><asp:ImageButton ID="ImageButton1"
              runat="server" ImageUrl="~/Images/calender.png" /><asp:Calendar ID="Calendar1" runat="server"
                  BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest"
                  Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Visible="False"
                  Width="220px">
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
      <tr><td></td><td style="width: 261px"><asp:CheckBox ID="CheckBox28" runat="server" Text="OK" AutoPostBack="True" /></td><td><asp:CheckBox ID="CheckBox29" runat="server" Text="NG" AutoPostBack="True" /></td><td></td></tr>
      
       <tr><td>
          <asp:Label ID="Label21" runat="server" Text="QC acknowledged by"></asp:Label></td><td style="width: 261px">
          <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox></td><td>
              <asp:Label ID="Label24" runat="server" Text="Date"></asp:Label></td><td>
          <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox><asp:ImageButton ID="ImageButton2"
              runat="server" ImageUrl="~/Images/calender.png" /><asp:Calendar ID="Calendar2" runat="server"
                  BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest"
                  Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Visible="False"
                  Width="220px">
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
      <tr><td></td><td style="width: 261px"><asp:CheckBox ID="CheckBox30" runat="server" Text="OK" AutoPostBack="True" /></td><td><asp:CheckBox ID="CheckBox31" runat="server" Text="NG" AutoPostBack="True" /></td><td></td></tr>
      
       <tr><td>
        </td><td style="width: 261px"></td><td></td><td></td></tr>
      <tr><td>
          <asp:Label ID="Label27" runat="server" Text="MM Incharge"></asp:Label></td><td style="width: 261px">
          <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox></td><td>
          <asp:Label ID="Label28" runat="server" Text="Expected Date"></asp:Label></td><td>
          <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox><asp:ImageButton ID="ImageButton4"
              runat="server" ImageUrl="~/Images/calender.png" /><asp:Calendar ID="Calendar4" runat="server"
                  BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest"
                  Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Visible="False"
                  Width="220px">
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
<tr><td></td><td style="width: 261px">
    <asp:Button ID="BtnSave" runat="server" Text="Add" /></td></tr>
    <tr><td id="Td1" runat="server" colspan="2">
        <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td></tr>
        <tr><td colspan="2">
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
