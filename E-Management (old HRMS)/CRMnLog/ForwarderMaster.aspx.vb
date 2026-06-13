'Declaring the namespaces
Imports System.Data.SqlClient
Imports E_Management.crmlognetglobal
Imports System.Web.Security
Imports E_Management.Global
Partial Class ForwarderMaster
    Inherits Messagebox
    'Variables
    '
    'Connection String
    Dim MyGlobal As New Emanagement.globalinfo
    Dim str1 = MyGlobal.ConCRMStr

    Dim str As String = MyGlobal.ConCRMStr
   
    Dim con As New SqlConnection(str1)
    Dim cb As SqlCommandBuilder
    Dim cb1 As SqlCommandBuilder
    Dim ds As New DataSet
    Public dr As SqlDataReader
    Dim da As New SqlDataAdapter("select * from Log_ForwardersMaster", con)
    Public cmd As New SqlCommand("Select * from Log_ForwardersMaster", con)
    Dim c(9) As DataColumn
    Public totrec As Int32
    Dim cntr As Int32
    Dim rno As Byte
    Dim str3 As String
    Dim mynet As New CRMlognetglobal
    'Ravi
    'Protected WithEvents ltlAlert As System.Web.UI.WebControls.Literal
    'Ravi
    Public a As String

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

        If Session("IsForwarder") = 2 Then
            Label8.Visible = False
            ddlselect.Visible = False
            txtFID.Enabled = False
            txtFID.Text = Session("forwcode")
            txtFEmailID.Text = Session("Email")
        End If
        txtFID.Enabled = False
        'Maintaining the Session Timeout
        If Session("IsForwarder") = 1 Then
            con.Open()
            Dim cmd10 As New SqlCommand("select EmpCustCode from users where userID='" & Session("UserId") & "'", con)
            Dim dr10 As SqlDataReader
            dr10 = cmd10.ExecuteReader
            Do While dr10.Read
                Session("forwarderid") = dr10(0)
            Loop
            dr10.Close()
            con.Close()
        End If


        'Disabling Edit mode to other forwarders
        If Page.IsPostBack = False Then
            If Session("IsForwarder") = 1 Then
                txtFname.Enabled = False
                txtaddress1.Enabled = False
                txtaddress2.Enabled = False
                txtstate.Enabled = False
                txtcty.Enabled = False
                txtFOffNo1.Enabled = False
                txtFOffNo2.Enabled = False
                ddlft.Enabled = False
                ddlst.Enabled = False
                ddlcty.Enabled = False
                txtofffaxno.Enabled = False
                txtFEmailID.Enabled = False
                txtFCntPerson.Enabled = False
                txtFMobileNo.Enabled = False
                txtoffphno.Enabled = False
                txtFFaxNo.Enabled = False
                txtcemail.Enabled = False
                ddlbillterm.Enabled = False
                txtobt.Enabled = False
                txtded.Enabled = False
                btnSubmit.Enabled = False
                btnClear.Enabled = False
            End If
        End If
        Response.AppendHeader("Refresh", (Session.Timeout * 40 + 60).ToString() + "; URL=../logout.aspx")
        If Not Page.IsPostBack Then
            Session("lo") = Now.Minute
        End If
        a = Session("lo") + 20
        Dim b As String
        If a = Now.Minute Or (Now.Minute - Session("lo")) > 20 Then
            Response.Redirect("../logout.aspx")
        End If
        'Objects for Accessing the Tables from mmCRM DataBase
        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = sConnString.ToString()
        Dim con1 As New SqlConnection(conStr1)
        cb = New SqlCommandBuilder(da)
        da.Fill(ds, "ds1")
        c(0) = ds.Tables("ds1").Columns("F_id")
        ds.Tables("ds1").PrimaryKey = c
        con.Open()
        If Not Page.IsPostBack Then
            ddlselect.Items.Clear()
            'Fetching the Forwarderid using FM_selectid procedure
            Dim cmd1 As New SqlCommand("FM_selectid", con)
            cmd1.CommandType = CommandType.StoredProcedure
            Dim dr1 As SqlDataReader
            dr1 = cmd1.ExecuteReader()
            ddlselect.Items.Insert(0, " - Select - ")
            While (dr1.Read())
                str3 = dr1(0) & "-" & dr1(1)
                ddlselect.Items.Add(str3)
            End While
            dr1.Close()
        End If
        If Not Page.IsPostBack Then
            ddlst.Items.Clear()
            'Fetching the state using FM_selectst procedure
            Dim cmd2 As New SqlCommand("FM_selectst", con)
            cmd2.CommandType = CommandType.StoredProcedure
            Dim dr2 As SqlDataReader
            dr2 = cmd2.ExecuteReader()
            ddlst.Items.Insert(0, " - Select - ")
            While (dr2.Read())
                ddlst.Items.Add(dr2(0))
            End While
            dr2.Close()
        End If
        If Not Page.IsPostBack Then
            ddlcty.Items.Clear()
            'Fetching the Country using FM_selectcy procedure
            Dim cmd3 As New SqlCommand("FM_selectcy", con)
            cmd3.CommandType = CommandType.StoredProcedure
            Dim dr3 As SqlDataReader
            dr3 = cmd3.ExecuteReader()
            ddlcty.Items.Insert(0, " - Select - ")
            While (dr3.Read())
                ddlcty.Items.Add(dr3(0))
            End While
            dr3.Close()
        End If
        If Not Page.IsPostBack Then
            ddlft.Items.Clear()
            ddlbillterm.Items.Clear()
            'Fetching the billingterim using FM_selectbt procedure
            Dim cmd4 As New SqlCommand("FM_selectbt", con)
            cmd4.CommandType = CommandType.StoredProcedure
            Dim dr4 As SqlDataReader
            dr4 = cmd4.ExecuteReader()
            ddlbillterm.Items.Insert(0, " - Select - ")
            While (dr4.Read())
                ddlbillterm.Items.Add(dr4(0))
            End While
            ddlft.Items.Clear()
            ddlft.Items.Insert(0, " -Select - ")
            ddlft.Items.Insert(1, "Airways")
            ddlft.Items.Insert(2, "Shiping ")
            ddlft.Items.Insert(3, "Truck")
            ddlft.Items.Insert(4, "Courier")
            ddlft.Items.Insert(5, "Both Air-Ship")
            ddlft.Items.Insert(6, "All")

            ddlft.Text = "All"
        End If
        con.Close()



        txtFID.Text = Session("forwcode").ToString

        'Try
        '    If Session("IsEmployee") = 1 Or Session("CAdmin") = True Then
        '        If ddlselect.SelectedItem.Text = " - Select - " Then
        '            If con.State = ConnectionState.Closed Then con.Open()
        '            Dim cmd1 As New SqlCommand("SPSelect_FWDMaxID", con)
        '            cmd1.CommandType = CommandType.StoredProcedure
        '            Dim dr As SqlDataReader
        '            dr = cmd1.ExecuteReader()
        '            While (dr.Read())
        '              
        'Catch ex As Exception
        '    msg(ex.Message)
        'End Try
        '-----------


        txtFEmailID.Text = Session("Email").ToString()
        txtcemail.Text = Session("Email").ToString()
    End Sub
    Sub filldata(ByVal rno1 As Byte)
        'Filling data's to the controls
        txtFID.Text = ds.Tables("ds1").Rows(rno1).Item(0)
        txtFname.Text = ds.Tables("ds1").Rows(rno1).Item(1)
        txtaddress1.Text = ds.Tables("ds1").Rows(rno1).Item(2)
        txtaddress2.Text = ds.Tables("ds1").Rows(rno1).Item(3)
        txtFEmailID.Text = ds.Tables("ds1").Rows(rno1).Item(6)
        txtFCntPerson.Text = ds.Tables("ds1").Rows(rno1).Item(7)
        txtFMobileNo.Text = ds.Tables("ds1").Rows(rno1).Item(8)
        txtFOffNo1.Text = ds.Tables("ds1").Rows(rno1).Item(9)
        txtFOffNo2.Text = ds.Tables("ds1").Rows(rno1).Item(10)
        txtFFaxNo.Text = ds.Tables("ds1").Rows(rno1).Item(11)
    End Sub
    Private Sub Say(ByVal Message As String)
        ' Format string properly
        Message = Message.Replace("'", "\'")
        Message = Message.Replace(Convert.ToChar(10), "\n")
        Message = Message.Replace(Convert.ToChar(13), "")
        ' Display as JavaScript alert
        ltlAlert.Text = "alert('" & Message & "')"
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        'Checking the fields entered values against its length

        If ddlbillterm.Text = " - Select - " Then
            msg("Please Select Billing Terms..")
            Exit Sub
        End If

        If ddlft.Text = " -Select - " Then
            msg("Please Select Forwarder Type")
            Exit Sub

        End If

        If Len(txtFEmailID.Text.Trim) > 50 Then
            msg("E-Mail ID Length Can not be Exceeded More than 50 Characters!")
            txtFEmailID.Text = ""
            Exit Sub
        End If
        If Len(txtaddress1.Text.Trim) > 500 Then
            msg("Address Length Can not be Exceeded More than 500 Characters!")
            txtaddress1.Text = ""
            Exit Sub
        End If
        If Len(txtaddress2.Text.Trim) > 500 Then
            msg("Address2 Length Can not be Exceeded More than 500 Characters!")
            txtaddress2.Text = ""
            Exit Sub
        End If
        If Len(txtFname.Text.Trim) > 50 Then
            msg("Forwarders Name Length Can not be Exceeded More than 50 Characters!")
            txtFname.Text = ""
            Exit Sub
        End If
        If Len(txtcemail.Text.Trim) > 50 Then
            msg("Confirm E-Mail Length Can not be Exceeded More than 50 Characters!")
            txtcemail.Text = ""
            Exit Sub
        End If

        If Len(txtFFaxNo.Text) > 12 Then
            msg("Fax Number  Length Can not be Exceeded More than 12 Characters!")
            txtFFaxNo.Text = ""
            Exit Sub
        End If
        If Len(txtoffphno.Text) > 12 Then
            msg("Office Phone Number  Length Can not be Exceeded More than 12 Characters!")
            txtoffphno.Text = ""
            Exit Sub
        End If
        If Len(txtFMobileNo.Text) > 12 Then
            msg("Mobile Number  Length Can not be Exceeded More than 12 Characters!")
            txtFMobileNo.Text = ""
            Exit Sub
        End If
        If Len(txtFname.Text) > 35 Then
            msg("Full Name Length Can not be Exceeded More than 35 Characters!")
            txtFname.Text = ""
            Exit Sub
        End If
        If Len(txtFOffNo1.Text) > 15 Then
            msg("Office Phone No1  Length Can not be Exceeded More than 15 Characters!")
            txtFOffNo1.Text = ""
            Exit Sub
        End If
        If Len(txtFOffNo2.Text) > 15 Then
            msg("Office Phone No2  Length Can not be Exceeded More than 15 Characters!")
            txtFOffNo2.Text = ""
            Exit Sub
        End If
        If Trim(txtFID.Text) = "" Then
            Say("Please Enter Valid Forwarder FID" & _
                                   Microsoft.VisualBasic.vbNewLine & _
                                   "Please try again.")

            Exit Sub
        End If
        If Trim(txtFname.Text) = "" Then
            Say("Please Enter Valid Forwarder Name! " & _
                                               Microsoft.VisualBasic.vbNewLine & _
                                               "Please try again.")
            Exit Sub
        End If
        If Trim(txtaddress1.Text) = "" Then
            Say("Please Enter Valid Address! " & _
                                               Microsoft.VisualBasic.vbNewLine & _
                                               "Please try again.")
            Exit Sub
        End If
        If Trim(txtFOffNo1.Text) = "" Then
            Say("Please Enter Valid Phone Number! " & _
                                               Microsoft.VisualBasic.vbNewLine & _
                                               "Please try again.")
            Exit Sub
        End If
        If Trim(txtFCntPerson.Text) = "" Then
            Say("Please Enter Valid Contact Person! " & _
                                               Microsoft.VisualBasic.vbNewLine & _
                                               "Please try again.")
            Exit Sub
        End If
        If Trim(txtFMobileNo.Text) = "" Then
            Say("Please Enter Mobile Number! " & _
                                               Microsoft.VisualBasic.vbNewLine & _
                                               "Please try again.")
            Exit Sub
        End If
        If Trim(txtFFaxNo.Text) = "" Then
            Say("Please Enter Valid Fax Number! " & _
                                               Microsoft.VisualBasic.vbNewLine & _
                                               "Please try again.")
            Exit Sub
        End If
        If Trim(txtcemail.Text) = "" Then
            Say("Please Enter Valid Email ID! " & _
                                               Microsoft.VisualBasic.vbNewLine & _
                                               "Please try again.")
            Exit Sub
        End If
        If Trim(txtded.Text) = "" Then
            Say("Please Enter Valid Deduction Percentage")
            txtded.Text = 0
            Exit Sub
        End If


        'Objects for mmCRM DataBase
        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString3.ToString()
        Dim con1 As New SqlConnection(conStr1)
        ' Code for Updating and Inserting data's
        Dim a1 As String
        a1 = ddlselect.SelectedItem.Text
        Dim str, x, y, a() As String
        str = a1
        Dim i As Integer
        a = str.Split("-")
        x = a(0)
        If (x = txtFID.Text) Then
            Try
                If con.State = ConnectionState.Closed Then con.Open()
                ' Checking whether the Dropdownlist is selected or Textbox
                Dim g, b, c As String
                If txtstate.Text = "" Then
                    g = ddlst.SelectedItem.Text.Trim
                Else
                    g = txtstate.Text
                End If
                If txtcty.Text = "" Then
                    b = ddlcty.SelectedItem.Text.Trim
                Else
                    b = txtcty.Text
                End If
                If txtobt.Text = "" Then
                    c = ddlbillterm.SelectedItem.Text.Trim
                Else
                    c = txtobt.Text
                End If
                'Updating to the table forwardermaster
                Dim date2 As Date
                date2 = Now.Date.ToShortDateString
                Dim st As String = Session("UserId")
                Dim cmd1 As New SqlCommand("update Log_ForwardersMaster set F_name='" & txtFname.Text & "',F_Type='" & ddlft.SelectedItem.Text & "',add1='" & txtaddress1.Text & "',add2='" & txtaddress2.Text & "',Offphno1='" & txtFOffNo1.Text & "',Offphno2='" & txtFOffNo2.Text & "',Offfaxno='" & txtofffaxno.Text & "',State='" & g & "',Country='" & b & "',F_Mailid='" & txtFEmailID.Text & "',con_person='" & txtFCntPerson.Text & "',CMobileno='" & txtFMobileNo.Text & "',CEmailId='" & txtcemail.Text & "',coffno='" & txtoffphno.Text & "',cfaxno='" & txtFFaxNo.Text & "',Billingterms='" & c & "',Deduction='" & txtded.Text & "', modifieddate= '" & date2 & "', modifiedby='" & st & " ', AppointedBy='" & ddltype.SelectedItem.Text & "' where F_id='" & txtFID.Text & "'", con)
                cmd1.ExecuteNonQuery()
                con1.Open()
                Dim cmd2 As New SqlCommand("update suppliermaster set suppliername='" & txtFname.Text & "',shipmentmethod='" & ddlft.SelectedItem.Text & "',address1='" & txtaddress1.Text & "',address2='" & txtaddress2.Text & "',phone1='" & txtFOffNo1.Text & "',phone2='" & txtFOffNo2.Text & "',fax='" & txtofffaxno.Text & "',State='" & g & "',Country='" & b & "',email='" & txtFEmailID.Text & "',contactperson1='" & txtFCntPerson.Text & "',phone4='" & txtFMobileNo.Text & "',phone3='" & txtoffphno.Text & "',faxno1='" & txtFFaxNo.Text & "',terms='" & c & "' where suppliercode='" & txtFID.Text & "'", con1)
                cmd2.ExecuteNonQuery()
                con1.Close()

                msg("Record Updated")
            Catch ex As ConstraintException
                msg("Forwarder ID Already Exists")
            Finally
                If con.State = ConnectionState.Open Then con.Close()
                'To clear the values in the controls
                Call clearall()
            End Try
        Else

            Try
                If con.State = ConnectionState.Closed Then con.Open()
                'Assigning the values to the Datarow to insert into the table
                Dim row1 As DataRow
                row1 = ds.Tables("ds1").NewRow
                row1.Item(0) = txtFID.Text
                row1.Item(1) = txtFname.Text.Trim
                row1.Item(2) = ddlft.SelectedItem.Text.Trim
                row1.Item(3) = txtaddress1.Text.Trim
                row1.Item(4) = txtaddress2.Text.Trim
                row1.Item(5) = txtFOffNo1.Text.Trim
                row1.Item(6) = txtFOffNo2.Text.Trim
                row1.Item(7) = txtofffaxno.Text.Trim
                ' Checking whether the Dropdownlist is selected or Textbox
                If txtstate.Text = "" Then
                    row1.Item(8) = ddlst.SelectedItem.Text.Trim
                Else
                    row1.Item(8) = txtstate.Text
                End If
                If txtcty.Text = "" Then
                    row1.Item(9) = ddlcty.SelectedItem.Text.Trim
                Else
                    row1.Item(9) = txtcty.Text
                End If

                row1.Item(10) = txtFEmailID.Text.Trim
                row1.Item(11) = txtFCntPerson.Text.Trim
                row1.Item(12) = txtFMobileNo.Text.Trim
                row1.Item(13) = txtcemail.Text.Trim
                row1.Item(14) = txtoffphno.Text.Trim
                row1.Item(15) = txtFFaxNo.Text.Trim
                row1.Item(18) = Session("UserId")
                row1.Item(19) = Session("UserId")
                row1.Item(20) = Date.Now.ToShortDateString
                row1.Item(21) = Date.Now.ToShortDateString
                row1.Item(22) = Session("UserId")
                row1.Item(23) = ddltype.SelectedItem.Text.Trim
                If txtobt.Text = "" Then
                    row1.Item(16) = ddlbillterm.SelectedItem.Text.Trim
                Else
                    row1.Item(16) = txtobt.Text
                End If
                row1.Item(17) = txtded.Text.Trim
                ds.Tables("ds1").Rows.Add(row1)
                da.Update(ds, "ds1")
                con1.Open()
                ' Checking whether the Dropdownlist is selected or Textbox
                Dim s, g, m As String
                If txtstate.Text = "" Then
                    s = ddlst.SelectedItem.Text.Trim
                Else
                    s = txtstate.Text
                End If
                If txtcty.Text = "" Then
                    g = ddlcty.SelectedItem.Text.Trim
                Else
                    g = txtcty.Text
                End If
                If txtobt.Text = "" Then
                    m = ddlbillterm.SelectedItem.Text.Trim
                Else
                    m = txtobt.Text
                End If
                'Inserting the values into the table Suppliermaster
                If con1.State = ConnectionState.Closed Then con1.Open()
                Dim cmd2 As New SqlCommand("insert into suppliermaster(registrationno,suppliercode,suppliername,shipmentmethod,suppliercategory,address1,address2,phone1,phone2,fax,state,country,email,contactperson1,phone4,phone3,faxno1,terms, datekeyin, keyinby, Status, deletestatus) values('" & txtFID.Text & "','" & txtFID.Text & "','" & txtFname.Text.Trim & "','" & ddlft.SelectedItem.Text & "','" & "FWD" & "','" & txtaddress1.Text & "','" & txtaddress2.Text & "','" & txtFOffNo1.Text & "','" & txtFOffNo2.Text & "','" & txtofffaxno.Text & "','" & s & "','" & g & "','" & txtFEmailID.Text & "','" & txtFCntPerson.Text & "','" & txtFMobileNo.Text & "','" & txtcemail.Text & "','" & txtoffphno.Text & "','" & m & "','" & Now.Date & "','" & Session("UserId") & "','A','N')", con1)
                cmd2.ExecuteNonQuery()
                If con1.State = ConnectionState.Open Then con1.Close()

                ''Inserting the values into the table Forwarders master
                'If con.State = ConnectionState.Closed Then con.Open()
                'Dim cmdin As New SqlCommand("insert into log_forwardersMaster (F_id ,F_name, F_type, add1,add2,Offphno1,OffPhNo2, OffFaxNo , state,country,F_mailId , con_person, cMobileNo , cEMailId, COffNo, BillingTerms, Deduction, CreatedBy, CreatedDate, AppointedBy) values('" & txtFID.Text & "','" & txtFname.Text.Trim & "','" & ddlft.SelectedItem.Text & "','" & txtaddress1.Text & "','" & txtaddress2.Text & "','" & txtFOffNo1.Text & "','" & txtFOffNo2.Text & "','" & txtofffaxno.Text & "','" & s & "','" & g & "','" & txtFEmailID.Text & "','" & txtFCntPerson.Text & "','" & txtFMobileNo.Text & "','" & txtcemail.Text & "','" & txtoffphno.Text & "','" & m & "','" & txtded.Text & "','" & Session("UserId") & "','" & Now & "','" & ddltype.SelectedItem.Text & "')", con)
                'cmdin.ExecuteNonQuery()

                msg("Record Inserted")
                Dim cmd1 As New SqlCommand("FM_selectid", con)
                cmd1.CommandType = CommandType.StoredProcedure
                Dim dr As SqlDataReader
                dr = cmd1.ExecuteReader()
                ddlselect.Items.Insert(0, " - Select - ")
                While (dr.Read())
                    str3 = dr(0) & "-" & dr(1)
                    ddlselect.Items.Add(str3)
                End While
                dr.Close()
                'con.Close()
            Catch ex As ConstraintException
                msg("Forwarder ID Number Already Exists")
            Finally
                'Clear the values from the controls
                con.Close()
                'Call clearall()
            End Try
        End If
        ddlselect.Items.Clear()
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            'Fetching Forwarderid using procedure
            Dim cmd As New SqlCommand("FM_selectid", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim dr1 As SqlDataReader
            dr1 = cmd.ExecuteReader()
            ddlselect.Items.Insert(0, " - Select - ")
            While (dr1.Read())
                str3 = dr1(0) & "-" & dr1(1)
                ddlselect.Items.Add(str3)
            End While
            dr1.Close()
            con.Close()
            'If Session("IsForwarder") = 1 Then
            Session("Email") = ""
            Session("forwcode") = ""
            msg("Successufully Registered")
            txtFname.Enabled = False
            txtaddress1.Enabled = False
            txtaddress2.Enabled = False
            txtstate.Enabled = False
            txtcty.Enabled = False
            txtFOffNo1.Enabled = False
            txtFOffNo2.Enabled = False
            ddlft.Enabled = False
            ddlst.Enabled = False
            ddlcty.Enabled = False
            txtofffaxno.Enabled = False
            txtFEmailID.Enabled = False
            txtFCntPerson.Enabled = False
            txtFMobileNo.Enabled = False
            txtoffphno.Enabled = False
            txtFFaxNo.Enabled = False
            txtcemail.Enabled = False
            ddlbillterm.Enabled = False
            txtobt.Enabled = False
            txtded.Enabled = False
            btnSubmit.Enabled = False
            btnClear.Enabled = False
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Sub clearall()
        'To Clear the values in the appropriate controls
        ddlselect.ClearSelection()
        txtFID.Text = ""
        txtFname.Text = ""
        txtaddress1.Text = ""
        txtaddress2.Text = ""
        txtFOffNo1.Text = ""
        txtFOffNo2.Text = ""
        txtofffaxno.Text = ""
        txtstate.Text = ""
        txtcty.Text = ""
        ddlcty.ClearSelection()
        ddlst.Items.Clear()
        ddlcty.Items.Clear()
        txtFEmailID.Text = ""
        txtFCntPerson.Text = ""
        txtFMobileNo.Text = ""
        txtcemail.Text = ""
        txtoffphno.Text = ""
        txtFFaxNo.Text = ""
        ddlbillterm.ClearSelection()
        ddlbillterm.Items.Clear()
        txtobt.Text = ""
        txtded.Text = ""
        crlro()
    End Sub

    Sub crlro()
        Try

            'Code for Fetching the State,Country,Billingterms from Forwardermaster
            con.Open()
            Dim cmd2 As New SqlCommand("FM_selectst", con)
            cmd2.CommandType = CommandType.StoredProcedure
            Dim dr2 As SqlDataReader
            dr2 = cmd2.ExecuteReader()
            ddlst.Items.Insert(0, " - Select - ")
            While (dr2.Read())
                ddlst.Items.Add(dr2(0))
            End While
            dr2.Close()
            Dim cmd3 As New SqlCommand("FM_selectcy", con)
            cmd3.CommandType = CommandType.StoredProcedure
            Dim dr3 As SqlDataReader
            dr3 = cmd3.ExecuteReader()
            ddlcty.Items.Insert(0, " - Select - ")
            While (dr3.Read())
                ddlcty.Items.Add(dr3(0))
            End While
            dr3.Close()
            Dim cmd4 As New SqlCommand("FM_selectbt", con)
            cmd4.CommandType = CommandType.StoredProcedure
            Dim dr4 As SqlDataReader
            dr4 = cmd4.ExecuteReader()
            ddlbillterm.Items.Insert(0, " - Select - ")
            While (dr4.Read())
                ddlbillterm.Items.Add(dr4(0))
            End While
            dr4.Close()
            ddlft.Items.Clear()
            ddlft.Items.Insert(0, " -Select - ")
            ddlft.Items.Insert(1, "Airways")
            ddlft.Items.Insert(2, "Shiping")
            ddlft.Items.Insert(3, "Truck")
            ddlft.Items.Insert(4, "Courier")
            ddlft.Items.Insert(5, "Both Air-Ship")
            ddlft.Items.Insert(6, "All")
        Catch ex As Exception

        End Try
        con.Close()

    End Sub
    Sub countrec()
        con.Open()
        'Counting the Total No of Records
        Try
            dr = cmd.ExecuteReader
            totrec = 0
            While dr.Read
                totrec = totrec + 1
            End While
        Catch ex As Exception

        End Try

        con.Close()
    End Sub
    Sub findrec(ByVal recno As Int32)
        'Finding the Particular Record
        Dim i As Int16
        i = 0
        While Not i = recno
            dr.Read()
            i = i + 1
        End While
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Call clearall()
        ddlselect.ClearSelection()
    End Sub

    Private Sub ddlselect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlselect.SelectedIndexChanged
        'Code for Fetching the Already Existing Forwarders
        If ddlselect.SelectedItem.Text = " - Select - " Then
            'Say("Sorry, Please select a Forwarder Id! " & _
            'Microsoft.VisualBasic.vbNewLine & _
            '"Please try again.")
            Call clearall()


            If Session("IsEmployee") = 1 Or Session("CAdmin") = True Then
                If ddlselect.SelectedItem.Text = " - Select - " Then
                    If con.State = ConnectionState.Closed Then con.Open()
                    Dim cmd1 As New SqlCommand("SPSelect_FWDMaxID", con)
                    cmd1.CommandType = CommandType.StoredProcedure
                    Dim dr As SqlDataReader
                    dr = cmd1.ExecuteReader()
                    While (dr.Read())
                        Dim xx = dr(0)
                        Dim yy = Right(xx, 3)
                        Dim s As String = Val(yy) + 1

                        Dim Shivaa = Len(s)
                        If Val(Shivaa) = 3 Then
                            Shivaa = s
                        ElseIf Val(Shivaa) = 2 Then
                            Shivaa = "0" & s
                        ElseIf Val(Shivaa) = 1 Then
                            Shivaa = "00" & s
                        End If
                        txtFID.Text = "FWD00" & Shivaa
                    End While
                    dr.Close()
                    If con.State = ConnectionState.Open Then con.Close()
                End If
            End If
            '-----------
            Exit Sub
        End If
        Dim a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20, a21 As String
        a1 = ddlselect.SelectedItem.Text
        Dim str, x, y, a() As String
        str = a1
        Dim i As Integer
        a = str.Split("-")
        x = a(0)
        If (x = Session("forwarderid")) Then
            txtFname.Enabled = True
            txtaddress1.Enabled = True
            txtaddress2.Enabled = True
            txtstate.Enabled = True
            txtcty.Enabled = True
            txtFOffNo1.Enabled = True
            txtFOffNo2.Enabled = True
            ddlft.Enabled = True
            ddlst.Enabled = True
            ddlcty.Enabled = True
            txtofffaxno.Enabled = True
            txtFEmailID.Enabled = True
            txtFCntPerson.Enabled = True
            txtFMobileNo.Enabled = True
            txtoffphno.Enabled = True
            txtFFaxNo.Enabled = True
            txtcemail.Enabled = True
            ddlbillterm.Enabled = True
            txtobt.Enabled = True
            txtded.Enabled = True
            btnSubmit.Enabled = True
            btnClear.Enabled = True
        ElseIf (x <> Session("forwarderid")) Then
            txtFname.Enabled = False
            txtaddress1.Enabled = False
            txtaddress2.Enabled = False
            txtstate.Enabled = False
            txtcty.Enabled = False
            txtFOffNo1.Enabled = False
            txtFOffNo2.Enabled = False
            ddlft.Enabled = False
            ddlst.Enabled = False
            ddlcty.Enabled = False
            txtofffaxno.Enabled = False
            txtFEmailID.Enabled = False
            txtFCntPerson.Enabled = False
            txtFMobileNo.Enabled = False
            txtoffphno.Enabled = False
            txtFFaxNo.Enabled = False
            txtcemail.Enabled = False
            ddlbillterm.Enabled = False
            txtobt.Enabled = False
            txtded.Enabled = False
            btnSubmit.Enabled = False
            btnClear.Enabled = False
        End If
        If Session("isemployee") = 1 Or Session("CAdmin") = True Or Session("employee") = True Then
            txtFname.Enabled = True
            txtaddress1.Enabled = True
            txtaddress2.Enabled = True
            txtstate.Enabled = True
            txtcty.Enabled = True
            txtFOffNo1.Enabled = True
            txtFOffNo2.Enabled = True
            ddlft.Enabled = True
            ddlst.Enabled = True
            ddlcty.Enabled = True
            txtofffaxno.Enabled = True
            txtFEmailID.Enabled = True
            txtFCntPerson.Enabled = True
            txtFMobileNo.Enabled = True
            txtoffphno.Enabled = True
            txtFFaxNo.Enabled = True
            txtcemail.Enabled = True
            ddlbillterm.Enabled = True
            txtobt.Enabled = True
            txtded.Enabled = True
            btnSubmit.Enabled = True
            btnClear.Enabled = True
        End If
        con.Open()
        'Calling the procedure
        Try
            Dim cmd2 As New SqlCommand("FM_select", con)
            cmd2.CommandType = CommandType.StoredProcedure
            Dim dr2 As SqlDataReader
            dr2 = cmd.ExecuteReader()
            While (dr2.Read())
                a2 = dr2.Item(0)
                a3 = dr2.Item(1)
                If Not IsDBNull(dr2.Item(2)) Then
                    a4 = dr2.Item(2)
                End If
                If Not IsDBNull(dr2.Item(3)) Then
                    a5 = dr2.Item(3)
                End If
                If Not IsDBNull(dr2.Item(4)) Then
                    a6 = dr2.Item(4)
                End If
                If Not IsDBNull(dr2.Item(5)) Then
                    a7 = dr2.Item(5)
                End If
                If Not IsDBNull(dr2.Item(6)) Then
                    a8 = dr2.Item(6)
                End If
                If Not IsDBNull(dr2.Item(7)) Then
                    a9 = dr2.Item(7)
                End If
                If Not IsDBNull(dr2.Item(8)) Then
                    a10 = dr2.Item(8)
                End If
                If Not IsDBNull(dr2.Item(9)) Then
                    a11 = dr2.Item(9)
                End If
                If Not IsDBNull(dr2.Item(10)) Then
                    a12 = dr2.Item(10)
                End If
                If Not IsDBNull(dr2.Item(11)) Then
                    a13 = dr2.Item(11)
                End If
                If Not IsDBNull(dr2.Item(12)) Then
                    a14 = dr2.Item(12)
                End If
                If Not IsDBNull(dr2.Item(13)) Then
                    a15 = dr2.Item(13)
                End If
                If Not IsDBNull(dr2.Item(14)) Then
                    a16 = dr2.Item(14)
                End If
                If Not IsDBNull(dr2.Item(15)) Then
                    a17 = dr2.Item(15)
                End If
                If Not IsDBNull(dr2.Item(16)) Then
                    a18 = dr2.Item(16)
                End If
                If Not IsDBNull(dr2.Item(17)) Then
                    a19 = dr2.Item(17)
                End If

                If (x = a2) Then
                    txtFID.Text = a2
                    txtFname.Text = a3
                    ddlft.SelectedItem.Text = a4
                    txtaddress1.Text = a5
                    txtaddress2.Text = a6
                    txtFOffNo1.Text = a7
                    txtFOffNo2.Text = a8
                    txtofffaxno.Text = a9
                    ddlst.Items.Clear()
                    ddlst.Items.Add(a10)
                    ddlcty.Items.Clear()
                    ddlcty.Items.Add(a11)
                    txtFEmailID.Text = a12
                    txtFCntPerson.Text = a13
                    txtFMobileNo.Text = a14
                    txtcemail.Text = a15
                    txtoffphno.Text = a16
                    txtFFaxNo.Text = a17
                    ddlbillterm.Items.Clear()
                    ddlbillterm.Items.Add(a18)
                    txtded.Text = a19
                End If
            End While
        Catch ex As Exception

        End Try
        con.Close()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'con.Close()
        'Navigate to the Main Page
        If Session("IsForwarder") = 2 Then
            FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
            Response.Redirect("../HRMIS/Default.aspx")
        Else
            Response.Redirect("../HRMIS/Default.aspx")
        End If
    End Sub

    'Private Sub Linkbutton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Linkbutton1.Click
    '    Call mynet.ChkLastLogin(Session("userID"))
    '    FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
    '    Response.Redirect("../logout.aspx")
    'End Sub

    'Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
    '    FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
    '    If Session("CAdmin") = True Then
    '        Response.Redirect("../logsticsMain.aspx")
    '    ElseIf Session("employee") = True Then
    '        Response.Redirect("../Employee/Emphome.aspx")
    '    ElseIf Session("IsForwarder") = 2 Then
    '        'Call mynet.ChkLastLogin(Session("userID"))
    '        FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
    '        Response.Redirect("../logout.aspx")
    '    Else
    '        Response.Redirect("../logsticsMain.aspx")
    '    End If
    'End Sub

    Protected Sub ddlbillterm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlbillterm.SelectedIndexChanged

    End Sub
End Class
