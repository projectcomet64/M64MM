Public Class ColorCodeCopyPasteForm
    Private ParentWindow As ColorCodeStudio

    Public Sub New(OutputOnly As Boolean, ByRef parent As ColorCodeStudio, Optional cc As String = "")
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ParentWindow = parent

        If OutputOnly = True Then
            B_Cancel.Visible = False
            B_OK.Text = "Close"
            Label1.Text = "Here's that color code you asked for!"
            TextBox1.Text = cc
            TextBox1.ReadOnly = True
        Else
            Label1.Text = "Paste your color code into the textbox below, then click ""OK""."
        End If
    End Sub

    Private Sub B_OK_Click(sender As Object, e As EventArgs) Handles B_OK.Click
        DialogResult = DialogResult.OK
        ParentWindow.returnedCode = TextBox1.Text
        Close()
    End Sub

    Private Sub B_Cancel_Click(sender As Object, e As EventArgs) Handles B_Cancel.Click
        Close()
    End Sub

    'If you have a TextBox with its MultiLine property set to True, it prevents you from using Ctrl+A to
    'select all of the text inside. This is a workaround to allow you to do that again.
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.A Then
            If sender IsNot Nothing Then
                DirectCast(sender, TextBox).SelectAll()
            End If
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub
End Class