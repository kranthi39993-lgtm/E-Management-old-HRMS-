<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ApprovedForwarderInvoices.aspx.vb" Inherits="E_Management.ApprovedForwarderInvoices" MasterPageFile="~/ems.Master" %>

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
            <td bgcolor="#ffffff" valign="top" style="text-align: center">
                <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px; text-align: right;">
                            <asp:Panel ID="Panel1" runat="server">
                            <h3 style="text-align: center">
                                <strong>Forwarder Invoice Details (Approved by EA)</strong></h3>
   
    
    
    
   <asp:GridView id="DGView1" runat="server" Height="181px" Width="506px" ForeColor="#333333" GridLines="None" CellPadding="4" AutoGenerateColumns="False">

<Columns>

<asp:TemplateField>
<ItemTemplate>
<asp:CheckBox ID="ChkBx1" runat="server"/>
</ItemTemplate>
</asp:TemplateField>

<asp:BoundField  HeaderText="UID" DataField="UID" >
    <ItemStyle HorizontalAlign="Left"  />
</asp:BoundField>


<asp:BoundField  HeaderText="InvoiceNo" DataField="InvoiceNo" >
    <ItemStyle HorizontalAlign="Left"  />
</asp:BoundField>

<asp:BoundField HeaderText="DepartmentName" DataField="DepartmentName" >
    <ItemStyle HorizontalAlign="Left"  />
</asp:BoundField>

<asp:BoundField HeaderText="ForwarderName" DataField="ForwarderName" >
    <ItemStyle HorizontalAlign="Left"  />
</asp:BoundField>

<asp:BoundField HeaderText="ArrivalPlace" DataField="ArrivalPlace" >
    <ItemStyle HorizontalAlign="Left"  />
</asp:BoundField>

<asp:BoundField HeaderText="DepartPlace" DataField="DepartPlace" >
    <ItemStyle HorizontalAlign="Left"  />
</asp:BoundField>

<asp:BoundField HeaderText="ForwarderInvoiceNo" DataField="ForwarderInvoiceNo" >
    <ItemStyle HorizontalAlign="Left"  />
</asp:BoundField>

<asp:BoundField HeaderText="QuotedAmount" DataField="QuotedAmount" >
    <ItemStyle HorizontalAlign="Right"  />
</asp:BoundField>

<asp:BoundField HeaderText="ForwarderInvoiceValue" DataField="ForwarderInvoiceValue" >
    <ItemStyle HorizontalAlign="Right"  />
</asp:BoundField>

<asp:BoundField HeaderText="Difference" DataField="Difference" >
    <ItemStyle HorizontalAlign="Right"  />
</asp:BoundField>

<asp:BoundField HeaderText="Remarks" DataField="Remarks" >
    <ItemStyle HorizontalAlign="Left"  />
</asp:BoundField>

</Columns>
    <RowStyle BackColor="#EFF3FB"  />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center"  />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"  />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  />
    <EditRowStyle BackColor="#2461BF"  />
    <AlternatingRowStyle BackColor="White"  />
</asp:GridView>

</asp:Panel>
                            &nbsp;
                            <asp:Label ID="Label1" runat="server" Visible="False">Total Amount : </asp:Label>
                            <asp:Label ID="LblAmount" runat="server" Visible="False"></asp:Label></td>
                    </tr>
                </table>
                <asp:Button ID="Button1" runat="server" Text="Post to BizTrak" />&nbsp;<asp:Button
                    ID="Button2" runat="server" Text="Exit" /></td>                
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