Imports System.Data.SqlClient

Partial Public Class covid19dailydeclaration
    Inherits System.Web.UI.Page

    ' Dim constr As String = "Data Source=Techfics;Initial Catalog=hrmis;uid=sa;password=TechficsPro"
    Dim constr As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"

    Function InsertCovid19(ByVal Options As String, ByVal empcode As String, ByVal EmpName As String, ByVal HOP As String, ByVal ICNO As String, ByVal Quest1 As String, ByVal Quest2 As String, ByVal Quest3 As String, ByVal Quest4 As String, ByVal Quest5 As String, ByVal Quest6 As String, ByVal Quest6Detail1 As String, ByVal Quest6Detail2 As String, ByVal Quest7Detail1 As String, ByVal Quest7Detail2 As String, ByVal Quest4_b As String, ByVal Quest7 As String) As DataSet
        '   MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Covid19Daily", con)
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
        Command.Parameters.AddWithValue("@appdate", Label5.Text)
        Command.Parameters.AddWithValue("@Quest4_b", Quest4_b)
        Command.Parameters.AddWithValue("@Quest7", Quest7)

        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "tbl_noflogin")
        con.Close()
        Return ds
    End Function

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        empcode.Text = Session("empcode")
        empname.Text = Session("empname")
        php.Focus()
        Label5.Text = DateTime.Now.ToString("dd-MMM-yyyy")

        If Session("empcode") = "" Then
            Response.Redirect("http://mmsbsql1/emgmt/announcement/logincovid.aspx")
            'Response.Redirect("http://58.26.100.36:55562/ymgw/hrmis/login.aspx")

        End If
 
        If Session("empcode") = "019442" Or Session("empcode") = "018399" Or Session("empcode") = "014804" Or Session("empcode") = "017243" Or Session("empcode") = "018443" Or Session("empcode") = "016631" Or Session("empcode") = "017947" Or Session("empcode") = "000007" Or Session("empcode") = "014623" Or Session("empcode") = "008836" Or Session("empcode") = "013784" Or Session("empcode") = "014191" Then
            LinkButton2.Visible = True
            LinkButton3.Visible = True
        Else
            LinkButton2.Visible = False
            LinkButton3.Visible = False
        End If

        If IsPostBack = False Then

            Dim TmpDs As New DataSet
            TmpDs = InsertCovid19("HOP", empcode.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
            If TmpDs.Tables(0).Rows.Count >= 1 Then
                php.Text = TmpDs.Tables(0).Rows(0).Item(0)
                If TmpDs.Tables(0).Rows(0).Item(0).ToString.Length <= 4 Then
                    icno.Text = TmpDs.Tables(0).Rows(0).Item(1).ToString
                Else
                    icno.Text = TmpDs.Tables(0).Rows(0).Item(2).ToString
                End If
            End If
            TmpDs = New DataSet
            TmpDs = InsertCovid19("ByEmpCode", empcode.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
            GridView1.DataSource = TmpDs.Tables(0)
            GridView1.DataBind()


        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            If CheckBox1.Checked = True Then

            Else
                CheckBox1.Focus()
                Label6.ForeColor = Drawing.Color.Red
                Label8.ForeColor = Drawing.Color.Red
                Label6.Text = "Please agree the declaration and press submit!"
                Label8.Text = "Please agree the declaration and press submit!"
                Exit Sub
            End If

            Dim Frst
            Dim Scnd
            Dim Thrd
            Dim Frth
            Dim Fth
            Dim Sxth
            Dim FrthB
            Dim Svnth

            Frst = "No"
            Scnd = "No"
            Thrd = "No"
            Fth = "No"
            Sxth = "No"

            If RadioButton7.Checked = True Then
                Frth = "Yes"
            ElseIf RadioButton8.Checked = True Then
                Frth = "No"
            Else
                Label6.ForeColor = Drawing.Color.Red
                Label8.ForeColor = Drawing.Color.Red
                Label6.Text = "Please answer all the questions!"
                Label8.Text = "Please answer all the questions!"
                Exit Sub
            End If

            If RadioButton11.Checked = True Then
                Svnth = "Yes"
            ElseIf RadioButton12.Checked = True Then
                Svnth = "No"
            Else
                Label6.ForeColor = Drawing.Color.Red
                Label8.ForeColor = Drawing.Color.Red
                Label6.Text = "Please answer all the questions!"
                Label8.Text = "Please answer all the questions!"
                Exit Sub
            End If

            If RadioButton13.Checked = True Then
                FrthB = "Yes"
            ElseIf RadioButton14.Checked = True Then
                FrthB = "No"
            Else
                Label6.ForeColor = Drawing.Color.Red
                Label8.ForeColor = Drawing.Color.Red
                Label6.Text = "Please answer all the questions!"
                Label8.Text = "Please answer all the questions!"
                Exit Sub
            End If



            If Svnth = "Yes" Then
                If TextBox3.Text = "" Then
                    Label3.Text = "Please key in valid data..."
                    Exit Sub
                Else
                    Label3.Text = ""

                End If

                If TextBox4.Text = "" Then
                    Label4.Text = "Please key in valid data..."
                    Exit Sub
                Else
                    Label4.Text = ""

                End If
            Else
                TextBox3.Text = "-"
                TextBox4.Text = "-"
                Label3.Text = ""
                Label4.Text = ""

            End If


            
            
            
             





            InsertCovid19("Insert", empcode.Text, empname.Text, php.Text, icno.Text, Frst, Scnd, Thrd, Frth, Fth, Sxth, UCase("-"), UCase("-"), UCase(TextBox3.Text), UCase(TextBox4.Text), FrthB, Svnth)
            Label6.ForeColor = Drawing.Color.Green
            Label6.Text = "Successfully updated! Auto logout after 3 seconds"

            Label8.ForeColor = Drawing.Color.Green
            Label8.Text = "Successfully updated! Auto logout after 3 seconds"

         
            Label3.Text = ""
            Label4.Text = ""

            TextBox3.Text = ""
            TextBox4.Text = ""

            Dim TmpDs As New DataSet
            TmpDs = New DataSet
            TmpDs = InsertCovid19("ByEmpCode", empcode.Text, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
            GridView1.DataSource = TmpDs.Tables(0)
            GridView1.DataBind()
            Tmr.Enabled = True
        Catch ex As Exception
            Label6.Text = ex.ToString
        End Try
    End Sub

  

    Protected Sub RadioButton12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton12.CheckedChanged
        Label3.Text = ""
        Label4.Text = ""
        TextBox3.Visible = False
        TextBox4.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        RadioButton12.Focus()
    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session("empcode") = ""
        Response.Redirect("http://mmsbsql1/emgmt/announcement/logincovid.aspx")
        'Response.Redirect("http://58.26.100.36:55562/ymgw/hrmis/login.aspx")
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
            Label6.ForeColor = Drawing.Color.Red
            Label8.ForeColor = Drawing.Color.Red
            Label6.Text = "Please agree the declaration and press submit!"
            Label8.Text = "Please agree the declaration and press submit!"
        End If
    End Sub



    Protected Sub RadioButton11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton11.CheckedChanged
        TextBox3.Visible = True
        TextBox4.Visible = True
        Label11.Visible = True
        Label12.Visible = True
        TextBox3.Focus()

    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Response.Redirect("CovidAbnormalReport.aspx")
    End Sub


    Protected Sub Tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr.Tick
        Session("empcode") = ""
        Response.Redirect("http://mmsbsql1/emgmt/announcement/logincovid.aspx")
        'Response.Redirect("http://58.26.100.36:55562/ymgw/hrmis/login.aspx")
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Response.Redirect("CovidDailyAbnormalReport.aspx")
    End Sub
End Class