Public Class ScanForm

    Private CancelScan As Boolean = False
    Private CurrentAddress As Integer
    Private Done As Boolean = False
    Public ProcessHandle As IntPtr

    Private Sub ScanForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub b_Cancel_Click(sender As Object, e As EventArgs) Handles b_Cancel.Click
        CancelScan = True
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        For x = ReadWritingMemory.startPoint To &H72D00000 Step ReadWritingMemory.scanStep
            If CancelScan = True Then
                BackgroundWorker1.WorkerSupportsCancellation = True
                BackgroundWorker1.CancelAsync()
                MessageBox.Show("Scan Canceled!")
                Exit For
            End If
            CurrentAddress = x

            Dim nsize As Integer = 4

            Dim vBuffer As Integer

            BackgroundWorker1.ReportProgress(0)

            ReadWritingMemory.ReadProcessMemory1(ProcessHandle, x, vBuffer, nsize, 0)
            If vBuffer = &H3C1A8032 Then
                ReadWritingMemory.Result = vBuffer
                Done = True
                BackgroundWorker1.ReportProgress(100)
            End If
        Next

        ReadWritingMemory.Result = 0
        Done = True
        BackgroundWorker1.ReportProgress(0)
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Refresh()
        ProgressBar1.Value = (CurrentAddress - startPoint) / &H72D00000
        Label1.Text = "Scanning for Base Address: " & (CurrentAddress - startPoint) / &H72D00000 & "%"
        Label2.Text = "Currently scanning address: " & Hex(CurrentAddress)
        If Done = True Then
            Close()
        End If
    End Sub
End Class