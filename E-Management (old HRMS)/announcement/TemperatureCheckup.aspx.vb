Imports System.Data.SqlClient
Partial Public Class TemperatureCheckup
    Inherits System.Web.UI.Page

    '    Dim constrtmp As String = "Data Source=Techfics;Initial Catalog=hrmis;uid=sa;password=TechficsPro"
    Dim constr As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"

    Function InsertCovid19(ByVal Options As String, ByVal empcode As String, ByVal EmpName As String, ByVal Temperature As String, ByVal Remarks As String, ByVal CreatedBy As String, ByVal AppDate As String) As DataSet
        '   MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Temperature", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@Options", Options)
        Command.Parameters.AddWithValue("@EmpCode", empcode)
        Command.Parameters.AddWithValue("@empname", EmpName)
        Command.Parameters.AddWithValue("@Temperature", Temperature)
        Command.Parameters.AddWithValue("@Remarks", Remarks)
        Command.Parameters.AddWithValue("@CreatedBy", CreatedBy)
        Command.Parameters.AddWithValue("@appdate", Label5.Text)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "tbl_noflogin")
        con.Close()
        Return ds
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        empcode.Text = Session("empcode")
        empname.Text = Session("empname")
        empcode1.Focus()
        Label5.Text = DateTime.Now.ToString("dd-MMM-yyyy")

        If IsPostBack = False Then
            Dim TmpDs As New DataSet
            TmpDs = New DataSet
            TmpDs = InsertCovid19("All", empcode.Text, 0, 0, 0, 0, 0)
            GridView1.DataSource = TmpDs.Tables(0)
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        TxtTemperature.Focus()
    End Sub

 

    Protected Sub empcode1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode1.TextChanged

        Dim txtempcode = empcode1.Text
        Dim _eid = empcode1.Text

        Dim DsData As New DataSet
        DsData = emanagement.SqlHelper.ExecuteDataset(constr, "hrmis_empdetailsall", txtempcode)

        Dim dr As DataRow
        If DsData.Tables(0).Rows.Count > 0 Then
            dr = DsData.Tables(0).Rows(0)
            empname1.Text = dr("empname").ToString
        End If


    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            If empcode1.Text.Trim.Equals("") Then
                empcode1.Text = ""
                empcode1.Focus()
                Label1.Text = "Enter valid data!"
                Exit Sub
            End If

            If empname1.Text.Trim.Equals("") Then
                empcode1.Text = ""
                empcode1.Focus()
                Label1.Text = "Enter valid data!"
                Exit Sub
            End If

            If Val(TxtTemperature.Text) <= 33 Or Val(TxtTemperature.Text) >= 42 Then
                Label1.Text = "Invalid temperature value!"
                TxtTemperature.Text = ""
                TxtTemperature.Focus()
            End If
        Catch ex As Exception

        End Try

        If RadioButton2.Checked = True Then
            If TxtTemperature.Text.Trim.Equals("") Then
                Label1.Text = "Please enter temperature value"
                Exit Sub
            End If
        Else
            If TxtTemperature.Text.Trim.Equals("") Then
                TxtTemperature.Text = 36.5
            End If

        End If
        Dim Remarks As String

        If RadioButton1.Checked = True Then
            Remarks = "Normal"
        Else
            Remarks = "Abnormal"
        End If
        InsertCovid19("Insert", empcode1.Text, empname1.Text, TxtTemperature.Text, Remarks, empcode.Text, Label5.Text)
        Label1.ForeColor = Drawing.Color.Green
        Label1.Text = "Successfully updated"

        empcode1.Text = ""
        empname1.Text = ""
        RadioButton1.Checked = True
        TxtTemperature.Text = ""
        empcode1.Focus()

        Dim TmpDs As New DataSet
        TmpDs = New DataSet
        TmpDs = InsertCovid19("All", empcode.Text, 0, 0, 0, 0, 0)
        GridView1.DataSource = TmpDs.Tables(0)
        GridView1.DataBind()

    End Sub
End Class