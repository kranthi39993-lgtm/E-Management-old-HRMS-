Imports System.Data.SqlClient

Partial Public Class EvaluationView
    Inherits System.Web.UI.Page

    Dim UID As Integer
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

        If IsPostBack = False Then

            Session("UID_EV") = 0
            UID = Request.QueryString("UID")
            Session("UID_EV") = UID

            TmpDs = New DataSet
            TmpDs = CallSP("ById", UID, "", "", DateTime.Now, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", DateTime.Now, DateTime.Now, "")

            Dim Quest1 As String
            Dim Quest3 As String
            Dim Quest4 As String
            Dim Quest6 As String
            Dim Quest7 As String
            Dim Ques2a As String
            Dim Ques2b As String
            Dim Ques2c As String
            Dim Ques2d As String
            Dim Ques2e As String



            If TmpDs.Tables(0).Rows.Count >= 1 Then
                TxtName.Text = TmpDs.Tables(0).Rows(0).Item("Name")
                TxtIcNo.Text = TmpDs.Tables(0).Rows(0).Item("NewICNo")
                TxtDate.Text = TmpDs.Tables(0).Rows(0).Item("Date").ToString()
                TxtOne.Text = TmpDs.Tables(0).Rows(0).Item("QuestionNo1Remarks")
                Quest1 = TmpDs.Tables(0).Rows(0).Item("QuestionNo1")
                Ques2a = TmpDs.Tables(0).Rows(0).Item("QuestionNo2a")
                Ques2b = TmpDs.Tables(0).Rows(0).Item("QuestionNo2b")
                Ques2c = TmpDs.Tables(0).Rows(0).Item("QuestionNo2c")
                Ques2d = TmpDs.Tables(0).Rows(0).Item("QuestionNo2d")
                Ques2e = TmpDs.Tables(0).Rows(0).Item("QuestionNo2e")
                TxtTwo.Text = TmpDs.Tables(0).Rows(0).Item("QuestionNo2Remarks")
                Quest3 = TmpDs.Tables(0).Rows(0).Item("QuestionNo3")
                TxtThree.Text = TmpDs.Tables(0).Rows(0).Item("QuestionNo3Remarks")
                Quest4 = TmpDs.Tables(0).Rows(0).Item("QuestionNo4")
                TxtFour.Text = TmpDs.Tables(0).Rows(0).Item("QuestionNo4Remarks")
                TxtFive.Text = TmpDs.Tables(0).Rows(0).Item("QuestionNo5Remarks")
                Quest6 = TmpDs.Tables(0).Rows(0).Item("QuestionNo6")
                TxtSix.Text = TmpDs.Tables(0).Rows(0).Item("QuestionNo6Remarks")
                Quest7 = TmpDs.Tables(0).Rows(0).Item("QuestionNo7")
                TxtEight.Text = TmpDs.Tables(0).Rows(0).Item("QuestionNo8Remarks")

                Dim Str1 As String()
                Str1 = Quest1.Split(",")

                For Tmpi As Integer = 0 To Str1.Length - 1
                    If Str1(Tmpi) = 1 Then
                        ChBx1a.Checked = True

                    End If

                    If Str1(Tmpi) = 2 Then
                        ChBx1b.Checked = True

                    End If

                    If Str1(Tmpi) = 3 Then
                        ChBx1c.Checked = True

                    End If

                    If Str1(Tmpi) = 4 Then
                        ChBx1d.Checked = True

                    End If
                Next

                If Ques2a = "Yes" Then
                    RBtn2a.Checked = True
                Else
                    RBtn2a1.Checked = True
                End If

                If Ques2b = "Yes" Then
                    RBtn2b.Checked = True
                Else
                    RBtn2b1.Checked = True
                End If

                If Ques2c = "Yes" Then
                    Rbtn2c.Checked = True
                Else
                    Rbtn2c1.Checked = True
                End If

                If Ques2d = "Yes" Then
                    Rbtn2d.Checked = True
                Else
                    Rbtn2d1.Checked = True
                End If

                If Ques2e = "Yes" Then
                    Rbtn2e.Checked = True
                Else
                    Rbtn2e1.Checked = True
                End If

                Dim Str3 As String()
                Str3 = Quest3.Split(",")

                For Tmpi As Integer = 0 To Str3.Length - 1
                    If Str3(Tmpi) = 1 Then
                        ChBx3a.Checked = True

                    End If

                    If Str3(Tmpi) = 2 Then
                        ChBx3b.Checked = True

                    End If

                    If Str3(Tmpi) = 3 Then
                        ChBx3c.Checked = True

                    End If

                    If Str3(Tmpi) = 4 Then
                        ChBx3d.Checked = True

                    End If
                Next

                Dim Str4 As String()
                Str4 = Quest4.Split(",")

                For Tmpi As Integer = 0 To Str4.Length - 1
                    If Str4(Tmpi) = 1 Then
                        ChBx4a.Checked = True

                    End If

                    If Str4(Tmpi) = 2 Then
                        ChBx4b.Checked = True

                    End If

                    If Str4(Tmpi) = 3 Then
                        ChBx4c.Checked = True

                    End If

                    If Str4(Tmpi) = 4 Then
                        ChBx4d.Checked = True

                    End If
                Next

                Dim Str6 As String()
                Str6 = Quest6.Split(",")

                For Tmpi As Integer = 0 To Str6.Length - 1
                    If Str6(Tmpi) = 1 Then
                        ChBx6a.Checked = True

                    End If

                    If Str6(Tmpi) = 2 Then
                        ChBx6b.Checked = True

                    End If

                    If Str6(Tmpi) = 3 Then
                        ChBx6c.Checked = True

                    End If

                    If Str6(Tmpi) = 4 Then
                        ChBx6d.Checked = True

                    End If
                Next

                Dim Str7 As String()
                Str7 = Quest7.Split(",")

                For Tmpi As Integer = 0 To Str7.Length - 1

                    If Str7(Tmpi) = 1 Then
                        ChBx7a.Checked = True

                    End If

                    If Str7(Tmpi) = 2 Then
                        ChBx7b.Checked = True

                    End If

                    If Str7(Tmpi) = 3 Then
                        ChBx7c.Checked = True

                    End If

                    If Str7(Tmpi) = 4 Then
                        ChBx7d.Checked = True

                    End If

                    If Str7(Tmpi) = 5 Then
                        ChBx7e.Checked = True

                    End If
                Next
            End If

        End If

    End Sub


    Protected Sub LinkButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Response.Redirect("DGViewEvaluation.aspx")
    End Sub
End Class