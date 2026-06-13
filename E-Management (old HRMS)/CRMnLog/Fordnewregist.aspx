<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Fordnewregist.aspx.vb" Inherits="E_Management.Fordnewregist" MasterPageFile="~/ems.Master" Title="Forwarder Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	
<table  cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../images/top_lef.gif" width="16"  alt=""/></td>
            <td background="../images/top_mid.gif" style="height: 16px; width: 681px;">
                <img height="16" src="../images/top_mid.gif" width="16"  alt="" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../images/top_rig.gif" width="24"  alt="" /></td>
        </tr>
        <tr>
            <td background="../images/cen_lef.gif"  width="16">
                <img height="11" src="../images/cen_lef.gif" width="16"  alt="" /></td>
            <td bgcolor="#ffffff" valign="top" style="width: 681px">
                <table>
                    <tr>
                        <td colspan="2" align="center" style="width: 435px; height: 332px;">
                            <asp:Panel ID="Panel1" runat="server">
                                &nbsp;<table>
					<tr>
						<td style="HEIGHT: 27px; text-align: center; background-color: #336699;" colspan="5">
							<FONT size="4"><STRONG><span style="color: #ffffff">Forwarder Registration (1 of 2)</span></STRONG></FONT></td>
						
					</tr>
					<tr>
					 
