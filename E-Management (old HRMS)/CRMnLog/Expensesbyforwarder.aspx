<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Expensesbyforwarder.aspx.vb" Inherits="E_Management.Expensesbyforwarder" MasterPageFile="~/ems.Master" Title="Forwarder Expense"%>


<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	
			<table cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../images/top_lef.gif" width="16"  alt=""/></td>
            <td background="../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../images/top_mid.gif" width="16"  alt="" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../images/top_rig.gif" width="24"  alt="" /></td>
        </tr>
        <tr>
            <td background="../images/cen_lef.gif"  width="16">
                <img height="11" src=    "../images/cen_lef.gif" width="16"  alt="" /></td>
            <td bgcolor="#ffffff" valign="top">
            <table style="width: 404px; height: 294px" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px; height: 427px;">
                            <asp:Panel ID="Panel1" runat="server">
				


		 
	
			
				<table>
					<tr>
						<td style="WIDTH: 607px; HEIGHT: 27px; background-color: #336699;" colspan="4"><span
                                style="color: #ffffff"> <strong><span style="font-size: 13.5pt">Register -
                                    Forwarder's Expenses</span></strong></span></td>
					</tr>
					<tr>
						<td style="WIDTH: 143px; HEIGHT: 30px; background-color: beige;"><asp:label id="lblfid" Width="148px" Height="18px" CssClass="lbldesign" Runat="server"> Forwarder's Id - Name</asp:label></td>
						<td style="WIDTH: 466px; HEIGHT: 30px" colspan="3">&nbsp;
							<asp:dropdownlist id="ddlfid" Width="456px" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
						<td style="HEIGHT: 30px"></td>
					</tr>
					<tr>
						<td style="WIDTH: 143px; HEIGHT: 30px; background-color: beige;"></td>
						<td style="WIDTH: 81px; HEIGHT: 47px; background-color: beige;"><strong>Expense Details</strong></td>
						<td style="WIDTH: 81px; HEIGHT: 47px; background-color: beige;"></td>
						<td style="WIDTH: 81px; HEIGHT: 47px; background-color: beige;"><strong>Selected Expenses</strong></td>
						<td style="HEIGHT: 47px"></td>
					</tr>
					<tr>
						<td style="WIDTH: 143px; HEIGHT: 30px; background-color: beige;"><asp:listbox id="lstexpcode" runat="server" Width="136px" Height="26px" Visible="False"></asp:listbox></td>
						<td style="WIDTH: 181px; HEIGHT: 15px"><asp:listbox id="lstb1" runat="server" Width="184px" Height="184px"></asp:listbox></td>
						<td style="WIDTH: 81px; HEIGHT: 26px; background-color: beige;"><asp:button id="btnadd" runat="server" BackColor="Control" Width="80px" BorderColor="LightBlue"
								Text="Add" ToolTip="Select an Expense from the Left Side and Press Add"></asp:button><br />
                            <br />
                            <asp:button id="btndel" runat="server" BackColor="Control" Width="80px" BorderColor="LightBlue"
								Text="Remove" ToolTip="Select an Expense from Right Side and Press Remove"></asp:button></td>
						<td style="WIDTH: 192px; HEIGHT: 15px"><asp:listbox id="lstb2" runat="server" Width="184px" Height="184px"></asp:listbox></td>
						<td style="HEIGHT: 15px"></td>
					</tr>
					<tr>
                        <td colspan="5" style="height: 28px">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnSubmit" CssClass="btnSubmitStyle" Runat="server" Text="Submit"></asp:button>
                            &nbsp; &nbsp;
							<asp:button id="btnClear" Width="72px" CssClass="btnSubmitStyle" Runat="server" Text="Clear"
								CausesValidation="False"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnExit" Width="84px" CssClass="btnExitStyle" Runat="server" Text="Exit" CausesValidation="False"></asp:button>
                            &nbsp; &nbsp;&nbsp;</td>
					</tr>
				</table>
            &nbsp;
        



</asp:Panel>
                        </td>
                    </tr>
                </table>
                </td>
				  <td background="../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../images/cen_rig.gif" width="24"  alt="" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../images/bot_lef.gif" width="16"  alt="" /></td>
            <td background="../images/bot_mid.gif" height="16">
                <img height="16" src="../images/bot_mid.gif" width="16"  alt="" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../images/bot_rig.gif" width="24" alt="" /></td>
        </tr>
        
        <tr>
        <td colspan="4">
            &nbsp;</td>
        </tr>
        
    </table>
				<asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
		</asp:Content>