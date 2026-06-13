Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.[Global]
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmMMchPw
    Inherits System.Web.UI.Page
    Dim mynet As New emanagement.netglobal
    Dim MyGlobal As New emanagement.globalinfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click
        If Len(Trim(TxtPwd.Text)) > 4 Then
            If Len(Trim(TxtPwd.Text)) <> 0 Then
                If Len(Trim(TxtCPwd.Text)) <> 0 Then
                    If Trim(TxtPwd.Text) = Trim(TxtCPwd.Text) Then
                        Try
                            mynet.db_cn()
                            mynet.db_open()
                            Call mynet.Update_EMPmaster_status(dbConnWeb, daConnWeb, 2, "update empmaster set pwd='" & Trim(TxtPwd.Text) & "' where empcode='" & Session("empcode") & "'")
                            mynet.db_close()
                            TxtPwd.Text = ""
                            TxtCPwd.Text = ""
                            LblMsg.Text = "Congratulations! You have changed your password successfully. "
                            LblMsg.ForeColor = Drawing.Color.DarkGreen
                        Catch ex As Exception
                            LblMsg.Text = ex.Message
                            LblMsg.ForeColor = Drawing.Color.Red
                        End Try
                    Else
                        LblMsg.Text = "Passwords you entered are not same. Please try again!"
                        LblMsg.ForeColor = Drawing.Color.Red
                        TxtPwd.Text = ""
                        TxtCPwd.Text = ""
                        TxtPwd.Focus()
                    End If
                Else
                    LblMsg.Text = "Please confirm the Password."
                    LblMsg.ForeColor = Drawing.Color.Red
                    TxtCPwd.Focus()
                End If
            Else
                LblMsg.Text = "Please enter Password."
                LblMsg.ForeColor = Drawing.Color.Red
                TxtPwd.Focus()
            End If
        Else
            LblMsg.Text = "Password must behave at least 4 characters."
            LblMsg.ForeColor = Drawing.Color.Red
            TxtPwd.Text = ""
            TxtPwd.Focus()
        End If
    End Sub
End Class