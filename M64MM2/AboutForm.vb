Public Class AboutForm

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("mailto:" & LinkLabel1.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

	Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Label2.Text = My.Resources.AboutCreatorDesc
		Label3.Text = My.Resources.AboutText1
		Label4.Text = My.Resources.AboutText2
		Label5.Text = My.Resources.AboutText3
	End Sub
End Class