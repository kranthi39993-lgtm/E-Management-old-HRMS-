Imports System.Data.SqlClient

Partial Public Class ApplnFormView
    Inherits System.Web.UI.Page
    Dim UID As Integer
    Dim TmpDs As New DataSet

    'Dim constr As String = "Data Source=Techfics2\Techfics;Initial Catalog=hrmis;uid=sa;password=TechficsPro"
    Dim constr As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"

    Function CallSP(ByVal Options As String, ByVal Uid As Integer, ByVal Post As String, ByVal Name As String, ByVal Address As String, ByVal Ic As String, ByVal Telno As String, ByVal Sex As String, ByVal Age As String, ByVal Hw As String, ByVal Nationality As String, ByVal Religion As String, ByVal Itno As String, ByVal Race As String, ByVal Sosco As String, ByVal Epf As String, ByVal Km As String, ByVal Trans As String, ByVal Lang As String, ByVal Dob As Date, ByVal Pof As String, ByVal Uni As String, ByVal Mart As String, ByVal Pri1 As String, ByVal Pri2 As String, ByVal Pri3 As Date, ByVal pri4 As Date, ByVal pri5 As String, ByVal Sec1 As String, ByVal Sec2 As String, ByVal Sec3 As Date, ByVal Sec4 As Date, ByVal Sec5 As String, ByVal Uni1 As String, ByVal Uni2 As String, ByVal Uni3 As Date, ByVal Uni4 As Date, ByVal Uni5 As String, ByVal Cer1 As String, ByVal Cer2 As String, ByVal Cer3 As Date, ByVal Cer4 As Date, ByVal Cer5 As String, ByVal Exp1 As String, ByVal Tel1 As String, ByVal Date1 As Date, ByVal Job1 As String, ByVal Dut1 As String, ByVal Sal1 As Integer, ByVal Reason1 As String, ByVal Exp2 As String, ByVal Tel2 As String, ByVal Date2 As String, ByVal Job2 As String, ByVal Dut2 As String, ByVal Sal2 As Integer, ByVal Reason2 As String, ByVal Exp3 As String, ByVal Tel3 As String, ByVal Date3 As String, ByVal job3 As String, ByVal Dut3 As String, ByVal Sal3 As Integer, ByVal Reason3 As String, ByVal Smoke As String, ByVal NoCigar As String, ByVal Marwa As String, ByVal Illness As String, ByVal Accident As String, ByVal Medi As String, ByVal Suffer As String, ByVal Glass As String, ByVal Vision As String, ByVal Shift As String, ByVal Pregnant As String, ByVal Worki As String, ByVal Department As String, ByVal Joind As String, ByVal Minsal As Integer, ByVal Vacancies As String, ByVal Name1 As String, ByVal add2 As String, ByVal Telno2 As String, ByVal Relation As String, ByVal Lastdate As Date, ByVal Signature As String, ByVal Pan1 As String, ByVal Id1 As String, ByVal Empname1 As String, ByVal Hire1 As String, ByVal Pan2 As String, ByVal id2 As String, ByVal Empname2 As String, ByVal Hire2 As String, ByVal Pan3 As String, ByVal id3 As String, ByVal Empname3 As String, ByVal Hire As String) As DataSet
        '   MyGlobal.Con_Str()F
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Admission_SP", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@Option", Options)
        Command.Parameters.AddWithValue("@Uid", Uid)
        Command.Parameters.AddWithValue("@Post", Post)
        Command.Parameters.AddWithValue("@Name", Name)
        Command.Parameters.AddWithValue("@Address", Address)
        Command.Parameters.AddWithValue("@Ic", Ic)
        Command.Parameters.AddWithValue("@Telno", Telno)
        Command.Parameters.AddWithValue("@Sex", Sex)
        Command.Parameters.AddWithValue("@Age", Age)
        Command.Parameters.AddWithValue("@Hw", Hw)
        Command.Parameters.AddWithValue("@Nationality", Nationality)
        Command.Parameters.AddWithValue("@Religion", Religion)
        Command.Parameters.AddWithValue("@Itno", Itno)
        Command.Parameters.AddWithValue("@Race", Race)
        Command.Parameters.AddWithValue("@Sosco", Sosco)
        Command.Parameters.AddWithValue("@Epf", Epf)
        Command.Parameters.AddWithValue("@Km", Km)
        Command.Parameters.AddWithValue("@Trans", Trans)
        Command.Parameters.AddWithValue("@Lang", Lang)
        Command.Parameters.AddWithValue("@Dob", Dob)
        Command.Parameters.AddWithValue("@Pof", Pof)
        Command.Parameters.AddWithValue("@Uni", Uni)
        Command.Parameters.AddWithValue("@Mart", Mart)
        Command.Parameters.AddWithValue("@Pri1", Pri1)
        Command.Parameters.AddWithValue("@Pri2", Pri2)
        Command.Parameters.AddWithValue("@Pri3", Pri3)
        Command.Parameters.AddWithValue("@Pri4", pri4)
        Command.Parameters.AddWithValue("@pri5", pri5)
        Command.Parameters.AddWithValue("@Sec1", Sec1)
        Command.Parameters.AddWithValue("@Sec2", Sec2)
        Command.Parameters.AddWithValue("@Sec3", Sec3)
        Command.Parameters.AddWithValue("@Sec4", Sec4)
        Command.Parameters.AddWithValue("@Sec5", Sec5)
        Command.Parameters.AddWithValue("@Uni1", Uni1)
        Command.Parameters.AddWithValue("@Uni2", Uni2)
        Command.Parameters.AddWithValue("@Uni3", Uni3)
        Command.Parameters.AddWithValue("@Uni4", Uni4)
        Command.Parameters.AddWithValue("@Uni5", Uni5)
        Command.Parameters.AddWithValue("@Cer1", Cer1)
        Command.Parameters.AddWithValue("@Cer2", Cer2)
        Command.Parameters.AddWithValue("@Cer3", Cer3)
        Command.Parameters.AddWithValue("@Cer4", Cer4)
        Command.Parameters.AddWithValue("@Cer5", Cer5)
        Command.Parameters.AddWithValue("@Exp1", Exp1)
        Command.Parameters.AddWithValue("@Tel1", Tel1)
        Command.Parameters.AddWithValue("@Date1", Date1)
        Command.Parameters.AddWithValue("@Job1", Job1)
        Command.Parameters.AddWithValue("@Dut1", Dut1)
        Command.Parameters.AddWithValue("@Sal1", Sal1)
        Command.Parameters.AddWithValue("@Reason1", Reason1)
        Command.Parameters.AddWithValue("@Exp2", Exp2)
        Command.Parameters.AddWithValue("@Tel2", Tel2)
        Command.Parameters.AddWithValue("@Date2", Date2)
        Command.Parameters.AddWithValue("@Job2", Job2)
        Command.Parameters.AddWithValue("@Dut2", Dut2)
        Command.Parameters.AddWithValue("@Sal2", Sal2)
        Command.Parameters.AddWithValue("@Reason2", Reason2)
        Command.Parameters.AddWithValue("@Exp3", Exp3)
        Command.Parameters.AddWithValue("@Tel3", Tel3)
        Command.Parameters.AddWithValue("@Date3", Date3)
        Command.Parameters.AddWithValue("@job3", job3)
        Command.Parameters.AddWithValue("@Dut3", Dut3)
        Command.Parameters.AddWithValue("@Sal3", Sal3)
        Command.Parameters.AddWithValue("@Reason3", Reason3)
        Command.Parameters.AddWithValue("@Smoke", Smoke)
        Command.Parameters.AddWithValue("@NoCigar", NoCigar)
        Command.Parameters.AddWithValue("@Marwa", Marwa)
        Command.Parameters.AddWithValue("@Illness", Illness)
        Command.Parameters.AddWithValue("@Accident", Accident)
        Command.Parameters.AddWithValue("@Medi", Medi)
        Command.Parameters.AddWithValue("@Suffer", Suffer)
        Command.Parameters.AddWithValue("@Glass", Glass)
        Command.Parameters.AddWithValue("@Vision", Vision)
        Command.Parameters.AddWithValue("@Shift", Shift)
        Command.Parameters.AddWithValue("@Pregnant", Pregnant)
        Command.Parameters.AddWithValue("@Worki", Worki)
        Command.Parameters.AddWithValue("@Department", Department)
        Command.Parameters.AddWithValue("@Joind", Joind)
        Command.Parameters.AddWithValue("@Minisal", Minsal)
        Command.Parameters.AddWithValue("@Vacancies", Vacancies)
        Command.Parameters.AddWithValue("@Name1", Name1)
        Command.Parameters.AddWithValue("@Add2", add2)
        Command.Parameters.AddWithValue("@Telno2", Telno2)
        Command.Parameters.AddWithValue("@Relation", Relation)
        Command.Parameters.AddWithValue("@Lastdate", Lastdate)
        Command.Parameters.AddWithValue("@Signature", Signature)
        Command.Parameters.AddWithValue("@Pan1", Pan1)
        Command.Parameters.AddWithValue("@Id1", Id1)
        Command.Parameters.AddWithValue("@Empname1", Empname1)
        Command.Parameters.AddWithValue("@Hire1", Hire1)
        Command.Parameters.AddWithValue("@Pan2", Pan2)
        Command.Parameters.AddWithValue("@id2", id2)
        Command.Parameters.AddWithValue("@Empname2", Empname2)
        Command.Parameters.AddWithValue("@Hire2", Hire2)
        Command.Parameters.AddWithValue("@Pan3", Pan3)
        Command.Parameters.AddWithValue("@id3", id3)
        Command.Parameters.AddWithValue("@Empname3", Empname3)
        Command.Parameters.AddWithValue("@Hire3", Hire)


        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "tbl_Addmtbl")
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

            Session("UID_AP") = 0
            UID = Request.QueryString("UID")
            Session("UID_AP") = UID

            TmpDs = New DataSet
            TmpDs = CallSP("ById", UID, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", DateTime.Now, "", "", "", "", "", DateTime.Now, DateTime.Now, "", "", "", DateTime.Now, DateTime.Now, "", "", "", DateTime.Now, DateTime.Now, "", "", "", DateTime.Now, DateTime.Now, "", "", "", DateTime.Now, "", "", 0, "", "", "", "", "", "", 0, "", "", "", "", "", "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "", "", DateTime.Now, "", "", "", "", "", "", "", "", "", "", "", "", "")


            Dim Q1 As String
            Dim Q2 As String
            Dim Q13 As String
            Dim Q14 As String
            Dim Q15 As String
            Dim Q16 As String
            Dim Q17 As String
            Dim Q3 As String
            Dim Q18 As String
            Dim Q19 As String
            Dim Q20 As String
            Dim Q4 As String
            Dim Q5 As String
            Dim Q6 As String
            Dim Q21 As String
            Dim Q7 As String
            Dim Q8 As String
            Dim Q9 As String
            Dim Q22 As String
            Dim Q10 As String
            Dim Q11 As String
            Dim Q12 As String

            
            If TmpDs.Tables(0).Rows.Count >= 1 Then
                Txtpos.Text = TmpDs.Tables(0).Rows(0).Item("Post")
                Txtname.Text = TmpDs.Tables(0).Rows(0).Item("Name")
                Txtadd.Text = TmpDs.Tables(0).Rows(0).Item("Address")
                Txticno.Text = TmpDs.Tables(0).Rows(0).Item("Ic")
                Txttele.Text = TmpDs.Tables(0).Rows(0).Item("Telno")
                Q1 = TmpDs.Tables(0).Rows(0).Item("Sex")
                Txtage.Text = TmpDs.Tables(0).Rows(0).Item("Age")
                Txthwb.Text = TmpDs.Tables(0).Rows(0).Item("Hw")
                Q2 = TmpDs.Tables(0).Rows(0).Item("Nationality")
                DropDownList1.Text = TmpDs.Tables(0).Rows(0).Item("Religion")
                Txtintax.Text = TmpDs.Tables(0).Rows(0).Item("Itno")
                Q13 = TmpDs.Tables(0).Rows(0).Item("Race")
                Txtsosco.Text = TmpDs.Tables(0).Rows(0).Item("Sosco")
                Txtepf.Text = TmpDs.Tables(0).Rows(0).Item("Epf")
                Txtdist.Text = TmpDs.Tables(0).Rows(0).Item("Km")
                Q14 = TmpDs.Tables(0).Rows(0).Item("Trans")
                Q15 = TmpDs.Tables(0).Rows(0).Item("Lang")
                Txtdob.Text = TmpDs.Tables(0).Rows(0).Item("Dob")
                Txtpob.Text = TmpDs.Tables(0).Rows(0).Item("Pof")
                Q16 = TmpDs.Tables(0).Rows(0).Item("Uni")
                Q17 = TmpDs.Tables(0).Rows(0).Item("Mart")
                Txtedur1.Text = TmpDs.Tables(0).Rows(0).Item("Pri1")
                Txtedur2.Text = TmpDs.Tables(0).Rows(0).Item("Pri2")
                Txtedur3.Text = TmpDs.Tables(0).Rows(0).Item("Pri3")
                Txtedur4.Text = TmpDs.Tables(0).Rows(0).Item("Pri4")
                Txtr5.Text = TmpDs.Tables(0).Rows(0).Item("Pri5")
                Txtsec1.Text = TmpDs.Tables(0).Rows(0).Item("Sec1")
                Txtsec2.Text = TmpDs.Tables(0).Rows(0).Item("Sec2")
                Txtsec3.Text = TmpDs.Tables(0).Rows(0).Item("Sec3")
                Txtsec4.Text = TmpDs.Tables(0).Rows(0).Item("Sec4")
                Txtsec5.Text = TmpDs.Tables(0).Rows(0).Item("Sec5")
                Txtuni1.Text = TmpDs.Tables(0).Rows(0).Item("Uni1")
                Txtuni2.Text = TmpDs.Tables(0).Rows(0).Item("Uni2")
                Txtuni3.Text = TmpDs.Tables(0).Rows(0).Item("Uni3")
                Txtuni4.Text = TmpDs.Tables(0).Rows(0).Item("Uni4")
                Txtuni5.Text = TmpDs.Tables(0).Rows(0).Item("Uni5")
                Txtcer1.Text = TmpDs.Tables(0).Rows(0).Item("Cer1")
                Txtcer2.Text = TmpDs.Tables(0).Rows(0).Item("Cer2")
                Txtcer3.Text = TmpDs.Tables(0).Rows(0).Item("Cer3")
                Txtcer4.Text = TmpDs.Tables(0).Rows(0).Item("Cer4")
                Txtcer5.Text = TmpDs.Tables(0).Rows(0).Item("Cer4")
                Txtnama1.Text = TmpDs.Tables(0).Rows(0).Item("Exp1")
                Txttel1.Text = TmpDs.Tables(0).Rows(0).Item("Tel1")
                Txtdat1.Text = TmpDs.Tables(0).Rows(0).Item("Date1")
                Txtjob1.Text = TmpDs.Tables(0).Rows(0).Item("Job1")
                Txtdut1.Text = TmpDs.Tables(0).Rows(0).Item("Dut1")
                Txtsal1.Text = TmpDs.Tables(0).Rows(0).Item("Sal1")
                Txtleav1.Text = TmpDs.Tables(0).Rows(0).Item("Reason1")
                Txtnama2.Text = TmpDs.Tables(0).Rows(0).Item("Exp2")
                Txttel2.Text = TmpDs.Tables(0).Rows(0).Item("Tel2")
                Txtdat2.Text = TmpDs.Tables(0).Rows(0).Item("Date2")
                Txtjob2.Text = TmpDs.Tables(0).Rows(0).Item("Job2")
                Txtdut2.Text = TmpDs.Tables(0).Rows(0).Item("Dut2")
                Txtsal2.Text = TmpDs.Tables(0).Rows(0).Item("Sal2")
                Txtleav2.Text = TmpDs.Tables(0).Rows(0).Item("Reason2")
                Txtnama3.Text = TmpDs.Tables(0).Rows(0).Item("Exp3")
                Txttel3.Text = TmpDs.Tables(0).Rows(0).Item("Tel3")
                Txtdat3.Text = TmpDs.Tables(0).Rows(0).Item("Date3")
                Txtjob3.Text = TmpDs.Tables(0).Rows(0).Item("Job3")
                Txtdut3.Text = TmpDs.Tables(0).Rows(0).Item("Dut3")
                Txtsal3.Text = TmpDs.Tables(0).Rows(0).Item("Sal3")
                Txtleav3.Text = TmpDs.Tables(0).Rows(0).Item("Reason3")
                Q3 = TmpDs.Tables(0).Rows(0).Item("Smoke")
                Q18 = TmpDs.Tables(0).Rows(0).Item("NoCigar")
                Q19 = TmpDs.Tables(0).Rows(0).Item("Marwa")
                Q20 = TmpDs.Tables(0).Rows(0).Item("Illness")
                Q4 = TmpDs.Tables(0).Rows(0).Item("Accident")
                Q5 = TmpDs.Tables(0).Rows(0).Item("Medi")
                Txtilness.Text = TmpDs.Tables(0).Rows(0).Item("Suffer")
                Q6 = TmpDs.Tables(0).Rows(0).Item("Glass")
                Q21 = TmpDs.Tables(0).Rows(0).Item("Vision")
                Q7 = TmpDs.Tables(0).Rows(0).Item("Shift")
                Q8 = TmpDs.Tables(0).Rows(0).Item("Pregnant")
                Q9 = TmpDs.Tables(0).Rows(0).Item("Worki")
                Txtfriends.Text = TmpDs.Tables(0).Rows(0).Item("Department")
                Txtjoin.Text = TmpDs.Tables(0).Rows(0).Item("Joind")
                Txtsal.Text = TmpDs.Tables(0).Rows(0).Item("Minsal")
                Q22 = TmpDs.Tables(0).Rows(0).Item("Vacancies")
                Txtnames.Text = TmpDs.Tables(0).Rows(0).Item("Name1")
                Txtaddr.Text = TmpDs.Tables(0).Rows(0).Item("Add2")
                Txttelno.Text = TmpDs.Tables(0).Rows(0).Item("Telno2")
                Txtrelation.Text = TmpDs.Tables(0).Rows(0).Item("Relation")
                Txtdate.Text = TmpDs.Tables(0).Rows(0).Item("Lastdate")
                Txtsig.Text = TmpDs.Tables(0).Rows(0).Item("Signature")
                Txtpan1.Text = TmpDs.Tables(0).Rows(0).Item("Pan1")
                Txtempid1.Text = TmpDs.Tables(0).Rows(0).Item("Id1")
                Txtempname1.Text = TmpDs.Tables(0).Rows(0).Item("EmpName1")
                Q10 = TmpDs.Tables(0).Rows(0).Item("Hire1")
                Txtpan2.Text = TmpDs.Tables(0).Rows(0).Item("Pan2")
                Txtempid2.Text = TmpDs.Tables(0).Rows(0).Item("Id2")
                Txtempname2.Text = TmpDs.Tables(0).Rows(0).Item("Empname2")
                Q11 = TmpDs.Tables(0).Rows(0).Item("Hire2")
                Txtpan3.Text = TmpDs.Tables(0).Rows(0).Item("Pan3")
                Txtempid3.Text = TmpDs.Tables(0).Rows(0).Item("Id3")
                Txtempname3.Text = TmpDs.Tables(0).Rows(0).Item("Empname3")
                Q12 = TmpDs.Tables(0).Rows(0).Item("Hire")

                If Q1 = "Female" Then
                    rbdfmale.Checked = True
                Else
                    rbdmale.Checked = True
                End If

                If rbdmala.Checked = True Then
                    Q2 = "Malasiya"
                Else
                    Q2 = "Lain-Lain"
                End If

                If chkmalay.Checked = True Then
                    Q13 = "Malay"

                ElseIf chkindia.Checked = True Then
                    Q13 = "Indian"

                ElseIf chkchinese.Checked = True Then
                    Q13 = "chinese"


                ElseIf chkothers.Checked = True Then
                    Q13 = " Others Nyatakan "
                End If


                Dim Str1 As String()
                Str1 = Q14.Split(",")

                For Tmpi As Integer = 0 To Str1.Length - 1
                    If Str1(Tmpi) = 1 Then
                        chksendiri.Checked = True
                    End If

                    If Str1(Tmpi) = 2 Then
                        chksyarikat.Checked = True
                    End If

                    If Str1(Tmpi) = 3 Then
                        chkasrama.Checked = True
                    End If
                Next

                Dim Str2 As String()
                Str2 = Q15.Split(",")

                For Tmpi As Integer = 0 To Str2.Length - 1
                    If Str2(Tmpi) = 1 Then
                        chkmalayi.Checked = True
                    End If

                    If Str2(Tmpi) = 2 Then
                        chkenglish.Checked = True
                    End If

                    If Str2(Tmpi) = 3 Then
                        chktamil.Checked = True
                    End If

                    If Str2(Tmpi) = 3 Then
                        chkchines.Checked = True
                    End If
                Next

                Dim Str3 As String()
                Str3 = Q15.Split(",")

                For Tmpi As Integer = 0 To Str3.Length - 1
                    If Str3(Tmpi) = 1 Then
                        chktrousers.Checked = True
                    End If

                    If Str3(Tmpi) = 2 Then
                        chkshirt.Checked = True
                    End If

                    If Str3(Tmpi) = 3 Then
                        chkshoe.Checked = True
                    End If
                Next

                Dim Str6 As String()
                Str6 = Q16.Split(",")

                For Tmpi As Integer = 0 To Str6.Length - 1
                    If Str6(Tmpi) = 1 Then
                        chktrousers.Checked = True
                    End If

                    If Str6(Tmpi) = 2 Then
                        chkshirt.Checked = True
                    End If

                    If Str6(Tmpi) = 3 Then
                        chkshoe.Checked = True
                    End If
                Next

                If chksingle.Checked = True Then
                    Q17 = "Single"

                ElseIf chkmarried.Checked = True Then
                    Q17 = "Married"

                ElseIf chkdivourse.Checked = True Then
                    Q17 = "Divourse"
                End If

                If rbdsmoke.Checked = True Then
                    Q3 = "Yes"
                Else
                    Q3 = "no"
                End If

                If Chkcigar10.Checked = True Then
                    Q18 = "Less than 10"

                ElseIf Chkcigar20.Checked = True Then
                    Q18 = "Less than 20"

                ElseIf Chkcigar30.Checked = True Then
                    Q18 = "More than 20"
                End If

                If Chkless.Checked = True Then
                    Q19 = "Less than 10"

                ElseIf Chkwithin.Checked = True Then
                    Q19 = "More than 10"
                End If

                Dim Str4 As String()
                Str4 = Q20.Split(",")

                For Tmpi As Integer = 0 To Str4.Length - 1
                    If Str4(Tmpi) = 1 Then
                        Chkasma.Checked = True
                    End If

                    If Str4(Tmpi) = 2 Then
                        Chkback.Checked = True
                    End If

                    If Str4(Tmpi) = 3 Then
                        Chkallergy.Checked = True
                    End If
                    If Str4(Tmpi) = 4 Then
                        Chkmig.Checked = True
                    End If
                    If Str4(Tmpi) = 5 Then
                        Chkrabun.Checked = True
                    End If
                Next

                If Rbdexpyes.Checked = True Then
                    Q4 = "yes"
                Else
                    Q4 = "no"
                End If
                If Rbdmedyes.Checked = True Then
                    Q5 = "yes"
                Else
                    Q5 = "no"
                End If
                If Rbdglassyes.Checked = True Then
                    Q6 = "yes"
                Else
                    Q6 = "no"
                End If

                If Chknor.Checked = True Then
                    Q21 = "Normal"

                ElseIf Chknear.Checked = True Then
                    Q21 = "Near Sighted "

                ElseIf Chkfar.Checked = True Then
                    Q21 = Q21 + "Far Sighted"

                ElseIf Chkblind.Checked = True Then
                    Q21 = "color Blind"
                End If

                If Rbdagreeyes.Checked = True Then
                    Q7 = "yes"
                Else
                    Q7 = "no"
                End If
                If Rbdpregyes.Checked = True Then
                    Q8 = "yes"
                Else
                    Q8 = "no"
                End If
                If Rbdworkyes.Checked = True Then
                    Q9 = "yes"
                Else
                    Q9 = "no"
                End If

                Dim Str5 As String()
                Str5 = Q22.Split(",")

                For Tmpi As Integer = 0 To Str5.Length - 1
                    If Str5(Tmpi) = 1 Then
                        Chkad.Checked = True
                    End If

                    If Str5(Tmpi) = 2 Then
                        Chkbanner.Checked = True
                    End If

                    If Str5(Tmpi) = 3 Then
                        Chkfriend.Checked = True
                    End If
                    If Str5(Tmpi) = 4 Then
                        Chkposte.Checked = True
                    End If
                    If Str5(Tmpi) = 5 Then
                        Chkemp.Checked = True
                    End If
                    If Str5(Tmpi) = 6 Then
                        Chkemploy.Checked = True
                    End If
                    If Str5(Tmpi) = 7 Then
                        chkothers.Checked = True
                    End If
                Next

                If Rbdyes1.Checked = True Then
                    Q10 = "yes"
                Else
                    Q10 = "no"
                End If

                If Rbdyes2.Checked = True Then
                    Q11 = "yes"
                Else
                    Q11 = "no"

                End If

                If Rbdyes3.Checked = True Then
                    Q12 = "yes"
                Else
                    Q12 = "no"

                End If
            End If

        End If

    End Sub



    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TmpDs = New DataSet
        Dim Q1 As String
        Dim Q2 As String
        Dim Q3 As String
        Dim Q4 As String
        Dim Q5 As String
        Dim Q6 As String
        Dim Q7 As String
        Dim Q8 As String
        Dim Q9 As String
        Dim Q10 As String
        Dim Q11 As String
        Dim Q12 As String
        Dim Q13 As String
        Dim Q14 As String
        Dim Q15 As String
        Dim Q16 As String
        Dim Q17 As String
        Dim Q18 As String
        Dim Q19 As String
        Dim Q20 As String
        Dim Q21 As String
        Dim Q22 As String


        If rbdfmale.Checked = True Then
            Q1 = "Female"
        Else
            Q1 = "Male"
        End If
        If rbdmala.Checked = True Then
            Q2 = "Malasiya"
        Else
            Q2 = "Lain-Lain"
        End If
        If rbdsmoke.Checked = True Then
            Q3 = "Yes"
        Else
            Q3 = "no"
        End If
        If Rbdexpyes.Checked = True Then
            Q4 = "yes"
        Else
            Q4 = "no"
        End If
        If Rbdmedyes.Checked = True Then
            Q5 = "yes"
        Else
            Q5 = "no"
        End If
        If Rbdglassyes.Checked = True Then
            Q6 = "yes"
        Else
            Q6 = "no"

        End If
        If Rbdagreeyes.Checked = True Then
            Q7 = "yes"
        Else
            Q7 = "no"
        End If
        If Rbdpregyes.Checked = True Then
            Q8 = "yes"
        Else
            Q8 = "no"
        End If
        If Rbdworkyes.Checked = True Then
            Q9 = "yes"
        Else
            Q9 = "no"
        End If
        If Rbdyes1.Checked = True Then
            Q10 = "yes"
        Else
            Q10 = "no"

        End If
        If Rbdyes2.Checked = True Then
            Q11 = "yes"
        Else
            Q11 = "no"

        End If

        If Rbdyes3.Checked = True Then
            Q12 = "yes"
        Else
            Q12 = "no"

        End If

        If chkmalay.Checked = True Then
            Q13 = "Malay"

        ElseIf chkindia.Checked = True Then
            Q13 = "Indian"

        ElseIf chkchinese.Checked = True Then
            Q13 = "chinese"


        ElseIf chkothers.Checked = True Then
            Q13 = " Others Nyatakan "

        End If

        If chksendiri.Checked = True Then
            Q14 = "1,"

        End If

        If chksyarikat.Checked = True Then
            Q14 = Q14 + "2,"
        End If

        If chkasrama.Checked = True Then
            Q14 = Q14 + "3,"
        End If

        Q14 = Q14.TrimEnd(",")
        If chkmalayi.Checked = True Then
            Q15 = "1,"
        End If

        If chkenglish.Checked = True Then
            Q15 = Q15 + "2,"
        End If
        If chktamil.Checked = True Then
            Q15 = Q15 + "3,"
        End If
        If chkchines.Checked = True Then
            Q15 = Q15 + "4,"
        End If
        Q15 = Q15.TrimEnd(",")

        If chktrousers.Checked = True Then
            Q16 = "1,"
        End If
        If chkshirt.Checked = True Then
            Q16 = Q16 + "2,"
        End If
        If chkshoe.Checked = True Then
            Q16 = Q16 + "3,"
        End If
        Q16 = Q16.TrimEnd(",")
        If chksingle.Checked = True Then
            Q17 = "Single"

        ElseIf chkmarried.Checked = True Then
            Q17 = "Married"

        ElseIf chkdivourse.Checked = True Then
            Q17 = "Divourse"

        End If


        If Chkcigar10.Checked = True Then
            Q18 = "Less than 10"

        ElseIf Chkcigar20.Checked = True Then
            Q18 = "Less than 20"

        ElseIf Chkcigar30.Checked = True Then
            Q18 = "More than 20"
        End If

        If Chkless.Checked = True Then
            Q19 = "Less than 10"

        ElseIf Chkwithin.Checked = True Then
            Q19 = "More than 10"
        End If

        If Chkasma.Checked = True Then
            Q20 = "1,"
        End If

        If Chkback.Checked = True Then
            Q20 = Q20 + "2,"
        End If

        If Chkallergy.Checked = True Then
            Q20 = Q20 + "3,"
        End If

        If Chkmig.Checked = True Then
            Q20 = Q20 + "4,"
        End If

        If Chkrabun.Checked = True Then
            Q20 = Q20 + "5,"

        End If

        Q20 = Q20.TrimEnd(",")

        If Chknor.Checked = True Then
            Q21 = "Normal"

        ElseIf Chknear.Checked = True Then
            Q21 = "Near Sighted "

        ElseIf Chkfar.Checked = True Then
            Q21 = Q21 + "Far Sighted"

        ElseIf Chkblind.Checked = True Then
            Q21 = "color Blind"

        End If

        If Chkad.Checked = True Then
            Q22 = "1,"
        End If
        If Chkbanner.Checked = True Then
            Q22 = Q22 + "2,"
        End If
        If Chkfriend.Checked = True Then
            Q22 = Q22 + "3,"
        End If

        If Chkposte.Checked = True Then
            Q22 = Q22 + "4,"
        End If

        If Chkemp.Checked = True Then
            Q22 = Q22 + "5,"
        End If

        If Chkemploy.Checked = True Then
            Q22 = Q22 + "6,"
        End If

        If chkothers.Checked = True Then
            Q22 = Q22 + "7,"
        End If
        Q22 = Q22.TrimEnd(",")


        TmpDs = CallSP("Insert", Session("UID_AP"), Txtpos.Text, Txtname.Text, Txtadd.Text, Txticno.Text, Txttele.Text, Q1, Txtage.Text, Txthwb.Text, Q2, DropDownList1.Text, Txtintax.Text, Q13, Txtsosco.Text, Txtepf.Text, Txtdist.Text, Q14, Q15, DateTime.Now, Txtpob.Text, Q16, Q17, Txtedur1.Text, Txtedur2.Text, DateTime.Now, DateTime.Now, Txtr5.Text, Txtsec1.Text, Txtsec2.Text, DateTime.Now, DateTime.Now, Txtsec5.Text, Txtuni1.Text, Txtuni2.Text, DateTime.Now, DateTime.Now, Txtuni5.Text, Txtcer1.Text, Txtcer2.Text, DateTime.Now, DateTime.Now, Txtcer5.Text, Txtnama1.Text, Txttel1.Text, DateTime.Now, Txtjob1.Text, Txtdut1.Text, Txtsal1.Text, Txtleav1.Text, Txtnama2.Text, Txttel2.Text, DateTime.Now, Txtjob2.Text, Txtdut2.Text, Txtsal2.Text, Txtleav2.Text, Txtnama3.Text, Txttel3.Text, DateTime.Now, Txtjob3.Text, Txtdut3.Text, Txtsal3.Text, Txtleav3.Text, Q3, Q18, Q19, Q20, Q4, Q5, Txtilness.Text, Q6, Q21, Q7, Q8, Q9, Txtfriends.Text, DateTime.Now, Txtsal.Text, Q22, Txtnames.Text, Txtaddr.Text, Txttelno.Text, Txtrelation.Text, DateTime.Now, Txtsig.Text, Txtpan1.Text, Txtempid1.Text, Txtempname1.Text, Q10, Txtpan2.Text, Txtempid2.Text, Txtempname2.Text, Q11, Txtpan3.Text, Txtempid3.Text, Txtempname3.Text, Q12)

        Label85.ForeColor = Drawing.Color.Green
        Label85.Text = "Successfully Updated!"

        Label8.ForeColor = Drawing.Color.Green
        Label8.Text = "Successfully Updated!"


        Response.Redirect("DGViewApplnForm.aspx")
    End Sub
End Class