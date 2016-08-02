Public Class ShadowFunctions
    Public Shared Addresses As Long() = {&H7EC30, &H7EC48, &H7EC60, &H7EC78, &H7EC90, &H7ECA8}
    Public Shared Sub RestoreAllShadeValues(Restore As Boolean)

        For Each Address As Integer In Addresses
            WriteInteger("Project64", MainForm.Base + Address, &H28282800)
        Next
    End Sub

    Public Shared Sub ChangeShadowX(X As String)
        For Each Address As Long In Addresses
            WriteXBytes("Project64", MainForm.Base + Address + &H3, X)
        Next
    End Sub

    Public Shared Sub ChangeShadowY(Y As String)
        For Each Address As Long In Addresses
            WriteXBytes("Project64", MainForm.Base + Address + &H2, Y)
        Next
    End Sub

    Public Shared Sub ChangeShadowZ(Z As String)
        For Each Address As Long In Addresses
            WriteXBytes("Project64", MainForm.Base + Address + &H1, Z)
        Next
    End Sub
End Class
