<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.b_Freeze = New System.Windows.Forms.Button()
        Me.b_Unfreeze = New System.Windows.Forms.Button()
        Me.b_ChangeCameraType = New System.Windows.Forms.Button()
        Me.BaseAddressLabel = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RetainAnimationSwapsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoPreviousAnimationSwapsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ResetAnimationSwapsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ForceCameraPresetMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrecisionModeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorCodeStudioMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoryIODebugToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LicenseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.AnimOW2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.AnimOW1 = New System.Windows.Forms.Label()
        Me.b_SoftFreeze = New System.Windows.Forms.Button()
        Me.b_SoftUnfreeze = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NormalCamControls = New System.Windows.Forms.GroupBox()
        Me.AnimSwapControls = New System.Windows.Forms.GroupBox()
        Me.PrecisionCamControls = New System.Windows.Forms.GroupBox()
        Me.PrecisionStatusLabel = New System.Windows.Forms.Label()
        Me.b_PrecisionPlusOne = New System.Windows.Forms.Button()
        Me.LevControls = New System.Windows.Forms.GroupBox()
        Me.MinLeviHeight = New System.Windows.Forms.Label()
        Me.MaxLeviHeight = New System.Windows.Forms.Label()
        Me.LevitateTrackBar = New System.Windows.Forms.TrackBar()
        Me.Info = New System.Windows.Forms.ToolTip(Me.components)
        Me.SmallExtra = New System.Windows.Forms.GroupBox()
        Me.HealBTN = New System.Windows.Forms.Button()
        Me.DisableHudBTN = New System.Windows.Forms.Button()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.CurrentCameraAdvice_lb = New System.Windows.Forms.Label()
        Me.ChangeCam_btn = New System.Windows.Forms.Button()
        Me.CameraType_gb = New System.Windows.Forms.GroupBox()
        Me.MenuStrip1.SuspendLayout()
        Me.NormalCamControls.SuspendLayout()
        Me.AnimSwapControls.SuspendLayout()
        Me.PrecisionCamControls.SuspendLayout()
        Me.LevControls.SuspendLayout()
        CType(Me.LevitateTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SmallExtra.SuspendLayout()
        Me.CameraType_gb.SuspendLayout()
        Me.SuspendLayout()
        '
        'b_Freeze
        '
        Me.b_Freeze.Location = New System.Drawing.Point(7, 19)
        Me.b_Freeze.Name = "b_Freeze"
        Me.b_Freeze.Size = New System.Drawing.Size(144, 23)
        Me.b_Freeze.TabIndex = 0
        Me.b_Freeze.Text = "Freeze Camera"
        Me.b_Freeze.UseVisualStyleBackColor = True
        '
        'b_Unfreeze
        '
        Me.b_Unfreeze.Location = New System.Drawing.Point(155, 19)
        Me.b_Unfreeze.Name = "b_Unfreeze"
        Me.b_Unfreeze.Size = New System.Drawing.Size(144, 23)
        Me.b_Unfreeze.TabIndex = 1
        Me.b_Unfreeze.Text = "Unfreeze Camera"
        Me.b_Unfreeze.UseVisualStyleBackColor = True
        '
        'b_ChangeCameraType
        '
        Me.b_ChangeCameraType.Location = New System.Drawing.Point(303, 19)
        Me.b_ChangeCameraType.Name = "b_ChangeCameraType"
        Me.b_ChangeCameraType.Size = New System.Drawing.Size(144, 23)
        Me.b_ChangeCameraType.TabIndex = 2
        Me.b_ChangeCameraType.Text = "Prepare Camera"
        Me.b_ChangeCameraType.UseVisualStyleBackColor = True
        '
        'BaseAddressLabel
        '
        Me.BaseAddressLabel.AutoSize = True
        Me.BaseAddressLabel.Location = New System.Drawing.Point(10, 28)
        Me.BaseAddressLabel.Name = "BaseAddressLabel"
        Me.BaseAddressLabel.Size = New System.Drawing.Size(69, 13)
        Me.BaseAddressLabel.TabIndex = 3
        Me.BaseAddressLabel.Text = "BaseAddress"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(59, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ctrl + 1"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(207, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Ctrl + 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(355, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Ctrl + 3"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.MenuBar
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.AboutMenu})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(593, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RetainAnimationSwapsMenuItem, Me.UndoPreviousAnimationSwapsMenuItem, Me.ToolStripSeparator2, Me.ResetAnimationSwapsMenuItem, Me.ForceCameraPresetMenuItem, Me.ToolStripSeparator1, Me.PrecisionModeMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'RetainAnimationSwapsMenuItem
        '
        Me.RetainAnimationSwapsMenuItem.Checked = True
        Me.RetainAnimationSwapsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RetainAnimationSwapsMenuItem.Name = "RetainAnimationSwapsMenuItem"
        Me.RetainAnimationSwapsMenuItem.Size = New System.Drawing.Size(347, 22)
        Me.RetainAnimationSwapsMenuItem.Text = "Remeber previous animation swaps"
        Me.RetainAnimationSwapsMenuItem.ToolTipText = "When you select a new animation to be overwritten, any previous animations" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "will " &
    "remain swapped until you manually change or reset them."
        '
        'UndoPreviousAnimationSwapsMenuItem
        '
        Me.UndoPreviousAnimationSwapsMenuItem.Name = "UndoPreviousAnimationSwapsMenuItem"
        Me.UndoPreviousAnimationSwapsMenuItem.Size = New System.Drawing.Size(347, 22)
        Me.UndoPreviousAnimationSwapsMenuItem.Text = "Undo previous animation swaps"
        Me.UndoPreviousAnimationSwapsMenuItem.ToolTipText = "When you select a new animation to be overwritten, the previous one" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "will be retu" &
    "rned to its default animation."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(344, 6)
        '
        'ResetAnimationSwapsMenuItem
        '
        Me.ResetAnimationSwapsMenuItem.Enabled = False
        Me.ResetAnimationSwapsMenuItem.Name = "ResetAnimationSwapsMenuItem"
        Me.ResetAnimationSwapsMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ResetAnimationSwapsMenuItem.Size = New System.Drawing.Size(347, 22)
        Me.ResetAnimationSwapsMenuItem.Text = "Reset all animations to default (Broken)"
        Me.ResetAnimationSwapsMenuItem.ToolTipText = "This resets all animations to their original sequences." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "However, it currently do" &
    "es not work as intended, so" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "I have disabled it until I determine how to fix it." &
    ""
        '
        'ForceCameraPresetMenuItem
        '
        Me.ForceCameraPresetMenuItem.Name = "ForceCameraPresetMenuItem"
        Me.ForceCameraPresetMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ForceCameraPresetMenuItem.Size = New System.Drawing.Size(347, 22)
        Me.ForceCameraPresetMenuItem.Text = "Force camera to be movable with C-buttons"
        Me.ForceCameraPresetMenuItem.ToolTipText = resources.GetString("ForceCameraPresetMenuItem.ToolTipText")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(344, 6)
        '
        'PrecisionModeMenuItem
        '
        Me.PrecisionModeMenuItem.Name = "PrecisionModeMenuItem"
        Me.PrecisionModeMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrecisionModeMenuItem.Size = New System.Drawing.Size(347, 22)
        Me.PrecisionModeMenuItem.Text = "Enable Precision Mode"
        Me.PrecisionModeMenuItem.ToolTipText = "Enables Precision Camera Mode, which lets you" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "control the angle of the camera fr" &
    "om Mario's first-person" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "view and lock it wherever you want, and then readjust t" &
    "he camera at will." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColorCodeStudioMenuItem, Me.MemoryIODebugToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'ColorCodeStudioMenuItem
        '
        Me.ColorCodeStudioMenuItem.Name = "ColorCodeStudioMenuItem"
        Me.ColorCodeStudioMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ColorCodeStudioMenuItem.Text = "Color Code/Shading Studio"
        '
        'MemoryIODebugToolStripMenuItem
        '
        Me.MemoryIODebugToolStripMenuItem.Name = "MemoryIODebugToolStripMenuItem"
        Me.MemoryIODebugToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.MemoryIODebugToolStripMenuItem.Text = "Memory I/O Debug"
        '
        'AboutMenu
        '
        Me.AboutMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutMenuItem, Me.LicenseToolStripMenuItem1})
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
        'LicenseToolStripMenuItem1
        '
        Me.LicenseToolStripMenuItem1.Name = "LicenseToolStripMenuItem1"
        Me.LicenseToolStripMenuItem1.Size = New System.Drawing.Size(297, 22)
        Me.LicenseToolStripMenuItem1.Text = "Licensing Info..."
        '
        'ComboBox2
        '
        Me.ComboBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Enabled = False
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(7, 76)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(234, 21)
        Me.ComboBox2.TabIndex = 13
        '
        'AnimOW2
        '
        Me.AnimOW2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AnimOW2.AutoSize = True
        Me.AnimOW2.Location = New System.Drawing.Point(7, 61)
        Me.AnimOW2.Name = "AnimOW2"
        Me.AnimOW2.Size = New System.Drawing.Size(99, 13)
        Me.AnimOW2.TabIndex = 12
        Me.AnimOW2.Text = "With this animation:"
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Enabled = False
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(7, 32)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(234, 21)
        Me.ComboBox1.TabIndex = 11
        '
        'AnimOW1
        '
        Me.AnimOW1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AnimOW1.AutoSize = True
        Me.AnimOW1.Location = New System.Drawing.Point(7, 17)
        Me.AnimOW1.Name = "AnimOW1"
        Me.AnimOW1.Size = New System.Drawing.Size(128, 13)
        Me.AnimOW1.TabIndex = 10
        Me.AnimOW1.Text = "Overwrite this animation..."
        '
        'b_SoftFreeze
        '
        Me.b_SoftFreeze.Enabled = False
        Me.b_SoftFreeze.Location = New System.Drawing.Point(15, 69)
        Me.b_SoftFreeze.Name = "b_SoftFreeze"
        Me.b_SoftFreeze.Size = New System.Drawing.Size(128, 23)
        Me.b_SoftFreeze.TabIndex = 14
        Me.b_SoftFreeze.Text = "Soft-Freeze Camera"
        Me.b_SoftFreeze.UseVisualStyleBackColor = True
        '
        'b_SoftUnfreeze
        '
        Me.b_SoftUnfreeze.Enabled = False
        Me.b_SoftUnfreeze.Location = New System.Drawing.Point(312, 69)
        Me.b_SoftUnfreeze.Name = "b_SoftUnfreeze"
        Me.b_SoftUnfreeze.Size = New System.Drawing.Size(128, 23)
        Me.b_SoftUnfreeze.TabIndex = 14
        Me.b_SoftUnfreeze.Text = "Soft-Unfreeze Camera"
        Me.b_SoftUnfreeze.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(60, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Ctrl + 4"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(356, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Ctrl + 5"
        '
        'NormalCamControls
        '
        Me.NormalCamControls.Controls.Add(Me.b_SoftFreeze)
        Me.NormalCamControls.Controls.Add(Me.b_SoftUnfreeze)
        Me.NormalCamControls.Controls.Add(Me.Label5)
        Me.NormalCamControls.Controls.Add(Me.Label8)
        Me.NormalCamControls.Controls.Add(Me.Label2)
        Me.NormalCamControls.Controls.Add(Me.Label4)
        Me.NormalCamControls.Controls.Add(Me.b_Freeze)
        Me.NormalCamControls.Controls.Add(Me.Label3)
        Me.NormalCamControls.Controls.Add(Me.b_ChangeCameraType)
        Me.NormalCamControls.Controls.Add(Me.b_Unfreeze)
        Me.NormalCamControls.Location = New System.Drawing.Point(10, 44)
        Me.NormalCamControls.Name = "NormalCamControls"
        Me.NormalCamControls.Size = New System.Drawing.Size(454, 129)
        Me.NormalCamControls.TabIndex = 15
        Me.NormalCamControls.TabStop = False
        Me.NormalCamControls.Text = "Normal Camera Controls"
        '
        'AnimSwapControls
        '
        Me.AnimSwapControls.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.AnimSwapControls.Controls.Add(Me.AnimOW1)
        Me.AnimSwapControls.Controls.Add(Me.ComboBox1)
        Me.AnimSwapControls.Controls.Add(Me.ComboBox2)
        Me.AnimSwapControls.Controls.Add(Me.AnimOW2)
        Me.AnimSwapControls.Location = New System.Drawing.Point(10, 264)
        Me.AnimSwapControls.Name = "AnimSwapControls"
        Me.AnimSwapControls.Size = New System.Drawing.Size(247, 109)
        Me.AnimSwapControls.TabIndex = 16
        Me.AnimSwapControls.TabStop = False
        Me.AnimSwapControls.Text = "Animation Swap Control"
        '
        'PrecisionCamControls
        '
        Me.PrecisionCamControls.Controls.Add(Me.PrecisionStatusLabel)
        Me.PrecisionCamControls.Controls.Add(Me.b_PrecisionPlusOne)
        Me.PrecisionCamControls.Location = New System.Drawing.Point(10, 179)
        Me.PrecisionCamControls.Name = "PrecisionCamControls"
        Me.PrecisionCamControls.Size = New System.Drawing.Size(454, 80)
        Me.PrecisionCamControls.TabIndex = 17
        Me.PrecisionCamControls.TabStop = False
        Me.PrecisionCamControls.Text = "Precision Camera Control"
        '
        'PrecisionStatusLabel
        '
        Me.PrecisionStatusLabel.Location = New System.Drawing.Point(8, 17)
        Me.PrecisionStatusLabel.Name = "PrecisionStatusLabel"
        Me.PrecisionStatusLabel.Size = New System.Drawing.Size(438, 32)
        Me.PrecisionStatusLabel.TabIndex = 1
        Me.PrecisionStatusLabel.Text = "Precision Mode is disabled."
        Me.PrecisionStatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'b_PrecisionPlusOne
        '
        Me.b_PrecisionPlusOne.Enabled = False
        Me.b_PrecisionPlusOne.Location = New System.Drawing.Point(161, 51)
        Me.b_PrecisionPlusOne.Name = "b_PrecisionPlusOne"
        Me.b_PrecisionPlusOne.Size = New System.Drawing.Size(132, 23)
        Me.b_PrecisionPlusOne.TabIndex = 0
        Me.b_PrecisionPlusOne.Text = "Precision Mode Disabled"
        Me.b_PrecisionPlusOne.UseVisualStyleBackColor = True
        '
        'LevControls
        '
        Me.LevControls.Controls.Add(Me.MinLeviHeight)
        Me.LevControls.Controls.Add(Me.MaxLeviHeight)
        Me.LevControls.Controls.Add(Me.LevitateTrackBar)
        Me.LevControls.Location = New System.Drawing.Point(470, 44)
        Me.LevControls.Name = "LevControls"
        Me.LevControls.Size = New System.Drawing.Size(111, 184)
        Me.LevControls.TabIndex = 18
        Me.LevControls.TabStop = False
        Me.LevControls.Text = "Hover Height"
        '
        'MinLeviHeight
        '
        Me.MinLeviHeight.AutoSize = True
        Me.MinLeviHeight.Location = New System.Drawing.Point(37, 162)
        Me.MinLeviHeight.Name = "MinLeviHeight"
        Me.MinLeviHeight.Size = New System.Drawing.Size(59, 13)
        Me.MinLeviHeight.TabIndex = 1
        Me.MinLeviHeight.Text = "0 (Nothing)"
        Me.MinLeviHeight.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'MaxLeviHeight
        '
        Me.MaxLeviHeight.AutoSize = True
        Me.MaxLeviHeight.Location = New System.Drawing.Point(38, 24)
        Me.MaxLeviHeight.Name = "MaxLeviHeight"
        Me.MaxLeviHeight.Size = New System.Drawing.Size(58, 13)
        Me.MaxLeviHeight.TabIndex = 1
        Me.MaxLeviHeight.Text = "5 (Highest)"
        Me.MaxLeviHeight.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'LevitateTrackBar
        '
        Me.LevitateTrackBar.Location = New System.Drawing.Point(6, 19)
        Me.LevitateTrackBar.Maximum = 5
        Me.LevitateTrackBar.Name = "LevitateTrackBar"
        Me.LevitateTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.LevitateTrackBar.Size = New System.Drawing.Size(45, 165)
        Me.LevitateTrackBar.TabIndex = 0
        Me.Info.SetToolTip(Me.LevitateTrackBar, "Reminder: Some animations won't be affected by this. Recommended value is 1.")
        '
        'Info
        '
        Me.Info.IsBalloon = True
        Me.Info.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.Info.ToolTipTitle = "Hey!"
        '
        'SmallExtra
        '
        Me.SmallExtra.Controls.Add(Me.HealBTN)
        Me.SmallExtra.Controls.Add(Me.DisableHudBTN)
        Me.SmallExtra.Location = New System.Drawing.Point(470, 234)
        Me.SmallExtra.Name = "SmallExtra"
        Me.SmallExtra.Size = New System.Drawing.Size(111, 139)
        Me.SmallExtra.TabIndex = 19
        Me.SmallExtra.TabStop = False
        Me.SmallExtra.Text = "Small Extras"
        '
        'HealBTN
        '
        Me.HealBTN.Location = New System.Drawing.Point(6, 49)
        Me.HealBTN.Name = "HealBTN"
        Me.HealBTN.Size = New System.Drawing.Size(99, 24)
        Me.HealBTN.TabIndex = 2
        Me.HealBTN.Text = "Heal Mario"
        Me.HealBTN.UseVisualStyleBackColor = True
        Me.HealBTN.Visible = False
        '
        'DisableHudBTN
        '
        Me.DisableHudBTN.Location = New System.Drawing.Point(6, 19)
        Me.DisableHudBTN.Name = "DisableHudBTN"
        Me.DisableHudBTN.Size = New System.Drawing.Size(99, 24)
        Me.DisableHudBTN.TabIndex = 2
        Me.DisableHudBTN.Text = "Remove HUD"
        Me.DisableHudBTN.UseVisualStyleBackColor = True
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Enabled = False
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(15, 47)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(172, 21)
        Me.ComboBox3.TabIndex = 0
        '
        'CurrentCameraAdvice_lb
        '
        Me.CurrentCameraAdvice_lb.AutoSize = True
        Me.CurrentCameraAdvice_lb.Location = New System.Drawing.Point(12, 28)
        Me.CurrentCameraAdvice_lb.Name = "CurrentCameraAdvice_lb"
        Me.CurrentCameraAdvice_lb.Size = New System.Drawing.Size(178, 13)
        Me.CurrentCameraAdvice_lb.TabIndex = 1
        Me.CurrentCameraAdvice_lb.Text = "Change the current camera style for:"
        '
        'ChangeCam_btn
        '
        Me.ChangeCam_btn.Enabled = False
        Me.ChangeCam_btn.Location = New System.Drawing.Point(59, 74)
        Me.ChangeCam_btn.Name = "ChangeCam_btn"
        Me.ChangeCam_btn.Size = New System.Drawing.Size(75, 23)
        Me.ChangeCam_btn.TabIndex = 2
        Me.ChangeCam_btn.Text = "Change!"
        Me.ChangeCam_btn.UseVisualStyleBackColor = True
        '
        'CameraType_gb
        '
        Me.CameraType_gb.Controls.Add(Me.ChangeCam_btn)
        Me.CameraType_gb.Controls.Add(Me.CurrentCameraAdvice_lb)
        Me.CameraType_gb.Controls.Add(Me.ComboBox3)
        Me.CameraType_gb.Location = New System.Drawing.Point(263, 264)
        Me.CameraType_gb.Name = "CameraType_gb"
        Me.CameraType_gb.Size = New System.Drawing.Size(201, 109)
        Me.CameraType_gb.TabIndex = 20
        Me.CameraType_gb.TabStop = False
        Me.CameraType_gb.Text = "Camera Style Control"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 385)
        Me.Controls.Add(Me.CameraType_gb)
        Me.Controls.Add(Me.SmallExtra)
        Me.Controls.Add(Me.LevControls)
        Me.Controls.Add(Me.PrecisionCamControls)
        Me.Controls.Add(Me.AnimSwapControls)
        Me.Controls.Add(Me.NormalCamControls)
        Me.Controls.Add(Me.BaseAddressLabel)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Mario 64 Movie Maker 2.0.6"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.NormalCamControls.ResumeLayout(False)
        Me.NormalCamControls.PerformLayout()
        Me.AnimSwapControls.ResumeLayout(False)
        Me.AnimSwapControls.PerformLayout()
        Me.PrecisionCamControls.ResumeLayout(False)
        Me.LevControls.ResumeLayout(False)
        Me.LevControls.PerformLayout()
        CType(Me.LevitateTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SmallExtra.ResumeLayout(False)
        Me.CameraType_gb.ResumeLayout(False)
        Me.CameraType_gb.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents b_Freeze As System.Windows.Forms.Button
    Friend WithEvents b_Unfreeze As System.Windows.Forms.Button
    Friend WithEvents b_ChangeCameraType As System.Windows.Forms.Button
    Friend WithEvents BaseAddressLabel As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AboutMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LicenseToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents AnimOW2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents AnimOW1 As System.Windows.Forms.Label
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RetainAnimationSwapsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoPreviousAnimationSwapsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetAnimationSwapsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents b_SoftFreeze As System.Windows.Forms.Button
    Friend WithEvents b_SoftUnfreeze As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ForceCameraPresetMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrecisionModeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NormalCamControls As System.Windows.Forms.GroupBox
    Friend WithEvents AnimSwapControls As System.Windows.Forms.GroupBox
    Friend WithEvents PrecisionCamControls As System.Windows.Forms.GroupBox
    Friend WithEvents PrecisionStatusLabel As System.Windows.Forms.Label
    Friend WithEvents b_PrecisionPlusOne As System.Windows.Forms.Button
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColorCodeStudioMenuItem As ToolStripMenuItem
    Friend WithEvents MemoryIODebugToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LevControls As GroupBox
    Friend WithEvents MinLeviHeight As Label
    Friend WithEvents MaxLeviHeight As Label
    Friend WithEvents LevitateTrackBar As TrackBar
    Friend WithEvents Info As ToolTip
    Friend WithEvents SmallExtra As GroupBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents HealBTN As Button
    Friend WithEvents DisableHudBTN As Button
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents CurrentCameraAdvice_lb As Label
    Friend WithEvents ChangeCam_btn As Button
    Friend WithEvents CameraType_gb As GroupBox
End Class
