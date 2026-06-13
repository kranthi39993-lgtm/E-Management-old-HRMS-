
Imports E_Management.CRMlognetglobal
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Partial Public Class ApprovalForwarderInvoice
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

        Cmd = New SqlCommand("SELECT UID,InvoiceNo, DepartmentName, FInvSubmissionDate, ForwarderName, ArrivalPlace, DepartPlace, ForwarderInvoiceNo, QuotedAmount, ForwarderInvoiceValue, Difference, Remarks FROM  Log_ForwarderInvoiceDetails Where VerifyStatus='Verified'", con1)
        Ad = New SqlDataAdapter(Cmd)
        TmpDs = New DataSet()
        Ad.Fill(TmpDs, "Verify")
        DGrid1.DataSource = TmpDs.Tables(0)
        DGrid1.DataBind()



        For Tmpi As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
            If Val(DGrid1.Items.Item(Tmpi).Cells(8).Text) < Val(DGrid1.Items.Item(Tmpi).Cells(9).Text) Then
                DGrid1.Items.Item(Tmpi).BackColor = Drawing.Color.Red
            Else
                DGrid1.Items.Item(Tmpi).BackColor = Drawing.Color.Lime
            End If
        Next

        con1.Close()

    End Sub

    Public Sub FunCancel(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)

        Try
            Dim ob As New CRMlognetglobal
            Dim conStr1
            ob.db_cn()
            conStr1 = ob.sConnString

            Dim con1 As New SqlConnection(conStr1)
            con1.Open()

            Cmd = New SqlCommand("Update Log_ForwarderInvoiceDetails Set VerifyStatus='Rejected' Where UID=" & e.Item.Cells(0).Text, con1)
            Cmd.ExecuteNonQuery()

            con1.Close()

            DGrid1.EditItemIndex = -1
            GridDisp()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub FunEdit(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)

        Session("refno") = e.Item.Cells(0).Text
        Response.Redirect("ApprovalForwarderInvoiceKeyIn.aspx")

    End Sub

    Public Sub FunUpdate(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        Try
            Dim ob As New CRMlognetglobal
            Dim conStr1
            ob.db_cn()
            conStr1 = ob.sConnString

            Dim con1 As New SqlConnection(conStr1)
            con1.Open()

            Cmd = New SqlCommand("Update Log_ForwarderInvoiceDetails Set VerifyStatus='Approved' Where UID=" & e.Item.Cells(0).Text, con1)
            Cmd.ExecuteNonQuery()

            con1.Close()

            msg("Update")
            DGrid1.EditItemIndex = -1
            GridDisp()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub
End Class