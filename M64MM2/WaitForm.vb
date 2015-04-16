Public Class WaitForm
    Public Shadows Sub Refresh(percent As Integer)
        ProgressBar1.Value = percent

        MyBase.Refresh()
    End Sub
End Class