<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="IssueMould.aspx.vb" Inherits="E_Management.IssueMould" MasterPageFile="~/ems.Master" Title="Issue Mould" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding="0" cellspacing="0" align="center">
	<tr>
					<td width="16"><IMG height="16" src="/images/top_lef.gif" width="16"></td>
					<td background="/images/top_mid.gif" height="16"><img  alt=""  height="16" src="/images/top_mid.gif" width="16" /></td>
					<td width="24"><img  alt=""  height="16" src="/images/top_rig.gif" width="24" /></td>
				</tr>
				<tr>
					<td width="16" background="/images/cen_lef.gif"><img  alt=""  height="11" src="/images/cen_lef.gif" width="16" /></td>
					<td valign="top" bgcolor="#ffffff">






<table>
<tr>
    <td colspan="1" style="background-color: #5d7b9d; text-align: center">
        <asp:ImageButton ID="ImageButton1" runat="server" Height="26px" ImageUrl="~/MMForms/images/back.jpg"
            Width="29px" /></td>
<td colspan="4" style="background-color: #5d7b9d; text-align: center">
    <asp:Label ID="Label4" runat="server" Text="Issue Mould" Font-Bold="True" ForeColor="#FFFFFF"></asp:Label></td>
</tr>
<tr>
    <td style="background-color: beige"><asp:Label ID="Label1" runat="server" Text="Department"></asp:Label></td>
    <td style="height: 21px"><asp:Label ID="LblDepartment" runat="server" Font-Bold="True"></asp:Label></td>
    <td style="height: 21px; background-color: beige"><asp:Label ID="Label2" runat="server" Text="Product"></asp:Label></td>
    <td style="height: 21px"><asp:Label ID="LblProduct" runat="server" Font-Bold="True"></asp:Label></td>        
</tr>
<tr>
    <td style="background-color: beige"><asp:Label ID="Label3" runat="server" Text="Mould Description"></asp:Label></td>
    <td><asp:Label ID="LblMName" runat="server" Font-Bold="True"></asp:Label></td>
    <td style="height: 21px; background-color: beige"><asp:Label ID="Label5" runat="server" Text="Pressing Machine"></asp:Label></td>
    <td><asp:Label ID="LblPressingMachine" runat="server" Font-Bold="True"></asp:Label></td>        
</tr>
<tr>
<td colspan="4" style="text-align: center">
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="SqlDataSource1"
        DataTextField="MouldNo" DataValueField="MouldNo" RepeatDirection="Horizontal" AutoPostBack="True" RepeatColumns="4">
    </asp:RadioButtonList></td>
</tr>
    <tr>
        <td colspan="4" style="height: 21px; text-align: center">
            <asp:Button ID="Button1" runat="server" Text="Issue Mould" />&nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="4" style="text-align: center">
            <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>
    </tr>
    <tr>
        <td colspan="4" style="text-align: center">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MMaintenanceConnectionString2 %>"
                SelectCommand="Select MouldNo From MouldMaster Where Status='A' and fgid=@fgid and Product=@Product and MouldName=@MouldName">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="21" Name="fgid" SessionField="fgid" />
                    <asp:ControlParameter ControlID="LblProduct" Name="Product" PropertyName="Text" />
                    <asp:ControlParameter ControlID="LblMName" Name="MouldName" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>

</table>








                    </td>
					<td width="24" background="/images/cen_rig.gif">
					<img height="11" src="/images/cen_rig.gif" width="24" alt="" /></td>
				</tr>
				<tr>
					<td width="16" height="16"><img height="16"  alt="" src="/images/bot_lef.gif" width="16" /></td>
					<td background="/images/bot_mid.gif" height="16"><img  alt="" height="16" src="/images/bot_mid.gif" width="16" /></td>
					<td width="24" height="16"><img alt="" height="16" src="/images/bot_rig.gif" width="24" /></td>
				</tr>
			</table>
</asp:Content>