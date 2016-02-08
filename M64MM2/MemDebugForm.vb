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
                    MsgBox("The value you have entered is not a valid Hexadecimal address." & vbCrLf & ex.Message)
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
                    MsgBox("The number you have entered is not a valid Hexadecimal value." & vbCrLf & ex.Message)
                    'IN_Value1.Text = ""
                End Try
            End If
        End If
    End Sub

    Private Sub B_Read1_Click(sender As Object, e As EventArgs) Handles B_Read1.Click
        If WeGotABadassOverHere Then
            Value1 = ReadUInteger("Project64", MainForm.Base + Address1)
            IN_Value1.Text = Hex(Value1)
        End If
    End Sub

    Private Sub B_Write1_Click(sender As Object, e As EventArgs) Handles B_Write1.Click
        If WeGotABadassOverHere Then
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