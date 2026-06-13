Imports System.Data.SqlClient

Partial Public Class ApplicationForm
    Inherits System.Web.UI.Page
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

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TmpDs = New DataSet

        Dim Q1 As String = ""
        Dim Q2 As String = ""
        Dim Q13 As String = ""
        Dim Q14 As String = ""
        Dim Q15 As String = ""
        Dim Q16 As String = ""
        Dim Q17 As String = ""
        Dim Q3 As String = ""
        Dim Q18 As String = ""
        Dim Q19 As String = ""
        Dim Q20 As String = ""
        Dim Q4 As String = ""
        Dim Q5 As String = ""
        Dim Q6 As String = ""
        Dim Q21 As String = ""
        Dim Q7 As String = ""
        Dim Q8 As String = ""
        Dim Q9 As String = ""
        Dim Q22 As String = ""
        Dim Q10 As String = ""
        Dim Q11 As String = ""
        Dim Q12 As String = ""


        If rbdfmale.Checked = True Then
            Q1 = "Female"
        ElseIf rbdmale.Checked = True Then
            Q1 = "Male"
        Else
            MessageBox("Plesae select gender!")
            Exit Sub
        End If

        If rbdmala.Checked = True Then
            Q2 = "Malasiya"
        ElseIf rbdlain.Checked = True Then
            Q2 = "Lain-Lain"
        Else
            MessageBox("Please select nationality!")
            Exit Sub

        End If

        If chkmalay.Checked = True Then
            Q13 = "Malay"

        ElseIf chkindia.Checked = True Then
            Q13 = "Indian"

        ElseIf chkchinese.Checked = True Then
            Q13 = "chinese"

        ElseIf chkothers.Checked = True Then
            Q13 = " Others Nyatakan "
        Else
            MessageBox("Plesae select Race!")
            Exit Sub

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
        Else
            MessageBox("Plesae select Marital Status!")
            Exit Sub
        End If

        If rbdsmoke.Checked = True Then
            Q3 = "Yes"
        ElseIf rbdsmokeno.Checked = True Then
            Q3 = "no"
        Else
            MessageBox("Plesae select Smoker option!")
            Exit Sub
        End If

        If Chkcigar10.Checked = True Then
            Q18 = "Less than 10"

        ElseIf Chkcigar20.Checked = True Then
            Q18 = "Less than 20"

        ElseIf Chkcigar30.Checked = True Then
            Q18 = "More than 20"

        Else
            MessageBox("Plesae select Cigret Status!")
            Exit Sub
        End If

        If Chkless.Checked = True Then
            Q19 = "Less than 10"

        ElseIf Chkwithin.Checked = True Then
            Q19 = "More than 10"
        Else
            MessageBox("Plesae select Any Option!")
            Exit Sub
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


        
        If Rbdexpyes.Checked = True Then
            Q4 = "yes"
        ElseIf Rbdexpno.Checked = True Then
            Q4 = "no"
        Else
            MessageBox("Plesae select Experience!")
            Exit Sub
        End If

        If Rbdmedyes.Checked = True Then
            Q5 = "yes"
        ElseIf Rbdmedno.Checked = True Then
            Q5 = "no"
        Else
            MessageBox("Plesae select illness option!")
            Exit Sub
        End If

        If Rbdglassyes.Checked = True Then
            Q6 = "yes"
        ElseIf Rbdglassno.Checked = True Then
            Q6 = "no"
        Else
            MessageBox("Plesae select wearing glass!")
            Exit Sub
        End If

        If Chknor.Checked = True Then
            Q21 = "Normal"

        ElseIf Chknear.Checked = True Then
            Q21 = "Near Sighted "

        ElseIf Chkfar.Checked = True Then
            Q21 = Q21 + "Far Sighted"

        ElseIf Chkblind.Checked = True Then
            Q21 = "color Blind"
        Else
            MessageBox("Plesae select Vision Status!")
            Exit Sub
        End If

        If Rbdagreeyes.Checked = True Then
            Q7 = "yes"
        ElseIf Rbdagreeno.Checked = True Then
            Q7 = "no"
        Else
            MessageBox("Plesae select workshift!")
            Exit Sub
        End If

        
        If Rbdpregyes.Checked = True Then
            Q8 = "yes"
        ElseIf Rbdpregno.Checked = True Then
            Q8 = "no"
        Else
            MessageBox("Plesae select Pregnancy status!")
            Exit Sub
        End If

        If Rbdworkyes.Checked = True Then
            Q9 = "yes"
        ElseIf Rbdworkno.Checked = True Then
            Q9 = "no"
        Else
            MessageBox("Plesae select Work Status!")
            Exit Sub
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


        If Q14.Trim.Equals("") Then
            MessageBox("Please answer Preferred Transportation!")
            Exit Sub
        End If

        If Q15.Trim.Equals("") Then
            MessageBox("Please answer Language Spoken!")
            Exit Sub
        End If

        If Q16.Trim.Equals("") Then
            MessageBox("Please answer Uniform status!")
            Exit Sub
        End If

        If Q20.Trim.Equals("") Then
            MessageBox("Please answer any Illness!")
            Exit Sub
        End If

        If Q22.Trim.Equals("") Then
            MessageBox("Please answer to know the vacancy position!")
            Exit Sub
        End If

        TmpDs = CallSP("Insert", 0, Txtpos.Text, Txtname.Text, Txtadd.Text, Txticno.Text, Txttele.Text, Q1, Txtage.Text, Txthwb.Text, Q2, DropDownList1.Text, Txtintax.Text, Q13, Txtsosco.Text, Txtepf.Text, Txtdist.Text, Q14, Q15, DateTime.Now, Txtpob.Text, Q16, Q17, Txtedur1.Text, Txtedur2.Text, DateTime.Now, DateTime.Now, Txtr5.Text, Txtsec1.Text, Txtsec2.Text, DateTime.Now, DateTime.Now, Txtsec5.Text, Txtuni1.Text, Txtuni2.Text, DateTime.Now, DateTime.Now, Txtuni5.Text, Txtcer1.Text, Txtcer2.Text, DateTime.Now, DateTime.Now, Txtcer5.Text, Txtnama1.Text, Txttel1.Text, DateTime.Now, Txtjob1.Text, Txtdut1.Text, Txtsal1.Text, Txtleav1.Text, Txtnama2.Text, Txttel2.Text, DateTime.Now, Txtjob2.Text, Txtdut2.Text, Txtsal2.Text, Txtleav2.Text, Txtnama3.Text, Txttel3.Text, DateTime.Now, Txtjob3.Text, Txtdut3.Text, Txtsal3.Text, Txtleav3.Text, Q3, Q18, Q19, Q20, Q4, Q5, Txtilness.Text, Q6, Q21, Q7, Q8, Q9, Txtfriends.Text, DateTime.Now, Txtsal.Text, Q22, Txtnames.Text, Txtaddr.Text, Txttelno.Text, Txtrelation.Text, DateTime.Now, Txtsig.Text, Txtpan1.Text, Txtempid1.Text, Txtempname1.Text, Q10, Txtpan2.Text, Txtempid2.Text, Txtempname2.Text, Q11, Txtpan3.Text, Txtempid3.Text, Txtempname3.Text, Q12)

        Label85.ForeColor = Drawing.Color.Green
        Label85.Text = "Successfully Inserted!"

        Label8.ForeColor = Drawing.Color.Green
        Label8.Text = "Successfully Inserted!"



    End Sub
   
   
End Class