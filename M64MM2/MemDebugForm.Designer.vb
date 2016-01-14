<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MemDebugForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MemDebugForm))
		Me.Label1 = New System.Windows.Forms.Label()
		Me.CB_Accept = New System.Windows.Forms.CheckBox()
		Me.GB_DebugControls = New System.Windows.Forms.GroupBox()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(433, 43)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = resources.GetString("Label1.Text")
		'
		'CB_Accept
		'
		Me.CB_Accept.AutoSize = True
		Me.CB_Accept.Location = New System.Drawing.Point(15, 55)
		Me.CB_Accept.Name = "CB_Accept"
		Me.CB_Accept.Size = New System.Drawing.Size(132, 17)
		Me.CB_Accept.TabIndex = 1
		Me.CB_Accept.Text = "I know what I'm doing."
		Me.CB_Accept.UseVisualStyleBackColor = True
		'
		'GB_DebugControls
		'
		Me.GB_DebugControls.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.GB_DebugControls.Location = New System.Drawing.Point(13, 79)
		Me.GB_DebugControls.Name = "GB_DebugControls"
		Me.GB_DebugControls.Size = New System.Drawing.Size(432, 250)
		Me.GB_DebugControls.TabIndex = 2
		Me.GB_DebugControls.TabStop = False
		Me.GB_DebugControls.Text = "Debug Controls"
		'
		'MemDebugForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(457, 341)
		Me.Controls.Add(Me.GB_DebugControls)
		Me.Controls.Add(Me.CB_Accept)
		Me.Controls.Add(Me.Label1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "MemDebugForm"
		Me.Text = "Memory I/O Debug"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents CB_Accept As CheckBox
	Friend WithEvents GB_DebugControls As GroupBox
End Class
