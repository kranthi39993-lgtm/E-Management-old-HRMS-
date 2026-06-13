Public Class clientsidepage
    Inherits System.Web.UI.Page

    Public Sub displayalert(ByVal message As String)
        RegisterClientScriptBlock(Guid.NewGuid().ToString(), "<script language=""JavaScript"">" & GetAlertScript(message) & "</script>")
    End Sub
    Public Function GetAlertScript(ByVal message As String) As String
        Return "alert(' " & message.Replace("'", "\'") & "');"
    End Function
End Class
