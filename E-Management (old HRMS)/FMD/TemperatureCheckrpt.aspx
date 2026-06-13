<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="TemperatureCheckrpt.aspx.vb" Inherits="E_Management.TemperatureCheckrpt" 
    title="Firing Machine Temperature Check" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="16" style="height: 16px">
                <img height="16" src="../../images/top_lef.gif" width="16" /></td>
            <td background="../../images/top_mid.gif" style="height: 16px; width: 1262px;">
                <img height="16" src="../../images/top_mid.gif" width="16" /></td>
            <td style="width: 24px; height: 16px;">
                <img height="16" src="../../images/top_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td background="../../images/cen_lef.gif" style="height: 622px" width="16">
                <img height="11" src="../../images/cen_lef.gif" width="16" /></td>
            <td bgcolor="#ffffff" style="height: 622px; width: 1262px;" valign="top">
            
            <TABLE><TBODY><TR><TD style="WIDTH: 100px"><asp:Panel id="Panel1" runat="server" Width="450px"><TABLE style="WIDTH: 448px" id="TABLE1" onclick="return TABLE1_onclick()" cellSpacing=1 cellPadding=1 border=1><TBODY><TR><TD style="WIDTH: 98px; HEIGHT: 26px; BACKGROUND-COLOR: beige" vAlign=top align=left><asp:Label id="Label2" runat="server" Text="Department"></asp:Label></TD><TD style="WIDTH: 395px; HEIGHT: 26px" vAlign=top align=left><asp:DropDownList id="dept_ddl" runat="server" Width="174px" DataSourceID="SqlDataSource1" DataValueField="departmentcode" DataTextField="dept" AutoPostBack="True" AppendDataBoundItems="True">
                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                        </asp:DropDownList> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="b" InitialValue="-1" ErrorMessage="!" ControlToValidate="dept_ddl"></asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 26px; BACKGROUND-COLOR: beige" vAlign=top align=left><asp:Label id="Label14" runat="server" Width="113px" Text="Machine No."></asp:Label></TD><TD style="WIDTH: 395px; HEIGHT: 26px" vAlign=top align=left><asp:DropDownList id="mcno_ddl" runat="server" Width="175px" AutoPostBack="True">
                         
                        </asp:DropDownList>&nbsp; <asp:RequiredFieldValidator id="R2" runat="server" ValidationGroup="b" ErrorMessage="!" ControlToValidate="mcno_ddl"></asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 11px; BACKGROUND-COLOR: beige" vAlign=top align=left><asp:Label id="Label3" runat="server" Width="102px" Text="Month "></asp:Label></TD><TD style="WIDTH: 395px; HEIGHT: 11px" vAlign=top align=left><asp:DropDownList id="Mon_ddl" runat="server" Width="102px" AutoPostBack="True">
                            <asp:ListItem>Jan</asp:ListItem>
                            <asp:ListItem>Feb</asp:ListItem>
                            <asp:ListItem>March</asp:ListItem>
                            <asp:ListItem>April</asp:ListItem>
                            <asp:ListItem>May</asp:ListItem>
                            <asp:ListItem>June</asp:ListItem>
                            <asp:ListItem>July</asp:ListItem>
                            <asp:ListItem>Aug</asp:ListItem>
                            <asp:ListItem>Sep</asp:ListItem>
                            <asp:ListItem>Oct</asp:ListItem>
                            <asp:ListItem>Nov</asp:ListItem>
                            <asp:ListItem>Dec</asp:ListItem>
                            <asp:ListItem Selected="True" Value="-1">--Select--</asp:ListItem>
                        </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Mon_ddl"
                                ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 11px; BACKGROUND-COLOR: beige" vAlign=top align=left></TD><TD style="WIDTH: 395px; HEIGHT: 11px" vAlign=top align=right>
    <asp:Button ID="Button1" runat="server" Text="Show Report" /></TD></TR></TBODY></TABLE><asp:Label id="lblmsg" runat="server" ForeColor="Green"></asp:Label> </asp:Panel> &nbsp;</TD></TR></TBODY></TABLE>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT ( [departmentcode] +'-'+ [departmentname]) as dept ,departmentcode FROM [department] where office = 'P'  ORDER BY [departmentcode], [departmentname]">
                </asp:SqlDataSource>
            
              </td>
            <td background="../../images/cen_rig.gif" style="width: 24px">
                <img height="11" src="../../images/cen_rig.gif" width="24" /></td>
        </tr>
        <tr>
            <td height="16" width="16">
                <img height="16" src="../../images/bot_lef.gif" width="16" /></td>
            <td background="../../images/bot_mid.gif" height="16" style="width: 1262px">
                <img height="16" src="../../images/bot_mid.gif" width="16" /></td>
            <td height="16" style="width: 24px">
                <img height="16" src="../../images/bot_rig.gif" width="24" /></td>
        </tr>
    </table>
</asp:Content>
