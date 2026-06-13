Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.EManagement.globalinfo
Imports E_Management.EManagement.EMSapplications
Imports E_Management.EManagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmReqMould
    Inherits System.Web.UI.Page
    Dim mynet As New emanagement.netglobal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            With CMBDepartment.Items
                .Add("-Select-")
                .Add("Substrate")
                .Add("TPH")
                .Add("CV")
                .Add("Ferrite Magnet")
            End With
        End If

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Calendar1.Visible = True
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        TxtBoxExpDate.Text = ""
        TxtBoxExpDate.Text = Calendar1.SelectedDate
        Calendar1.Visible = False
    End Sub




    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        If CMBDepartment.Text = "-Select-" Then
            LblMsg.Text = "Please Select Department"
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        Else
            LblMsg.Text = ""
            LblMsg.ForeColor = Drawing.Color.Green
        End If

        If TxtBoxExpDate.Text = "" Then
            LblMsg.Text = "Please Select Date Needed"
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        Else
            LblMsg.Text = ""
            LblMsg.ForeColor = Drawing.Color.Green
        End If




        Dim PressMC As String

        Try
            If CMBDepartment.Text = "Substrate" Then
                PressMC = DrpDwnPressMC_Sub.Text

            ElseIf CMBDepartment.Text = "TPH" Then
                PressMC = DrpDwnPressMC_TPH.Text
            ElseIf CMBDepartment.Text = "CV" Then
                PressMC = DrpDwnPressMc_CV.Text
            ElseIf CMBDepartment.Text = "Ferrite Magnet" Then
                PressMC = DrpDwnPressMC_Mag.Text
            ElseIf CMBDepartment.Text = "Ferrite Sheet" Then

            End If
        Catch ex As Exception

        End Try
        Dim ExpDate

        ExpDate = CDate(TxtBoxExpDate.Text)

        Try
            ExpDate = CDate(TxtBoxExpDate.Text)
            mynet.db_cn()
            mynet.dbM_open()
            'Call mynet.Update_MMSmaster_status(dbConnWeb, daConnWeb, 2, "update mouldmaster set status='" & DrpDwnStatus.SelectedValue & "' , expdate= '" & ExpDate & "', pressmc='" & PressMC & "' where product='" & DrpdwnProduct.SelectedItem.Text & "' and mouldno='" & DrpDwnMould.SelectedItem.Text & "'")
            Call mynet.dbSpM_open("insert_MouldRequest")
            'MsgBox(Session("empcode"))
            command.Parameters.AddWithValue("@Product", Trim(DrpdwnProduct.SelectedItem.Text))
            command.Parameters.AddWithValue("@MouldName", Trim(DrpDwnMould.Text))
            command.Parameters.AddWithValue("@pressmc", PressMC)
            command.Parameters.AddWithValue("@expdate", ExpDate)
            command.Parameters.AddWithValue("@requestedby", Session("empcode"))
            command.Parameters.AddWithValue("@requestDate", Now)
            command.Parameters.AddWithValue("@FGID", Session("fgid"))
            command.ExecuteNonQuery()
            'Call mynet.Update_MMSmaster_status(dbConnWeb, daConnWeb, 2, "update mouldmaster set status='R' , expdate= '" & ExpDate & "', pressmc='" & PressMC & "' where product='" & DrpdwnProduct.SelectedItem.Text & "' and mouldno='" & DrpDwnMould.SelectedItem.Text & "'")
            mynet.dbM_close()

            'GridView1.DataBind()

            LblMsg.Text = "Congratulations! You have Saved successfully. "
            LblMsg.ForeColor = Drawing.Color.DarkGreen

        Catch ex As Exception
            LblMsg.Text = ex.Message
            LblMsg.ForeColor = Drawing.Color.Red
        End Try
    End Sub

    

    '-------04/03/2013--------
    Protected Sub CMBDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDepartment.SelectedIndexChanged

        If CMBDepartment.Text = "Substrate" Then
            Session("fgid") = "21"
            DrpDwnPressMC_Sub.Visible = True
            DrpDwnPressMc_CV.Visible = False
            DrpDwnPressMC_TPH.Visible = False
            DrpDwnPressMC_Mag.Visible = False

        ElseIf CMBDepartment.Text = "TPH" Then
            Session("fgid") = "71"
            DrpDwnPressMc_CV.Visible = False
            DrpDwnPressMC_Sub.Visible = False
            DrpDwnPressMC_TPH.Visible = True
            DrpDwnPressMC_Mag.Visible = False

        ElseIf CMBDepartment.Text = "CV" Then
            Session("fgid") = "31"
            DrpDwnPressMc_CV.Visible = True
            DrpDwnPressMC_Sub.Visible = False
            DrpDwnPressMC_TPH.Visible = False
            DrpDwnPressMC_Mag.Visible = False

        ElseIf CMBDepartment.Text = "Ferrite Magnet" Then
            Session("fgid") = "42"
            DrpDwnPressMc_CV.Visible = False
            DrpDwnPressMC_Sub.Visible = False
            DrpDwnPressMC_TPH.Visible = False
            DrpDwnPressMC_Mag.Visible = True
        ElseIf CMBDepartment.Text = "Ferrite Sheet" Then
            Session("fgid") = "43"

        End If
    End Sub

    
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("EditRequestMould.aspx")
    End Sub
End Class