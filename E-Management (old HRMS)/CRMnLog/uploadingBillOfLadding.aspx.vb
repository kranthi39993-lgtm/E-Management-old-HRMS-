Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Image
Imports System.IO.Stream
Imports System.Collections
Imports System.ComponentModel
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports E_Management.crmlognetglobal
'Imports TallComponents.PDF
Imports System.Web.Security
Partial Class uploadingBillOfLadding
    'Inherits System.Web.UI.Page
    Inherits Messagebox

    Dim MyGlobal As New emanagement.globalinfo
    Dim str As String = MyGlobal.conCRMstr
    Dim mynet As New CRMlognetglobal
    Dim con As New SqlConnection(str)
    Dim con1 As New SqlConnection(mynet.sConnString)


    Dim con2 As New SqlConnection(mynet.sConnString4)

    Dim a As String

    Public Shared vpath1, imgtyp, pdftyp As String
    Public Shared sz1 As Integer
    Dim cmd As New SqlCommand
    Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator

    'Ravi
    ' Protected WithEvents ltlAlert As System.Web.UI.WebControls.Literal
    'Ravi

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

        Session("UserId") = Session("empcode")

        Response.AppendHeader("Refresh", (Session.Timeout * 40 + 60).ToString() + "; URL=../logout.aspx")
        Dim a As String
        If Not Page.IsPostBack Then
            Session("lo") = Now.Minute
        End If
        a = Session("lo") + 20
        Dim b As String
        If a = Now.Minute Or (Now.Minute - Session("lo")) > 20 Then
            Response.Redirect("../logout.aspx")
        End If


        Dim ob As New CRMlognetglobal()
        Dim conStr1 As String
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()
        If IsPostBack() = False Then
            

            DropDownList1.Items.Clear()
            DropDownList1.Items.Insert(0, "--Select--")
            'DropDownList1.Items.Insert(0, "--Select--")
            con.Open()
            Dim Query
            Dim str As String = Session("UserId")
            Dim cmd1 As New SqlCommand("Select EmpCustCode, emp from users where EmpCustCode='" & str & "'", con)
            'Dim cmd As New SqlCommand("Select invno from log_invoice ", con)
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader

            While dr1.Read
                Dim s = dr1(0)
                Session("forwaid") = dr1(0)
                'Query = "Select invno from log_MaruwaInvoice where F_Id='" & Session("forwaid") & "' Order By InvNo Desc"

                Query = "Select InvoiceNo from Log_ShippingDetails Order By InvoiceDate Desc"

                Panel1.Visible = False
                ' Panel2.Visible = True
                'lbltitle.Text = " Upload - Bills of Lading"
                If Not IsDBNull(dr1(1)) Then
                    'Dim s1 = dr1(1)
                    'If dr1(1) = 1 Then
                    'lbltitle.Text = "Customer Documents Uploading"
                    ' Panel1.Visible = True
                    Panel2.Visible = False
                    'Query = "Select invno from log_MaruwaInvoice"

                    Query = "Select Invoiceno from Log_ShippingDetails Order By InvoiceDate Desc"
                    'End If
                End If
            End While
            dr1.Close()

            'Dim cmd As New SqlCommand("Select invno from log_invoice where F_Id='" & Session("forwaid") & "'", con)

            Dim cmd As New SqlCommand(Query, con)
            'Dim cmd As New SqlCommand("Select invno from log_invoice ", con)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                DropDownList1.Items.Add(dr(0))
            End While
            dr.Close()

            

        End If

        If IsPostBack = False Then

            DropDownList2.Items.Clear()
            DropDownList2.Items.Insert(0, "--Select--")
            DropDownList2.Items.Add("Invoice")
            DropDownList2.Items.Add("Packing List")
            DropDownList2.Items.Add("K8 Custom Form")
            DropDownList2.Items.Add("Certificate of Origin(COC)")
            DropDownList2.Items.Add("AWB and BL")
            DropDownList2.Items.Add("Fumigation Certificate and Wooden Declaration")
            DropDownList2.Items.Add("Photos")
            DropDownList2.Items.Add("Forwarder Invoice")

        End If

        If IsPostBack = False Then
            AddDepartment()

            CmbHSCode.Items.Clear()
            CmbHSCode.Items.Add("-Select-")
            CmbHSCode.Items.Add("8546.90.000")
            CmbHSCode.Items.Add("6914.90.000")
            CmbHSCode.Items.Add("6914.90.0000")
        End If

        con.Close()
        con1.Close()
    End Sub

    Private Sub AddDepartment()
        CmbDept.Items.Clear()
        mynet.db_cn()
        mynet.db_open()
        CmbDept.Items.Clear()
        CmbDept.Items.Add("Select Department")
        Dim dsQC, dsQCC As DataSet
        Dim dsOSC As DataSet
        Dim drQC, drQCC As DataRow

        Dim Obj1 As New CRMlognetglobal()
        Obj1.db_open()

        dsQCC = CRMlognetglobal.Open_hlpgdept(Obj1.dbConnWeb, Obj1.daConnWeb, 2, "SELECT dept_desc,fg_GROUP FROM HLPGDEPT where FG_Group<>''")
        If dsQCC.Tables("hlpgdept").Rows.Count > 0 Then
            For iW = 0 To dsQCC.Tables("hlpgdept").Rows.Count - 1
                drQCC = dsQCC.Tables("hlpgdept").Rows(iW)
                CmbDept.Items.Add(drQCC("dept_desc") & " [" & drQCC("FG_Group") & "]")
            Next
        End If
        mynet.db_close()
    End Sub

    Private Sub btn_attach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_attach.Click

        '''''Attach File1
        If DropDownList1.SelectedItem.Text = "--Select--" Then
            msg("Please Select Invoice!")
            Exit Sub
        End If

        If txtCustomNo.Text = "" Then
            msg("Enter the CustomForm and then Try Again")
            setFocus(txtCustomNo)
            Exit Sub
        End If

        Dim strFileNameOnServer As String = File.PostedFile.FileName
        Dim extPosition As Integer = strFileNameOnServer.IndexOf(".")
        Dim ext As String = strFileNameOnServer.Substring(extPosition + 1, strFileNameOnServer.Length - extPosition - 1)
        Dim strBaseLocation As String = "F:\DailyDB\Bills\"
        Dim MyString, LastWord, lastword1 As String
        Dim MyLen As Integer
        MyString = ext
        LastWord = Microsoft.VisualBasic.Left(MyString, 3)
        If ext = "" Then
            msg("Please Select Valid File Type!")
            Exit Sub
        End If
        ''''''''''''''''''''''''''''''''
        If con.State = ConnectionState.Closed Then con.Open()
        Dim cmd As New SqlCommand("select invno from Log_CustomerBillUploading where invno='" & DropDownList1.SelectedItem.Text & "' ", con)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()

        If (dr.Read()) Then
            'msg("Already Files are Uploaded in this")
            msg("Already File Uploaded.. Please Remove the File and Attach again !")
            btn_remove1.Visible = True
            lbldel.Visible = True
            dr.Close()
        Else
            dr.Close()
            '''If file format is pdf
            If (LastWord = "pdf") Then
                Try
                    Dim da As New SqlDataAdapter("Select * from Log_CustomerBillUploading", con)
                    Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                    Dim ds As New DataSet
                    da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                    Dim vpath As String
                    vpath = File.PostedFile.FileName
                    Dim sz As Integer
                    sz = File.PostedFile.ContentLength
                    '''check size of the file 
                    If (sz <= 2204480) Then
                        Dim fs As New FileStream(vpath, FileMode.Open, FileAccess.Read)
                        Dim mydata(fs.Length) As Byte
                        fs.Read(mydata, 0, fs.Length)
                        fs.Close()
                        da.Fill(ds, "uploading")
                        Dim myrow As DataRow

                        myrow = ds.Tables("uploading").NewRow()
                        myrow("invno") = DropDownList1.SelectedItem.Text
                        myrow("invdate") = txtInvDate.Text
                        myrow("custnam") = txt_custname.Text
                        myrow("dest") = txt_des.Text
                        myrow("cadd1") = txt_custadd.Text
                        myrow("ddate") = txt_sch.Text
                        myrow("BillImage") = mydata
                        myrow("imgtype") = "pdf"
                        myrow("u_id") = Session("UserId")
                        myrow("createdby") = Session("UserId")
                        myrow("createddate") = Date.Now.ToShortDateString
                        myrow("BillType") = Form1.Text
                        ds.Tables("uploading").Rows.Add(myrow)
                        da.Update(ds, "uploading")
                        fs = Nothing
                        ds = Nothing
                        cb = Nothing
                        da = Nothing
                        con.Close()
                        con = Nothing
                        btn_attach.Enabled = False
                        lbl1.Text = "@" & strFileNameOnServer
                        msg("PDF File Uploaded")
                    Else
                        msg("File Size is too Large, Try to Reduce the File Size!")
                        Exit Sub
                    End If
                Catch ex As Exception
                    msg(ex.Message)
                    Exit Sub
                End Try
                '''If file format is jpg
            ElseIf (LastWord = "jpg" Or LastWord = "JPG") Then
                Try
                    Dim da As New SqlDataAdapter("Select * from Log_CustomerBillUploading", con)
                    Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                    Dim ds As New DataSet
                    da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                    Dim vpath As String
                    vpath = File.PostedFile.FileName
                    Dim sz As Integer
                    sz = File.PostedFile.ContentLength

                    If (sz <= 2204480) Then
                        Dim fs As New FileStream(vpath, FileMode.Open, FileAccess.Read)
                        Dim mydata(fs.Length) As Byte
                        fs.Read(mydata, 0, fs.Length)
                        fs.Close()
                        da.Fill(ds, "uploading")
                        Dim myrow As DataRow
                        myrow = ds.Tables("uploading").NewRow()
                        myrow("invno") = DropDownList1.SelectedItem.Text
                        myrow("invdate") = txtInvDate.Text
                        myrow("custnam") = txt_custname.Text
                        myrow("dest") = txt_des.Text
                        myrow("cadd1") = txt_custadd.Text
                        myrow("ddate") = txt_sch.Text
                        myrow("BillImage") = mydata
                        myrow("imgtype") = "jpg"
                        myrow("u_id") = Session("UserId")
                        myrow("createdby") = Session("UserId")
                        myrow("createddate") = Date.Now.ToShortDateString
                        myrow("BillType") = Form1.Text
                        ds.Tables("uploading").Rows.Add(myrow)
                        da.Update(ds, "uploading")
                        fs = Nothing
                        ds = Nothing
                        cb = Nothing
                        da = Nothing
                        con.Close()
                        con = Nothing
                        btn_attach.Enabled = False
                        lbl1.Text = "@" & strFileNameOnServer
                        msg("Image Uploaded")
                    Else
                        msg("File size is too large, Try to reduce the File Size!")
                        Exit Sub
                    End If
                Catch ex As Exception
                    msg(ex.Message & " Btn_Attach")
                    Exit Sub
                End Try
            Else
                msg("Invalid File Format, Select Jpg or PDF files Only!")
                Exit Sub
            End If


            Dim Str = "Update Uploading set CustomFormNo='" & txtCustomNo.Text.Trim & "' where invno='" & DropDownList1.SelectedItem.Text & "' and BillType='Custom Form'"
            If con1.State = ConnectionState.Closed Then con1.Open()
            Dim CmdUp As New SqlClient.SqlCommand(Str, con1)
            CmdUp.ExecuteNonQuery()
            If con1.State = ConnectionState.Open Then con1.Close()
            '<<<<<<<<<<<<<<28/12/2006>>>>>>>>>>>>>End 
        End If
        'End If
    End Sub

    Private Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Try
            clear()
            If DropDownList1.SelectedIndex = 0 Then
                Exit Sub
            End If
            Dim ob As New CRMlognetglobal
            Dim conStr1
            ob.db_cn()
            conStr1 = sConnString.ToString()
            'txtpic.Text = sConnString
            Dim con1 As New SqlConnection(conStr1)
            con1.Open()
            con.Open()
            TxtInvNo.Text = DropDownList1.SelectedItem.Text
            'Dim cmd As New SqlCommand("Select invdate from log_invoice  where invno= replace(' " & DropDownList1.SelectedItem.Text & " ',' ','')", con)
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("Select ProdCode from InvDetail where InvNo= replace('" & TxtInvNo.Text & "',' ','')", con)
            Dim TmpDs1 As New DataSet
            Dim TmpAd1 As New SqlDataAdapter
            TmpDs1 = New DataSet
            TmpAd1 = New SqlDataAdapter(cmd)
            TmpAd1.Fill(TmpDs1, "InvDetails")

            If Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("21") Then
                TxtDept.Text = "Substrate"
            ElseIf Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("31") Then
                TxtDept.Text = "Ceramic Valve"
            ElseIf Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("41") Or Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("42") Then
                TxtDept.Text = "Ferrite Magnet"
            ElseIf Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("71") Or Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("74") Then
                TxtDept.Text = "TPH"
            ElseIf Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("43") Then
                TxtDept.Text = "Ferrite Sheet"
            ElseIf Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("72") Then
                TxtDept.Text = "Media"
            ElseIf Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("73") Then
                TxtDept.Text = "Alumina Ball"
            ElseIf Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("61") Then
                TxtDept.Text = "Quartz"
            ElseIf Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("54") Then
                TxtDept.Text = "Inductor"
            ElseIf Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("11") Then
                TxtDept.Text = "Extrusion"
            ElseIf Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("51") Or Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("52") Or Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("53") Then
                TxtDept.Text = "Ferrite"
            ElseIf Left(TmpDs1.Tables(0).Rows(0).Item(0), 2).Equals("90") Then
                TxtDept.Text = "Administration"
            End If


            'DropDownList2.Items.Insert(0, "--Select--")
            'DropDownList2.Items.Add("")
            'DropDownList2.Items.Add("")
            'DropDownList2.Items.Add("")
            'DropDownList2.Items.Add("")
            'DropDownList2.Items.Add("")
            'DropDownList2.Items.Add("Fumigation Certificate and Wooden Declaration")
            'DropDownList2.Items.Add("")
            'DropDownList2.Items.Add("Forwarder Invoice")


            cmd = New SqlCommand("Select DocName, CustomFormNo, HSCode from Log_CustomerBillUploading where InvNo= replace('" & TxtInvNo.Text & "',' ','')", con)
            TmpDs1 = New DataSet
            TmpAd1 = New SqlDataAdapter(cmd)
            TmpAd1.Fill(TmpDs1, "InvDetails")


            Label1.BackColor = Color.White
            Label8.BackColor = Color.White
            Label2.BackColor = Color.White
            Label11.BackColor = Color.White
            Label3.BackColor = Color.White
            Label9.BackColor = Color.White
            Label10.BackColor = Color.White
            Label12.BackColor = Color.White


            Label1.ForeColor = Color.Black
            Label8.ForeColor = Color.Black
            Label2.ForeColor = Color.Black
            Label11.ForeColor = Color.Black
            Label3.ForeColor = Color.Black
            Label9.ForeColor = Color.Black
            Label10.ForeColor = Color.Black
            Label12.ForeColor = Color.Black


            If TmpDs1.Tables(0).Rows.Count >= 1 Then
                txtCustomNo.Text = TmpDs1.Tables(0).Rows(0).Item(1)
                TxtHSCode.Text = TmpDs1.Tables(0).Rows(0).Item(2)
            End If

            For TmpI1 As Integer = 0 To TmpDs1.Tables(0).Rows.Count - 1

                Dim Str As String = ""


                Str = TmpDs1.Tables(0).Rows(TmpI1).Item(0)

                If Str = "Invoice" Then
                    Label1.BackColor = Color.Green
                    Label1.ForeColor = Color.White

                ElseIf Str = "Packing List" Then
                    Label8.BackColor = Color.Green
                    Label8.ForeColor = Color.White

                ElseIf Str = "K8 Custom Form" Then
                    Label2.BackColor = Color.Green
                    Label2.ForeColor = Color.White

                ElseIf Str = "Certificate of Origin(COC)" Then
                    Label11.BackColor = Color.Green
                    Label11.ForeColor = Color.White

                ElseIf Str = "AWB and BL" Then
                    Label3.BackColor = Color.Green
                    Label3.ForeColor = Color.White

                ElseIf Str = "Fumigation Certificate and Wooden Declaration" Then
                    Label9.BackColor = Color.Green
                    Label9.ForeColor = Color.White

                ElseIf Str = "Photos" Then
                    Label10.BackColor = Color.Green
                    Label10.ForeColor = Color.White


                ElseIf Str = "Forwarder Invoice" Then
                    Label12.BackColor = Color.Green
                    Label12.ForeColor = Color.White
                End If
            Next


            

            cmd = New SqlCommand("Select b.invdate from InvMaster b where b.InvNo= replace('" & TxtInvNo.Text & "',' ','')", con)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            Dim invdate As Date
            While dr.Read()
                invdate = dr(0)
                txtInvDate.Text = invdate

                txt_sch.Text = invdate
            End While
            dr.Close()
            Dim x1, x2, x3, x4, x5, x6, x7 As String
            'Dim cmd2 As New SqlCommand("select a.customer,a.address1,a.address2,a.address3,a.address4,b.destination,b.deliverydate  from custmaster a,log_invoice b  where a.cust_id=b.cust_id and  b.invno=replace(' " & DropDownList1.SelectedItem.Text & " ',' ','') ", con)
            'Dim cmd2 As New SqlCommand("select a.customer,a.address1,a.address2,a.address3,a.address4,b.destination,b.Scdate from custmaster a, InvMaster b where a.cust_id=b.Cust_id and b.invno=replace('" & TxtInvNo.Text & "',' ','')", con)


            Dim cmd2 As New SqlCommand("select a.customer,a.address1,a.address2,a.address3,a.address4,b.destination, a.cust_id from custmaster a, InvMaster b where a.cust_id=b.Cust_id and b.invno=replace('" & TxtInvNo.Text & "',' ','')", con)
            Dim dr1 As SqlDataReader
            dr1 = cmd2.ExecuteReader()
            Do While dr1.Read
                txt_custname.Text = dr1(0)
                Dim add1 As String = dr1(1)
                Dim add2 As String = dr1(2)
                Dim add3 As String = dr1(3)
                Dim add4 As String = dr1(4)
                txt_des.Text = dr1(5)
                Session("custid") = dr1(6)

                'txt_sch.Text = dr1(6)
                txt_custadd.Text = add1 & "," & add2 & "," & add3 & "," & add4
            Loop
            dr1.Close()




            If Label1.BackColor = Color.Green And Label2.BackColor = Color.Green And Label3.BackColor = Color.Green Then
                Panel4.Visible = True

                cmd = New SqlCommand("Select Top 1 * From Log_COCSubmission Where InvoiceNo='" & TxtInvNo.Text & "' Order By UID Desc", con)
                TmpDs1 = New DataSet
                TmpAd1 = New SqlDataAdapter(cmd)
                TmpAd1.Fill(TmpDs1, "Tmp")

                If TmpDs1.Tables(0).Rows.Count >= 1 Then
                    If TmpDs1.Tables(0).Rows(0).Item(13) = "Pending" Then
                        Panel4.Visible = True
                        RadioButton1.Visible = False

                        RadioButton2.Visible = True
                        RadioButton3.Visible = True

                        RadioButton4.Visible = False



                    ElseIf TmpDs1.Tables(0).Rows(0).Item(13) = "Rejected" Then
                        Panel4.Visible = False
                        RadioButton1.Visible = False

                        RadioButton2.Visible = False
                        RadioButton3.Visible = False

                        RadioButton4.Visible = True
                        TxtDocumentNo.Text = ""

                    ElseIf TmpDs1.Tables(0).Rows(0).Item(13) = "Approved" Then
                        Panel4.Visible = False
                        TxtDocumentNo.Text = ""
                        Label17.Text = "Coc already approved"
                        GoTo x11


                    End If
                Else
                    TxtDocumentNo.Text = ""
                    Panel4.Visible = True
                    RadioButton1.Visible = True
                    RadioButton2.Visible = False
                    RadioButton3.Visible = False
                    RadioButton4.Visible = False


                End If

            Else
                Panel4.Visible = False
            End If

            cmd = New SqlCommand("Select * From Log_COCCustomer Where CustomerID='" & Session("custid").ToString & "'", con)
            TmpAd1 = New SqlDataAdapter(cmd)
            TmpDs1 = New DataSet
            TmpAd1.Fill(TmpDs1, "Tmp")

            If TmpDs1.Tables(0).Rows.Count >= 1 Then
                Label16.Text = "Please submit COC for this customer"
                Label17.Text = " " & Session("custid")
                Label18.Text = "(" & TmpDs1.Tables(0).Rows(0).Item(8) & ")"
                'Panel4.Visible = True
            Else
                Label16.Text = "You don't need to submit COC for this customer"
                Label17.Text = Session("custid")
                Panel4.Visible = False
            End If

