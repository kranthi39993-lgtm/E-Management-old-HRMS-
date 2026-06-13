Imports System.Data.SqlClient

Partial Public Class DGViewCalculation
    Inherits System.Web.UI.Page
    Dim TmpDs As New DataSet

    'Dim constr As String = "Data Source=Techfics2\Techfics;Initial Catalog=hrmis;uid=sa;password=TechficsPro"
    Dim constr As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"

    Function CallSP(ByVal Options As String, ByVal Uid As Integer, ByVal Name As String, ByVal ICNo As String, ByVal OnDate As Date, ByVal QuestionNo1 As Double, ByVal QuestionNo2 As Double, ByVal QuestionNo3 As Double, ByVal QuestionNo4 As Double, ByVal QuestionNo5 As Double, ByVal QuestionNo6 As Double, ByVal QuestionNo7 As Double, ByVal QuestionNo8 As Double, ByVal QuestionNo9 As Double, ByVal QuestionNo10 As Double, ByVal QuestionNo11 As Double, ByVal QuestionNo12 As Double, ByVal QuestionNo13 As Double, ByVal QuestionNo14 As Double, ByVal QuestionNo15 As Double, ByVal QuestionNo16 As Double, ByVal QuestionNo17 As Double, ByVal QuestionNo18 As Double, ByVal QuestionNo19 As Double, ByVal QuestionNo20 As Double, ByVal QuestionNo21 As Double, ByVal QuestionNo22 As Double, ByVal QuestionNo23 As Double, ByVal QuestionNo24a As Double, ByVal QuestionNo24b As Double, ByVal CreatedOn As Date, ByVal Timetaken As Date, ByVal TimeRemarks As String, ByVal QNo1result As Integer, ByVal QNo2result As Integer, ByVal QNo3result As Integer, ByVal QNo4result As Integer, ByVal QNo5result As Integer, ByVal QNo6result As Integer, ByVal QNo7result As Integer, ByVal QNo8result As Integer, ByVal QNo9result As Integer, ByVal QNo10result As Integer, ByVal QNo11result As Integer, ByVal QNo12result As Integer, ByVal QNo13result As Integer, ByVal QNo14result As Integer, ByVal QNo15result As Integer, ByVal QNo16result As Integer, ByVal QNo17result As Integer, ByVal QNo18result As Integer, ByVal QNo19result As Integer, ByVal QNo20result As Integer, ByVal QNo21result As Integer, ByVal QNo22result As Integer, ByVal QNo23result As Integer, ByVal QNo24aresult As Integer, ByVal QNo24bresult As Integer, ByVal MathResult As Integer, ByVal ProblemResult As Integer, ByVal TotalScore As Integer) As DataSet
        '   MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("FormA_SP", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@Option", Options)
        Command.Parameters.AddWithValue("@Uid", Uid)
        Command.Parameters.AddWithValue("@Name", Name)
        Command.Parameters.AddWithValue("@ICNo", ICNo)
        Command.Parameters.AddWithValue("@Date", OnDate)
        Command.Parameters.AddWithValue("@QNo1", QuestionNo1)
        Command.Parameters.AddWithValue("@QNo2", QuestionNo2)
        Command.Parameters.AddWithValue("@QNo3", QuestionNo3)
        Command.Parameters.AddWithValue("@QNo4", QuestionNo4)
        Command.Parameters.AddWithValue("@QNo5", QuestionNo5)
        Command.Parameters.AddWithValue("@QNo6", QuestionNo6)
        Command.Parameters.AddWithValue("@QNo7", QuestionNo7)
        Command.Parameters.AddWithValue("@QNo8", QuestionNo8)
        Command.Parameters.AddWithValue("@QNo9", QuestionNo9)
        Command.Parameters.AddWithValue("@QNo10", QuestionNo10)
        Command.Parameters.AddWithValue("@QNo11", QuestionNo11)
        Command.Parameters.AddWithValue("@QNo12", QuestionNo12)
        Command.Parameters.AddWithValue("@QNo13", QuestionNo13)
        Command.Parameters.AddWithValue("@QNo14", QuestionNo14)
        Command.Parameters.AddWithValue("@QNo15", QuestionNo15)
        Command.Parameters.AddWithValue("@QNo16", QuestionNo16)
        Command.Parameters.AddWithValue("@QNo17", QuestionNo17)
        Command.Parameters.AddWithValue("@QNo18", QuestionNo18)
        Command.Parameters.AddWithValue("@QNo19", QuestionNo19)
        Command.Parameters.AddWithValue("@QNo20", QuestionNo20)
        Command.Parameters.AddWithValue("@QNo21", QuestionNo21)
        Command.Parameters.AddWithValue("@QNo22", QuestionNo22)
        Command.Parameters.AddWithValue("@QNo23", QuestionNo23)
        Command.Parameters.AddWithValue("@QNo24a", QuestionNo24a)
        Command.Parameters.AddWithValue("@QNo24b", QuestionNo24b)
        Command.Parameters.AddWithValue("@CreatedOn", CreatedOn)
        Command.Parameters.AddWithValue("@Timetaken", Timetaken)
        Command.Parameters.AddWithValue("@TimeRemarks", TimeRemarks)
        Command.Parameters.AddWithValue("@QNo1Result", QNo1result)
        Command.Parameters.AddWithValue("@QNo2Result", QNo2result)
        Command.Parameters.AddWithValue("@QNo3Result", QNo3result)
        Command.Parameters.AddWithValue("@QNo4Result", QNo4result)
        Command.Parameters.AddWithValue("@QNo5Result", QNo5result)
        Command.Parameters.AddWithValue("@QNo6Result", QNo6result)
        Command.Parameters.AddWithValue("@QNo7Result", QNo7result)
        Command.Parameters.AddWithValue("@QNo8Result", QNo8result)
        Command.Parameters.AddWithValue("@QNo9Result", QNo9result)
        Command.Parameters.AddWithValue("@QNo10Result", QNo10result)
        Command.Parameters.AddWithValue("@QNo11Result", QNo11result)
        Command.Parameters.AddWithValue("@QNo12Result", QNo12result)
        Command.Parameters.AddWithValue("@QNo13Result", QNo13result)
        Command.Parameters.AddWithValue("@QNo14Result", QNo14result)
        Command.Parameters.AddWithValue("@QNo15Result", QNo15result)
        Command.Parameters.AddWithValue("@QNo16Result", QNo16result)
        Command.Parameters.AddWithValue("@QNo17Result", QNo17result)
        Command.Parameters.AddWithValue("@QNo18Result", QNo18result)
        Command.Parameters.AddWithValue("@QNo19Result", QNo19result)
        Command.Parameters.AddWithValue("@QNo20Result", QNo20result)
        Command.Parameters.AddWithValue("@QNo21Result", QNo21result)
        Command.Parameters.AddWithValue("@QNo22Result", QNo22result)
        Command.Parameters.AddWithValue("@QNo23Result", QNo23result)
        Command.Parameters.AddWithValue("@QNo24aResult", QNo24aresult)
        Command.Parameters.AddWithValue("@QNo24bResult", QNo24bresult)
        Command.Parameters.AddWithValue("@MathResult", MathResult)
        Command.Parameters.AddWithValue("@ProblemResult", ProblemResult)
        Command.Parameters.AddWithValue("@TotalScore", TotalScore)



        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "tbl_FormA")
        con.Close()
        Return ds
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindGridData()
    End Sub

    Private Function BindGridData()
        TmpDs = New DataSet
        TmpDs = CallSP("ViewAll", 0, "", "", DateTime.Now, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, DateTime.Now, DateTime.Now, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
        DGCalculation.DataSource = TmpDs.Tables(0)
        DGCalculation.DataBind()
    End Function
End Class