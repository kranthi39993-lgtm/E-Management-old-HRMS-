Imports System.Data.SqlClient
Partial Public Class EvaluationWorkingEnv
    Inherits System.Web.UI.Page
    Dim TmpDs As New DataSet

    'Dim constr As String = "Data Source=Techfics2\Techfics;Initial Catalog=hrmis;uid=sa;password=TechficsPro"
    Dim constr As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"

    Function CallSP(ByVal Options As String, ByVal Uid As Integer, ByVal Name As String, ByVal NewICNo As String, ByVal OnDate As Date, ByVal QuesNo1 As String, ByVal QuesNo1Remarks As String, ByVal QuesNo2a As String, ByVal QuesNo2b As String, ByVal QuesNo2c As String, ByVal QuesNo2d As String, ByVal QuesNo2e As String, ByVal QuesNo2Remarks As String, ByVal QuesNo3 As String, ByVal QuesNo3Remarks As String, ByVal QuesNo4 As String, ByVal QuesNo4Remarks As String, ByVal QuesNo5Remarks As String, ByVal QuesNo6 As String, ByVal QuesNo6Remarks As String, ByVal QuesNo7 As String, ByVal QuesNo8Remarks As String, ByVal CreatedOn As Date, ByVal TimeTaken As Date, ByVal TimeRemarks As String) As DataSet
        '   MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("FormB_SP", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@Option", Options)
        Command.Parameters.AddWithValue("@Uid", Uid)
        Command.Parameters.AddWithValue("@Name", Name)
        Command.Parameters.AddWithValue("@ICNo", NewICNo)
        Command.Parameters.AddWithValue("@Date", OnDate)
        Command.Parameters.AddWithValue("@QNo1", QuesNo1)
        Command.Parameters.AddWithValue("@QNo1Remarks", QuesNo1Remarks)
        Command.Parameters.AddWithValue("@QNo2a", QuesNo2a)
        Command.Parameters.AddWithValue("@QNo2b", QuesNo2b)
        Command.Parameters.AddWithValue("@QNo2c", QuesNo2c)
        Command.Parameters.AddWithValue("@QNo2d", QuesNo2d)
        Command.Parameters.AddWithValue("@QNo2e", QuesNo2e)
        Command.Parameters.AddWithValue("@QNo2Remarks", QuesNo2Remarks)
        Command.Parameters.AddWithValue("@QNo3", QuesNo3)
        Command.Parameters.AddWithValue("@QNo3Remarks", QuesNo3Remarks)
        Command.Parameters.AddWithValue("@QNo4", QuesNo4)
        Command.Parameters.AddWithValue("@QNo4Remarks", QuesNo4Remarks)
        Command.Parameters.AddWithValue("@QNo5Remarks", QuesNo5Remarks)
        Command.Parameters.AddWithValue("@QNo6", QuesNo6)
        Command.Parameters.AddWithValue("@QNo6Remarks", QuesNo6Remarks)
        Command.Parameters.AddWithValue("@QNo7", QuesNo7)
        Command.Parameters.AddWithValue("@QNo8Remarks", QuesNo8Remarks)
        Command.Parameters.AddWithValue("@CreatedOn", CreatedOn)
        Command.Parameters.AddWithValue("@TimeTaken", TimeTaken)
        Command.Parameters.AddWithValue("@TimeRemarks", TimeRemarks)


        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "tbl_Formb")
        con.Close()
        Return ds
    End Function

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'empcode.Text = 
        'empname.Text = Session("empname")

        'Label5.Text = DateTime.Now.ToString("dd-MMM-yyyy")

        'If Session("empcode") = "" Then
        'Response.Redirect("http://maruwa.com.my/")
        'End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim Quest1 As String = ""
        Dim Quest3 As String = ""
        Dim Quest4 As String = ""
        Dim Quest6 As String = ""
        Dim Quest7 As String = ""
        Dim Ques2a As String = ""
        Dim Ques2b As String = ""
        Dim Ques2c As String = ""
        Dim Ques2d As String = ""
        Dim Ques2e As String = ""

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


        If ChBx6a.Checked = True Then
            Quest6 = "1,"
        End If

        If ChBx6b.Checked = True Then
            Quest6 = Quest6 + "2,"
        End If

        If ChBx6c.Checked = True Then
            Quest6 = Quest6 + "3,"
        End If

        If ChBx6d.Checked = True Then
            Quest6 = Quest6 + "4,"
        End If

        Quest6 = Quest6.TrimEnd(",")

        If ChBx7a.Checked = True Then
            Quest7 = "1,"
        End If

        If ChBx7b.Checked = True Then
            Quest7 = Quest7 + "2,"
        End If

        If ChBx7c.Checked = True Then
            Quest7 = Quest7 + "3,"
        End If

        If ChBx7d.Checked = True Then
            Quest7 = Quest7 + "4,"
        End If

        If ChBx7e.Checked = True Then
            Quest7 = Quest7 + "4,"
        End If

        Quest7 = Quest7.TrimEnd(",")

        If RBtn2a.Checked = True Then
            Ques2a = "Yes"
        Else
            Ques2a = "No"
        End If

        If RBtn2b.Checked = True Then
            Ques2b = "Yes"
        ElseIf RBtn2b1.Checked = True Then
            Ques2b = "No"
        Else
            MessageBox("Please answere for Question 2b..!")
            Exit Sub

        End If

        If Rbtn2c.Checked = True Then
            Ques2c = "Yes"
        ElseIf Rbtn2c1.Checked = True Then
            Ques2c = "No"
        Else
            MessageBox("Please answere for Question 2c..!")
            Exit Sub
        End If

        If Rbtn2d.Checked = True Then
            Ques2d = "Yes"
        ElseIf Rbtn2d1.Checked = True Then
            Ques2d = "No"
        Else
            MessageBox("Please answere for Question 2d..!")
            Exit Sub
        End If

        If Rbtn2e.Checked = True Then
            Ques2e = "Yes"
        ElseIf Rbtn2e.Checked = True Then
            Ques2e = "No"
        Else
            MessageBox("Please answere for Question 2e..!")
            Exit Sub
        End If

        If Ques2a = "No" Or Ques2b = "No" Or Ques2c = "No" Or Ques2d = "No" Or Ques2e = "No" Then
            TxtTwo.Text = ""
            MessageBox("Please State the reason")
        End If


        If Quest1.Trim.Equals("") Then
            MessageBox("Please answer for question1!")
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

        If Quest6.Trim.Equals("") Then
            MessageBox("Please answer for question6!")
            Exit Sub
        End If

        If Quest7.Trim.Equals("") Then
            MessageBox("Please answer for question7!")
            Exit Sub
        End If


        TmpDs = New DataSet

        TmpDs = CallSP("Insert", 0, TxtName.Text, TxtIcNo.Text, DateTime.Now, Quest1, TxtOne.Text, Ques2a, Ques2b, Ques2c, Ques2d, Ques2e, TxtTwo.Text, Quest3, TxtThree.Text, Quest4, TxtFour.Text, TxtFive.Text, Quest6, TxtSix.Text, Quest7, TxtEight.Text, DateTime.Now, DateTime.Now, "")
        Label6.ForeColor = Drawing.Color.Green
        Label6.Text = "Successfully Inserted!"

        Label8.ForeColor = Drawing.Color.Green
        Label8.Text = "Successfully Inserted!"



    End Sub


End Class