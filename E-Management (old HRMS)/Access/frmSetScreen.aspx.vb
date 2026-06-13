Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmSetScreen
    Inherits System.Web.UI.Page
    Dim mynet As New emanagement.netglobal
    Dim MyGlobal As New emanagement.globalinfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Len(Trim(DrpDwnSystem.SelectedValue.ToString)) <> 0 Then
            Dim SystemId = DrpDwnSystem.SelectedValue
            If Len(Trim(DrpdwnModule.SelectedValue.ToString)) <> 0 Then
                Dim ModuleId = DrpdwnModule.SelectedValue
                If Len(Trim(DrpDwnScrtype.SelectedValue.ToString)) <> 0 Then
                    Dim ScrtypeId = DrpDwnScrtype.SelectedValue
                    If Len(Trim(TxtBoxScreenName.Text)) <> 0 Then
                        Dim ScrName = Trim(TxtBoxScreenName.Text)
                        Dim filename = FileUpload1.FileName & ""
                        If Len(Trim(filename)) <> 0 Then
                            If Len(Trim(TxtBoxString.Text)) <> 0 Then
                                Dim StringtoElem = Trim(TxtBoxString.Text) & ""
                                Dim ScrDesc = Trim(TxtBoxScrDesc.Text) & ""
                                Dim PanelName = Trim(TxtBoxPanel.Text) & ""
                                filename = Trim(StringtoElem) & filename
                                Try
                                    mynet.db_cn()
                                    mynet.db_open()
                                    Call mynet.dbSp_open("Sp_InsUpdScreens")
                                    command.Parameters.AddWithValue("@Systemid", SystemId)
                                    command.Parameters.AddWithValue("@moduleid", ModuleId)
                                    command.Parameters.AddWithValue("@scrtypeid", ScrtypeId)
                                    command.Parameters.AddWithValue("@scrname", ScrName)
                                    command.Parameters.AddWithValue("@pathdesc", filename)
                                    command.Parameters.AddWithValue("@scrdesc", ScrDesc)
                                    command.Parameters.AddWithValue("@panelvisible", PanelName)

                                    command.ExecuteNonQuery()
                                    mynet.db_close()
                                    LblMsg.Text = "Congratulations! You have Saved successfully. "
                                    LblMsg.ForeColor = Drawing.Color.DarkGreen
                                    GridView1.DataBind()
                                Catch ex As Exception
                                    LblMsg.Text = ex.Message
                                    LblMsg.ForeColor = Drawing.Color.Red
                                End Try
                            Else
                                LblMsg.Text = "Please enter string to eliminate"
                                LblMsg.ForeColor = Drawing.Color.Red
                            End If
                        Else
                            LblMsg.Text = "Please select File Name"
                            LblMsg.ForeColor = Drawing.Color.Red
                        End If
                    Else
                        LblMsg.Text = "Please enter Screen Name"
                        LblMsg.ForeColor = Drawing.Color.Red
                    End If
                Else
                    LblMsg.Text = "Please select Screen Type"
                    LblMsg.ForeColor = Drawing.Color.Red
                End If
                Else
                    LblMsg.Text = "Please select Module "
                    LblMsg.ForeColor = Drawing.Color.Red
                End If
            Else
                LblMsg.Text = "Please select System "
                LblMsg.ForeColor = Drawing.Color.Red
            End If
    End Sub

    Private Sub FileUpload1_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileUpload1.DataBinding
        Dim aa
        aa = FileUpload1.FileName
    End Sub
End Class