Imports System.Data.SqlClient

Partial Public Class Covid19DeclarationView
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
        Dim UID As Integer
        UID = Request.QueryString("UID")

        Dim TmpDs As New DataSet
        TmpDs = New DataSet
        TmpDs = InsertCovid19("UID", UID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)

        If TmpDs.Tables(0).Rows.Count >= 1 Then
            empcode.Text = TmpDs.Tables(0).Rows(0).Item("Empcode")
            empname.Text = TmpDs.Tables(0).Rows(0).Item("EmpName")
            icno.Text = TmpDs.Tables(0).Rows(0).Item("IcNumber")
            php.Text = TmpDs.Tables(0).Rows(0).Item("HOP")

            If TmpDs.Tables(0).Rows(0).Item("Quest1") = "Yes" Then
                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If

            If TmpDs.Tables(0).Rows(0).Item("Quest2") = "Yes" Then
                RadioButton3.Checked = True
            Else
                RadioButton4.Checked = True
            End If

            If TmpDs.Tables(0).Rows(0).Item("Quest3") = "Yes" Then
                RadioButton5.Checked = True
            Else
                RadioButton6.Checked = True
            End If

            If TmpDs.Tables(0).Rows(0).Item("Quest4") = "Yes" Then
                RadioButton7.Checked = True
            Else
                RadioButton8.Checked = True
            End If

            If TmpDs.Tables(0).Rows(0).Item("Quest4_b") = "Yes" Then
                RadioButton13.Checked = True
            Else
                RadioButton14.Checked = True
            End If

            If TmpDs.Tables(0).Rows(0).Item("Quest5") = "Yes" Then
                RadioButton15.Checked = True
            Else
                RadioButton16.Checked = True
            End If

            If TmpDs.Tables(0).Rows(0).Item("Quest6") = "Yes" Then
                RadioButton9.Checked = True
                TextBox1.Visible = True
                TextBox2.Visible = True
            Else
                RadioButton10.Checked = True
            End If

            If TmpDs.Tables(0).Rows(0).Item("Quest7") = "Yes" Then
                RadioButton11.Checked = True
                TextBox3.Visible = True
                TextBox4.Visible = True
            Else
                RadioButton12.Checked = True
            End If

            TextBox1.Text = TmpDs.Tables(0).Rows(0).Item("Quest6Detail1")
            TextBox2.Text = TmpDs.Tables(0).Rows(0).Item("Quest6Detail2")
            TextBox3.Text = TmpDs.Tables(0).Rows(0).Item("Quest7Detail1")
            TextBox4.Text = TmpDs.Tables(0).Rows(0).Item("Quest7Detail2")

            
        End If


    End Sub


End Class