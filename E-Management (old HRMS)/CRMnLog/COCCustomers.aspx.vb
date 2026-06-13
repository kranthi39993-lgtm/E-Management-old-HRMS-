
Imports E_Management.CRMlognetglobal
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Partial Public Class COCCustomers
    Inherits Messagebox


    Dim Cmd As New SqlCommand
    Dim Ad As New SqlDataAdapter
    Dim TmpDs As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        If IsPostBack = False Then
            Cmd = New SqlCommand("SELECT Distinct Cust_ID,Customer FROM  CustMaster order by customer", con1)
            Ad = New SqlDataAdapter(Cmd)
            TmpDs = New DataSet()
            Ad.Fill(TmpDs, "Verify")

            DGView1.DataSource = TmpDs.Tables(0)

            DGView1.DataBind()


            Dim Item As GridViewRow

            For Each Item In DGView1.Rows

                Dim CustId As String = Item.Cells(1).Text

                Cmd = New SqlCommand("Select * From Log_COCCustomer Where CustomerId='" & CustId & "'", con1)
                Ad = New SqlDataAdapter(Cmd)
                TmpDs = New DataSet
                Ad.Fill(TmpDs, "COC")

                Dim Chk1 As CheckBox = (Item.Cells(0).FindControl("ChkBx1"))
                Dim Cmb As DropDownList = (Item.Cells(0).FindControl("FrmType1"))
                If TmpDs.Tables(0).Rows.Count >= 1 Then
                    If TmpDs.Tables(0).Rows(0).Item(3) = 1 Then
                        Chk1.Checked = True
                        Cmb.Text = TmpDs.Tables(0).Rows(0).Item(8)
                    End If
                End If
            Next
  
        End If

                con1.Close()

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ob As New CRMlognetglobal
        Dim conStr1
        ob.db_cn()
        conStr1 = ob.sConnString

        Dim con1 As New SqlConnection(conStr1)
        con1.Open()

        Dim Item As GridViewRow

        For Each Item In DGView1.Rows
            Dim Chk1 As CheckBox = (Item.Cells(0).FindControl("ChkBx1"))
            Dim Cmb As DropDownList = (Item.Cells(3).FindControl("FrmType1"))

            If Chk1.Checked = True Then

                Dim CustId As String = Item.Cells(1).Text
                Dim CustName As String = Item.Cells(2).Text
                Dim CocStatus As Integer = 1

                If Cmb.Text = "-Select-" Then
                    msg("Please Select Valid Form Type for the Customer : " & CustName)
                    Exit Sub
                End If

                Cmd = New SqlCommand("Select * From Log_COCCustomer Where CustomerId='" & CustId & "'", con1)
                TmpDs = New DataSet
                Ad = New SqlDataAdapter(Cmd)
                Ad.Fill(TmpDs, "COC")

                

                If TmpDs.Tables(0).Rows.Count >= 1 Then
                    Cmd = New SqlCommand("Update Log_COCCustomer Set COCStatus=1, FormType='" & Cmb.Text & "' Where CustomerId='" & CustId & "'", con1)
                    Cmd.ExecuteNonQuery()
                Else
                    Cmd = New SqlCommand("Insert Into Log_COCCustomer(CustomerId, CustomerName, COCStatus, CreatedBy, CreatedOn, FormType) Values('" & CustId & "','" & CustName & "'," & CocStatus & ",'" & Session("empcode").ToString & "','" & DateTime.Now & "','" & Cmb.Text & "')", con1)
                    Cmd.ExecuteNonQuery()
                End If

            End If

        Next
        msg("Successfully Updated")
        con1.Close()
    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FormsAuthentication.RedirectFromLoginPage(Session("userID"), True)
        Response.Redirect("../HRMIS/Default.aspx")
    End Sub
End Class