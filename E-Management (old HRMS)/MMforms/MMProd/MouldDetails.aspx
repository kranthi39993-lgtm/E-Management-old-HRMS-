<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MouldDetails.aspx.vb" Inherits="E_Management.MouldDetails" MasterPageFile="~/ems.Master" Title="Mould Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding="0" cellspacing="0" align="center">
	<tr>
					<td width="16"><IMG height="16" src="/images/top_lef.gif" width="16"></td>
					<td background="/images/top_mid.gif" height="16"><img  alt=""  height="16" src="/images/top_mid.gif" width="16" /></td>
					<td width="24"><img  alt=""  height="16" src="/images/top_rig.gif" width="24" /></td>
				</tr>
				<tr>
					<td width="16" background="/images/cen_lef.gif"><img  alt=""  height="11" src="/images/cen_lef.gif" width="16" /></td>
					<td valign="top" bgcolor="#ffffff">
					
					
					<table>
					<tr>
					<td colspan="5" style="background-color: #5d7b9d; text-align: center"> 
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#FFFFFF" Text="Mould Details"></asp:Label></td>
					</tr>
					
					<tr>
					<td>
                        <asp:Label ID="Label1" runat="server" Text="Department"></asp:Label></td>
					<td>
                        <asp:DropDownList ID="CmbDepartment" runat="server">
                        </asp:DropDownList></td>
					<td>
                        <asp:Label ID="Label2" runat="server" Text="Mould Status"></asp:Label></td>
					<td>
                        <asp:DropDownList ID="CmbMouldStatus" runat="server">
                            <asp:ListItem>-Select-</asp:ListItem>
                            <asp:ListItem Value="A">Available</asp:ListItem>
                            <asp:ListItem Value="I">Issued</asp:ListItem>
                            <asp:ListItem Value="M">Internal Service</asp:ListItem>
                            <asp:ListItem Value="J">External Service</asp:ListItem>
                            <asp:ListItem Value="S">Scrap</asp:ListItem>
                        </asp:DropDownList></td>					
					<td>
                        <asp:Button ID="Button1" runat="server" Text="View" /></td>
					</tr>
                        <tr>
                            <td colspan="5" style="text-align: center">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product" />
                                        <asp:BoundField DataField="MouldName" HeaderText="MouldName" SortExpression="MouldName" />
                                        <asp:BoundField DataField="MouldNo" HeaderText="MouldNo" SortExpression="MouldNo" />
                                        <asp:BoundField DataField="MouldType" HeaderText="MouldType" SortExpression="MouldType" />
                                        <asp:BoundField DataField="PressLimit" HeaderText="PressLimit" SortExpression="PressLimit" />
                                        <asp:BoundField DataField="StandByQty" HeaderText="StandByQty" SortExpression="StandByQty" />
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MMaintenanceConnectionString2 %>"
                                    SelectCommand="SELECT     Product, MouldName, MouldNo, MouldType, PressLimit, StandByQty&#13;&#10;FROM         MouldMaster Where Status=@Status and FGID=@FGID">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="CmbMouldStatus" Name="Status" PropertyName="SelectedValue" />
                                        <asp:SessionParameter DefaultValue="21" Name="FGID" SessionField="fgid" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
					</table>
					
					
					
					
					
					
					 </td>
					<td width="24" background="/images/cen_rig.gif">
					<img height="11" src="/images/cen_rig.gif" width="24" alt="" /></td>
				</tr>
				<tr>
					<td width="16" height="16"><img height="16"  alt="" src="/images/bot_lef.gif" width="16" /></td>
					<td background="/images/bot_mid.gif" height="16"><img  alt="" height="16" src="/images/bot_mid.gif" width="16" /></td>
					<td width="24" height="16"><img alt="" height="16" src="/images/bot_rig.gif" width="24" /></td>
				</tr>
			</table>
</asp:Content>