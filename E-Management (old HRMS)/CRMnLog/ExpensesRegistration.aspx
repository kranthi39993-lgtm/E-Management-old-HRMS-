<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ExpensesRegistration.aspx.vb" Inherits="E_Management.ExpensesRegistration" MasterPageFile="~/ems.Master" Title="Expense Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	
			<table cellpadding="0" cellspacing="0" align="center" style="width: 380px; height: 335px">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../images/top_lef.gif" width="16"  alt=""/></td>
            <td background="../images/top_mid.gif" style="height: 16px; width: 458px;">
                <img height="16" src="../images/top_mid.gif" width="16"  alt="" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../images/top_rig.gif" width="24"  alt="" /></td>
        </tr>
        <tr>
            <td background="../images/cen_lef.gif"  width="16" style="height: 314px">
                <img height="11" src=    "../images/cen_lef.gif" width="16"  alt="" /></td>
            <td bgcolor="#ffffff" valign="top" style="width: 458px; height: 314px">
            <table style="width: 374px; height: 253px" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px; height: 280px;">
                            <asp:Panel ID="Panel1" runat="server">
				



<%--		<div id="copyright" onBeforePrint="this.style.visibility='visible'" onAfterPrint="this.style.visibility='hidden'">--%>
		
	<%--	</div>--%>
		<blockquote dir="ltr" style="MARGIN-RIGHT: 0px"></blockquote>
		<table style="width: 386px; height: 280px">
			<tr>
				<td style="HEIGHT: 38px; background-color: #336699;" rowspan="1" colspan="2"><font size="2"><strong><span style="color: #ffffff">Local Handling Charges&nbsp;Registration</span></strong></font></td>
			</tr>
			<tr>
				<td style="WIDTH: 175px; HEIGHT: 21px; text-align: left; background-color: beige;"><asp:label id="lbloelist" Width="144px" Runat="server" CssClass="lbldesign"> Other Expenses List</asp:label><br />
                </td>
				<td style="HEIGHT: 15px; text-align: left; width: 320px;"><asp:dropdownlist id="ddloelist" Width="170px" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;<br />
                    * <span style="font-size: 8pt">(for Modification Please Select Here!)<span></span></span></td>
			</tr>
			<tr>
				<td style="WIDTH: 175px; HEIGHT: 21px; text-align: left; background-color: beige;"><asp:label id="lblcode" Width="144px" Runat="server" CssClass="lbldesign">Expenses Code</asp:label></td>
				<td style="HEIGHT: 33px; text-align: left; width: 320px;"><asp:textbox id="txtcode" ToolTip="Enter your own Expense Code" Width="170px" Runat="server" ReadOnly="True"></asp:textbox>&nbsp;</td>
			</tr>
			<tr>
				<td style="WIDTH: 175px; HEIGHT: 21px; text-align: left; background-color: beige;"><asp:label id="lblname" Width="144px" Runat="server" CssClass="lbldesign">Expenses Name</asp:label><br />
                </td>
				<td style="HEIGHT: 30px; text-align: left; width: 320px;"><asp:textbox id="txtexname" ToolTip="Enter the Expense Name Max 25 Characters" Width="170px"
						Runat="server"></asp:textbox>&nbsp;<br />
                    * <span style="font-size: 8pt">Max 25 Characters Only</span></td>
			</tr>
			<tr>
				<td style="WIDTH: 175px; HEIGHT: 21px; text-align: left; background-color: beige;"><asp:label id="Label1" Width="144px" Runat="server" CssClass="lbldesign">Expenses Type</asp:label></td>
				<td style="HEIGHT: 21px; text-align: left; width: 320px;"><asp:dropdownlist id="ddlType" Width="170px" runat="server" AutoPostBack="True">
						<asp:ListItem Value="Standard">Standard</asp:ListItem>
						<asp:ListItem Value="PerUnit">PerUnit</asp:ListItem>
					</asp:dropdownlist></td>
			</tr>
			<tr>
				<td style="WIDTH: 175px; HEIGHT: 21px; text-align: left; background-color: beige;"><asp:label id="Label4" Width="144px" Runat="server" CssClass="lbldesign" Visible="False">Minimum Amount</asp:label></td>
				<td style="HEIGHT: 45px; text-align: left; width: 320px;"><asp:textbox id="txtminamt" ToolTip="Enter the Minimum Expense Amount Ex:425.50" Width="170px"
						Runat="server" Visible="False">0</asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" ControlToValidate="txtminamt" ErrorMessage="Enter Numerical value only (Ex: 1245.25)"
						ValidationExpression="(\d{1,8}(\.\d{1,3})?)|(\d{0,8}(\.\d{1,3}))" Visible="False">*</asp:regularexpressionvalidator></td>
			</tr>
			<tr>
				<td style="height: 21px; width: 175px; text-align: center;" colspan="2"><asp:button id="btnSubmit" Runat="server" CssClass="btnSubmitStyle" Text="Submit"></asp:button>&nbsp;&nbsp;<asp:button id="btnClear" Width="64px" Runat="server" CssClass="btnSubmitStyle" Text="Clear"
						CausesValidation="False"></asp:button>&nbsp;&nbsp;<asp:button id="btnExit" Width="72px" Runat="server" CssClass="btnSubmitStyle" Text="Exit" CausesValidation="False"></asp:button>&nbsp;
				</td>
			</tr>
		</table>
	

	
				</asp:Panel>
                        </td>
                    </tr>
                </table>
                </td>
				  <td background="../images/cen_rig.gif" style="width: 24px; height: 314px;">
                <img height="11" src="../images/cen_rig.gif" width="24"  alt="" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../images/bot_lef.gif" width="16"  alt="" /></td>
            <td background="../images/bot_mid.gif" height="16" style="width: 458px">
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