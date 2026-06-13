<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ForwarderMaster.aspx.vb" Inherits="E_Management.ForwarderMaster" codePage="65001" MasterPageFile="~/ems.Master" Title="Forwarder Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	
<table  cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../images/top_lef.gif" width="16" alt=""/></td>
            <td background="../images/top_mid.gif" style="height: 16px; width: 596px;" >
                <img height="16" src="../images/top_mid.gif" width="16"  alt="" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../images/top_rig.gif" width="24" alt=""/></td>
        </tr>
        <tr>
            <td background="../images/cen_lef.gif"  width="16" style="height: 711px">
                <img height="11" src="../images/cen_lef.gif" width="16"  alt="" /></td>
            <td bgcolor="#ffffff" valign="top" style="width: 596px; height: 711px;">
                <table style="width: 600px; height: 714px" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px; height: 725px;">
                            <asp:Panel ID="Panel1" runat="server">
                            
                            
		<%--<div id="copyright" onAfterPrint="this.style.visibility='hidden'" onBeforePrint="this.style.visibility='visible'">--%>
		<%--	<blockquote dir="ltr" style="MARGIN-RIGHT: 0px">
				<font size="4"><strong></strong></font>&nbsp;
			</blockquote>--%>
			

                           
				

				
				
	<%--	</div>--%>
		
			<table>
				<tr>
					<td colspan="2" style="height: 22px; background-color: #336699;"><font size="4"><strong>
								<font size="2"><span style="color: #ffffff"></span></font></strong></font>
                        <font size="4"><strong><font size="2"><span style="font-size: 12pt; color: #ffffff">
                            Forwarder Registration (2 of 2)</span></font></strong></font></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lblFid" Width="96px" Runat="server" CssClass="lbldesign">Forwarders ID</asp:label></td>
					<td style="text-align: left"><asp:textbox id="txtFID" Width="180px" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="text-align: left; height: 26px; background-color: beige;"><asp:label id="lblFname" Width="114px" Runat="server" CssClass="lbldesign">Forwarders Name</asp:label><asp:label id="lblm1" Height="8px" Width="7px" ForeColor="Red" BackColor="Transparent" Font-Size="X-Small"
							Runat="server" CssClass="lbldesign">*</asp:label></td>
					<td style="text-align: left; height: 26px;"><asp:textbox id="txtFname" Width="180" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige; height: 24px;"><asp:label id="lblft" Width="100px" Runat="server" CssClass="lbldesign">Shipment Mode</asp:label></td>
					<td style="text-align: left; height: 24px;"><asp:dropdownlist id="ddlft" runat="server" Width="184px" AutoPostBack="True">
							<asp:ListItem Value="Airways">Airways</asp:ListItem>
							<asp:ListItem Value="Shiping">Shiping</asp:ListItem>
							<asp:ListItem Value="Truck">Truck</asp:ListItem>
							<asp:ListItem Value="Both Air-Ship">Both Air-Ship</asp:ListItem>
							<asp:ListItem Value="All">All</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;">
						<asp:label id="lbltype" Width="160px" CssClass="lbldesign" Runat="server">Forwarder Appointed By</asp:label></td>
					<td style="text-align: left">
						<asp:dropdownlist id="ddltype" runat="server" Width="184px" AutoPostBack="True">
							<asp:ListItem Value="Maruwa">Maruwa</asp:ListItem>
							<asp:ListItem Value="Customer">Customer</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lbladdress1" Width="54px" Runat="server" CssClass="lbldesign">Address1</asp:label><asp:label id="lblm2" Width="7px" ForeColor="Red" BackColor="Transparent" Font-Size="X-Small"
							Runat="server" CssClass="lbldesign">*</asp:label></td>
					<td style="text-align: left"><asp:textbox id="txtaddress1" Width="180" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lbladdress2" Width="64px" Runat="server" CssClass="lbldesign">Address2</asp:label></td>
					<td style="text-align: left"><asp:textbox id="txtaddress2" Width="180" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lblst" Width="34px" Runat="server" CssClass="lbldesign">State</asp:label><asp:label id="lblm3" Height="1px" Width="7px" ForeColor="Red" BackColor="Transparent" Font-Size="X-Small"
							Runat="server" CssClass="lbldesign">*</asp:label></td>
					<td style="text-align: left"><asp:dropdownlist id="ddlst" runat="server" Width="180px" AutoPostBack="True"></asp:dropdownlist>
                        <asp:textbox id="txtstate" Width="150px" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lblcty" Width="54px" Runat="server" CssClass="lbldesign">Country</asp:label><asp:label id="lblm5" Width="7px" ForeColor="Red" BackColor="Transparent" Font-Size="X-Small"
							Runat="server" CssClass="lbldesign">*</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
					<td style="text-align: left">
                        <asp:dropdownlist id="ddlcty" runat="server" Width="180px" AutoPostBack="True"></asp:dropdownlist>
                        <asp:textbox id="txtcty" Width="150px" Runat="server"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;</td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lblOffNo1" Width="112px" Runat="server" CssClass="lbldesign">Office Phone No1</asp:label><asp:label id="lblm4" Width="7px" ForeColor="Red" BackColor="Transparent" Font-Size="X-Small"
							Runat="server" CssClass="lbldesign">*</asp:label></td>
					<td style="text-align: left"><asp:textbox id="txtFOffNo1" Width="180" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator2" runat="server" ControlToValidate="txtFOffNo1" ErrorMessage="Enter numerical value only in Office Ph No1"
							ValidationExpression="\d+">*</asp:regularexpressionvalidator>&nbsp;<span style="font-size: 10pt">(Max
                                12 Nos)</span></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lblOffNo2" Width="114px" Runat="server" CssClass="lbldesign">Office Phone No2</asp:label>&nbsp;&nbsp;</td>
					<td style="text-align: left"><asp:textbox id="txtFOffNo2" Width="180" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator4" runat="server" ControlToValidate="txtFOffNo2" ErrorMessage="Enter numerical value only in Office Ph No2"
							ValidationExpression="\d+">*</asp:regularexpressionvalidator>&nbsp;<span style="font-size: 10pt">(Max
                                12 Nos)</span></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lblfax" Width="92px" Runat="server" CssClass="lbldesign">Office Fax No</asp:label></td>
					<td style="text-align: left"><asp:textbox id="txtofffaxno" Width="180" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator7" runat="server" ControlToValidate="txtofffaxno"
							ErrorMessage="Enter numerical value only in Office Fax No" ValidationExpression="\d+">*</asp:regularexpressionvalidator>&nbsp;<span
                                style="font-size: 10pt">(Max 15 Nos)</span></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige; height: 26px;"><asp:label id="lblFEmailID" Width="126px" Runat="server" CssClass="lbldesign">Forwarders EmailID</asp:label><asp:label id="lblm6" Width="7px" ForeColor="Red" BackColor="Transparent" Font-Size="X-Small"
							Runat="server" CssClass="lbldesign">*</asp:label></td>
					<td style="text-align: left; height: 26px;"><asp:textbox id="txtFEmailID" Width="180" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtFEmailID"
							ErrorMessage="Enter valid Email ID" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:regularexpressionvalidator>&nbsp;</td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lblCntPerson" Width="100px" Runat="server" CssClass="lbldesign">Contact Person</asp:label><asp:label id="lblm7" Width="7px" ForeColor="Red" BackColor="Transparent" Font-Size="X-Small"
							Runat="server" CssClass="lbldesign">*</asp:label></td>
					<td style="text-align: left"><asp:textbox id="txtFCntPerson" Width="180" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lblMobileNo" Width="194px" Runat="server" CssClass="lbldesign">Contact Person Mobile No</asp:label><asp:label id="lblm8" Width="7px" ForeColor="Red" BackColor="Transparent" Font-Size="X-Small"
							Runat="server" CssClass="lbldesign">*</asp:label></td>
					<td style="text-align: left"><asp:textbox id="txtFMobileNo" Width="180" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" ControlToValidate="txtFMobileNo"
							ErrorMessage="Enter numerical value only in Mobile No" ValidationExpression="\d+">*</asp:regularexpressionvalidator></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lbladdress4" Width="224px" Runat="server" CssClass="lbldesign">Contact Person Office Phone No</asp:label></td>
					<td style="text-align: left"><asp:textbox id="txtoffphno" Width="180" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator8" runat="server" ControlToValidate="txtoffphno" ErrorMessage="Enter numerical value onlyin Office Ph No"
							ValidationExpression="\d+">*</asp:regularexpressionvalidator><span style="font-size: 10pt">(Max
                                12 Nos)</span></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lblFaxNo" Width="204px" Runat="server" CssClass="lbldesign">Contact Person Office Fax No</asp:label></td>
					<td style="text-align: left"><asp:textbox id="txtFFaxNo" Width="180" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator5" runat="server" ControlToValidate="txtFFaxNo" ErrorMessage="Enter numerical value only in Office fax No"
							ValidationExpression="\d+">*</asp:regularexpressionvalidator>&nbsp;<span style="font-size: 10pt">(Max
                                15 Nos)</span></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lblemail" Width="212px" Runat="server" CssClass="lbldesign">Contact Person E-Mail ID</asp:label><asp:label id="lbleid" Width="7px" ForeColor="Red" BackColor="Transparent" Font-Size="X-Small"
							Runat="server" CssClass="lbldesign">*</asp:label></td>
					<td style="text-align: left"><asp:textbox id="txtcemail" Width="180" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lblBL" Width="78px" Runat="server" CssClass="lbldesign">BillingTerms</asp:label><asp:label id="lblm10" Width="7px" ForeColor="Red" BackColor="Transparent" Font-Size="X-Small"
							Runat="server" CssClass="lbldesign">*</asp:label></td>
					<td style="text-align: left"><asp:dropdownlist id="ddlbillterm" runat="server" Width="186px" AutoPostBack="True"></asp:dropdownlist><asp:textbox id="txtobt" Width="150px" Runat="server"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator6" runat="server" ControlToValidate="txtobt" ErrorMessage="Enter Billinig terms in Number of days Only Numeric"
							ValidationExpression="\d+">*</asp:regularexpressionvalidator></td>
				</tr>
				<tr>
					<td style="text-align: left; background-color: beige;"><asp:label id="lbldet" Width="122px" Runat="server" CssClass="lbldesign">Deduction With %</asp:label></td>
					<td style="text-align: left"><asp:textbox id="txtded" Width="180" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td colspan="2" style="text-align: center">
						
					<asp:button id="btnSubmit" BackColor="Control" BorderColor="Control" Runat="server" CssClass="btnSubmitStyle"
							Text="Submit"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;<asp:button id="btnClear" BackColor="Control" BorderColor="Control" Runat="server" CssClass="btnSubmitStyle"
							Text="Clear" CausesValidation="False"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnExit" BackColor="Control" BorderColor="Control" Runat="server" CssClass="btnExitStyle"
							Text="Exit" CausesValidation="False"></asp:button><br />
		<asp:validationsummary id="ValidationSummary1" runat="server" Height="1px" Width="547px" ShowSummary="False"
				ShowMessageBox="True"></asp:validationsummary>
					<asp:label id="Label8" runat="server" Height="23px" Width="178px" ForeColor="#C00000" BackColor="White"
							BorderColor="White" Visible="False">Select, If you want to Edit .</asp:label><asp:dropdownlist id="ddlselect" runat="server" Width="186px" AutoPostBack="True" Visible="False"></asp:dropdownlist></td>
				</tr>
			</table>
		
	
		
 
	<%--	<script language="JavaScript" type="text/javascript">
				<!--#include file="../common/jlib/eenadu_itu.js"-->
		</script>--%>
		</asp:Panel>
                        </td>
                    </tr>
                </table>
                </td>
   <td background="../images/cen_rig.gif" style="width: 24px; height: 711px;">
                <img height="11" src="../images/cen_rig.gif" width="24" alt="" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../images/bot_lef.gif" width="16"  alt="" /></td>
            <td background="../images/bot_mid.gif" height="16" style="width: 596px">
                <img height="16" src="../images/bot_mid.gif" width="16"  alt=""/></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../images/bot_rig.gif" width="24"  alt=""/></td>
        </tr>
    </table>
    <script type="text/javascript">
  <asp:Literal id="ltlAlert" runat="server" EnableViewState="False">
    </asp:Literal>
			</script>
 </asp:Content>