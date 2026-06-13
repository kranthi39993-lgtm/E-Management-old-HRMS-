Imports System.Data.SqlClient
Imports E_Management.crmlognetglobal
Imports System.Web.Security
Partial Class Weightregistration
    Inherits Messagebox

    Dim MyGlobal As New emanagement.globalinfo
    Dim str1 As String = MyGlobal.ConCRMStr

    Dim con As New SqlConnection(str1)
    Dim cmd As New SqlCommand
    Dim mynet As New CRMlognetglobal
    Public dr As SqlDataReader
    Dim str3 As String

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load

        Session("userid") = Session("empcode")

        Response.AppendHeader("Refresh", (Session.Timeout * 40 + 60).ToString() + "; URL=../logout.aspx")
        Session("U_ID") = "first"
        Dim a As String
        If Not Page.IsPostBack Then
            Session("lo") = Now.Minute
        End If
        a = Session("lo") + 20
        Dim b As String
        If a = Now.Minute Or (Now.Minute - Session("lo")) > 20 Then
            Response.Redirect("../logout.aspx")
        End If
        If Not Page.IsPostBack Then
            '    Panel1.Visible = False
            '    Panel2.Visible = False
            '    Dim ob As New netglobal
            '    Dim conStr1
            '    ob.db_cn()
            '    conStr1 = sConnString.ToString()
            '    'txtpic.Text = sConnString
            '    Dim con1 As New SqlConnection(conStr1)
            '    con1.Open()
            '    'con.Open()
            '    Dim cmd2 As New SqlCommand("select * from department", con1)
            '    Dim dr2 As SqlDataReader
            '    dr2 = cmd2.ExecuteReader()
            '    ddldnam.Items.Insert(0, " - Select - ")
            '    Dropdownlist2.Items.Insert(0, " - Select - ")
            '    While (dr2.Read())
            '        ddldnam.Items.Add(dr2(1))
            '        Dropdownlist2.Items.Add(dr2(1))
            '    End While
            '    dr2.Close()
            '    Dim cmd3 As New SqlCommand("select * from PoDetail", con1)
            '    Dim dr3 As SqlDataReader
            '    dr3 = cmd3.ExecuteReader()
            '    ddlpnam.Items.Insert(0, " - Select - ")
            '    Dropdownlist1.Items.Insert(0, " - Select - ")
            '    While (dr3.Read())
            '        ddlpnam.Items.Add(dr3(2))
            '        Dropdownlist1.Items.Add(dr3(2))
            '    End While
            '    dr3.Close()

            '    Dim cmd1 As New SqlCommand("select * from custmaster", con1)
            '    Dim dr1 As SqlDataReader
            '    dr1 = cmd1.ExecuteReader()
            '    ddlcnam.Items.Insert(0, " - Select - ")
            '    While (dr1.Read())
            '        ddlcnam.Items.Add(dr1(1))
            '    End While
            '    dr1.Close()
            '    con1.Close()


            'con.Open()
            'If Not Page.IsPostBack Then
            '    'Loading the existing expenses
            '    Dim cmd1 As New SqlCommand("select * from HlpgDept", con)
            '    Dim dr1 As SqlDataReader
            '    dr1 = cmd1.ExecuteReader()
            '    DrpDwnLstDpt.Items.Insert(0, " - Select - ")
            '    While (dr1.Read())
            '        If Not IsDBNull(dr1("FG_Group")) Then
            '            str3 = dr1("Dept_Desc") & "[" & dr1("FG_Group") & "]"
            '            DrpDwnLstDpt.Items.Add(str3)
            '        End If
            '    End While
            '    dr1.Close()
            'End If
            'con.Close()


            AddDepartment()
        End If

    End Sub

    Private Sub AddDepartment()
        DrpDwnLstDpt.Items.Clear()
        mynet.db_cn()
        mynet.db_open()
        DrpDwnLstDpt.Items.Clear()
        DrpDwnLstDpt.Items.Add("Select Department")
        Dim dsQC, dsQCC As DataSet
        Dim dsOSC As DataSet
        Dim drQC, drQCC As DataRow

        Dim Obj1 As New CRMlognetglobal()
        Obj1.db_open()

        dsQCC = CRMlognetglobal.Open_hlpgdept(Obj1.dbConnWeb, Obj1.daConnWeb, 2, "SELECT dept_desc,fg_GROUP FROM HLPGDEPT where FG_Group<>''")
        If dsQCC.Tables("hlpgdept").Rows.Count > 0 Then
            For iW = 0 To dsQCC.Tables("hlpgdept").Rows.Count - 1
                drQCC = dsQCC.Tables("hlpgdept").Rows(iW)
                DrpDwnLstDpt.Items.Add(drQCC("dept_desc") & " [" & drQCC("FG_Group") & "]")
            Next
        End If
        mynet.db_close()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If DrpDwnLstDpt.Text = "Select Department" Then
            msg("Please Select Department Name")
            Exit Sub
        End If

        If (txtpic.Text = "" Or txtwt.Text = "") Then
            msg("Enter Valid  Number of Pieces and Weight")
            Exit Sub

        Else
            'Dim ob As New netglobal
            'Dim conStr1
            'ob.db_cn()
            'conStr1 = sConnString.ToString()
            'txtpic.Text = sConnString
            'Dim con1 As New SqlConnection(conStr1)
            con.Open()
            Dim str = Session("userid")
            Dim dept, s()
            s = Split(DrpDwnLstDpt.SelectedItem.Text, "[")
            dept = s(0)
            'Dim cmd As New SqlCommand("insert into whtinkgs (deptnam,prodnam,nopic,kgs) values(' " & ddldnam.SelectedItem.Text & " ',ltrim(rtrim(' " & ddlpnam.SelectedItem.Text.Trim & " '))," & txtpic.Text & "," & txtwt.Text & ")", con)
            Dim cmd As New SqlCommand("insert into Log_WtM3Registration (Department,prodcode,TotalPieces,Weight, M3, CreatedBy, CreatedDate) values('" & dept & " ',ltrim(rtrim(' " & ddlpnam.SelectedItem.Text.Trim & " '))," & txtpic.Text & "," & txtwt.Text & "," & txtM3.Text & ",'" & str & "','" & Now & "')", con)
            cmd.ExecuteNonQuery()
            msg("Record Inserted")
            con.Close()
            'ddldnam.Items.Clear()
            ddlpnam.Items.Clear()
            txtwt.Text = ""
            txtpic.Text = ""
            txtM3.Text = ""
            'con1.Open()
            'Dim cmd2 As New SqlCommand("select * from department", con1)
            'Dim dr2 As SqlDataReader
            'dr2 = cmd2.ExecuteReader()
            'ddldnam.Items.Insert(0, " - Select - ")
            'While (dr2.Read())
            '    ddldnam.Items.Add(dr2(1))
            'End While
            'dr2.Close()
            'Dim cmd3 As New SqlCommand("select * from PoDetail", con1)
            'Dim dr3 As SqlDataReader
            'dr3 = cmd3.ExecuteReader()
            'ddlpnam.Items.Insert(0, " - Select - ")
            'While (dr3.Read())
            '    ddlpnam.Items.Add(dr3(2))
            'End While
            'dr3.Close()
            'con1.Close()
        End If
    End Sub

    Private Sub DrpDwnLstDpt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpDwnLstDpt.SelectedIndexChanged
        If Not DrpDwnLstDpt.SelectedItem.Text = "Select Department" Then
            Dim DCs = InStr(DrpDwnLstDpt.SelectedItem.Text, "[", CompareMethod.Text)
            Dim DCe = InStr(DrpDwnLstDpt.SelectedItem.Text, "]", CompareMethod.Text)
            Dim Len = DCe - (DCs + 1)
            Dim DuCo = Trim(Mid(DrpDwnLstDpt.SelectedItem.Text, (DCs + 1), Len))
            Dim DuCs = Trim(Mid(DrpDwnLstDpt.SelectedItem.Text, 1, DCs - 1))
            Session("DepCode") = DuCo
            'Load the data for the first time
            'InitializeData()
            'BindGrid()
            mynet.db_cn()
            mynet.db_open()
            Dim dsQC, dsQCC As DataSet
            Dim dsOSC As DataSet
            Dim drQC, drQCC As DataRow
            ddlpnam.Items.Clear()
            dsQCC = mynet.Open_Productmaster(mynet.dbConnWeb, mynet.daConnWeb, 2, "SELECT Distinct FG_DESC FROM productmaster WHERE FG_GROUP = '" & Session("depCode") & "' order by fg_desc")
            If dsQCC.Tables("productmaster").Rows.Count > 0 Then
                For iW = 0 To dsQCC.Tables("productmaster").Rows.Count - 1
                    ddlpnam.Items.Add(dsQCC.Tables(0).Rows(iW).Item(0))
                Next
            End If
            mynet.db_close()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub

    Private Sub btnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub

   

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        'ddldnam.ClearSelection()
        ddlpnam.ClearSelection()
        txtpic.Text = ""
        txtwt.Text = ""
        txtM3.Text = ""
    End Sub
    'Private Sub Dropdownlist5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If (Dropdownlist5.SelectedIndex = 1) Then
    '        Panel2.Visible = False
    '        Panel1.Visible = True


    '    ElseIf (Dropdownlist5.SelectedIndex = 2) Then
    '        Panel1.Visible = False
    '        Panel2.Visible = True

    '    Else
    '        msg("select type of mode")
    '    End If
    'End Sub


    'Private Sub btnsubmit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim ob As New netglobal
    '    Dim conStr1
    '    ob.db_cn()
    '    conStr1 = sConnString.ToString()
    '    'txtpic.Text = sConnString
    '    Dim con1 As New SqlConnection(conStr1)
    '    If (txtplt.Text = "") Then
    '        msg("Enter the Volume")
    '    End If
    '    If (txtqty.Text = "") Then
    '        msg("Enter the Quantity ")
    '    End If
    '    con.Open()
    '    Dim cmd As New SqlCommand("insert into whtinvolume (cusnam,depname,prodnam,quantity,palvol)values(' " & ddlcnam.SelectedItem.Text & "',' " & Dropdownlist2.SelectedItem.Text & " ',' " & Dropdownlist1.SelectedItem.Text & " '," & txtqty.Text & "," & txtplt.Text & ")", con)
    '    cmd.ExecuteNonQuery()
    '    msg("Record Inserted")
    '    ddlcnam.Items.Clear()
    '    Dropdownlist2.Items.Clear()
    '    Dropdownlist1.Items.Clear()
    '    txtqty.Text = ""
    '    txtplt.Text = ""
    '    con.Close()
    '    con1.Open()
    '    Dim cmd1 As New SqlCommand("select * from custmaster", con1)
    '    Dim dr1 As SqlDataReader
    '    dr1 = cmd1.ExecuteReader()
    '    ddlcnam.Items.Insert(0, " - Select - ")
    '    While (dr1.Read())
    '        ddlcnam.Items.Add(dr1(1))
    '    End While
    '    dr1.Close()
    '    Dim cmd2 As New SqlCommand("select * from department", con1)
    '    Dim dr2 As SqlDataReader
    '    dr2 = cmd2.ExecuteReader()
    '    Dropdownlist2.Items.Insert(0, " - Select - ")
    '    While (dr2.Read())
    '        Dropdownlist2.Items.Add(dr2(1))
    '    End While
    '    dr2.Close()
    '    Dim cmd3 As New SqlCommand("select * from PoDetail", con1)
    '    Dim dr3 As SqlDataReader
    '    dr3 = cmd3.ExecuteReader()
    '    Dropdownlist1.Items.Insert(0, " - Select - ")
    '    While (dr3.Read())
    '        Dropdownlist1.Items.Add(dr3(2))
    '    End While
    '    dr3.Close()
    '    con1.Close()
    'End Sub

    'Private Sub btnclr1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim ob As New netglobal
    '    Dim conStr1
    '    ob.db_cn()
    '    conStr1 = sConnString.ToString()
    '    'txtpic.Text = sConnString
    '    Dim con1 As New SqlConnection(conStr1)
    '    con1.Open()
    '    ddlcnam.Items.Clear()
    '    Dropdownlist2.Items.Clear()
    '    Dropdownlist1.Items.Clear()
    '    txtplt.Text = ""
    '    txtqty.Text = ""
    '    Dim cmd1 As New SqlCommand("select * from custmaster", con1)
    '    Dim dr1 As SqlDataReader
    '    dr1 = cmd1.ExecuteReader()
    '    ddlcnam.Items.Insert(0, " - Select - ")
    '    While (dr1.Read())
    '        ddlcnam.Items.Add(dr1(1))
    '    End While
    '    dr1.Close()
    '    Dim cmd2 As New SqlCommand("select * from department", con1)
    '    Dim dr2 As SqlDataReader
    '    dr2 = cmd2.ExecuteReader()
    '    Dropdownlist2.Items.Insert(0, " - Select - ")
    '    While (dr2.Read())
    '        Dropdownlist2.Items.Add(dr2(1))
    '    End While
    '    dr2.Close()
    '    Dim cmd3 As New SqlCommand("select * from PoDetail", con1)
    '    Dim dr3 As SqlDataReader
    '    dr3 = cmd3.ExecuteReader()
    '    Dropdownlist1.Items.Insert(0, " - Select - ")
    '    While (dr3.Read())
    '        Dropdownlist1.Items.Add(dr3(2))
    '    End While
    '    dr3.Close()
    '    con1.Close()
    'End Sub


End Class