<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ChangeMouldStatus.aspx.vb" Inherits="E_Management.ChangeMouldStatus"  MasterPageFile="~/ems.Master" Title="Change Mould Status"  %>

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
        <td colspan="7" style="height: 21px; background-color: #5d7b9d; text-align: center">
            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="White" Text="Change Mould Status"></asp:Label></td>
    </tr>
<tr>
<td style="background-color: beige">
    <asp:Label ID="Label1" runat="server" Text="Department Name"></asp:Label></td>
    <td style="width: 126px">
        <asp:DropDownList ID="CmbDepartment" runat="server" Width="150px">
        </asp:DropDownList></td>
        <td><asp:Button ID="Button2" runat="server" Text="View" /></td>
<td style="background-color: beige">
    <asp:Label ID="Label2" runat="server" Text="Product Name"></asp:Label></td><td>
        <asp:DropDownList ID="CmbProduct" runat="server" DataSourceID="SqlDataSource3" DataTextField="fg_desc" DataValueField="fg_desc" Width="150px">
        </asp:DropDownList>
        </td>
        <td><asp:Button ID="Button1" runat="server" Text="View" /></td>
</tr>
    <tr>
        <td>
        </td>
        <td style="width: 126px">
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
<tr>
<td colspan="6" style="text-align: center">

        <asp:GridView id="GridView1" runat="server" Width="394px" ForeColor="#333333" GridLines="None" CellPadding="4" AutoGenerateColumns="False" DataKeyNames="Product,MouldName,MouldNo" AllowSorting="True" AllowPaging="True" DataSourceID="SqlDataSource2" AutoGenerateEditButton="false" PageSize="15">
        <Columns>
        <asp:TemplateField HeaderText="">
            
            <EditItemTemplate>
                <asp:CheckBox ID="ChkBxSelect" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>                
              <asp:CheckBox ID="ChkBxSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            
        <asp:BoundField DataField="UID" HeaderText="UID" ReadOnly="True" SortExpression="UID" ></asp:BoundField>
            <asp:BoundField DataField="Product" HeaderText="Product" ReadOnly="True" SortExpression="Product" ></asp:BoundField>
            <asp:BoundField DataField="MouldName" HeaderText="MouldName" ReadOnly="True" SortExpression="MouldName" ></asp:BoundField>
            <asp:BoundField DataField="MouldNo" HeaderText="MouldNo" ReadOnly="True" SortExpression="MouldNo" ></asp:BoundField>
            <asp:BoundField DataField="MouldType" HeaderText="MouldType" SortExpression="MouldType" ReadOnly="True"></asp:BoundField>
            <asp:BoundField DataField="PressLimit" HeaderText="PressLimit" SortExpression="PressLimit" ReadOnly="false"></asp:BoundField>
            <asp:BoundField DataField="StandByQty" HeaderText="StandByQty" SortExpression="StandByQty" ReadOnly="True"></asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Current Status" SortExpression="Status" ReadOnly="True" ></asp:BoundField>                        
            
            <asp:TemplateField HeaderText="ChangeStatusTo">
            <EditItemTemplate>
                <asp:DropDownList ID="CmbMouldStatus" runat="server" Enabled="true">
                <asp:ListItem Value="-Select-">-Select-</asp:ListItem>                
                <asp:ListItem Value="IN">Internal Service</asp:ListItem>
                <asp:ListItem Value="EX">External Service</asp:ListItem>
                <asp:ListItem Value="S">Scrap</asp:ListItem>
                <asp:ListItem Value="A">Available</asp:ListItem>
                </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                <asp:DropDownList ID="CmbMouldStatus" runat="server" Enabled="true" >
                <asp:ListItem Value="-Select-">-Select-</asp:ListItem>                
                <asp:ListItem Value="M">Internal Service</asp:ListItem>
                <asp:ListItem Value="J">External Service</asp:ListItem>
                <asp:ListItem Value="S">Scrap</asp:ListItem>
                <asp:ListItem Value="A">Available</asp:ListItem>
                </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="ExpectedOn">
            
            <EditItemTemplate>
                <asp:TextBox ID="TxtExpDate" Enabled="true"  runat="server" Width="75PX"></asp:TextBox>                 
                </EditItemTemplate>
                <ItemTemplate>                
                    <asp:TextBox ID="TxtExpDate" Enabled="true" runat="server"  Width="75PX"></asp:TextBox>               
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="MouldNo">
            
            <EditItemTemplate>
                <asp:TextBox ID="TxtMouldNo" Enabled="true"  runat="server" Width="50PX"></asp:TextBox>                 
                </EditItemTemplate>
                <ItemTemplate>                
                    <asp:TextBox ID="TxtMouldNo" Enabled="true" runat="server"  Width="50PX"></asp:TextBox>               
                </ItemTemplate>
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText="Press Limit">
            
            <EditItemTemplate>
                <asp:TextBox ID="TxtPressLimit" Enabled="true"  runat="server" Width="75PX"></asp:TextBox>                 
                </EditItemTemplate>
                <ItemTemplate>                
                    <asp:TextBox ID="TxtPressLimit" Enabled="true" runat="server"  Width="75PX"></asp:TextBox>               
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"  />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"  />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
        <EditRowStyle BackColor="#999999"  />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
    </asp:GridView>
   
    </td>
</tr>
            <tr>
                <td colspan="9" style="text-align: center">
                    <asp:Button ID="Button3" runat="server" Text="Save Status" /></td>
            </tr>
            <tr>
                <td colspan="9" style="text-align: center">
                    <asp:Label ID="LblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label></td>
            </tr>
    <tr>
        <td colspan="1" style="text-align: center">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MMaintenanceConnectionString %>"
                DeleteCommand="Sp_DelMoulds" DeleteCommandType="StoredProcedure" SelectCommand="SELECT Product, MouldNo, MouldType, PressLimit, Remarks, status, expdate,pressmc, StandByQty  FROM  MouldMaster Where FGID=@FGID ORDER BY  FGID, Product, MouldNo">
                <DeleteParameters>
                    <asp:Parameter Name="Product" Type="String" />
                    <asp:Parameter Name="MouldNo" Type="String" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="21" Name="FGID" SessionField="fgid" />
                </SelectParameters>
            </asp:SqlDataSource>
            &nbsp;
        </td>
        <td colspan="2" style="text-align: center">
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MMaintenanceConnectionString2 %>"
        SelectCommand="SelectAll_MouldMaster" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="null" Name="Product" SessionField="product" Type="String" />
            <asp:SessionParameter DefaultValue="21" Name="FGID" SessionField="fgid" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
        </td>
        <td colspan="6" style="text-align: center">
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:mmCRMConnectionString %>"
                SelectCommand="select Distinct  fg_desc from productmaster where fg_group = @fgid order by fg_desc">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="21" Name="fgid" SessionField="fgid" />
                </SelectParameters>
            </asp:SqlDataSource>
            &nbsp;
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