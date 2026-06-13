Imports System.Web.Security
Imports System.Text.RegularExpressions
Imports crmlognetglobal
Imports System.Data.SqlClient
Imports System.Data.DataView
Partial Class QuotationApprovalMaster
    Inherits CRMlognetglobal 'System.Web.UI.Page
    Dim com As New SqlClient.SqlCommand

    Dim MyGlobal As New emanagement.globalinfo
    Dim str As String = MyGlobal.ConCRMStr

    Dim con As New SqlConnection(str)
    Dim con2 As New SqlConnection(str)
    Dim datread As SqlClient.SqlDataReader
    Dim datread2 As SqlClient.SqlDataReader
    Dim objDataAdapter As SqlClient.SqlDataAdapter
    Dim objDataSet As DataSet
    Dim typechange As Boolean
    Dim QueryString As String
    Dim objTable As DataTable
    Public Quotetype As String
    Public fid As String
    Public mynet As New CRMlognetglobal
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
        If Me.IsPostBack = False Then
            Session("U_ID") = "first"
            rblType.SelectedIndex = 0
            GetDataset()
        End If
    End Sub

    Sub GetDataset()
        'Binding the Grid
        detailsgrid.Visible = True
        If con.State = ConnectionState.Open Then con.Close()
        con.Open()
        If rblType.SelectedIndex = 0 Then
            Quotetype = "No"
        ElseIf rblType.SelectedIndex = 1 Then
            Quotetype = "Approved"
        ElseIf rblType.SelectedIndex = 2 Then
            Quotetype = "On Hold"
        ElseIf rblType.SelectedIndex = 3 Then
            Quotetype = "Rejected"
        End If
        Try
            Dim cmd As New SqlClient.SqlCommand("select distinct Fqno, f_id, ApprovedStatus from log_VehicleQuotation where ApprovedStatus='" & Quotetype & "'", con)
            'Dim cmd As New SqlClient.SqlCommand("select f_id,flightno,deptplace,arrivalplace,CurrName,OthExpen,approvedstatus,rid from log_flightquotation", con)
            Dim adap As New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet
            adap.Fill(ds, "log_VehicleQuotation")
            dg.DataSource = ds
            detailsgrid.Visible = True
            dg.DataBind()
        Catch ex As Exception
            msg(ex.Message)
        End Try
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'Go Back to Previous Screen
        FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub

    Sub selectfid(ByVal objArgs As DataGridCommandEventArgs)
        'Showing the OtherExpenses Details
        Dim dp, ap, qno
        dp = objArgs.Item.Cells(5).Text
        ap = objArgs.Item.Cells(6).Text
        fid = objArgs.Item.Cells(2).Text
        qno = objArgs.Item.Cells(1).Text
        txtfid.Text = fid
        'QueryString = "select distinct a.OtherFees,a.Amount, b.F_name as 'Fowarwarders Name', a.DeptPlace as 'Departure', a.ArrivalPlace as 'Arrival', a.EffectiveDate from log_forotherexpensedump a,log_forwardersmaster b where a.F_id=b.F_id and b.F_name= '" & txtfid.Text & "' and a.DeptPlace='" & dp & "' and a.ArrivalPlace='" & ap & "' and a.QuoteNo='" & qno & "'"
        QueryString = "select distinct a.OtherFees,a.Amount, a.MinimumAmount, a.DeptPlace as 'Departure', a.ArrivalPlace as 'Arrival', a.EffectiveDate from log_forotherexpensedump a,log_forwardersmaster b where a.F_id=b.F_id and b.F_name= '" & txtfid.Text & "' and a.DeptPlace='" & dp & "' and a.ArrivalPlace='" & ap & "' and a.QuoteNo='" & qno & "'"
        objDataSet = New DataSet
        objDataAdapter = New SqlClient.SqlDataAdapter(QueryString, con)
        Try
            objDataAdapter.Fill(objDataSet, "log_forotherexpensedump")
        Catch ex As Exception
            Response.Write("Exception " & ex.Message & " Selectfid")
        End Try
        feesgrid.Visible = True
        objTable = objDataSet.Tables("log_forotherexpensedump")
        feesgrid.DataSource = objTable.DefaultView
        feesgrid.DataBind()
    End Sub

    Sub selectitem2(ByVal objArgs As DataGridCommandEventArgs)
        detailsgrid.Visible = False
        'Showing Product Details
        Dim k As Integer
        Dim objTable As DataTable = Session("ObjectTable")
        Dim ridno, fqno
        'fqno = objArgs.Item.Cells(1).Text
        'fid = objArgs.Item.Cells(2).Text
        Dim lbl As Label
        lbl = objArgs.Item.FindControl("lblqno") 'dgItem.FindControl("lblQNo")
        fqno = lbl.Text

        lbl = objArgs.Item.FindControl("lblfid")
        fid = lbl.Text
        txtfid.Text = fid

        'QueryString = "select b.F_name,a.airwaysname,a.Flightno,a.deptplace,a.arrivalplace,a.weight,a.Amount,a.currname,a.othexpen from log_flightapproval a,log_forwardersmaster b where a.F_id=b.F_id "
        'QueryString = "select a.FQno as 'QuoteNo', b.F_name,a.TransportName,a.VehicleNo,a.DepartPlace as 'Departure',a.ArrivalPlace as 'Arrival',a.Weight,a.Amount,a.Currname as 'Currency' , a.EffectiveDate,a.MinimumCharge, a.RevisionNo from log_VehicleQuotation a,log_forwardersmaster b where a.F_id=b.F_id and a.FQno='" & fqno & "' order by arrival, transportname"
        QueryString = "select a.FQno as 'QuoteNo', b.F_name,a.TransportName,a.VehicleNo,a.DepartPlace as 'Departure',a.ArrivalPlace as 'Arrival',a.Weight,a.Amount,a.MinimumCharge, a.Currname as 'Currency' , a.EffectiveDate from log_VehicleQuotation a,log_forwardersmaster b where a.F_id=b.F_id and a.FQno='" & fqno & "' order by arrival, transportname"
        objDataSet = New DataSet
        objDataAdapter = New SqlClient.SqlDataAdapter(QueryString, con)
        Try
            objDataAdapter.Fill(objDataSet, "log_VehicleQuotation")
            objTable = objDataSet.Tables("log_VehicleQuotation")
            detailsgrid.DataSource = objTable.DefaultView
            detailsgrid.Visible = True
            detailsgrid.DataBind()
        Catch ex As Exception
            Response.Write("Exception " & ex.Message & " Selectitem2")
        End Try
    End Sub

    Private Sub dg_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg.ItemCommand
        'Seleting the Events
        Try
            Select Case (CType(e.CommandSource, LinkButton)).CommandName
                Case "Select"
                    selectitem2(e)
            End Select
        Catch ex As Exception
            msg(ex.ToString())
        End Try
    End Sub
    Sub dg_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dg.PageIndexChanged

        dg.CurrentPageIndex = e.NewPageIndex
        detailsgrid.Visible = False
        feesgrid.Visible = False

        Try
            GetDataset()
        Catch ex As Exception
            msg(ex.Message & " dg_page")
        End Try
    End Sub
    Private Sub rblType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblType.SelectedIndexChanged
        Try
            dg.CurrentPageIndex = 0
            dg.Visible = False
            GetDataset()
            dg.Visible = True
            detailsgrid.Visible = False
            feesgrid.Visible = False
        Catch ex As Exception
            msg(ex.Message & " rbltype")
        End Try
    End Sub

    ''''
    'Sub dg_Page(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
    '    dg.CurrentPageIndex = e.NewPageIndex
    '    'BindGrid()
    'End Sub

    'Sub ShowStats()
    '    lblCurrentIndex.Text = "CurrentPageIndex is " & MyDataGrid.CurrentPageIndex
    '    lblPageCount.Text = "PageCount is " & MyDataGrid.PageCount
    'End Sub

    ''''''

    Private Sub detailsgrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles detailsgrid.ItemCommand
        'Selecting the Events
        Select Case (CType(e.CommandSource, LinkButton)).CommandName
            Case "Select"
                selectfid(e)
        End Select
    End Sub

    Private Sub dg_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg.EditCommand
        detailsgrid.Visible = False
        feesgrid.Visible = False
        selectitem2(e)
        'Datagrid Edit
        dg.EditItemIndex = e.Item.ItemIndex
        GetDataset()
        'detailsgrid.Visible = True
    End Sub

    Private Sub dg_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg.CancelCommand
        'Datagrid Cancel
        detailsgrid.Visible = False
        feesgrid.Visible = False
        dg.EditItemIndex = -1
        GetDataset()
    End Sub

    Private Sub dg_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dg.UpdateCommand
        'Datagrid Update
        Dim Rid, Status, fqno
        fqno = e.Item.Cells(1).Text
        'Rid = e.Item.Cells(1).Text
        fid = e.Item.Cells(2).Text
        Dim opt As RadioButtonList
        opt = CType(e.Item.FindControl("rbList"), RadioButtonList)
        If opt.SelectedIndex > -1 Then
            Status = opt.SelectedItem.Text
        End If
        'Updating the Status
        Dim strSql As String = "Update log_VehicleQuotation set Approvedstatus='" & Status & "'"
        'strSql &= " where Rid=" & Rid
        strSql &= " where FQno='" & fqno & "'"
        If con.State = ConnectionState.Closed Then con.Open()
        Dim cmdupdate As New SqlCommand(strSql, con)
        Dim Result = cmdupdate.ExecuteNonQuery()
        dg.EditItemIndex = -1
        GetDataset()
    End Sub

    Private Sub dg_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dg.ItemDataBound
        'Setting the Approval
        If (e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item) Then
            e.Item.Cells(0).Text = e.Item.DataSetIndex + 1
        End If
        'for displaying status in radiobuttonlist
        'If (e.Item.ItemType = ListItemType.EditItem) Then
        Dim status = DataBinder.Eval(e.Item.DataItem, "Approvedstatus")
        Dim opt As RadioButtonList
        opt = CType(e.Item.FindControl("rbList"), RadioButtonList)
        'If IsDBNull(status) Or CStr(status) = "Approval Pending" Then
        '    opt.SelectedIndex = 3
        'ElseIf CStr(status) = "Approved" Then
        If CStr(status) = "Approved" Then
            opt.SelectedIndex = 0
        ElseIf CStr(status) = "On Hold" Then
            opt.SelectedIndex = 1
        ElseIf CStr(status) = "Rejected" Then
            opt.SelectedIndex = 2
        End If
        'End If
    End Sub

    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        detailsgrid.Visible = False
        feesgrid.Visible = False
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim dgItem As DataGridItem
        Dim chkSelected As RadioButtonList
        Dim lbl As Label
        For Each dgItem In dg.Items
            chkSelected = dgItem.FindControl("rblist")

            If Not chkSelected.SelectedIndex = -1 Then
                Dim Status = chkSelected.SelectedItem.Text
                lbl = dgItem.FindControl("lblQNo")
                Dim QuoteNo As String = lbl.Text

                lbl = dgItem.FindControl("lblfid")
                Dim FID As String = lbl.Text
                'Dim FID = CType(dgItem.FindControl("lblFID"), Label).Text
                'Dim QuoteNo = CType(dgItem.FindControl("lblDONo"), Label).Text
                'God DOInv.01
                If con2.State = ConnectionState.Closed Then con2.Open()

                Dim strSql As String = "Update log_VehicleQuotation set Approvedstatus='" & Status & "'"
                strSql &= " where FQno='" & QuoteNo & "'"
                Dim cmd As New SqlClient.SqlCommand(strSql, con2)
                cmd.ExecuteNonQuery()
                If con2.State = ConnectionState.Open Then con2.Close()
            End If
        Next
        msg("Successfully Updated")
        GetDataset()

    End Sub

End Class
