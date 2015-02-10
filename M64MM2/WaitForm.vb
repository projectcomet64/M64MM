Public Class WaitForm
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Shadows Sub Refresh(percent As Integer)
        ProgressBar1.Value = percent

        MyBase.Refresh()
    End Sub
End Class