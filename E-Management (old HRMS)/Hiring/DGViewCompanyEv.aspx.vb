Imports System.Data.SqlClient
Partial Public Class DGViewCompanyEv
    Inherits System.Web.UI.Page
    Dim TmpDs As New DataSet

    '    Dim constr As String = "Data Source=Techfics2\Techfics;Initial Catalog=hrmis;uid=sa;password=TechficsPro"
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
        BindGridData()
    End Sub

    Private Function BindGridData()
        TmpDs = New DataSet
        TmpDs = CallSP("ViewAll", 0, "", "", DateTime.Now, "", "", "", "", "", DateTime.Now, DateTime.Now, "")
        DGCompanyEv.DataSource = TmpDs.Tables(0)
        DGCompanyEv.DataBind()
    End Function

End Class