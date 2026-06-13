Imports System.Data.SqlClient
Partial Public Class CompanyEvaluation
    Inherits System.Web.UI.Page
    Dim TmpDs As New DataSet

    ' Dim constr As String = "Data Source=Techfics2\Techfics;Initial Catalog=hrmis;uid=sa;password=TechficsPro"
    Dim constr As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"

    Function CallSP(ByVal Options As String, ByVal Uid As Integer, ByVal Name As String, ByVal NewIcNo As String, ByVal OnDate As Date, ByVal QNo1 As String, ByVal QNo2 As String, ByVal QNo3 As String, ByVal QNo4 As String, ByVal QNo5 As String, ByVal Createdon As Date, ByVal Timetaken As Date, ByVal TimeRemarks As String) As DataSet
        '   MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("FormC_SP", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@Option", Options)
        Command.Parameters.AddWithValue("@Uid", Uid)
        Command.Parameters.AddWithValue("@Name", Name)
        Command.Parameters.AddWithValue("@NewIcNo", NewIcNo)
        Command.Parameters.AddWithValue("@Date", OnDate)
        Command.Parameters.AddWithValue("@QNo1", QNo1)
        Command.Parameters.AddWithValue("@QNo2", QNo2)
        Command.Parameters.AddWithValue("@QNo3", QNo3)
        Command.Parameters.AddWithValue("@QNo4", QNo4)
        Command.Parameters.AddWithValue("@QNo5", QNo5)
        Command.Parameters.AddWithValue("@CreatedOn", Createdon)
        Command.Parameters.AddWithValue("@TimeTaken", TimeTaken)
        Command.Parameters.AddWithValue("@TimeRemarks", TimeRemarks)


        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "tbl_Formc")
        con.Close()
        Return ds

    End Function

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Quest1 As String = ""
        Dim Quest2 As String = ""
        Dim Quest3 As String = ""
        Dim Quest4 As String = ""
        Dim Quest5 As String = ""

        If ChBx1a.Checked = True Then
            Quest1 = "1,"
        End If

        If ChBx1b.Checked = True Then
            Quest1 = Quest1 + "2,"
        End If

        If ChBx1c.Checked = True Then
            Quest1 = Quest1 + "3,"
        End If

        If ChBx1d.Checked = True Then
            Quest1 = Quest1 + "4,"
        End If

        Quest1 = Quest1.TrimEnd(",")

        If ChBx2a.Checked = True Then
            Quest2 = "1,"
        End If

        If ChBx2b.Checked = True Then
            Quest2 = Quest2 + "2,"
        End If

        If ChBx2c.Checked = True Then
            Quest2 = Quest2 + "3,"
        End If

        If ChBx2d.Checked = True Then
            Quest2 = Quest2 + "4,"
        End If

        Quest2 = Quest2.TrimEnd(",")

        If ChBx3a.Checked = True Then
            Quest3 = "1,"
        End If

        If ChBx3b.Checked = True Then
            Quest3 = Quest3 + "2,"
        End If

        If ChBx3c.Checked = True Then
            Quest3 = Quest3 + "3,"
        End If

        If ChBx3d.Checked = True Then
            Quest3 = Quest3 + "4,"
        End If

        Quest3 = Quest3.TrimEnd(",")

        If ChBx4a.Checked = True Then
            Quest4 = "1,"
        End If

        If ChBx4b.Checked = True Then
            Quest4 = Quest4 + "2,"
        End If

        If ChBx4c.Checked = True Then
            Quest4 = Quest4 + "3,"
        End If

        If ChBx4d.Checked = True Then
            Quest4 = Quest4 + "4,"
        End If

        Quest4 = Quest4.TrimEnd(",")

        If ChBx5a.Checked = True Then
            Quest5 = "1,"
        End If

        If ChBx5b.Checked = True Then
            Quest5 = Quest5 + "2,"
        End If

        If ChBx5c.Checked = True Then
            Quest5 = Quest5 + "3,"
        End If

        If ChBx5d.Checked = True Then
            Quest5 = Quest5 + "4,"
        End If

        Quest5 = Quest5.TrimEnd(",")

        If Quest1.Trim.Equals("") Then
            MessageBox("Please answer for question1!")
            Exit Sub
        End If

        If Quest2.Trim.Equals("") Then
            MessageBox("Please answer for question2!")
            Exit Sub
        End If

        If Quest3.Trim.Equals("") Then
            MessageBox("Please answer for question3!")
            Exit Sub
        End If

        If Quest4.Trim.Equals("") Then
            MessageBox("Please answer for question4!")
            Exit Sub
        End If

        If Quest5.Trim.Equals("") Then
            MessageBox("Please answer for question5!")
            Exit Sub
        End If

        TmpDs = New DataSet

        TmpDs = CallSP("Insert", 0, TxtName.Text, TxtIcNo.Text, DateTime.Now, Quest1, Quest2, Quest3, Quest4, Quest5, DateTime.Now, DateTime.Now, "")
        Label6.ForeColor = Drawing.Color.Green
        Label6.Text = "Successfully Inserted!"

        Label8.ForeColor = Drawing.Color.Green
        Label8.Text = "Successfully Inserted!"
    End Sub
End Class