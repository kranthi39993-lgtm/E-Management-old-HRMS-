Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmRolesNRights
    Inherits System.Web.UI.Page
    Dim mynet As New Emanagement.netglobal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
     
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        Dim row As GridViewRow

        For Each row In GridView1.Rows

            Dim ChkBoxCell As CheckBox = row.FindControl("checkbox1")

            If ChkBoxCell.Checked Then

                Dim RoleId As String = CType(row.Cells(0).Text, String)

                Dim row2 As GridViewRow
                Dim SystemId, ModuleId
                For Each row2 In GridView2.Rows
                    Dim chkboxCell2 As CheckBox = row2.FindControl("checkbox1")
                    If chkboxCell2.Checked Then
                        SystemId = CType(row2.Cells(0).Text, String)
                        ModuleId = CType(row2.Cells(2).Text, String)
                    End If

                    Dim i
                    Dim ScrTypeId
                    Dim status
                    For i = 0 To CheckBoxList1.Items.Count - 1
                        ScrTypeId = CheckBoxList1.Items(i).Value
                        If CheckBoxList1.Items(i).Selected Then
                            status = "1"
                        Else
                            status = "0"
                        End If
                        'insert / update code
                        Try
                            mynet.db_cn()
                            mynet.db_open()
                            Call mynet.dbSp_open("Sp_InsUpdRolesNRights")
                            command.Parameters.AddWithValue("@roleid", RoleId)
                            command.Parameters.AddWithValue("@Systemid", SystemId)
                            command.Parameters.AddWithValue("@moduleid", ModuleId)
                            command.Parameters.AddWithValue("@scrtypeid", ScrTypeId)
                            command.Parameters.AddWithValue("@scrstatus", status)
                            command.ExecuteNonQuery()
                            mynet.db_close()
                            LblMsg.Text = "Congratulations! You have Saved successfully. "
                            LblMsg.ForeColor = Drawing.Color.DarkGreen
                        Catch ex As Exception
                            LblMsg.Text = ex.Message
                            LblMsg.ForeColor = Drawing.Color.Red
                        End Try
                    Next

                Next

                'SqlDataSource2.Update()

            End If

        Next

    End Sub
End Class