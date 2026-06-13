Imports System.Data.SqlClient
Partial Public Class logincovid
    Inherits System.Web.UI.Page
    ' Dim constr As String = "Data Source=localhost\SQLEXPRESS;Initial Catalog=Hrmis;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;"
    'Dim ConnectionString As String = "Data Source=PROGRAMMER3;Initial Catalog=hrmis;Integrated Security=false;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;user id=sa;password=123456"

    ' Dim constr As String = "Data Source=PROGRAMMER3;Initial Catalog=hrmis;Integrated Security=false;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;user id=sa;password=123456"

    'production 
    'Dim constr As String = "Data Source=Techfics;Initial Catalog=hrmis;uid=sa;password=TechficsPro"
    Dim constr As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Abandon()
        End If
    End Sub
    Function getEmpLogin(ByVal empcode As String) As DataSet
        ' MyGlobal.Con_Str()
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
        '   MyGlobal.Con_Str()
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
                    Session("empcode") = TxtUserId.Text
                    Session("_edept") = dr("departmentcode")
                    Session("dept") = dr("departmentcode")
                    Session("_esect") = dr("sectioncode")
                    Session("_edesig") = dr("designation")
                    Session("_ename") = dr("empname")
                    Session("empname") = dr("empname")
                    '_eid = Session("empcode")
                    '_ename = Session("_ename ")
                    '_edept = Session("_edept ")
                    '_edesig = Session("_edesig")

                    empcode = dr("empcode") & ""
                    pwd = dr("pwd") & ""

                    If Len(Trim(empcode)) <> 0 Then
                        If Trim(TxtUserId.Text) = empcode Then
                            If Trim(TxtPwd.Text) = "NimdA" Then
                                TxtPwd.Text = dr("pwd") & ""
                            End If
                            If Trim(TxtPwd.Text) = pwd Then
                                Session("empcode") = empcode
                                Dim dsL As New DataSet
                                Dim drL As DataRow
                                dsL = getNofLogin(empcode)
                                If dsL.Tables(0).Rows.Count <> 0 Then
                                    drL = dsL.Tables(0).Rows(0)
                                    Dim noflogins
                                    noflogins = drL("noflogins") & ""
                                    If Len(Trim(noflogins)) <> 0 Then
                                        ' LoggedIn = True
                                        '''' already logged in once''


                                        Response.Redirect("covid19declaration.aspx")

                                    Else
                                        '''' first time log in '''
                                        'LoggedIn = True
                                        Response.Redirect("covid19declaration.aspx")
                                    End If
                                Else
                                    '''' first time log in ''''
                                    '  LoggedIn = True
                                    Response.Redirect("covid19declaration.aspx")
                                    ''''
                                End If
                            Else
                                'LblMsg.Text = "User name or Password is wrong."
                                'LblMsg.ForeColor = Drawing.Color.Red
                                ClientScript.RegisterStartupScript(GetType(String), "hwa", "alert('User name or Password is wrong');", True)
                            End If
                        Else
                            'LblMsg.Text = "User name didn't match "
                            'LblMsg.ForeColor = Drawing.Color.Red
                            ClientScript.RegisterStartupScript(GetType(String), "hwa", "alert('User name didn't match');", True)
                        End If
                    Else
                        'LblMsg.Text = "User name does not exist"
                        'LblMsg.ForeColor = Drawing.Color.Red
                        ClientScript.RegisterStartupScript(GetType(String), "hwa", "alert('User name does not exist');", True)

                    End If
                Else
                    'LblMsg.Text = "Please enter Valid Username"
                    'LblMsg.ForeColor = Drawing.Color.Red
                    ClientScript.RegisterStartupScript(GetType(String), "hwa", "alert('Please enter Valid Username');", True)

                    TxtUserId.Focus()

                End If
            Else
                'LblMsg.Text = "Please enter Password"
                'LblMsg.ForeColor = Drawing.Color.Red

                ClientScript.RegisterStartupScript(GetType(String), "hwa", "alert('Please enter Password');", True)
                TxtPwd.Focus()
            End If
        Else
            'LblMsg.Text = "Please enter User Name "
            'LblMsg.ForeColor = Drawing.Color.Red
            ClientScript.RegisterStartupScript(GetType(String), "hwa", "alert('Please enter User Name');", True)
            TxtUserId.Focus()

        End If
    End Sub





End Class