
Imports E_Management.CRMlognetglobal
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Partial Public Class ExpenseExpiryDetails
    Inherits Messagebox

    Dim Cmd As New SqlCommand
    Dim Ad As New SqlDataAdapter
    Dim TmpDs As New DataSet
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim ob As New CRMlognetglobal
        'Dim conStr1
        'ob.db_cn()
        'conStr1 = ob.sConnString

        'Dim con1 As New SqlConnection(conStr1)
        'con1.Open()

        'Cmd = New SqlCommand("SELECT * From Log_VehicleQuotation Where ApprovedStatus='Approved' and Effective", con1)
        'Ad = New SqlDataAdapter(Cmd)
        'TmpDs = New DataSet()
        'Ad.Fill(TmpDs, "Verify")
        'DGrid1.DataSource = TmpDs.Tables(0)
        'DGrid1.DataBind()
    End Sub

End Class