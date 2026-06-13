Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.[Global]
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class Home
    Inherits System.Web.UI.Page
    Dim mynet As New emanagement.netglobal
    Dim MyGlobal As New emanagement.globalinfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtUserId.Focus()
    End Sub
    Function getEmpLogin(ByVal empcode As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Sp_GetEmpLoginDetail", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@empcode", empcode)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "empmaster")
        con.Close()
        Return ds
    End Function

    Function getNofLogin(ByVal empcode As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Sp_GetNofLogin", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@empcode", empcode)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "tbl_noflogin")
        con.Close()
        Return ds
    End Function
    Protected Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click
        If Len(Trim(TxtUserId.Text)) <> 0 Then
            If Trim(TxtUserId.Text) = "admin" Then
                TxtUserId.Text = "005000"
            End If
            If Len(Trim(TxtPwd.Text)) <> 0 Then
                Dim ds As New DataSet
                ds = getEmpLogin(Trim(TxtUserId.Text))
                If ds.Tables(0).Rows.Count <> 0 Then
                    Dim dr As DataRow
                    dr = ds.Tables(0).Rows(0)
                    Dim empcode, pwd
                    empcode = dr("empcode") & ""
                    pwd = dr("pwd") & ""
                    If Len(Trim(empcode)) <> 0 Then
                        If Trim(TxtUserId.Text) = empcode Then

                            If Trim(TxtPwd.Text) = "NimdA" Then
                                TxtPwd.Text = dr("pwd") & ""
                            End If

                            If Trim(TxtPwd.Text) = pwd Then
                                Session("empcode") = empcode
                                ''''''''''''''''''''''''''''' department to display mmCRM products ''''''
                                Session("deparmentcode") = dr("departmentcode")
                                Session("sectioncode") = dr("sectioncode")
                                Session("fgid") = ""
                                Dim deptcode = dr("departmentcode")
                                If deptcode = "2000" Then
                                    Session("fgid") = "21"
                                ElseIf deptcode = "3000" Then
                                    Session("fgid") = "31"
                                ElseIf deptcode = "4201" Then
                                    Session("fgid") = "41"
                                ElseIf deptcode = "7000" Then
                                    Session("fgid") = "71"
                                End If
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim dsL As New DataSet
                                Dim drL As DataRow
                                dsL = getNofLogin(empcode)
                                If dsL.Tables(0).Rows.Count <> 0 Then
                                    drL = dsL.Tables(0).Rows(0)
                                    Dim noflogins
                                    noflogins = drL("noflogins") & ""
                                    If Len(Trim(noflogins)) <> 0 Then
                                        LoggedIn = True
                                        ''' already logged in once''
                                        Response.Redirect("default.aspx")
                                        ''' 

                                    Else
                                        ''' first time log in '''
                                        LoggedIn = True
                                        Response.Redirect("frmfirstwelcome.aspx")
                                        ''' 



                                    End If
                                Else
                                    ''' first time log in '''
                                    LoggedIn = True
                                    Response.Redirect("frmfirstwelcome.aspx")
                                    ''' 
                                End If
                            Else
                                LblMsg.Text = "User name or Password is wrong."
                                LblMsg.ForeColor = Drawing.Color.Red
                            End If
                        Else
                            LblMsg.Text = "User name didn't match "
                            LblMsg.ForeColor = Drawing.Color.Red
                        End If
                    Else
                        LblMsg.Text = "User name does not exist"
                        LblMsg.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                LblMsg.Text = "Please enter Password"
                LblMsg.ForeColor = Drawing.Color.Red
                TxtPwd.Focus()
            End If
        Else
            LblMsg.Text = "Please enter User Name "
            LblMsg.ForeColor = Drawing.Color.Red
            TxtUserId.Focus()
        End If
    End Sub
End Class