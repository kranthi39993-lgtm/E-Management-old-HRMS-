Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class RegisterMouldName
    Inherits System.Web.UI.Page

    Dim mynet As New emanagement.netglobal

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            With CMbDepartment.Items
                .Add("-Select-")
                .Add("Substrate")
                .Add("TPH")
                .Add("CV")
                .Add("Ferrite Magnet")
            End With
        End If
    End Sub

   

    Protected Sub BtnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        Try

        
            mynet.db_cn()
            mynet.dbM_open()

            Call mynet.dbSpM_open("Insert_MouldName")
            command.Parameters.AddWithValue("@FGID", Session("fgid"))
            command.Parameters.AddWithValue("@MouldName", UCase(TxtMName.Text))
            command.Parameters.AddWithValue("@MouldType", CmbMType.Text)
            command.Parameters.AddWithValue("@CreatedBy", Session("empcode"))
            command.Parameters.AddWithValue("@CreatedOn", Now)
            command.ExecuteNonQuery()
            mynet.dbM_close()

            LblMsg.Text = "Congratulations! You have Saved successfully. "
            LblMsg.ForeColor = Drawing.Color.DarkGreen
        Catch ex As Exception
            LblMsg.Text = ex.Message
            LblMsg.ForeColor = Drawing.Color.Red
        End Try
    End Sub

    Protected Sub CMbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMbDepartment.SelectedIndexChanged



        If CMbDepartment.Text = "Substrate" Then
            Session("fgid") = "21"
        ElseIf CMbDepartment.Text = "TPH" Then
            Session("fgid") = "71"
        ElseIf CMbDepartment.Text = "CV" Then
            Session("fgid") = "31"
        ElseIf CMbDepartment.Text = "Ferrite Magnet" Then
            Session("fgid") = "42"
        ElseIf CMbDepartment.Text = "Ferrite Sheet" Then
            Session("fgid") = "43"
        End If
    End Sub

   
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("EditMouldName.aspx")
    End Sub
End Class