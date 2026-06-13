<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="RptTemperatureCheck.aspx.vb" Inherits="E_Management.RptTemperatureCheck" 
    title="Firing Machine Temperature Daily check" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <table>
        <tr>
            <td style="height: 21px">
    <asp:Label ID="lblmsg" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 16px" align="left">
                <table>
                    <tr>
                        <td style="width: 143px">
                            Month</td>
                        <td style="width: 536px">
                            <asp:Label ID="lblmon" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 143px">
                            Firing Machine No:</td>
                        <td style="width: 536px">
                            <asp:Label ID="lblmcno" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 143px">
                            Department</td>
                        <td style="width: 536px">
                            <asp:Label ID="lbdept" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 446px">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
     DataSourceID="SqlDataSource1" ShowFooter="True" CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" EmptyDataText="No Records found" >
        <Columns>
            <asp:BoundField DataField="Zoneid" HeaderText="Zone" SortExpression="Zoneid" FooterText="No.of" >
                            <ItemStyle BackColor="Beige" />
            </asp:BoundField>
            <asp:BoundField DataField="Spec" HeaderText="Spec" SortExpression="Spec" FooterText="Failures" >
              
                <ItemStyle BackColor="Beige" />
            </asp:BoundField>
            <asp:BoundField DataField="fmax" HeaderText="Max" SortExpression="fmax" FooterText="By" >
              
                <ItemStyle BackColor="Beige" />
            </asp:BoundField>
            <asp:BoundField DataField="fmin" HeaderText="Min" SortExpression="fmin" FooterText=" Days" >
               
                <ItemStyle BackColor="Beige" />
            </asp:BoundField>
            <asp:BoundField DataField="ftemp" HeaderText="Temp" SortExpression="ftemp" >
               
                <ItemStyle BackColor="Beige" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="&lt;U&gt; 01  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d1am" >
                  <ItemTemplate>
                    <asp:Label ID="L1a" runat="server" Text='<%# Bind("d1am") %>'></asp:Label> -
                    <asp:Label ID="L1p" runat="server" Text='<%# Bind("d1pm") %>'></asp:Label>
                </ItemTemplate>
                  <FooterTemplate>
                    <asp:Label ID="f1p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 02  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d2am">
                <ItemTemplate>
                    <asp:Label ID="L2a" runat="server" Text='<%# Bind("d2am") %>'></asp:Label> -
                    <asp:Label ID="L2p" runat="server" Text='<%# Bind("d2pm") %>'></asp:Label>
                </ItemTemplate>
                  <FooterTemplate>
                    <asp:Label ID="f2p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 03  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d3am">
                <ItemTemplate>
                    <asp:Label ID="L3a" runat="server" Text='<%# Bind("d3am") %>'></asp:Label> -
                    <asp:Label ID="L3p" runat="server" Text='<%# Bind("d3pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f3p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="&lt;U&gt; 04  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d4am">
                <ItemTemplate>
                    <asp:Label ID="L4a" runat="server" Text='<%# Bind("d4am") %>'></asp:Label> -
                    <asp:Label ID="L4p" runat="server" Text='<%# Bind("d4pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f4p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 05  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d5am">
              <ItemTemplate>
                    <asp:Label ID="L5a" runat="server" Text='<%# Bind("d5am") %>'></asp:Label> -
                    <asp:Label ID="L5p" runat="server" Text='<%# Bind("d5pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f5p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 06  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d6am">
             <ItemTemplate>
                    <asp:Label ID="L6a" runat="server" Text='<%# Bind("d6am") %>'></asp:Label> -
                    <asp:Label ID="L6p" runat="server" Text='<%# Bind("d6pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f6p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 07  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d7am">
             <ItemTemplate>
                    <asp:Label ID="L7a" runat="server" Text='<%# Bind("d7am") %>'></asp:Label> -
                    <asp:Label ID="L7p" runat="server" Text='<%# Bind("d7pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f7p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="&lt;U&gt; 08  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d8am">
             <ItemTemplate>
                    <asp:Label ID="L8a" runat="server" Text='<%# Bind("d8am") %>'></asp:Label> -
                    <asp:Label ID="L8p" runat="server" Text='<%# Bind("d8pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f8p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 09  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d9am">
                 <ItemTemplate>
                    <asp:Label ID="L9a" runat="server" Text='<%# Bind("d9am") %>'></asp:Label> -
                    <asp:Label ID="L9p" runat="server" Text='<%# Bind("d9pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f9p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 10  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d10am">
              <ItemTemplate>
                    <asp:Label ID="L10a" runat="server" Text='<%# Bind("d10am") %>'></asp:Label> -
                    <asp:Label ID="L10p" runat="server" Text='<%# Bind("d10pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f10p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 11  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d11am">
                <ItemTemplate>
                    <asp:Label ID="L11a" runat="server" Text='<%# Bind("d11am") %>'></asp:Label> -
                    <asp:Label ID="L11p" runat="server" Text='<%# Bind("d11pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f11p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 12  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d12am">
                <ItemTemplate>
                    <asp:Label ID="L12a" runat="server" Text='<%# Bind("d12am") %>'></asp:Label> -
                    <asp:Label ID="L12p" runat="server" Text='<%# Bind("d12pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f12p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 13  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d13am">
              <ItemTemplate>
                    <asp:Label ID="L13a" runat="server" Text='<%# Bind("d13am") %>'></asp:Label> -
                    <asp:Label ID="L13p" runat="server" Text='<%# Bind("d13pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f13p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="&lt;U&gt; 14  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d14am">
              <ItemTemplate>
                    <asp:Label ID="L14a" runat="server" Text='<%# Bind("d14am") %>'></asp:Label> -
                    <asp:Label ID="L14p" runat="server" Text='<%# Bind("d14pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f14p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 15  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d15am">
               <ItemTemplate>
                    <asp:Label ID="L15a" runat="server" Text='<%# Bind("d15am") %>'></asp:Label> -
                    <asp:Label ID="L15p" runat="server" Text='<%# Bind("d15pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f15p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="&lt;U&gt; 16  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d16am">
                <ItemTemplate>
                    <asp:Label ID="L16a" runat="server" Text='<%# Bind("d16am") %>'></asp:Label> -
                    <asp:Label ID="L16p" runat="server" Text='<%# Bind("d16pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f16p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
           <asp:TemplateField HeaderText="&lt;U&gt; 17  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d17am">
                <ItemTemplate>
                    <asp:Label ID="L17a" runat="server" Text='<%# Bind("d17am") %>'></asp:Label> -
                    <asp:Label ID="L17p" runat="server" Text='<%# Bind("d17pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f17p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 18  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d18am">
               <ItemTemplate>
                    <asp:Label ID="L18a" runat="server" Text='<%# Bind("d18am") %>'></asp:Label> -
                    <asp:Label ID="L18p" runat="server" Text='<%# Bind("d18pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f18p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 19  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d19am">
                   <ItemTemplate>
                    <asp:Label ID="L19a" runat="server" Text='<%# Bind("d19am") %>'></asp:Label> -
                    <asp:Label ID="L19p" runat="server" Text='<%# Bind("d19pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f19p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 20  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d20am">
                  <ItemTemplate>
                    <asp:Label ID="L20a" runat="server" Text='<%# Bind("d20am") %>'></asp:Label> -
                    <asp:Label ID="L20p" runat="server" Text='<%# Bind("d20pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f20p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 21  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d21am">
                <ItemTemplate>
                    <asp:Label ID="L21a" runat="server" Text='<%# Bind("d21am") %>'></asp:Label> -
                    <asp:Label ID="L21p" runat="server" Text='<%# Bind("d21pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f21p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 22  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d22am">
                <ItemTemplate>
                    <asp:Label ID="L22a" runat="server" Text='<%# Bind("d22am") %>'></asp:Label> -
                    <asp:Label ID="L22p" runat="server" Text='<%# Bind("d22pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f22p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 23  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d23am">
               <ItemTemplate>
                    <asp:Label ID="L23a" runat="server" Text='<%# Bind("d23am") %>'></asp:Label> -
                    <asp:Label ID="L23p" runat="server" Text='<%# Bind("d23pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f23p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 24  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d24am">
              <ItemTemplate>
                    <asp:Label ID="L24a" runat="server" Text='<%# Bind("d24am") %>'></asp:Label> -
                    <asp:Label ID="L24p" runat="server" Text='<%# Bind("d24pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f24p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 25  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d25am">
                <ItemTemplate>
                    <asp:Label ID="L25a" runat="server" Text='<%# Bind("d25am") %>'></asp:Label> -
                    <asp:Label ID="L25p" runat="server" Text='<%# Bind("d25pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f25p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 26  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d26am">
               <ItemTemplate>
                    <asp:Label ID="L26a" runat="server" Text='<%# Bind("d26am") %>'></asp:Label> -
                    <asp:Label ID="L26p" runat="server" Text='<%# Bind("d26pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f26p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 27  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d27am">
               <ItemTemplate>
                    <asp:Label ID="L27a" runat="server" Text='<%# Bind("d27am") %>'></asp:Label> -
                    <asp:Label ID="L27p" runat="server" Text='<%# Bind("d27pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f27p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 28  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d28am">
             <ItemTemplate>
                    <asp:Label ID="L28a" runat="server" Text='<%# Bind("d28am") %>'></asp:Label> -
                    <asp:Label ID="L28p" runat="server" Text='<%# Bind("d28pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f28p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 29  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d29am">
              <ItemTemplate>
                    <asp:Label ID="L29a" runat="server" Text='<%# Bind("d29am") %>'></asp:Label> -
                    <asp:Label ID="L29p" runat="server" Text='<%# Bind("d29pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f29p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 30  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d30am">
            <ItemTemplate>
                    <asp:Label ID="L30a" runat="server" Text='<%# Bind("d30am") %>'></asp:Label> -
                    <asp:Label ID="L30p" runat="server" Text='<%# Bind("d30pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f30p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&lt;U&gt; 31  &lt;/U&gt; &lt;BR&gt;  AM-PM" SortExpression="d31am">
               <ItemTemplate>
                    <asp:Label ID="L31a" runat="server" Text='<%# Bind("d31am") %>'></asp:Label> -
                    <asp:Label ID="L31p" runat="server" Text='<%# Bind("d31pm") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="f31p" runat="server" Text=""></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No.of &lt;BR&gt; Failures &lt;BR&gt; by Zone" InsertVisible="False"
                SortExpression="Sno">
                 <ItemTemplate>
                    <asp:Label ID="Lbltot" runat="server" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <EmptyDataRowStyle Font-Size="Medium" ForeColor="Red" />
    </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLFMD %>"
        SelectCommand="SELECT * FROM [Fir_RptTempcheckTable] WHERE ([keyinby] = @keyinby) and mcno = @mcno order by sno  ">
        <SelectParameters>
            <asp:SessionParameter Name="keyinby" SessionField="empcode" Type="String" />
            <asp:SessionParameter Name="mcno" SessionField="McNoR" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>



</asp:Content>
