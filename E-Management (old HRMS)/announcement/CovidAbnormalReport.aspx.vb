Imports System.Data.SqlClient

Partial Public Class CovidAbnormalReport
    Inherits System.Web.UI.Page

    ' Dim constr As String = "Data Source=Techfics;Initial Catalog=hrmis;uid=sa;password=TechficsPro"
    Dim constr As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"

    Function InsertCovid19(ByVal Options As String, ByVal empcode As String, ByVal EmpName As String, ByVal HOP As String, ByVal ICNO As String, ByVal Quest1 As String, ByVal Quest2 As String, ByVal Quest3 As String, ByVal Quest4 As String, ByVal Quest5 As String, ByVal Quest6 As String, ByVal Quest6Detail1 As String, ByVal Quest6Detail2 As String, ByVal Quest7Detail1 As String, ByVal Quest7Detail2 As String, ByVal Quest4_b As String, ByVal Quest7 As String) As DataSet
        '   MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Covid19", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@Options", Options)
        Command.Parameters.AddWithValue("@empcode", empcode)
        Command.Parameters.AddWithValue("@empname", EmpName)
        Command.Parameters.AddWithValue("@hop", HOP)
        Command.Parameters.AddWithValue("@icnumber", ICNO)
        Command.Parameters.AddWithValue("@quest1", Quest1)
        Command.Parameters.AddWithValue("@quest2", Quest2)
        Command.Parameters.AddWithValue("@quest3", Quest3)
        Command.Parameters.AddWithValue("@quest4", Quest4)
        Command.Parameters.AddWithValue("@quest5", Quest5)
        Command.Parameters.AddWithValue("@quest6", Quest6)
        Command.Parameters.AddWithValue("@quest6detail1", Quest6Detail1)
        Command.Parameters.AddWithValue("@quest6detail2", Quest6Detail2)
        Command.Parameters.AddWithValue("@quest7detail1", Quest7Detail1)
        Command.Parameters.AddWithValue("@quest7detail2", Quest7Detail2)
        Command.Parameters.AddWithValue("@appdate", "")
        Command.Parameters.AddWithValue("@Quest4_b", Quest4_b)
        Command.Parameters.AddWithValue("@Quest7", Quest7)

        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "tbl_noflogin")
        con.Close()
        Return ds
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empcode") = "" Then
            Response.Redirect("http://mmsbsql1/emgmt/announcement/logincovid.aspx")
            'Response.Redirect("http://58.26.100.36:55562/ymgw/hrmis/login.aspx")

        End If

        If IsPostBack = False Then

            Dim TmpDs As New DataSet
            TmpDs = New DataSet
            TmpDs = InsertCovid19("AbnormalAll", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

            GridView1.DataSource = TmpDs.Tables(0)
            GridView1.DataBind()

            If TmpDs.Tables(0).Rows.Count >= 1 Then
                For Tmpi As Integer = 0 To GridView1.Rows.Count - 1
                    GridView1.Rows(Tmpi).Cells(4).Font.Bold = True
                    If GridView1.Rows(Tmpi).Cells(4).Text = "Answered with Yes" Then
                        GridView1.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Red
                        GridView1.Rows(Tmpi).Cells(4).ForeColor = Drawing.Color.Yellow
                    ElseIf GridView1.Rows(Tmpi).Cells(4).Text = "Declared" Then
                        GridView1.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Green
                        GridView1.Rows(Tmpi).Cells(4).ForeColor = Drawing.Color.White
                    Else
                        GridView1.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Yellow
                    End If
                Next
            End If

            TmpDs = New DataSet
            TmpDs = InsertCovid19("NotDeclared", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

            GridView4.DataSource = TmpDs.Tables(0)
            GridView4.DataBind()

            If TmpDs.Tables(0).Rows.Count >= 1 Then
                For Tmpi As Integer = 0 To GridView4.Rows.Count - 1
                    GridView4.Rows(Tmpi).Cells(4).Font.Bold = True
                    If GridView4.Rows(Tmpi).Cells(4).Text = "Answered with Yes" Then
                        GridView4.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Red
                        GridView4.Rows(Tmpi).Cells(4).ForeColor = Drawing.Color.Yellow
                    ElseIf GridView4.Rows(Tmpi).Cells(4).Text = "Declared" Then
                        GridView4.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Green
                        GridView4.Rows(Tmpi).Cells(4).ForeColor = Drawing.Color.White
                    Else
                        GridView4.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Yellow
                    End If
                Next
            End If

            TmpDs = New DataSet
            TmpDs = InsertCovid19("Abnormal", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

            GridView3.DataSource = TmpDs.Tables(0)
            GridView3.DataBind()

            If TmpDs.Tables(0).Rows.Count >= 1 Then
                For Tmpi As Integer = 0 To GridView3.Rows.Count - 1
                    GridView3.Rows(Tmpi).Cells(4).Font.Bold = True
                    If GridView3.Rows(Tmpi).Cells(4).Text = "Answered with Yes" Then
                        GridView3.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Red
                        GridView3.Rows(Tmpi).Cells(4).ForeColor = Drawing.Color.Yellow
                    ElseIf GridView3.Rows(Tmpi).Cells(4).Text = "Declared" Then
                        GridView3.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Green
                        GridView3.Rows(Tmpi).Cells(4).ForeColor = Drawing.Color.White
                    Else
                        GridView3.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Yellow
                    End If
                Next
            End If

        End If
        

    End Sub

    Protected Sub empcode1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode1.TextChanged

        If empcode1.Text.Trim.Equals("") Then
            Exit Sub
        End If

        Dim DsData As New DataSet
        DsData = InsertCovid19("AbnormalByEmpCode", empcode1.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
        GridView2.DataSource = DsData
        GridView2.DataBind()

        For Tmpi As Integer = 0 To GridView2.Rows.Count - 2
            GridView2.Rows(Tmpi).Cells(4).Font.Bold = True
            If GridView2.Rows(Tmpi).Cells(4).Text = "Answered with Yes" Then
                GridView2.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Red
                GridView2.Rows(Tmpi).Cells(4).ForeColor = Drawing.Color.Yellow
            ElseIf GridView2.Rows(Tmpi).Cells(4).Text = "Declared" Then
                GridView2.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Green
                GridView2.Rows(Tmpi).Cells(4).ForeColor = Drawing.Color.White
            Else
                GridView2.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Yellow
            End If
        Next

        If DsData.Tables(0).Rows.Count < 1 Then
            lblmsg.Text = "No Data"
        End If
    End Sub



    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If empcode1.Text.Trim.Equals("") Then
            Exit Sub
        End If

        Dim DsData As New DataSet
        DsData = InsertCovid19("AbnormalByEmpCode", empcode1.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
        GridView2.DataSource = DsData
        GridView2.DataBind()

        For Tmpi As Integer = 0 To GridView2.Rows.Count - 1
            GridView2.Rows(Tmpi).Cells(4).Font.Bold = True
            If GridView2.Rows(Tmpi).Cells(4).Text = "Answered with Yes" Then
                GridView2.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Red
                GridView2.Rows(Tmpi).Cells(4).ForeColor = Drawing.Color.Yellow
            ElseIf GridView2.Rows(Tmpi).Cells(4).Text = "Declared" Then
                GridView2.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Green
                GridView2.Rows(Tmpi).Cells(4).ForeColor = Drawing.Color.White
            Else
                GridView2.Rows(Tmpi).Cells(4).BackColor = Drawing.Color.Yellow
            End If
        Next

        If DsData.Tables(0).Rows.Count < 1 Then
            lblmsg.Text = "No Data"
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session("empcode") = ""
        Response.Redirect("http://mmsbsql1/emgmt/announcement/logincovid.aspx")
        'Response.Redirect("http://58.26.100.36:55562/ymgw/hrmis/login.aspx")
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Response.Redirect("covid19declaration.aspx")
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Response.Redirect("CovidDailyAbnormalReport.aspx")
    End Sub
End Class