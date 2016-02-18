Imports System.Drawing.Imaging

Public Class ColorCodeStudio
    'TO DO: Add ability to reset colors to default, as well as load current CC from game or from copy/paste.
    'Also, make ColorDialog1's currently selected color to be the color of the pressed button, so that users
    'can easily modify the previous color.

    Private hatColorMap As New ColorMap()
    Private hairColorMap As New ColorMap()
    Private skinColorMap As New ColorMap()
    Private pantsColorMap As New ColorMap()
    Private glovesColorMap As New ColorMap()
    Private shoesColorMap As New ColorMap()

    Private DefaultColors(23) As Color
    Private IsResettingDefaults As Boolean = False

    Private Sub ColorButton_Click(sender As Object, e As EventArgs) Handles _
         HatButton3.Click, HatButton1.Click, SkinButton3.Click, SkinButton1.Click, ShoesButton3.Click, ShoesButton1.Click, PantsButton3.Click, PantsButton1.Click, HairButton3.Click, HairButton1.Click, GlovesButton3.Click, GlovesButton1.Click

        Dim senderButton As Button = DirectCast(sender, Button)
        ColorDialog1.Color = senderButton.BackColor
        Dim avgHatColor As Color = Color.FromArgb((HatButton1.BackColor.R + HatButton3.BackColor.R) / 2, (HatButton1.BackColor.G + HatButton3.BackColor.G) / 2, (HatButton1.BackColor.B + HatButton3.BackColor.B) / 2)
        hatColorMap.OldColor = avgHatColor

        If IsResettingDefaults = True OrElse ColorDialog1.ShowDialog() = DialogResult.OK Then

            If Not IsResettingDefaults Then senderButton.BackColor = ColorDialog1.Color

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
            If Not IsResettingDefaults Then
                PictureBox1.Refresh()
            End If
        End If
    End Sub

    Private Sub ColorCodeStudio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Save the default colors as what they are when the form loads
        Dim buttonIndex As Integer
        For Each control As Control In Controls
            If TypeOf control Is Button Then
                Dim foundButton As Button = DirectCast(control, Button)
                'If the button has no text, it's a color-selection button
                If foundButton.Text = "" Then
                    DefaultColors(buttonIndex) = foundButton.BackColor
                    buttonIndex += 1
                End If
            End If
        Next
    End Sub

    Private Sub RestoreDefaults(sender As Object, e As EventArgs) Handles DefaultButton.Click
        'Set the default colors to what they were saved as when the form first loaded
        Dim buttonIndex As Integer
        IsResettingDefaults = True
        For Each control As Control In Controls
            If TypeOf control Is Button Then
                Dim foundButton As Button = DirectCast(control, Button)
                'If the button has no text, it's a color-selection button
                If foundButton.Text = "" Then
                    foundButton.BackColor = DefaultColors(buttonIndex)
                    foundButton.PerformClick()
                    buttonIndex += 1
                End If
            End If
        Next
        IsResettingDefaults = False
    End Sub

    Private Sub LoadFromRam(sender As Object, e As EventArgs) Handles LoadRamButton.Click
        Dim addresses As Integer() = {&H07EC38, &H07EC3C, &H07EC40, &H07EC44, &H07EC98, &H07EC9C, &H07ECA0, &H07ECA4, &H07EC80, &H07EC84, &H07EC88, &H07EC8C, &H07EC20, &H07EC24, &H07EC28, &H07EC2C, &H07EC50, &H07EC54, &H07EC58, &H07EC5C, &H07EC68, &H07EC6C, &H07EC70, &H07EC74}
        Dim val As Byte() = BigEndianRead("Project64", MainForm.Base + addresses(0), 4)
        HatButton1.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(1), 4)
        'HatButton2.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(2), 4)
        HatButton3.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(3), 4)
        'HatButton4.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(4), 4)
        HairButton1.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(5), 4)
        'HairButton2.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(6), 4)
        HairButton3.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(7), 4)
        'HairButton4.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(8), 4)
        SkinButton1.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(9), 4)
        'SkinButton2.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(10), 4)
        SkinButton3.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(11), 4)
        'SkinButton4.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(12), 4)
        PantsButton1.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(13), 4)
        'PantsButton2.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(14), 4)
        PantsButton3.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(15), 4)
        'PantsButton4.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(16), 4)
        GlovesButton1.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(17), 4)
        'GlovesButton2.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(18), 4)
        GlovesButton3.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(19), 4)
        'GlovesButton4.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(20), 4)
        ShoesButton1.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(21), 4)
        'ShoesButton2.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(22), 4)
        ShoesButton3.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(23), 4)
        'ShoesButton4.BackColor = Color.FromArgb(val(0), val(1), val(2))
    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Dim image As New Bitmap(PictureBox1.Image)
        Dim imageAttributes As New ImageAttributes()
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height

    End Sub
End Class