Imports System.Data.SqlClient

Partial Public Class DGViewApplnForm
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindGridData()
    End Sub

    Private Function BindGridData()
        TmpDs = New DataSet

        TmpDs = CallSP("ViewAll", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", DateTime.Now, "", "", "", "", "", DateTime.Now, DateTime.Now, "", "", "", DateTime.Now, DateTime.Now, "", "", "", DateTime.Now, DateTime.Now, "", "", "", DateTime.Now, DateTime.Now, "", "", "", DateTime.Now, "", "", 0, "", "", "", "", "", "", 0, "", "", "", "", "", "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "", "", DateTime.Now, "", "", "", "", "", "", "", "", "", "", "", "", "")
        DGApplnForm.DataSource = TmpDs.Tables(0)
        DGApplnForm.DataBind()
    End Function

End Class