<td style="width: 133px; background-color: beige; text-align: left"></td>
<td style="width: 357px"></td>						
                        <td style="width: 357px">
                        </td>
                        <td><asp:comparevalidator id="Comparevalidator1" runat="server" Font-Bold="True" Font-Size="X-Small" Operator="NotEqual"

								EnableClientScript="False" Display="Dynamic" ControlToCompare="txtCompUser" ErrorMessage="" ControlToValidate="txtUserID"></asp:comparevalidator></td>
								
					</tr>
					<tr>
						<td style="WIDTH: 133px; text-align: left; background-color: beige;"><asp:label id="Label6" runat="server" BackColor="Beige" Width="96px">E-mail ID</asp:label></td>
						<td style="WIDTH: 357px; text-align: left;"><asp:textbox id="TxtEmail" runat="server" Width="175px"></asp:textbox></td>
                        <td style="width: 357px; text-align: left">
                            <asp:label id="Label7" runat="server" ForeColor="Red">&nbsp;*</asp:label></td>
						<td style="width: 363px; text-align: left"><asp:regularexpressionvalidator id="RegExpValEmail" runat="server" Width="118px" Font-Bold="True" ErrorMessage="Invalid Email ID"
								ControlToValidate="TxtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td style="WIDTH: 133px; text-align: left; background-color: beige;"><asp:label id="Label5" runat="server" BackColor="Beige" Width="114px">Confirm E-mail ID</asp:label></td>
						<td style="WIDTH: 357px; text-align: left; height: 45px;"><asp:textbox id="TxtConEmail" runat="server" Width="175px"></asp:textbox></td>
                        <td style="width: 357px; height: 45px; text-align: left">
                            <asp:label id="Label8" runat="server" ForeColor="Red">&nbsp;*</asp:label></td>
						<td style="width: 363px; text-align: left; height: 45px;"><asp:regularexpressionvalidator id="RegExpValConEmail" runat="server" Width="156px" Font-Bold="True" ErrorMessage="Can not be Left Empty"
								ControlToValidate="TxtConEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator><br />
                            <asp:comparevalidator id="CompareValidator3" runat="server" Width="142px" Font-Bold="True" ControlToCompare="TxtEmail"
								ErrorMessage="EMail Id - Mismatch " ControlToValidate="TxtConEmail"></asp:comparevalidator></td>
					</tr>
					<tr>
						<td style="WIDTH: 133px; text-align: left; background-color: beige;"><asp:label id="Label2" runat="server" BackColor="Beige" Width="96px">User Name</asp:label></td>
						<td style="WIDTH: 357px; text-align: left;"><asp:textbox id="txtUserID" runat="server" Width="175px" MaxLength="15" ToolTip="Please enter UserName here. Maximum length-15characters."></asp:textbox></td>
                        <td style="width: 357px; text-align: left">
                            <asp:label id="Label9" runat="server" ForeColor="Red">&nbsp;*</asp:label></td>
						<td style="width: 363px; text-align: left"><asp:requiredfieldvalidator id="ReqValUserName" runat="server" Width="162px" Font-Bold="True" Display="Dynamic"
								ErrorMessage="Can Not be Left Empty" ControlToValidate="txtUserID"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td style="WIDTH: 133px; text-align: left; background-color: beige;"><asp:label id="Label3" runat="server" BackColor="Beige" Width="96px">Password</asp:label></td>
						<td style="WIDTH: 357px; text-align: left; height: 45px;"><asp:textbox id="txtPassword" runat="server" Width="175px" MaxLength="15" ToolTip="Please enter your password here. Maximum Length - 15 characters"
								TextMode="Password"></asp:textbox></td>
                        <td style="width: 357px; height: 45px; text-align: left">
                            <asp:label id="Label10" runat="server" ForeColor="Red">&nbsp;*</asp:label></td>
						<td style="width: 363px; text-align: left; height: 45px;"><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Width="162px" Font-Bold="True" ErrorMessage="Can Not be Left Empty"
								ControlToValidate="txtPassword"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td style="WIDTH: 133px; text-align: left; background-color: beige;"><asp:label id="Label4" runat="server" BackColor="Beige" Width="122px">Confirm Password</asp:label></td>
						<td style="WIDTH: 357px; text-align: left; height: 45px;"><asp:textbox id="TxtConPassword" runat="server" Width="175px" MaxLength="15" ToolTip="Please enter your password here. Maximum Length - 15 characters"
								TextMode="Password"></asp:textbox></td>
                        <td style="width: 357px; height: 45px; text-align: left">
                            <asp:label id="Label11" runat="server" ForeColor="Red">&nbsp;*</asp:label></td>
						<td style="width: 363px; text-align: left; height: 45px;"><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Width="162px" Font-Bold="True" ErrorMessage="Can Not be Left Empty"
								ControlToValidate="TxtConPassword"></asp:requiredfieldvalidator></td>
					</tr>
					<tr>
						<td style="WIDTH: 133px; text-align: left; background-color: beige;"><asp:textbox id="txtCompUser" runat="server" Width="32px" Visible="False" BackColor="Beige"></asp:textbox></td>
						<td style="WIDTH: 357px; text-align: left;"></td>
                        <td style="width: 357px; text-align: left">
                        </td>
						<td style="width: 363px; text-align: left"><asp:comparevalidator id="CompareValidator2" runat="server" Width="224px" Font-Bold="True" ControlToCompare="txtPassword"
								ErrorMessage="Password & Confirm Password Must be Equal." ControlToValidate="TxtConPassword"></asp:comparevalidator></td>
					</tr>
					<tr>
						<td colspan="4" style="width: 133px; text-align: center; height: 50px;"><asp:button id="btnSearch" onmouseover="this.style.backgroundColor='lightsteelblue'; this.style.fontWeight='bold'; this.className='cursor'"
								onmouseout="this.style.backgroundColor='aliceblue'; this.style.fontWeight='normal'" runat="server" Width="136px"
								ForeColor="Black" BackColor="Control" text="Submit"></asp:button>&nbsp;<asp:Button
                                    ID="Button1" runat="server" Text="Exit" Width="93px" CausesValidation="False" /></td>
					</tr>
				</table>
	
	
		</asp:Panel>
                        </td>
                    </tr>
                </table>
                
  <td background="../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../images/cen_rig.gif" width="24" alt=""/></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../images/bot_lef.gif" width="16"  alt=""/></td>
            <td background="../images/bot_mid.gif" height="16" style="width: 681px">
                <img height="16" src="../images/bot_mid.gif" width="16" alt="" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../images/bot_rig.gif" width="24"  alt=""/></td>
        </tr>
    </table>
    <script type="text/javascript">
  <asp:Literal id="ltlAlert" runat="server" EnableViewState="False">
    </asp:Literal>
		</script>
</asp:Content>