<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MouldStatusAlert.aspx.vb" Inherits="E_Management.MouldStatusAlert"  MasterPageFile="~/ems.Master" Title="Mould Status Alert" %>
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
					<td colspan="2" style="background-color: #5d7b9d; text-align: center">
                        <asp:Label ID="Label1" runat="server" Text="Mould Stand By Qty Status Alert" Font-Bold="True" ForeColor="#FFFFFF"></asp:Label></td>					
                    </tr>
                        <tr>
                            <td style="width: 82px; background-color: beige">
                                <asp:Label ID="Label2" runat="server" Text="Department"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="CmbDepartment" runat="server" AutoPostBack="True" Width="125px">
                                </asp:DropDownList></td>
                        </tr>
					<tr>
					<td colspan="2" style="text-align: center">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="FGID" HeaderText="FGID" SortExpression="FGID" />
                                <asp:BoundField DataField="Product" HeaderText="Product" SortExpression="Product" />
                                <asp:BoundField DataField="MouldName" HeaderText="MouldName" SortExpression="MouldName" />
                                <asp:BoundField DataField="TotalMould" HeaderText="TotalMould" ReadOnly="True" SortExpression="TotalMould" />
                                <asp:BoundField DataField="Running" HeaderText="Running" ReadOnly="True" SortExpression="Running" />
                                <asp:BoundField DataField="Available" HeaderText="Available" ReadOnly="True" SortExpression="Available" />
                                <asp:BoundField DataField="StandByQty" HeaderText="StandByQty" SortExpression="StandByQty" />
                                <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status" />
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
                            <td colspan="2">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MMaintenanceConnectionString2 %>"
                                    SelectCommand="Select FGID, Product, MouldName, Count(StandByQty) as TotalMould, (Count(StandByQty)-sum(case when status='A' Then 1 else 0 End)) as Running , sum(case when status='A' Then 1 else 0 End) as Available, StandByQty,  Case When sum(case when status='A' Then 1 else 0 End)<standbyqty Then 'Insufficient' else 'Sufficient' End as Status from MouldMaster Where FGID=@FGID  Group By FGID, Product, MouldName, StandByQty Order By Status">
                                    <SelectParameters>
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
