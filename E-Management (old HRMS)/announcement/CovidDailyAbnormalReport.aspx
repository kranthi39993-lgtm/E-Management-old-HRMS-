<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CovidDailyAbnormalReport.aspx.vb" Inherits="E_Management.CovidDailyAbnormalReport" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Covid 19 Daily Declaration</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table align="center" width="60%"  class="table table-striped">
    
    <thead>
        <tr>
            <th style="height: 16px; text-align: right">
                <asp:LinkButton ID="LinkButton3" runat="server" Font-Names="Arial" Font-Size="9pt"
                    ForeColor="Blue">COVID 19 Weekly Report</asp:LinkButton>&nbsp; 
                <asp:LinkButton ID="LinkButton2" runat="server" Font-Names="Arial" Font-Size="9pt"
                    ForeColor="Blue">COVID 19 Declaration</asp:LinkButton>
                &nbsp; &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Blue" Font-Names="Arial" Font-Size="9pt">Logout</asp:LinkButton></th>
        </tr>
        <tr>
            <th style="height: 16px; text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="10pt" Text="Declaration - Abnormal Report - Daily"></asp:Label>&nbsp;</th>                
        </tr>
        </thead>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                    Text="Search By Employee Code"></asp:Label>
                <asp:TextBox ID="empcode1" runat="server" AutoPostBack="True" Font-Names="Arial"
                    Font-Size="9pt"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Font-Names="Arial"
                        Font-Size="9pt" Text="View" />
                <asp:Label ID="lblmsg" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:GridView AutoGenerateColumns=false ID="GridView2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" GridLines="Horizontal">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                      <Columns>
                
                 <asp:BoundField DataField="UID" HeaderText="UID" ReadOnly="True" SortExpression="UID" Visible=False />
                  <asp:BoundField DataField="EmpCode" HeaderText="EmpCode" ReadOnly="True" SortExpression="EmpCode" />
                   <asp:BoundField DataField="EmpName" HeaderText="EmpName" ReadOnly="True" SortExpression="EmpName" />
                    <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" ReadOnly="True" SortExpression="DepartmentName" />
                     <asp:BoundField DataField="DeclarationStatus" HeaderText="DeclarationStatus" ReadOnly="True" SortExpression="DeclarationStatus" />
                      <asp:BoundField DataField="DeclaredOn" HeaderText="DeclaredOn" ReadOnly="True" SortExpression="DeclaredOn" />
                   <asp:HyperLinkField DataNavigateUrlFields="UID" DataNavigateUrlFormatString="Covid19DailyDeclarationView.aspx?uid={0}"
                                                HeaderText="View" Target="_blank" Text="view">
                                                <ControlStyle Font-Underline="True" />
                                            </asp:HyperLinkField>
                </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td bgcolor="#cccccc" style="text-align: left">
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                    Text="Declared with Yes"></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:GridView AutoGenerateColumns=false ID="GridView3" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" GridLines="Horizontal">
                    <Columns>
                        <asp:BoundField DataField="UID" HeaderText="UID" ReadOnly="True" SortExpression="UID" Visible=False />
                        <asp:BoundField DataField="EmpCode" HeaderText="EmpCode" ReadOnly="True" SortExpression="EmpCode" />
                        <asp:BoundField DataField="EmpName" HeaderText="EmpName" ReadOnly="True" SortExpression="EmpName" />
                        <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" ReadOnly="True" SortExpression="DepartmentName" />
                        <asp:BoundField DataField="DeclarationStatus" HeaderText="DeclarationStatus" ReadOnly="True" SortExpression="DeclarationStatus" />
                        <asp:BoundField DataField="DeclaredOn" HeaderText="DeclaredOn" ReadOnly="True" SortExpression="DeclaredOn" />
                        <asp:HyperLinkField DataNavigateUrlFields="UID" DataNavigateUrlFormatString="Covid19DailyDeclarationView.aspx?uid={0}"
                                                HeaderText="View" Target="_blank" Text="view">
                            <ControlStyle Font-Underline="True" />
                        </asp:HyperLinkField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td bgcolor="#cccccc" style="height: 21px; text-align: left">
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                    Text="Not Declared Employee Detail"></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:GridView AutoGenerateColumns=false ID="GridView4" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" GridLines="Horizontal">
                    <Columns>
                        <asp:BoundField DataField="UID" HeaderText="UID" ReadOnly="True" SortExpression="UID" Visible=False />
                        <asp:BoundField DataField="EmpCode" HeaderText="EmpCode" ReadOnly="True" SortExpression="EmpCode" />
                        <asp:BoundField DataField="EmpName" HeaderText="EmpName" ReadOnly="True" SortExpression="EmpName" />
                        <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" ReadOnly="True" SortExpression="DepartmentName" />
                        <asp:BoundField DataField="DeclarationStatus" HeaderText="DeclarationStatus" ReadOnly="True" SortExpression="DeclarationStatus" />
                        <asp:BoundField DataField="DeclaredOn" HeaderText="DeclaredOn" ReadOnly="True" SortExpression="DeclaredOn" />
                        <asp:HyperLinkField DataNavigateUrlFields="UID" DataNavigateUrlFormatString="Covid19DailyDeclarationView.aspx?uid={0}"
                                                HeaderText="View" Target="_blank" Text="view">
                            <ControlStyle Font-Underline="True" />
                        </asp:HyperLinkField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td bgcolor="#cccccc" style="text-align: left">
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"
                    Text="Overall Detail"></asp:Label></td>
        </tr>
        
        <tr>
        <td style="text-align: left">
            <asp:GridView AutoGenerateColumns=false ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="8pt" ForeColor="Black" GridLines="Horizontal"><Columns>
                <asp:BoundField DataField="UID" HeaderText="UID" ReadOnly="True" SortExpression="UID" Visible=False />
                <asp:BoundField DataField="EmpCode" HeaderText="EmpCode" ReadOnly="True" SortExpression="EmpCode" />
                <asp:BoundField DataField="EmpName" HeaderText="EmpName" ReadOnly="True" SortExpression="EmpName" />
                <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" ReadOnly="True" SortExpression="DepartmentName" />
                <asp:BoundField DataField="DeclarationStatus" HeaderText="DeclarationStatus" ReadOnly="True" SortExpression="DeclarationStatus" />
                <asp:BoundField DataField="DeclaredOn" HeaderText="DeclaredOn" ReadOnly="True" SortExpression="DeclaredOn" />
                <asp:HyperLinkField DataNavigateUrlFields="UID" DataNavigateUrlFormatString="Covid19DailyDeclarationView.aspx?uid={0}"
                                                HeaderText="View" Target="_blank" Text="view">
                    <ControlStyle Font-Underline="True" />
                </asp:HyperLinkField>
            </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </td>
        </tr>
        
        </table>
    </div>
    </form>
</body>
</html>

