
Imports E_Management.CRMlognetglobal
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Partial Public Class NotSubmittedForwarderInvoice
    Inherits Messagebox

    Dim Cmd As New SqlCommand
    Dim Ad As New SqlDataAdapter
    Dim TmpDs As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        Cmd = New SqlCommand("SELECT  InvoiceNo, CustomerName, ShippingTerms, Destination, TransitBy, REPLACE(From1, '-Select-', '') AS From1, REPLACE(To1, '-Select-', '') AS To1, REPLACE(Transport1, '-Select-', '') AS Transport1, REPLACE(Forwarder1, '-Select-', '') AS Forwarder1, AAmount1, REPLACE(From2, '-Select-', '') AS From2, REPLACE(To2, '-Select-', '') AS To2, REPLACE(Transport2, '-Select-', '') AS Transport2, REPLACE(Forwarder2, '-Select-', '') AS Forwarder2, AAmount2, REPLACE(From3, '-Select-', '') AS From3, REPLACE(To3, '-Select-', '') AS To3, REPLACE(Transport3, '-Select-', '') AS Transport3, REPLACE(Forwarder3, '-Select-', '') AS Forwarder3, AAmount3, OverallAmount FROM Log_ShippingDetails WHERE (InvoiceNo Not IN(SELECT InvoiceNo FROM Log_ForwarderInvoiceDetails)) ORDER BY InvoiceDate", con1)
        Ad = New SqlDataAdapter(Cmd)
        TmpDs = New DataSet()
        Ad.Fill(TmpDs, "Verify")
        DGrid1.DataSource = TmpDs.Tables(0)
        DGrid1.DataBind()
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub
End Class