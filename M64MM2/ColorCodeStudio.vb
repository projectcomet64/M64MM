Public Class ColorCodeStudio
	'Private HatColor(3) As Color '= Color.FromArgb(127, 0, 0)
	'Private HairColor(3) As Color
	'Private SkinColor(3) As Color
	'Private PantsColor(3) As Color
	'Private GlovesColor(3) As Color
	'Private ShoesColor(3) As Color

	Private Sub ColorCodeStudio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'HatColor(0) = HatButton1.BackColor
		'HatColor(1) = HatButton2.BackColor
		'HatColor(2) = HatButton3.BackColor
		'HatColor(3) = HatButton4.BackColor


	End Sub

	Private Sub ColorButton_Click(sender As Object, e As EventArgs) Handles HatButton1.Click, HatButton4.Click, HatButton3.Click, HatButton2.Click
		If ColorDialog1.ShowDialog() = DialogResult.OK Then
			DirectCast(sender, Button).BackColor = ColorDialog1.Color
		End If
	End Sub
End Class