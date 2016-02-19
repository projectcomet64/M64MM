<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorCodeCopyPasteForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ColorCodeCopyPasteForm))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.B_Cancel = New System.Windows.Forms.Button()
        Me.B_OK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.AcceptsReturn = True
        Me.TextBox1.AllowDrop = True
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(1, 36)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(232, 295)
        Me.TextBox1.TabIndex = 0
        '
        'B_Cancel
        '
        Me.B_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.B_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.B_Cancel.Location = New System.Drawing.Point(1, 337)
        Me.B_Cancel.Name = "B_Cancel"
        Me.B_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.B_Cancel.TabIndex = 1
        Me.B_Cancel.Text = "&Cancel"
        Me.B_Cancel.UseVisualStyleBackColor = True
        '
        'B_OK
        '
        Me.B_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.B_OK.Location = New System.Drawing.Point(158, 337)
        Me.B_OK.Name = "B_OK"
        Me.B_OK.Size = New System.Drawing.Size(75, 23)
        Me.B_OK.TabIndex = 2
        Me.B_OK.Text = "&OK"
        Me.B_OK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(1, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 29)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "This message will change based on whether you're importing or exporting a color c" &
    "ode."
        '
        'ColorCodeCopyPasteForm
        '
        Me.AcceptButton = Me.B_OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.B_Cancel
        Me.ClientSize = New System.Drawing.Size(234, 361)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.B_OK)
        Me.Controls.Add(Me.B_Cancel)
        Me.Controls.Add(Me.TextBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(175, 200)
        Me.Name = "ColorCodeCopyPasteForm"
        Me.Text = "Color Code Copy/Paste"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents B_Cancel As Button
    Friend WithEvents B_OK As Button
    Friend WithEvents Label1 As Label
End Class
