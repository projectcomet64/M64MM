Imports System.Globalization

Public Class ColorCodeStudio
    'These commented variables are part of my failed attempt at making the Mario sprite change
    'color to match the user's selected colors. Un-commenting them does nothing.

    'Private hatColorMap As New ColorMap()
    'Private hairColorMap As New ColorMap()
    'Private skinColorMap As New ColorMap()
    'Private pantsColorMap As New ColorMap()
    'Private glovesColorMap As New ColorMap()
    'Private shoesColorMap As New ColorMap()

    Public returnedCode As String = ""
    Private rand As Random = New Random()
    Private cycleTime As Integer
    Private cycleColors As Boolean = False
    Private CCCopyPaste As ColorCodeCopyPasteForm
    Private DefaultColors(23) As Color
    Private IsSettingAllColors As Boolean = False

    Private Sub ColorButton_Click(sender As Object, e As EventArgs) Handles HatButton3.Click, HatButton1.Click, SkinButton3.Click, SkinButton1.Click,
        ShoesButton3.Click, ShoesButton1.Click, PantsButton3.Click, PantsButton1.Click, HairButton3.Click, HairButton1.Click, GlovesButton3.Click, GlovesButton1.Click

        Dim senderButton As Button = DirectCast(sender, Button)

        'If the current button is disabled, it means we aren't hooked into SM64's memory, so we don't want to do anything or we will probably crash
        If senderButton.Enabled = False Then Exit Sub

        ColorDialog1.Color = senderButton.BackColor
        'Dim avgHatColor As Color = Color.FromArgb((HatButton1.BackColor.R + HatButton3.BackColor.R) / 2, (HatButton1.BackColor.G + HatButton3.BackColor.G) / 2, (HatButton1.BackColor.B + HatButton3.BackColor.B) / 2)
        'hatColorMap.OldColor = avgHatColor

        If IsSettingAllColors = True OrElse ColorDialog1.ShowDialog() = DialogResult.OK Then

            If Not IsSettingAllColors Then senderButton.BackColor = ColorDialog1.Color
            UpdateHatnShirt(0, 0, 0, HatButton3.BackColor)
            Haircut(0, 0, 0, HairButton3.BackColor)
            UpdateOveralls(0, 0, 0, PantsButton3.BackColor)
            UpdateGloves(0, 0, 0, GlovesButton3.BackColor)
            UpdateShoes(0, 0, 0, ShoesButton3.BackColor)
            UpdateSkin(0, 0, 0, SkinButton3.BackColor)
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
            'If Not IsResettingDefaults Then
            '    PictureBox1.Refresh()
            'End If
        End If
    End Sub

    Private Sub ColorCodeStudio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Save the default colors as what they are when the form loads
        AssignDefaults()
    End Sub

    Private Sub AssignDefaults()
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
        IsSettingAllColors = True
        For Each control As Control In Controls
            If TypeOf control Is Button Then
                Dim foundButton As Button = DirectCast(control, Button)
                'If the button has no text, it's a color-selection button
                If foundButton.Text = "" Then
                    foundButton.BackColor = DefaultColors(buttonIndex)
                    foundButton.PerformClick()
                    UpdateHatnShirt(255, 0, 0)
                    Haircut(115, 6, 0)
                    UpdateShoes(115, 6, 0)
                    UpdateOveralls(0, 0, 255)
                    UpdateSkin(254, 193, 121)
                    buttonIndex += 1
                End If
            End If
        Next
        IsSettingAllColors = False
    End Sub

    Public Sub RefreshColorCycle()
        If cycleColors = True Then
            'Uncomment the following If statement and adjust the cap (default = 1) to slow down the refresh rate
            'If cycleTime >= 1 Then
            Dim buttonIndex As Integer
            IsSettingAllColors = True
            For Each control As Control In Controls
                If TypeOf control Is Button Then
                    Dim foundButton As Button = DirectCast(control, Button)
                    'If the button has no text, it's a color-selection button
                    If foundButton.Text = "" Then
                        foundButton.BackColor = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256))
                        'SEIZURE MODE OFF.
                        UpdateHatnShirt(100, 100, 100)
                        Haircut(100, 100, 100)
                        UpdateShoes(100, 100, 100)
                        UpdateOveralls(100, 100, 100)
                        UpdateGloves(100, 100, 100)
                        foundButton.PerformClick()
                        buttonIndex += 1
                    End If
                End If
            Next
            IsSettingAllColors = False
            '    cycleTime = 0
            'Else
            '    cycleTime += 1
            'End If
        End If
    End Sub

    Private Sub LoadFromRam(sender As Object, e As EventArgs) Handles LoadRamButton.Click
        Dim addresses As Integer() = {&H07EC38, &H07EC3C, &H07EC40, &H07EC44, &H07EC98, &H07EC9C, &H07ECA0, &H07ECA4, &H07EC80, &H07EC84, &H07EC88, &H07EC8C, &H07EC20, &H07EC24, &H07EC28, &H07EC2C, &H07EC50, &H07EC54, &H07EC58, &H07EC5C, &H07EC68, &H07EC6C, &H07EC70, &H07EC74}
        Dim val As Byte() = BigEndianRead("Project64", MainForm.Base + addresses(0), 4)
        HatButton1.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(1), 4)
        'HatButton2.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(2), 4)
        HatButton3.BackColor = Color.FromArgb(val(0), val(1), val(2))
        UpdateHatnShirt(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(3), 4)
        'HatButton4.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(4), 4)
        HairButton1.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(5), 4)
        'HairButton2.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(6), 4)
        HairButton3.BackColor = Color.FromArgb(val(0), val(1), val(2))
        Haircut(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(7), 4)
        'HairButton4.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(8), 4)
        SkinButton1.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(9), 4)
        'SkinButton2.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(10), 4)
        SkinButton3.BackColor = Color.FromArgb(val(0), val(1), val(2))
        UpdateSkin(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(11), 4)
        'SkinButton4.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(12), 4)
        PantsButton1.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(13), 4)
        'PantsButton2.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(14), 4)
        PantsButton3.BackColor = Color.FromArgb(val(0), val(1), val(2))
        UpdateOveralls(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(15), 4)
        'PantsButton4.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(16), 4)
        GlovesButton1.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(17), 4)
        'GlovesButton2.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(18), 4)
        GlovesButton3.BackColor = Color.FromArgb(val(0), val(1), val(2))
        UpdateGloves(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(19), 4)
        'GlovesButton4.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(20), 4)
        ShoesButton1.BackColor = Color.FromArgb(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(21), 4)
        'ShoesButton2.BackColor = Color.FromArgb(val(0), val(1), val(2))
        val = BigEndianRead("Project64", MainForm.Base + addresses(22), 4)
        ShoesButton3.BackColor = Color.FromArgb(val(0), val(1), val(2))
        UpdateShoes(val(0), val(1), val(2))
        'val = BigEndianRead("Project64", MainForm.Base + addresses(23), 4)
        'ShoesButton4.BackColor = Color.FromArgb(val(0), val(1), val(2))

        If MessageBox.Show("Do you want to use these colors as default?", "Set as default?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            AssignDefaults()
        End If
    End Sub

    Private Sub ImportColorCode(sender As Object, e As EventArgs) Handles ImportCCButton.Click
        If CCCopyPaste IsNot Nothing AndAlso CCCopyPaste.IsDisposed = False Then
            CCCopyPaste.Close()
        End If

        CCCopyPaste = New ColorCodeCopyPasteForm(False, Me)
        If CCCopyPaste.ShowDialog = DialogResult.OK Then
            Try
                returnedCode = returnedCode.Replace(vbCrLf, "")
                returnedCode = returnedCode.Replace("\n", "")
                Dim len = 13
                Dim splitByLength = Enumerable.Range(0, returnedCode.Length / len).Select(Function(x) returnedCode.Substring(x * len, len)).ToArray()
                Dim colorData As Dictionary(Of String, String) = New Dictionary(Of String, String)
                'Remove the first two characters from the beginning of each line of the code, because it's only used by a GameShark
                'Then, separate the address and value sections of the code
                For line As Integer = 0 To (splitByLength.Length - 1)
                    colorData.Add(splitByLength(line).Split(" ")(0).Substring(2), splitByLength(line).Split(" ")(1))
                Next

                IsSettingAllColors = True
                For code As Integer = 0 To colorData.Count - 2 Step 2
                    Dim R As Byte = Byte.Parse(colorData.Values(code).Substring(0, 2), NumberStyles.HexNumber)
                    Dim G As Byte = Byte.Parse(colorData.Values(code).Substring(2, 2), NumberStyles.HexNumber)
                    Dim B As Byte = Byte.Parse(colorData.Values(code + 1).Substring(0, 2), NumberStyles.HexNumber)
                    Select Case colorData.Keys(code).ToUpper()
                        Case "07EC38"
                            HatButton1.BackColor = Color.FromArgb(R, G, B)
                            HatButton1.PerformClick()
                        Case "07EC40"
                            HatButton3.BackColor = Color.FromArgb(R, G, B)
                            UpdateHatnShirt(R, G, B)
                            HatButton3.PerformClick()
                        Case "07EC98"
                            HairButton1.BackColor = Color.FromArgb(R, G, B)
                            HairButton1.PerformClick()
                        Case "07ECA0"
                            HairButton3.BackColor = Color.FromArgb(R, G, B)
                            Haircut(R, G, B)
                            HairButton3.PerformClick()
                        Case "07EC80"
                            SkinButton1.BackColor = Color.FromArgb(R, G, B)
                            SkinButton1.PerformClick()
                        Case "07EC88"
                            SkinButton3.BackColor = Color.FromArgb(R, G, B)
                            UpdateSkin(R, G, B)
                            SkinButton3.PerformClick()
                        Case "07EC20"
                            PantsButton1.BackColor = Color.FromArgb(R, G, B)
                            PantsButton1.PerformClick()
                        Case "07EC28"
                            PantsButton3.BackColor = Color.FromArgb(R, G, B)
                            UpdateOveralls(R, G, B)
                            PantsButton3.PerformClick()
                        Case "07EC50"
                            GlovesButton1.BackColor = Color.FromArgb(R, G, B)
                            GlovesButton1.PerformClick()
                        Case "07EC58"
                            GlovesButton3.BackColor = Color.FromArgb(R, G, B)
                            UpdateGloves(R, G, B)
                            GlovesButton3.PerformClick()
                        Case "07EC68"
                            ShoesButton1.BackColor = Color.FromArgb(R, G, B)
                            ShoesButton1.PerformClick()
                        Case "07EC70"
                            ShoesButton3.BackColor = Color.FromArgb(R, G, B)
                            UpdateShoes(R, G, B)
                            ShoesButton3.PerformClick()
                    End Select
                Next
                IsSettingAllColors = False
            Catch ex As Exception
                MsgBox("An error occurred while trying to import the color code. Make sure you entered a valid code!" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub ExportColorCode(sender As Object, e As EventArgs) Handles ExportCCButton.Click
        If CCCopyPaste IsNot Nothing AndAlso CCCopyPaste.IsDisposed = False Then
            CCCopyPaste.Close()
        End If

        Dim generatedCode As String = ""
        For Each control As Control In Controls
            If TypeOf control Is Button Then
                Dim button As Button = DirectCast(control, Button)
                If button.Text = "" Then
                    Dim addressToWrite(1) As String
                    Select Case button.Name
                        Case "HatButton1"
                            addressToWrite(0) = "07EC38"
                            addressToWrite(1) = "07EC3A"
                        Case "HatButton2"
                            addressToWrite(0) = "07EC3C"
                            addressToWrite(1) = "07EC3E"
                        Case "HatButton3"
                            addressToWrite(0) = "07EC40"
                            addressToWrite(1) = "07EC42"
                        Case "HatButton4"
                            addressToWrite(0) = "07EC44"
                            addressToWrite(1) = "07EC46"
                        Case "HairButton1"
                            addressToWrite(0) = "07EC98"
                            addressToWrite(1) = "07EC9A"
                        Case "HairButton2"
                            addressToWrite(0) = "07EC9C"
                            addressToWrite(1) = "07EC9E"
                        Case "HairButton3"
                            addressToWrite(0) = "07ECA0"
                            addressToWrite(1) = "07ECA2"
                        Case "HairButton4"
                            addressToWrite(0) = "07ECA4"
                            addressToWrite(1) = "07ECA6"
                        Case "SkinButton1"
                            addressToWrite(0) = "07EC80"
                            addressToWrite(1) = "07EC82"
                        Case "SkinButton2"
                            addressToWrite(0) = "07EC84"
                            addressToWrite(1) = "07EC86"
                        Case "SkinButton3"
                            addressToWrite(0) = "07EC88"
                            addressToWrite(1) = "07EC8A"
                        Case "SkinButton4"
                            addressToWrite(0) = "07EC8C"
                            addressToWrite(1) = "07EC8E"
                        Case "PantsButton1"
                            addressToWrite(0) = "07EC20"
                            addressToWrite(1) = "07EC22"
                        Case "PantsButton2"
                            addressToWrite(0) = "07EC24"
                            addressToWrite(1) = "07EC26"
                        Case "PantsButton3"
                            addressToWrite(0) = "07EC28"
                            addressToWrite(1) = "07EC2A"
                        Case "PantsButton4"
                            addressToWrite(0) = "07EC2C"
                            addressToWrite(1) = "07EC2E"
                        Case "GlovesButton1"
                            addressToWrite(0) = "07EC50"
                            addressToWrite(1) = "07EC52"
                        Case "GlovesButton2"
                            addressToWrite(0) = "07EC54"
                            addressToWrite(1) = "07EC56"
                        Case "GlovesButton3"
                            addressToWrite(0) = "07EC58"
                            addressToWrite(1) = "07EC5A"
                        Case "GlovesButton4"
                            addressToWrite(0) = "07EC5C"
                            addressToWrite(1) = "07EC5E"
                        Case "ShoesButton1"
                            addressToWrite(0) = "07EC68"
                            addressToWrite(1) = "07EC6A"
                        Case "ShoesButton2"
                            addressToWrite(0) = "07EC6C"
                            addressToWrite(1) = "07EC6E"
                        Case "ShoesButton3"
                            addressToWrite(0) = "07EC70"
                            addressToWrite(1) = "07EC72"
                        Case "ShoesButton4"
                            addressToWrite(0) = "07EC74"
                            addressToWrite(1) = "07EC76"
                    End Select
                    generatedCode += "81" & addressToWrite(0) & " " & FixZeroHexByte(Hex(button.BackColor.R)) & FixZeroHexByte(Hex(button.BackColor.G)) & vbCrLf
                    generatedCode += "81" & addressToWrite(1) & " " & FixZeroHexByte(Hex(button.BackColor.B)) & "00" & vbCrLf
                    'Dim bytes As String = colorData.Substring(6, 2) & colorData.Substring(4, 2) & colorData.Substring(2, 2) & colorData.Substring(0, 2)
                End If
            End If
        Next
        CCCopyPaste = New ColorCodeCopyPasteForm(True, Me, generatedCode)
        CCCopyPaste.Show()
    End Sub

    'This was my failed attempt at making the Mario sprite change colors to match your
    ''selected colors. I don't know if I'll ever find a way to make it do that,
    'but if anyone has any ideas, let me know.
    'Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs)
    '    Dim image As New Bitmap(PictureBox1.Image)
    '    Dim imageAttributes As New ImageAttributes()
    '    Dim width As Integer = image.Width
    '    Dim height As Integer = image.Height

    'End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs)
        cycleColors = Not cycleColors
    End Sub

    Private Sub UpdateHatnShirt(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer, Optional ByVal c As Color = Nothing)
        If c = Nothing Then
            capsh1.BackColor = (Color.FromArgb(255, r, g, b))
            capsh2.BackColor = (Color.FromArgb(255, r, g, b))
            capsh3.BackColor = (Color.FromArgb(255, r, g, b))
            capsh4.BackColor = (Color.FromArgb(255, r, g, b))
            capsh5.BackColor = (Color.FromArgb(255, r, g, b))
            capsh6.BackColor = (Color.FromArgb(255, r, g, b))
            capsh7.BackColor = (Color.FromArgb(255, r, g, b))
            capsh8.BackColor = (Color.FromArgb(255, r, g, b))
            capsh9.BackColor = (Color.FromArgb(255, r, g, b))
            capsh10.BackColor = (Color.FromArgb(255, r, g, b))
            capsh11.BackColor = (Color.FromArgb(255, r, g, b))
        Else
            capsh1.BackColor = (c)
            capsh2.BackColor = (c)
            capsh3.BackColor = (c)
            capsh4.BackColor = (c)
            capsh5.BackColor = (c)
            capsh6.BackColor = (c)
            capsh7.BackColor = (c)
            capsh8.BackColor = (c)
            capsh9.BackColor = (c)
            capsh10.BackColor = (c)
            capsh11.BackColor = (c)
        End If
    End Sub

    Private Sub UpdateOveralls(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer, Optional ByVal c As Color = Nothing)
        If c = Nothing Then
            over1.BackColor = (Color.FromArgb(255, r, g, b))
            over2.BackColor = (Color.FromArgb(255, r, g, b))
            over3.BackColor = (Color.FromArgb(255, r, g, b))
            over4.BackColor = (Color.FromArgb(255, r, g, b))
            over5.BackColor = (Color.FromArgb(255, r, g, b))
            over6.BackColor = (Color.FromArgb(255, r, g, b))
            over7.BackColor = (Color.FromArgb(255, r, g, b))
        Else
            over1.BackColor = (c)
            over2.BackColor = (c)
            over3.BackColor = (c)
            over4.BackColor = (c)
            over5.BackColor = (c)
            over6.BackColor = (c)
            over7.BackColor = (c)
        End If
    End Sub

    Private Sub UpdateSkin(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer, Optional ByVal c As Color = Nothing)
        If c = Nothing Then
            face1.BackColor = (Color.FromArgb(255, r, g, b))
            face2.BackColor = (Color.FromArgb(255, r, g, b))
            face3.BackColor = (Color.FromArgb(255, r, g, b))
            face4.BackColor = (Color.FromArgb(255, r, g, b))
            face5.BackColor = (Color.FromArgb(255, r, g, b))
            face6.BackColor = (Color.FromArgb(255, r, g, b))
            face7.BackColor = (Color.FromArgb(255, r, g, b))
            face8.BackColor = (Color.FromArgb(255, r, g, b))
            face9.BackColor = (Color.FromArgb(255, r, g, b))
        Else
            face1.BackColor = (c)
            face2.BackColor = (c)
            face3.BackColor = (c)
            face4.BackColor = (c)
            face5.BackColor = (c)
            face6.BackColor = (c)
            face7.BackColor = (c)
            face8.BackColor = (c)
            face9.BackColor = (c)
        End If
    End Sub

    Private Sub UpdateGloves(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer, Optional ByVal c As Color = Nothing)
        If c = Nothing Then
            glo1.BackColor = (Color.FromArgb(255, r, g, b))
            glo2.BackColor = (Color.FromArgb(255, r, g, b))
            glo3.BackColor = (Color.FromArgb(255, r, g, b))
            glo4.BackColor = (Color.FromArgb(255, r, g, b))
        Else
            glo1.BackColor = (c)
            glo2.BackColor = (c)
            glo3.BackColor = (c)
            glo4.BackColor = (c)
        End If
    End Sub

    Private Sub UpdateShoes(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer, Optional ByVal c As Color = Nothing)
        If c = Nothing Then
            sho1.BackColor = (Color.FromArgb(255, r, g, b))
            sho2.BackColor = (Color.FromArgb(255, r, g, b))
            sho3.BackColor = (Color.FromArgb(255, r, g, b))
            sho4.BackColor = (Color.FromArgb(255, r, g, b))
        Else
            sho1.BackColor = (c)
            sho2.BackColor = (c)
            sho3.BackColor = (c)
            sho4.BackColor = (c)
        End If
    End Sub

    Private Sub Haircut(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer, Optional ByVal c As Color = Nothing)
        If c = Nothing Then
            hair1.BackColor = (Color.FromArgb(255, r, g, b))
            hair2.BackColor = (Color.FromArgb(255, r, g, b))
            hair3.BackColor = (Color.FromArgb(255, r, g, b))
            hair4.BackColor = (Color.FromArgb(255, r, g, b))
            hair5.BackColor = (Color.FromArgb(255, r, g, b))
        Else
            hair1.BackColor = (c)
            hair2.BackColor = (c)
            hair3.BackColor = (c)
            hair4.BackColor = (c)
            hair5.BackColor = (c)
        End If
    End Sub
End Class