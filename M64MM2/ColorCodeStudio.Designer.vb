<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorCodeStudio
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ColorCodeStudio))
		Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
		Me.HatButton1 = New System.Windows.Forms.Button()
		Me.HatButton2 = New System.Windows.Forms.Button()
		Me.HatButton4 = New System.Windows.Forms.Button()
		Me.HatButton3 = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'HatButton1
		'
		Me.HatButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.HatButton1.Location = New System.Drawing.Point(12, 12)
		Me.HatButton1.Name = "HatButton1"
		Me.HatButton1.Size = New System.Drawing.Size(75, 23)
		Me.HatButton1.TabIndex = 0
		Me.HatButton1.UseVisualStyleBackColor = False
		'
		'HatButton2
		'
		Me.HatButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.HatButton2.Location = New System.Drawing.Point(93, 12)
		Me.HatButton2.Name = "HatButton2"
		Me.HatButton2.Size = New System.Drawing.Size(75, 23)
		Me.HatButton2.TabIndex = 1
		Me.HatButton2.UseVisualStyleBackColor = False
		'
		'HatButton4
		'
		Me.HatButton4.BackColor = System.Drawing.Color.Red
		Me.HatButton4.Location = New System.Drawing.Point(568, 12)
		Me.HatButton4.Name = "HatButton4"
		Me.HatButton4.Size = New System.Drawing.Size(75, 23)
		Me.HatButton4.TabIndex = 2
		Me.HatButton4.UseVisualStyleBackColor = False
		'
		'HatButton3
		'
		Me.HatButton3.BackColor = System.Drawing.Color.Red
		Me.HatButton3.Location = New System.Drawing.Point(487, 12)
		Me.HatButton3.Name = "HatButton3"
		Me.HatButton3.Size = New System.Drawing.Size(75, 23)
		Me.HatButton3.TabIndex = 3
		Me.HatButton3.UseVisualStyleBackColor = False
		'
		'ColorCodeStudio
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(655, 418)
		Me.Controls.Add(Me.HatButton3)
		Me.Controls.Add(Me.HatButton4)
		Me.Controls.Add(Me.HatButton2)
		Me.Controls.Add(Me.HatButton1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.Name = "ColorCodeStudio"
		Me.Text = "Color Code Studio"
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents ColorDialog1 As ColorDialog
	Friend WithEvents HatButton1 As Button
	Friend WithEvents HatButton2 As Button
	Friend WithEvents HatButton4 As Button
	Friend WithEvents HatButton3 As Button
End Class
