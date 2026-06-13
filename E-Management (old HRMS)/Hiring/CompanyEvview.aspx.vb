Imports System.Data.SqlClient
Partial Public Class CompanyEvview
    Inherits System.Web.UI.Page
    Dim UID As Integer
    Dim TmpDs As New DataSet

    'Dim constr As String = "Data Source=Techfics2\Techfics;Initial Catalog=hrmis;uid=sa;password=TechficsPro"
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            Session("UID_CE") = 0
            UID = Request.QueryString("UID")
            Session("UID_CE") = UID

            TmpDs = New DataSet
            TmpDs = CallSP("ById", UID, "", "", DateTime.Now, "", "", "", "", "", DateTime.Now, DateTime.Now, "")


            Dim Quest1 As String
            Dim Quest2 As String
            Dim Quest3 As String
            Dim Quest4 As String
            Dim Quest5 As String


            If TmpDs.Tables(0).Rows.Count >= 1 Then
                TxtName.Text = TmpDs.Tables(0).Rows(0).Item("Name")
                TxtIcNo.Text = TmpDs.Tables(0).Rows(0).Item("NewIcNo")
                TxtDate.Text = TmpDs.Tables(0).Rows(0).Item("Date").ToString()
                Quest1 = TmpDs.Tables(0).Rows(0).Item("QNo1")
                Quest2 = TmpDs.Tables(0).Rows(0).Item("QNo2")
                Quest3 = TmpDs.Tables(0).Rows(0).Item("QNo3")
                Quest4 = TmpDs.Tables(0).Rows(0).Item("QNo4")
                Quest5 = TmpDs.Tables(0).Rows(0).Item("QNo5")

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

                Dim Str2 As String()
                Str2 = Quest2.Split(",")

                For Tmpi As Integer = 0 To Str2.Length - 1
                    If Str2(Tmpi) = 1 Then
                        ChBx2a.Checked = True
                    End If

                    If Str2(Tmpi) = 2 Then
                        ChBx2b.Checked = True
                    End If

                    If Str2(Tmpi) = 3 Then
                        ChBx2c.Checked = True
                    End If

                    If Str2(Tmpi) = 4 Then
                        ChBx2d.Checked = True
                    End If
                Next

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

                Dim Str5 As String()
                Str5 = Quest5.Split(",")

                For Tmpi As Integer = 0 To Str5.Length - 1
                    If Str5(Tmpi) = 1 Then
                        ChBx5a.Checked = True
                    End If

                    If Str5(Tmpi) = 2 Then
                        ChBx5b.Checked = True
                    End If

                    If Str5(Tmpi) = 3 Then
                        ChBx5c.Checked = True
                    End If

                    If Str5(Tmpi) = 4 Then
                        ChBx5d.Checked = True
                    End If
                Next

            End If

        End If
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Response.Redirect("DGViewCompanyEv.aspx")
    End Sub

End Class