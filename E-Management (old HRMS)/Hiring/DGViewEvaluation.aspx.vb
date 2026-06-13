Imports System.Data.SqlClient

Partial Public Class DGViewEvaluation
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


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindGridData()
    End Sub

    Private Function BindGridData()
        TmpDs = New DataSet
        TmpDs = CallSP("ViewAll", 0, "", "", DateTime.Now, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", DateTime.Now, DateTime.Now, "")
        DGEvaluation.DataSource = TmpDs.Tables(0)
        DGEvaluation.DataBind()
    End Function

End Class