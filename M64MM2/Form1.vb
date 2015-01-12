Public Class Form1
    'My base address: 42D90000

    '430CC848 - Me
    '5293C848 - MatthewGU4

    Public ChangeCamera As Boolean = False
    Public Base As UInteger
    Public AddressToModify As UInteger
    Private testStuck As Long

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
        Base = GetBaseAddress("Project64")
        If Base > 0 Then
            MessageBox.Show("The base address is: " & Hex(Base))
            Label1.Text = "The base address is: " & Hex(Base)
            AddressToModify = (Base + &H33C848)
        Else
            Label1.Text = "Project64 isn't open!"
        End If
    End Sub

    Private Sub b_Freeze_Click(sender As Object, e As EventArgs) Handles b_Freeze.Click
        ChangeCamera = False
        WriteInteger("Project64", Base + &H33C848, &H80000000)
    End Sub

    Private Sub b_Unfreeze_Click(sender As Object, e As EventArgs) Handles b_Unfreeze.Click
        ChangeCamera = False
        WriteInteger("Project64", Base + &H33C848, 0)
        'BackgroundWorker1.WorkerSupportsCancellation = True
        'BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If Base <= 0 Then
            MessageBox.Show("Project64 isn't open!")
            Exit Sub
        End If
        Do While Base > 0
            testStuck = ReadLong("Project64", Base + &H33C848)
            If testStuck >= &HA2000000L Then
                WriteInteger("Project64", Base + &H33C848, &H80000000)
            End If
            Do
                If ChangeCamera = False Then
                    Exit Do
                End If
                WriteInteger("Project64", Base + &H33C848L, &H80000000)
            Loop
        Loop
    End Sub

    Private Sub ChangeCameraType_Click(sender As Object, e As EventArgs) Handles ChangeCameraType.Click
        ChangeCamera = True
        'WriteInteger("Project64", Base + &H8033C848, &H80000000)
    End Sub
End Class
