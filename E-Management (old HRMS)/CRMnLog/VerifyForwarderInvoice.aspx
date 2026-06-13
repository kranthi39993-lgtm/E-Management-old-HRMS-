<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VerifyForwarderInvoice.aspx.vb" Inherits="E_Management.VerifyForwarderInvoice" MasterPageFile="~/ems.Master" Title="Verify Forwarder Invoice"%>

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
                                        <td style="width: 100px; height: 59px; background-color: #336699;">
                                            <br />
                                            <span style="font-size: 14pt; color: #ffffff;"><strong>
                                            Verify Forwarder Invoice<br />
                                            </strong></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:DataGrid ID="DGrid1" runat="server" CellPadding="4" Width="321px" OnCancelCommand="FunCancel" OnEditCommand="FunEdit" OnUpdateCommand="FunUpdate" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None">
                                                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <ItemStyle BackColor="#EFF3FB" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                <asp:BoundColumn DataField="UID" HeaderText="RefNo" ReadOnly=True></asp:BoundColumn>
                                                <asp:BoundColumn DataField="InvoiceNo" HeaderText="InvoiceNo" ReadOnly=True></asp:BoundColumn>
                                                <asp:BoundColumn DataField="DepartmentName" HeaderText="DepartmentName" ReadOnly=True></asp:BoundColumn>
                                                <asp:BoundColumn DataField="FInvSubmissionDate" HeaderText="Forwarder Inv Submission Date" ReadOnly=True></asp:BoundColumn>
                                                <asp:BoundColumn DataField="ForwarderName" HeaderText="Forwarder Name" ReadOnly=True></asp:BoundColumn>
                                                <asp:BoundColumn DataField="ArrivalPlace" HeaderText="Arrival Place" ReadOnly=True></asp:BoundColumn>
                                                <asp:BoundColumn DataField="DepartPlace" HeaderText="Depart Place" ReadOnly=True></asp:BoundColumn>
                                                <asp:BoundColumn DataField="ForwarderInvoiceNo" HeaderText="Forwarder Invoice No" ReadOnly=True></asp:BoundColumn>
                                                <asp:BoundColumn DataField="QuotedAmount" HeaderText="QuotedAmount" ReadOnly=True></asp:BoundColumn>
                                                <asp:BoundColumn DataField="ForwarderInvoiceValue" HeaderText="ForwarderInvoiceValue" ReadOnly=True></asp:BoundColumn>
                                                <asp:BoundColumn DataField="Difference" HeaderText="Difference" ReadOnly=True></asp:BoundColumn>
                                                <asp:BoundColumn DataField="Remarks" HeaderText="Remarks" ReadOnly=True></asp:BoundColumn>
                                                <asp:EditCommandColumn CancelText="Reject" UpdateText="Verify" EditText="Verify / Reject" ButtonType="PushButton">                                                
                                                </asp:EditCommandColumn> 
                                                </Columns>                                            
                                                <EditItemStyle BackColor="#2461BF" />
                                                <AlternatingItemStyle BackColor="White" />
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 27px;">
                                            <asp:Button ID="Button1" runat="server" Text="Exit" Width="76px" /></td>
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
            <td width="16" style="height: 1px">
                <img height="16" src="../images/bot_lef.gif" width="16" /></td>
            <td background="../images/bot_mid.gif" style="height: 1px">
                <img height="16" src="../images/bot_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 1px;">
                <img height="16" src="../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>



</asp:Content>