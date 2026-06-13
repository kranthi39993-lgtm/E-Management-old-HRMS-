Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmScrType
    Inherits System.Web.UI.Page
    Dim mynet As New Emanagement.netglobal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        '#Add New Screen Types
        If Len(Trim(TxtBoxScrType.Text)) <> 0 Then
            Try
                mynet.db_cn()
                mynet.db_open()
                Call mynet.dbSp_open("sp_insupdScrTypes")
                command.Parameters.AddWithValue("@ScrType", Trim(TxtBoxScrType.Text))
                command.Parameters.AddWithValue("@ScrTypeDesc", Trim(TxtBoxScrTypeDesc.Text))
                command.ExecuteNonQuery()
                mynet.db_close()
                TxtBoxScrType.Text = ""
                TxtBoxScrTypeDesc.Text = ""
                GridView1.DataBind()
                TxtBoxScrType.Focus()
                LblMsg.Text = "Congratulations! You have Saved successfully. "
                LblMsg.ForeColor = Drawing.Color.DarkGreen
            Catch ex As Exception
                LblMsg.Text = ex.Message
                LblMsg.ForeColor = Drawing.Color.Red
            End Try
        Else
            LblMsg.Text = "Please Enter Screen Type "
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        End If
        '##
    End Sub
End Class