<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MaruwaUploadingBillView.aspx.vb" Inherits="E_Management.MaruwaUploadingBillView"   MasterPageFile="~/ems.Master" title="Upload Documents" %>



<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">	

	<script type="text/javascript">
  <asp:Literal id="ltlAlert" runat="server" EnableViewState="False">
    </asp:Literal>
			</script>
			
			<table cellpadding="0" cellspacing="0" align="center" width="500">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../images/top_lef.gif" width="16"  alt=""/></td>
            <td background="../images/top_mid.gif" style="height: 16px">
                <img height="16" src="../images/top_mid.gif" width="16"  alt="" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../images/top_rig.gif" width="24"  alt="" /></td>
        </tr>
        <tr>
            <td background="../images/cen_lef.gif"  width="16">
                <img height="11" src=    "../images/cen_lef.gif" width="16"  alt="" /></td>
            <td bgcolor="#ffffff" valign="top">
            <table width="500" >
                    <tr>
                        <td colspan="2" align="center" style="width: 435px">
                            <asp:Panel ID="Panel11" runat="server">
                                &nbsp;
	<%--	</div>--%>
		<table>
	
			<tr>
				<td style="HEIGHT: 34px; background-color: #336699;" colspan="3"><font size="4"><strong><span style="color: #ffffff">View - Bills of Lading</span></strong></font></td>
			</tr>
			<tr>
				<td style="WIDTH: 69px; HEIGHT: 22px; background-color: beige;"><asp:label id="lblinvno" Height="15px" Width="72px" Runat="server"  >Invoice No</asp:label></td>
				<td style="WIDTH: 216px; HEIGHT: 35px"><asp:dropdownlist id="ddlAirname" runat="server" Width="160px" AutoPostBack="True"></asp:dropdownlist></td>
				<td style="WIDTH: 165px; HEIGHT: 35px"></td>
			</tr>
			<tr>
				<td style="WIDTH: 69px; HEIGHT: 22px; background-color: beige;"><asp:label id="lblinvdate" Height="15px" Width="80px" Runat="server"  >Invoice Date</asp:label></td>
				<td style="WIDTH: 216px; HEIGHT: 27px"><asp:textbox id="txt_indate" Width="160px" Runat="server"></asp:textbox></td>
				<td style="WIDTH: 165px; HEIGHT: 27px"></td>
			</tr>
			<tr>
				<td style="WIDTH: 69px; HEIGHT: 22px; background-color: beige;"><asp:label id="lblcnam" Width="104px" Runat="server"  >Customer Name</asp:label></td>
				<td style="WIDTH: 216px; HEIGHT: 32px"><asp:textbox id="txt_custname" Width="160px" Runat="server"></asp:textbox></td>
				<td style="WIDTH: 165px; HEIGHT: 32px"></td>
			</tr>
			<tr>
				<td style="WIDTH: 69px; HEIGHT: 22px; background-color: beige;"><asp:label id="lbldes" Width="64px" Runat="server"  >Destination</asp:label></td>
				<td style="WIDTH: 216px; HEIGHT: 34px"><asp:textbox id="txt_des" Width="160px" Runat="server"></asp:textbox></td>
				<td style="WIDTH: 165px; HEIGHT: 34px"></td>
			</tr>
			<tr>
				<td style="WIDTH: 69px; HEIGHT: 22px; background-color: beige;"><asp:label id="lblcadd1" Width="122px" Runat="server"  >Customer Address1</asp:label></td>
				<td style="WIDTH: 216px; HEIGHT: 22px"><asp:textbox id="txt_custadd1" Width="160px" Runat="server" TextMode="MultiLine"></asp:textbox></td>
				<td style="WIDTH: 165px; HEIGHT: 22px"></td>
			</tr>
			<tr>
				<td style="WIDTH: 69px; HEIGHT: 22px; background-color: beige;"><asp:label id="lbl_sdate" Width="86px" Runat="server"  >Delivery Date</asp:label></td>
				<td style="WIDTH: 216px; HEIGHT: 35px"><asp:textbox id="txt_sch" Width="160px" Runat="server"></asp:textbox></td>
				<td style="WIDTH: 165px; HEIGHT: 35px"></td>
			</tr>
			<tr>
				<td style="WIDTH: 69px; HEIGHT: 22px; background-color: beige;"><asp:label id="lblsf" Width="72px" Runat="server"  >Select File</asp:label></td>
				<td style="WIDTH: 216px; HEIGHT: 35px"><asp:dropdownlist id="Dropdownlist1" runat="server" Height="54px" Width="158px" AutoPostBack="True"></asp:dropdownlist></td>
				<td style="WIDTH: 165px; HEIGHT: 35px"></td>
			</tr>
            <tr>
                <td colspan="2" style="height: 22px">
                    <asp:Button ID="Button2" runat="server" Text="Exit" Width="77px" />
                    &nbsp;
                                <asp:button id="Button1" runat="server" Width="96px" CssClass="btnsubmitstyle" Text="View "></asp:button></td>
                <td style="width: 165px; height: 35px">
                </td>
            </tr>
		</table>
                                &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                            </asp:Panel>
                            <asp:label id="lblfnam" Height="15px" Width="108px" Runat="server" Visible="False"  >Forwarder Name</asp:label><asp:textbox id="txtfnam" Width="160px" Runat="server" Visible="False"></asp:textbox>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                </td>
				  <td background="../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../images/cen_rig.gif" width="24"  alt="" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../images/bot_lef.gif" width="16"  alt="" /></td>
            <td background="../images/bot_mid.gif" height="16">
                <img height="16" src="../images/bot_mid.gif" width="16"  alt="" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../images/bot_rig.gif" width="24" alt="" /></td>
        </tr>
        
        <tr>
        <td colspan="4">
            &nbsp;</td>
        </tr>
        
    </table>
		</asp:Content>