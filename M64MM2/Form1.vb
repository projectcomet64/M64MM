Imports System.Windows.Input

Public Class Form1
    Private ChangeCamera As Boolean = False
    Private Base As Long
	Private Key3WasUp As Boolean = True

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackgroundWorker1.WorkerSupportsCancellation = True
        MessageBox.Show("Mario 64 Movie Maker 2.0 by James ""CaptainSwag101"" Pelster." & vbCrLf & "Click OK to begin searching for a base address. This may take some time.")
        GetBase()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub GetBase()
        ' Get the base RAM address of the emulated memory block by searching for the constant value of SM64's first RAM address
        Base = GetBaseAddress("Project64")
        If Base > 0 Then
            MessageBox.Show("The base address is: " & Hex(Base))
            Label1.Text = "The base address is: " & Hex(Base)
            'AddressToModify = (Base + &H33C848)
        Else
            Label1.Text = "Project64 isn't open!"
        End If
    End Sub
	
	Private Sub Freeze()
		ChangeCamera = False
        WriteInteger("Project64", Base + &H33C848, &H80000000)
	End Sub
	
	Private Sub Unfreeze()
		ChangeCamera = False
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
        ' Check if a valid base address was found. If not, stop the BackgroundWorker
		If Base <= 0 Then
            MessageBox.Show("Project64 isn't open!")
            Exit Sub
        End If	
		
		' Main program update loop
        Do While Base > 0
			' Handle key input (for hotkeys, etc.)
			HandleInput()
			
			' Sometimes exiting first-person while the camera is frozen will result in a glitched state where Mario is stuck in first-person.
			' This checks to see if this has happened, and forcibly fixes the camera if needed.
            If ReadLong("Project64", Base + &H33C848) >= &HA2000000L Then
                WriteInteger("Project64", Base + &H33C848, &H80000000)
            End If
			
			' If we are changing camera modes, repeatedly force the camera into frozen mode.
            Do While ChangingCamera = True
                WriteInteger("Project64", Base + &H33C848, &H80000000)
            Loop
        Loop
    End Sub
	
	Private Sub HandleInput()
		If (Keyboard.GetKeyStates(Key.LeftControl) And KeyStates.Down) Or (Keyboard.GetKeyStates(Key.RightControl) And KeyStates.Down) Then
			If (Keyboard.GetKeyStates(Key.D1) And KeyStates.Down) Then ' Pressing Control-1
				Freeze()
			ElseIf (Keyboard.GetKeyStates(Key.D2) And KeyStates.Down) Then ' Pressing Control-2
				Unfreeze()
			ElseIf (Keyboard.GetKeyStates(Key.D3) And KeyStates.Down) And Key3WasUp = True Then ' Pressing Control-3
				' Because this switches the CameraChanged variable between true and false, we don't want it spamming if the user holds down the "3" key for a moment.
				Key3WasUp = False
				ChangeCameraType()
			End If
		End If
		
		If (Keyboard.GetKeyStates(Key.D3) And KeyStates.Up) Then
			Key3WasUp = True
		Else
			Key3WasUp = False
		End If
	End Sub
End Class
