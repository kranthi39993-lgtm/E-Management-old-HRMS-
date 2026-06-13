<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="frmRegMould.aspx.vb" Inherits="E_Management.frmRegMould" 
    title="Mould Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding="0" cellspacing="0" align="center">
	<tr>
					<td width="16"><IMG height="16" src="/images/top_lef.gif" width="16"></td>
					<td background="/images/top_mid.gif" height="16"><IMG height="16" src="/images/top_mid.gif" width="16"></td>
					<td style="width: 10px"><IMG height="16" src="/images/top_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" background="/images/cen_lef.gif"><IMG height="11" src="/images/cen_lef.gif" width="16"></td>
					<td vAlign="top" bgColor="#ffffff">
					
<table align="center">
<tr><td colspan="2" align="center"  style="background: #5D7B9D; font-weight:bold; color:White; height: 19px;">
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" Text="Mould Registration"></asp:Label></td>
    <td align="center" colspan="1" style="font-weight: bold; background: #5d7b9d; color: white;
        height: 19px; text-align: center;">
        Mould No &nbsp;
    </td>
</tr>
    <tr>
        <td style="background-color: beige;">
            <asp:Label ID="Label7" runat="server" Text="Department" Width="100px"></asp:Label></td>
        <td style="height: 21px">
            <asp:DropDownList ID="CMBDepartment" runat="server" AutoPostBack="True" Width="150px">
            </asp:DropDownList></td>
        <td rowspan="7">
        <table>
            <tr>
                <td style="height: 26px; background-color: beige;">
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Small" Text="Mould No"></asp:Label></td>
                <td style="height: 26px; background-color: beige;">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" Text="Pressing Qty"></asp:Label></td>
                <td style="height: 26px; background-color: beige;">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Small" Text="Mould No"></asp:Label></td>
                <td style="height: 26px; background-color: beige;">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" Text="Pressing Qty"></asp:Label></td>
                <td style="height: 26px; background-color: beige;">
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Small" Text="Mould No"></asp:Label></td>
                <td style="height: 26px; background-color: beige;">
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Small" Text="Pressing Qty"></asp:Label></td>
            </tr>
        
        <tr>
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="A" runat="server" Text="A01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="A1" runat="server" Width="75px"></asp:TextBox></td> 
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="B" runat="server" Text="B01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="B1" runat="server" Width="75px"></asp:TextBox></td>       
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="C" runat="server" Text="C01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="C1" runat="server" Width="75px"></asp:TextBox></td> 
        </tr>
        
        <tr>
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="D" runat="server" Text="D01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="D1" runat="server" Width="75px"></asp:TextBox></td>       
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="E" runat="server" Text="E01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="E1" runat="server" Width="75px"></asp:TextBox></td> 
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="F" runat="server" Text="F01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="F1" runat="server" Width="75px"></asp:TextBox></td>       
        </tr>
        
        <tr>
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="G" runat="server" Text="G01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="G1" runat="server" Width="75px"></asp:TextBox></td> 
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="H" runat="server" Text="H01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="H1" runat="server" Width="75px"></asp:TextBox></td>       
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="I" runat="server" Text="I01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="I1" runat="server" Width="75px"></asp:TextBox></td> 
        </tr>
        
        <tr>
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="J" runat="server" Text="J01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="J1" runat="server" Width="75px"></asp:TextBox></td>       
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="K" runat="server" Text="K01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="K1" runat="server" Width="75px"></asp:TextBox></td> 
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="L" runat="server" Text="L01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="L1" runat="server" Width="75px"></asp:TextBox></td>       
        </tr>
        
        <tr>
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="M" runat="server" Text="M01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="M1" runat="server" Width="75px"></asp:TextBox></td> 
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="N" runat="server" Text="N01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="N1" runat="server" Width="75px"></asp:TextBox></td>       
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="O" runat="server" Text="O01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="O1" runat="server" Width="75px"></asp:TextBox></td>         
        </tr>
        
        <tr>
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="P" runat="server" Text="P01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="P1" runat="server" Width="75px"></asp:TextBox></td>       
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="Q" runat="server" Text="Q01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="Q1" runat="server" Width="75px"></asp:TextBox></td> 
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="R" runat="server" Text="R01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="R1" runat="server" Width="75px"></asp:TextBox></td>       
        </tr>
        
        <tr>
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="S" runat="server" Text="S01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="S1" runat="server" Width="75px"></asp:TextBox></td> 
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="T" runat="server" Text="T01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="T1" runat="server" Width="75px"></asp:TextBox></td>       
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="U" runat="server" Text="U01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="U1" runat="server" Width="75px"></asp:TextBox></td> 
        </tr>
        
        <tr>
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="V" runat="server" Text="V01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="V1" runat="server" Width="75px"></asp:TextBox></td>       
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="W" runat="server" Text="W01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="W1" runat="server" Width="75px"></asp:TextBox></td> 
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="X" runat="server" Text="X01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="X1" runat="server" Width="75px"></asp:TextBox></td>       
        </tr>
        
        <tr>
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="Y" runat="server" Text="Y01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="Y1" runat="server" Width="75px"></asp:TextBox></td> 
        <td style="height: 26px; background-color: beige;"><asp:CheckBox ID="Z" runat="server" Text="Z01" /></td>        
        <td style="height: 26px"><asp:TextBox ID="Z1" runat="server" Width="75px"></asp:TextBox></td>       
        <td style="height: 26px; background-color: beige"></td><td></td>
        </tr>
        
        </table>
        
            </td>
    </tr>
