
Imports E_Management.CRMlognetglobal
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls


Partial Public Class ForwarderInvoiceSubmission
    Inherits Messagebox

    Dim Cmd As New SqlCommand
    Dim Ad As New SqlDataAdapter
    Dim TmpDs As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim ob As New CRMlognetglobal
            Dim conStr1
            ob.db_cn()
            conStr1 = ob.sConnString

            Dim con1 As New SqlConnection(conStr1)
            con1.Open()

            If IsPostBack = False Then

                CmbInvNo.Items.Add("-Select-")

                Cmd = New SqlCommand("Select Distinct InvNo From Log_CustomerBillUploading where InvNo Not in (Select InvoiceNo From Log_ForwarderInvoiceDetails Where VerifyStatus='Verified' or VerifyStatus='Approved')", con1)
                TmpDs = New DataSet()

                Ad = New SqlDataAdapter(Cmd)
                Ad.Fill(TmpDs, "InvNo")

                For Tmpi As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
                    CmbInvNo.Items.Add(TmpDs.Tables(0).Rows(Tmpi).Item(0))
                Next

            End If

            con1.Close()

        Catch ex As Exception
            msg(ex.ToString)
        End Try
    End Sub

    Protected Sub CmbInvNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbInvNo.SelectedIndexChanged
        'Try

        '    CmbForwarder.Items.Clear()

        '    CmbForwarder.Items.Add("-Select-")

        '    CmbForwarder.Items.Add("Forwarder1")
        '    CmbForwarder.Items.Add("Forwarder2")
        '    CmbForwarder.Items.Add("Forwarder3")


        'Catch ex As Exception
        '    MsgBox(ex.ToString)

        'End Try
        TxtDepartment.Text = ""
        TxtDifference.Text = ""
        TxtForwarderInvoiceNumber.Text = ""
        TxtForwarderInvoiceValue.Text = ""
        LblForwarderName.Text = ""
        LblRemarks.Text = ""
        TxtFrom.Text = ""
        TxtTo.Text = ""
        TxtQuotedAmount.Text = ""
        TxtRemarks.Text = ""


        CmbForwarder.Items.Clear()
        CmbForwarder.Items.Add("-Select-")

        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString
        Dim con1 As New SqlConnection(conStr1)

        Try

            con1.Open()

            Cmd = New SqlCommand("Select * From Log_ShippingDetails Where InvoiceNo='" & CmbInvNo.Text & "'", con1)
            Ad = New SqlDataAdapter(Cmd)
            TmpDs = New DataSet()
            Ad.Fill(TmpDs, "Verify")

            If TmpDs.Tables(0).Rows.Count >= 1 Then
                If Not (TmpDs.Tables(0).Rows(0).Item("Forwarder1").Equals("")) Then
                    CmbForwarder.Items.Add("Forwarder1")
                End If

                If Not (TmpDs.Tables(0).Rows(0).Item("Forwarder2").Equals("")) Then
                    CmbForwarder.Items.Add("Forwarder2")
                End If

                If Not (TmpDs.Tables(0).Rows(0).Item("Forwarder3").Equals("")) Then
                    CmbForwarder.Items.Add("Forwarder3")
                End If
            End If

            Cmd = New SqlCommand("Select * From Log_ForwarderInvoiceDetails Where InvoiceNo='" & CmbInvNo.Text & "' and VerifyStatus='Pending'", con1)
            Ad = New SqlDataAdapter(Cmd)
            TmpDs = New DataSet()
            Ad.Fill(TmpDs, "Verify")
            If TmpDs.Tables(0).Rows.Count <= 0 Then

                Cmd = New SqlCommand("Select Department From Log_CustomerBillUploading Where InvNo='" & CmbInvNo.Text & "'", con1)
                TmpDs = New DataSet()

                Ad = New SqlDataAdapter(Cmd)
                Ad.Fill(TmpDs, "InvNo")

                If TmpDs.Tables(0).Rows.Count >= 1 Then
                    TxtDepartment.Text = TmpDs.Tables(0).Rows(0).Item(0)
                Else
                    TxtDepartment.Text = ""
                    msg("Please Upload Any One of the Document for this Invoice")
                    Exit Sub

                End If

            Else
                TxtDepartment.Text = TmpDs.Tables(0).Rows(0).Item("DepartmentName")
                TxtDifference.Text = TmpDs.Tables(0).Rows(0).Item("Difference")
                TxtForwarderInvoiceNumber.Text = TmpDs.Tables(0).Rows(0).Item("ForwarderInvoiceNo")
                TxtForwarderInvoiceValue.Text = TmpDs.Tables(0).Rows(0).Item("ForwarderInvoiceValue")
                LblForwarderName.Text = TmpDs.Tables(0).Rows(0).Item("ForwarderName")
                LblRemarks.Text = TmpDs.Tables(0).Rows(0).Item("Remarks")
                TxtFrom.Text = TmpDs.Tables(0).Rows(0).Item("DepartPlace")
                TxtTo.Text = TmpDs.Tables(0).Rows(0).Item("ArrivalPlace")
                TxtQuotedAmount.Text = TmpDs.Tables(0).Rows(0).Item("QuotedAmount")
                CmbForwarder.SelectedItem.Text = TmpDs.Tables(0).Rows(0).Item("ForwarderType")

                TxtRemarks.Visible = True
                LblRemarks.Visible = True



            End If

            con1.Close()
        Catch ex As Exception
            con1.Close()
            msg("Error")
        End Try
    End Sub

    Protected Sub CmbForwarder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbForwarder.SelectedIndexChanged

        Try
            Dim ob As New CRMlognetglobal
            Dim conStr1
            ob.db_cn()
            conStr1 = ob.sConnString

            Dim con1 As New SqlConnection(conStr1)
            con1.Open()


            Cmd = New SqlCommand("Select * From Log_ForwarderInvoiceDetails Where InvoiceNo='" & CmbInvNo.Text & "' and VerifyStatus='Pending' and ForwarderType='" & CmbForwarder.Text & "'", con1)
            Ad = New SqlDataAdapter(Cmd)
            TmpDs = New DataSet()
            Ad.Fill(TmpDs, "Verify")
            If TmpDs.Tables(0).Rows.Count <= 0 Then
            

                Cmd = New SqlCommand("Select Forwarder1, Forwarder2, Forwarder3, AAmount1,AAmount2, AAmount3, From1, To1, From2, To2, From3, To3  From Log_ShippingDetails Where InvoiceNo='" & CmbInvNo.Text & "'", con1)
                TmpDs = New DataSet()

                Ad = New SqlDataAdapter(Cmd)
                Ad.Fill(TmpDs, "InvNo")

                If CmbForwarder.Text = "Forwarder1" Then
                    LblForwarderName.Text = (TmpDs.Tables(0).Rows(0).Item(0))
                    TxtQuotedAmount.Text = (TmpDs.Tables(0).Rows(0).Item(3))
                    TxtFrom.Text = (TmpDs.Tables(0).Rows(0).Item(6))
                    TxtTo.Text = (TmpDs.Tables(0).Rows(0).Item(7))
                End If

                If CmbForwarder.Text = "Forwarder2" Then
                    LblForwarderName.Text = (TmpDs.Tables(0).Rows(0).Item(1))
                    TxtQuotedAmount.Text = (TmpDs.Tables(0).Rows(0).Item(4))
                    TxtFrom.Text = (TmpDs.Tables(0).Rows(0).Item(8))
                    TxtTo.Text = (TmpDs.Tables(0).Rows(0).Item(9))
                End If

                If CmbForwarder.Text = "Forwarder3" Then
                    LblForwarderName.Text = (TmpDs.Tables(0).Rows(0).Item(2))
                    TxtQuotedAmount.Text = (TmpDs.Tables(0).Rows(0).Item(5))
                    TxtFrom.Text = (TmpDs.Tables(0).Rows(0).Item(10))
                    TxtTo.Text = (TmpDs.Tables(0).Rows(0).Item(11))
                End If

                TxtForwarderInvoiceValue.Text = ""

                TxtRemarks.Visible = False
            Else
                LblForwarderName.Text = TmpDs.Tables(0).Rows(0).Item("ForwarderName")
                LblRemarks.Text = TmpDs.Tables(0).Rows(0).Item("Remarks")
                TxtFrom.Text = TmpDs.Tables(0).Rows(0).Item("DepartPlace")
                TxtTo.Text = TmpDs.Tables(0).Rows(0).Item("ArrivalPlace")
                TxtQuotedAmount.Text = TmpDs.Tables(0).Rows(0).Item("QuotedAmount")
                TxtForwarderInvoiceNumber.Text = TmpDs.Tables(0).Rows(0).Item("ForwarderInvoiceNo")
                TxtForwarderInvoiceValue.Text = TmpDs.Tables(0).Rows(0).Item("ForwarderInvoiceValue")

            End If

            con1.Close()

        Catch ex As Exception
            msg(ex.ToString)

        End Try
        
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()
        Try

            

            TxtDifference.Text = TxtForwarderInvoiceValue.Text - TxtQuotedAmount.Text


            If TxtDifference.Text >= 1 Then
                If TxtRemarks.Text.Trim.Equals("") Then
                    LblRemarks.Visible = True
                    TxtRemarks.Visible = True
                    msg("Please Enter Remarks for Price Difference")
                    Exit Sub
                End If
            End If

            If TxtDepartment.Text.Trim.Equals("") Then
                msg("Invalid Department Name")
                Exit Sub
            End If


            Cmd = New SqlCommand("Select * From Log_ForwarderInvoiceDetails Where InvoiceNo='" & CmbInvNo.Text & "' and VerifyStatus='Pending' and ForwarderType='" & CmbForwarder.Text & "'", con1)
            Ad = New SqlDataAdapter(Cmd)
            TmpDs = New DataSet()
            Ad.Fill(TmpDs, "Verify")
            If TmpDs.Tables(0).Rows.Count <= 0 Then

                Cmd = New SqlCommand("Insert Into Log_ForwarderInvoiceDetails (FInvSubmissionDate, InvoiceNo, DepartmentName, ForwarderType, ForwarderName, DepartPlace, ArrivalPlace, QuotedAmount, ForwarderInvoiceNo, ForwarderInvoiceValue, Difference, Remarks, CreatedBy, CreatedOn) values ('" & DateTime.Now & "','" & CmbInvNo.Text & "','" & TxtDepartment.Text & "','" & CmbForwarder.Text & "','" & LblForwarderName.Text & "','" & TxtFrom.Text & "','" & TxtTo.Text & "'," & TxtQuotedAmount.Text & ",'" & TxtForwarderInvoiceNumber.Text & "'," & TxtForwarderInvoiceValue.Text & "," & TxtDifference.Text & ",'" & TxtRemarks.Text & "','" & Session("empcode") & "','" & DateTime.Now & "')", con1)
                Cmd.ExecuteNonQuery()
                con1.Close()
            Else
                Cmd = New SqlCommand("Update  Log_ForwarderInvoiceDetails Set FInvSubmissionDate='" & DateTime.Now & "', ForwarderName='" & LblForwarderName.Text & "', ArrivalPlace='" & TxtTo.Text & "' , DepartPlace='" & TxtFrom.Text & "' , QuotedAmount=" & TxtQuotedAmount.Text & ", ForwarderInvoiceNo='" & TxtForwarderInvoiceNumber.Text & "' , ForwarderInvoiceValue=" & TxtForwarderInvoiceValue.Text & ", Difference=" & TxtDifference.Text & ", Remarks='" & TxtRemarks.Text & "', CreatedBy='" & Session("empcode") & "', CreatedOn='" & DateTime.Now & "' Where InvoiceNo='" & CmbInvNo.Text & "' and VerifyStatus='Pending' and ForwarderType='" & CmbForwarder.Text & "'", con1)
                Cmd.ExecuteNonQuery()
                con1.Close()
            End If


            msg("Successfully Updated")

            LblRemarks.Visible = False
            TxtRemarks.Visible = False
            TxtRemarks.Text = ""

        Catch ex As Exception
            con1.Close()
            LblRemarks.Visible = False
            TxtRemarks.Visible = False
            TxtRemarks.Text = ""
        End Try

    End Sub

    Protected Sub TxtForwarderInvoiceValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtForwarderInvoiceValue.TextChanged


    End Sub

    Protected Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TxtDepartment.Text = ""
        TxtDifference.Text = ""
        TxtForwarderInvoiceNumber.Text = ""
        TxtForwarderInvoiceValue.Text = ""
        LblForwarderName.Text = ""
        LblRemarks.Text = ""
        TxtFrom.Text = ""
        TxtTo.Text = ""
        TxtQuotedAmount.Text = ""
        TxtRemarks.Text = ""
    End Sub
End Class