<%@ Page Language="vb" AutoEventWireup="false" Codebehind="QuotationMaster.aspx.vb" Inherits="E_Management.QuotationMaster" MasterPageFile="~/ems.Master" Title="Prepare Quotation" %>

		<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	
			<table cellpadding="0" cellspacing="0" align="center" width="800">
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
            <table>
                    <tr>
                        <td colspan="2" align="center" style="width: 435px; height: 652px;">
                            <asp:Panel ID="Panel1" runat="server">
				


		<table>
				<tr>
					<td style="HEIGHT: 40px; background-color: #336699;" colspan="4">
                        <span style="color: #ffffff">
						<font size="3"><strong>Quotation Master</strong></font>
                        </span>
					</td>
				</tr>
				<tr>
					<td style="WIDTH: 200px; HEIGHT: 26px; text-align: left; background-color: beige;"><font size="2"><asp:label id="Label4" Height="14px" Width="104px" ForeColor="Red" CssClass="lbldesign" Runat="server">&nbsp;Quotation For :</asp:label></font></td>
					<td style="WIDTH: 166px; HEIGHT: 16px; text-align: left;"><asp:radiobuttonlist id="rblType" runat="server" Height="8px" Width="212px" AutoPostBack="True" RepeatDirection="Horizontal">
							<asp:ListItem Value="Flight">Air</asp:ListItem>
							<asp:ListItem Value="Vessel">Sea</asp:ListItem>
							<asp:ListItem Value="Truck">Truck</asp:ListItem>
                        <asp:ListItem>Courier</asp:ListItem>
						</asp:radiobuttonlist></td>
					<td style="WIDTH: 158px; HEIGHT: 33px; text-align: left; background-color: beige;"><asp:label id="Label1" Height="14px" Width="104px" ForeColor="Red" CssClass="lbldesign" Runat="server">Quotation No. </asp:label></td>
					<td style="HEIGHT: 16px; text-align: left;" colspan="4"><strong><asp:textbox id="txtQuoteno" runat="server" Width="180px" Font-Bold="True" ToolTip="Enter the Quotation No. here" ReadOnly="True"></asp:textbox></strong></td>
				</tr>
				<tr>
					<td style="WIDTH: 200px; HEIGHT: 26px; text-align: left; background-color: beige;"><asp:label id="lblfid" Width="110px" CssClass="lbldesign" Runat="server">Forwarders ID</asp:label></td>
					<td style="WIDTH: 166px; HEIGHT: 33px; text-align: left;"><asp:textbox id="txtfid" Width="180px" Runat="server" Visible="False"></asp:textbox><asp:dropdownlist id="ddlfid" Height="23px" Width="180px" Runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td style="WIDTH: 158px; HEIGHT: 33px; text-align: left; background-color: beige;"><asp:label id="lblFname" Height="14px" Width="80px" CssClass="lbldesign" Runat="server">ForwarderName</asp:label></td>
					<td style="HEIGHT: 33px; text-align: left; width: 328px;"><asp:textbox id="txtfname" Height="22" Width="180px" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 200px; HEIGHT: 26px; text-align: left; background-color: beige;"><asp:label id="lblname" Height="14px" Width="112px" CssClass="lbldesign" Runat="server">Transport Name</asp:label></td>
					<td style="WIDTH: 166px; HEIGHT: 27px; text-align: left;"><asp:dropdownlist id="ddlname" tabIndex="1" Height="22" Width="180px" Runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td style="WIDTH: 158px; HEIGHT: 33px; text-align: left; background-color: beige;"></td>
					<td style="HEIGHT: 27px; text-align: left; width: 328px;"></td>
				</tr>
				<tr>
					<td style="WIDTH: 200px; HEIGHT: 26px; text-align: left; background-color: beige;"><asp:label id="lblno" Height="14px" Width="111px" CssClass="lbldesign" Runat="server">Vehicle No</asp:label></td>
					<td style="WIDTH: 166px; HEIGHT: 25px; text-align: left;"><asp:dropdownlist id="ddlno" tabIndex="2" Height="22" Width="180px" Runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td style="WIDTH: 158px; HEIGHT: 33px; text-align: left; background-color: beige;"><asp:label id="lbldescriptname" Height="14px" Width="96px" CssClass="lbldesign" Runat="server">Vehicle Name</asp:label></td>
					<td style="HEIGHT: 25px; text-align: left; width: 328px;"><asp:textbox id="txtdescriptname" Height="22" Width="180px" Runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 200px; HEIGHT: 33px; text-align: left; background-color: beige;"><asp:label id="lblfrm" Height="14px" Width="111px" CssClass="lbldesign" Runat="server">From</asp:label></td>
					<td style="WIDTH: 166px; HEIGHT: 33px; text-align: left;"><asp:dropdownlist id="ddlfrom" Height="22" Width="180px" Runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td style="WIDTH: 158px; HEIGHT: 33px; text-align: left; background-color: beige;"><asp:label id="lblto" Height="14px" Width="96px" CssClass="lbldesign" Runat="server">To</asp:label></td>
					<td style="HEIGHT: 33px; text-align: left; width: 328px;"><asp:dropdownlist id="ddlto" Height="22" Width="180px" Runat="server" AutoPostBack="True"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td style="WIDTH: 200px; HEIGHT: 33px; text-align: left; background-color: beige;"><asp:label id="lblcur" Height="14px" Width="111px" CssClass="lbldesign" Runat="server">Currency Name</asp:label></td>
					<td style="WIDTH: 166px; HEIGHT: 33px; text-align: left;"><asp:dropdownlist id="ddlcur" Height="22" Width="180px" Runat="server" AutoPostBack="True"></asp:dropdownlist></td>
					<td style="WIDTH: 158px; HEIGHT: 33px; text-align: left; background-color: beige;"><asp:label id="lbleffectivefrom" runat="server" Width="104px">Effective From</asp:label></td>
					<td style="HEIGHT: 33px; text-align: left; width: 328px;"><asp:textbox id="txteffectivedate" runat="server" Width="150px" Wrap="False"></asp:textbox>&nbsp;<asp:imagebutton id="Imagebutton1" runat="server" Height="18px" Width="20px" ImageUrl="~/images/calender.png"></asp:imagebutton></td>
				</tr>
				<tr>
					<td style="WIDTH: 200px; HEIGHT: 26px; text-align: left; background-color: beige;"><asp:label id="lblqty" Height="14px" Width="111px" CssClass="lbldesign" Runat="server">Weight</asp:label></td>
					<td style="WIDTH: 166px; HEIGHT: 20px; text-align: left;"><asp:textbox id="txtQty" Width="150px" Runat="server" ToolTip="Enter the Weight Ex: +100, -45">0</asp:textbox><asp:label id="lblunit" runat="server">in Kgs</asp:label></td>
					<td style="WIDTH: 158px; HEIGHT: 33px; text-align: left; background-color: beige;">
						<asp:radiobuttonlist id="rblContainerType" runat="server" Width="120px" Height="8px" RepeatDirection="Horizontal"
							AutoPostBack="True" Visible="False">
							<asp:ListItem Value="LCL" Selected="True">LCL</asp:ListItem>
							<asp:ListItem Value="FCL">FCL</asp:ListItem>
						</asp:radiobuttonlist></td>
					<td style="HEIGHT: 20px; text-align: left; width: 328px;"></td>
				</tr>
				<tr>
					<td style="WIDTH: 200px; HEIGHT: 26px; text-align: left; font-family: beige; background-color: beige;"><asp:label id="Label2" Height="14px" Width="99px" CssClass="lbldesign" Runat="server">Amount</asp:label></td>
					<td style="WIDTH: 166px; HEIGHT: 26px; text-align: left;"><asp:textbox id="txtamt" Width="150px" Runat="server" ToolTip="Enter the Amount Ex: 12.50">0</asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ValidationExpression="(\d{1,8}(\.\d{1,2})?)|(\d{0,8}(\.\d{1,2}))|(N\/A)"
							ErrorMessage="Enter numerical value only in Amount" ControlToValidate="txtamt">*</asp:regularexpressionvalidator></td>
					<td style="WIDTH: 158px; HEIGHT: 33px; text-align: left; background-color: beige;"><asp:label id="Label3" runat="server" Width="234px">Minimum Amount</asp:label></td>
					<td style="HEIGHT: 26px; text-align: left; width: 328px;">
						<asp:textbox id="TxtMinAmt" Height="12px" Width="180px" Runat="server" ToolTip="Enter the Minimum Weight Amount Ex: 20.00">0</asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator4" runat="server" ValidationExpression="(\d{1,8}(\.\d{1,2})?)|(\d{0,8}(\.\d{1,2}))|(N\/A)"
								ErrorMessage="Enter numerical value only in Amount" ControlToValidate="txtamt">*</asp:regularexpressionvalidator>
					</td>
				</tr>
				<tr>
					<td style="WIDTH: 328px; HEIGHT: 25px; text-align: left;" colspan="2"><asp:label id="Label5" runat="server" Width="388px" ForeColor="Red">* Pls Enter 0 (zero) on Not Applicaple columns to avoid errors</asp:label>
						<asp:Label id="Label6" runat="server" ForeColor="Red">(All Local Handling Charges in Ringgit Malaysia)</asp:Label></td>
					<td style="WIDTH: 328px; HEIGHT: 25px; text-align: left;" valign="middle" nowrap="nowrap" align="center"></td>
					<td style="WIDTH: 328px; HEIGHT: 25px; text-align: left;" valign="middle" nowrap="nowrap" align="left"></td>
				</tr>
				<tr>
					<td style="WIDTH: 200px; HEIGHT: 26px; text-align: left; font-family: beige; background-color: beige;" valign="top" align="left" colspan="1" rowspan="1"><asp:placeholder id="dynamicLabel" runat="server" Visible="False"></asp:placeholder><asp:label id="lblexp" runat="server"  Visible="False" Width="200px"></asp:label></td>
					<td style="WIDTH: 166px; HEIGHT: 70px; background-color: beige;" valign="top" align="left">
						<asp:placeholder id="dynamicTextBox" runat="server"></asp:placeholder>
					</td>
					<td style="WIDTH: 158px; HEIGHT: 33px; text-align: left; background-color: beige;" valign="top" align="left">
                        &nbsp; &nbsp;<asp:label id="lbltype" runat="server" Width="102px"></asp:label>
                        &nbsp; &nbsp; 
                        <asp:label id="lblMin" runat="server" ForeColor="Red" Width="86px">Min Amt</asp:label></td>
					<td style="WIDTH: 328px; HEIGHT: 70px; text-align: left; background-color: beige;" valign="top" align="left">
						<asp:placeholder id="DTxtMinAmt" runat="server"></asp:placeholder>
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:datagrid id="Grid" runat="server" Height="153px" Width="766px"
							OnEditCommand="DoItemEdit" OnUpdateCommand="DoItemUpdate" OnCancelCommand="DoItemCancel" CellPadding="4"
							AutoGenerateColumns="False" ForeColor="#333333" GridLines="None">
							<EditItemStyle BackColor="#2461BF"></EditItemStyle>
							<HeaderStyle ForeColor="White" BackColor="#507CD1" Font-Bold="True"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="F_Id" HeaderText="ForwarderId"></asp:BoundColumn>
								<asp:BoundColumn DataField="VehicleNo" HeaderText="VehicleNo"></asp:BoundColumn>
								<asp:BoundColumn DataField="Departplace" HeaderText="Departure"></asp:BoundColumn>
								<asp:BoundColumn DataField="Arrivalplace" HeaderText="Arrival"></asp:BoundColumn>
								<asp:BoundColumn DataField="Weight" HeaderText="M3/Kg"></asp:BoundColumn>
								<asp:BoundColumn DataField="Amount" HeaderText="Amount"></asp:BoundColumn>
								<asp:BoundColumn DataField="CurrName" HeaderText="Currency Name"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="OtherExpenses" HeaderText="Net Amount"></asp:BoundColumn>
								<asp:BoundColumn DataField="RevisionNo" ReadOnly="True" HeaderText="RevisionNo"></asp:BoundColumn>
								<asp:BoundColumn DataField="EffectiveDate" HeaderText="Effective Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="MinimumCharge" HeaderText="Minimum Charge"></asp:BoundColumn>
								<asp:EditCommandColumn Visible="False" UpdateText="Update" HeaderText="Edit" CancelText="Cancel"
									EditText="Edit"></asp:EditCommandColumn>
								<asp:ButtonColumn Text="Delete" HeaderText="Delete" CommandName="Delete"></asp:ButtonColumn>
								<asp:ButtonColumn Visible="False" Text="View" HeaderText="Other Expenses" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="TransportName" HeaderText="TransportName"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="VesselMode" HeaderText="VesselMode"></asp:BoundColumn>
							</Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" />
                            <ItemStyle BackColor="#EFF3FB" />
						</asp:datagrid>
					</td>
				</tr>
				<tr>				
					<td style="HEIGHT: 25px" colspan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnClear" Width="74px" CssClass="btnSubmitStyle" Runat="server" Visible="False"
							Text="Clear" CausesValidation="False"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;&nbsp;<asp:button id="btnadd" Width="104px" CssClass="btnSubmitStyle" Runat="server" Text="Add To Grid"
							DESIGNTIMEDRAGDROP="121" BorderColor="ButtonFace" BackColor="Control"></asp:button>
                        &nbsp; &nbsp;
						<asp:button id="btnSubmit" Width="78px" CssClass="btnSubmitStyle" Runat="server" Text="Submit" Enabled="False"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnexit" Width="80px" CssClass="btnSubmitStyle" Runat="server" Text="Exit" CausesValidation="False"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</td>
				</tr>
			</table>
			<asp:datagrid id="feesgrid" style="Z-INDEX: 105; LEFT: 629px; POSITION: absolute; TOP: 962px"
				runat="server" Height="88px" Width="249px" Font-Bold="True" CellPadding="4" ForeColor="#333333" GridLines="None">
				<HeaderStyle ForeColor="White" BackColor="#507CD1" Font-Bold="True"></HeaderStyle>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
			</asp:datagrid><asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 104; LEFT: 46px; POSITION: absolute; TOP: 969px"
				runat="server" Height="19px" Width="803px" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary>
			<asp:calendar id="Calendar1" style="Z-INDEX: 106; LEFT: 857px; POSITION: absolute; TOP: 371px"
				runat="server" Height="80px" Width="151px" Visible="False" BorderColor="#006699" BackColor="LightBlue">
				<TodayDayStyle BackColor="#8080FF"></TodayDayStyle>
				<DayHeaderStyle BorderStyle="Double" BorderColor="#006699" BackColor="LightSteelBlue"></DayHeaderStyle>
				<TitleStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></TitleStyle>
				<OtherMonthDayStyle BackColor="#E0E0E0"></OtherMonthDayStyle>
			</asp:calendar>
			<asp:textbox id="txtnetoe" style="Z-INDEX: 108; LEFT: 976px; POSITION: absolute; TOP: 736px"
					Height="22" Width="83px" Runat="server" Visible="False" Enabled="False" ReadOnly="True"></asp:textbox><asp:label id="lblnet" style="Z-INDEX: 109; LEFT: 975px; POSITION: absolute; TOP: 706px" Height="16px"
					Width="82px" CssClass="lbldesign" Runat="server" Visible="False">Net Amount</asp:label><asp:listbox id="lstlabel" style="Z-INDEX: 110; LEFT: 976px; POSITION: absolute; TOP: 832px"
					runat="server" Visible="False"></asp:listbox><asp:listbox id="lstmin" style="Z-INDEX: 111; LEFT: 976px; POSITION: absolute; TOP: 848px" runat="server"
					Visible="False"></asp:listbox>
			<asp:textbox id="txtcur" style="Z-INDEX: 112; LEFT: 976px; POSITION: absolute; TOP: 768px" Height="13px"
					Width="80px" Runat="server" Visible="False"></asp:textbox><asp:listbox id="lsttype" style="Z-INDEX: 113; LEFT: 976px; POSITION: absolute; TOP: 792px" runat="server"
					Height="23px" Width="80px" Visible="False"></asp:listbox>
			<asp:listbox id="lstamt" style="Z-INDEX: 114; LEFT: 976px; POSITION: absolute; TOP: 808px" runat="server"
					Height="24px" Width="80px" Visible="False"></asp:listbox><asp:listbox id="lstFrom" style="Z-INDEX: 115; LEFT: 1056px; POSITION: absolute; TOP: 192px"
					runat="server" Visible="False"></asp:listbox>
				<asp:ListBox id="lstTo" style="Z-INDEX: 116; LEFT: 1056px; POSITION: absolute; TOP: 216px" runat="server"
					Visible="False"></asp:ListBox>
	 	
	 	
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