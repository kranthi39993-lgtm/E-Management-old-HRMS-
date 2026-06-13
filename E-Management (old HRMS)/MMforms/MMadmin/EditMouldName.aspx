<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditMouldName.aspx.vb" Inherits="E_Management.EditMouldName" MasterPageFile="~/ems.Master" Title="Edit Mould Name" %>
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
                        <td colspan="1" style="background-color: #5d7b9d; text-align: center">
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/MMForms/images/back.jpg"
                                Width="35px" /></td>
					    <td style="background-color: #5d7b9d; text-align: left" colspan="2">
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="White" Text="Mould Description Details"></asp:Label></td>
					</tr>
					<tr>
					<td style="width: 173px; background-color: beige;"><asp:Label id="Label4" runat="server" Text="Department Name"></asp:Label></td>
					<td><asp:DropDownList id="CMbDepartment" runat="server" Width="150px" AutoPostBack="True"></asp:DropDownList></td>
					</tr>
					<tr>
					<td colspan="2" style="text-align: center"><asp:GridView id="GridView1" runat="server" ForeColor="#333333" PageSize="20" GridLines="None" DataSourceID="SqlDataSource2" DataKeyNames="FGID,MouldName" CellPadding="4" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
                                    <Columns>
                                        <asp:BoundField DataField="FGID" HeaderText="FGID" ReadOnly="True" SortExpression="FGID" />
                                        <asp:BoundField DataField="MouldName" HeaderText="MouldName" ReadOnly="True" SortExpression="MouldName" />
                                        <asp:BoundField DataField="MouldType" HeaderText="MouldType" SortExpression="MouldType" />
                                        <asp:BoundField DataField="RegisteredBy" HeaderText="RegisteredBy" SortExpression="RegisteredBy" />
                                        <asp:BoundField DataField="RegisteredOn" HeaderText="RegisteredOn" ReadOnly="True"
                                            SortExpression="RegisteredOn" />
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"  />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"  />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                                    <EditRowStyle BackColor="#999999"  />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
                                </asp:GridView><asp:SqlDataSource id="SqlDataSource2" runat="server" SelectCommand="SELECT [FGID], [MouldName], [MouldType], [CreatedBy] as RegisteredBy, Convert(varchar(10),[CreatedOn], 103) as RegisteredOn FROM [RegisterMouldName] Where FGID=@FGID" ConnectionString="<%$ ConnectionStrings:MMaintenanceConnectionString2 %>" DeleteCommand="DELETE from RegisterMouldName Where  FGID=@FGID and MouldName=@MouldName">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="21" Name="FGID" SessionField="fgid"  />
                                    </SelectParameters>
                                    <DeleteParameters>
                                        <asp:Parameter Name="FGID"  />
                                        <asp:Parameter Name="MouldName"  />
                                    </DeleteParameters>
                                </asp:SqlDataSource>
                                </td></tr>
								
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