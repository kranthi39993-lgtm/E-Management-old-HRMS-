Imports System.Data.SqlClient

Partial Public Class CandidateReg
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

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'empcode.Text = 
        'empname.Text = Session("empname")

        Label5.Text = DateTime.Now.ToString("dd-MMM-yyyy")

        If Session("empcode") = "" Then
            Response.Redirect("http://maruwa.com.my/")
        End If

        If IsPostBack = False Then
            TmpDs = New DataSet
            TmpDs = CallSP("Position", 0, "", "", "", "", DateTime.Now, DateTime.Now, "", "", DateTime.Now, "", DateTime.Now, "", "")
            DropDownList1.DataSource = TmpDs.Tables(0)
            DropDownList1.DataTextField = "Designationname"
            DropDownList1.DataValueField = "Designationname"
            DropDownList1.DataBind()
            DropDownList1.Items.Insert(0, "-Select-")
        End If

        
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        TmpDs = New DataSet

        TmpDs = CallSP("Insert", 0, CandidateName.Text, icno.Text, ContactNo.Text, DropDownList1.Text, Date.Now, Date.Now, FileUpload1.PostedFile.FileName, FileUpload2.PostedFile.FileName, Date.Now, Session("empcode"), Date.Now, "", "")
        Label6.ForeColor = Drawing.Color.Green
        Label6.Text = "Successfully Inserted!"

        Label8.ForeColor = Drawing.Color.Green
        Label8.Text = "Successfully Inserted!"
    End Sub

    
End Class