<%@ Page Language="vb" AutoEventWireup="false" Codebehind="QuotationListing.aspx.vb" Inherits="E_Management.QuotationListing" MasterPageFile="~/ems.Master" Title="Quotation Details" %>

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
                            
                            


			<table>
				<tr>
					<td style="WIDTH: 665px; HEIGHT: 37px; background-color: beige;"><asp:label id="lblFWName" runat="server" Width="128px">Forwarders Name</asp:label><asp:dropdownlist id="ddlfid" runat="server" Width="152px" AutoPostBack="True"></asp:dropdownlist><asp:textbox id="txtfid" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 665px; HEIGHT: 15px; background-color: beige;"><asp:radiobuttonlist id="RadBtnQuotLst" runat="server" Width="616px" RepeatDirection="Horizontal" AutoPostBack="True"
							Font-Bold="True" Height="24px" ForeColor="Navy">
							<asp:ListItem Value="Approval Pending">Approval Pending</asp:ListItem>
							<asp:ListItem Value="On Hold">On Hold</asp:ListItem>
							<asp:ListItem Value="Approved">Approved Quotations</asp:ListItem>
							<asp:ListItem Value="Rejected">Rejected</asp:ListItem>
						</asp:radiobuttonlist></td>
				</tr>
				<tr>
					<td style="WIDTH: 665px">&nbsp;&nbsp;
						<asp:Label id="Label1" runat="server" ForeColor="Magenta" Font-Size="X-Small">** To Edit the Quotation Click on the respective Quotation Number</asp:Label>
						<asp:datagrid id="Grid" runat="server" Width="690px" EnableViewState="False" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None">
							<FooterStyle ForeColor="White" BackColor="#507CD1" Font-Bold="True"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#333333" BackColor="#D1DDF1"></SelectedItemStyle>
							<ItemStyle BackColor="#EFF3FB"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#507CD1"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Quotation Number">
									<ItemTemplate>
										<a href='<%# String.Concat("EditQuotation.aspx?FQNo=",DataBinder.Eval(Container.DataItem,"FQNo")) %>'>
											<%# DataBinder.Eval(Container.DataItem,"FQNo") %>
										</a>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Date">
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CreatedDate") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox runat="server"></asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Approval Status">
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ApprovedStatus") %>' >
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox runat="server"></asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" ForeColor="White" BackColor="#2461BF"></PagerStyle>
                            <EditItemStyle BackColor="#2461BF" />
                            <AlternatingItemStyle BackColor="White" />
						</asp:datagrid></td>
				</tr>
				<tr>
					<td style="WIDTH: 665px">&nbsp;&nbsp;
						<asp:button id="btnExit" onmouseover="this.style.backgroundColor='lightsteelblue'; this.style.fontWeight='bold'; this.className='cursor'"
							onmouseout="this.style.backgroundColor='aliceblue'; this.style.fontWeight='normal'" runat="server"
							Width="136px" ForeColor="Black" BackColor="Control" Text="Exit"></asp:button></td>
				</tr>
			</table>
			<asp:label id="lblHead" style="Z-INDEX: 101; LEFT: 120px; POSITION: absolute; TOP: 98px" runat="server"
				Width="689px" Height="24px" ForeColor="Navy" BackColor="#AFD7FF" BorderStyle="None" BorderColor="#AFD7FF"
				BorderWidth="0px" Font-Size="XX-Small" Visible="False"></asp:label>



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