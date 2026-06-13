<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Whistleblower.aspx.vb" Inherits="E_Management.Whistleblower" MasterPageFile="~/ems.Master" title="Whistle Blower"%>

 
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">

        <table>
            <tr>
                <td colspan="2" style="width: 100px; background-color: beige; text-align: center">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="14pt"
                        Text="CORPORATE GOVERNANCE" Width="361px"></asp:Label><br />
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: beige; text-align: center;" colspan="2">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Calibri" Text="WHISTLEBLOWER (FEEDBACK TO MANAGEMENT)"
                        Width="361px"></asp:Label><br />
                </td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: beige;">
                    <asp:Label ID="Label1" runat="server" Text="Your Name / Nama Anda (Optional / Tidak Wajib)"
                        Width="275px" Font-Names="Calibri"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtName" runat="server" Width="450px" Font-Names="Calibri">Mr. / Mdm. / Ms. (Anonymous)</asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: beige;">
                    <asp:Label ID="Label2" runat="server" Text="Your Email Address / Email Anda (Optional / Tidak Wajib)"
                        Width="275px" Font-Names="Calibri"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtFrom" runat="server" Width="450px" Font-Names="Calibri">feedback@maruwa.com.my</asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: beige;">
                    <asp:Label ID="Label3" runat="server" Text="To / Kepada" Width="275px" Font-Names="Calibri"></asp:Label></td>
                <td style="width: 100px">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="* Mr.Sasaki&#13;&#10; * Mr.Ogawa&#13;&#10; * Mr.Sathiaseelan * Mr.Justin"
                        Width="450px" Font-Names="Calibri"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: beige;">
                    <asp:Label ID="Label4" runat="server" Text="Subject / Perkara *" Width="275px" Font-Names="Calibri"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtSubject" runat="server" Width="450px" Font-Names="Calibri"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: beige;">
                    <asp:Label ID="Label5" runat="server" Text="Message / Mesej *" Width="275px" Font-Names="Calibri"></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtMessage" runat="server" Height="154px" TextMode="MultiLine" Width="450px" Font-Names="Calibri"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; background-color: beige;">
                    <asp:Label ID="LblResult" runat="server" Font-Bold="True" Width="275px" Font-Names="Calibri"></asp:Label></td>
                <td style="width: 100px">
                    <asp:Button ID="Button1" runat="server" Text="Send" Font-Bold="True" Font-Names="Calibri" Font-Size="11pt" /></td>
            </tr>
        </table>
    </asp:Content>