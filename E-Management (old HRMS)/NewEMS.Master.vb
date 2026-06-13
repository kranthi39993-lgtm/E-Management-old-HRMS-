Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports E_Management.emanagement.[Global]

Partial Public Class NewEMS
    Inherits System.Web.UI.MasterPage

    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim Mynet As New Emanagement.netglobal

    Private Sub form1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Init
        If Session("empcode") = "" Then
            Response.Redirect("http://mmsbsql1/emgmt/hrmis/login.aspx")
        Else
            GlobalDsRights = getEmpActScreens(Session("empcode").ToString)
        End If
    End Sub

    Private Sub form1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.PreRender
        Dim validatorOverrideScripts As String = "<script src='/EMSScripts/validator.js' type='text/javascript'></script>"
        Me.Page.ClientScript.RegisterStartupScript(Me.GetType, "ValidatorOverrideScripts", validatorOverrideScripts, False)
        MyBase.OnPreRender(e)
        'Session("empcode") = "014543"
        'Session("_edept") = "9000"
        'Session("_esect") = "9000"
    End Sub

    Protected Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empcode") = "" Then
            Response.Redirect("http://mmsbsql1/emgmt/hrmis/login.aspx")
        End If
        If Not IsPostBack Then

            Dim ipaddress As String
            ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If ipaddress = "" Or ipaddress Is Nothing Then
                ipaddress = Request.ServerVariables("REMOTE_ADDR")
            End If

            If (ipaddress.Equals("192.168.4.90")) Then
                Menu1.Visible = False
                ImageButton1.Visible = True
                ImageButton2.Visible = True
                ImageButton3.Visible = True
                LinkButton2.Visible = True
                LinkButton3.Visible = True
                LinkButton4.Visible = True

            Else
                ImageButton1.Visible = False
                ImageButton2.Visible = False
                ImageButton3.Visible = False
                LinkButton2.Visible = False
                LinkButton3.Visible = False
                LinkButton4.Visible = False
                PopulateMenu()
            End If



        End If
    End Sub
    Function GetMenuData() As DataSet
        'MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        Dim dadCats As New _
        SqlDataAdapter("SELECT * FROM tbl_systems order by systemid", con)
        Dim dst As New DataSet()
        dadCats.Fill(dst, "tbl_systems")
        Return dst
    End Function

    Function GetModData() As DataSet
        MyGlobal.Con_Str()
        Dim con1 As New SqlConnection(constr)
        Dim dadMods As New _
        SqlDataAdapter("SELECT * FROM tbl_modules order by moduleid", con1)
        Dim dst1 As New DataSet()
        dadMods.Fill(dst1, "tbl_modules")
        Return dst1
    End Function

    Function GetScrData() As DataSet
        MyGlobal.Con_Str()
        Dim con2 As New SqlConnection(constr)
        Dim dadScrs As New _
        SqlDataAdapter("SELECT * FROM tbl_Screens order by scrid", con2)
        Dim dst2 As New DataSet()
        dadScrs.Fill(dst2, "tbl_Screens")
        Return dst2
    End Function

    Function GetSubMenuData() As DataSet
        'MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        Dim dadCats As New _
        SqlDataAdapter("SELECT * FROM tbl_modules", con)
        Dim dadProducts As New _
        SqlDataAdapter("SELECT * FROM tbl_screens", con)
        Dim dst As New DataSet()
        dadCats.Fill(dst, "tbl_systems")
        dadProducts.Fill(dst, "tbl_modules")
        dst.Relations.Add("childrensub", _
        dst.Tables("tbl_systems").Columns("moduleid"), _
        dst.Tables("tbl_modules").Columns("scrid"))
        Return dst
    End Function

    Sub PopulateMenu()
        If LoggedIn = True Then
            Dim dst As New DataSet
            dst = getEmpActSystems(Session("empcode").ToString)
            Dim dst1 As New DataSet
            dst1 = getEmpActModules(Session("empcode").ToString)
            Dim dst2 As New DataSet
            dst2 = getEmpActScreens(Session("empcode").ToString)
            ''' here we add one more global dataset with a new name and assgin some thing like this..
            ''' GlobalDsRights = dst2
            ''' and everywhere we use that GlobalDsRights...

            For Each masterRow As DataRow In dst.Tables(0).Rows()
                Dim masterItem As New MenuItem(masterRow("systemname").ToString())
                Menu1.Items.Add(masterItem)
                For Each ModRow As DataRow In dst1.Tables(0).Select("systemid='" & masterRow("sysid").ToString() & "'")
                    Dim childItem As New MenuItem(ModRow("modulename").ToString())
                    masterItem.ChildItems.Add(childItem)
                    'childItem.NavigateUrl = "~/webform1.aspx"
                    For Each ScrRow As DataRow In dst2.Tables(0).Select("systemid='" & masterRow("sysid").ToString() & "' and moduleid='" & ModRow("modid").ToString() & "'")
                        Dim childSubItem As New MenuItem(ScrRow("scrname").ToString())
                        If ScrRow("scrstatus") <> 0 Then
                            childItem.ChildItems.Add(childSubItem)
                            childSubItem.NavigateUrl = ScrRow("pathdesc").ToString()
                        End If
                    Next
                Next
            Next
        End If

        ''''''''''''' APPRAISAL CODE 

        Dim dshod As DataSet
        Dim drhod As DataRow
        Dim lvl
        dshod = Getdlevel()
        If dshod.Tables(0).Rows.Count > 0 Then
            drhod = dshod.Tables(0).Rows(0)
            lvl = drhod("dlevel").ToString
        End If

        If lvl >= 4 Then

            Dim dsapp As New DataSet
            Dim drapp As DataRow
            Dim app
            dsapp = getAppraisalLogin()

            If dsapp.Tables(0).Rows.Count > 0 Then
                drapp = dsapp.Tables(0).Rows(0)
                app = drapp("appraisal").ToString
            Else
                app = 0
            End If
            If app <> "1" Then
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("hrmis_insAppraisalLogin")
                Cmd.Parameters.AddWithValue("@empcode", Session("empcode").ToString)
                Cmd.ExecuteNonQuery()
                InsertAppraisalData()
            End If
        End If

    End Sub
    Function getEmpActSystems(ByVal empcode As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Sp_GetEmpActSystems", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@empcode", empcode)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "empsystems")
        con.Close()
        Return ds
    End Function
    Function getEmpActModules(ByVal empcode As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Sp_GetEmpActModules", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@empcode", empcode)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "empmodules")
        con.Close()
        Return ds
    End Function
    Function getEmpActScreens(ByVal empcode As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Sp_GetEmpActScreens", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@empcode", empcode)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "empscreens")
        con.Close()
        Return ds
    End Function

    Private Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
        ' If Menu1.menu Then
    End Sub
    'Protected Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
    '    Call mynet.ChkLastLogin(Session("EMPCODE"))
    '    FormsAuthentication.RedirectFromLoginPage(Session("empcode"), True)
    '    Session.Abandon()
    '    Response.Redirect("http://mmsbsql1/emgmt/hrmis/login.aspx")
    '    'FormsAuthentication.SignOut()
    '    'FormsAuthentication.RedirectToLoginPage()
    'End Sub

    ''' <summary>
    ''' APPRAISAL CODING FOR ALERT STARTS HERE
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Function Getdlevel() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select dlevel from designation where designationname=(select designation from empmaster where empcode='" & Session("empcode") & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIlvl")
        con.Close()
        Return ds
    End Function
    Function getAppraisalLogin() As DataSet
        Dim dt As Date
        dt = DateTime.Now.ToShortDateString
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("hrmis_GetAppraisalLoginDet", con)
        Command.CommandType = CommandType.StoredProcedure
        'Command.Parameters.AddWithValue("@empcode", empcode)
        Command.Parameters.AddWithValue("@dt", dt)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "appdata")
        con.Close()
        Return ds
    End Function
    ''' <summary>
    ''' GET PROBATION EXPIRY DETAILS
    ''' </summary>
    ''' <remarks></remarks>

    Private Sub InsertAppraisalData()
        Dim doj As Date
        Dim desig, emp
        Dim dsemp, dsemp1 As DataSet
        Dim dremp, dremp1 As DataRow
        Dim i1, I
        Dim cmd1, cmd2 As New SqlCommand
        Dim dra, dra1 As SqlDataReader
        Dim da As SqlDataAdapter
        Dim prob1, prob2
        Dim fstat
        Dim datediff As Date
        Dim dateexp As Date
        Dim dlevel
        Dim foreign

        '' Get Probation Expiry Employee Details

        dsemp = GetProbEmp()
        If dsemp.Tables(0).Rows.Count <> 0 Then
            Dim lcount = dsemp.Tables(0).Rows.Count
            For i = 0 To lcount - 1
                dremp = dsemp.Tables(0).Rows(i)
                doj = dremp("dateofjoin").ToString
                desig = dremp("designation").ToString
                emp = dremp("empcode").ToString
                foreign = dremp("foreignemp").ToString
                If foreign = "N" Then
                    Dim con As New SqlConnection(constr)
                    con.Open()
                    cmd1 = New SqlCommand("Select * from designation where designationname = '" & desig & "'", con)
                    dra = cmd1.ExecuteReader()

                    While (dra.Read())
                        prob1 = Double.Parse(dra("probation").ToString())
                        Dim dsp As DataSet
                        Dim drp As DataRow
                        dsp = GetProbation(emp)
                        If dsp.Tables(0).Rows.Count <> 0 Then
                            drp = dsp.Tables(0).Rows(0)
                            prob2 = Double.Parse(drp("months").ToString())
                            prob1 = prob1 + prob2
                        End If
                        dateexp = doj.AddMonths(prob1)
                        If dateexp > "01/01/2012" Then
                            Dim dtdiff = dateexp.Subtract(Date.Now).Days
                            If (dtdiff <= 30) Then
                                Try
                                    Call MyGlobal.dbSp_open("hrmis_Insertappraisal@login")
                                    Cmd.Parameters.AddWithValue("@empcode", emp)
                                    Cmd.Parameters.AddWithValue("@probation", prob1)
                                    Cmd.ExecuteNonQuery()
                                Catch ex As Exception

                                End Try
                            End If
                        End If

                    End While
                    Cmd.Dispose()
                End If

            Next
        End If

        '' Get Contract Expiry Employee Details

        Dim contract
        Dim contracteffectivefrom As Date
        dsemp1 = GetContractEmp()
        If dsemp1.Tables(0).Rows.Count <> 0 Then
            Dim lcount2 = dsemp1.Tables(0).Rows.Count
            For i1 = 0 To lcount2 - 1

                dremp1 = dsemp1.Tables(0).Rows(i1)
                doj = dremp1("dateofjoin").ToString
                desig = dremp1("designation").ToString
                emp = dremp1("empcode").ToString
                contract = dremp1("contract").ToString
                foreign = dremp1("foreignemp").ToString
                If foreign = "Y" Then
                    If Not dremp1("extendcontract") Is System.DBNull.Value Then
                        If dremp1("extendcontract") = "Y" Then
                            If Not dremp1("contracteffectivefrom") Is System.DBNull.Value Then
                                contracteffectivefrom = dremp1("contracteffectivefrom")
                                dateexp = contracteffectivefrom.AddMonths(contract)
                            Else
                                dateexp = doj.AddMonths(contract)
                            End If
                        Else
                            dateexp = doj.AddMonths(contract)
                        End If
                    Else
                        dateexp = doj.AddMonths(contract)
                    End If
                    If dateexp > "01/01/2012" Then
                        Dim dtdiff = dateexp.Subtract(Date.Now).Days
                        If (dtdiff <= 60) Then
                            Try
                                Call MyGlobal.dbSp_open("hrmis_Insertappraisalcontract@login")
                                Cmd.Parameters.AddWithValue("@empcode", emp)
                                Cmd.Parameters.AddWithValue("@expiry", dateexp)
                                Cmd.ExecuteNonQuery()

                            Catch ex As Exception

                            End Try
                        End If
                    End If

                    Cmd.Dispose()
                End If

            Next
        End If
    End Sub
    Function GetProbEmp() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from empmaster where emptype <> 'Confirmed' and resigned = 'N' and nationality <> 'JAP' and foreignemp = 'N' order by empcode", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "emp")
        con.Close()
        Return ds
    End Function
    Function GetProbation(ByVal empcode As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from emp_probationextend where empcode = '" & empcode & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "empprob")
        con.Close()
        Return ds
    End Function
    Function GetContractEmp() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from empmaster where emptype = 'Contract'  and resigned = 'N' and nationality <> 'JAP' and foreignemp = 'Y' order by empcode", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "emp")
        con.Close()
        Return ds
    End Function

    Protected Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Call Mynet.ChkLastLogin(Session("EMPCODE"))
        FormsAuthentication.RedirectFromLoginPage(Session("empcode"), True)
        Session.Abandon()
        Response.Redirect("http://mmsbsql1/emgmt/hrmis/login.aspx")
    End Sub

    Protected Sub ImageButton3_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("http://mmsbsql1/emgmt/HRMIS/Clinic/clinicform.aspx")
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Response.Redirect("http://mmsbsql1/emgmt/HRMIS/GatePass/GPform.aspx")
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("http://mmsbsql1/emgmt/HRMIS/leave/Leaveform.aspx")
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Response.Redirect("http://mmsbsql1/emgmt/HRMIS/leave/Leaveform.aspx")
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        Response.Redirect("http://mmsbsql1/emgmt/HRMIS/GatePass/GPform.aspx")
    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
        Response.Redirect("http://mmsbsql1/emgmt/HRMIS/Clinic/clinicform.aspx")
    End Sub
End Class