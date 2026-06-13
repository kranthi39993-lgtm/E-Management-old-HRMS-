Imports System.Data.SqlClient

Partial Public Class DGViewCandidateReg
    Inherits System.Web.UI.Page


    Dim TmpDs As New DataSet

    'Dim constr As String = "Data Source=Techfics2\Techfics;Initial Catalog=hrmis;uid=sa;password=TechficsPro"
    Dim constr As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"

    Function CallSP(ByVal Options As String, ByVal Uid As Integer, ByVal CandidateName As String, ByVal ICNumber As String, ByVal ContactNumber As String, ByVal Position As String, ByVal AppliedOn As Date, ByVal ScheduledOn As Date, ByVal Resume1 As String, ByVal Certificate As String, ByVal CreatedOn As Date, ByVal CreatedBy As String, ByVal ModifiedOn As Date, ByVal ModifiedBy As String, ByVal Status As String) As DataSet
        '   MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("CandidateRegn_SP", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@Option", Options)
        Command.Parameters.AddWithValue("@Uid", Uid)
        Command.Parameters.AddWithValue("@CandName", CandidateName)
        Command.Parameters.AddWithValue("@ICNo", ICNumber)
        Command.Parameters.AddWithValue("@ContactNo", ContactNumber)
        Command.Parameters.AddWithValue("@Position", Position)
        Command.Parameters.AddWithValue("@AppliedOn", AppliedOn)
        Command.Parameters.AddWithValue("@SchOn", ScheduledOn)
        Command.Parameters.AddWithValue("@Resume", Resume1)
        Command.Parameters.AddWithValue("@Certificate", Certificate)
        Command.Parameters.AddWithValue("@CreatedOn", CreatedOn)
        Command.Parameters.AddWithValue("@CreatedBy", CreatedBy)
        Command.Parameters.AddWithValue("@ModifiedOn", ModifiedOn)
        Command.Parameters.AddWithValue("@ModifiedBy", ModifiedBy)
        Command.Parameters.AddWithValue("@Status", Status)

        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "tbl_Candidate")
        con.Close()
        Return ds
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        BindGridData()

    End Sub

    Private Function BindGridData()
        TmpDs = New DataSet
        TmpDs = CallSP("ViewAll", 0, "", "", "", "", DateTime.Now, DateTime.Now, "", "", DateTime.Now, "", DateTime.Now, "", "")
        DGCandidateReg.DataSource = TmpDs.Tables(0)
        DGCandidateReg.DataBind()
    End Function
   
End Class