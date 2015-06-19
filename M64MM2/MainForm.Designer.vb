<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.b_Freeze = New System.Windows.Forms.Button()
        Me.b_Unfreeze = New System.Windows.Forms.Button()
        Me.b_ChangeCameraType = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AboutMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RetainAnimationSwapsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoPreviousAnimationSwapsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetAnimationSwapsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'b_Freeze
        '
        Me.b_Freeze.Enabled = False
        Me.b_Freeze.Location = New System.Drawing.Point(12, 44)
        Me.b_Freeze.Name = "b_Freeze"
        Me.b_Freeze.Size = New System.Drawing.Size(147, 23)
        Me.b_Freeze.TabIndex = 0
        Me.b_Freeze.Text = "Freeze Camera"
        Me.b_Freeze.UseVisualStyleBackColor = True
        '
        'b_Unfreeze
        '
        Me.b_Unfreeze.Enabled = False
        Me.b_Unfreeze.Location = New System.Drawing.Point(165, 44)
        Me.b_Unfreeze.Name = "b_Unfreeze"
        Me.b_Unfreeze.Size = New System.Drawing.Size(147, 23)
        Me.b_Unfreeze.TabIndex = 1
        Me.b_Unfreeze.Text = "Unfreeze Camera"
        Me.b_Unfreeze.UseVisualStyleBackColor = True
        '
        'b_ChangeCameraType
        '
        Me.b_ChangeCameraType.Enabled = False
        Me.b_ChangeCameraType.Location = New System.Drawing.Point(318, 44)
        Me.b_ChangeCameraType.Name = "b_ChangeCameraType"
        Me.b_ChangeCameraType.Size = New System.Drawing.Size(145, 23)
        Me.b_ChangeCameraType.TabIndex = 2
        Me.b_ChangeCameraType.Text = "Change Camera Type"
        Me.b_ChangeCameraType.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "BaseAddress"
        '
        'Timer1
        '
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(60, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ctrl + 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(219, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Ctrl + 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(371, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Ctrl + 3"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.MenuBar
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutMenu, Me.SettingsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(475, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AboutMenu
        '
        Me.AboutMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutMenuItem, Me.HelpToolStripMenuItem1})
        Me.AboutMenu.Name = "AboutMenu"
        Me.AboutMenu.Size = New System.Drawing.Size(52, 20)
        Me.AboutMenu.Text = "About"
        '
        'AboutMenuItem
        '
        Me.AboutMenuItem.Name = "AboutMenuItem"
        Me.AboutMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.AboutMenuItem.Size = New System.Drawing.Size(297, 22)
        Me.AboutMenuItem.Text = "About Mario 64 Movie Maker 2.0..."
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Enabled = False
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(297, 22)
        Me.HelpToolStripMenuItem1.Text = "Help..."
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RetainAnimationSwapsMenuItem, Me.UndoPreviousAnimationSwapsMenuItem, Me.ResetAnimationSwapsMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'RetainAnimationSwapsMenuItem
        '
        Me.RetainAnimationSwapsMenuItem.Checked = True
        Me.RetainAnimationSwapsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RetainAnimationSwapsMenuItem.Name = "RetainAnimationSwapsMenuItem"
        Me.RetainAnimationSwapsMenuItem.Size = New System.Drawing.Size(274, 22)
        Me.RetainAnimationSwapsMenuItem.Text = "Remeber previous animation swaps"
        Me.RetainAnimationSwapsMenuItem.ToolTipText = "When you select a new animation to be overwritten, any previous animations" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "will " & _
    "remain swapped until you manually change or reset them."
        '
        'UndoPreviousAnimationSwapsMenuItem
        '
        Me.UndoPreviousAnimationSwapsMenuItem.Name = "UndoPreviousAnimationSwapsMenuItem"
        Me.UndoPreviousAnimationSwapsMenuItem.Size = New System.Drawing.Size(274, 22)
        Me.UndoPreviousAnimationSwapsMenuItem.Text = "Undo previous animation swaps"
        Me.UndoPreviousAnimationSwapsMenuItem.ToolTipText = "When you select a new animation to be overwritten, the previous one" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "will be retu" & _
    "rned to its default animation."
        '
        'ResetAnimationSwapsMenuItem
        '
        Me.ResetAnimationSwapsMenuItem.Name = "ResetAnimationSwapsMenuItem"
        Me.ResetAnimationSwapsMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ResetAnimationSwapsMenuItem.Size = New System.Drawing.Size(274, 22)
        Me.ResetAnimationSwapsMenuItem.Text = "Reset all animations to default"
        Me.ResetAnimationSwapsMenuItem.ToolTipText = "This resets all animations to their original sequences."
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Enabled = False
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(12, 154)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(451, 21)
        Me.ComboBox2.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "With this animation:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 110)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(451, 21)
        Me.ComboBox1.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Overwrite this animation..."
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 186)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.b_ChangeCameraType)
        Me.Controls.Add(Me.b_Unfreeze)
        Me.Controls.Add(Me.b_Freeze)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Mario 64 Movie Maker 2.0"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents b_Freeze As System.Windows.Forms.Button
    Friend WithEvents b_Unfreeze As System.Windows.Forms.Button
    Friend WithEvents b_ChangeCameraType As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AboutMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RetainAnimationSwapsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoPreviousAnimationSwapsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetAnimationSwapsMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
