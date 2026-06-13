<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Weightregistration.aspx.vb" Inherits="E_Management.Weightregistration" MasterPageFile="~/ems.Master" Title="Weight Registration" %>


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
                            
                            
                            
                            

				<table>
					<tr>
						<td style="HEIGHT: 30px; background-color: #336699;" colspan="2"><strong><font size="2"><span style="color: #ffffff">Weight / M3&nbsp;Details </span>
								</font></strong>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 142px; HEIGHT: 14px; text-align: left; background-color: beige;">&nbsp;
							<asp:label id="lblDNAM" Width="130px" CssClass="lbldesign" Runat="server">Department Name</asp:label></td>
						<td style="HEIGHT: 14px">
							<asp:dropdownlist id="DrpDwnLstDpt" Width="512px" Font-Size="XX-Small" ForeColor="Blue" runat="server"
								AutoPostBack="True" Height="21pt"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td style="WIDTH: 142px; HEIGHT: 14px; text-align: left; background-color: beige;">&nbsp;
							<asp:label id="lblpname" Width="98px" CssClass="lbldesign" Runat="server">Product Name</asp:label></td>
						<td style="HEIGHT: 26px; text-align: left;">
							<asp:dropdownlist id="ddlpnam" Width="182px" runat="server"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td style="WIDTH: 142px; HEIGHT: 14px; text-align: left; background-color: beige;">&nbsp;
							<asp:label id="lblpic" Width="84px" CssClass="lbldesign" Runat="server">No Of Pieces</asp:label></td>
						<td style="HEIGHT: 38px; text-align: left;">
							<asp:textbox id="txtpic" Width="180" Runat="server">100</asp:textbox>
							<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ValidationExpression="\d+" ErrorMessage="Enter numerical value only in weight"
								ControlToValidate="txtpic">*</asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td style="WIDTH: 142px; HEIGHT: 14px; text-align: left; background-color: beige;">&nbsp;
							<asp:label id="lblw" Width="54px" CssClass="lbldesign" Runat="server">Weight</asp:label></td>
						<td style="HEIGHT: 31px; text-align: left;">
							<asp:textbox id="txtwt" Width="180" Runat="server"></asp:textbox>
							<asp:label id="lblkg" Width="39px" CssClass="lbldesign" Runat="server">KGS</asp:label>
							<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ValidationExpression="(\d{1,8}(\.\d{1,3})?)|(\d{0,8}(\.\d{1,3}))"
								ErrorMessage="Enter numerical value only in Pallet  Volume" ControlToValidate="txtwt">*</asp:regularexpressionvalidator></td>
					</tr>
					<tr>
						<td style="WIDTH: 142px; HEIGHT: 14px; text-align: left; background-color: beige;">&nbsp;
							<asp:label id="Label6" Width="38px" CssClass="lbldesign" Runat="server">M3</asp:label></td>
						<td style="HEIGHT: 31px; text-align: left;">
							<asp:textbox id="txtM3" Width="180" Runat="server"></asp:textbox>
							<asp:label id="Label7" Width="39px" CssClass="lbldesign" Runat="server">M3</asp:label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtM3"
                                ErrorMessage="Please enter M3 value"></asp:RequiredFieldValidator></td>
					</tr>
					<tr>
						<td colspan="2" style="width: 142px; height: 14px; text-align: center">
							<asp:button id="btnSubmit" CssClass="btnSubmitStyle" Runat="server" Text="Submit"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="btnClear" CssClass="btnSubmitStyle" Runat="server" Text="Clear" CausesValidation="False" Width="67px"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="btnExit" CssClass="btnExitStyle" Runat="server" Text="Exit" CausesValidation="False" Width="64px"></asp:button></td>
					</tr>
				</table>
			
				<asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
                                &nbsp;&nbsp;
		<asp:validationsummary id="ValidationSummary1" runat="server" Height="16px" Width="643px" ShowMessageBox="True"
				ShowSummary="False"></asp:validationsummary>
	

			
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