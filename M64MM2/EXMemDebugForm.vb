Imports System.Globalization
Public Class EXMemDebugForm
    Private Value1 As String
    Private Address1 As UInteger
    Private Sub ReadAs1_btn_Click(sender As Object, e As EventArgs) Handles ReadAs1_btn.Click
        If Type_cb.SelectedItem = "Integer" Then
            Value1 = ""
            Dim ValueRead As Integer = ReadUInteger("Project64", MainForm.Base + Address1, BTR_nud.Value)
            Value1_tb.Text = ValueRead
        ElseIf Type_cb.SelectedItem = "Float" Then
            Value1 = ""
            Dim ValueRead As Single = ReadFloat("Project64", MainForm.Base + Address1, BTR_nud.Value)
            Value1_tb.Text = ValueRead
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Type_cb.SelectedItem = "Integer" Then
            WriteUInteger("Project64", UInteger.Parse(Address1_tb.Text, NumberStyles.HexNumber), Integer.Parse(Value1_tb.Text))
        ElseIf Type_cb.SelectedItem = "Float" Then
            WriteFloat("Project64", UInteger.Parse(Address1_tb.Text, NumberStyles.HexNumber), Single.Parse(Value1_tb.Text))
        End If
    End Sub
End Class