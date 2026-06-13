<%@ Page Language="vb" AutoEventWireup="false" Codebehind="QuotationApprovalMaster.aspx.vb" Inherits="E_Management.QuotationApprovalMaster" MasterPageFile="~/ems.Master"  Title="Quotation Approval"%>
<%--<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.5000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
--%>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	
<table><tr><td>
			<table cellpadding="0" cellspacing="0" align="left" width="300">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../images/top_lef.gif" width="16"  alt=""/></td>
            <td background="../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../images/top_mid.gif" width="16"  alt="" /></td>
            <td style="width: 36px; height: 16px;">
                <img height="16" src="../images/top_rig.gif" width="24"  alt="" /></td>
        </tr>
        <tr>
            <td background="../images/cen_lef.gif"  width="16">
                <img height="11" src=    "../images/cen_lef.gif" width="16"  alt="" /></td>
            <td bgcolor="#ffffff" valign="top">
            <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 335px">
                            <asp:Panel ID="Panel1" runat="server">
                                &nbsp;<table>
				<tbody>
                    <tr>
                        <td colspan="6" style="background-color: beige" >
                            Select the Quotation Type<br />
                            <br />
							<asp:radiobuttonlist id="rblType" runat="server" Width="462px" Height="16px" AutoPostBack="True" RepeatDirection="Horizontal">
								<asp:ListItem Value="Pending">Pending</asp:ListItem>
								<asp:ListItem Value="Approved">Approved</asp:ListItem>
								<asp:ListItem Value="OnHold">OnHold</asp:ListItem>
								<asp:ListItem Value="Rejected">Rejected</asp:ListItem>
							</asp:radiobuttonlist></td>
                    </tr>
                    <tr>
                        <td colspan="7" style="height: 37px; text-align: center">
                            &nbsp;
							<asp:button id="btnSubmit" runat="server" Width="84px" Height="21px" BorderWidth="1px" BorderStyle="Solid"
								BorderColor="ActiveCaptionText" BackColor="Control" Text="Submit"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="Button1" runat="server" Width="84" Height="21" BorderWidth="1px" BorderStyle="Solid"
								BorderColor="ActiveCaptionText" BackColor="Control" Text="Hide Details"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="btnExit" runat="server" Width="84px" Height="21px" BorderWidth="1px" BorderStyle="Solid"
								BorderColor="ActiveCaptionText" BackColor="Control" Text="Exit"></asp:button></td>
					</tr>
					<tr>
						<td style="WIDTH: 55px; HEIGHT: 296px" colspan="6">
                            &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
							<asp:datagrid id="dg" runat="server" Height="285px" Width="396px" 
								HeaderStyle-BackColor="#003399" HeaderStyle-ForeColor="#ffffff" PageSize="6" OnPageIndexChanged="dg_PageIndexChanged"
								AutoGenerateColumns="False">
								<AlternatingItemStyle BorderColor="LightBlue"></AlternatingItemStyle>
								<HeaderStyle Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center"
									ForeColor="White" BackColor="#003399"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="SNo">
										<ItemTemplate>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Quote No.">
										<ItemTemplate>
											<asp:Label id="lblQNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FQNo") %>'>></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="ForwarderID">
										<ItemTemplate>
											<asp:Label id="LblFID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"F_id") %>'>></asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"F_id") %>' ID="Textbox1">
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Status">
										<ItemTemplate>
											<asp:RadioButtonList ID="rbList" Runat="server">
												<asp:ListItem>Approved</asp:ListItem>
												<asp:ListItem>On Hold</asp:ListItem>
												<asp:ListItem>Rejected</asp:ListItem>
											</asp:RadioButtonList>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:EditCommandColumn Visible="False" UpdateText="Update" HeaderText="View" CancelText="Cancel"
										EditText="View"></asp:EditCommandColumn>
									<asp:ButtonColumn Text="View" HeaderText="View Details" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle Width="25px" HorizontalAlign="Right" PageButtonCount="50" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
					
					<tr>
						<td style="WIDTH: 55px; HEIGHT: 37px; text-align: center;" colspan="6"></td>
					</tr>
					<tr>
						<td style="WIDTH: 55px; HEIGHT: 37px; text-align: center;" colspan="6"></td>
					</tr>
				</tbody>
			</table>

			<asp:textbox id="txtfid" style="Z-INDEX: 104; LEFT: 723px; POSITION: absolute; TOP: 39px" Width="112px"
				Height="22" Visible="False" Runat="server"></asp:textbox>


</asp:Panel>
                        </td>
                    </tr>
                </table>
                </td>
				  <td background="../images/cen_rig.gif" style="width: 36px">
                <img height="11" src="../images/cen_rig.gif" width="24"  alt="" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../images/bot_lef.gif" width="16"  alt="" /></td>
            <td background="../images/bot_mid.gif" height="16">
                <img height="16" src="../images/bot_mid.gif" width="16"  alt="" /></td>
            <td height="16" style="width: 36px">
                <img height="16" src="../images/bot_rig.gif" width="24" alt="" /></td>
        </tr>
        
        <tr>
        <td colspan="4">
            &nbsp;</td>
        </tr>
        
    </table>
    			</td>
<td valign="top">
    &nbsp;<asp:datagrid id="detailsgrid" runat="server" Width="696px" Height="135px"
								Font-Bold="True" CellPadding="4" ForeColor="#333333" GridLines="None">
								<AlternatingItemStyle BorderColor="DeepSkyBlue" BackColor="White"></AlternatingItemStyle>
								<HeaderStyle ForeColor="White" BackColor="#507CD1" Font-Bold="True"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn Text="View" HeaderText="OtherExpenses" CommandName="Select"></asp:ButtonColumn>
								</Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#2461BF" />
                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <ItemStyle BackColor="#EFF3FB" />
							</asp:datagrid><asp:datagrid id="feesgrid" runat="server" Width="263px" Height="88px"
								Font-Bold="True" Visible="False" CellPadding="4" ForeColor="#333333" GridLines="None">
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#507CD1"></HeaderStyle>
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditItemStyle BackColor="#2461BF" />
                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" />
                            <ItemStyle BackColor="#EFF3FB" />
							</asp:datagrid></td></tr>
</table>
				<asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
		</asp:Content>