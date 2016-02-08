Imports System.Globalization

Public Class MemDebugForm

    Private Address1 As UInteger
    Private Address2 As UInteger
    Private Address3 As UInteger
    Private Address4 As UInteger
    Private Value1 As UInteger
    Private Value2 As UInteger
    Private Value3 As UInteger
    Private Value4 As UInteger

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

    Private Sub IN_Address1_ValidateHex(sender As Object, Optional e As EventArgs = Nothing, Optional key As KeyEventArgs = Nothing) Handles IN_Address1.Leave, IN_Address1.KeyDown
        If IN_Address1.Text IsNot Nothing AndAlso IN_Address1.Text <> "" Then
            If (key IsNot Nothing AndAlso key.KeyCode <> Keys.Return) Or (key Is Nothing And e IsNot Nothing) Then
                If IN_Address1.Text.StartsWith("0x") Or (IN_Address1.Text.StartsWith("80") And IN_Address1.Text.Length = 8) Then
                    IN_Address1.Text = IN_Address1.Text.Substring(2)
                End If

                Try
                    Address1 = UInteger.Parse(IN_Address1.Text, NumberStyles.HexNumber)
                Catch ex As Exception
                    MsgBox("The value you have entered is not a valid Hexadecimal address." & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
                    'IN_Address1.Text = ""
                End Try
            End If
        End If
    End Sub

    Private Sub IN_Value1_ValidateHex(sender As Object, Optional e As EventArgs = Nothing, Optional key As KeyEventArgs = Nothing) Handles IN_Value1.Leave, IN_Value1.KeyDown
        If IN_Value1.Text IsNot Nothing AndAlso IN_Value1.Text <> "" Then
            If (key IsNot Nothing AndAlso key.KeyCode <> Keys.Return) Or (key Is Nothing And e IsNot Nothing) Then
                If IN_Value1.Text.StartsWith("0x") Then
                    IN_Value1.Text = IN_Value1.Text.Substring(2)
                End If

                Try
                    Value1 = UInteger.Parse(IN_Value1.Text, NumberStyles.HexNumber)
                Catch ex As Exception
                    MsgBox("The number you have entered is not a valid Hexadecimal value." & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
                    'IN_Value1.Text = ""
                End Try
            End If
        End If
    End Sub

    Private Sub B_Read_Click(sender As Object, e As EventArgs) Handles B_Read1.Click, B_Read2.Click, B_Read3.Click, B_Read4.Click
        If WeGotABadassOverHere Then
            Try
                Select Case DirectCast(sender, Control).Name
                    Case "B_Read1"
                        Value1 = ReadUInteger("Project64", MainForm.Base + Address1)
                        IN_Value1.Text = Hex(Value1)
                    Case "B_Read2"
                        Value2 = ReadUInteger("Project64", MainForm.Base + Address2)
                        IN_Value2.Text = Hex(Value2)
                    Case "B_Read3"
                        Value3 = ReadUInteger("Project64", MainForm.Base + Address3)
                        IN_Value3.Text = Hex(Value3)
                    Case "B_Read4"
                        Value4 = ReadUInteger("Project64", MainForm.Base + Address4)
                        IN_Value4.Text = Hex(Value4)
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
                        Dim WarningText As String = "You are attempting to write to the first four bytes of Super Mario 64's memory, " &
                          "which contains the value this program uses to find the game's base address. " &
                          "If you click ""Yes"", you will need to reset the emulator before this program will be able " &
                          "to find Super Mario 64 again. Are you sure you want to do this?"
                        If MessageBox.Show(WarningText, "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            WriteUInteger("Project64", MainForm.Base + Address1, Value1)
                        End If
                    Else
                        WriteUInteger("Project64", MainForm.Base + Address1, Value1)
                    End If
                Case "B_Write2"
                    If Address2 <= 4 Then
                        Dim WarningText As String = "You are attempting to write to the first four bytes of Super Mario 64's memory, " &
                          "which contains the value this program uses to find the game's base address. " &
                          "If you click ""Yes"", you will need to reset the emulator before this program will be able " &
                          "to find Super Mario 64 again. Are you sure you want to do this?"
                        If MessageBox.Show(WarningText, "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            WriteUInteger("Project64", MainForm.Base + Address2, Value2)
                        End If
                    Else
                        WriteUInteger("Project64", MainForm.Base + Address2, Value2)
                    End If
                Case "B_Write3"
                    If Address3 <= 4 Then
                        Dim WarningText As String = "You are attempting to write to the first four bytes of Super Mario 64's memory, " &
                          "which contains the value this program uses to find the game's base address. " &
                          "If you click ""Yes"", you will need to reset the emulator before this program will be able " &
                          "to find Super Mario 64 again. Are you sure you want to do this?"
                        If MessageBox.Show(WarningText, "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            WriteUInteger("Project64", MainForm.Base + Address3, Value3)
                        End If
                    Else
                        WriteUInteger("Project64", MainForm.Base + Address3, Value3)
                    End If
                Case "B_Write4"
                    If Address4 <= 4 Then
                        Dim WarningText As String = "You are attempting to write to the first four bytes of Super Mario 64's memory, " &
                          "which contains the value this program uses to find the game's base address. " &
                          "If you click ""Yes"", you will need to reset the emulator before this program will be able " &
                          "to find Super Mario 64 again. Are you sure you want to do this?"
                        If MessageBox.Show(WarningText, "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                            WriteUInteger("Project64", MainForm.Base + Address4, Value4)
                        End If
                    Else
                        WriteUInteger("Project64", MainForm.Base + Address4, Value4)
                    End If
            End Select
        End If
    End Sub

    Private Sub IN_Value1_ValidateHex(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub IN_Value1_ValidateHex(sender As Object, e As EventArgs) Handles IN_Value1.Leave, IN_Value1.KeyDown

    End Sub

    Private Sub IN_Address1_ValidateHex(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub IN_Address1_ValidateHex(sender As Object, e As EventArgs) Handles IN_Address1.Leave, IN_Address1.KeyDown

    End Sub
End Class