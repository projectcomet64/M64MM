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
        Me.LB_Disclaimer = New System.Windows.Forms.Label()
        Me.CB_Accept = New System.Windows.Forms.CheckBox()
        Me.GB_DebugControls = New System.Windows.Forms.GroupBox()
        Me.AAFirst_btn = New System.Windows.Forms.Button()
        Me.B_Write4 = New System.Windows.Forms.Button()
        Me.B_Read4 = New System.Windows.Forms.Button()
        Me.IN_Value4 = New System.Windows.Forms.TextBox()
        Me.IN_Address4 = New System.Windows.Forms.TextBox()
        Me.LB_Value4 = New System.Windows.Forms.Label()
        Me.LB_Address4 = New System.Windows.Forms.Label()
        Me.B_Write3 = New System.Windows.Forms.Button()
        Me.B_Read3 = New System.Windows.Forms.Button()
        Me.IN_Value3 = New System.Windows.Forms.TextBox()
        Me.IN_Address3 = New System.Windows.Forms.TextBox()
        Me.LB_Value3 = New System.Windows.Forms.Label()
        Me.LB_Address3 = New System.Windows.Forms.Label()
        Me.B_Write2 = New System.Windows.Forms.Button()
        Me.B_Read2 = New System.Windows.Forms.Button()
        Me.IN_Value2 = New System.Windows.Forms.TextBox()
        Me.IN_Address2 = New System.Windows.Forms.TextBox()
        Me.LB_Value2 = New System.Windows.Forms.Label()
        Me.LB_Address2 = New System.Windows.Forms.Label()
        Me.B_Write1 = New System.Windows.Forms.Button()
        Me.B_Read1 = New System.Windows.Forms.Button()
        Me.IN_Value1 = New System.Windows.Forms.TextBox()
        Me.IN_Address1 = New System.Windows.Forms.TextBox()
        Me.LB_Value1 = New System.Windows.Forms.Label()
        Me.LB_Address1 = New System.Windows.Forms.Label()
        Me.GB_DebugControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'LB_Disclaimer
        '
        Me.LB_Disclaimer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LB_Disclaimer.Location = New System.Drawing.Point(12, 9)
        Me.LB_Disclaimer.Name = "LB_Disclaimer"
        Me.LB_Disclaimer.Size = New System.Drawing.Size(309, 59)
        Me.LB_Disclaimer.TabIndex = 0
        Me.LB_Disclaimer.Text = resources.GetString("LB_Disclaimer.Text")
        '
        'CB_Accept
        '
        Me.CB_Accept.AutoSize = True
        Me.CB_Accept.Enabled = False
        Me.CB_Accept.Location = New System.Drawing.Point(12, 80)
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
        Me.GB_DebugControls.Controls.Add(Me.AAFirst_btn)
        Me.GB_DebugControls.Controls.Add(Me.B_Write4)
        Me.GB_DebugControls.Controls.Add(Me.B_Read4)
        Me.GB_DebugControls.Controls.Add(Me.IN_Value4)
        Me.GB_DebugControls.Controls.Add(Me.IN_Address4)
        Me.GB_DebugControls.Controls.Add(Me.LB_Value4)
        Me.GB_DebugControls.Controls.Add(Me.LB_Address4)
        Me.GB_DebugControls.Controls.Add(Me.B_Write3)
        Me.GB_DebugControls.Controls.Add(Me.B_Read3)
        Me.GB_DebugControls.Controls.Add(Me.IN_Value3)
        Me.GB_DebugControls.Controls.Add(Me.IN_Address3)
        Me.GB_DebugControls.Controls.Add(Me.LB_Value3)
        Me.GB_DebugControls.Controls.Add(Me.LB_Address3)
        Me.GB_DebugControls.Controls.Add(Me.B_Write2)
        Me.GB_DebugControls.Controls.Add(Me.B_Read2)
        Me.GB_DebugControls.Controls.Add(Me.IN_Value2)
        Me.GB_DebugControls.Controls.Add(Me.IN_Address2)
        Me.GB_DebugControls.Controls.Add(Me.LB_Value2)
        Me.GB_DebugControls.Controls.Add(Me.LB_Address2)
        Me.GB_DebugControls.Controls.Add(Me.B_Write1)
        Me.GB_DebugControls.Controls.Add(Me.B_Read1)
        Me.GB_DebugControls.Controls.Add(Me.IN_Value1)
        Me.GB_DebugControls.Controls.Add(Me.IN_Address1)
        Me.GB_DebugControls.Controls.Add(Me.LB_Value1)
        Me.GB_DebugControls.Controls.Add(Me.LB_Address1)
        Me.GB_DebugControls.Enabled = False
        Me.GB_DebugControls.Location = New System.Drawing.Point(13, 103)
        Me.GB_DebugControls.Name = "GB_DebugControls"
        Me.GB_DebugControls.Size = New System.Drawing.Size(308, 303)
        Me.GB_DebugControls.TabIndex = 2
        Me.GB_DebugControls.TabStop = False
        Me.GB_DebugControls.Text = "Debug Controls"
        '
        'AAFirst_btn
        '
        Me.AAFirst_btn.Location = New System.Drawing.Point(92, 270)
        Me.AAFirst_btn.Name = "AAFirst_btn"
        Me.AAFirst_btn.Size = New System.Drawing.Size(125, 23)
        Me.AAFirst_btn.TabIndex = 25
        Me.AAFirst_btn.Text = "don't mind me yet"
        Me.AAFirst_btn.UseVisualStyleBackColor = True
        Me.AAFirst_btn.Visible = False
        '
        'B_Write4
        '
        Me.B_Write4.Location = New System.Drawing.Point(240, 241)
        Me.B_Write4.Name = "B_Write4"
        Me.B_Write4.Size = New System.Drawing.Size(57, 23)
        Me.B_Write4.TabIndex = 24
        Me.B_Write4.Text = "Write"
        Me.B_Write4.UseVisualStyleBackColor = True
        '
        'B_Read4
        '
        Me.B_Read4.Location = New System.Drawing.Point(172, 241)
        Me.B_Read4.Name = "B_Read4"
        Me.B_Read4.Size = New System.Drawing.Size(57, 23)
        Me.B_Read4.TabIndex = 23
        Me.B_Read4.Text = "Read"
        Me.B_Read4.UseVisualStyleBackColor = True
        '
        'IN_Value4
        '
        Me.IN_Value4.Location = New System.Drawing.Point(172, 215)
        Me.IN_Value4.MaxLength = 8
        Me.IN_Value4.Name = "IN_Value4"
        Me.IN_Value4.Size = New System.Drawing.Size(125, 20)
        Me.IN_Value4.TabIndex = 22
        '
        'IN_Address4
        '
        Me.IN_Address4.Location = New System.Drawing.Point(172, 172)
        Me.IN_Address4.MaxLength = 8
        Me.IN_Address4.Name = "IN_Address4"
        Me.IN_Address4.Size = New System.Drawing.Size(125, 20)
        Me.IN_Address4.TabIndex = 21
        '
        'LB_Value4
        '
        Me.LB_Value4.AutoSize = True
        Me.LB_Value4.Location = New System.Drawing.Point(169, 198)
        Me.LB_Value4.Name = "LB_Value4"
        Me.LB_Value4.Size = New System.Drawing.Size(37, 13)
        Me.LB_Value4.TabIndex = 20
        Me.LB_Value4.Text = "Value:"
        '
        'LB_Address4
        '
        Me.LB_Address4.AutoSize = True
        Me.LB_Address4.Location = New System.Drawing.Point(169, 155)
        Me.LB_Address4.Name = "LB_Address4"
        Me.LB_Address4.Size = New System.Drawing.Size(48, 13)
        Me.LB_Address4.TabIndex = 19
        Me.LB_Address4.Text = "Address:"
        '
        'B_Write3
        '
        Me.B_Write3.Location = New System.Drawing.Point(77, 241)
        Me.B_Write3.Name = "B_Write3"
        Me.B_Write3.Size = New System.Drawing.Size(57, 23)
        Me.B_Write3.TabIndex = 18
        Me.B_Write3.Text = "Write"
        Me.B_Write3.UseVisualStyleBackColor = True
        '
        'B_Read3
        '
        Me.B_Read3.Location = New System.Drawing.Point(9, 241)
        Me.B_Read3.Name = "B_Read3"
        Me.B_Read3.Size = New System.Drawing.Size(57, 23)
        Me.B_Read3.TabIndex = 17
        Me.B_Read3.Text = "Read"
        Me.B_Read3.UseVisualStyleBackColor = True
        '
        'IN_Value3
        '
        Me.IN_Value3.Location = New System.Drawing.Point(9, 215)
        Me.IN_Value3.MaxLength = 8
        Me.IN_Value3.Name = "IN_Value3"
        Me.IN_Value3.Size = New System.Drawing.Size(125, 20)
        Me.IN_Value3.TabIndex = 16
        '
        'IN_Address3
        '
        Me.IN_Address3.Location = New System.Drawing.Point(9, 172)
        Me.IN_Address3.MaxLength = 8
        Me.IN_Address3.Name = "IN_Address3"
        Me.IN_Address3.Size = New System.Drawing.Size(125, 20)
        Me.IN_Address3.TabIndex = 15
        '
        'LB_Value3
        '
        Me.LB_Value3.AutoSize = True
        Me.LB_Value3.Location = New System.Drawing.Point(6, 198)
        Me.LB_Value3.Name = "LB_Value3"
        Me.LB_Value3.Size = New System.Drawing.Size(37, 13)
        Me.LB_Value3.TabIndex = 14
        Me.LB_Value3.Text = "Value:"
        '
        'LB_Address3
        '
        Me.LB_Address3.AutoSize = True
        Me.LB_Address3.Location = New System.Drawing.Point(6, 155)
        Me.LB_Address3.Name = "LB_Address3"
        Me.LB_Address3.Size = New System.Drawing.Size(48, 13)
        Me.LB_Address3.TabIndex = 13
        Me.LB_Address3.Text = "Address:"
        '
        'B_Write2
        '
        Me.B_Write2.Location = New System.Drawing.Point(240, 107)
        Me.B_Write2.Name = "B_Write2"
        Me.B_Write2.Size = New System.Drawing.Size(57, 23)
        Me.B_Write2.TabIndex = 12
        Me.B_Write2.Text = "Write"
        Me.B_Write2.UseVisualStyleBackColor = True
        '
        'B_Read2
        '
        Me.B_Read2.Location = New System.Drawing.Point(172, 107)
        Me.B_Read2.Name = "B_Read2"
        Me.B_Read2.Size = New System.Drawing.Size(57, 23)
        Me.B_Read2.TabIndex = 11
        Me.B_Read2.Text = "Read"
        Me.B_Read2.UseVisualStyleBackColor = True
        '
        'IN_Value2
        '
        Me.IN_Value2.Location = New System.Drawing.Point(172, 81)
        Me.IN_Value2.MaxLength = 8
        Me.IN_Value2.Name = "IN_Value2"
        Me.IN_Value2.Size = New System.Drawing.Size(125, 20)
        Me.IN_Value2.TabIndex = 10
        '
        'IN_Address2
        '
        Me.IN_Address2.Location = New System.Drawing.Point(172, 38)
        Me.IN_Address2.MaxLength = 8
        Me.IN_Address2.Name = "IN_Address2"
        Me.IN_Address2.Size = New System.Drawing.Size(125, 20)
        Me.IN_Address2.TabIndex = 9
        '
        'LB_Value2
        '
        Me.LB_Value2.AutoSize = True
        Me.LB_Value2.Location = New System.Drawing.Point(169, 64)
        Me.LB_Value2.Name = "LB_Value2"
        Me.LB_Value2.Size = New System.Drawing.Size(37, 13)
        Me.LB_Value2.TabIndex = 8
        Me.LB_Value2.Text = "Value:"
        '
        'LB_Address2
        '
        Me.LB_Address2.AutoSize = True
        Me.LB_Address2.Location = New System.Drawing.Point(169, 21)
        Me.LB_Address2.Name = "LB_Address2"
        Me.LB_Address2.Size = New System.Drawing.Size(48, 13)
        Me.LB_Address2.TabIndex = 7
        Me.LB_Address2.Text = "Address:"
        '
        'B_Write1
        '
        Me.B_Write1.Location = New System.Drawing.Point(77, 107)
        Me.B_Write1.Name = "B_Write1"
        Me.B_Write1.Size = New System.Drawing.Size(57, 23)
        Me.B_Write1.TabIndex = 6
        Me.B_Write1.Text = "Write"
        Me.B_Write1.UseVisualStyleBackColor = True
        '
        'B_Read1
        '
        Me.B_Read1.Location = New System.Drawing.Point(9, 107)
        Me.B_Read1.Name = "B_Read1"
        Me.B_Read1.Size = New System.Drawing.Size(57, 23)
        Me.B_Read1.TabIndex = 5
        Me.B_Read1.Text = "Read"
        Me.B_Read1.UseVisualStyleBackColor = True
        '
        'IN_Value1
        '
        Me.IN_Value1.Location = New System.Drawing.Point(9, 81)
        Me.IN_Value1.MaxLength = 8
        Me.IN_Value1.Name = "IN_Value1"
        Me.IN_Value1.Size = New System.Drawing.Size(125, 20)
        Me.IN_Value1.TabIndex = 4
        '
        'IN_Address1
        '
        Me.IN_Address1.Location = New System.Drawing.Point(9, 38)
        Me.IN_Address1.MaxLength = 8
        Me.IN_Address1.Name = "IN_Address1"
        Me.IN_Address1.Size = New System.Drawing.Size(125, 20)
        Me.IN_Address1.TabIndex = 3
        '
        'LB_Value1
        '
        Me.LB_Value1.AutoSize = True
        Me.LB_Value1.Location = New System.Drawing.Point(6, 64)
        Me.LB_Value1.Name = "LB_Value1"
        Me.LB_Value1.Size = New System.Drawing.Size(37, 13)
        Me.LB_Value1.TabIndex = 2
        Me.LB_Value1.Text = "Value:"
        '
        'LB_Address1
        '
        Me.LB_Address1.AutoSize = True
        Me.LB_Address1.Location = New System.Drawing.Point(6, 21)
        Me.LB_Address1.Name = "LB_Address1"
        Me.LB_Address1.Size = New System.Drawing.Size(48, 13)
        Me.LB_Address1.TabIndex = 0
        Me.LB_Address1.Text = "Address:"
        '
        'MemDebugForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 418)
        Me.Controls.Add(Me.GB_DebugControls)
        Me.Controls.Add(Me.CB_Accept)
        Me.Controls.Add(Me.LB_Disclaimer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MemDebugForm"
        Me.Text = "Memory I/O Debug"
        Me.GB_DebugControls.ResumeLayout(False)
        Me.GB_DebugControls.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LB_Disclaimer As Label
	Friend WithEvents CB_Accept As CheckBox
	Friend WithEvents GB_DebugControls As GroupBox
	Friend WithEvents LB_Address1 As Label
	Friend WithEvents LB_Value1 As Label
	Friend WithEvents IN_Value1 As TextBox
	Friend WithEvents IN_Address1 As TextBox
    Friend WithEvents B_Write1 As Button
    Friend WithEvents B_Read1 As Button
    Friend WithEvents B_Write4 As Button
    Friend WithEvents B_Read4 As Button
    Friend WithEvents IN_Value4 As TextBox
    Friend WithEvents IN_Address4 As TextBox
    Friend WithEvents LB_Value4 As Label
    Friend WithEvents LB_Address4 As Label
    Friend WithEvents B_Write3 As Button
    Friend WithEvents B_Read3 As Button
    Friend WithEvents IN_Value3 As TextBox
    Friend WithEvents IN_Address3 As TextBox
    Friend WithEvents LB_Value3 As Label
    Friend WithEvents LB_Address3 As Label
    Friend WithEvents B_Write2 As Button
    Friend WithEvents B_Read2 As Button
    Friend WithEvents IN_Value2 As TextBox
    Friend WithEvents IN_Address2 As TextBox
    Friend WithEvents LB_Value2 As Label
    Friend WithEvents LB_Address2 As Label
    Friend WithEvents AAFirst_btn As Button
End Class
