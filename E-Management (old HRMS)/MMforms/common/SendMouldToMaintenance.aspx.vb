Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports e_management.emanagement.globalinfo
Imports e_management.emanagement.EMSapplications
Imports e_management.emanagement.[Global]
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security

Partial Public Class SendMouldToMaintenance
    Inherits System.Web.UI.Page

    Dim mynet As New Emanagement.netglobal
    Dim MyGlobal As New Emanagement.globalinfo

    Dim SlNo
    Dim Product
    Dim MouldNo
    Dim MouldName
    Dim Renew
    Dim Service
    Dim Shedderbreak
    Dim Sheddermark
    Dim SlitlineNampakShallow
    Dim SlitlineShallow
    Dim SlitlineDeep
    Dim PinBreak
    Dim SlitlineShifted
    Dim TholeShifted
    Dim OutlineProblem
    Dim SendMouldToJapan
    Dim TholeBurr
    Dim EdgeChip
    Dim PumpingBar
    Dim Washing
    Dim Additional1
    Dim Additional2
    Dim Additional3
    Dim Additional4
    Dim DefectivePoint
    Dim Reason
    Dim PressShotOutline
    Dim PressShotGreenSheet
    Dim WDupper
    Dim WDlower
    Dim LDupper
    Dim LDlower
    Dim Afterwashing
    Dim AfterpinShaving
    Dim AfterRenew
    Dim RprMalaysia
    Dim RprJapan
    Dim RprStandBy
    Dim RepairingRecommendation
    Dim RepairingMethod
    Dim MouldCheckedBy
    Dim MouldCheckedDate
    Dim QCAcknowledgedBy
    Dim QCackDate
    Dim PressIncharge
    Dim PressDate
    Dim MMIncharge
    Dim MMdate
    Dim MMOK
    Dim MMNG
    Dim QCOK
    Dim QCNG
    Dim Status
    Dim FinalStatus

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''' get maximum serial number from tbl MRRS '''''
        
        TxtLastUsedOn.Text = CDate(Now)

        If IsPostBack = False Then
            Session("fgid") = "21"
            LoadData()

        End If
    End Sub

    Private Sub LoadData()
        If Session("fgid").ToString.Equals("21") Then
            Dim Ad As New SqlDataAdapter
            Dim Ds As New DataSet
            Cmd = New SqlCommand

            Con = New SqlConnection("User Id=sa;Password=;Data Source=192.168.0.248;Initial Catalog=Slitline")
            Con.Open()

            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "SP_SelectMouldData"
            Cmd.Parameters.Clear()
            Cmd.Parameters.AddWithValue("@Options", "MachineNo")
            Cmd.Parameters.AddWithValue("@MouldNo", "MouldNo")

            Cmd.Connection = Con
            Ad = New SqlDataAdapter(Cmd)
            Ds = New DataSet
            Ad.Fill(Ds, "Details")

            Dim Tmpi As Integer = 0
            CmbPressMachine.Items.Clear()
            For Tmpi = 0 To Ds.Tables(0).Rows.Count - 1
                CmbPressMachine.Items.Add(Ds.Tables(0).Rows(Tmpi).Item(0))
            Next


            'Cmd.Parameters.Clear()
            'Cmd.Parameters.AddWithValue("@Options", "Product")
            'Cmd.Parameters.AddWithValue("@MouldNo", "MouldNo")

            'Cmd.Connection = Con
            'Ad = New SqlDataAdapter(Cmd)
            'Ds = New DataSet
            'Ad.Fill(Ds, "Details")

            'CmbProductName.Items.Clear()
            'For Tmpi = 0 To Ds.Tables(0).Rows.Count - 1
            '    CmbProductName.Items.Add(Ds.Tables(0).Rows(Tmpi).Item(0))
            'Next


            Cmd.Parameters.Clear()
            Cmd.Parameters.AddWithValue("@Options", "MouldNo")
            Cmd.Parameters.AddWithValue("@MouldNo", "MouldNo")

            Cmd.Connection = Con
            Ad = New SqlDataAdapter(Cmd)
            Ds = New DataSet
            Ad.Fill(Ds, "Details")

            DrpDwnMould.Items.Clear()
            For Tmpi = 0 To Ds.Tables(0).Rows.Count - 1
                DrpDwnMould.Items.Add(Ds.Tables(0).Rows(Tmpi).Item(0))
            Next

            Con.Close()

        End If
    End Sub


    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ''' get maximum serial number from tbl MRRS '''''

        RepairingMethod = ""
        LblMsg.Text = ""
        LblMsg.ForeColor = Drawing.Color.Red

        If TxtMMIncharge.Text.Trim.Equals("") Then
            LblMsg.Text = "Please enter mould maintenance incharge!"
            Exit Sub
        End If

        If TxtPressIncharge.Text.Trim.Equals("") Then
            LblMsg.Text = "Please enter press incharge!"
            Exit Sub
        End If


        If TxtLastUsedOn.Text.Trim.Equals("") Then
            LblMsg.Text = "Please enter last used on date!"
            Exit Sub
        End If


        If TxtOperatorID.Text.Trim.Equals("") Then
            LblMsg.Text = "Please enter operator EMP ID!"
            Exit Sub
        End If

        If TxtReason.Text.Trim.Equals("") Then
            LblMsg.Text = "Please enter reason!"
            Exit Sub
        End If

        If DrpDwnMould.Text = "" Then
            LblMsg.Text = "Select Mould Number"
            Exit Sub
        End If

        If DrpDwnMouldName.Text = "" Then
            LblMsg.Text = "Select Mould Name"
            Exit Sub
        End If


        If DrpdwnProduct.Text = "" Then
            LblMsg.Text = "Select Mould Number"
            Exit Sub
        End If


        If CmbPressMachine.Text = "" Then
            LblMsg.Text = "Select Pressing Machine Name"
            Exit Sub
        End If


        mynet.db_cn()
        mynet.dbM_open()
 

        Product = DrpdwnProduct.SelectedItem.Text
        MouldNo = DrpDwnMould.SelectedItem.Text
        MouldName = DrpDwnMouldName.Text & ""

        Dim Str As String
        Str = ""

        
        If ChkRenew.Checked = True Then
            Str = Str + "Renew,"
        End If

        If ChkService.Checked = True Then
            Str = Str + "Service,"
        End If

        If ChkShedderBreak.Checked = True Then
            Str = Str + "Shedder Break,"
        End If

        If ChkShedderMark.Checked = True Then
            Str = Str + "Shedder Mark,"
        End If

        If ChkNampakShallow.Checked = True Then
            Str = Str + "Slit Line Nampak Shallow,"
        End If

        If ChkShallow.Checked = True Then
            Str = Str + "Slit Line Shallow,"
        End If

        If ChkDeep.Checked = True Then
            Str = Str + "Slit Line Deep,"
        End If

        If ChkPinBreak.Checked = True Then
            Str = Str + "Pin Break,"
        End If

        If ChkShifted.Checked = True Then
            Str = Str + "Slit Line Shifted,"
        End If

        If ChkTHoleShifted.Checked = True Then
            Str = Str + "Thruhole Shifted,"
        End If

        If ChkEdgeChip.Checked = True Then
            Str = Str + "Edge Chip,"
        End If

        If ChkOP.Checked = True Then
            Str = Str + "Out Line Problem,"
        End If

        If ChkBurr.Checked = True Then
            Str = Str + "Thruhole Burr,"
        End If

        If ChkEdgeChip.Checked = True Then
            EdgeChip = 1
        Else
            EdgeChip = 0
        End If


        If ChkBar.Checked = True Then
            Str = Str + "Pumbing Bar,"
        End If

        If ChkWashing.Checked = True Then
            Str = Str + "Washing,"
        End If

        If Str.Length <= 1 Then
            LblMsg.Text = "Please Select Defect Details!"
            Exit Sub
        End If

        Str = Str.TrimEnd(",")

        PressIncharge = TxtPressIncharge.Text & ""
        MMIncharge = TxtMMIncharge.Text & ""

        If ChkBxInternal.Checked = True Then
            RepairingMethod = "Internal"
        ElseIf ChkBxJapan.Checked = True Then
            RepairingMethod = "Japan"
        End If

        If RepairingMethod.Length <= 1 Then
            LblMsg.Text = "Please Select Repairing Method!"
            Exit Sub
        End If

        LblMsg.ForeColor = Drawing.Color.Green

        Try
            mynet.db_cn()
            mynet.dbM_open()
            Call mynet.dbSpM_open("SP_Insert_MouldRepairData")


            command.Parameters.AddWithValue("@SLNO", 0)
            command.Parameters.AddWithValue("@Product", Product)
            command.Parameters.AddWithValue("@MouldNo", MouldNo)
            command.Parameters.AddWithValue("@MouldName", MouldName)
            command.Parameters.AddWithValue("@RepairingMethod", RepairingMethod)
            command.Parameters.AddWithValue("@DefectDetails", Str)
            command.Parameters.AddWithValue("@Reason", TxtReason.Text)
            command.Parameters.AddWithValue("@OperatorID", TxtOperatorID.Text)
            command.Parameters.AddWithValue("@LastUsedOn", TxtLastUsedOn.Text)
            command.Parameters.AddWithValue("@PressIncharge", PressIncharge)
            command.Parameters.AddWithValue("@MMIncharge", MMincharge)
            command.Parameters.AddWithValue("@CreatedBy", Session("empcode").ToString)
            command.Parameters.AddWithValue("@M_DeliveryDate", DateTime.Now)
            command.Parameters.AddWithValue("@PressingMachine", CmbPressMachine.Text)

         
            command.ExecuteNonQuery()


        

            Dim Ds As DataSet
            Dim Dr As DataRow
            Ds = mynet.Update_EMPmaster_status(dbConnWeb, daConnWeb, 2, "Select IsNull(Max(SLNO),0) as SLNo  From Tbl_MMRepairData ")
            If Ds.Tables(0).Rows.Count <> 0 Then
                Dr = Ds.Tables(0).Rows(0)
                SlNo = Val(Dr("SLNO") & "")
            Else
            SlNo = 1
            End If

            mynet.dbM_close()
            '''''''''



            LblMsg.Text = "Congratulations! You have Saved successfully. "
            LblMsg.ForeColor = Drawing.Color.DarkGreen
            Session("purl") = "SendMouldToMaintenance.aspx"

            Session("options") = "production"
            Session("reqno") = SlNo
            Response.Redirect("PrintProductionRequest.aspx")
        Catch ex As Exception
            LblMsg.Text = ex.Message
            LblMsg.ForeColor = Drawing.Color.Red
        End Try

    End Sub

   

    

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Calendar1.Visible = True
    End Sub

     

   

    Protected Sub Calendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        TxtLastUsedOn.Text = ""
        TxtLastUsedOn.Text = Calendar1.SelectedDate
        Calendar1.Visible = False
    End Sub
 
   
    
    Protected Sub DrpDwnMould_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpDwnMould.SelectedIndexChanged
        Dim Ad As New SqlDataAdapter
        Dim Ds As New DataSet
        Cmd = New SqlCommand

        Con = New SqlConnection("User Id=sa;Password=;Data Source=192.168.0.248;Initial Catalog=Slitline")
        Con.Open()

        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_SelectMouldData"
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@Options", "MouldName")
        Cmd.Parameters.AddWithValue("@MouldNo", DrpDwnMould.Text)

        Cmd.Connection = Con
        Ad = New SqlDataAdapter(Cmd)
        Ds = New DataSet
        Ad.Fill(Ds, "Details")

        Dim Tmpi As Integer = 0
        DrpDwnMouldName.Items.Clear()
        For Tmpi = 0 To Ds.Tables(0).Rows.Count - 1
            DrpDwnMouldName.Items.Add(Ds.Tables(0).Rows(Tmpi).Item(0))
        Next

    End Sub

   
    Protected Sub ChkBxInternal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBxInternal.CheckedChanged
        If ChkBxInternal.Checked = True Then
            ChkBxJapan.Checked = False
        End If


    End Sub

    Protected Sub ChkBxJapan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBxJapan.CheckedChanged
        If ChkBxInternal.Checked = True Then
            ChkBxInternal.Checked = False
        End If
    End Sub
End Class