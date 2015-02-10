Public Class MainForm
    Private Declare Function GetKeyPress Lib "user32" Alias "GetAsyncKeyState" (ByVal key As Integer) As Integer
    Private Declare Function RegisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    Private Declare Function UnregisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer) As Integer

    Private ChangeCamera As Boolean = False
    Private CameraUnfrozen As Boolean = False
    Private Base As Long
    Public Shared IsError As Boolean = False
    Private Key3WasUp As Boolean = True
    Private ctrlkey As Boolean
    Private d1 As Boolean
    Private d2 As Boolean
    Private d3 As Boolean
    Private MOD_CTRL As Integer = &H11
    Private VK_D1 As Integer = &H31
    Private VK_D2 As Integer = &H32
    Private VK_D3 As Integer = &H33
    Private Const WM_HOTKEY As Integer = &H312

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Timer1.Enabled = True
        Timer1.Interval = 1
        BackgroundWorker1.WorkerSupportsCancellation = True
        MessageBox.Show("Mario 64 Movie Maker 2.0 by James ""CaptainSwag101"" Pelster." & vbCrLf & "Click OK to begin searching for a base address. This will take a few seconds.")
        GetBase()

        If IsError = True Then
            Me.Close()
            Application.Exit()
            Exit Sub
        End If
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'RegisterHotKey(Me.Handle, 9, MOD_CTRL, VK_D1)
        'RegisterHotKey(Me.Handle, 10, MOD_CTRL, VK_D2)
        'RegisterHotKey(Me.Handle, 11, MOD_CTRL, VK_D3)
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'UnregisterHotKey(Me.Handle, 9)
        'UnregisterHotKey(Me.Handle, 10)
        'UnregisterHotKey(Me.Handle, 11)
    End Sub

    Private Sub GetBase()
        ' Get the base RAM address of the emulated memory block by searching for the constant value of SM64's first RAM address
        If IsError = True Then
            BackgroundWorker1.WorkerSupportsCancellation = True
            BackgroundWorker1.CancelAsync()
            'Me.Close()
            Application.Exit()
            'Stop
        End If

        Base = GetBaseAddress("Project64")
        If Base > 0 Then
            MessageBox.Show("The base address is: " & Hex(Base))
            Label1.Text = "The base address is: " & Hex(Base)
            'AddressToModify = (Base + &H33C848)
        Else
            ' We need to go deeper...
            If IsError = True Then
                BackgroundWorker1.WorkerSupportsCancellation = True
                BackgroundWorker1.CancelAsync()
                'Me.Close()
                Application.Exit()
                Exit Sub
                'Stop
            End If

            If MessageBox.Show("Base address not found!" & vbCrLf & "Would you like to run a more thourough scan?" & vbCrLf & "This process may take several minutes, but is much more likely to find the base address.", "Error", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Base = GetBaseAddress("Project64", &H100)
                If Base > 0 Then
                    MessageBox.Show("The base address is: " & Hex(Base))
                    Label1.Text = "The base address is: " & Hex(Base)
                    'AddressToModify = (Base + &H33C848)
                Else
                    ' We need to go even deeper...
                    If IsError = True Then
                        BackgroundWorker1.WorkerSupportsCancellation = True
                        BackgroundWorker1.CancelAsync()
                        'Me.Close()
                        Application.Exit()
                        'Stop
                    End If

                    If MessageBox.Show("Base address still not found!" & vbCrLf & "Would you like to run a byte-by-byte memory scan?" & vbCrLf & "This process will take a VERY long time, but is guaranteed to find the base address if it exists.", "Error", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        Base = GetBaseAddress("Project64", 4)
                        If Base > 0 Then
                            MessageBox.Show("The base address is: " & Hex(Base))
                            Label1.Text = "The base address is: " & Hex(Base)
                            'AddressToModify = (Base + &H33C848)
                        Else
                            MessageBox.Show("Sorry, the base address could not be found. Make sure you're running Project64 with a U.S. ROM of Super Mario 64." & vbCrLf & "If you are using a modded ROM, please email me the name of the hack so that I can integrate it into this program." & vbCrLf & "Email me at CaptainSwag101@gmail.com.")
                            Label1.Text = "Base address not found!"
                        End If
                    Else
                        Label1.Text = "Base address not found!"
                        BackgroundWorker1.WorkerSupportsCancellation = True
                        BackgroundWorker1.CancelAsync()
                        Me.Close()
                        Application.Exit()
                        ''Stop
                    End If
                End If
            Else
                Label1.Text = "Base address not found!"
                BackgroundWorker1.WorkerSupportsCancellation = True
                BackgroundWorker1.CancelAsync()
                'Me.Close()
                Application.Exit()
                'Stop
            End If
        End If
    End Sub

    Private Sub Freeze()
        ChangeCamera = False
        WriteInteger("Project64", Base + &H33C848, &H80000000)
    End Sub

    Private Sub Unfreeze()
        ChangeCamera = False
        CameraUnfrozen = True
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.ReportProgress(0)
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
        Freeze()
    End Sub

    Private Sub b_Unfreeze_Click(sender As Object, e As EventArgs) Handles b_Unfreeze.Click
        Unfreeze()
    End Sub

    Private Sub b_ChangeCameraType_Click(sender As Object, e As EventArgs) Handles b_ChangeCameraType.Click
        ChangeCameraType()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ' Check if a valid base address was found. If not, 'Stop the BackgroundWorker
        If Base <= 0 Then
            BackgroundWorker1.WorkerSupportsCancellation = True
            BackgroundWorker1.CancelAsync()
            Exit Sub
        End If

        ' Main program update loop
        Do While Base > 0
            ' Handle key input (for hotkeys, etc.)
            HandleInput()

            If IsError = True Then
                'MsgBox("Project64 isn't open!")
                Application.Exit()
                Exit Sub
            End If
            ' Sometimes exiting first-person while the camera is frozen will result in a glitched state where Mario is stuck in first-person.
            ' This checks to see if this has happened, and forcibly fixes the camera if needed.
            If ReadLong("Project64", Base + &H33C848) >= &HA2000000L Then
                WriteInteger("Project64", Base + &H33C848, &H80000000)
            End If

            ' If we are changing camera modes, repeatedly force the camera into frozen mode.
            If ChangeCamera = True Then
                WriteInteger("Project64", Base + &H33C848, &H80000000)
            End If
        Loop
    End Sub

    Private Sub HandleInput()
        If GetKeyPress(Keys.ControlKey) And GetKeyPress(Keys.D1) Then
            Freeze()
        ElseIf GetKeyPress(Keys.ControlKey) And GetKeyPress(Keys.D2) Then
            Unfreeze()
        ElseIf GetKeyPress(Keys.ControlKey) And GetKeyPress(Keys.D3) And Key3WasUp Then
            Key3WasUp = False
            BackgroundWorker1.WorkerReportsProgress = True
            BackgroundWorker1.ReportProgress(0)
        End If

        If GetKeyPress(Keys.D3) = False Then
            Key3WasUp = True
        Else
            Key3WasUp = False
        End If
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(Sender As Object, e As EventArgs) Handles BackgroundWorker1.ProgressChanged
        If IsError = True Then
            BackgroundWorker1.WorkerSupportsCancellation = True
            BackgroundWorker1.CancelAsync()
            Me.Close()
            Application.Exit()
            'Stop
        End If
        If CameraUnfrozen = True Then
            b_ChangeCameraType.Text = "Change Camera Type"
            CameraUnfrozen = False
            Exit Sub
        End If
        ChangeCameraType()
    End Sub

    Private Sub AboutM64MovieMaker20ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutM64MovieMaker20ToolStripMenuItem.Click
        Dim AboutDialog As New AboutForm
        AboutDialog.ShowDialog()
    End Sub
End Class
