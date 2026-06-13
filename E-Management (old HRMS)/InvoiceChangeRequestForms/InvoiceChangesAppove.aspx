<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InvoiceChangesAppove.aspx.vb" MasterPageFile="~/ems.Master" Inherits="E_Management.InvoiceChangesAppove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

    <table cellpadding="5" cellspacing="0" border="0" width="100%">
          <tr>
              <td align="left" style="background-color: #0066cc; text-align: center">
                  <strong><span style="color: #ffffff;">APPLIED - REQUEST DETAILS</span></strong></td>
          </tr>
          <tr>
              <td align="center">
                  <asp:Label ID="lblCreatedBy" runat="server" Text="Label"></asp:Label>
                  <asp:Label ID="lblMsg" runat="server"></asp:Label></td>
          </tr>
        
                  <tr>
                  <td align="left" style="height: 134px">                 
                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" Height="238px" OnRowCommand="GridView1_RowCommand" AllowPaging="True" PageSize="20" CellPadding="2" ForeColor="#333333" GridLines="None">
                      <Columns>
                      
                      
                    <asp:BoundField DataField="INVNo" HeaderText="InvoiceNo" />
                    <asp:BoundField DataField="cust_id" HeaderText="CustomerID" />
                    <asp:BoundField DataField="Customer" HeaderText="CustomerName" />
                    <asp:BoundField DataField="INVDate" DataFormatString="{0:d}" HeaderText="InvoiceDate" />
                    <asp:BoundField DataField="SoldTo" HeaderText="SoldTo"/>
                    <asp:BoundField DataField="ShipTo" HeaderText="ShipTo" />
                    <asp:BoundField DataField="Attn" HeaderText="Attn" />
                    <asp:BoundField DataField="Destination" HeaderText="Destination" />
                    <asp:BoundField DataField="CreatedBy" HeaderText="Created By" />
					<asp:BoundField DataField="Status" HeaderText="status" />
					 <asp:TemplateField HeaderText="Approve">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" Text="Approve" runat="server" CommandName="approve" CommandArgument="<%# Container.DataItemIndex %>" />
            </ItemTemplate>
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Reject">
           <ItemTemplate>
                <asp:LinkButton ID="LinkButton3" Text="Reject" runat="server" CommandName="reject" CommandArgument="<%# Container.DataItemIndex %>" />
            </ItemTemplate>
           </asp:TemplateField>
              <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="window.open('InvoiceView.aspx?&id=<%# Eval("INVNo") %>&sinfo=waiting','Popup','width=800px,height=900px,scrollbars=yes')">View</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                           
           
                      </Columns>
                          <RowStyle BackColor="#EFF3FB" />
                          <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                          <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
                          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <EditRowStyle BackColor="#2461BF" />
                          <AlternatingRowStyle BackColor="White" />
                  </asp:GridView>
                      <br /><br /><br />
                  </td>
                  </tr>
                  
                  
                  <tr><td>
                      <strong><span></span></strong></td></tr>
        <tr>
            <td align="left" height="25">
            </td>
        </tr>
        <tr>
            <td align="left" style="background-color: #0066cc; text-align: center">
                <strong><span style="color: #ffffff">APPROVED INVOICES</span></strong></td>
        </tr>
                  
                  <tr>
                 
                  <td align="left" style="height: 134px">                 
                      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="GridView1_RowCommand" AllowPaging="True" PageSize="20" CellPadding="2" ForeColor="#333333" GridLines="None">
                      <Columns>
                      
                      
                    <asp:BoundField DataField="INVNo" HeaderText="InvoiceNo" />
                    <asp:BoundField DataField="cust_id" HeaderText="CustomerID" />
                    <asp:BoundField DataField="Customer" HeaderText="CustomerName" />
                    <asp:BoundField DataField="INVDate" DataFormatString="{0:d}" HeaderText="InvoiceDate" />
                    <asp:BoundField DataField="SoldTo" HeaderText="SoldTo"/>
                    <asp:BoundField DataField="ShipTo" HeaderText="ShipTo" />
                    <asp:BoundField DataField="Attn" HeaderText="Attn" />
                    <asp:BoundField DataField="Destination" HeaderText="Destination" />
                    <asp:BoundField DataField="CreatedBy" HeaderText="Created By" />
					<asp:BoundField DataField="Status" HeaderText="status" />
					 
              <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="window.open('InvoiceView.aspx?&id=<%# Eval("INVNo") %>','Popup','width=800px,height=700px,scrollbars=yes')">View</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                 
           
           
                      </Columns>
                          <RowStyle BackColor="#EFF3FB" />
                          <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                          <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
                          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <EditRowStyle BackColor="#2461BF" />
                          <AlternatingRowStyle BackColor="White" />
                  </asp:GridView>
                      
                  </td>
                  </tr>
                  
                  <tr>
                  <td><br /><br /><asp:Panel ID="Panel1" runat="server" Width="682px">
                  <table>
                  <TR>
                  <td style="background-color: #0066cc; text-align: center;">
                      <strong><span style="color: #ffffff">Open or Release 6 PM Rule /</span></strong></td>
                  <td style="background-color: #0066cc; text-align: center;">
                      <strong><span style="color: #ffffff; background-color: #0066cc; text-align: center;">Delivery Schedule /</span></strong></td>
                  <td style="background-color: #0066cc; text-align: center;">
                      <strong><span style="color: #ffffff; background-color: #0066cc; text-align: center;">Packinglist Verification</span></strong></td>
                  </TR>
                  <tr>
                  <td><asp:Button ID="btn6pmrule" runat="server" Text="Button" OnClick="btn6pmrule_Click" Font-Bold="True" /></td>
                  <td><asp:Button ID="btndeliveryschedule" runat="server" Text="Button" OnClick="btndeliveryschedule_Click" Font-Bold="True" /></td>
                  <td><asp:Button ID="btnpackagingList" runat="server" Text="Button" OnClick="btnpackagingList_Click" Font-Bold="True" /></td></tr>
                  </table>  
                  </asp:Panel></td>
          
             
          </tr>
          
      </table>
 
</asp:Content>