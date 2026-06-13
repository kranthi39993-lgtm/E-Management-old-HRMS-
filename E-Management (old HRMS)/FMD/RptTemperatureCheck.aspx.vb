Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports System.Web.Security
Partial Public Class RptTemperatureCheck
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con_FMD()
        MyGlobal.Con_Str()

        'Session("FsDate") = "08/01/2011"
        'Session("FTdate") = "08/31/2011"
        'Session("McNoR") = "Q1"
        'Session("FDept") = "6000"
        'MsgBox(Session("FsDate") & Session("FtDate"))

        ' Session("empcode") = "014543"

        lblmon.Text = Session("Fsmon")
        lblmcno.Text = Session("McNoR")
        lbdept.Text = Session("FDept")

        If Session("Fsmon") <> "" And Session("McNoR") <> "" And Session("FDept") <> "" Then

            LoadGrid()

        End If

    End Sub
    Private Sub LoadGrid()

        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        '''' Delete from Temp table before entering new record

        Dim con As New SqlConnection(conFMD)
        con.Open()
        Cmd = New SqlCommand("delete from Fir_RptTempcheckTable where mcno = '" & Session("McNoR") & "' and keyinby = '" & Session("empcode") & "'", con)
        Cmd.ExecuteNonQuery()


        Dim zcount

        MyGlobal.Open_Con_FMD()
        MyGlobal.Con_Str()
        Dim dszone As DataSet
        Dim drzone As DataRow

        Dim zone
        Dim spec
        Dim ztemp, zmax, zmin

        dszone = GetZoneInfo(Session("McNoR"))
        '''' get zone info and store to temp table
        If dszone.Tables(0).Rows.Count > 0 Then
            zcount = dszone.Tables(0).Rows.Count
            For i As Integer = 0 To zcount - 1
                drzone = dszone.Tables(0).Rows(i)
                zone = drzone("zoneid").ToString
                ztemp = drzone("ftemp").ToString
                spec = drzone("spec").ToString
                zmax = drzone("fmax").ToString
                zmin = drzone("fmin").ToString

                Try
                    MyGlobal.Open_Con_FMD()
                    MyGlobal.Con_Str()



                    Dim dsT As DataSet
                    Dim drt As DataRow
                    dsT = GetTempInfoForZone(zone)
                    Dim acount
                    Dim act
                    Dim edate
                    Dim ampm

                    Dim a1 = "-"
                    Dim a2 = "-"
                    Dim a3 = "-"
                    Dim a4 = "-"
                    Dim a5 = "-"
                    Dim a6 = "-"
                    Dim a7 = "-"
                    Dim a8 = "-"
                    Dim a9 = "-"
                    Dim a10 = "-"
                    Dim a11 = "-"
                    Dim a12 = "-"
                    Dim a13 = "-"
                    Dim a14 = "-"
                    Dim a15 = "-"
                    Dim a16 = "-"
                    Dim a17 = "-"
                    Dim a18 = "-"
                    Dim a19 = "-"
                    Dim a20 = "-"
                    Dim a21 = "-"
                    Dim a22 = "-"
                    Dim a23 = "-"
                    Dim a24 = "-"
                    Dim a25 = "-"
                    Dim a26 = "-"
                    Dim a27 = "-"
                    Dim a28 = "-"
                    Dim a29 = "-"
                    Dim a30 = "-"
                    Dim a31 = "-"

                    Dim b1 = "-"
                    Dim b2 = "-"
                    Dim b3 = "-"
                    Dim b4 = "-"
                    Dim b5 = "-"
                    Dim b6 = "-"
                    Dim b7 = "-"
                    Dim b8 = "-"
                    Dim b9 = "-"
                    Dim b10 = "-"
                    Dim b11 = "-"
                    Dim b12 = "-"
                    Dim b13 = "-"
                    Dim b14 = "-"
                    Dim b15 = "-"
                    Dim b16 = "-"
                    Dim b17 = "-"
                    Dim b18 = "-"
                    Dim b19 = "-"
                    Dim b20 = "-"
                    Dim b21 = "-"
                    Dim b22 = "-"
                    Dim b23 = "-"
                    Dim b24 = "-"
                    Dim b25 = "-"
                    Dim b26 = "-"
                    Dim b27 = "-"
                    Dim b28 = "-"
                    Dim b29 = "-"
                    Dim b30 = "-"
                    Dim b31 = "-"

                    Dim stat

              
                    If dsT.Tables(0).Rows.Count > 0 Then
                        acount = dsT.Tables(0).Rows.Count
                        For z As Integer = 0 To acount - 1
                            drt = dsT.Tables(0).Rows(z)

                            If Not drt("actualval") Is System.DBNull.Value Then
                                act = drt("actualval").ToString.Trim
                            Else
                                act = ""
                            End If
                            If Not drt("ampm") Is System.DBNull.Value Then
                                ampm = drt("ampm").ToString.Trim
                            Else
                                ampm = ""
                            End If
                            If Not drt("status") Is System.DBNull.Value Then
                                stat = drt("status").ToString.Trim
                            Else
                                stat = ""
                            End If
                            If Not drt("entrydate") Is System.DBNull.Value Then
                                edate = Format(Convert.ToDateTime(drt("entrydate")), "dd")
                            End If

                            If edate = "01" Then
                                If ampm = "AM" Then
                                    a1 = act
                                ElseIf ampm = "PM" Then
                                    b1 = act
                                End If
                            ElseIf edate = "02" Then
                                If ampm = "AM" Then
                                    a2 = act
                                ElseIf ampm = "PM" Then
                                    b2 = act
                                End If

                            ElseIf edate = "03" Then
                                If ampm = "AM" Then
                                    a3 = act
                                ElseIf ampm = "PM" Then
                                    b3 = act
                                End If
                            ElseIf edate = "04" Then
                                If ampm = "AM" Then
                                    a4 = act
                                ElseIf ampm = "PM" Then
                                    b4 = act
                                End If
                            ElseIf edate = "05" Then
                                If ampm = "AM" Then
                                    a5 = act
                                ElseIf ampm = "PM" Then
                                    b5 = act
                                End If
                            ElseIf edate = "06" Then
                                If ampm = "AM" Then
                                    a6 = act
                                ElseIf ampm = "PM" Then
                                    b6 = act
                                End If
                            ElseIf edate = "07" Then
                                If ampm = "AM" Then
                                    a7 = act
                                ElseIf ampm = "PM" Then
                                    b7 = act
                                End If
                            ElseIf edate = "08" Then
                                If ampm = "AM" Then
                                    a8 = act
                                ElseIf ampm = "PM" Then
                                    b8 = act
                                End If
                            ElseIf edate = "09" Then
                                If ampm = "AM" Then
                                    a9 = act
                                ElseIf ampm = "PM" Then
                                    b9 = act
                                End If
                            ElseIf edate = "10" Then
                                If ampm = "AM" Then
                                    a10 = act
                                ElseIf ampm = "PM" Then
                                    b10 = act
                                End If


                            ElseIf edate = "11" Then
                                If ampm = "AM" Then
                                    a11 = act
                                ElseIf ampm = "PM" Then
                                    b11 = act
                                End If
                            ElseIf edate = "12" Then
                                If ampm = "AM" Then
                                    a12 = act
                                ElseIf ampm = "PM" Then
                                    b12 = act
                                End If

                            ElseIf edate = "13" Then
                                If ampm = "AM" Then
                                    a13 = act
                                ElseIf ampm = "PM" Then
                                    b13 = act
                                End If
                            ElseIf edate = "14" Then
                                If ampm = "AM" Then
                                    a14 = act
                                ElseIf ampm = "PM" Then
                                    b14 = act
                                End If
                            ElseIf edate = "15" Then
                                If ampm = "AM" Then
                                    a15 = act
                                ElseIf ampm = "PM" Then
                                    b15 = act
                                End If
                            ElseIf edate = "16" Then
                                If ampm = "AM" Then
                                    a16 = act
                                ElseIf ampm = "PM" Then
                                    b16 = act
                                End If
                            ElseIf edate = "17" Then
                                If ampm = "AM" Then
                                    a17 = act
                                ElseIf ampm = "PM" Then
                                    b17 = act
                                End If
                            ElseIf edate = "18" Then
                                If ampm = "AM" Then
                                    a18 = act
                                ElseIf ampm = "PM" Then
                                    b18 = act
                                End If
                            ElseIf edate = "19" Then
                                If ampm = "AM" Then
                                    a19 = act
                                ElseIf ampm = "PM" Then
                                    b19 = act
                                End If
                            ElseIf edate = "20" Then
                                If ampm = "AM" Then
                                    a20 = act
                                ElseIf ampm = "PM" Then
                                    b20 = act
                                End If

                            ElseIf edate = "21" Then
                                If ampm = "AM" Then
                                    a21 = act
                                ElseIf ampm = "PM" Then
                                    b21 = act
                                End If
                            ElseIf edate = "22" Then
                                If ampm = "AM" Then
                                    a22 = act
                                ElseIf ampm = "PM" Then
                                    b22 = act
                                End If

                            ElseIf edate = "23" Then
                                If ampm = "AM" Then
                                    a23 = act
                                ElseIf ampm = "PM" Then
                                    b23 = act
                                End If
                            ElseIf edate = "24" Then
                                If ampm = "AM" Then
                                    a24 = act
                                ElseIf ampm = "PM" Then
                                    b24 = act
                                End If
                            ElseIf edate = "25" Then
                                If ampm = "AM" Then
                                    a25 = act
                                ElseIf ampm = "PM" Then
                                    b25 = act
                                End If
                            ElseIf edate = "26" Then
                                If ampm = "AM" Then
                                    a26 = act
                                ElseIf ampm = "PM" Then
                                    b26 = act
                                End If
                            ElseIf edate = "27" Then
                                If ampm = "AM" Then
                                    a27 = act
                                ElseIf ampm = "PM" Then
                                    b27 = act
                                End If
                            ElseIf edate = "28" Then
                                If ampm = "AM" Then
                                    a28 = act
                                ElseIf ampm = "PM" Then
                                    b28 = act
                                End If
                            ElseIf edate = "29" Then
                                If ampm = "AM" Then
                                    a29 = act
                                ElseIf ampm = "PM" Then
                                    b29 = act
                                End If
                            ElseIf edate = "30" Then
                                If ampm = "AM" Then
                                    a30 = act
                                ElseIf ampm = "PM" Then
                                    b30 = act
                                End If
                            ElseIf edate = "31" Then
                                If ampm = "AM" Then
                                    a31 = act
                                ElseIf ampm = "PM" Then
                                    b31 = act
                                End If


                            End If

                            Call MyGlobal.dbSp_open_FMD("FIR_Rpttempcheck")

                            Cmd.Parameters.AddWithValue("@Zoneid", zone)
                            Cmd.Parameters.AddWithValue("@Spec", spec)
                            Cmd.Parameters.AddWithValue("@fmax", zmax)
                            Cmd.Parameters.AddWithValue("@fmin", zmin)
                            Cmd.Parameters.AddWithValue("@ftemp", ztemp)
                            Cmd.Parameters.AddWithValue("@d1am", a1)
                            Cmd.Parameters.AddWithValue("@d1pm", b1)
                            Cmd.Parameters.AddWithValue("@d2am", a2)
                            Cmd.Parameters.AddWithValue("@d2pm", b2)
                            Cmd.Parameters.AddWithValue("@d3am", a3)
                            Cmd.Parameters.AddWithValue("@d3pm", b3)
                            Cmd.Parameters.AddWithValue("@d4am", a4)
                            Cmd.Parameters.AddWithValue("@d4pm", b4)
                            Cmd.Parameters.AddWithValue("@d5am", a5)
                            Cmd.Parameters.AddWithValue("@d5pm", b5)
                            Cmd.Parameters.AddWithValue("@d6am", a6)
                            Cmd.Parameters.AddWithValue("@d6pm", b6)
                            Cmd.Parameters.AddWithValue("@d7am", a7)
                            Cmd.Parameters.AddWithValue("@d7pm", b7)
                            Cmd.Parameters.AddWithValue("@d8am", a8)
                            Cmd.Parameters.AddWithValue("@d8pm", b8)
                            Cmd.Parameters.AddWithValue("@d9am", a9)
                            Cmd.Parameters.AddWithValue("@d9pm", b9)
                            Cmd.Parameters.AddWithValue("@d10am", a10)
                            Cmd.Parameters.AddWithValue("@d10pm", b10)
                            Cmd.Parameters.AddWithValue("@d11am", a11)
                            Cmd.Parameters.AddWithValue("@d11pm", b11)
                            Cmd.Parameters.AddWithValue("@d12am", a12)
                            Cmd.Parameters.AddWithValue("@d12pm", b12)
                            Cmd.Parameters.AddWithValue("@d13am", a13)
                            Cmd.Parameters.AddWithValue("@d13pm", b13)
                            Cmd.Parameters.AddWithValue("@d14am", a14)
                            Cmd.Parameters.AddWithValue("@d14pm", a14)
                            Cmd.Parameters.AddWithValue("@d15am", a15)
                            Cmd.Parameters.AddWithValue("@d15pm", b15)
                            Cmd.Parameters.AddWithValue("@d16am", a16)
                            Cmd.Parameters.AddWithValue("@d16pm", b16)
                            Cmd.Parameters.AddWithValue("@d17am", a17)
                            Cmd.Parameters.AddWithValue("@d17pm", b17)
                            Cmd.Parameters.AddWithValue("@d18am", a18)
                            Cmd.Parameters.AddWithValue("@d18pm", b18)
                            Cmd.Parameters.AddWithValue("@d19am", a19)
                            Cmd.Parameters.AddWithValue("@d19pm", b19)
                            Cmd.Parameters.AddWithValue("@d20am", a20)
                            Cmd.Parameters.AddWithValue("@d20pm", b20)
                            Cmd.Parameters.AddWithValue("@d21am", a21)
                            Cmd.Parameters.AddWithValue("@d21pm", b21)
                            Cmd.Parameters.AddWithValue("@d22am", a22)
                            Cmd.Parameters.AddWithValue("@d22pm", b22)
                            Cmd.Parameters.AddWithValue("@d23am", a23)
                            Cmd.Parameters.AddWithValue("@d23pm", b23)
                            Cmd.Parameters.AddWithValue("@d24am", a24)
                            Cmd.Parameters.AddWithValue("@d24pm", b24)
                            Cmd.Parameters.AddWithValue("@d25am", a25)
                            Cmd.Parameters.AddWithValue("@d25pm", b25)
                            Cmd.Parameters.AddWithValue("@d26am", a26)
                            Cmd.Parameters.AddWithValue("@d26pm", b26)
                            Cmd.Parameters.AddWithValue("@d27am", a27)
                            Cmd.Parameters.AddWithValue("@d27pm", b27)
                            Cmd.Parameters.AddWithValue("@d28am", a28)
                            Cmd.Parameters.AddWithValue("@d28pm", b28)
                            Cmd.Parameters.AddWithValue("@d29am", a29)
                            Cmd.Parameters.AddWithValue("@d29pm", b29)
                            Cmd.Parameters.AddWithValue("@d30am", a30)
                            Cmd.Parameters.AddWithValue("@d30pm", b30)
                            Cmd.Parameters.AddWithValue("@d31am", a31)
                            Cmd.Parameters.AddWithValue("@d31pm", b31)
                            Cmd.Parameters.AddWithValue("@mcno", Session("McNoR"))
                            Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))

                            Cmd.ExecuteNonQuery()
                        Next
                    End If





                Catch ex As Exception
                    lblmsg.Text = ex.Message
                    lblmsg.ForeColor = Drawing.Color.Red
                End Try
            Next
        End If

     
        'End If

    End Sub
    Function GetZoneInfo(ByVal mcno As String) As DataSet

        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Select * from Fir_McZoneInfo where mcno = '" & mcno & "' order by sno", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "MN")
        con.Close()
        Return ds

    End Function


    Function GetTempInfoForZone(ByVal Zone As String) As DataSet

        MyGlobal.Con_Str()
        MyGlobal.Open_Con_FMD()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(conFMD)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Select * from Fir_temperaturecheck where   McNo = '" & Session("McNoR") & "' AND (EntryDate >= '" & Session("FsDate") & "') AND (EntryDate <= '" & Session("FTdate") & "') AND (ZoneId = '" & Zone & "') order by sno", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "MN")
        con.Close()
        Return ds

    End Function

    Private Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
        Dim f1 = 0
        Dim f2 = 0
        Dim f3 = 0
        Dim f4 = 0
        Dim f5 = 0
        Dim f6 = 0
        Dim f7 = 0
        Dim f8 = 0
        Dim f9 = 0
        Dim f10 = 0
        Dim f11 = 0
        Dim f12 = 0
        Dim f13 = 0
        Dim f14 = 0
        Dim f15 = 0
        Dim f16 = 0
        Dim f17 = 0
        Dim f18 = 0
        Dim f19 = 0
        Dim f20 = 0
        Dim f21 = 0
        Dim f22 = 0
        Dim f23 = 0
        Dim f24 = 0
        Dim f25 = 0
        Dim f26 = 0
        Dim f27 = 0
        Dim f28 = 0
        Dim f29 = 0
        Dim f30 = 0
        Dim f31 = 0
        For i As Integer = 0 To GridView1.Rows.Count - 1

            '''


            'determine the value of the status field
            Dim zMax As Decimal = GridView1.Rows(i).Cells(2).Text
            Dim zmin As Decimal = GridView1.Rows(i).Cells(3).Text

            Dim d1a As Label = TryCast(GridView1.Rows(i).FindControl("L1a"), Label)
            Dim d1p As Label = TryCast(GridView1.Rows(i).FindControl("L1p"), Label)
            Dim d2a As Label = TryCast(GridView1.Rows(i).FindControl("L2a"), Label)
            Dim d2p As Label = TryCast(GridView1.Rows(i).FindControl("L2p"), Label)
            Dim d3a As Label = TryCast(GridView1.Rows(i).FindControl("L3a"), Label)
            Dim d3p As Label = TryCast(GridView1.Rows(i).FindControl("L3p"), Label)
            Dim d4a As Label = TryCast(GridView1.Rows(i).FindControl("L4a"), Label)
            Dim d4p As Label = TryCast(GridView1.Rows(i).FindControl("L4p"), Label)
            Dim d5a As Label = TryCast(GridView1.Rows(i).FindControl("L5a"), Label)
            Dim d5p As Label = TryCast(GridView1.Rows(i).FindControl("L5p"), Label)
            Dim d6a As Label = TryCast(GridView1.Rows(i).FindControl("L6a"), Label)
            Dim d6p As Label = TryCast(GridView1.Rows(i).FindControl("L6p"), Label)
            Dim d7a As Label = TryCast(GridView1.Rows(i).FindControl("L7a"), Label)
            Dim d7p As Label = TryCast(GridView1.Rows(i).FindControl("L7p"), Label)
            Dim d8a As Label = TryCast(GridView1.Rows(i).FindControl("L8a"), Label)
            Dim d8p As Label = TryCast(GridView1.Rows(i).FindControl("L8p"), Label)
            Dim d9a As Label = TryCast(GridView1.Rows(i).FindControl("L9a"), Label)
            Dim d9p As Label = TryCast(GridView1.Rows(i).FindControl("L9p"), Label)
            Dim d10a As Label = TryCast(GridView1.Rows(i).FindControl("L10a"), Label)
            Dim d10p As Label = TryCast(GridView1.Rows(i).FindControl("L10p"), Label)

            Dim d11a As Label = TryCast(GridView1.Rows(i).FindControl("L11a"), Label)
            Dim d11p As Label = TryCast(GridView1.Rows(i).FindControl("L11p"), Label)
            Dim d12a As Label = TryCast(GridView1.Rows(i).FindControl("L12a"), Label)
            Dim d12p As Label = TryCast(GridView1.Rows(i).FindControl("L12p"), Label)
            Dim d13a As Label = TryCast(GridView1.Rows(i).FindControl("L13a"), Label)
            Dim d13p As Label = TryCast(GridView1.Rows(i).FindControl("L13p"), Label)
            Dim d14a As Label = TryCast(GridView1.Rows(i).FindControl("L14a"), Label)
            Dim d14p As Label = TryCast(GridView1.Rows(i).FindControl("L14p"), Label)
            Dim d15a As Label = TryCast(GridView1.Rows(i).FindControl("L15a"), Label)
            Dim d15p As Label = TryCast(GridView1.Rows(i).FindControl("L15p"), Label)
            Dim d16a As Label = TryCast(GridView1.Rows(i).FindControl("L16a"), Label)
            Dim d16p As Label = TryCast(GridView1.Rows(i).FindControl("L16p"), Label)
            Dim d17a As Label = TryCast(GridView1.Rows(i).FindControl("L17a"), Label)
            Dim d17p As Label = TryCast(GridView1.Rows(i).FindControl("L17p"), Label)
            Dim d18a As Label = TryCast(GridView1.Rows(i).FindControl("L18a"), Label)
            Dim d18p As Label = TryCast(GridView1.Rows(i).FindControl("L18p"), Label)
            Dim d19a As Label = TryCast(GridView1.Rows(i).FindControl("L19a"), Label)
            Dim d19p As Label = TryCast(GridView1.Rows(i).FindControl("L19p"), Label)
            Dim d20a As Label = TryCast(GridView1.Rows(i).FindControl("L20a"), Label)
            Dim d20p As Label = TryCast(GridView1.Rows(i).FindControl("L20p"), Label)

            Dim d21a As Label = TryCast(GridView1.Rows(i).FindControl("L21a"), Label)
            Dim d21p As Label = TryCast(GridView1.Rows(i).FindControl("L21p"), Label)
            Dim d22a As Label = TryCast(GridView1.Rows(i).FindControl("L22a"), Label)
            Dim d22p As Label = TryCast(GridView1.Rows(i).FindControl("L22p"), Label)
            Dim d23a As Label = TryCast(GridView1.Rows(i).FindControl("L23a"), Label)
            Dim d23p As Label = TryCast(GridView1.Rows(i).FindControl("L23p"), Label)
            Dim d24a As Label = TryCast(GridView1.Rows(i).FindControl("L24a"), Label)
            Dim d24p As Label = TryCast(GridView1.Rows(i).FindControl("L24p"), Label)
            Dim d25a As Label = TryCast(GridView1.Rows(i).FindControl("L25a"), Label)
            Dim d25p As Label = TryCast(GridView1.Rows(i).FindControl("L25p"), Label)
            Dim d26a As Label = TryCast(GridView1.Rows(i).FindControl("L26a"), Label)
            Dim d26p As Label = TryCast(GridView1.Rows(i).FindControl("L26p"), Label)
            Dim d27a As Label = TryCast(GridView1.Rows(i).FindControl("L27a"), Label)
            Dim d27p As Label = TryCast(GridView1.Rows(i).FindControl("L27p"), Label)
            Dim d28a As Label = TryCast(GridView1.Rows(i).FindControl("L28a"), Label)
            Dim d28p As Label = TryCast(GridView1.Rows(i).FindControl("L28p"), Label)
            Dim d29a As Label = TryCast(GridView1.Rows(i).FindControl("L29a"), Label)
            Dim d29p As Label = TryCast(GridView1.Rows(i).FindControl("L29p"), Label)
            Dim d30a As Label = TryCast(GridView1.Rows(i).FindControl("L30a"), Label)
            Dim d30p As Label = TryCast(GridView1.Rows(i).FindControl("L30p"), Label)

            Dim d31a As Label = TryCast(GridView1.Rows(i).FindControl("L31a"), Label)
            Dim d31p As Label = TryCast(GridView1.Rows(i).FindControl("L31p"), Label)

            '' footer


            Dim Ftot = "0"
            If d1a.Text.Trim <> "-" Then
                If (d1a.Text.Trim <= zMax And d1a.Text.Trim >= zmin) Then
                    d1a.ForeColor = Drawing.Color.Green

                Else
                    d1a.ForeColor = Drawing.Color.Red
                    f1 = f1 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d1a.Text = ""
            End If
            If d1p.Text.Trim <> "-" Then
                If (d1p.Text.Trim <= zMax And d1p.Text.Trim >= zmin) Then
                    d1p.ForeColor = Drawing.Color.Green

                Else
                    d1p.ForeColor = Drawing.Color.Red
                    f1 = f1 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d1p.Text = ""
            End If

            If d2a.Text.Trim <> "-" Then
                If (d2a.Text.Trim <= zMax And d2a.Text.Trim >= zmin) Then
                    d2a.ForeColor = Drawing.Color.Green

                Else
                    d2a.ForeColor = Drawing.Color.Red
                    f2 = f2 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d2a.Text = ""
            End If
            If d2p.Text.Trim <> "-" Then
                If (d2p.Text.Trim <= zMax And d2p.Text.Trim >= zmin) Then
                    d2p.ForeColor = Drawing.Color.Green

                Else
                    d2p.ForeColor = Drawing.Color.Red
                    f2 = f2 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d2p.Text = ""
            End If


            If d3a.Text.Trim <> "-" Then
                If (d3a.Text.Trim <= zMax And d3a.Text.Trim >= zmin) Then
                    d3a.ForeColor = Drawing.Color.Green

                Else
                    d3a.ForeColor = Drawing.Color.Red
                    f3 = f3 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d3a.Text = ""
            End If

            If d3p.Text.Trim <> "-" Then
                If (d3p.Text.Trim <= zMax And d3p.Text.Trim >= zmin) Then
                    d3p.ForeColor = Drawing.Color.Green

                Else
                    d3p.ForeColor = Drawing.Color.Red
                    f3 = f3 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d3p.Text = ""
            End If

            If d4a.Text.Trim <> "-" Then
                If (d4a.Text.Trim <= zMax And d4a.Text.Trim >= zmin) Then
                    d4a.ForeColor = Drawing.Color.Green

                Else
                    d4a.ForeColor = Drawing.Color.Red
                    f4 = f4 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d4a.Text = ""
            End If
            If d4p.Text.Trim <> "-" Then
                If (d4p.Text.Trim <= zMax And d4p.Text.Trim >= zmin) Then
                    d4p.ForeColor = Drawing.Color.Green

                Else
                    d4p.ForeColor = Drawing.Color.Red
                    f4 = f4 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d4p.Text = ""
            End If


            If d5a.Text.Trim <> "-" Then
                If (d5a.Text.Trim <= zMax And d5a.Text.Trim >= zmin) Then
                    d5a.ForeColor = Drawing.Color.Green

                Else
                    d5a.ForeColor = Drawing.Color.Red
                    f5 = f5 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d5a.Text = ""
            End If
            If d5p.Text.Trim <> "-" Then
                If (d5p.Text.Trim <= zMax And d5p.Text.Trim >= zmin) Then
                    d5p.ForeColor = Drawing.Color.Green

                Else
                    d5p.ForeColor = Drawing.Color.Red
                    f5 = f5 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d5p.Text = ""
            End If

            If d6a.Text.Trim <> "-" Then
                If (d6a.Text.Trim <= zMax And d6a.Text.Trim >= zmin) Then
                    d6a.ForeColor = Drawing.Color.Green

                Else
                    d6a.ForeColor = Drawing.Color.Red
                    f6 = f6 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d6a.Text = ""
            End If

            If d6p.Text.Trim <> "-" Then
                If (d6p.Text.Trim <= zMax And d6p.Text.Trim >= zmin) Then
                    d6p.ForeColor = Drawing.Color.Green

                Else
                    d6p.ForeColor = Drawing.Color.Red
                    f6 = f6 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d6p.Text = ""
            End If

            If d7a.Text.Trim <> "-" Then
                If (d7a.Text.Trim <= zMax And d7a.Text.Trim >= zmin) Then
                    d7a.ForeColor = Drawing.Color.Green
                Else
                    d7a.ForeColor = Drawing.Color.Red
                    f7 = f7 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d7a.Text = ""
            End If
            If d7p.Text.Trim <> "-" Then
                If (d7p.Text.Trim <= zMax And d7p.Text.Trim >= zmin) Then
                    d7p.ForeColor = Drawing.Color.Green
                Else
                    d7p.ForeColor = Drawing.Color.Red
                    f7 = f7 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d7p.Text = ""
            End If

            If d8a.Text.Trim <> "-" Then
                If (d8a.Text.Trim <= zMax And d8a.Text.Trim >= zmin) Then
                    d8a.ForeColor = Drawing.Color.Green
                Else
                    d8a.ForeColor = Drawing.Color.Red
                    f8 = f8 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d8a.Text = ""
            End If
            If d8p.Text.Trim <> "-" Then
                If (d8p.Text.Trim <= zMax And d8p.Text.Trim >= zmin) Then
                    d8p.ForeColor = Drawing.Color.Green
                Else
                    d8p.ForeColor = Drawing.Color.Red
                    f8 = f8 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d8p.Text = ""
            End If

            If d9a.Text.Trim <> "-" Then
                If (d9a.Text.Trim <= zMax And d9a.Text.Trim >= zmin) Then
                    d9a.ForeColor = Drawing.Color.Green
                Else
                    d9a.ForeColor = Drawing.Color.Red
                    f9 = f9 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d9a.Text = ""
            End If
            If d9p.Text.Trim <> "-" Then
                If (d9p.Text.Trim <= zMax And d9p.Text.Trim >= zmin) Then
                    d9p.ForeColor = Drawing.Color.Green
                Else
                    d9p.ForeColor = Drawing.Color.Red
                    f9 = f9 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d9p.Text = ""
            End If

            If d10a.Text.Trim <> "-" Then
                If (d10a.Text.Trim <= zMax And d10a.Text.Trim >= zmin) Then
                    d10a.ForeColor = Drawing.Color.Green
                Else
                    d10a.ForeColor = Drawing.Color.Red
                    f10 = f10 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d10a.Text = ""
            End If
            If d10p.Text.Trim <> "-" Then
                If (d10p.Text.Trim <= zMax And d10p.Text.Trim >= zmin) Then
                    d10p.ForeColor = Drawing.Color.Green
                Else
                    d10p.ForeColor = Drawing.Color.Red
                    f10 = f10 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d10p.Text = ""
            End If


            If d11a.Text.Trim <> "-" Then
                If (d11a.Text.Trim <= zMax And d11a.Text.Trim >= zmin) Then
                    d11a.ForeColor = Drawing.Color.Green
                Else
                    d11a.ForeColor = Drawing.Color.Red
                    f11 = f11 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d11a.Text = ""
            End If
            If d11p.Text.Trim <> "-" Then
                If (d11p.Text.Trim <= zMax And d11p.Text.Trim >= zmin) Then
                    d11p.ForeColor = Drawing.Color.Green
                Else
                    d11p.ForeColor = Drawing.Color.Red
                    f11 = f11 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d11p.Text = ""
            End If

            If d12a.Text.Trim <> "-" Then
                If (d12a.Text.Trim <= zMax And d12a.Text.Trim >= zmin) Then
                    d12a.ForeColor = Drawing.Color.Green
                Else
                    d12a.ForeColor = Drawing.Color.Red
                    f12 = f12 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d12a.Text = ""
            End If
            If d12p.Text.Trim <> "-" Then
                If (d12p.Text.Trim <= zMax And d12p.Text.Trim >= zmin) Then
                    d12p.ForeColor = Drawing.Color.Green
                Else
                    d12p.ForeColor = Drawing.Color.Red
                    f12 = f12 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d12p.Text = ""
            End If

            If d13a.Text.Trim <> "-" Then
                If (d13a.Text.Trim <= zMax And d13a.Text.Trim >= zmin) Then
                    d13a.ForeColor = Drawing.Color.Green
                Else
                    d13a.ForeColor = Drawing.Color.Red
                    f13 = f13 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d13a.Text = ""
            End If
            If d13p.Text.Trim <> "-" Then
                If (d13p.Text.Trim <= zMax And d13p.Text.Trim >= zmin) Then
                    d13p.ForeColor = Drawing.Color.Green
                Else
                    d13p.ForeColor = Drawing.Color.Red
                    f13 = f13 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d13p.Text = ""
            End If
            If d14a.Text.Trim <> "-" Then
                If (d14a.Text.Trim <= zMax And d14a.Text.Trim >= zmin) Then
                    d14a.ForeColor = Drawing.Color.Green
                Else
                    d14a.ForeColor = Drawing.Color.Red
                    f14 = f14 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d14a.Text = ""
            End If

            If d14p.Text.Trim <> "-" Then
                If (d14p.Text.Trim <= zMax And d14p.Text.Trim >= zmin) Then
                    d14p.ForeColor = Drawing.Color.Green
                Else
                    d14p.ForeColor = Drawing.Color.Red
                    f14 = f14 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d14p.Text = ""
            End If

            If d15a.Text.Trim <> "-" Then
                If (d15a.Text.Trim <= zMax And d15a.Text.Trim >= zmin) Then
                    d15a.ForeColor = Drawing.Color.Green
                Else
                    d15a.ForeColor = Drawing.Color.Red
                    f15 = f15 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d15a.Text = ""
            End If
            If d15p.Text.Trim <> "-" Then
                If (d15p.Text.Trim <= zMax And d15p.Text.Trim >= zmin) Then
                    d15p.ForeColor = Drawing.Color.Green
                Else
                    d15p.ForeColor = Drawing.Color.Red
                    f15 = f15 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d15p.Text = ""
            End If
            If d16a.Text.Trim <> "-" Then
                If (d16a.Text.Trim <= zMax And d16a.Text.Trim >= zmin) Then
                    d16a.ForeColor = Drawing.Color.Green
                Else
                    d16a.ForeColor = Drawing.Color.Red
                    f16 = f16 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d16a.Text = ""
            End If
            If d16p.Text.Trim <> "-" Then
                If (d16p.Text.Trim <= zMax And d16p.Text.Trim >= zmin) Then
                    d16p.ForeColor = Drawing.Color.Green
                Else
                    d16p.ForeColor = Drawing.Color.Red
                    f16 = f16 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d16p.Text = ""
            End If

            If d17a.Text.Trim <> "-" Then
                If (d17a.Text.Trim <= zMax And d17a.Text.Trim >= zmin) Then
                    d17a.ForeColor = Drawing.Color.Green
                Else
                    d17a.ForeColor = Drawing.Color.Red
                    f17 = f17 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d17a.Text = ""
            End If

            If d17p.Text.Trim <> "-" Then
                If (d17p.Text.Trim <= zMax And d17p.Text.Trim >= zmin) Then
                    d17p.ForeColor = Drawing.Color.Green
                Else
                    d17p.ForeColor = Drawing.Color.Red
                    f17 = f17 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d17p.Text = ""
            End If
            If d18a.Text.Trim <> "-" Then
                If (d18a.Text.Trim <= zMax And d18a.Text.Trim >= zmin) Then
                    d18a.ForeColor = Drawing.Color.Green
                Else
                    d18a.ForeColor = Drawing.Color.Red
                    f18 = f18 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d18a.Text = ""
            End If
            If d18p.Text.Trim <> "-" Then
                If (d18p.Text.Trim <= zMax And d18p.Text.Trim >= zmin) Then
                    d18p.ForeColor = Drawing.Color.Green
                Else
                    d18p.ForeColor = Drawing.Color.Red
                    f18 = f18 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d18p.Text = ""
            End If
            If d19a.Text.Trim <> "-" Then
                If (d19a.Text.Trim <= zMax And d19a.Text.Trim >= zmin) Then
                    d19a.ForeColor = Drawing.Color.Green
                Else
                    d19a.ForeColor = Drawing.Color.Red
                    f19 = f19 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d19a.Text = ""
            End If
            If d19p.Text.Trim <> "-" Then
                If (d19p.Text.Trim <= zMax And d19p.Text.Trim >= zmin) Then
                    d19p.ForeColor = Drawing.Color.Green
                Else
                    d19p.ForeColor = Drawing.Color.Red
                    f19 = f19 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d19p.Text = ""
            End If
            If d20a.Text.Trim <> "-" Then
                If (d20a.Text.Trim <= zMax And d20a.Text.Trim >= zmin) Then
                    d20a.ForeColor = Drawing.Color.Green
                Else
                    d20a.ForeColor = Drawing.Color.Red
                    f20 = f20 + 1
                    Ftot = Ftot + 1
                End If
            End If
            If d20p.Text.Trim <> "-" Then
                If (d20p.Text.Trim <= zMax And d20p.Text.Trim >= zmin) Then
                    d20p.ForeColor = Drawing.Color.Green
                Else
                    d20p.ForeColor = Drawing.Color.Red
                    f20 = f20 + 1
                    Ftot = Ftot + 1
                End If
            End If
            If d21a.Text.Trim <> "-" Then
                If (d21a.Text.Trim <= zMax And d21a.Text.Trim >= zmin) Then
                    d21a.ForeColor = Drawing.Color.Green
                Else
                    d21a.ForeColor = Drawing.Color.Red
                    f21 = f21 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d21a.Text = ""
            End If
            If d21p.Text.Trim <> "-" Then
                If (d21p.Text.Trim <= zMax And d21p.Text.Trim >= zmin) Then
                    d21p.ForeColor = Drawing.Color.Green
                Else
                    d21p.ForeColor = Drawing.Color.Red
                    f21 = f21 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d21p.Text = ""
            End If
            If d22a.Text.Trim <> "-" Then
                If (d22a.Text.Trim <= zMax And d22a.Text.Trim >= zmin) Then
                    d22a.ForeColor = Drawing.Color.Green
                Else
                    d22a.ForeColor = Drawing.Color.Red
                    f22 = f22 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d22a.Text = ""
            End If

            If d22p.Text.Trim <> "-" Then
                If (d22p.Text.Trim <= zMax And d22p.Text.Trim >= zmin) Then
                    d22p.ForeColor = Drawing.Color.Green
                Else
                    d22p.ForeColor = Drawing.Color.Red
                    f22 = f22 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d22p.Text = ""
            End If

            If d23a.Text.Trim <> "-" Then
                If (d23a.Text.Trim <= zMax And d23a.Text.Trim >= zmin) Then
                    d23a.ForeColor = Drawing.Color.Green
                Else
                    d23a.ForeColor = Drawing.Color.Red
                    f23 = f23 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d23a.Text = ""
            End If
            If d23p.Text.Trim <> "-" Then
                If (d23p.Text.Trim <= zMax And d23p.Text.Trim >= zmin) Then
                    d23p.ForeColor = Drawing.Color.Green
                Else
                    d23p.ForeColor = Drawing.Color.Red
                    f23 = f23 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d23p.Text = ""
            End If
            If d24a.Text.Trim <> "-" Then
                If (d24a.Text.Trim <= zMax And d24a.Text.Trim >= zmin) Then
                    d24a.ForeColor = Drawing.Color.Green
                Else
                    d24a.ForeColor = Drawing.Color.Red
                    f24 = f24 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d24a.Text = ""
            End If

            If d24p.Text.Trim <> "-" Then
                If (d24p.Text.Trim <= zMax And d24p.Text.Trim >= zmin) Then
                    d24p.ForeColor = Drawing.Color.Green
                Else
                    d24p.ForeColor = Drawing.Color.Red
                    f24 = f24 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d24p.Text = ""
            End If

            If d25a.Text.Trim <> "-" Then
                If (d25a.Text.Trim <= zMax And d25a.Text.Trim >= zmin) Then
                    d25a.ForeColor = Drawing.Color.Green
                Else
                    d25a.ForeColor = Drawing.Color.Red
                    f25 = f25 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d25a.Text = ""
            End If

            If d25p.Text.Trim <> "-" Then
                If (d25p.Text.Trim <= zMax And d25p.Text.Trim >= zmin) Then
                    d25p.ForeColor = Drawing.Color.Green
                Else
                    d25p.ForeColor = Drawing.Color.Red
                    f25 = f25 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d25p.Text = ""
            End If

            If d26a.Text.Trim <> "-" Then
                If (d26a.Text.Trim <= zMax And d26a.Text.Trim >= zmin) Then
                    d26a.ForeColor = Drawing.Color.Green
                Else
                    d26a.ForeColor = Drawing.Color.Red
                    f26 = f26 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d26a.Text = ""
            End If
            If d26p.Text.Trim <> "-" Then
                If (d26p.Text.Trim <= zMax And d26p.Text.Trim >= zmin) Then
                    d26p.ForeColor = Drawing.Color.Green
                Else
                    d26p.ForeColor = Drawing.Color.Red
                    f26 = f26 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d26p.Text = ""
            End If

            If d27a.Text.Trim <> "-" Then
                If (d27a.Text.Trim <= zMax And d27a.Text.Trim >= zmin) Then
                    d27a.ForeColor = Drawing.Color.Green
                Else
                    d27a.ForeColor = Drawing.Color.Red
                    f27 = f27 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d27a.Text = ""
            End If
            If d27p.Text.Trim <> "-" Then
                If (d27p.Text.Trim <= zMax And d27p.Text.Trim >= zmin) Then
                    d27p.ForeColor = Drawing.Color.Green
                Else
                    d27p.ForeColor = Drawing.Color.Red
                    f27 = f27 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d27p.Text = ""
            End If
            If d28a.Text.Trim <> "-" Then
                If (d28a.Text.Trim <= zMax And d28a.Text.Trim >= zmin) Then
                    d28a.ForeColor = Drawing.Color.Green
                Else
                    d28a.ForeColor = Drawing.Color.Red
                    f28 = f28 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d28a.Text = ""
            End If
            If d28p.Text.Trim <> "-" Then
                If (d28p.Text.Trim <= zMax And d28p.Text.Trim >= zmin) Then
                    d28p.ForeColor = Drawing.Color.Green
                Else
                    d28p.ForeColor = Drawing.Color.Red
                    f28 = f28 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d28p.Text = ""
            End If

            If d29a.Text.Trim <> "-" Then
                If (d29a.Text.Trim <= zMax And d29a.Text.Trim >= zmin) Then
                    d29a.ForeColor = Drawing.Color.Green
                Else
                    d29a.ForeColor = Drawing.Color.Red
                    f29 = f29 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d29a.Text = ""
            End If
            If d29p.Text.Trim <> "-" Then
                If (d29p.Text.Trim <= zMax And d29p.Text.Trim >= zmin) Then
                    d29p.ForeColor = Drawing.Color.Green
                Else
                    d29p.ForeColor = Drawing.Color.Red
                    f29 = f29 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d29p.Text = ""
            End If
            If d30a.Text.Trim <> "-" Then
                If (d30a.Text.Trim <= zMax And d30a.Text.Trim >= zmin) Then
                    d30a.ForeColor = Drawing.Color.Green
                Else
                    d30a.ForeColor = Drawing.Color.Red
                    f30 = f30 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d30a.Text = ""
            End If
            If d30p.Text.Trim <> "-" Then
                If (d30p.Text.Trim <= zMax And d30p.Text.Trim >= zmin) Then
                    d30p.ForeColor = Drawing.Color.Green
                Else
                    d30p.ForeColor = Drawing.Color.Red
                    f30 = f30 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d30p.Text = ""
            End If

            If d31a.Text.Trim <> "-" Then
                If (d31a.Text.Trim <= zMax And d31a.Text.Trim >= zmin) Then
                    d31a.ForeColor = Drawing.Color.Green
                Else
                    d31a.ForeColor = Drawing.Color.Red
                    f31 = f31 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d31a.Text = ""
            End If

            If d31p.Text.Trim <> "-" Then
                If (d31p.Text.Trim <= zMax And d31p.Text.Trim >= zmin) Then
                    d31p.ForeColor = Drawing.Color.Green
                Else
                    d31p.ForeColor = Drawing.Color.Red
                    f31 = f31 + 1
                    Ftot = Ftot + 1
                End If
            Else
                d31p.Text = ""
            End If

            '  Ftot = f1 + f2 + f3 + f4 + f5 + f6 + f7 + f8 + f9 + f10 + f11 + f12 + f13 + f14 + f15 + f16 + f17 + f18 + f19 + f20 + f21 + f22 + f23 + f24 + f25 + f26 + f27 + f28 + f29 + f30 + f31
            TryCast(GridView1.Rows(i).FindControl("lbltot"), Label).Text = Ftot
            ''''
            Dim f1p As Label = TryCast(GridView1.FooterRow.FindControl("f1p"), Label)
            Dim f2p As Label = TryCast(GridView1.FooterRow.FindControl("f2p"), Label)
            Dim f3p As Label = TryCast(GridView1.FooterRow.FindControl("F3p"), Label)
            Dim f4p As Label = TryCast(GridView1.FooterRow.FindControl("F4p"), Label)
            Dim f5p As Label = TryCast(GridView1.FooterRow.FindControl("F5p"), Label)
            Dim f6p As Label = TryCast(GridView1.FooterRow.FindControl("F6p"), Label)
            Dim f7p As Label = TryCast(GridView1.FooterRow.FindControl("F7p"), Label)
            Dim f8p As Label = TryCast(GridView1.FooterRow.FindControl("F8p"), Label)
            Dim f9p As Label = TryCast(GridView1.FooterRow.FindControl("F9p"), Label)
            Dim f10p As Label = TryCast(GridView1.FooterRow.FindControl("F10p"), Label)
            Dim f11p As Label = TryCast(GridView1.FooterRow.FindControl("F11p"), Label)
            Dim f12p As Label = TryCast(GridView1.FooterRow.FindControl("F12p"), Label)
            Dim f13p As Label = TryCast(GridView1.FooterRow.FindControl("F13p"), Label)
            Dim f14p As Label = TryCast(GridView1.FooterRow.FindControl("F14p"), Label)
            Dim f15p As Label = TryCast(GridView1.FooterRow.FindControl("F15p"), Label)
            Dim f16p As Label = TryCast(GridView1.FooterRow.FindControl("F16p"), Label)
            Dim f17p As Label = TryCast(GridView1.FooterRow.FindControl("F17p"), Label)

            Dim f18p As Label = TryCast(GridView1.FooterRow.FindControl("F18p"), Label)
            Dim f19p As Label = TryCast(GridView1.FooterRow.FindControl("F19p"), Label)
            Dim f20p As Label = TryCast(GridView1.FooterRow.FindControl("F20p"), Label)
            Dim f21p As Label = TryCast(GridView1.FooterRow.FindControl("F21p"), Label)
            Dim f22p As Label = TryCast(GridView1.FooterRow.FindControl("F22p"), Label)

            Dim f23p As Label = TryCast(GridView1.FooterRow.FindControl("F23p"), Label)
            Dim f24p As Label = TryCast(GridView1.FooterRow.FindControl("F24p"), Label)
            Dim f25p As Label = TryCast(GridView1.FooterRow.FindControl("F25p"), Label)
            Dim f26p As Label = TryCast(GridView1.FooterRow.FindControl("F26p"), Label)
            Dim f27p As Label = TryCast(GridView1.FooterRow.FindControl("F27p"), Label)

            Dim f28p As Label = TryCast(GridView1.FooterRow.FindControl("F28p"), Label)
            Dim f29p As Label = TryCast(GridView1.FooterRow.FindControl("F29p"), Label)
            Dim f30p As Label = TryCast(GridView1.FooterRow.FindControl("F30p"), Label)
            Dim f31p As Label = TryCast(GridView1.FooterRow.FindControl("F31p"), Label)



            f1p.Text = f1
            f2p.Text = f2
            f3p.Text = f3
            f4p.Text = f4
            f5p.Text = f5
            f6p.Text = f6
            f7p.Text = f7
            f8p.Text = f8
            f9p.Text = f9
            f10p.Text = f10
            f11p.Text = f11
            f12p.Text = f12
            f13p.Text = f13
            f14p.Text = f14
            f15p.Text = f15
            f16p.Text = f16
            f17p.Text = f17
            f18p.Text = f18
            f19p.Text = f19
            f20p.Text = f20
            f21p.Text = f21
            f22p.Text = f22
            f23p.Text = f23
            f24p.Text = f24
            f25p.Text = f25
            f26p.Text = f26
            f27p.Text = f27
            f28p.Text = f28
            f29p.Text = f29
            f30p.Text = f30
            f31p.Text = f31

        Next
    End Sub

    Private Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        '  gridview1.Attributes.Add(
    End Sub


    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        Dim f1 = 0
        Dim f2 = 0
        Dim f3 = 0
        Dim f4 = 0
        Dim f5 = 0
        Dim f6 = 0
        Dim f7 = 0
        Dim f8 = 0
        Dim f9 = 0
        Dim f10 = 0
        Dim f11 = 0
        Dim f12 = 0
        Dim f13 = 0
        Dim f14 = 0
        Dim f15 = 0
        Dim f16 = 0
        Dim f17 = 0
        Dim f18 = 0
        Dim f19 = 0
        Dim f20 = 0
        Dim f21 = 0
        Dim f22 = 0
        Dim f23 = 0
        Dim f24 = 0
        Dim f25 = 0
        Dim f26 = 0
        Dim f27 = 0
        Dim f28 = 0
        Dim f29 = 0
        Dim f30 = 0
        Dim f31 = 0

        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    'determine the value of the status field
        '    Dim zMax As Decimal = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "fmax"))
        '    Dim zmin As Decimal = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "fmin"))

        '    Dim d1a As Label = TryCast(e.Row.FindControl("L1a"), Label)
        '    Dim d1p As Label = TryCast(e.Row.FindControl("L1p"), Label)
        '    Dim d2a As Label = TryCast(e.Row.FindControl("L2a"), Label)
        '    Dim d2p As Label = TryCast(e.Row.FindControl("L2p"), Label)
        '    Dim d3a As Label = TryCast(e.Row.FindControl("L3a"), Label)
        '    Dim d3p As Label = TryCast(e.Row.FindControl("L3p"), Label)
        '    Dim d4a As Label = TryCast(e.Row.FindControl("L4a"), Label)
        '    Dim d4p As Label = TryCast(e.Row.FindControl("L4p"), Label)
        '    Dim d5a As Label = TryCast(e.Row.FindControl("L5a"), Label)
        '    Dim d5p As Label = TryCast(e.Row.FindControl("L5p"), Label)
        '    Dim d6a As Label = TryCast(e.Row.FindControl("L6a"), Label)
        '    Dim d6p As Label = TryCast(e.Row.FindControl("L6p"), Label)
        '    Dim d7a As Label = TryCast(e.Row.FindControl("L7a"), Label)
        '    Dim d7p As Label = TryCast(e.Row.FindControl("L7p"), Label)
        '    Dim d8a As Label = TryCast(e.Row.FindControl("L8a"), Label)
        '    Dim d8p As Label = TryCast(e.Row.FindControl("L8p"), Label)
        '    Dim d9a As Label = TryCast(e.Row.FindControl("L9a"), Label)
        '    Dim d9p As Label = TryCast(e.Row.FindControl("L9p"), Label)
        '    Dim d10a As Label = TryCast(e.Row.FindControl("L10a"), Label)
        '    Dim d10p As Label = TryCast(e.Row.FindControl("L10p"), Label)

        '    Dim d11a As Label = TryCast(e.Row.FindControl("L11a"), Label)
        '    Dim d11p As Label = TryCast(e.Row.FindControl("L11p"), Label)
        '    Dim d12a As Label = TryCast(e.Row.FindControl("L12a"), Label)
        '    Dim d12p As Label = TryCast(e.Row.FindControl("L12p"), Label)
        '    Dim d13a As Label = TryCast(e.Row.FindControl("L13a"), Label)
        '    Dim d13p As Label = TryCast(e.Row.FindControl("L13p"), Label)
        '    Dim d14a As Label = TryCast(e.Row.FindControl("L14a"), Label)
        '    Dim d14p As Label = TryCast(e.Row.FindControl("L14p"), Label)
        '    Dim d15a As Label = TryCast(e.Row.FindControl("L15a"), Label)
        '    Dim d15p As Label = TryCast(e.Row.FindControl("L15p"), Label)
        '    Dim d16a As Label = TryCast(e.Row.FindControl("L16a"), Label)
        '    Dim d16p As Label = TryCast(e.Row.FindControl("L16p"), Label)
        '    Dim d17a As Label = TryCast(e.Row.FindControl("L17a"), Label)
        '    Dim d17p As Label = TryCast(e.Row.FindControl("L17p"), Label)
        '    Dim d18a As Label = TryCast(e.Row.FindControl("L18a"), Label)
        '    Dim d18p As Label = TryCast(e.Row.FindControl("L18p"), Label)
        '    Dim d19a As Label = TryCast(e.Row.FindControl("L19a"), Label)
        '    Dim d19p As Label = TryCast(e.Row.FindControl("L19p"), Label)
        '    Dim d20a As Label = TryCast(e.Row.FindControl("L20a"), Label)
        '    Dim d20p As Label = TryCast(e.Row.FindControl("L20p"), Label)

        '    Dim d21a As Label = TryCast(e.Row.FindControl("L21a"), Label)
        '    Dim d21p As Label = TryCast(e.Row.FindControl("L21p"), Label)
        '    Dim d22a As Label = TryCast(e.Row.FindControl("L22a"), Label)
        '    Dim d22p As Label = TryCast(e.Row.FindControl("L22p"), Label)
        '    Dim d23a As Label = TryCast(e.Row.FindControl("L23a"), Label)
        '    Dim d23p As Label = TryCast(e.Row.FindControl("L23p"), Label)
        '    Dim d24a As Label = TryCast(e.Row.FindControl("L24a"), Label)
        '    Dim d24p As Label = TryCast(e.Row.FindControl("L24p"), Label)
        '    Dim d25a As Label = TryCast(e.Row.FindControl("L25a"), Label)
        '    Dim d25p As Label = TryCast(e.Row.FindControl("L25p"), Label)
        '    Dim d26a As Label = TryCast(e.Row.FindControl("L26a"), Label)
        '    Dim d26p As Label = TryCast(e.Row.FindControl("L26p"), Label)
        '    Dim d27a As Label = TryCast(e.Row.FindControl("L27a"), Label)
        '    Dim d27p As Label = TryCast(e.Row.FindControl("L27p"), Label)
        '    Dim d28a As Label = TryCast(e.Row.FindControl("L28a"), Label)
        '    Dim d28p As Label = TryCast(e.Row.FindControl("L28p"), Label)
        '    Dim d29a As Label = TryCast(e.Row.FindControl("L29a"), Label)
        '    Dim d29p As Label = TryCast(e.Row.FindControl("L29p"), Label)
        '    Dim d30a As Label = TryCast(e.Row.FindControl("L30a"), Label)
        '    Dim d30p As Label = TryCast(e.Row.FindControl("L30p"), Label)
        '    Dim d31a As Label = TryCast(e.Row.FindControl("L31a"), Label)
        '    Dim d31p As Label = TryCast(e.Row.FindControl("L31p"), Label)

        '    '' footer

        '    If d1a.Text.Trim <> "-" Then
        '        If (d1a.Text.Trim <= zMax And d1a.Text.Trim >= zmin) Then
        '            d1a.ForeColor = Drawing.Color.Green
        '            f1 = f1 + 1
        '        Else
        '            d1a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d1a.Text = ""
        '    End If
        '    If d1p.Text.Trim <> "-" Then
        '        If (d1p.Text.Trim <= zMax And d1p.Text.Trim >= zmin) Then
        '            d1p.ForeColor = Drawing.Color.Green
        '            f1 = f1 + 1
        '        Else
        '            d1p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d1p.Text = ""
        '    End If

        '    If d2a.Text.Trim <> "-" Then
        '        If (d2a.Text.Trim <= zMax And d2a.Text.Trim >= zmin) Then
        '            d2a.ForeColor = Drawing.Color.Green
        '            f2 = f2 + 1
        '        Else
        '            d2a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d2a.Text = ""
        '    End If
        '    If d2p.Text.Trim <> "-" Then
        '        If (d2p.Text.Trim <= zMax And d2p.Text.Trim >= zmin) Then
        '            d2p.ForeColor = Drawing.Color.Green
        '            f2 = f2 + 1
        '        Else
        '            d2p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d2p.Text = ""
        '    End If


        '    If d3a.Text.Trim <> "-" Then
        '        If (d3a.Text.Trim <= zMax And d3a.Text.Trim >= zmin) Then
        '            d3a.ForeColor = Drawing.Color.Green
        '            f3 = f3 + 1
        '        Else
        '            d3a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d3a.Text = ""
        '    End If

        '    If d3p.Text.Trim <> "-" Then
        '        If (d3p.Text.Trim <= zMax And d3p.Text.Trim >= zmin) Then
        '            d3p.ForeColor = Drawing.Color.Green
        '            f3 = f3 + 1
        '        Else
        '            d3p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d3p.Text = ""
        '    End If

        '    If d4a.Text.Trim <> "-" Then
        '        If (d4a.Text.Trim <= zMax And d4a.Text.Trim >= zmin) Then
        '            d4a.ForeColor = Drawing.Color.Green
        '            f4 = f4 + 1
        '        Else
        '            d4a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d4a.Text = ""
        '    End If
        '    If d4p.Text.Trim <> "-" Then
        '        If (d4p.Text.Trim <= zMax And d4p.Text.Trim >= zmin) Then
        '            d4p.ForeColor = Drawing.Color.Green
        '            f4 = f4 + 1
        '        Else
        '            d4p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d4p.Text = ""
        '    End If


        '    If d5a.Text.Trim <> "-" Then
        '        If (d5a.Text.Trim <= zMax And d5a.Text.Trim >= zmin) Then
        '            d5a.ForeColor = Drawing.Color.Green
        '            f5 = f5 + 1
        '        Else
        '            d5a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d5a.Text = ""
        '    End If
        '    If d5p.Text.Trim <> "-" Then
        '        If (d5p.Text.Trim <= zMax And d5p.Text.Trim >= zmin) Then
        '            d5p.ForeColor = Drawing.Color.Green
        '            f5 = f5 + 1
        '        Else
        '            d5p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d5p.Text = ""
        '    End If

        '    If d6a.Text.Trim <> "-" Then
        '        If (d6a.Text.Trim <= zMax And d6a.Text.Trim >= zmin) Then
        '            d6a.ForeColor = Drawing.Color.Green
        '            f6 = f6 + 1
        '        Else
        '            d6a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d6a.Text = ""
        '    End If

        '    If d6p.Text.Trim <> "-" Then
        '        If (d6p.Text.Trim <= zMax And d6p.Text.Trim >= zmin) Then
        '            d6p.ForeColor = Drawing.Color.Green
        '            f6 = f6 + 1
        '        Else
        '            d6p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d6p.Text = ""
        '    End If

        '    If d7a.Text.Trim <> "-" Then
        '        If (d7a.Text.Trim <= zMax And d7a.Text.Trim >= zmin) Then
        '            d7a.ForeColor = Drawing.Color.Green
        '        Else
        '            d7a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d7a.Text = ""
        '    End If
        '    If d7p.Text.Trim <> "-" Then
        '        If (d7p.Text.Trim <= zMax And d7p.Text.Trim >= zmin) Then
        '            d7p.ForeColor = Drawing.Color.Green
        '        Else
        '            d7p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d7p.Text = ""
        '    End If

        '    If d8a.Text.Trim <> "-" Then
        '        If (d8a.Text.Trim <= zMax And d8a.Text.Trim >= zmin) Then
        '            d8a.ForeColor = Drawing.Color.Green
        '        Else
        '            d8a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d8a.Text = ""
        '    End If
        '    If d8p.Text.Trim <> "-" Then
        '        If (d8p.Text.Trim <= zMax And d8p.Text.Trim >= zmin) Then
        '            d8p.ForeColor = Drawing.Color.Green
        '        Else
        '            d8p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d8p.Text = ""
        '    End If

        '    If d9a.Text.Trim <> "-" Then
        '        If (d9a.Text.Trim <= zMax And d9a.Text.Trim >= zmin) Then
        '            d9a.ForeColor = Drawing.Color.Green
        '        Else
        '            d9a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d9a.Text = ""
        '    End If
        '    If d9p.Text.Trim <> "-" Then
        '        If (d9p.Text.Trim <= zMax And d9p.Text.Trim >= zmin) Then
        '            d9p.ForeColor = Drawing.Color.Green
        '        Else
        '            d9p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d9p.Text = ""
        '    End If

        '    If d10a.Text.Trim <> "-" Then
        '        If (d10a.Text.Trim <= zMax And d10a.Text.Trim >= zmin) Then
        '            d10a.ForeColor = Drawing.Color.Green
        '        Else
        '            d10a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d10a.Text = ""
        '    End If
        '    If d10p.Text.Trim <> "-" Then
        '        If (d10p.Text.Trim <= zMax And d10p.Text.Trim >= zmin) Then
        '            d10p.ForeColor = Drawing.Color.Green
        '        Else
        '            d10p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d10p.Text = ""
        '    End If
        '    If d11a.Text.Trim <> "-" Then
        '        If (d11a.Text.Trim <= zMax And d11a.Text.Trim >= zmin) Then
        '            d11a.ForeColor = Drawing.Color.Green
        '        Else
        '            d11a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d11a.Text = ""
        '    End If
        '    If d11p.Text.Trim <> "-" Then
        '        If (d11p.Text.Trim <= zMax And d11p.Text.Trim >= zmin) Then
        '            d11p.ForeColor = Drawing.Color.Green
        '        Else
        '            d11p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d11p.Text = ""
        '    End If
        '    If d12a.Text.Trim <> "-" Then
        '        If (d12a.Text.Trim <= zMax And d12a.Text.Trim >= zmin) Then
        '            d12a.ForeColor = Drawing.Color.Green
        '        Else
        '            d12a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d12a.Text = ""
        '    End If
        '    If d12p.Text.Trim <> "-" Then
        '        If (d12p.Text.Trim <= zMax And d12p.Text.Trim >= zmin) Then
        '            d12p.ForeColor = Drawing.Color.Green
        '        Else
        '            d12p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d12p.Text = ""
        '    End If

        '    If d13a.Text.Trim <> "-" Then
        '        If (d13a.Text.Trim <= zMax And d13a.Text.Trim >= zmin) Then
        '            d13a.ForeColor = Drawing.Color.Green
        '        Else
        '            d13a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d13a.Text = ""
        '    End If
        '    If d13p.Text.Trim <> "-" Then
        '        If (d13p.Text.Trim <= zMax And d13p.Text.Trim >= zmin) Then
        '            d13p.ForeColor = Drawing.Color.Green
        '        Else
        '            d13p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d13p.Text = ""
        '    End If
        '    If d14a.Text.Trim <> "-" Then
        '        If (d14a.Text.Trim <= zMax And d14a.Text.Trim >= zmin) Then
        '            d14a.ForeColor = Drawing.Color.Green
        '        Else
        '            d14a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d14a.Text = ""
        '    End If
        '    If d14p.Text.Trim <> "-" Then
        '        If (d14p.Text.Trim <= zMax And d14p.Text.Trim >= zmin) Then
        '            d14p.ForeColor = Drawing.Color.Green
        '        Else
        '            d14p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d14p.Text = ""
        '    End If

        '    If d15a.Text.Trim <> "-" Then
        '        If (d15a.Text.Trim <= zMax And d15a.Text.Trim >= zmin) Then
        '            d15a.ForeColor = Drawing.Color.Green
        '        Else
        '            d15a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d15a.Text = ""
        '    End If
        '    If d15p.Text.Trim <> "-" Then
        '        If (d15p.Text.Trim <= zMax And d15p.Text.Trim >= zmin) Then
        '            d15p.ForeColor = Drawing.Color.Green
        '        Else
        '            d15p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d15p.Text = ""
        '    End If
        '    If d16a.Text.Trim <> "-" Then
        '        If (d16a.Text.Trim <= zMax And d16a.Text.Trim >= zmin) Then
        '            d16a.ForeColor = Drawing.Color.Green
        '        Else
        '            d16a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d16a.Text = ""
        '    End If
        '    If d16p.Text.Trim <> "-" Then
        '        If (d16p.Text.Trim <= zMax And d16p.Text.Trim >= zmin) Then
        '            d16p.ForeColor = Drawing.Color.Green
        '        Else
        '            d16p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d16p.Text = ""
        '    End If

        '    If d17a.Text.Trim <> "-" Then
        '        If (d17a.Text.Trim <= zMax And d17a.Text.Trim >= zmin) Then
        '            d17a.ForeColor = Drawing.Color.Green
        '        Else
        '            d17a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d17a.Text = ""
        '    End If
        '    If d17p.Text.Trim <> "-" Then
        '        If (d17p.Text.Trim <= zMax And d17p.Text.Trim >= zmin) Then
        '            d17p.ForeColor = Drawing.Color.Green
        '        Else
        '            d17p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d17p.Text = ""
        '    End If
        '    If d18a.Text.Trim <> "-" Then
        '        If (d18a.Text.Trim <= zMax And d18a.Text.Trim >= zmin) Then
        '            d18a.ForeColor = Drawing.Color.Green
        '        Else
        '            d18a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d18a.Text = ""
        '    End If
        '    If d18p.Text.Trim <> "-" Then
        '        If (d18p.Text.Trim <= zMax And d18p.Text.Trim >= zmin) Then
        '            d18p.ForeColor = Drawing.Color.Green
        '        Else
        '            d18p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d18p.Text = ""
        '    End If
        '    If d19a.Text.Trim <> "-" Then
        '        If (d19a.Text.Trim <= zMax And d19a.Text.Trim >= zmin) Then
        '            d19a.ForeColor = Drawing.Color.Green
        '        Else
        '            d19a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d19a.Text = ""
        '    End If
        '    If d19p.Text.Trim <> "-" Then
        '        If (d19p.Text.Trim <= zMax And d19p.Text.Trim >= zmin) Then
        '            d19p.ForeColor = Drawing.Color.Green
        '        Else
        '            d19p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d19p.Text = ""
        '    End If
        '    If d20a.Text.Trim <> "-" Then
        '        If (d20a.Text.Trim <= zMax And d20a.Text.Trim >= zmin) Then
        '            d20a.ForeColor = Drawing.Color.Green
        '        Else
        '            d20a.ForeColor = Drawing.Color.Red
        '        End If
        '    End If
        '    If d20p.Text.Trim <> "-" Then
        '        If (d20p.Text.Trim <= zMax And d20p.Text.Trim >= zmin) Then
        '            d20p.ForeColor = Drawing.Color.Green
        '        Else
        '            d20p.ForeColor = Drawing.Color.Red
        '        End If
        '    End If
        '    If d21a.Text.Trim <> "-" Then
        '        If (d21a.Text.Trim <= zMax And d21a.Text.Trim >= zmin) Then
        '            d21a.ForeColor = Drawing.Color.Green
        '        Else
        '            d21a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d21a.Text = ""
        '    End If
        '    If d21p.Text.Trim <> "-" Then
        '        If (d21p.Text.Trim <= zMax And d21p.Text.Trim >= zmin) Then
        '            d21p.ForeColor = Drawing.Color.Green
        '        Else
        '            d21p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d21p.Text = ""
        '    End If
        '    If d22a.Text.Trim <> "-" Then
        '        If (d22a.Text.Trim <= zMax And d22a.Text.Trim >= zmin) Then
        '            d22a.ForeColor = Drawing.Color.Green
        '        Else
        '            d22a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d22a.Text = ""
        '    End If

        '    If d22p.Text.Trim <> "-" Then
        '        If (d22p.Text.Trim <= zMax And d22p.Text.Trim >= zmin) Then
        '            d22p.ForeColor = Drawing.Color.Green
        '        Else
        '            d22p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d22p.Text = ""
        '    End If

        '    If d23a.Text.Trim <> "-" Then
        '        If (d23a.Text.Trim <= zMax And d23a.Text.Trim >= zmin) Then
        '            d23a.ForeColor = Drawing.Color.Green
        '        Else
        '            d23a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d23a.Text = ""
        '    End If
        '    If d23p.Text.Trim <> "-" Then
        '        If (d23p.Text.Trim <= zMax And d23p.Text.Trim >= zmin) Then
        '            d23p.ForeColor = Drawing.Color.Green
        '        Else
        '            d23p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d23p.Text = ""
        '    End If
        '    If d24a.Text.Trim <> "-" Then
        '        If (d24a.Text.Trim <= zMax And d24a.Text.Trim >= zmin) Then
        '            d24a.ForeColor = Drawing.Color.Green
        '        Else
        '            d24a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d24a.Text = ""
        '    End If

        '    If d24p.Text.Trim <> "-" Then
        '        If (d24p.Text.Trim <= zMax And d24p.Text.Trim >= zmin) Then
        '            d24p.ForeColor = Drawing.Color.Green
        '        Else
        '            d24p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d24p.Text = ""
        '    End If

        '    If d25a.Text.Trim <> "-" Then
        '        If (d25a.Text.Trim <= zMax And d25a.Text.Trim >= zmin) Then
        '            d25a.ForeColor = Drawing.Color.Green
        '        Else
        '            d25a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d25a.Text = ""
        '    End If

        '    If d25p.Text.Trim <> "-" Then
        '        If (d25p.Text.Trim <= zMax And d25p.Text.Trim >= zmin) Then
        '            d25p.ForeColor = Drawing.Color.Green
        '        Else
        '            d25p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d25p.Text = ""
        '    End If

        '    If d26a.Text.Trim <> "-" Then
        '        If (d26a.Text.Trim <= zMax And d26a.Text.Trim >= zmin) Then
        '            d26a.ForeColor = Drawing.Color.Green
        '        Else
        '            d26a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d26a.Text = ""
        '    End If
        '    If d26p.Text.Trim <> "-" Then
        '        If (d26p.Text.Trim <= zMax And d26p.Text.Trim >= zmin) Then
        '            d26p.ForeColor = Drawing.Color.Green
        '        Else
        '            d26p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d26p.Text = ""
        '    End If

        '    If d27a.Text.Trim <> "-" Then
        '        If (d27a.Text.Trim <= zMax And d27a.Text.Trim >= zmin) Then
        '            d27a.ForeColor = Drawing.Color.Green
        '        Else
        '            d27a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d27a.Text = ""
        '    End If
        '    If d27p.Text.Trim <> "-" Then
        '        If (d27p.Text.Trim <= zMax And d27p.Text.Trim >= zmin) Then
        '            d27p.ForeColor = Drawing.Color.Green
        '        Else
        '            d27p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d27p.Text = ""
        '    End If
        '    If d28a.Text.Trim <> "-" Then
        '        If (d28a.Text.Trim <= zMax And d28a.Text.Trim >= zmin) Then
        '            d28a.ForeColor = Drawing.Color.Green
        '        Else
        '            d28a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d28a.Text = ""
        '    End If
        '    If d28p.Text.Trim <> "-" Then
        '        If (d28p.Text.Trim <= zMax And d28p.Text.Trim >= zmin) Then
        '            d28p.ForeColor = Drawing.Color.Green
        '        Else
        '            d28p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d28p.Text = ""
        '    End If

        '    If d29a.Text.Trim <> "-" Then
        '        If (d29a.Text.Trim <= zMax And d29a.Text.Trim >= zmin) Then
        '            d29a.ForeColor = Drawing.Color.Green
        '        Else
        '            d29a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d29a.Text = ""
        '    End If
        '    If d29p.Text.Trim <> "-" Then
        '        If (d29p.Text.Trim <= zMax And d29p.Text.Trim >= zmin) Then
        '            d29p.ForeColor = Drawing.Color.Green
        '        Else
        '            d29p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d29p.Text = ""
        '    End If
        '    If d30a.Text.Trim <> "-" Then
        '        If (d30a.Text.Trim <= zMax And d30a.Text.Trim >= zmin) Then
        '            d30a.ForeColor = Drawing.Color.Green
        '        Else
        '            d30a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d30a.Text = ""
        '    End If
        '    If d30p.Text.Trim <> "-" Then
        '        If (d30p.Text.Trim <= zMax And d30p.Text.Trim >= zmin) Then
        '            d30p.ForeColor = Drawing.Color.Green
        '        Else
        '            d30p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d30p.Text = ""
        '    End If

        '    If d31a.Text.Trim <> "-" Then
        '        If (d31a.Text.Trim <= zMax And d31a.Text.Trim >= zmin) Then
        '            d31a.ForeColor = Drawing.Color.Green
        '        Else
        '            d31a.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d31a.Text = ""
        '    End If

        '    If d31p.Text.Trim <> "-" Then
        '        If (d31p.Text.Trim <= zMax And d31p.Text.Trim >= zmin) Then
        '            d31p.ForeColor = Drawing.Color.Green
        '        Else
        '            d31p.ForeColor = Drawing.Color.Red
        '        End If
        '    Else
        '        d31p.Text = ""
        '    End If

        'End If
   
      

    End Sub

    Public Sub test()

    End Sub
End Class