<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demo" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<%@ Register TagPrefix="cc" Namespace="Winthusiasm.HtmlEditor" Assembly="Winthusiasm.HtmlEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Demo of HTML Editor for ASP.NET AJAX - Basic Edition</title>
    <style type="text/css">
        body { font-family: Verdana; font-size: 8pt; margin: 10px; }
        .button { font-family: Verdana; font-size: 8pt; width: 100px; height: 30px; }
        .previewButton { margin-left: 10px; margin-right: 10px; margin-top: 3px; width: 75px; height: 28px; }
        .radiobuttonList label { margin-right: 5px; }
        .preview { width: 578px; padding: 10px; }
        div#Content { width: 780px; }
        table#DemoTable { width: 780px; }
        td#EditorCell { width: 600px; vertical-align: top; }
        td#OptionsCell { width: 180px; vertical-align: top; }
        div#Options { width: 150px; margin-left: 5px; }
        div#DemoControls { width: 600px; height: 25px; line-height: 25px; text-align: center; }
        div#Preview { width: 598px; border: solid 1px gray; margin-top: 25px; }
        div#PreviewControls { height: 35px; line-height: 35px; text-align: left; border-bottom: solid 1px gray; }
        div.demoHeading { height: 25px; line-height: 25px; color: black; font-weight: bold; border-bottom: solid 1px gray; text-align: center; }
        div.optionsHeading { font-size: 10pt; border: none; text-align: left; margin-left: 10px; }
        div.optionsLabel { margin: 10px; font-weight: bold; }
        div.optionControls { margin-left: 10px; }
        div#Footer { margin-top: 10px; color: #7f9db9; font-size: 7pt; }
        div#Footer { margin-top: 10px; color: black; font-size: 7pt; }
        a:link.poweredby, a:visited.poweredby, a:active.poweredby { color: black; text-decoration: none; }
        a:hover.poweredby { text-decoration: underline; }
    </style>
    <link href="mvwres:3-AjaxControlToolkit.HTMLEditor.Editor.css,AjaxControlToolkit,%20Version=3.0.30512.20351,%20Culture=neutral,%20PublicKeyToken=28f01b0e84b6d53e"
        rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
        
        <div id="Content">
        
            <table id="DemoTable" border="0" cellpadding="0" cellspacing="0">
            
                <tr>
               &nbsp;&nbsp;
                <br />
            <br />
            <br />
                    <asp:DropDownList ID="DropDownList2" runat="server" Height="17px" 
                        Style="z-index: 100; left: 387px; position: absolute; top: 105px">
                        <asp:ListItem>College</asp:ListItem>
                        <asp:ListItem>School</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Style="z-index: 101;
                        left: 295px; position: absolute; top: 158px" Text="Button" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Style="z-index: 105;
                        left: 393px; position: absolute; top: 157px" Text="Button" />
             <br />
            <br />
            <br />
             <br />
                    <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 103; left: 126px; position: absolute;
                        top: 62px"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList1" runat="server" Style="z-index: 104; left: 287px;
                        position: absolute; top: 107px">
                        <asp:ListItem>College</asp:ListItem>
                        <asp:ListItem>School</asp:ListItem>
                    </asp:DropDownList>
            <br />
             <br />
            <br />
            <br />
                  
             <br />
            <br />
            <br />
               
                    <td id="EditorCell" style="height: 441px">

                        <div id="EditorPanel">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                                <ContentTemplate>
                                
                                    <cc:HtmlEditor ID="Editor" runat="server" Height="400px" Width="614px" ButtonMouseOverColor="192, 192, 255" ButtonMouseOverBorderColor="255, 192, 255" />
                                    &nbsp;
                                
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            &nbsp; &nbsp;
                         </div>
                        </td>
                       </tr>
                      </table>
                   </div>
            </form>

<script type="text/javascript">

function GetHtmlEditor()
{
    return $find('<%= Editor.ClientID %>');
}





</script>

</body>
</html>
