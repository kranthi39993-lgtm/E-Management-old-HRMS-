<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="FiringMCtemperatureCheck.aspx.vb" Inherits="E_Management.FiringMCtemperatureCheck" 
    title="Firing Machine Temperature Check Data Entry" %>
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

<table id="TABLE2" style="width: 450px">
    <tr>
        <td align="center" colspan="1" valign="top" style="width: 445px; height: 21px; text-align: center;">
                        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="Maroon" Text="FIRING MACHINE TEMPERATURE CHECK DATA ENTRY"></asp:Label></td>
    </tr>
        <tr>
            <td style="width: 445px; text-align: left;" valign="top" align="left">
                <br />
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:Panel ID="Panel1" runat="server" Width="450px">
                <table id="TABLE1" onclick="return TABLE1_onclick()" border="1" cellpadding="1" cellspacing="1" style="width: 448px"><tr>
                    <td style="width: 98px; background-color: beige; height: 26px;" valign="top" align="left">
                        <asp:Label ID="Label2" runat="server" Text="Department"></asp:Label></td>
                    <td style="width: 395px; height: 26px;" valign="top" align="left">
                        <asp:DropDownList ID="dept_ddl" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                            DataSourceID="SqlDataSource1" DataTextField="dept" DataValueField="departmentcode"
                            Width="174px">
                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dept_ddl"
                            ErrorMessage="!" InitialValue="-1" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                </tr>
                    <tr>
                        <td align="left" style="width: 98px; height: 26px; background-color: beige" valign="top">
                        <asp:Label ID="Label14" runat="server" Text="Machine No." Width="113px"></asp:Label></td>
                        <td align="left" style="width: 395px; height: 26px" valign="top">
                        <asp:DropDownList ID="mcno_ddl" runat="server" AutoPostBack="True"
                            Width="175px">
                         
                        </asp:DropDownList>&nbsp;
                            <asp:RequiredFieldValidator ID="R2" runat="server" ControlToValidate="mcno_ddl" ErrorMessage="!" ValidationGroup="b"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 98px; background-color: beige; height: 11px;" valign="top" align="left">
                            <asp:Label ID="Label3" runat="server" Text="Machine Name" Width="102px"></asp:Label></td>
                        <td style="width: 395px; height: 11px;" valign="top" align="left">
                            <asp:Label ID="mcname" runat="server" Width="174px"></asp:Label>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 98px; height: 11px; background-color: beige" valign="top">
                        <asp:Label ID="Label15" runat="server" Text="Machine Description" Width="128px"></asp:Label></td>
                        <td align="left" style="width: 395px; height: 11px" valign="top">
                        <asp:Label ID="mcdesc" runat="server" Width="174px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 98px; height: 11px; background-color: beige" valign="top">
                            Date
                        </td>
                        <td align="left" style="width: 395px; height: 11px" valign="top">
                            <asp:Label ID="dttoday" runat="server" Width="175px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 98px; height: 11px; background-color: beige" valign="top">
                            Time</td>
                        <td align="left" style="width: 395px; height: 11px" valign="top">
                            <asp:Label ID="timetod" runat="server" Width="176px"></asp:Label></td>
                    </tr>
                </table>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Green"></asp:Label>
                                <asp:Label ID="lblmsg1" runat="server" ForeColor="Green"></asp:Label></asp:Panel>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                    BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="firstgrid"
                    ForeColor="Black" GridLines="None" ShowFooter="True" Width="450px">
                    <Columns>
                        <asp:BoundField DataField="ZoneId" HeaderText="ZoneId" SortExpression="ZoneId" />
                        <asp:BoundField DataField="FTemp" HeaderText="Temperature" SortExpression="FTemp" />
                        <asp:BoundField DataField="Spec" HeaderText="Spec" SortExpression="Spec" />
                        <asp:BoundField DataField="FMax" HeaderText="Maximum" SortExpression="FMax" />
                        <asp:BoundField DataField="fMin" HeaderText="Minimum" SortExpression="fMin" />
                        <asp:TemplateField HeaderText="Actual">
                            <ItemTemplate>
                                <asp:TextBox ID="act" runat="server" Width="59px"></asp:TextBox>
                                &nbsp;
                                <asp:RequiredFieldValidator ID="R10" runat="server" ControlToValidate="act" ErrorMessage="!"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="R11" runat="server" ControlToValidate="act"
                                    ErrorMessage="Only Nos.!" ValidationExpression="^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$"
                                    Width="72px"></asp:RegularExpressionValidator>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="SaveZonefirst" Text="Save" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2"
                    ForeColor="#333333" GridLines="None" ShowFooter="True" Width="450px">
                    <Columns>
                        <asp:BoundField DataField="ZoneId" HeaderText="ZoneId" SortExpression="ZoneId" />
                        <asp:BoundField DataField="FMax" HeaderText="Max" SortExpression="FMax" />
                        <asp:BoundField DataField="fMin" HeaderText="Min" SortExpression="fMin" />
                        <asp:TemplateField HeaderText="Spec" SortExpression="Spec">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Spec") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td style="width: 12px; height: 21px; text-align: center">
                                            <span style="text-decoration: underline">+</span></td>
                                        <td style="width: 55px; height: 21px; text-align: left">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Spec") %>'></asp:Label></td>
                                    </tr>
                                </table>
                                                            </ItemTemplate>
                                                             <FooterTemplate>
                                <asp:Button ID="Button1" runat="server" OnClick="exitpage" Text="EXIT" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FTemp" HeaderText="Temperature" SortExpression="FTemp" />
                         <asp:BoundField DataField="ActualVal" HeaderText="Actual" SortExpression="ActualVal" />
                         <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        
                    </Columns>
                    
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <EditRowStyle BackColor="#999999" />
                </asp:GridView>
                        </td>
                    </tr>
                </table>
                &nbsp; &nbsp;&nbsp;<br />
                <br />
            </td>
        </tr>
    <tr>
        <td align="right" style="width: 445px; text-align: right" valign="top">
            <table id="Table4" onclick="return TABLE1_onclick()" style="width: 600px">
                <tr>
                    <td style="width: 545px; text-align: right;" valign="top" align="left" colspan="6">
                </td>
                    <td align="left" style="height: 26px" valign="top">
                </td>
                </tr>
            </table>
            <asp:TextBox ID="datebox" runat="server" Visible="False"></asp:TextBox>
            <asp:TextBox ID="timebox" runat="server" Visible="False"></asp:TextBox></td>
    </tr>
    </table>
                <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:sqlfmd %>"
                    SelectCommand="SELECT McNo FROM Fir_FiringMcMaster WHERE (Fir_FiringMcMaster.department = @dept)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="dept_ddl" Name="dept" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Sqlcon1 %>"
                    SelectCommand="SELECT ( [departmentcode] +'-'+ [departmentname]) as dept ,departmentcode FROM [department] where office = 'P'  ORDER BY [departmentcode], [departmentname]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server"></asp:SqlDataSource>
                <asp:SqlDataSource ID="firstgrid" runat="server" ConnectionString="<%$ ConnectionStrings:SqlFMd %>"
                    SelectCommand="SELECT DISTINCT [ZoneId], [FTemp], [Spec], [FMax], [fMin],sno FROM [Fir_McZoneinfo] WHERE ([McNo] = @McNo) order by sno">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="mcno_ddl" Name="McNo" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:sqlFMD %>"
                    SelectCommand="SELECT Distinct Fir_McZoneinfo.McNo FROM Fir_FiringMcMaster INNER JOIN Fir_McZoneinfo ON Fir_FiringMcMaster.McNo = Fir_McZoneinfo.McNo WHERE (Fir_FiringMcMaster.department = @dept)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="dept_ddl" Name="dept" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SqlFMd %>"
                    SelectCommand="SELECT Fir_McZoneinfo.ZoneId, Fir_McZoneinfo.FMax, Fir_McZoneinfo.fMin, Fir_McZoneinfo.Spec, Fir_McZoneinfo.FTemp, Fir_temperaturecheck.Status, Fir_temperaturecheck.ActualVal, Fir_temperaturecheck.EntryDate, Fir_temperaturecheck.EntryTime FROM Fir_McZoneinfo LEFT OUTER JOIN Fir_temperaturecheck ON Fir_McZoneinfo.McNo = Fir_temperaturecheck.McNo AND Fir_McZoneinfo.ZoneId = Fir_temperaturecheck.ZoneId WHERE (Fir_McZoneinfo.McNo = @mcno) AND (Fir_temperaturecheck.EntryDate = @dt) AND (Fir_temperaturecheck.EntryTime = @tim) order by Fir_temperaturecheck.sno">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="mcno_ddl" Name="mcno" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="datebox" Name="dt" PropertyName="Text" />
                        <asp:ControlParameter ControlID="timebox" Name="tim" PropertyName="Text" />
                    </SelectParameters>
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