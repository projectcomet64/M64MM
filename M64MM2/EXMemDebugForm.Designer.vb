<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EXMemDebugForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Address1_tb = New System.Windows.Forms.TextBox()
        Me.Address1_lb = New System.Windows.Forms.Label()
        Me.Value1_tb = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ReadAs1_btn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BTR_nud = New System.Windows.Forms.NumericUpDown()
        Me.Type_cb = New System.Windows.Forms.ComboBox()
        CType(Me.BTR_nud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Address1_tb
        '
        Me.Address1_tb.Location = New System.Drawing.Point(12, 99)
        Me.Address1_tb.Name = "Address1_tb"
        Me.Address1_tb.Size = New System.Drawing.Size(152, 20)
        Me.Address1_tb.TabIndex = 0
        '
        'Address1_lb
        '
        Me.Address1_lb.AutoSize = True
        Me.Address1_lb.Location = New System.Drawing.Point(9, 83)
        Me.Address1_lb.Name = "Address1_lb"
        Me.Address1_lb.Size = New System.Drawing.Size(60, 13)
        Me.Address1_lb.TabIndex = 1
        Me.Address1_lb.Text = "(1) Address"
        '
        'Value1_tb
        '
        Me.Value1_tb.Location = New System.Drawing.Point(12, 157)
        Me.Value1_tb.Name = "Value1_tb"
        Me.Value1_tb.Size = New System.Drawing.Size(152, 20)
        Me.Value1_tb.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "(1) Value"
        '
        'ReadAs1_btn
        '
        Me.ReadAs1_btn.Location = New System.Drawing.Point(170, 99)
        Me.ReadAs1_btn.Name = "ReadAs1_btn"
        Me.ReadAs1_btn.Size = New System.Drawing.Size(75, 23)
        Me.ReadAs1_btn.TabIndex = 4
        Me.ReadAs1_btn.Text = "Read As:"
        Me.ReadAs1_btn.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(170, 157)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Write As:"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BTR_nud
        '
        Me.BTR_nud.Location = New System.Drawing.Point(393, 131)
        Me.BTR_nud.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.BTR_nud.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.BTR_nud.Name = "BTR_nud"
        Me.BTR_nud.Size = New System.Drawing.Size(40, 20)
        Me.BTR_nud.TabIndex = 7
        Me.BTR_nud.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Type_cb
        '
        Me.Type_cb.FormattingEnabled = True
        Me.Type_cb.Items.AddRange(New Object() {"Integer", "Float"})
        Me.Type_cb.Location = New System.Drawing.Point(251, 130)
        Me.Type_cb.Name = "Type_cb"
        Me.Type_cb.Size = New System.Drawing.Size(136, 21)
        Me.Type_cb.TabIndex = 8
        '
        'EXMemDebugForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 261)
        Me.Controls.Add(Me.Type_cb)
        Me.Controls.Add(Me.BTR_nud)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ReadAs1_btn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Value1_tb)
        Me.Controls.Add(Me.Address1_lb)
        Me.Controls.Add(Me.Address1_tb)
        Me.Name = "EXMemDebugForm"
        Me.Text = "User friendly memory editor"
        CType(Me.BTR_nud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Address1_tb As TextBox
    Friend WithEvents Address1_lb As Label
    Friend WithEvents Value1_tb As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ReadAs1_btn As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents BTR_nud As NumericUpDown
    Friend WithEvents Type_cb As ComboBox
End Class
