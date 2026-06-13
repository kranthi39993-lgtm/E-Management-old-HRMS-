Imports E_Management.CRMlognetglobal
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Partial Public Class ApprovalForwarderInvoiceKeyIn
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

        Cmd = New SqlCommand("SELECT UID,InvoiceNo, DepartmentName, FInvSubmissionDate, ForwarderName, ArrivalPlace, DepartPlace, ForwarderInvoiceNo, QuotedAmount, ForwarderInvoiceValue, Difference, Remarks FROM  Log_ForwarderInvoiceDetails Where VerifyStatus='Verified' and  UID=" & Session("refno"), con1)
        Ad = New SqlDataAdapter(Cmd)
        TmpDs = New DataSet()
        Ad.Fill(TmpDs, "Verify")

        TxtUID.Text = TmpDs.Tables(0).Rows(0).Item(0)
        TxtInvoiceNo.Text = TmpDs.Tables(0).Rows(0).Item(1)
        TxtDepartment.Text = TmpDs.Tables(0).Rows(0).Item(2)
        TxtFInvSubDate.Text = TmpDs.Tables(0).Rows(0).Item(3)
        TxtFName.Text = TmpDs.Tables(0).Rows(0).Item(4)
        TxtArrival.Text = TmpDs.Tables(0).Rows(0).Item(5)
        TxtDepart.Text = TmpDs.Tables(0).Rows(0).Item(6)
        TxtFInvNo.Text = TmpDs.Tables(0).Rows(0).Item(7)
        TxtQAmount.Text = TmpDs.Tables(0).Rows(0).Item(8)
        TxtFInvValue.Text = TmpDs.Tables(0).Rows(0).Item(9)
        TxtDiff.Text = TmpDs.Tables(0).Rows(0).Item(10)
        TxtRemarks.Text = TmpDs.Tables(0).Rows(0).Item(11)

        If TxtDiff.Text > 0 Then
            TxtDiff.BackColor = Drawing.Color.Red
        Else
            TxtDiff.BackColor = Drawing.Color.Green
        End If



        con1.Close()
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            If Val(TxtDiff.Text) >= 1 Then
                If TxtRemarks.Text.Trim.Length <= 0 Then
                    msg("Please Enter Valid Remarks!")
                    Exit Sub
                End If
            End If


            Dim ob As New CRMlognetglobal
            Dim conStr1
            ob.db_cn()
            conStr1 = ob.sConnString

            Dim con1 As New SqlConnection(conStr1)
            con1.Open()

            Cmd = New SqlCommand("Update Log_ForwarderInvoiceDetails Set VerifyStatus='Approved', Remarks='" & TxtRemarks.Text & "' Where UID=" & Session("refno"), con1)
            Cmd.ExecuteNonQuery()

            con1.Close()

            msg("Forwarder Invoice Verified")
            Response.Redirect("ApprovalForwarderInvoice.aspx")

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If Val(TxtDiff.Text) >= 1 Then
                If TxtRemarks.Text.Trim.Length <= 0 Then
                    msg("Please Enter Valid Remarks!")
                    Exit Sub
                End If
            End If

            Dim ob As New CRMlognetglobal
            Dim conStr1
            ob.db_cn()
            conStr1 = ob.sConnString

            Dim con1 As New SqlConnection(conStr1)
            con1.Open()

            Cmd = New SqlCommand("Update Log_ForwarderInvoiceDetails Set VerifyStatus='Rejected' , Remarks='" & TxtRemarks.Text & "'  Where UID=" & Session("refno"), con1)
            Cmd.ExecuteNonQuery()

            con1.Close()
            msg("Forwarder Invoice Rejected")
            Response.Redirect("ApprovalForwarderInvoice.aspx")


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub
End Class