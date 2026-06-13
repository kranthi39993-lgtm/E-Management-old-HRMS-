Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmSystems
    Inherits System.Web.UI.Page
    Dim mynet As New emanagement.netglobal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        '#Add New Systems
        If Len(Trim(TxtBoxSystem.Text)) <> 0 Then
            Try
                mynet.db_cn()
                mynet.db_open()
                Call mynet.dbSp_open("sp_insupdsystems")
                command.Parameters.AddWithValue("@systemname", Trim(TxtBoxSystem.Text))
                command.Parameters.AddWithValue("@systemdesc", Trim(TxtBoxSystemDesc.Text))
                command.ExecuteNonQuery()
                mynet.db_close()
                TxtBoxSystem.Text = ""
                TxtBoxSystemDesc.Text = ""
                GridView1.DataBind()
                TxtBoxSystem.Focus()
                LblMsg.Text = "Congratulations! You have Saved successfully. "
                LblMsg.ForeColor = Drawing.Color.DarkGreen
            Catch ex As Exception
                LblMsg.Text = ex.Message
                LblMsg.ForeColor = Drawing.Color.Red
            End Try
        Else
            LblMsg.Text = "Enter System Name "
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        End If
        '##
    End Sub
End Class