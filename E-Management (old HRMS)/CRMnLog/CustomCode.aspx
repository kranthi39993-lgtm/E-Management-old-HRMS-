<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CustomCode.aspx.vb" Inherits="E_Management.CustomCode" MasterPageFile="~/ems.Master" Title ="Custom Code" %>

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
            <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px">
                            <asp:Panel ID="Panel11" runat="server">

 
	 	<%--<div id="copyright" onAfterPrint="this.style.visibility='hidden'" onBeforePrint="this.style.visibility='visible'">--%>
                                &nbsp;&nbsp;<%--</div>--%><%--<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px"></BLOCKQUOTE>--%>
		<table>
			<tr>
				<td style="HEIGHT: 39px; background-color: #336699;" rowspan="1" colspan="2"><font size="2"><strong><span style="color: #ffffff; font-size: 14pt;">Custom Code&nbsp;Registration</span></strong></font></td>
			</tr>
			<tr>
				<td style="WIDTH: 175px; HEIGHT: 51px; background-color: beige;"><asp:label id="lbloelist" Width="144px" CssClass="lbldesign" Runat="server"> Department</asp:label></td>
				<td style="HEIGHT: 52px; width: 245px;"><asp:dropdownlist id="ddlDept" runat="server" Width="196px" AutoPostBack="True"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;</td>
			</tr>
			<tr>
				<td style="WIDTH: 175px; HEIGHT: 51px; background-color: beige;"><asp:label id="lblcode" Width="144px" CssClass="lbldesign" Runat="server">Custom Code</asp:label><br />
                    <br />
                </td>
				<td style="HEIGHT: 51px; width: 245px; text-align: left;">
                    <asp:DropDownList ID="CmbCustomCode" runat="server" AutoPostBack="True" Width="196px">
                    </asp:DropDownList><br />
                    <asp:textbox id="txtcode" Width="186px" ToolTip="Enter your own Expense Code" Runat="server"></asp:textbox>&nbsp;</td>
			</tr>
			<tr>
				<td style="WIDTH: 175px; HEIGHT: 51px; background-color: beige;"><asp:label id="Label1" Width="144px" CssClass="lbldesign" Runat="server">Description</asp:label></td>
				<td style="HEIGHT: 51px; width: 245px; text-align: left;"><asp:textbox id="txtDesc" Width="180" ToolTip="Enter your own Expense Code" Runat="server"></asp:textbox></td>
			</tr>
			<tr>
                <td colspan="2">
                    <asp:button id="btnSubmit" CssClass="btnSubmitStyle" Runat="server" Text="Submit"></asp:button>
					<asp:button id="btnClear" Width="64px" CssClass="btnSubmitStyle" Runat="server" Text="Clear"
						CausesValidation="False"></asp:button>
					<asp:button id="btnExit" Width="72px" CssClass="btnSubmitStyle" Runat="server" Text="Exit" CausesValidation="False"></asp:button>
                </td>
			</tr>
		</table>
		 
		 
		 
		 
				</asp:Panel>
                            &nbsp;
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
		</asp:Content>