x11:
            con.Close()
            con1.Close()

            setFocus(txtCustomNo)



        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Public Sub setFocus(ByVal ctrl As System.Web.UI.Control)

        Dim strS As String
        strS = "<SCRIPT language='javascript'>document.getElementById('" + ctrl.ID + "').focus() </SCRIPT>"
        Page.RegisterStartupScript("focus", strS)

    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ''Attach file2 
        If DropDownList1.SelectedItem.Text = "--Select--" Then
            msg("Select the Invoice first and Try Again!")
            Exit Sub
        End If
        Dim strFileNameOnServer As String = File1.PostedFile.FileName
        Dim extPosition As Integer = strFileNameOnServer.IndexOf(".")
        Dim ext As String = strFileNameOnServer.Substring(extPosition + 1, strFileNameOnServer.Length - extPosition - 1)
        Dim strBaseLocation As String = "F:\DailyDB\Bills\"

        Dim MyString, LastWord As String
        Dim MyLen As Integer
        MyString = ext
        LastWord = Microsoft.VisualBasic.Right(MyString, 3)
        If (LastWord = "pdf") Then

            Try
                Dim da As New SqlDataAdapter("Select * from Log_CustomerBillUploading", con)
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                Dim vpath As String
                vpath = File1.PostedFile.FileName
                Dim sz As Integer
                sz = File1.PostedFile.ContentLength
                If (sz <= 2204480) Then
                    Dim fs As New FileStream(vpath, FileMode.Open, FileAccess.Read)
                    Dim mydata(fs.Length) As Byte
                    fs.Read(mydata, 0, fs.Length)
                    fs.Close()
                    con.Open()
                    da.Fill(ds, "uploading")
                    Dim myrow As DataRow
                    myrow = ds.Tables("uploading").NewRow()
                    myrow("invno") = DropDownList1.SelectedItem.Text
                    myrow("invdate") = txtInvDate.Text
                    myrow("custnam") = txt_custname.Text
                    myrow("dest") = txt_des.Text
                    myrow("cadd1") = txt_custadd.Text
                    myrow("ddate") = txt_sch.Text
                    myrow("BillImage") = mydata
                    myrow("imgtype") = "pdf1"
                    myrow("u_id") = Session("UserId")
                    myrow("createdby") = Session("UserId")
                    myrow("createddate") = Date.Now.ToShortDateString
                    myrow("BillType") = Form2.Text
                    ds.Tables("uploading").Rows.Add(myrow)
                    da.Update(ds, "uploading")
                    fs = Nothing
                    ds = Nothing
                    cb = Nothing
                    da = Nothing
                    con.Close()
                    con = Nothing
                    Button6.Enabled = False
                    lbl2.Text = "@" & strFileNameOnServer
                    msg("PDF File Uploaded")
                Else
                    msg("File size is too large !")
                End If
            Catch ex As Exception
                msg(ex.Message)
            End Try
        ElseIf (LastWord = "jpg" Or LastWord = "JPG") Then

            Try
                Dim da As New SqlDataAdapter("Select * from Log_CustomerBillUploading", con)
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                Dim vpath As String
                vpath = File1.PostedFile.FileName
                Dim sz As Integer
                sz = File1.PostedFile.ContentLength
                If (sz <= 2204480) Then
                    Dim fs As New FileStream(vpath, FileMode.Open, FileAccess.Read)
                    Dim mydata(fs.Length) As Byte
                    fs.Read(mydata, 0, fs.Length)
                    fs.Close()
                    con.Open()
                    da.Fill(ds, "uploading")
                    Dim myrow As DataRow
                    myrow = ds.Tables("uploading").NewRow()
                    myrow("invno") = DropDownList1.SelectedItem.Text
                    myrow("invdate") = txtInvDate.Text
                    myrow("custnam") = txt_custname.Text
                    myrow("dest") = txt_des.Text
                    myrow("cadd1") = txt_custadd.Text
                    myrow("ddate") = txt_sch.Text
                    myrow("BillImage") = mydata
                    myrow("imgtype") = "jpg1"
                    myrow("u_id") = Session("UserId")
                    myrow("createdby") = Session("UserId")
                    myrow("createddate") = Date.Now.ToShortDateString
                    myrow("BillType") = Form2.Text
                    ds.Tables("uploading").Rows.Add(myrow)
                    da.Update(ds, "uploading")
                    fs = Nothing
                    ds = Nothing
                    cb = Nothing
                    da = Nothing
                    con.Close()
                    con = Nothing
                    Button6.Enabled = False
                    lbl2.Text = "@" & strFileNameOnServer
                    msg("Image Uploaded")
                Else
                    msg("File size is too large !")
                End If
            Catch ex As Exception

            End Try
        Else
            msg("Invalid File Format !")
        End If

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '''Attach file3
        If DropDownList1.SelectedItem.Text = "--Select--" Then
            msg("Select the Invoice first and Try Again!")
            Exit Sub
        End If
        Dim strFileNameOnServer As String = File2.PostedFile.FileName
        Dim extPosition As Integer = strFileNameOnServer.IndexOf(".")
        Dim ext As String = strFileNameOnServer.Substring(extPosition + 1, strFileNameOnServer.Length - extPosition - 1)
        Dim strBaseLocation As String = "F:\DailyDB\Bills\"
        Dim MyString, LastWord As String
        Dim MyLen As Integer
        MyString = ext
        LastWord = Microsoft.VisualBasic.Right(MyString, 3)
        If (LastWord = "pdf") Then
            Try
                Dim da As New SqlDataAdapter("Select * from Log_CustomerBillUploading", con)
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                Dim vpath As String
                vpath = File2.PostedFile.FileName
                Dim sz As Integer
                sz = File2.PostedFile.ContentLength

                If (sz <= 2204480) Then
                    Dim fs As New FileStream(vpath, FileMode.Open, FileAccess.Read)
                    Dim mydata(fs.Length) As Byte
                    fs.Read(mydata, 0, fs.Length)
                    fs.Close()
                    If con.State = ConnectionState.Closed Then con.Open()
                    da.Fill(ds, "uploading")
                    Dim myrow As DataRow
                    myrow = ds.Tables("uploading").NewRow()
                    myrow("invno") = DropDownList1.SelectedItem.Text
                    myrow("invdate") = txtInvDate.Text
                    myrow("custnam") = txt_custname.Text
                    myrow("dest") = txt_des.Text
                    myrow("cadd1") = txt_custadd.Text
                    myrow("ddate") = txt_sch.Text
                    myrow("BillImage") = mydata
                    myrow("imgtype") = "pdf2"
                    myrow("u_id") = Session("UserId")
                    myrow("createdby") = Session("UserId")
                    myrow("createddate") = Date.Now.ToShortDateString
                    myrow("BillType") = Form3.Text
                    ds.Tables("uploading").Rows.Add(myrow)
                    da.Update(ds, "uploading")
                    fs = Nothing
                    ds = Nothing
                    cb = Nothing
                    da = Nothing
                    If con.State = ConnectionState.Open Then con.Close()
                    con = Nothing
                    Button3.Enabled = False
                    lbl3.Text = "@" & strFileNameOnServer
                    msg("pdf file Uploaded")
                Else
                    msg("File size is too large !")
                End If
            Catch ex As Exception
                msg(ex.Message)
            End Try
        ElseIf (LastWord = "jpg" Or LastWord = "JPG") Then
            Try
                Dim da As New SqlDataAdapter("Select * from Log_CustomerBillUploading", con)
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                Dim vpath As String
                vpath = File2.PostedFile.FileName
                Dim sz As Integer
                sz = File2.PostedFile.ContentLength
                If (sz <= 2204480) Then
                    Dim fs As New FileStream(vpath, FileMode.Open, FileAccess.Read)
                    Dim mydata(fs.Length) As Byte
                    fs.Read(mydata, 0, fs.Length)
                    fs.Close()
                    con.Open()
                    da.Fill(ds, "uploading")
                    Dim myrow As DataRow
                    myrow = ds.Tables("uploading").NewRow()
                    myrow("invno") = DropDownList1.SelectedItem.Text
                    myrow("invdate") = txtInvDate.Text
                    myrow("custnam") = txt_custname.Text
                    myrow("dest") = txt_des.Text
                    myrow("cadd1") = txt_custadd.Text
                    myrow("ddate") = txt_sch.Text
                    myrow("BillImage") = mydata
                    myrow("imgtype") = "jpg2"
                    myrow("u_id") = Session("UserId")
                    myrow("createdby") = Session("UserId")
                    myrow("createddate") = Date.Now.ToShortDateString
                    myrow("BillType") = Form3.Text
                    ds.Tables("uploading").Rows.Add(myrow)
                    da.Update(ds, "uploading")
                    fs = Nothing
                    ds = Nothing
                    cb = Nothing
                    da = Nothing
                    If con.State = ConnectionState.Open Then con.Close()
                    con = Nothing
                    Button3.Enabled = False
                    lbl3.Text = "@" & strFileNameOnServer
                    msg("Image Uploaded")
                Else
                    msg("File size is too large !")
                End If
            Catch ex As Exception

            End Try
        Else
            msg("Invalid File Format !")
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        '''Attach File4
        If DropDownList1.SelectedItem.Text = "--Select--" Then
            msg("Select the Invoice first and Try Again!")
            Exit Sub
        End If
        Dim strFileNameOnServer As String = File3.PostedFile.FileName
        Dim extPosition As Integer = strFileNameOnServer.IndexOf(".")
        Dim ext As String = strFileNameOnServer.Substring(extPosition + 1, strFileNameOnServer.Length - extPosition - 1)
        Dim strBaseLocation As String = "F:\DailyDB\Bills\"

        Dim MyString, LastWord As String
        Dim MyLen As Integer
        MyString = ext
        LastWord = Microsoft.VisualBasic.Right(MyString, 3)
        If (LastWord = "pdf") Then

            Try
                Dim da As New SqlDataAdapter("Select * from Log_CustomerBillUploading", con)
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                Dim vpath As String
                vpath = File3.PostedFile.FileName
                Dim sz As Integer
                sz = File3.PostedFile.ContentLength
                If (sz <= 2204480) Then
                    Dim fs As New FileStream(vpath, FileMode.Open, FileAccess.Read)
                    Dim mydata(fs.Length) As Byte
                    fs.Read(mydata, 0, fs.Length)
                    fs.Close()

                    If con.State = ConnectionState.Closed Then con.Open()
                    da.Fill(ds, "uploading")
                    Dim myrow As DataRow
                    myrow = ds.Tables("uploading").NewRow()
                    myrow("invno") = DropDownList1.SelectedItem.Text
                    myrow("invdate") = txtInvDate.Text
                    myrow("custnam") = txt_custname.Text
                    myrow("dest") = txt_des.Text
                    myrow("cadd1") = txt_custadd.Text
                    myrow("ddate") = txt_sch.Text
                    myrow("BillImage") = mydata
                    myrow("imgtype") = "pdf3"
                    myrow("u_id") = Session("UserId")
                    myrow("createdby") = Session("UserId")
                    myrow("createddate") = Date.Now.ToShortDateString
                    myrow("BillType") = Form4.Text
                    ds.Tables("uploading").Rows.Add(myrow)
                    da.Update(ds, "uploading")
                    fs = Nothing
                    ds = Nothing
                    cb = Nothing
                    da = Nothing
                    If con.State = ConnectionState.Open Then con.Close()
                    con = Nothing
                    Button4.Enabled = False
                    lbl4.Text = "@" & strFileNameOnServer
                    msg("pdf file Uploaded")
                Else
                    msg("File size is too large !")
                End If
            Catch ex As Exception
                msg(ex.Message)
            End Try
        ElseIf (LastWord = "jpg" Or LastWord = "JPG") Then
            Try
                Dim da As New SqlDataAdapter("Select * from Log_CustomerBillUploading", con)
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                Dim vpath As String
                vpath = File3.PostedFile.FileName
                Dim sz As Integer
                sz = File3.PostedFile.ContentLength
                If (sz <= 2204480) Then
                    Dim fs As New FileStream(vpath, FileMode.Open, FileAccess.Read)
                    Dim mydata(fs.Length) As Byte
                    fs.Read(mydata, 0, fs.Length)
                    fs.Close()
                    If con.State = ConnectionState.Closed Then con.Open()
                    da.Fill(ds, "uploading")
                    Dim myrow As DataRow
                    myrow = ds.Tables("uploading").NewRow()
                    myrow("invno") = DropDownList1.SelectedItem.Text
                    myrow("invdate") = txtInvDate.Text
                    myrow("custnam") = txt_custname.Text
                    myrow("dest") = txt_des.Text
                    myrow("cadd1") = txt_custadd.Text
                    myrow("ddate") = txt_sch.Text
                    myrow("BillImage") = mydata
                    myrow("imgtype") = "jpg3"
                    myrow("u_id") = Session("UserId")
                    myrow("createdby") = Session("UserId")
                    myrow("createddate") = Date.Now.ToShortDateString
                    myrow("BillType") = Form4.Text
                    ds.Tables("uploading").Rows.Add(myrow)
                    da.Update(ds, "uploading")
                    fs = Nothing
                    ds = Nothing
                    cb = Nothing
                    da = Nothing
                    If con.State = ConnectionState.Open Then con.Close()
                    con = Nothing
                    Button4.Enabled = False
                    lbl4.Text = "@" & strFileNameOnServer
                    msg("Image Uploaded")
                Else
                    msg("File size is too large !")
                End If
            Catch ex As Exception

            End Try
        Else
            msg("Invalid File Format !")
        End If
    End Sub
    Public Sub clear()
        txtInvDate.Text = ""
        txt_custname.Text = ""
        txt_des.Text = ""
        txt_custadd.Text = ""
        txt_sch.Text = ""
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        '''Attach File5
        If DropDownList1.SelectedItem.Text = "--Select--" Then
            msg("Select the Invoice first and Try Again!")
            Exit Sub
        End If
        Dim strFileNameOnServer As String = File4.PostedFile.FileName
        Dim extPosition As Integer = strFileNameOnServer.IndexOf(".")
        Dim ext As String = strFileNameOnServer.Substring(extPosition + 1, strFileNameOnServer.Length - extPosition - 1)
        Dim strBaseLocation As String = "F:\DailyDB\Bills\"

        Dim MyString, LastWord As String
        Dim MyLen As Integer
        MyString = ext
        LastWord = Microsoft.VisualBasic.Right(MyString, 3)
        If (LastWord = "pdf") Then

            Try
                Dim sz As Integer
                Dim da As New SqlDataAdapter("Select * from Log_CustomerBillUploading", con)
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                Dim vpath As String
                vpath = File4.PostedFile.FileName
                sz = File4.PostedFile.ContentLength
                If (sz <= 2204480) Then
                    Dim fs As New FileStream(vpath, FileMode.Open, FileAccess.Read)
                    Dim mydata(fs.Length) As Byte
                    fs.Read(mydata, 0, fs.Length)
                    fs.Close()

                    con.Open()
                    da.Fill(ds, "uploading")
                    Dim myrow As DataRow
                    myrow = ds.Tables("uploading").NewRow()
                    myrow("invno") = DropDownList1.SelectedItem.Text
                    myrow("invdate") = txtInvDate.Text
                    myrow("custnam") = txt_custname.Text
                    myrow("dest") = txt_des.Text
                    myrow("cadd1") = txt_custadd.Text
                    myrow("ddate") = txt_sch.Text
                    myrow("BillImage") = mydata
                    myrow("imgtype") = "pdf4"
                    myrow("u_id") = Session("UserId")
                    myrow("createdby") = Session("UserId")
                    myrow("createddate") = Date.Now.ToShortDateString
                    myrow("BillType") = Form5.Text
                    ds.Tables("uploading").Rows.Add(myrow)
                    da.Update(ds, "uploading")
                    fs = Nothing
                    ds = Nothing
                    cb = Nothing
                    da = Nothing
                    con.Close()
                    con = Nothing
                    Button5.Enabled = False
                    lbl5.Text = "@" & strFileNameOnServer
                    msg("pdf file Uploaded")
                Else
                    msg("File size is too large !")
                End If
            Catch ex As Exception
                msg(ex.Message)
            End Try
        ElseIf (LastWord = "jpg" Or LastWord = "JPG") Then

            Try
                Dim da As New SqlDataAdapter("Select * from uploading", con)
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                Dim vpath As String
                vpath = File4.PostedFile.FileName
                Dim sz As Integer
                sz = File4.PostedFile.ContentLength
                If (sz <= 2204480) Then
                    Dim fs As New FileStream(vpath, FileMode.Open, FileAccess.Read)
                    Dim mydata(fs.Length) As Byte
                    fs.Read(mydata, 0, fs.Length)
                    fs.Close()
                    con.Open()
                    da.Fill(ds, "uploading")
                    Dim myrow As DataRow
                    myrow = ds.Tables("uploading").NewRow()
                    myrow("invno") = DropDownList1.SelectedItem.Text
                    myrow("invdate") = txtInvDate.Text
                    myrow("custnam") = txt_custname.Text
                    myrow("dest") = txt_des.Text
                    myrow("cadd1") = txt_custadd.Text
                    myrow("ddate") = txt_sch.Text
                    myrow("BillImage") = mydata
                    myrow("imgtype") = "jpg4"
                    myrow("u_id") = Session("UserId")
                    myrow("createdby") = Session("UserId")
                    myrow("createddate") = Date.Now.ToShortDateString
                    myrow("BillType") = Form5.Text
                    ds.Tables("uploading").Rows.Add(myrow)

                    da.Update(ds, "uploading")
                    fs = Nothing
                    ds = Nothing
                    cb = Nothing
                    da = Nothing
                    con.Close()
                    con = Nothing
                    lbl5.Text = "@" & strFileNameOnServer
                    Button5.Enabled = False
                    msg("Image Uploaded")
                Else
                    msg("File size is too large !")
                End If
            Catch ex As Exception

            End Try
        Else
            msg("Invalid File Format !")
        End If

    End Sub

  

    Private Sub btn_remove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_remove1.Click
        'Delete Existing file
        If DropDownList1.SelectedItem.Text = "--Select--" Then
            msg("Select the Invoice first and Try Again!")
            Exit Sub
        End If
        Try
            con.Open()
            Dim cmd As New SqlCommand("delete from Log_CustomerBillUploading where invno='" & TxtInvNo.Text & "'", con)
            cmd.ExecuteNonQuery()
            msg("Deleted")
            btn_attach.Enabled = True
            lbl1.Text = ""
            con.Close()
        Catch ex As Exception
            msg("No Bills")
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TxtDept.Text = "" Then
            msg("Please Select Department Name")
            Exit Sub
        End If

        txt_custname.Text = txt_custname.Text.Replace("'", " ")
        txt_custadd.Text = txt_custadd.Text.Replace("'", " ")

        vpath1 = (File5.PostedFile.FileName().Replace("\", "\\"))
        msg(vpath1)
        sz1 = File5.PostedFile.ContentLength


        
        imgtyp = "Jpg"
        pdftyp = "Pdf"
        filetypetest()
        filetypetest1()

        Try
            Dim TmpDs1 As New DataSet
            Dim TmpAd1 As New SqlDataAdapter

            Dim ob As New CRMlognetglobal
            Dim conStr1
            ob.db_cn()
            conStr1 = sConnString.ToString()
            'txtpic.Text = sConnString
            Dim con1 As New SqlConnection(conStr1)
            con1.Open()


            cmd = New SqlCommand("Select DocName, CustomFormNo, HSCode from Log_CustomerBillUploading where InvNo= replace('" & TxtInvNo.Text & "',' ','')", con1)
            TmpDs1 = New DataSet
            TmpAd1 = New SqlDataAdapter(cmd)
            TmpAd1.Fill(TmpDs1, "InvDetails")


            Label1.BackColor = Color.White
            Label8.BackColor = Color.White
            Label2.BackColor = Color.White
            Label11.BackColor = Color.White
            Label3.BackColor = Color.White
            Label9.BackColor = Color.White
            Label10.BackColor = Color.White
            Label12.BackColor = Color.White


            Label1.ForeColor = Color.Black
            Label8.ForeColor = Color.Black
            Label2.ForeColor = Color.Black
            Label11.ForeColor = Color.Black
            Label3.ForeColor = Color.Black
            Label9.ForeColor = Color.Black
            Label10.ForeColor = Color.Black
            Label12.ForeColor = Color.Black


          

            For TmpI1 As Integer = 0 To TmpDs1.Tables(0).Rows.Count - 1

                Dim Str As String = ""


                Str = TmpDs1.Tables(0).Rows(TmpI1).Item(0)

                If Str = "Invoice" Then
                    Label1.BackColor = Color.Green
                    Label1.ForeColor = Color.White

                ElseIf Str = "Packing List" Then
                    Label8.BackColor = Color.Green
                    Label8.ForeColor = Color.White

                ElseIf Str = "K8 Custom Form" Then
                    Label2.BackColor = Color.Green
                    Label2.ForeColor = Color.White

                ElseIf Str = "Certificate of Origin(COC)" Then
                    Label11.BackColor = Color.Green
                    Label11.ForeColor = Color.White

                ElseIf Str = "AWB and BL" Then
                    Label3.BackColor = Color.Green
                    Label3.ForeColor = Color.White

                ElseIf Str = "Fumigation Certificate and Wooden Declaration" Then
                    Label9.BackColor = Color.Green
                    Label9.ForeColor = Color.White

                ElseIf Str = "Photos" Then
                    Label10.BackColor = Color.Green
                    Label10.ForeColor = Color.White


                ElseIf Str = "Forwarder Invoice" Then
                    Label12.BackColor = Color.Green
                    Label12.ForeColor = Color.White
                End If
            Next


            con1.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub filetypetest()


        Dim ob As New CRMlognetglobal()
        Dim conStr1 As String
        ob.db_cn()
        conStr1 = ob.sConnString4

        Dim con2 As New SqlConnection()
        con2 = New SqlConnection(conStr1)
        con2.Open()

        'Dim vpath As String
        If DropDownList1.Visible = True Then
            If DropDownList1.SelectedItem.Text = "--Select--" Then
                msg("Select the Invoice first and Try Again!")
                Exit Sub
            End If
        End If

        If txtCustomNo.Text.Trim.Equals("") Then
            MsgBox("Please Enter Valid Custom Form No")
            Exit Sub
        End If

        If TxtHSCode.Text.Trim.Equals("") Then
            MsgBox("Please Enter Valid HS Code")
            Exit Sub
        End If


        Dim strFileNameOnServer As String = vpath1
        Dim extPosition As Integer = strFileNameOnServer.IndexOf(".")
        Dim ext As String = strFileNameOnServer.Substring(extPosition + 1, strFileNameOnServer.Length - extPosition - 1)
        Dim strBaseLocation As String = "F:\DailyDB\Bills\"

        Dim MyString, LastWord As String
        Dim MyLen As Integer
        MyString = ext
        LastWord = Microsoft.VisualBasic.Right(MyString, 3)
        If (LastWord = "pdf") Then
            Try
                Dim da As New SqlDataAdapter("Select * from Log_CustomerBillUploading", con2)
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey

                'vpath = File1.PostedFile.FileName
                Dim sz As Integer
                sz = File5.PostedFile.ContentLength
                If (sz <= 2204480) Then
                    Dim fs As New FileStream(vpath1, FileMode.Open, FileAccess.Read)
                    Dim mydata(fs.Length) As Byte
                    fs.Read(mydata, 0, fs.Length)
                    fs.Close()
                    con.Open()
                    da.Fill(ds, "Log_CustomerBillUploading")
                    Dim myrow As DataRow
                    myrow = ds.Tables("Log_CustomerBillUploading").NewRow()
                    myrow("invno") = TxtInvNo.Text
                    'myrow("invdate") = txtInvDate.Text
                    myrow("custId") = txt_custname.Text
                    'myrow("dest") = txt_des.Text
                    'myrow("cadd1") = txt_custadd.Text
                    'myrow("ddate") = txt_sch.Text
                    myrow("BillImage") = mydata
                    myrow("imagetype") = pdftyp
                    'myrow("u_id") = Session("UserId")
                    myrow("createdby") = Session("UserId")
                    myrow("createddate") = Date.Now
                    myrow("DocName") = DropDownList2.Text
                    myrow("CustomFormNo") = txtCustomNo.Text
                    myrow("Department") = TxtDept.Text
                    myrow("DDate") = txt_sch.Text
                    myrow("HsCode") = TxtHSCode.Text

                    ds.Tables("Log_CustomerBillUploading").Rows.Add(myrow)
                    da.Update(ds, "Log_CustomerBillUploading")
                    fs = Nothing
                    ds = Nothing
                    cb = Nothing
                    da = Nothing
                    con.Close()
                    con = Nothing
                    Button6.Enabled = False
                    lbl2.Text = "@" & strFileNameOnServer
                    msg("PDF File Uploaded")
                Else
                    msg("File size is too Large !")
                End If
            Catch ex As Exception
                msg(ex.Message)
            End Try
        ElseIf (LastWord = "jpg" Or LastWord = "JPG") Then
            Try
                Dim da As New SqlDataAdapter("Select * from Log_CustomerBillUploading", con2)
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                Dim vpath As String
                'vpath = File1.PostedFile.FileName
                'Dim sz As Integer
                'sz = File1.PostedFile.ContentLength
                If (sz1 <= 2204480) Then
                    Dim fs As New FileStream(vpath1, FileMode.Open, FileAccess.Read)
                    Dim mydata(fs.Length) As Byte
                    fs.Read(mydata, 0, fs.Length)
                    fs.Close()
                    con.Open()
                    da.Fill(ds, "Log_CustomerBillUploading")
                    Dim myrow As DataRow
                    myrow = ds.Tables("Log_CustomerBillUploading").NewRow()
                    myrow("invno") = TxtInvNo.Text
                    'myrow("invdate") = txtInvDate.Text
                    myrow("custId") = txt_custname.Text
                    'myrow("dest") = txt_des.Text
                    'myrow("cadd1") = txt_custadd.Text
                    'myrow("ddate") = txt_sch.Text
                    myrow("BillImage") = mydata
                    myrow("imagetype") = imgtyp
                    'myrow("u_id") = Session("UserId")
                    myrow("createdby") = Session("UserId")
                    myrow("createddate") = Date.Now
                    myrow("DocName") = DropDownList2.Text
                    myrow("CustomFormNo") = txtCustomNo.Text
                    myrow("Department") = TxtDept.Text
                    myrow("DDate") = txt_sch.Text
                    myrow("HsCode") = TxtHSCode.Text

                    ds.Tables("Log_CustomerBillUploading").Rows.Add(myrow)
                    da.Update(ds, "Log_CustomerBillUploading")
                    fs = Nothing
                    ds = Nothing
                    cb = Nothing
                    da = Nothing
                    con2.Close()
                    con2 = Nothing
                    Button6.Enabled = False
                    lbl2.Text = "@" & strFileNameOnServer
                    msg("Image Uploaded..")
                Else
                    msg("File Size is too Large !")
                End If
            Catch ex As Exception

            End Try
        Else
            msg("Invalid File Format !")
        End If
    End Sub


    Private Sub filetypetest1()
        'Dim vpath As String


        Dim ob As New CRMlognetglobal()
        Dim conStr1 As String
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection()
        con1 = New SqlConnection(conStr1)
        con1.Open()


        If DropDownList1.Visible = True Then
            If DropDownList1.SelectedItem.Text = "--Select--" Or DropDownList1.SelectedItem.Equals("") Then
                msg("Select the Invoice first and Try Again!")
                Exit Sub
            End If
        End If

        If txtCustomNo.Text.Trim.Equals("") Then
            MsgBox("Please Enter Valid Custom Form No")
            Exit Sub
        End If

        If TxtHSCode.Text.Trim.Equals("") Then
            MsgBox("Please Enter Valid HS Code")
            Exit Sub
        End If


        Dim strFileNameOnServer As String = vpath1
        Dim extPosition As Integer = strFileNameOnServer.IndexOf(".")
        Dim ext As String = strFileNameOnServer.Substring(extPosition + 1, strFileNameOnServer.Length - extPosition - 1)
        Dim strBaseLocation As String = "F:\DailyDB\Bills\"

        Dim MyString, LastWord As String
        Dim MyLen As Integer
        MyString = ext
        LastWord = Microsoft.VisualBasic.Right(MyString, 3)
        If (LastWord = "pdf") Then
            Try
                Dim da As New SqlDataAdapter("Select * from Log_CustomerBillUploading", con1)
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey

                'vpath = File1.PostedFile.FileName
                Dim sz As Integer
                sz = File5.PostedFile.ContentLength
                If (sz <= 2204480) Then
                    Dim fs As New FileStream(vpath1, FileMode.Open, FileAccess.Read)
                    Dim mydata(fs.Length) As Byte
                    fs.Read(mydata, 0, fs.Length)
                    fs.Close()
                    'con.Open()
                    da.Fill(ds, "Log_CustomerBillUploading")
                    Dim myrow As DataRow
                    myrow = ds.Tables("Log_CustomerBillUploading").NewRow()
                    myrow("invno") = TxtInvNo.Text
                    'myrow("invdate") = txtInvDate.Text
                    myrow("custId") = txt_custname.Text
                    'myrow("dest") = txt_des.Text
                    'myrow("cadd1") = txt_custadd.Text
                    'myrow("ddate") = txt_sch.Text
                    'myrow("BillImage") = ""
                    myrow("imagetype") = pdftyp
                    'myrow("u_id") = Session("UserId")
                    myrow("createdby") = Session("UserId")
                    myrow("createddate") = Date.Now
                    myrow("DocName") = DropDownList2.Text
                    myrow("CustomFormNo") = txtCustomNo.Text
                    myrow("Department") = TxtDept.Text
                    myrow("DDate") = txt_sch.Text
                    myrow("HsCode") = TxtHSCode.Text

                    ds.Tables("Log_CustomerBillUploading").Rows.Add(myrow)
                    da.Update(ds, "Log_CustomerBillUploading")
                    fs = Nothing
                    ds = Nothing
                    cb = Nothing
                    da = Nothing
                    con1.Close()
                    con1 = Nothing
                    Button6.Enabled = False
                    lbl2.Text = "@" & strFileNameOnServer
                    msg("PDF File Uploaded")
                Else
                    msg("File size is too Large !")
                End If
            Catch ex As Exception
                msg(ex.Message)
            End Try
        ElseIf (LastWord = "jpg" Or LastWord = "JPG") Then
            Try
                Dim da As New SqlDataAdapter("Select * from Log_CustomerBillUploading", con1)
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                Dim ds As New DataSet
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey
                Dim vpath As String
                'vpath = File1.PostedFile.FileName
                'Dim sz As Integer
                'sz = File1.PostedFile.ContentLength
                If (sz1 <= 2204480) Then
                    Dim fs As New FileStream(vpath1, FileMode.Open, FileAccess.Read)
                    Dim mydata(fs.Length) As Byte
                    fs.Read(mydata, 0, fs.Length)
                    fs.Close()
                    'con.Open()
                    da.Fill(ds, "Log_CustomerBillUploading")
                    Dim myrow As DataRow
                    myrow = ds.Tables("Log_CustomerBillUploading").NewRow()
                    myrow("invno") = TxtInvNo.Text
                    'myrow("invdate") = txtInvDate.Text
                    myrow("custId") = txt_custname.Text
                    'myrow("dest") = txt_des.Text
                    'myrow("cadd1") = txt_custadd.Text
                    'myrow("ddate") = txt_sch.Text
                    'myrow("BillImage") = ""
                    myrow("imagetype") = imgtyp
                    'myrow("u_id") = Session("UserId")
                    myrow("createdby") = Session("UserId")
                    myrow("createddate") = Date.Now
                    myrow("DocName") = DropDownList2.Text
                    myrow("CustomFormNo") = txtCustomNo.Text
                    myrow("Department") = TxtDept.Text
                    myrow("DDate") = txt_sch.Text
                    myrow("HsCode") = TxtHSCode.Text

                    ds.Tables("Log_CustomerBillUploading").Rows.Add(myrow)
                    da.Update(ds, "Log_CustomerBillUploading")
                    fs = Nothing
                    ds = Nothing
                    cb = Nothing
                    da = Nothing
                    con1.Close()
                    con1 = Nothing
                    Button6.Enabled = False
                    lbl2.Text = "@" & strFileNameOnServer
                    msg("Image Uploaded")
                Else
                    msg("File Size is too Large !")
                End If
            Catch ex As Exception

            End Try
        Else
            msg("Invalid File Format !")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        vpath1 = File6.PostedFile.FileName()
        sz1 = File6.PostedFile.ContentLength
        imgtyp = "Jpg1"
        pdftyp = "Pdf1"
        filetypetest()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        vpath1 = File7.PostedFile.FileName()
        sz1 = File7.PostedFile.ContentLength
        imgtyp = "Jpg2"
        pdftyp = "Pdf2"

        filetypetest()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        vpath1 = File8.PostedFile.FileName()
        sz1 = File8.PostedFile.ContentLength
        imgtyp = "Jpg3"
        pdftyp = "Pdf3"
        filetypetest()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        vpath1 = File9.PostedFile.FileName()
        sz1 = File9.PostedFile.ContentLength
        imgtyp = "Jpg4"
        pdftyp = "Pdf4"
        filetypetest()
    End Sub

    Private Sub btnRemoveCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveCustomer.Click
        'Delete Existing file
        If DropDownList1.SelectedItem.Text = "--Select--" Or TxtInvNo.Text = "" Then
            msg("Please Select the Invoice!")
            Exit Sub
        End If

        Try
            con.Open()
            Dim cmd As New SqlCommand("delete from log_customerBillUploading where invno='" & TxtInvNo.Text & "'", con)
            cmd.ExecuteNonQuery()
            msg("Deleted")
            btn_attach.Enabled = True
            lbl1.Text = ""
            con.Close()
        Catch ex As Exception
            msg("No Bills")
        End Try
    End Sub

     
    Protected Sub CmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbDept.SelectedIndexChanged
        If Not CmbDept.SelectedItem.Text = "Select Department" Then
            Dim DCs = InStr(CmbDept.SelectedItem.Text, "[", CompareMethod.Text)
            Dim DCe = InStr(CmbDept.SelectedItem.Text, "]", CompareMethod.Text)
            Dim Len = DCe - (DCs + 1)
            Dim DuCo = Trim(Mid(CmbDept.SelectedItem.Text, (DCs + 1), Len))
            Dim DuCs = Trim(Mid(CmbDept.SelectedItem.Text, 1, DCs - 1))
            TxtDept.Text = DuCs
        End If
    End Sub

    Protected Sub CmbHSCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbHSCode.SelectedIndexChanged
        TxtHSCode.Text = CmbHSCode.Text
    End Sub
 
    Protected Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If DropDownList1.SelectedItem.Text = "--Select--" Or TxtInvNo.Text = "" Then
            msg("Please Select the Invoice!")
            Exit Sub
        End If

        If DropDownList2.Text = "" Or DropDownList2.Text = "--Select--" Then
            msg("Please Select valid Document Name")
            Exit Sub
        End If

        Try

            Dim ob As New CRMlognetglobal()
            Dim conStr1 As String
            ob.db_cn()
            conStr1 = ob.sConnString4

            Dim con2 As New SqlConnection()
            con2 = New SqlConnection(conStr1)
            con2.Open()

            Dim cmd As New SqlCommand("delete from log_customerBillUploading where invno='" & TxtInvNo.Text & "' and DocName='" & DropDownList2.Text & "'", con2)
            cmd.ExecuteNonQuery()

       
        Catch ex As Exception

        End Try

        con2.Close()



        Try
            Dim ob As New CRMlognetglobal()
            Dim conStr1 As String
            ob.db_cn()
            conStr1 = ob.sConnString

            Dim con2 As New SqlConnection()
            con2 = New SqlConnection(conStr1)
            con2.Open()

            Dim cmd As New SqlCommand("delete from log_customerBillUploading where invno='" & TxtInvNo.Text & "' and DocName='" & DropDownList2.Text & "'", con2)
            cmd.ExecuteNonQuery()
            msg("File Removed...")
           
        Catch ex As Exception

        End Try
        con2.Close()
    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged

    End Sub

    Protected Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim ob As New CRMlognetglobal()
        Dim conStr1 As String
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con2 As New SqlConnection()
        con2 = New SqlConnection(conStr1)
        con2.Open()

        If RadioButton1.Checked = True Then

            cmd = New SqlCommand("Insert Into Log_COCSubmission (InvoiceNo, InvoiceDate, SubmittedOn,SubmittedBy,SDocumentNo, ApprovalStatus, Department,Remarks, CreatedOn) Values ('" & TxtInvNo.Text & "','" & txtInvDate.Text & "','" & TxtCocDate.Text & "','" & Session("empcode").ToString & "','" & TxtDocumentNo.Text & "','Pending','" & TxtDept.Text & "','" & TxtRemarks.Text & "','" & DateTime.Now & "')", con2)
            cmd.ExecuteNonQuery()
            msg("COC Submitted")
            con2.Close()

        ElseIf RadioButton2.Checked = True Then

            If Label11.BackColor = Color.Green Then
                cmd = New SqlCommand("Update Log_COCSubmission Set ApprovalStatus='Approved', ApprovedOn='" & TxtCocDate.Text & "', ApprovedBy='" & Session("empcode").ToString & "', ADocumentNo='" & TxtDocumentNo.Text & "', Remarks='" & TxtRemarks.Text & "' Where InvoiceNo='" & TxtInvNo.Text & "'", con2)
                cmd.ExecuteNonQuery()
                msg("COC - Approved Data Stored Successfully")
                con2.Close()
            Else
                msg("Please Upload COC")
            End If

        ElseIf RadioButton3.Checked = True Then

            cmd = New SqlCommand("Update Log_COCSubmission Set ApprovalStatus='Rejected', RejectedOn='" & TxtCocDate.Text & "', RejectedBy='" & Session("empcode").ToString & "', Remarks='" & TxtRemarks.Text & "' Where InvoiceNo='" & TxtInvNo.Text & "'", con2)
            cmd.ExecuteNonQuery()
            msg("COC - Rejected Data Stored Successfully")
            con2.Close()

        ElseIf RadioButton4.Checked = True Then

            cmd = New SqlCommand("Update Log_COCSubmission Set ApprovalStatus='Pending', ReSubmittedOn='" & TxtCocDate.Text & "', ReSubmittedBy='" & Session("empcode").ToString & "', RDocumentNo='" & TxtDocumentNo.Text & "', Remarks='" & TxtRemarks.Text & "' Where InvoiceNo='" & TxtInvNo.Text & "'", con2)
            cmd.ExecuteNonQuery()
            msg("COC - Resubmitted Data Stored Successfully")
            con2.Close()

        Else
            msg("Please Select the Given Option")
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If Calendar1.Visible = False Then
            Calendar1.Visible = True
        Else
            Calendar1.Visible = False
        End If
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Dim s = Calendar1.SelectedDate
        's = Format(Calendar1.SelectedDate, "dd/mm/yyyy")
        s = Format(Convert.ToDateTime(Calendar1.SelectedDate), "MM/dd/yyyy")
        TxtCocDate.Text = s
        Calendar1.Visible = False
    End Sub

    Protected Sub TxtCocDate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCocDate.TextChanged

    End Sub

    Protected Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Button11.Text = "COC - Submit"
    End Sub

    Protected Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Button11.Text = "COC - Approve"
    End Sub

    Protected Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        Button11.Text = "COC - Reject"
    End Sub

    Protected Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Button11.Text = "COC - ReSubmit"
    End Sub
End Class
