<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EditQuotation.aspx.vb" Inherits="E_Management.EditQuotation" MasterPageFile="~/ems.Master" Title="Edit Quotation" %>


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
                            <asp:Panel ID="Panel1" runat="server">
			<asp:label id="lblStatus" style="Z-INDEX: 108; LEFT: 155px; POSITION: absolute; TOP: 84px" runat="server"
				Width="689px" Height="24px" ForeColor="Navy" BackColor="#AFD7FF" BorderColor="#AFD7FF"
				BorderStyle="None" BorderWidth="0px" Font-Size="XX-Small" Visible="False"></asp:label>
			<table>
				<tr>
					<td style="WIDTH: 665px; HEIGHT: 37px"></td>
				</tr>
				<tr>
					<td style="WIDTH: 665px; HEIGHT: 25px; background-color: beige;"><asp:label id="lblQno" Width="104px" Height="14px" ForeColor="Red" Runat="server" CssClass="lbldesign">&nbsp;Quotation No. </asp:label><strong><asp:textbox id="txtQuoteno" runat="server" Width="128px" Font-Bold="True" ToolTip="Enter the Quotation No. here"
								ReadOnly="True"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="lblquote" Width="136px" Height="14px" ForeColor="Red" Runat="server" CssClass="lbldesign"
								Visible="False">&nbsp; New Quotation No. </asp:label>&nbsp;&nbsp; <strong>
								<asp:textbox id="txtNewQuoteNo" runat="server" Width="128px" Font-Bold="True" ToolTip="Enter the Quotation No. here"
									Visible="False"></asp:textbox></strong></strong></td>
				</tr>
				<tr>
					<td style="WIDTH: 665px">&nbsp;&nbsp;
						<asp:datagrid id="Grid" runat="server" Width="686px" Height="153px"
							OnCancelCommand="DoItemCancel" OnUpdateCommand="DoItemUpdate" OnEditCommand="DoItemEdit" CellPadding="4"
							AutoGenerateColumns="False" ForeColor="#333333" GridLines="None">
							<EditItemStyle BackColor="#2461BF"></EditItemStyle>
							<HeaderStyle ForeColor="White" BackColor="#507CD1" Font-Bold="True"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="F_Id" HeaderText="ForwarderId"></asp:BoundColumn>
								<asp:BoundColumn DataField="TransportName" HeaderText="Transport Name"></asp:BoundColumn>
								<asp:BoundColumn DataField="VehicleNo" HeaderText="VehicleNo"></asp:BoundColumn>
								<asp:BoundColumn DataField="Departplace" HeaderText="Departure"></asp:BoundColumn>
								<asp:BoundColumn DataField="Arrivalplace" HeaderText="Arrival"></asp:BoundColumn>
								<asp:BoundColumn DataField="Weight" HeaderText="M3/Kg"></asp:BoundColumn>
								<asp:BoundColumn DataField="Amount" HeaderText="Amount"></asp:BoundColumn>
								<asp:BoundColumn DataField="MinimumCharge" HeaderText="Minimum Charge"></asp:BoundColumn>
								<asp:BoundColumn DataField="CurrName" HeaderText="Currency Name"></asp:BoundColumn>
								<asp:BoundColumn DataField="RevisionNo" HeaderText="RevisionNo"></asp:BoundColumn>
								<asp:BoundColumn DataField="EffectiveDate" HeaderText="Effective Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="VesselMode" HeaderText="Container"></asp:BoundColumn>
								<asp:EditCommandColumn UpdateText="Update" HeaderText="Edit" CancelText="Cancel"
									EditText="Edit"></asp:EditCommandColumn>
								<asp:ButtonColumn Visible="False" Text="Delete" HeaderText="Delete" CommandName="Delete"></asp:ButtonColumn>
								<asp:ButtonColumn Text="View" HeaderText="LCL Charges" CommandName="Select"></asp:ButtonColumn>
							</Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" />
                            <ItemStyle BackColor="#EFF3FB" />
						</asp:datagrid></td>
				</tr>
				<tr>
					<td style="WIDTH: 665px; text-align: center;">
                        <br />
                        <asp:datagrid id="LCL" runat="server" Width="480px" Height="88px" Font-Bold="True"
							AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
							<HeaderStyle ForeColor="White" BackColor="#507CD1" Font-Bold="True"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="LCL Charges">
									<ItemTemplate>
										<asp:Label id="lblDesc" runat="server" Text='<%# DataBinder.Eval(container.Dataitem, "OtherFees")%>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Amount">
									<ItemTemplate>
										<asp:Label id="lblAmt" runat="server" Text='<%# DataBinder.Eval(container.Dataitem, "Amount")%>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox id="TxtAmt" Text='<%# DataBinder.Eval(container.Dataitem, "Amount")%>' Runat="server">
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Minimum Amount">
									<ItemTemplate>
										<asp:Label id="lblMin" runat="server" Text='<%# DataBinder.Eval(container.Dataitem, "MinimumAmount")%>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox id="txtMin" Text='<%# DataBinder.Eval(container.Dataitem, "MinimumAmount")%>' Runat="server">
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
							</Columns>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditItemStyle BackColor="#2461BF" />
                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" />
                            <ItemStyle BackColor="#EFF3FB" />
						</asp:datagrid></td>
				</tr>
				<tr>
					<td style="WIDTH: 665px">&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnSave" onmouseover="this.style.backgroundColor='lightsteelblue'; this.style.fontWeight='bold'; this.className='cursor'"
							onmouseout="this.style.backgroundColor='aliceblue'; this.style.fontWeight='normal'" runat="server"
							Width="136px" ForeColor="Black" BackColor="Control" Text="Save Quotation"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnExit" onmouseover="this.style.backgroundColor='lightsteelblue'; this.style.fontWeight='bold'; this.className='cursor'"
							onmouseout="this.style.backgroundColor='aliceblue'; this.style.fontWeight='normal'" runat="server"
							Width="136px" ForeColor="Black" BackColor="Control" Text="Exit"></asp:button></td>
				</tr>
			</table>




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