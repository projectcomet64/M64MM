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
        Label6.Text = My.Resources.AboutBuildDate + My.Settings.BuildDate.ToShortDateString
        'EDITOR'S NOTE:
        'In Settings, change the Build Date to "Today" when you release pl0x
    End Sub

    'NOTE'S NOTE:
    ' please change the super hidden label 7u7
    ' idk, i wanna keep it as one of those weird, non visible
    ' easter eggs
    ' even though in-code comments exists
    ' i'm just like that lol
    ' i doubt it does any significant change in the size of the file or the ram load...
End Class