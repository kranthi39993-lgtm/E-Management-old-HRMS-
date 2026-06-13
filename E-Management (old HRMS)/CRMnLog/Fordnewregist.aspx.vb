Imports E_Management.crmlognetglobal
Imports System.Web.Security
Imports System.Data.SqlClient

Partial Class Fordnewregist
    Inherits System.Web.UI.Page
    Dim myNet As New CRMlognetglobal
    Dim Ccint, intCc, strCc, maxf
    Protected drInsert As DataRow
    'Ravi
    'Protected WithEvents ltlAlert As System.Web.UI.WebControls.Literal
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
        Response.AppendHeader("Refresh", (Session.Timeout * 40 + 60).ToString() + "; URL=../logout.aspx")
        DefaultButton(Page, TxtConPassword, btnSearch)
        Session("UserId") = Session("empcode")
    End Sub
    Public Sub DefaultButton(ByRef Page As System.Web.UI.Page, ByRef objTextControl As System.Web.UI.WebControls.TextBox, ByRef objDefaultButton As Button)

        Dim sScript As New System.Text.StringBuilder

        sScript.Append("<SCRIPT language=""javascript"">" & vbCrLf)
        sScript.Append("function fnTrapKD(btn){" & vbCrLf)
        sScript.Append(" if (document.all){" & vbCrLf)
        sScript.Append("   if (event.keyCode == 13)" & vbCrLf)
        sScript.Append("   { " & vbCrLf)
        sScript.Append("     event.returnValue=false;" & vbCrLf)
        sScript.Append("     event.cancel = true;" & vbCrLf)
        sScript.Append("     btn.click();" & vbCrLf)
        sScript.Append("   } " & vbCrLf)
        sScript.Append(" } " & vbCrLf)
        sScript.Append("}" & vbCrLf)
        sScript.Append("</SCRIPT>" & vbCrLf)

        objTextControl.Attributes.Add("onkeydown", "fnTrapKD(document.all." & objDefaultButton.ClientID & ")")
        Page.RegisterStartupScript("ForceDefaultToScript", sScript.ToString)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Trim(TxtEmail.Text) = "" Then
            Say("Please Enter Valid E-mail ID! " & _
                                   Microsoft.VisualBasic.vbNewLine & _
                                   "Please try again.")

            Exit Sub
        End If
        If Trim(TxtConEmail.Text) = "" Then
            Say("Please Enter Valid Confirm Email ID! " & _
                                               Microsoft.VisualBasic.vbNewLine & _
                                               "Please try again.")
            Exit Sub
        End If
        If Trim(txtUserID.Text) = "" Then
            Say("Please Enter Valid User Name! " & _
                                               Microsoft.VisualBasic.vbNewLine & _
                                               "Please try again.")
            Exit Sub
        End If
        If Trim(txtPassword.Text) = "" Then
            Say("Please Enter Valid Password! " & _
                                               Microsoft.VisualBasic.vbNewLine & _
                                               "Please try again.")
            Exit Sub
        End If

        If Trim(TxtConPassword.Text) = "" Then
            Say("Please Enter Valid Confirm Password! " & _
                                               Microsoft.VisualBasic.vbNewLine & _
                                               "Please try again.")
            Exit Sub
        End If
        If txtPassword.Text <> TxtConPassword.Text Then
            Say("Password & Confirm Password Must be Equal! " & _
                                               Microsoft.VisualBasic.vbNewLine & _
                                               "Please try again.")
            Exit Sub
        End If
        If TxtEmail.Text <> TxtConEmail.Text Then
            Say("E-mail & Confirm E-Mail Must be Equal! " & _
                                               Microsoft.VisualBasic.vbNewLine & _
                                               "Please try again.")
            Exit Sub
        End If

        myNet.db_cn()
        myNet.dbCRM_open()

        ds = myNet.Open_Users(myNet.dbConnWeb, myNet.daConnWeb, 1, "WHERE USERID='" & txtUserID.Text & "'")

        If ds.Tables("USERS").Rows.Count <> 0 Then
            dr = ds.Tables("USERS").Rows(0)
            txtCompUser.Text = dr("userid")
            Comparevalidator1.Validate()
            Comparevalidator1.ErrorMessage = "User already Exists  '" & dr("userid") & "'. Please Try With Another User Name."
            txtCompUser.Text = ""
        Else
            Call CheckCcint()
            ds = New DataSet
            ds = myNet.Open_Users(myNet.dbConnWeb, myNet.daConnWeb, 2, "select * from users")
            'drInsert = ds.Tables("USERS").NewRow()

            'drInsert("userid") = txtUserID.Text
            'drInsert("pwd") = myNet.SimpleCrypt(txtPassword.Text)
            'drInsert("empcustcode") = strCc
            'drInsert("email") = TxtEmail.Text
            'drInsert("firsttime") = 1
            ''drInsert("maxf") = intCc
            'ds.Tables("users").Rows.Add(drInsert)
            'myNet.daConnWeb.Update(ds, "users")

            Dim MyGlobal As New Emanagement.globalinfo
            Dim str As String = MyGlobal.ConCRMStr
            Dim con, con1 As New SqlConnection(str)
            con.Open()

            Dim ccode = "sa"
            strInsert = "insert into users (userid,pwd,empcustcode,email) values ('" & txtUserID.Text & "','" & myNet.SimpleCrypt(txtPassword.Text) & "', '" & ccode & "','" & TxtEmail.Text & "')"

            DBInsert = New SqlCommand(strInsert, con)
            DBInsert.ExecuteNonQuery()

            'myNet.db_close()
            Session("newCust") = txtUserID.Text
            Session("userid") = txtUserID.Text
            Session("Email") = TxtEmail.Text
            Session("forwcode") = strCc
            strUser = Session("userid")
            FormsAuthentication.RedirectFromLoginPage(strUser, True)
            Response.Redirect("ForwarderMaster.aspx")
        End If
    End Sub
    Private Sub Say(ByVal Message As String)
        ' Format string properly
        Message = Message.Replace("'", "\'")
        Message = Message.Replace(Convert.ToChar(10), "\n")
        Message = Message.Replace(Convert.ToChar(13), "")
        ' Display as JavaScript alert
        ltlAlert.Text = "alert('" & Message & "')"
    End Sub
    Private Sub CheckCcint()
        '''''''''''''''''check the maximum FORWcustcode''''''''''''''''''''
        ds1 = myNet.Open_Users(myNet.dbConnWeb, myNet.daConnWeb, 2, "select count(userid) from users")
        If ds1.Tables("users").Rows.Count <> 0 Then
            dr = ds1.Tables("users").Rows(0)
            maxf = dr(0)
            If TypeOf (maxf) Is System.DBNull Then
                intCc = 0
                'intCc += 9000
                strCc = "FWD0000" & intCc
            Else
                intCc = dr(0)
                intCc += 1
                Dim tcc As String = intCc
                If Len(tcc) = 1 Then
                    strCc = "FWD0000" & intCc
                ElseIf Len(tcc) = 2 Then
                    strCc = "FWD000" & intCc
                ElseIf Len(tcc) = 3 Then
                    strCc = "FWD00" & intCc
                ElseIf Len(tcc) = 4 Then
                    strCc = "FWD0" & intCc
                ElseIf Len(tcc) >= 5 Then
                    strCc = "FWD" & intCc
                End If
            End If
        ElseIf ds1.Tables("users").Rows.Count = 0 Then
            intCc = 0
            'intCc += 9000
            strCc = "FWD0000" & intCc
            Session("CCode") = strCc
        End If
    End Sub
    Public Function ChkLastLogin()
        myNet.db_cn()
        myNet.db_open()
        Dim uidHere = Session("userID")
        ds = myNet.Open_Users(myNet.dbConnWeb, myNet.daConnWeb, 2, "select noflogins,Date_time from users WHERE EmpCustCode = '" & uidHere & "' ")
        If ds.Tables("users").Rows.Count > 0 Then
            dr = ds.Tables("users").Rows(0)
            Dim iHere
            Dim dHere
            If Not TypeOf (dr("noflogins")) Is System.DBNull Then
                dr("noflogins") = Val(dr("noflogins")) + 1

                iHere = dr("noflogins")
            Else
                dr("noflogins") = 1
                iHere = 1
            End If
            dr("Date_time") = Now  ' CDate(Format(Now, "dd/MM/yyyy hh:mm"))
            dHere = dr("Date_Time")

            ds = myNet.Open_Users(myNet.dbConnWeb, myNet.daConnWeb, 2, "UPDATE users SET noflogins ='" & iHere & "', Date_Time ='" & dHere & "' WHERE userID = '" & uidHere & "' ")
        End If
        myNet.db_close()
    End Function

    'Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    Call ChkLastLogin()
    '    Response.Redirect("../logout.aspx")
    'End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
        Response.Redirect("../HRMIS/Default.aspx")

    End Sub
End Class
