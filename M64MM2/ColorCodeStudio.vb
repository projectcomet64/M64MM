Public Class ColorCodeStudio
    Private Sub ColorButton_Click(sender As Object, e As EventArgs) Handles HatButton1.Click, HatButton4.Click, HatButton3.Click, HatButton2.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            Dim senderButton As Button = DirectCast(sender, Button)
            senderButton.BackColor = ColorDialog1.Color
            Dim colorData As String
            colorData = FixZeroHexByte(Hex(senderButton.BackColor.R)) & FixZeroHexByte(Hex(senderButton.BackColor.G)) & FixZeroHexByte(Hex(senderButton.BackColor.B)) & "00"
            Dim bytes As String = colorData.Substring(6, 2) & colorData.Substring(4, 2) & colorData.Substring(2, 2) & colorData.Substring(0, 2)

            Dim addressToWrite As Integer = 0
            Select Case senderButton.Name
                Case "HatButton1"
                    addressToWrite = &H07EC38
                Case "HatButton2"
                    addressToWrite = &H07EC3C
                Case "HatButton3"
                    addressToWrite = &H07EC40
                Case "HatButton4"
                    addressToWrite = &H07EC44
                Case "HairButton1"
                    addressToWrite = &H07EC98
                Case "HairButton2"
                    addressToWrite = &H07EC9C
                Case "HairButton3"
                    addressToWrite = &H07ECA0
                Case "HairButton4"
                    addressToWrite = &H07ECA4
                Case "SkinButton1"
                    addressToWrite = &H07EC80
                Case "SkinButton2"
                    addressToWrite = &H07EC84
                Case "SkinButton3"
                    addressToWrite = &H07EC88
                Case "SkinButton4"
                    addressToWrite = &H07EC8C
                Case "PantsButton1"
                    addressToWrite = &H07EC20
                Case "PantsButton2"
                    addressToWrite = &H07EC24
                Case "PantsButton3"
                    addressToWrite = &H07EC28
                Case "PantsButton4"
                    addressToWrite = &H07EC2C
                Case "GlovesButton1"
                    addressToWrite = &H07EC50
                Case "GlovesButton2"
                    addressToWrite = &H07EC54
                Case "GlovesButton3"
                    addressToWrite = &H07EC58
                Case "GlovesButton4"
                    addressToWrite = &H07EC5C
                Case "ShoesButton1"
                    addressToWrite = &H07EC68
                Case "ShoesButton2"
                    addressToWrite = &H07EC6C
                Case "ShoesButton3"
                    addressToWrite = &H07EC70
                Case "ShoesButton4"
                    addressToWrite = &H07EC74
            End Select
            If addressToWrite > 0 Then
                WriteXBytes("Project64", MainForm.Base + addressToWrite, bytes)
            End If
        End If
    End Sub
End Class