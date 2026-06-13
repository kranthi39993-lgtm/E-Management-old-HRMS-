<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ExpenseExpiryDetails.aspx.vb" Inherits="E_Management.ExpenseExpiryDetails" MasterPageFile="~/ems.Master" Title="Expiry Alert" %>


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
                                            Effective Date Expiry Alert <br />
                                            </strong></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:DataGrid ID="DGrid1" runat="server">
                                            
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px; height: 27px;">
                                        </td>
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