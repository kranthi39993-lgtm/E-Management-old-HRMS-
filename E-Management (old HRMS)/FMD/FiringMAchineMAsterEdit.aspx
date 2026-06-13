<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="FiringMAchineMAsterEdit.aspx.vb" Inherits="E_Management.FiringMAchineMAsterEdit" 
   title="Firing machine Master Edit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

<table id="TABLE2" style="width: 574px">
    <tr>
        <td align="center" colspan="1" valign="top" style="width: 436px; height: 21px; text-align: center;">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="FIRING MACHINE MASTER EDIT"></asp:Label></td>
    </tr>
    <tr>
        <td align="left" style="width: 500px" valign="top">
            <asp:Panel ID="Panel1" runat="server" Width="450px">
                <table id="Table5" border="1" cellpadding="1" cellspacing="1" onclick="return TABLE1_onclick()"
                    style="width: 448px">
                    <tr>
                        <td align="left" style="width: 98px; height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label6" runat="server" Text="Department"></asp:Label></td>
                        <td align="left" style="width: 395px; height: 26px" valign="top">
                            <asp:DropDownList ID="dept_ddl" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                DataSourceID="SqlDataSource1" DataTextField="dept" DataValueField="departmentcode"
                                Width="174px">
                                <asp:ListItem Value="-1">---Select---</asp:ListItem>
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="dept_ddl" ErrorMessage="!" InitialValue="-1" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 98px; height: 26px; background-color: beige" valign="top">
                            <asp:Label ID="Label7" runat="server" Text="Machine No." Width="113px"></asp:Label></td>
                        <td align="left" style="width: 395px; height: 26px" valign="top">
                            <asp:DropDownList ID="mcno_ddl" runat="server" AutoPostBack="True" Width="175px">
                            </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="mcno_ddl" ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 98px; height: 11px; background-color: beige" valign="top">
                            <asp:Label ID="Label8" runat="server" Text="Machine Name" Width="102px"></asp:Label></td>
                        <td align="left" style="width: 395px; height: 11px" valign="top">
                            <asp:Label ID="mcname" runat="server" Width="174px"></asp:Label>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 98px; height: 11px; background-color: beige" valign="top">
                            <asp:Label ID="Label9" runat="server" Text="Machine Description" Width="128px"></asp:Label></td>
                        <td align="left" style="width: 395px; height: 11px" valign="top">
                            <asp:Label ID="mcdesc" runat="server" Width="174px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 98px; height: 11px; background-color: beige" valign="top">
                            Registered By</td>
                        <td align="left" style="width: 395px; height: 11px" valign="top">
                            <asp:Label ID="mcreg" runat="server" Width="175px"></asp:Label></td>
                    </tr>
                </table>
                </asp:Panel>
        </td>
    </tr>
        <tr>
            <td style="width: 500px;" valign="top" align="left">
                <br /><table id="Table3" onclick="return TABLE1_onclick()" border="1" cellpadding="1" cellspacing="1" style="width: 600px">
                    <tr>
                        <td style="width: 522px; background-color: beige; height: 14px;" valign="top" align="left">
                            Zone ID</td>
                        <td style="width: 240px; height: 14px;" valign="top" align="left">
                            <asp:TextBox ID="zoneid" runat="server" Width="61px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="zoneid"
                                ErrorMessage="!" ValidationGroup="r"></asp:RequiredFieldValidator></td>
                        <td style="width: 125px; background-color: beige; height: 14px; color: #000000;" valign="top" align="left">
                            Temperature</td>
                        <td style="width: 562px; height: 14px;" valign="top" align="left">
                            <asp:TextBox ID="temperature" runat="server" Width="64px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="temperature"
                                ErrorMessage="!" ValidationGroup="r"></asp:RequiredFieldValidator>
                            </td>
                        <td align="left" style="width: 125px; height: 14px; background-color: beige" valign="top">
                            Spec.</td>
                        <td align="left" style="width: 749px; height: 14px" valign="top">
                            <asp:Label ID="Label5" runat="server" Font-Underline="True" Text="+"></asp:Label>
                            <asp:TextBox ID="spec" runat="server" Width="67px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="R7" runat="server" ControlToValidate="spec" ErrorMessage="!" ValidationGroup="r"></asp:RequiredFieldValidator>
                            </td>
                        <td align="left" style="height: 14px" valign="top">
                            <asp:Button ID="addtogrid_btn" runat="server" Text="SAVE" ValidationGroup="r" /></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 522px; height: 17px" valign="top">
                        </td>
                        <td align="left" style="width: 240px; height: 17px" valign="top">
                        </td>
                        <td align="left" style="height: 17px" valign="top">
                        </td>
                        <td align="left" style="width: 562px; height: 17px" valign="top">
                            <asp:RegularExpressionValidator ID="R6" runat="server" ControlToValidate="temperature"
                                ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                Width="96px"></asp:RegularExpressionValidator></td>
                        <td align="left" style="height: 17px" valign="top">
                        </td>
                        <td align="left" style="width: 749px; height: 17px" valign="top">
                            <asp:RegularExpressionValidator ID="R9" runat="server" ControlToValidate="spec"
                                ErrorMessage="only Numbers!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                Width="96px"></asp:RegularExpressionValidator></td>
                        <td align="left" style="height: 17px" valign="top">
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource5"
                    ForeColor="Black" GridLines="None" Width="600px">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                             <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ZoneId", "{0}") %>'
                                    ForeColor="#0000C0" OnCommand="mpop" Text="Select" CausesValidation=False ></asp:LinkButton>
                             
                         </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Sno" HeaderText="Sno" SortExpression="Sno" />
                        <asp:BoundField DataField="ZoneId" HeaderText="Zone Id" SortExpression="ZoneId" />
                        <asp:BoundField DataField="fTemp" HeaderText="Temperature" SortExpression="fTemp" />
                        <asp:TemplateField HeaderText="Spec." SortExpression="Spec">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Spec") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <br />
                                <table style="height: 30px; width: 88px;">
                                    <tr>
                                        <td style="width: 19px; height: 17px;"  align="left" valign="top">
                                            <asp:Label ID="Label4" runat="server" Font-Underline="True" Text="+"
                                                Width="1px"></asp:Label></td>
                                        <td style="text-align: left; width: 8px; height: 17px;" valign="top" align="left">
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Spec") %>' Height="15px" Width="56px"></asp:Label></td>
                                    </tr>
                                </table>
                                &nbsp;&nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="fMax" HeaderText="Max." SortExpression="fMax" />
                        <asp:BoundField DataField="fMin" HeaderText="Min." SortExpression="fMin" />
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                </asp:GridView>
                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</td>
        </tr>
    <tr>
        <td align="right" style="width: 500px" valign="top">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label></td>
    </tr>
    </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT ( [departmentcode] +'-'+ [departmentname]) as dept ,departmentcode FROM [department]  where office = 'P' ORDER BY [departmentcode], [departmentname]">
                </asp:SqlDataSource>
                &nbsp;&nbsp;&nbsp; &nbsp;
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:SQLFMD %>"
                    SelectCommand="SELECT * FROM [Fir_McZoneinfo] WHERE ([McNo] = @McNo)" InsertCommand="INSERT INTO [Fir_McZoneinfoTemp] ([ZoneId], [fTemp], [Spec], [fMax], [fMin], [McNo]) VALUES (@ZoneId, @fTemp, @Spec, @fMax, @fMin, @McNo)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="mcno_ddl" Name="McNo" PropertyName="selectedvalue" Type="String" />
                    </SelectParameters>
                  
                </asp:SqlDataSource>
                &nbsp;
    
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