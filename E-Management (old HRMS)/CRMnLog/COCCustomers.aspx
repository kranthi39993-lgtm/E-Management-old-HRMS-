<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="COCCustomers.aspx.vb" Inherits="E_Management.COCCustomers" Title="COC Customers" MasterPageFile="~/ems.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	
<table  cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../images/top_lef.gif" width="16"/></td>
            <td background="../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../images/cen_lef.gif"  width="16">
                <img height="11" src="../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" valign="top">
                <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px">
                            <asp:Panel ID="Panel1" runat="server">
                                <table>
                                    <tr>
                                        <td style="width: 100px; text-align: center;">
                                            <strong>
                                                <br />
                                                Assign COC Customer <br />
                                                


<asp:GridView ID="DGView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="181px" Width="506px">




<Columns>

<asp:TemplateField>
<ItemTemplate>
<asp:CheckBox ID="ChkBx1" runat="server" />
</ItemTemplate>
</asp:TemplateField>

<asp:BoundField  HeaderText="Customer Id" DataField="Cust_Id" >
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>
<asp:BoundField HeaderText="Customer Name" DataField="CuStomer" >
    <ItemStyle HorizontalAlign="Left" />
</asp:BoundField>

<asp:TemplateField HeaderText="Form Type">
<ItemTemplate >
<asp:DropDownList ID="FrmType1" runat="server">
<asp:ListItem>-Select-</asp:ListItem>
<asp:ListItem>Form A</asp:ListItem>
<asp:ListItem>Form AK</asp:ListItem>
<asp:ListItem>Form D</asp:ListItem>
<asp:ListItem>Form E</asp:ListItem>
<asp:ListItem>ACF7A</asp:ListItem>
</asp:DropDownList>
</ItemTemplate>
</asp:TemplateField>


</Columns>
    <RowStyle BackColor="#EFF3FB" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
                                                <br />
                                            </strong>
                                            <br />
                                            <asp:Button ID="Button1" runat="server" Text="Save" Width="70px" />
                                            <asp:Button ID="Button2" runat="server" Text="Exit" Width="70px" />&nbsp;</td>
                                    </tr>
                                </table>








</asp:Panel>
                        </td>
                    </tr>
                </table>
</td>                
  <td background="../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../images/bot_lef.gif" width="16" /></td>
            <td background="../images/bot_mid.gif" height="16">
                <img height="16" src="../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>
