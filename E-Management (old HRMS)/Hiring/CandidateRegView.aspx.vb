Imports System.Data.SqlClient

Partial Public Class CandidateRegView
    Inherits System.Web.UI.Page

    Dim UID As Integer
    Dim TmpDs As New DataSet

    Dim constr As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"


    Function CallSP(ByVal Options As String, ByVal Uid As Integer, ByVal CandidateName As String, ByVal ICNumber As String, ByVal ContactNumber As String, ByVal Position As String, ByVal AppliedOn As Date, ByVal ScheduledOn As Date, ByVal Resume1 As String, ByVal Certificate As String, ByVal CreatedOn As Date, ByVal CreatedBy As String, ByVal ModifiedOn As Date, ByVal ModifiedBy As String, ByVal Status As String) As DataSet
        '   MyGlobal.Con_Str()

        CreatedBy = "-"
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
        If IsPostBack = False Then

            Session("UID_CR") = 0
            UID = Request.QueryString("UID")
            Session("UID_CR") = UID

            Dim TmpDs As New DataSet
            TmpDs = New DataSet
            TmpDs = New DataSet
            TmpDs = CallSP("Position", 0, "", "", "", "", DateTime.Now, DateTime.Now, "", "", DateTime.Now, "", DateTime.Now, "", "")
            DropDownList1.DataSource = TmpDs.Tables(0)
            DropDownList1.DataTextField = "Designationname"
            DropDownList1.DataValueField = "Designationname"
            DropDownList1.DataBind()
            DropDownList1.Items.Insert(0, "-Select-")


            TmpDs = New DataSet
            TmpDs = CallSP("ById", UID, "", "", "", "", DateTime.Now, DateTime.Now, "", "", DateTime.Now, "", DateTime.Now, "", "")

            If TmpDs.Tables(0).Rows.Count >= 1 Then
                CandidateName.Text = TmpDs.Tables(0).Rows(0).Item("CandidateName")
                icno.Text = TmpDs.Tables(0).Rows(0).Item("ICNumber")
                ContactNo.Text = TmpDs.Tables(0).Rows(0).Item("ContactNumber")
                DropDownList1.SelectedItem.Text = TmpDs.Tables(0).Rows(0).Item("Position")
                AppliedOn.Text = TmpDs.Tables(0).Rows(0).Item("AppliedOn").ToString()
                ScheduledOn.Text = TmpDs.Tables(0).Rows(0).Item("ScheduledOn").ToString()
            End If


        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TmpDs = New DataSet

        TmpDs = CallSP("Insert", Session("UID_CR"), CandidateName.Text, icno.Text, ContactNo.Text, DropDownList1.Text, Date.Now, Date.Now, FileUpload1.PostedFile.FileName, FileUpload2.PostedFile.FileName, Date.Now, Session("empcode"), Date.Now, "", "")
        Label6.ForeColor = Drawing.Color.Green
        Label6.Text = "Successfully Updated!"

        Label8.ForeColor = Drawing.Color.Green
        Label8.Text = "Successfully Updated!"

        Response.Redirect("DGViewCandidateReg.aspx")

    End Sub
End Class