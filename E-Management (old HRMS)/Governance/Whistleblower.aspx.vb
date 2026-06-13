Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.VCIDapplications3
Imports System.Net.Mail
Imports System.Web.UI.HtmlControls.HtmlTable
Imports E_Management.POclass

Imports CrystalDecisions.CrystalReports.Engine

Imports CrystalDecisions.Shared
Imports System.Net.Security
Imports System.IO

Imports System.Web.UI.Page

Partial Public Class Whistleblower
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SendSMTP()
    End Sub

    Public Sub SendSMTP()
        Try
            If txtSubject.Text.Trim.Equals("") Or txtMessage.Text.Trim.Equals("") Then
                LblResult.Text = "Subject and Message are matatory, please fill the details!"
                Exit Sub
            End If

            'Dim insMail As New MailMessage(New MailAddress(strFrom), New MailAddress(strTo))

            Dim insMail As New MailMessage()
            insMail.From = New MailAddress("feedback@maruwa.com.my")
            insMail.To.Add("nobuhiro.sasaki@maruwa-g.com, yasuhiro.ogawa@maruwa-g.com, sathiaseelan@maruwa.com.my, justin@maruwa.com.my")
            insMail.Subject = txtSubject.Text
            insMail.Body = "From :" & txtName.Text & "" & vbCrLf & txtMessage.Text






            'insMail.Priority = MailPriority.Normal

            Dim smtp As New System.Net.Mail.SmtpClient
            'smtp.Host = "58.26.100.35"
            smtp.Host = "172.16.0.11"
            smtp.Port = 25

            smtp.Send(insMail)
            insMail.Dispose()
            txtSubject.Text = ""
            txtMessage.Text = ""
            txtFrom.Text = ""
            LblResult.Text = "Thank you for your feedback!"
        Catch err As Exception
            'MsgBox(err.Message)
        End Try
    End Sub
End Class