<tr><td style="background-color: beige">
    <asp:Label ID="Label5" runat="server" Text="Product"></asp:Label></td><td>
        <asp:DropDownList ID="DrpdwnProduct" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3"
            DataTextField="fg_desc" DataValueField="fg_desc" Width="150px">
        </asp:DropDownList>
    </td></tr>
    <tr>
        <td style="background-color: beige">
            <asp:Label ID="Label3" runat="server" Text="Mould Description:"></asp:Label></td>
        <td>
            <asp:DropDownList ID="DrpDwnMName" runat="server" AutoPostBack="True" Width="150px" DataSourceID="SqlDataSource2" DataTextField="MouldName" DataValueField="MouldName">
            <asp:ListItem Value="-Select-"></asp:ListItem>
            <asp:ListItem>Single Slit</asp:ListItem>
            <asp:ListItem>Double Slit</asp:ListItem>
        </asp:DropDownList>
        </td>
    </tr>
        <tr><td style="background-color: beige">
    <asp:Label ID="Label12" runat="server" Text="Mould Type"></asp:Label></td><td>
        &nbsp;
        <asp:Label ID="LblMType" runat="server" Text="Please Select Mould Name"></asp:Label></td></tr>
    <tr>
        <td style="background-color: beige">
            <asp:Label ID="Label8" runat="server" Text="Stand-By Qty"></asp:Label></td>
        <td>
            <asp:TextBox ID="TxtSQty" runat="server" MaxLength="50" Width="150px"></asp:TextBox>&nbsp;</td>
    </tr>
<tr><td style="text-align: right">
    <asp:Button ID="Button1" runat="server" Text="View" Width="60px" CausesValidation="False" /></td><td>
    <asp:Button ID="BtnSave" runat="server" Text="Save" Width="60px" /></td></tr>
    <tr><td id="Td1" runat="server" colspan="2">
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CMBDepartment"
            ErrorMessage="* Please Select - Department" InitialValue="-Select-"></asp:RequiredFieldValidator><br />
        &nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DrpDwnMName"
            ErrorMessage="* Please Select - Mould Type" InitialValue="-Select-"></asp:RequiredFieldValidator><br />
        &nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtSQty"
                ErrorMessage="* Stand By Qty Must Be Numeric" ValidationExpression="\d*" SetFocusOnError="True"></asp:RegularExpressionValidator>&nbsp;<br />
        &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtSQty"
                ErrorMessage="* Please Enter Stand By Qty"></asp:RequiredFieldValidator>
        <br />
        &nbsp;
        <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td></tr>
        <tr><td colspan="3" style="text-align: center">
            &nbsp;
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:mmCRMConnectionString %>"
            SelectCommand="select Distinct  fg_desc from productmaster where fg_group = @fgid order by fg_desc">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="21" Name="fgid" SessionField="fgid" />
            </SelectParameters>
        </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MMaintenanceConnectionString2 %>"
                SelectCommand="SELECT [MouldName] FROM [RegisterMouldName] Where FGID=@FGID">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="21" Name="FGID" SessionField="fgid" />
                </SelectParameters>
            </asp:SqlDataSource>
            &nbsp; &nbsp;
        </td>
        </tr>
    </table>
    </td>
					<td background="/images/cen_rig.gif" style="width: 10px">
					<IMG height="11" src="/images/cen_rig.gif" width="24"></td>
				</tr>
				<tr>
					<td width="16" height="16"><IMG height="16" src="/images/bot_lef.gif" width="16"></td>
					<td background="/images/bot_mid.gif" height="16"><IMG height="16" src="/images/bot_mid.gif" width="16"></td>
					<td height="16" style="width: 10px"><IMG height="16" src="/images/bot_rig.gif" width="24"></td>
				</tr>
			</table>
</asp:Content>
