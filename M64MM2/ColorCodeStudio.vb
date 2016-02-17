Public Class ColorCodeStudio
    Private Sub ColorButton_Click(sender As Object, e As EventArgs) Handles HatButton1.Click, HatButton4.Click, HatButton3.Click, HatButton2.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            Dim senderButton As Button = DirectCast(sender, Button)
            senderButton.BackColor = ColorDialog1.Color
            Dim colorData As String
            colorData = FixZeroHexByte(Hex(senderButton.BackColor.R)) & FixZeroHexByte(Hex(senderButton.BackColor.G)) & FixZeroHexByte(Hex(senderButton.BackColor.B)) & "00"
            Dim bytes As String = colorData.Substring(6, 2) & colorData.Substring(4, 2) & colorData.Substring(2, 2) & colorData.Substring(0, 2)
            WriteXBytes("Project64", MainForm.Base + &H07EC38, bytes)
        End If
    End Sub
End Class