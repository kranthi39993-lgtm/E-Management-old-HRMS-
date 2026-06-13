<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ShippingDetails.aspx.vb" Inherits="E_Management.ShippingDetails" MasterPageFile="~/ems.Master" Title="Shipping Details" %>

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
                            <tr><td colspan="2" style="height: 35px; background-color: #336699">
                                <strong><span style="color: #ffffff">Shipping Details</span></strong></td></tr>
                            <tr><td style="width: 62px; text-align: left; height: 26px; background-color: beige;">
                                <asp:Label ID="Label1" runat="server" Text="Invoice No" Width="180px"></asp:Label></td><td style="text-align: left">
                                <asp:DropDownList ID="CmbInvoiceNo" runat="server" Width="250px" AutoPostBack="True">
                                </asp:DropDownList></td></tr>
                                <tr>
                                    <td style="width: 62px; text-align: left; height: 26px; background-color: beige;">
                                Invoice Date</td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="TxtInvoiceDate" runat="server" ReadOnly="True" Width="250px"></asp:TextBox>(MM/DD/YYYY)</td>
                                </tr>
                                <tr>
                                    <td style="width: 62px; text-align: left; height: 26px; background-color: beige;">
                                        <asp:Label ID="Label2" runat="server" Text="Customer Name" Width="171px"></asp:Label></td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="TxtCustomerName" runat="server" ReadOnly="True" Width="250px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 62px; text-align: left; height: 26px; background-color: beige;">
                                        Address</td>
                                    <td style="height: 22px; text-align: left">
                                        <asp:TextBox ID="TxtCustomerAddress" runat="server" ReadOnly="True" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 62px; height: 26px; text-align: left; background-color: beige;">
                                        Shipping Terms</td>
                                    <td style="height: 26px; text-align: left">
                                        <asp:TextBox ID="TxtShippingTerms" runat="server" ReadOnly="True" Width="250px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 62px; text-align: left; height: 26px; background-color: beige;">
                                        Destination</td>
                                    <td style="height: 22px; text-align: left">
                                        <asp:TextBox ID="TxtDestination" runat="server" ReadOnly="True" Width="250px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 62px; height: 26px; text-align: left; background-color: beige;">
                                        Transit By</td>
                                    <td style="height: 26px; text-align: left">
                                        <asp:TextBox ID="TxtTransitBy" runat="server" ReadOnly="True" Width="250px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 55px; height: 26px; background-color: beige; text-align: right">
                                        Make Visible
                                        <asp:Button ID="Button4" runat="server" Text="On" Width="75px" /></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="width: 55px; height: 26px; background-color: beige; text-align: left">
                                        <asp:Label ID="LblDestination1" runat="server" Text="From Company to Port / Airport" Width="208px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; height: 81px;" colspan="2">
                                    <table><td><asp:Label ID="LblFrom1" runat="server" Text="From"></asp:Label></td><td><asp:DropDownList ID="CmbFrom1" runat="server" Width="163px" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                        <td>
                                            <asp:Label ID="LblTo1" runat="server" Text="To"></asp:Label></td>
                                        <td>
                                    <asp:DropDownList ID="CmbTo1" runat="server" Width="163px" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                        <tr>
                                            <td style="height: 24px">
                                        <asp:Label ID="LblTransport1" runat="server" Text="Tranport Name" Width="107px"></asp:Label></td>
                                            <td style="height: 24px">
                                        <asp:DropDownList ID="CmbTransport1" runat="server" AutoPostBack="True" Width="163px">
                                        </asp:DropDownList></td>
                                            <td style="height: 24px">
                                        <asp:Label ID="LblForwarder1" runat="server" Text="Select Forwarder" Width="111px"></asp:Label></td>
                                            <td style="height: 24px">
                                        <asp:DropDownList ID="CmbForwarder1" runat="server" Width="163px" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 26px">
                                        <asp:Label ID="LblAFee1" runat="server" Text="Actual Fee" Width="75px"></asp:Label></td>
                                            <td style="height: 26px">
                                        <asp:TextBox ID="TxtAFee1" runat="server" Width="163px">0</asp:TextBox></td>
                                            <td style="height: 26px">
                                        <asp:Label ID="LblRemarks1" runat="server" Text="Remarks" Width="111px" Visible="False"></asp:Label><br />
                                                <asp:Label ID="LblQFee1" runat="server" Text="As per Quotation" Visible="False" Width="111px"></asp:Label></td>
                                            <td style="height: 26px">
                                        <asp:TextBox
                                            ID="TxtRemarks1" runat="server" Visible="False" Width="163px" TextMode="MultiLine">-</asp:TextBox><br />
                                                <asp:TextBox ID="TxtQFee1" runat="server" Visible="False" Width="163px">0</asp:TextBox></td>
                                        </tr>
                                    </table>
                                        
                                        </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="DGrid1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                            Height="161px" Width="643px">
                                            <RowStyle BackColor="#EFF3FB" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color: beige; text-align: left">
                                        <asp:Label ID="LblDestination2" runat="server" Text="From Airport / Port to Airport / Port"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 9px; text-align: left">
                                        <table>
                                            <tr>
                                                <td style="width: 100px">
                                        <asp:Label ID="LblFrom2" runat="server" Text="From"></asp:Label></td>
                                                <td style="width: 100px">
                                        <asp:DropDownList ID="CmbFrom2" runat="server" Width="163px" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                                <td style="width: 100px">
                                        <asp:Label ID="LblTo2" runat="server" Text="To"></asp:Label></td>
                                                <td style="width: 100px">
                                                    <asp:DropDownList ID="CmbTo2" runat="server" Width="163px" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                        <asp:Label ID="LblTransport2" runat="server" Text="Tranport Name"></asp:Label></td>
                                                <td style="width: 100px">
                                        <asp:DropDownList ID="CmbTransport2" runat="server" AutoPostBack="True" Width="163px">
                                        </asp:DropDownList></td>
                                                <td style="width: 100px">
                                        <asp:Label ID="LblForwarder2" runat="server" Text="Select Forwarder" Width="111px"></asp:Label></td>
                                                <td style="width: 100px">
                                        <asp:DropDownList ID="CmbForwarder2" runat="server" Width="163px" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                        <asp:Label ID="LblAFee2" runat="server" Text="Actual Fee" Width="75px"></asp:Label></td>
                                                <td style="width: 100px">
                                        <asp:TextBox ID="TxtAFee2" runat="server" Width="163px">0</asp:TextBox></td>
                                                <td style="width: 100px">
                                                    <asp:Label ID="LblRemarks2" runat="server" Text="Remarks" Visible="False" Width="111px"></asp:Label><br />
                                        <asp:Label ID="LblQFee2" runat="server" Text="As per Quotation" Width="111px" Visible="False"></asp:Label></td>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="TxtRemarks2" runat="server" Visible="False" Width="163px" TextMode="MultiLine">-</asp:TextBox><br />
                                        <asp:TextBox
                                            ID="TxtQFee2" runat="server" Visible="False" Width="163px">0</asp:TextBox></td>
                                            </tr>
                                        </table>
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        &nbsp; &nbsp; &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="DGrid2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                            Height="161px" Width="643px">
                                            <RowStyle BackColor="#EFF3FB" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color: beige; text-align: left">
                                        <asp:Label ID="LblDestination3" runat="server" Text="From Airport / Port to Customer Place"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align: left" colspan="2">
                                        <table>
                                            <tr>
                                                <td style="width: 100px">
                                        <asp:Label ID="LblFrom3" runat="server" Text="From"></asp:Label></td>
                                                <td style="width: 100px">
                                        <asp:DropDownList ID="CmbFrom3" runat="server" Width="163px" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                                <td style="width: 100px">
                                        <asp:Label ID="LblTo3" runat="server" Text="To"></asp:Label></td>
                                                <td style="width: 100px">
                                        <asp:DropDownList ID="CmbTo3" runat="server" Width="163px" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                        <asp:Label ID="LblTransport3" runat="server" Text="Tranport Name" Width="97px"></asp:Label></td>
                                                <td style="width: 100px">
                                        <asp:DropDownList ID="CmbTransport3" runat="server" AutoPostBack="True" Width="163px">
                                        </asp:DropDownList></td>
                                                <td style="width: 100px">
                                        <asp:Label ID="LblForwarder3" runat="server" Text="Select Forwarder" Width="111px" Height="23px"></asp:Label></td>
                                                <td style="width: 100px">
                                                    <asp:DropDownList ID="CmbForwarder3" runat="server" Width="163px" AutoPostBack="True">
                                        </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                    <asp:Label ID="LblAFee3" runat="server" Text="Actual Fee" Width="75px"></asp:Label></td>
                                                <td style="width: 100px">
                                        <asp:TextBox ID="TxtAFee3" runat="server" Width="163px">0</asp:TextBox></td>
                                                <td style="width: 100px">
                                                    <asp:Label ID="LblRemarks3" runat="server" Text="Remarks" Visible="False" Width="111px"></asp:Label><br />
                                        <asp:Label ID="LblQFee3" runat="server" Text="As per Quotation" Width="111px" Visible="False"></asp:Label></td>
                                                <td style="width: 100px">
                                                    <asp:TextBox ID="TxtRemarks3" runat="server" Visible="False" Width="163px" TextMode="MultiLine">-</asp:TextBox><br />
                                        <asp:TextBox ID="TxtQFee3" runat="server" Visible="False" Width="163px">0</asp:TextBox></td>
                                            </tr>
                                        </table>
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="DGrid3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                            Height="161px" Width="643px">
                                            <RowStyle BackColor="#EFF3FB" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color: beige">
                                       </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="Button1" runat="server" Text="Submit" />
                                        <asp:Button ID="Button2" runat="server" Text="Clear" />
                                        <asp:Button ID="Button3" runat="server" Text="Exit" /></td>
                                </tr>
                            </table>
                            
                            
                            
                            
                            
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                
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