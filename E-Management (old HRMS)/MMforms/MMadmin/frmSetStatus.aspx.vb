Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmSetStatus
    Inherits System.Web.UI.Page
    Dim mynet As New emanagement.netglobal
    Dim MyGlobal As New emanagement.globalinfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        '#Add New Company
        Dim ExpDate
        Dim PressMC
        If Len(Trim(DrpdwnProduct.SelectedItem.Text)) <> 0 Then
            If Len(Trim(DrpDwnMould.SelectedItem.Text)) <> 0 Then
                If Trim(DrpDwnStatus.SelectedItem.Text) <> "Select Status" Then
                    If Trim(DrpDwnStatus.SelectedValue) = "P" Then
                        If DrpDwnPressMC.SelectedItem.Text <> "" Then
                        Else
                            LblMsg.Text = "Select Press Machine"
                            LblMsg.ForeColor = Drawing.Color.Red
                            Exit Sub
                        End If
                    ElseIf Trim(DrpDwnStatus.SelectedValue) = "M" Or Trim(DrpDwnStatus.SelectedValue) = "J" Then
                        If Len(Trim(TxtBoxExpDate.Text)) <> 0 Then
                        Else
                            LblMsg.Text = "Please enter expected date of return from repair"
                            LblMsg.ForeColor = Drawing.Color.Red
                            Exit Sub
                        End If
                    End If
                    If Len(Trim(TxtBoxExpDate.Text)) <> 0 Then
                        ExpDate = CDate(TxtBoxExpDate.Text)
                    Else
                        ExpDate = Now
                    End If
                    If Trim(DrpDwnStatus.SelectedValue) = "P" Then
                        If Len(Trim(DrpDwnPressMC.SelectedItem.Text)) <> 0 Then
                            PressMC = DrpDwnPressMC.SelectedItem.Text
                        Else
                            PressMC = ""
                        End If
                    End If
                    Try
                        mynet.db_cn()
                        mynet.dbM_open()
                        Call mynet.Update_MMSmaster_status(dbConnWeb, daConnWeb, 2, "update mouldmaster set status='" & DrpDwnStatus.SelectedValue & "' , expdate= '" & ExpDate & "', pressmc='" & PressMC & "' where product='" & DrpdwnProduct.SelectedItem.Text & "' and mouldno='" & DrpDwnMould.SelectedItem.Text & "'")
                        mynet.dbM_close()
                        TxtBoxMould.Text = ""
                        GridView1.DataBind()
                        TxtBoxMould.Focus()
                        LblMsg.Text = "Congratulations! You have Saved successfully. "
                        LblMsg.ForeColor = Drawing.Color.DarkGreen
                    Catch ex As Exception
                        LblMsg.Text = ex.Message
                        LblMsg.ForeColor = Drawing.Color.Red
                    End Try
                Else
                    LblMsg.Text = "Select Status"
                    LblMsg.ForeColor = Drawing.Color.Red
                    Exit Sub
                End If
            Else
                LblMsg.Text = "Select Mould "
                LblMsg.ForeColor = Drawing.Color.Red
                Exit Sub
            End If
        Else
            LblMsg.Text = "Select Product "
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        End If
        '##
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        TxtBoxExpDate.Text = ""
        TxtBoxExpDate.Text = Calendar1.SelectedDate
        Calendar1.Visible = False
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Calendar1.Visible = True
    End Sub

    Private Sub DrpdwnProduct_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpdwnProduct.DataBound

    End Sub

    Protected Sub DrpdwnProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpdwnProduct.SelectedIndexChanged
        Session("product") = DrpdwnProduct.SelectedItem.Text
    End Sub

    Private Sub DrpDwnMould_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpDwnMould.DataBound
        If DrpDwnMould.Items.Count > 0 Then
            TxtBoxMould.Text = ""
            TxtBoxMould.Text = DrpDwnMould.SelectedItem.Text
        End If
    End Sub

    Protected Sub DrpDwnMould_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpDwnMould.SelectedIndexChanged
        TxtBoxMould.Text = ""
        TxtBoxMould.Text = DrpDwnMould.SelectedItem.Text
    End Sub

    Protected Sub DrpDwnStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpDwnStatus.SelectedIndexChanged
        If Trim(DrpDwnStatus.SelectedValue) = "P" Then
            DrpDwnPressMC.Visible = True
        Else
            DrpDwnPressMC.Visible = False
        End If
    End Sub

    Protected Sub TxtBoxExpDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBoxExpDate.TextChanged

    End Sub
End Class