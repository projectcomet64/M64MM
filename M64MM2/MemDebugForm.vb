Imports System.Globalization
Imports M64MM2.My.Resources

Public Class MemDebugForm

	Private Address1 As UInteger
	Private Address2 As UInteger
	Private Address3 As UInteger
	Private Address4 As UInteger
	Private Value1 As String
	Private Value2 As String
	Private Value3 As String
	Private Value4 As String

	Private ReadOnly Property WeGotABadassOverHere As Boolean
		Get
			Return (CB_Accept.Checked And MainForm.EmuOpen And MainForm.Base > 0)
		End Get
	End Property

	Private Sub CB_Accept_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Accept.CheckedChanged
		If WeGotABadassOverHere Then
			GB_DebugControls.Enabled = True
		Else
			GB_DebugControls.Enabled = False
		End If
	End Sub

	Private Sub IN_Address_ValidateHex(sender As Object, Optional e As EventArgs = Nothing, Optional key As KeyEventArgs = Nothing) Handles IN_Address1.Leave, IN_Address1.KeyDown, IN_Address2.Leave, IN_Address2.KeyDown, IN_Address3.Leave, IN_Address3.KeyDown, IN_Address4.Leave, IN_Address4.KeyDown
		Select Case DirectCast(sender, Control).Name
			Case "IN_Address1"
				If IN_Address1.Text IsNot Nothing AndAlso IN_Address1.Text <> "" Then
					If (key IsNot Nothing AndAlso key.KeyCode = Keys.Return) Or (key Is Nothing And e IsNot Nothing) Then
						If IN_Address1.Text.StartsWith("0x") Or (IN_Address1.Text.StartsWith("80") And IN_Address1.Text.Length = 8) Then
							IN_Address1.Text = IN_Address1.Text.Substring(2)
						End If

						Try
							Address1 = UInteger.Parse(IN_Address1.Text, NumberStyles.HexNumber)
						Catch ex As Exception
							MsgBox(InvalidHexAddress & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
						End Try
					End If
				End If
			Case "IN_Address2"
				If IN_Address2.Text IsNot Nothing AndAlso IN_Address2.Text <> "" Then
					If (key IsNot Nothing AndAlso key.KeyCode = Keys.Return) Or (key Is Nothing And e IsNot Nothing) Then
						If IN_Address2.Text.StartsWith("0x") Or (IN_Address2.Text.StartsWith("80") And IN_Address2.Text.Length = 8) Then
							IN_Address2.Text = IN_Address2.Text.Substring(2)
						End If

						Try
							Address2 = UInteger.Parse(IN_Address2.Text, NumberStyles.HexNumber)
						Catch ex As Exception
							MsgBox(InvalidHexAddress & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
						End Try
					End If
				End If
			Case "IN_Address3"
				If IN_Address3.Text IsNot Nothing AndAlso IN_Address3.Text <> "" Then
					If (key IsNot Nothing AndAlso key.KeyCode = Keys.Return) Or (key Is Nothing And e IsNot Nothing) Then
						If IN_Address3.Text.StartsWith("0x") Or (IN_Address3.Text.StartsWith("80") And IN_Address3.Text.Length = 8) Then
							IN_Address3.Text = IN_Address3.Text.Substring(2)
						End If

						Try
							Address3 = UInteger.Parse(IN_Address3.Text, NumberStyles.HexNumber)
						Catch ex As Exception
							MsgBox(InvalidHexAddress & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
						End Try
					End If
				End If
			Case "IN_Address4"
				If IN_Address4.Text IsNot Nothing AndAlso IN_Address4.Text <> "" Then
					If (key IsNot Nothing AndAlso key.KeyCode = Keys.Return) Or (key Is Nothing And e IsNot Nothing) Then
						If IN_Address4.Text.StartsWith("0x") Or (IN_Address4.Text.StartsWith("80") And IN_Address4.Text.Length = 8) Then
							IN_Address4.Text = IN_Address4.Text.Substring(2)
						End If

						Try
							Address4 = UInteger.Parse(IN_Address4.Text, NumberStyles.HexNumber)
						Catch ex As Exception
							MsgBox(InvalidHexAddress & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
						End Try
					End If
				End If
		End Select
	End Sub

	Private Sub IN_Value_ValidateHex(sender As Object, Optional e As EventArgs = Nothing, Optional key As KeyEventArgs = Nothing) Handles IN_Value1.Leave, IN_Value1.KeyDown, IN_Value2.Leave, IN_Value2.KeyDown, IN_Value3.Leave, IN_Value3.KeyDown, IN_Value4.Leave, IN_Value4.KeyDown
		Select Case DirectCast(sender, Control).Name
			Case "IN_Value1"
				If IN_Value1.Text IsNot Nothing AndAlso IN_Value1.Text <> "" Then
					If (key IsNot Nothing AndAlso key.KeyCode = Keys.Return) Or (key Is Nothing And e IsNot Nothing) Then
						If IN_Value1.Text.StartsWith("0x") Then
							IN_Value1.Text = IN_Value1.Text.Substring(2)
						End If

						If System.Text.RegularExpressions.Regex.IsMatch(IN_Value1.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
							Value1 = IN_Value1.Text
						Else
							MsgBox(InvalidHexValue)
						End If
					End If
				End If
			Case "IN_Value2"
				If IN_Value2.Text IsNot Nothing AndAlso IN_Value2.Text <> "" Then
					If (key IsNot Nothing AndAlso key.KeyCode = Keys.Return) Or (key Is Nothing And e IsNot Nothing) Then
						If IN_Value2.Text.StartsWith("0x") Then
							IN_Value2.Text = IN_Value2.Text.Substring(2)
						End If

						If System.Text.RegularExpressions.Regex.IsMatch(IN_Value2.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
							Value2 = IN_Value2.Text
						Else
							MsgBox(InvalidHexValue)
						End If
					End If
				End If
			Case "IN_Value3"
				If IN_Value3.Text IsNot Nothing AndAlso IN_Value3.Text <> "" Then
					If (key IsNot Nothing AndAlso key.KeyCode = Keys.Return) Or (key Is Nothing And e IsNot Nothing) Then
						If IN_Value3.Text.StartsWith("0x") Then
							IN_Value3.Text = IN_Value3.Text.Substring(2)
						End If

						If System.Text.RegularExpressions.Regex.IsMatch(IN_Value3.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
							Value3 = IN_Value3.Text
						Else
							MsgBox(InvalidHexValue)
						End If
					End If
				End If
			Case "IN_Value4"
				If IN_Value4.Text IsNot Nothing AndAlso IN_Value4.Text <> "" Then
					If (key IsNot Nothing AndAlso key.KeyCode = Keys.Return) Or (key Is Nothing And e IsNot Nothing) Then
						If IN_Value4.Text.StartsWith("0x") Then
							IN_Value4.Text = IN_Value4.Text.Substring(2)
						End If

						If System.Text.RegularExpressions.Regex.IsMatch(IN_Value4.Text, "\A\b[0-9a-fA-F]+\b\Z") Then
							Value4 = IN_Value4.Text
						Else
							MsgBox(InvalidHexValue)
						End If
					End If
				End If
		End Select
	End Sub

	Private Sub B_Read_Click(sender As Object, e As EventArgs) Handles B_Read1.Click, B_Read2.Click, B_Read3.Click, B_Read4.Click
		If WeGotABadassOverHere Then
			Try
				Select Case DirectCast(sender, Control).Name
					Case "B_Read1"
						Value1 = ""
						Dim bytes() As Byte = BigEndianRead("Project64", MainForm.Base + Address1, 4)
						For X As Integer = 0 To 3
							Value1 += FixZeroHexByte(Hex(bytes(X)))
						Next
						IN_Value1.Text = Value1
					Case "B_Read2"
						Value2 = ""
						Dim bytes() As Byte = BigEndianRead("Project64", MainForm.Base + Address2, 4)
						For X As Integer = 0 To 3
							Value2 += FixZeroHexByte(Hex(bytes(X)))
						Next
						IN_Value2.Text = Value2
					Case "B_Read3"
						Value3 = ""
						Dim bytes() As Byte = BigEndianRead("Project64", MainForm.Base + Address3, 4)
						For X As Integer = 0 To 3
							Value3 += FixZeroHexByte(Hex(bytes(X)))
						Next
						IN_Value3.Text = Value3
					Case "B_Read4"
						Value4 = ""
						Dim bytes() As Byte = BigEndianRead("Project64", MainForm.Base + Address4, 4)
						For X As Integer = 0 To 3
							Value4 += FixZeroHexByte(Hex(bytes(X)))
						Next
						IN_Value4.Text = Value4
				End Select
			Catch ex As Exception
				MsgBox("Something went wrong:" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
			End Try
		End If
	End Sub

	Private Sub B_Write_Click(sender As Object, e As EventArgs) Handles B_Write1.Click, B_Write2.Click, B_Write3.Click, B_Write4.Click
		If WeGotABadassOverHere Then
			Select Case DirectCast(sender, Control).Name
				Case "B_Write1"
					If Address1 <= 4 Then
						If MessageBox.Show(BaseAddressOverwriteWarning, "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
							Dim bytes As String = Value1.Substring(6, 2) & Value1.Substring(4, 2) & Value1.Substring(2, 2) & Value1.Substring(0, 2)
							WriteXBytes("Project64", MainForm.Base + Address1, Value1)
						End If
					Else
						Dim bytes As String = Value1.Substring(6, 2) & Value1.Substring(4, 2) & Value1.Substring(2, 2) & Value1.Substring(0, 2)
						WriteXBytes("Project64", MainForm.Base + Address1, bytes)
					End If
				Case "B_Write2"
					If Address2 <= 4 Then
						If MessageBox.Show(BaseAddressOverwriteWarning, "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
							Dim bytes As String = Value2.Substring(6, 2) & Value2.Substring(4, 2) & Value2.Substring(2, 2) & Value2.Substring(0, 2)
							WriteXBytes("Project64", MainForm.Base + Address1, Value2)
						End If
					Else
						Dim bytes As String = Value2.Substring(6, 2) & Value2.Substring(4, 2) & Value2.Substring(2, 2) & Value2.Substring(0, 2)
						WriteUInteger("Project64", MainForm.Base + Address2, Value2)
					End If
				Case "B_Write3"
					If Address3 <= 4 Then
						If MessageBox.Show(BaseAddressOverwriteWarning, "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
							Dim bytes As String = Value3.Substring(6, 2) & Value3.Substring(4, 2) & Value3.Substring(2, 2) & Value3.Substring(0, 2)
							WriteXBytes("Project64", MainForm.Base + Address1, Value3)
						End If
					Else
						Dim bytes As String = Value3.Substring(6, 2) & Value3.Substring(4, 2) & Value3.Substring(2, 2) & Value3.Substring(0, 2)
						WriteUInteger("Project64", MainForm.Base + Address3, Value3)
					End If
				Case "B_Write4"
					If Address4 <= 4 Then
						If MessageBox.Show(BaseAddressOverwriteWarning, "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
							Dim bytes As String = Value4.Substring(6, 2) & Value4.Substring(4, 2) & Value4.Substring(2, 2) & Value4.Substring(0, 2)
							WriteXBytes("Project64", MainForm.Base + Address1, Value4)
						End If
					Else
						Dim bytes As String = Value4.Substring(6, 2) & Value4.Substring(4, 2) & Value4.Substring(2, 2) & Value4.Substring(0, 2)
						WriteUInteger("Project64", MainForm.Base + Address4, Value4)
					End If
			End Select
		End If
	End Sub

	Private Sub MemDebugForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LB_Disclaimer.Text = MemDebugWarning
        CB_Accept.Text = IOBadass
        B_Read1.Text = IORead
        B_Read2.Text = IORead
        B_Read3.Text = IORead
        B_Read4.Text = IORead
        B_Write1.Text = IOWrite
        B_Write2.Text = IOWrite
        B_Write3.Text = IOWrite
        B_Write4.Text = IOWrite
        LB_Address1.Text = IOAddr
        LB_Address2.Text = IOAddr
        LB_Address3.Text = IOAddr
        LB_Address4.Text = IOAddr
        LB_Value1.Text = IOValue
        LB_Value2.Text = IOValue
        LB_Value3.Text = IOValue
        LB_Value4.Text = IOValue
        GB_DebugControls.Text = IOFormTitle
        Me.Text = IOFormTitle
    End Sub

    Private Sub AAFirst_btn_Click(sender As Object, e As EventArgs) Handles AAFirst_btn.Click
        EXMemDebugForm.Show()
    End Sub
End Class