Imports System
Imports System.IO

Public Class MainForm
    Private Declare Function GetKeyPress Lib "user32" Alias "GetAsyncKeyState" (ByVal key As Integer) As Integer

    Private ChangeCamera As Boolean = False
    Private CameraUnfrozen As Boolean = False
    Private Base As Long
    Public Shared EmuOpen As Boolean = False
    Private Key3WasUp As Boolean = True
    Private ctrlkey As Boolean
    Private AnimData As Dictionary(Of String, String) = New Dictionary(Of String, String)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            Using sr As New StreamReader("animation_data.txt")
                Do While sr.Peek() >= 0
                    Dim rawLine As String
                    rawLine = sr.ReadLine()
                    Dim step1 As String = rawLine.Trim()
                    Dim step2 As String = step1.TrimStart("0")
                    Dim step3 As String = step2.TrimStart("x")
                    Dim splitLine() As String = Split(step3, " = ")
                    'Dim HexValue As Int64 = Int64.Parse(splitLine(0), System.Globalization.NumberStyles.HexNumber)
                    'AnimData.Add(HexValue, splitLine(1))
                    AnimData.Add(splitLine(0), splitLine(1))
                Loop
            End Using
        Catch e As Exception
            MessageBox.Show("Error reading animation data file:" & vbCrLf & e.Message)
        End Try

        If AnimData.Count > 0 Then
            ComboBox1.DataSource = New BindingSource(AnimData, Nothing)
            ComboBox1.DisplayMember = "Value"
            ComboBox1.ValueMember = "Key"
            AddHandler ComboBox1.SelectedValueChanged, AddressOf ComboBox1_SelectedValueChanged
            ComboBox1.Refresh()
            WriteAnimationSwap()
        End If

        'MessageBox.Show("Mario 64 Movie Maker 2.0 by James ""CaptainSwag101"" Pelster." & vbCrLf & "Click OK to begin searching for a base address. This will take a few seconds.")

        If GetEmuProcess("Project64") = Nothing Then
            EmuOpen = False
        Else
            EmuOpen = True
        End If

        Timer1.Enabled = True
        Timer1.Interval = 1

        'Commented this because this will be called immediately later in the first timer tick
        'GetBase()
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        If ComboBox1.SelectedIndex <> -1 Then
            WriteAnimationSwap()
        End If
    End Sub

    Public Function GetChunks(value As String, chunkSize As Integer) As List(Of String)
        Dim bytes As New List(Of String)
        While value.Length > chunkSize
            bytes.Add(value.Substring(0, chunkSize))
            value = value.Substring(chunkSize)
        End While
        If value <> "" Then
            bytes.Add(value)
        End If
        Return bytes
    End Function

    Private Sub WriteAnimationSwap()
        'Dim animationBytes As List(Of String) = GetChunks(ComboBox1.SelectedValue, 2)
        'WriteXBytes("Project64", Base + &H64508, ComboBox1.SelectedValue)
        If EmuOpen = True And Base > 0 Then
            WriteInteger("Project64", Base + &H64508, Integer.Parse(GetChunks(ComboBox1.SelectedValue, 8)(0), Globalization.NumberStyles.HexNumber))
            WriteInteger("Project64", Base + &H6450C, Integer.Parse(GetChunks(ComboBox1.SelectedValue, 8)(1), Globalization.NumberStyles.HexNumber))
        End If

        'WriteLong("Project64", Base + &H64508, CLng(ComboBox1.SelectedValue))
    End Sub

    Private Sub GetBase(Optional silent As Boolean = True)
        ' Get the base RAM address of the emulated memory block by searching for the constant value of SM64's first RAM address
        Label1.Text = "Scanning for base address..."
        Label1.Refresh()
        Base = GetBaseAddress("Project64", silent)
        If Base > 0 Then
            If silent = False Then
                MessageBox.Show("The base address is: " & Hex(Base))
            End If
            Label1.Text = "The base address is: " & Hex(Base)
            'AddressToModify = (Base + &H33C848)
            'Else
            '    ' We need to go deeper...
            '    If MessageBox.Show("Base address not found!" & vbCrLf & "Would you like to run a more thorough scan?" & vbCrLf & "This process may take up to one minute, but is much more likely to find the base address.", "Error", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            '        Base = GetBaseAddress("Project64", silent, &H100)
            '        If Base > 0 Then
            '            If silent = False Then
            '                MessageBox.Show("The base address is: " & Hex(Base))
            '            End If
            '            Label1.Text = "The base address is: " & Hex(Base)
            '            'AddressToModify = (Base + &H33C848)
            '        Else
            '            ' We need to go even deeper...
            '            If MessageBox.Show("Base address still not found!" & vbCrLf & "Would you like to run a byte-by-byte memory scan?" & vbCrLf & "This process will take a VERY long time, but is guaranteed to find the base address if it exists." & vbCrLf & vbCrLf & "If this is your first time seeing this message, I suggest you click ""No"" and try restarting both Project64 and this program to see if the problem is solved before trying this scan level.", "Error", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            '                Base = GetBaseAddress("Project64", silent, 4)
            '                If Base > 0 Then
            '                    If silent = False Then
            '                        MessageBox.Show("The base address is: " & Hex(Base))
            '                    End If
            '                    Label1.Text = "The base address is: " & Hex(Base)
            '                    'AddressToModify = (Base + &H33C848)
            '                Else
            '                    If silent = False Then
            '                        MessageBox.Show("Sorry, the base address could not be found. Make sure you're running Project64 with a U.S. ROM of Super Mario 64." & vbCrLf & "If you are using a modified ROM, please email me the name of the hack so that I can integrate it into this program." & vbCrLf & "Email me at CaptainSwag101@gmail.com.")
            '                    End If
            '                    Label1.Text = "Base address not found!"
            '                End If
            '            Else
            '                Label1.Text = "Base address not found!"
            '            End If
            '        End If
        Else
            Label1.Text = "Base address not found!"
            'End If
        End If
    End Sub


    Private Sub Freeze()
        ChangeCamera = False
        WriteInteger("Project64", Base + &H33C848, &H80000000)
    End Sub

    Private Sub Unfreeze()
        ChangeCamera = False
        CameraUnfrozen = True
        WriteInteger("Project64", Base + &H33C848, 0)
    End Sub

    Private Sub ChangeCameraType()
        ChangeCamera = Not ChangeCamera
        If ChangeCamera = True Then
            b_ChangeCameraType.Text = "Go to new area"
        Else
            b_ChangeCameraType.Text = "Change Camera Type"
        End If
    End Sub

    Private Sub b_Freeze_Click(sender As Object, e As EventArgs) Handles b_Freeze.Click
        If EmuOpen = True And Base > 0 Then Freeze()
    End Sub

    Private Sub b_Unfreeze_Click(sender As Object, e As EventArgs) Handles b_Unfreeze.Click
        If EmuOpen = True And Base > 0 Then Unfreeze()
    End Sub

    Private Sub b_ChangeCameraType_Click(sender As Object, e As EventArgs) Handles b_ChangeCameraType.Click
        If EmuOpen = True And Base > 0 Then ChangeCameraType()
    End Sub

    Private Sub TimerEventProcessor(myObject As Object, ByVal myEventArgs As EventArgs) Handles Timer1.Tick
        Timer1.Stop()

        ' Main program update call
        If GetEmuProcess("Project64") = Nothing Then
            EmuOpen = False
        Else
            EmuOpen = True
        End If

        If EmuOpen = True Then
            If Base > 0 Then
                ' Check if base address is still correct
                If ReadInteger("Project64", Base) <> &H3C1A8032 Then
                    Base = 0
                    GetBase()
                    If Base = 0 Then
                        Timer1.Enabled = True
                        Exit Sub
                    End If
                End If

                ' Handle key input (for hotkeys, etc.)
                HandleInput()

                ' Sometimes exiting first-person while the camera is frozen will result in a glitched state where Mario is stuck in first-person.
                ' This checks to see if this has happened, and forcibly fixes the camera if needed.
                If ReadLong("Project64", Base + &H33C848) >= &HA2000000L Then
                    WriteInteger("Project64", Base + &H33C848, &H80000000)
                End If

                ' If we are changing camera modes, repeatedly force the camera into frozen mode.
                If ChangeCamera = True Then
                    WriteInteger("Project64", Base + &H33C848, &H80000000)
                End If
            Else
                GetBase()
            End If
        Else
            Label1.Text = "Project64 isn't open!"
        End If

        Timer1.Enabled = True
    End Sub

    Private Sub HandleInput()
        If GetKeyPress(Keys.ControlKey) And GetKeyPress(Keys.D1) Then
            Freeze()
        ElseIf GetKeyPress(Keys.ControlKey) And GetKeyPress(Keys.D2) Then
            Unfreeze()
        ElseIf GetKeyPress(Keys.ControlKey) And GetKeyPress(Keys.D3) And Key3WasUp Then
            Key3WasUp = False
            If CameraUnfrozen = True Then
                b_ChangeCameraType.Text = "Change Camera Type"
                CameraUnfrozen = False
                Exit Sub
            End If
            ChangeCameraType()
        End If

        If GetKeyPress(Keys.D3) = False Then
            Key3WasUp = True
        Else
            Key3WasUp = False
        End If
    End Sub

    Private Sub AboutM64MovieMaker20ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutM64MovieMaker20ToolStripMenuItem.Click
        Dim AboutDialog As New AboutForm
        AboutDialog.ShowDialog()
    End Sub
End Class
