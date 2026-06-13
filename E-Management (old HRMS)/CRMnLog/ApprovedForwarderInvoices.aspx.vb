
Imports E_Management.CRMlognetglobal
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Partial Public Class ApprovedForwarderInvoices
    Inherits Messagebox

    Dim Cmd As New SqlCommand
    Dim Ad As New SqlDataAdapter
    Dim TmpDs As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            GridDisp()

        End If
    End Sub
    Private Sub GridDisp()

        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        Cmd = New SqlCommand("SELECT UID, InvoiceNo, DepartmentName, FInvSubmissionDate, ForwarderName, ArrivalPlace, DepartPlace, ForwarderInvoiceNo, QuotedAmount, ForwarderInvoiceValue, Difference, Remarks FROM  Log_ForwarderInvoiceDetails Where VerifyStatus='Approved'", con1)
        Ad = New SqlDataAdapter(Cmd)
        TmpDs = New DataSet()
        Ad.Fill(TmpDs, "Verify")
        DGView1.DataSource = TmpDs.Tables(0)
        DGView1.DataBind()

        con1.Close()

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim Sum As Long

        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        Dim Item As GridViewRow

        For Each Item In DGView1.Rows
            Dim Chk1 As CheckBox = (Item.Cells(0).FindControl("ChkBx1"))

            If Chk1.Checked = True Then

                Dim UID As String = Item.Cells(1).Text
                Dim InvoiceNo As String = Item.Cells(2).Text
                Dim DepartmentName As String = Item.Cells(3).Text
                Dim ForwarderName As String = Item.Cells(4).Text
                Dim ArrivalPlace As String = Item.Cells(5).Text
                Dim DepartPlace As String = Item.Cells(6).Text
                Dim ForwarderInvoiceNo As String = Item.Cells(7).Text
                Dim QuotedAmount As String = Item.Cells(8).Text
                Dim ForwarderInvoiceValue As String = Item.Cells(9).Text
                Dim Difference As String = Item.Cells(10).Text
                Dim Remarks As String = Item.Cells(11).Text

                Sum = Sum + Item.Cells(9).Text

                msg("Update Log_ForwarderInvoiceDetails set Verifystatus='BizTrak' Where InvoiceNo='" & InvoiceNo & "' and UID='" & UID & "'")

            End If

        Next

        LblAmount.Text = Sum

        msg("Successfully Updated")
        con1.Close()
    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub

End Class