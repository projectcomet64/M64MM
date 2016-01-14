Public Class MemDebugForm

	Private ReadOnly Property WeGotABadassOverHere As Boolean
		Get
			Return CB_Accept.Checked
		End Get
	End Property

	Private Sub CB_Accept_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Accept.CheckedChanged
		If CB_Accept.Checked = True Then
			GB_DebugControls.Enabled = True
		Else
			GB_DebugControls.Enabled = False
		End If
	End Sub

End Class