Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Drawing.Image
Imports System.IO.Stream
Imports System.Collections
Imports System.ComponentModel
'Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports netglobal
Imports E_Management.crmlognetglobal
'Imports TallComponents.PDF
Imports System.Web.Security
Partial Class MaruwaUploadingBillView
    'Inherits System.Web.UI.Page
    Inherits Messagebox

    Dim MyGlobal As New emanagement.globalinfo
    Dim str As String = MyGlobal.ConCRMStr

    Dim con As New SqlConnection(str)

    Dim mynet As New E_Management.CRMlognetglobal()



    Dim con1 As New SqlConnection(mynet.sConnString4)
    Dim NwConStr As String = mynet.sConnString4




    Dim cmd As New SqlCommand
    Public Shared emp As Boolean
    'Protected WithEvents ltlAlert As System.Web.UI.WebControls.Literal
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
        'Put user code to initialize the page here
        Session("UserId") = Session("empcode")
        Response.AppendHeader("Refresh", (Session.Timeout * 19 + 60).ToString() + "; URL=../logout.aspx")
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
        If IsPostBack() = False Then
            Dropdownlist1.Items.Insert(0, "--Select--")
            ddlAirname.Items.Insert(0, "--Select--")
            con.Open()
            Dim Query
            Dim str As String = Session("UserId")
            Dim cmd1 As New SqlCommand("Select EmpCustCode, emp from users where EmpCustCode='" & str & "'", con)
            'Dim cmd1 As New SqlCommand("Select F_Id from log_forwardersMaster where U_Id='" & str & "'", con)
            'Dim cmd As New SqlCommand("Select invno from log_invoice ", con)
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader
            While dr1.Read
                Session("forwaid") = (dr1(0))
                'emp=false
                emp = True
                '                lblTitle.Text = "View Bill Of Ladding"
                'Query = "Select invno from log_MaruwaInvoice where F_Id='" & Session("forwaid") & "' Order By InvNo Desc"

                Query = "Select Distinct invno from Log_CustomerBillUploading"

                If Not IsDBNull(dr1(1)) Then
                    emp = True
                    Query = "Select Distinct invno from Log_CustomerBillUploading"
                    '                   lblTitle.Text = "View Customer Supportive Documents"
                End If
            End While
            dr1.Close()
            'Dim s
            's = Session("forwaid")
            Try
                mynet.db_cn()
                NwConStr = mynet.sConnString4
                con1 = New SqlConnection(NwConStr)
                con1.Open()
                ddlAirname.Items.Clear()
                ddlAirname.Items.Add("-Select-")
                Dim cmd As New SqlCommand(Query, con1)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                While dr.Read
                    ddlAirname.Items.Add(dr(0))
                End While
                dr.Close()
            Catch ex As Exception

            End Try

            con.Close()
            con1.Close()
        End If
    End Sub

    Private Sub ddlAirname_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlAirname.SelectedIndexChanged
        Button1.Enabled = True
        If ddlAirname.SelectedIndex = 0 Then
            Button1.Enabled = False
        End If

        'If con.State = ConnectionState.Closed Then con.Open()
        ''Dim cmd2 As New SqlCommand("select a.F_name,b.invdate,c.customer,c.address1,c.address2,c.address3,c.address4,b.distination,b.deliverydate from forwardersmaster a,invoice b ,custmaster c where a.f_id=b.f_id and b.cust_id=c.cust_id and b.invno=replace('" & ddlAirname.SelectedItem.Text & "',' ','') ", con)
        ''Dim cmd2 As New SqlCommand
        ''("select a.F_name,b.invdate,c.customer,c.address1,c.address2,c.address3,c.address4,b.destination,
        ''b.deliverydate from Log_forwardersmaster a,log_invoice b ,custmaster c where a.f_id=b.f_id and b.cust_id=c.cust_id and b.invno=replace('" & ddlAirname.SelectedItem.Text & "',' ','') ", con)
        'Dim cmd2 As New SqlCommand("select a.F_name,d.invdate,c.customer,c.address1,c.address2,c.address3,c.address4,b.destination,b.SCdate from Log_forwardersmaster a,log_MaruwaInvoice b ,custmaster c, InvMaster d where a.f_id=b.f_id and b.cust_id=c.cust_id and b.InvNo=d.InvNo and b.invno=replace('" & ddlAirname.SelectedItem.Text & "',' ','') ", con)
        'Dim dr2 As SqlDataReader
        'dr2 = cmd2.ExecuteReader
        'While dr2.Read
        '    txtfnam.Text = dr2(0)
        '    txt_indate.Text = dr2(1)
        '    txt_custname.Text = dr2(2)
        '    Dim add1 As String = dr2(3)
        '    Dim add2 As String = dr2(4)
        '    Dim add3 As String = dr2(5)
        '    Dim add4 As String = dr2(6)
        '    txt_des.Text = dr2(7)
        '    txt_sch.Text = dr2(8)
        '    txt_custadd1.Text = add1 & "," & add2 & "," & add3 & "," & add4
        'End While
        'dr2.Close()

        con.Open()
        Dim cmd As New SqlCommand("Select b.invdate from InvMaster b where b.InvNo= replace('" & ddlAirname.Text & "',' ','')", con)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader
        Dim invdate As Date
        While dr.Read()
            invdate = dr(0)
            txt_indate.Text = invdate
            txt_sch.Text = invdate
        End While
        dr.Close()
        Dim x1, x2, x3, x4, x5, x6, x7 As String
        'Dim cmd2 As New SqlCommand("select a.customer,a.address1,a.address2,a.address3,a.address4,b.destination,b.deliverydate  from custmaster a,log_invoice b  where a.cust_id=b.cust_id and  b.invno=replace(' " & DropDownList1.SelectedItem.Text & " ',' ','') ", con)
        'Dim cmd2 As New SqlCommand("select a.customer,a.address1,a.address2,a.address3,a.address4,b.destination,b.Scdate from custmaster a, InvMaster b where a.cust_id=b.Cust_id and b.invno=replace('" & TxtInvNo.Text & "',' ','')", con)


        Dim cmd2 As New SqlCommand("select a.customer,a.address1,a.address2,a.address3,a.address4,b.destination from custmaster a, InvMaster b where a.cust_id=b.Cust_id and b.invno=replace('" & ddlAirname.Text & "',' ','')", con)
        Dim dr1 As SqlDataReader
        dr1 = cmd2.ExecuteReader()
        Do While dr1.Read
            txt_custname.Text = dr1(0)
            Dim add1 As String = dr1(1)
            Dim add2 As String = dr1(2)
            Dim add3 As String = dr1(3)
            Dim add4 As String = dr1(4)
            txt_des.Text = dr1(5)
            'txt_sch.Text = dr1(6)
            txt_custadd1.Text = add1 & "," & add2 & "," & add3 & "," & add4
        Loop
        dr1.Close()
        con.Close()
 

        Dim Query1
        If emp Then
            Query1 = "Select DISTINCT MAX(ID) AS ID, ImageType, DocName from Log_CustomerBillUploading where invno='" & ddlAirname.SelectedItem.Text & "' GROUP BY IMAGETYPE, DOCNAME ORDER BY ID DESC" '"Select imagetype  from log_customerBillUploading where invno= '" & ddlAirname.SelectedItem.Text & "'"
        Else
            Query1 = "Select DISTINCT MAX(ID) AS ID, ImageType, DocName from Log_CustomerBillUploading where invno='" & ddlAirname.SelectedItem.Text & "' GROUP BY IMAGETYPE, DOCNAME ORDER BY ID DESC"
        End If


        mynet.db_cn()
        NwConStr = mynet.sConnString4
        con1 = New SqlConnection(NwConStr)
        con1.Open()
        cmd = New SqlCommand(Query1, con1)
        dr = cmd.ExecuteReader
        Dropdownlist1.Items.Clear()
        Dropdownlist1.Items.Insert(0, "--Select--")
        While dr.Read
            Dropdownlist1.Items.Add(dr(2) + "-" + dr(1))
            Button1.Enabled = True
        End While
        dr.Close()
        con1.Close()
        If Dropdownlist1.Items.Count = 0 Then Button1.Enabled = False
        If con.State = ConnectionState.Open Then con.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Dropdownlist1.Text = "--Select--" Then
            Exit Sub
        End If

        Dim Indx As Integer
        Indx = Dropdownlist1.Text.IndexOf("-")

        If ddlAirname.SelectedIndex = 0 Then
            Exit Sub
        End If
        '''View selected file
        con.Open()
        Dim CM As New SqlCommand
        Dim Tmp As New DataSet
        Dim Adp As New SqlDataAdapter
        CM = New SqlCommand("Select DISTINCT MAX(ID) from Log_CustomerBillUploading where invno= '" & ddlAirname.SelectedItem.Text & "' and  docname='" & Dropdownlist1.SelectedItem.Text.Substring(0, Indx) & "'", con)
        Tmp = New DataSet()
        Adp = New SqlDataAdapter(CM)
        Adp.Fill(Tmp, "IDNO")
        Dim IDNo1 As Integer

        If Tmp.Tables(0).Rows.Count >= 1 Then
            IDNo1 = Tmp.Tables(0).Rows(0).Item(0)
        End If


        Dim str As String
        Dim Query2
        If emp Then
            Query2 = "Select ImageType, BillImage  from Log_CustomerBillUploading where invno= '" & ddlAirname.SelectedItem.Text & "'   and docname='" & Dropdownlist1.SelectedItem.Text.Substring(0, Indx) & "' and ID=" & IDNo1 'Query2 = "Select imagetype, BillImage  from log_customerBillUploading where invno= '" & ddlAirname.SelectedItem.Text & "' and ImageType='" & Dropdownlist1.SelectedItem.Text & "'"
        Else
            'Query2 = "Select Imgtype, BillImage  from uploading where invno= '" & ddlAirname.SelectedItem.Text & "' and imgtype='" & Dropdownlist1.SelectedItem.Text & "'"
            Query2 = "Select ImageType, BillImage  from Log_CustomerBillUploading where invno= '" & ddlAirname.SelectedItem.Text & "' and  and docname='" & Dropdownlist1.SelectedItem.Text.Substring(0, Indx) & "' and ID=" & IDNo1
        End If

        mynet.db_cn()
        NwConStr = mynet.sConnString4
        con1 = New SqlConnection(NwConStr)
        con1.Open()

        Dim cmd As New SqlCommand(Query2, con1)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        If (dr.Read()) Then
            str = dr(0)
        End If

        'str = Dropdownlist1.SelectedItem.Text
        con.Close()
        If (UCase(str) = "JPG") Then
            jpg()
        ElseIf (UCase(str) = "PDF") Then
            pdf()
        Else
            'msg("No Bills")
        End If

        If (UCase(str) = "JPG1") Then
            jpg()
        ElseIf (LCase(str) = "pdf1") Then
            pdf()

        Else
            ' msg("No Bills")
        End If


        If (LCase(str) = "jpg2") Then
            jpg()
        ElseIf (LCase(str) = "pdf2") Then
            pdf()
        Else
            'msg("No Bills")
        End If


        If (LCase(str) = "jpg3") Then
            jpg()
        ElseIf (LCase(str) = "pdf3") Then
            pdf()
        Else
            'msg("No Bills")
        End If

        If (LCase(str) = "jpg4") Then
            jpg()
        ElseIf (LCase(str) = "pdf4") Then
            pdf()
        Else
            ' msg("No Bills")
        End If
        'con.Close()
        con1.Close()
    End Sub

    Public Sub jpg()
        '''OPEN JPG FILE
        Dim Indx As Integer
        Indx = Dropdownlist1.Text.IndexOf("-")

        mynet.db_cn()
        NwConStr = mynet.sConnString4
        con1 = New SqlConnection(NwConStr)
        con1.Open()

        Dim CM As New SqlCommand
        Dim Tmp As New DataSet
        Dim Adp As New SqlDataAdapter
        CM = New SqlCommand("Select DISTINCT MAX(ID) from Log_CustomerBillUploading where invno= '" & ddlAirname.SelectedItem.Text & "' and  docname='" & Dropdownlist1.SelectedItem.Text.Substring(0, Indx) & "'", con1)
        Tmp = New DataSet()
        Adp = New SqlDataAdapter(CM)
        Adp.Fill(Tmp, "IDNO")
        Dim IDNo1 As Integer

        If Tmp.Tables(0).Rows.Count >= 1 Then
            IDNo1 = Tmp.Tables(0).Rows(0).Item(0)
        End If




        Dim Query
        If emp Then
            Query = "Select BillImage from Log_CustomerBillUploading where invno= '" & ddlAirname.SelectedItem.Text & "'   and docname='" & Dropdownlist1.SelectedItem.Text.Substring(0, Indx) & "' and ID=" & IDNo1
        Else
            'Query = "Select BillImage from uploading where invno=ltrim(rtrim('" & ddlAirname.SelectedItem.Text.Trim & "')) and imgtype='" & Dropdownlist1.SelectedItem.Text & "'"
            Query = "Select BillImage from Log_CustomerBillUploading where invno= '" & ddlAirname.SelectedItem.Text & "'   and docname='" & Dropdownlist1.SelectedItem.Text.Substring(0, Indx) & "' and ID=" & IDNo1
        End If

       

        Dim myCommand As New SqlCommand(Query, con1)

        Try
            'myConnection.Open()
            con.Open()
            Dim myDataReader As SqlDataReader
            myDataReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection)

            Do While (myDataReader.Read())
                'Response.ContentType = myDataReader.Item("PersonImageType")
                Response.BinaryWrite(myDataReader.Item("BillImage"))
            Loop
            con.Close()
            ' myConnection.Close()
            Response.Write("Image successfully Retrieved!")
        Catch SQLexc As SqlException
            msg("Read Failed : " & SQLexc.ToString())
        End Try

        'Exit Sub
        '''''
        'Try
        '    'Dim da As New SqlDataAdapter("Select BillImage from uploading where invno='" & Dropdownlist1.SelectedItem.Text & "' ", con)
        '    Dim da As New SqlDataAdapter("Select BillImage from uploading where invno='" & ddlAirname.SelectedItem.Text & "' and imgtype='" & Dropdownlist1.SelectedItem.Text & "' ", con)
        '    Dim MyCB As SqlCommandBuilder = New SqlCommandBuilder(da)
        '    Dim ds As New DataSet

        '    con.Open()
        '    da.Fill(ds, "ds1")
        '    Dim myrow As DataRow
        '    myrow = ds.Tables("ds1").Rows(0)

        '    Dim mydata() As Byte
        '    mydata = myrow("BillImage")
        '    Dim l As Long
        '    l = UBound(mydata)

        '    Dim fs1 As New FileStream("C:\image.pdf", FileMode.Create, FileAccess.Write)
        '    fs1.Write(mydata, 0, l)
        '    fs1.Close()
        '    Image1.Visible = True
        '    Image1.ImageUrl = "C:\image.pdf"

        '    fs1 = Nothing
        '    MyCB = Nothing
        '    ds = Nothing
        '    da = Nothing
        con.Close()
        con = Nothing
        con1.Close()
        'msg("Image Retrieved")
        'Catch ex As Exception
        '    msg(ex.Message)
        'End Try
    End Sub

    Public Sub pdf()
        Dim Indx As Integer
        Indx = Dropdownlist1.Text.IndexOf("-")

        '''OPEN PDF FILE
        Try


            con.Open()


            Dim CM As New SqlCommand
            Dim Tmp As New DataSet
            Dim Adp As New SqlDataAdapter
            CM = New SqlCommand("Select DISTINCT MAX(ID) from Log_CustomerBillUploading where invno= '" & ddlAirname.SelectedItem.Text & "' and  docname='" & Dropdownlist1.SelectedItem.Text.Substring(0, Indx) & "'", con)
            Tmp = New DataSet()
            Adp = New SqlDataAdapter(CM)
            Adp.Fill(Tmp, "IDNO")
            Dim IDNo1 As Integer

            If Tmp.Tables(0).Rows.Count >= 1 Then
                IDNo1 = Tmp.Tables(0).Rows(0).Item(0)
            End If




            Dim Query
            If emp Then
                Query = "Select BillImage from Log_CustomerBillUploading where invno= '" & ddlAirname.SelectedItem.Text & "'   and docname='" & Dropdownlist1.SelectedItem.Text.Substring(0, Indx) & "' and ID=" & IDNo1
            Else
                'Query = "Select BillImage from uploading where invno=ltrim(rtrim('" & ddlAirname.SelectedItem.Text.Trim & "')) and imgtype='" & Dropdownlist1.SelectedItem.Text & "'"
                Query = "Select BillImage from Log_CustomerBillUploading where invno= '" & ddlAirname.SelectedItem.Text & "'   and docname='" & Dropdownlist1.SelectedItem.Text.Substring(0, Indx) & "' and ID=" & IDNo1
            End If
            ''Dim da As New SqlDataAdapter("Select BillImage from uploading where invno=replace('" & ddlAirname.SelectedItem.Text.Trim & "',' ','') and imgtype='" & Dropdownlist1.SelectedItem.Text.Trim & "'", con)
            'Dim Query
            'If emp Then
            '    Query = "Select BillImage from Log_CustomerBillUploading where invno=ltrim(rtrim('" & ddlAirname.SelectedItem.Text.Trim & "')) and docname='" & Dropdownlist1.SelectedItem.Text.Substring(0, Indx) & "'" 'Query = "Select BillImage from Log_CustomerBillUploading where invno=ltrim(rtrim('" & ddlAirname.SelectedItem.Text.Trim & "')) and imagetype='" & Dropdownlist1.SelectedItem.Text & "'"
            'Else
            '    'Query = "Select BillImage from uploading where invno=ltrim(rtrim('" & ddlAirname.SelectedItem.Text.Trim & "')) and imgtype='" & Dropdownlist1.SelectedItem.Text & "'"
            '    Query = "Select BillImage from Log_CustomerBillUploading where invno=ltrim(rtrim('" & ddlAirname.SelectedItem.Text.Trim & "')) and docname='" & Dropdownlist1.SelectedItem.Text.Substring(0, Indx) & "'"
            'End If

            mynet.db_cn()
            NwConStr = mynet.sConnString4
            con1 = New SqlConnection(NwConStr)
            con1.Open()

            '"Select BillImage from uploading where invno=ltrim(rtrim('" & ddlAirname.SelectedItem.Text.Trim & "')) and imgtype='" & Dropdownlist1.SelectedItem.Text & "'"
            Dim da As New SqlDataAdapter(Query, con1)
            Dim MyCB As SqlCommandBuilder = New SqlCommandBuilder(da)
            Dim ds As New DataSet
            da.Fill(ds, "uploading")
            Dim myrow As DataRow
            myrow = ds.Tables("uploading").Rows(0)
            Dim mydata() As Byte
            mydata = myrow("BillImage")
            Dim l As Long
            l = UBound(mydata)
            'Have to change to Virtual Directory Path..
            Dim srvpath = Server.MapPath(".")
            Dim fs1 As New FileStream(srvpath & "\" & Session("UserId") & ".pdf", FileMode.Create, FileAccess.ReadWrite)
            'Dim fs1 As New FileStream("C:\Inetpub\wwwroot\mmCRM\Logistics\image.pdf", FileMode.Create, FileAccess.ReadWrite)
            fs1.Write(mydata, 0, l)
            fs1.Close()
            fs1 = Nothing
            con.Close()
            con = Nothing
            Response.Redirect(Session("UserId") & ".pdf")
            'Dim fs2 As New FileStream("C:\Inetpub\wwwroot\mmCRM\Logistics\image.pdf", FileMode.Open, FileAccess.Read)
            ''<a href ="C:\Inetpub\wwwroot\mmCRM\Logistics\image.pdf" >click to get PDF</a>
            'Dim document As New Document(New BinaryReader(fs2))
            'Response.ContentType = "application/pdf"
            'ds = Nothing
            'fs2.Close()
            ' msg("Image Retrieved")
        Catch ex As Exception
            msg(ex.Message)
            txt_custadd1.Text = ex.Message
        Finally
            'Response.End()
            con1.Close()
        End Try
    End Sub

    
    Protected Sub Dropdownlist1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dropdownlist1.SelectedIndexChanged

    End Sub

  
    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub
End Class
