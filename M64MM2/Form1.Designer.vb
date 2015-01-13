<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.b_Freeze = New System.Windows.Forms.Button()
        Me.b_Unfreeze = New System.Windows.Forms.Button()
        Me.b_ChangeCameraType = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'b_Freeze
        '
        Me.b_Freeze.Location = New System.Drawing.Point(12, 29)
        Me.b_Freeze.Name = "b_Freeze"
        Me.b_Freeze.Size = New System.Drawing.Size(147, 23)
        Me.b_Freeze.TabIndex = 0
        Me.b_Freeze.Text = "Freeze Camera"
        Me.b_Freeze.UseVisualStyleBackColor = True
        '
        'b_Unfreeze
        '
        Me.b_Unfreeze.Location = New System.Drawing.Point(165, 29)
        Me.b_Unfreeze.Name = "b_Unfreeze"
        Me.b_Unfreeze.Size = New System.Drawing.Size(147, 23)
        Me.b_Unfreeze.TabIndex = 1
        Me.b_Unfreeze.Text = "Unfreeze Camera"
        Me.b_Unfreeze.UseVisualStyleBackColor = True
        '
        'b_ChangeCameraType
        '
        Me.b_ChangeCameraType.Location = New System.Drawing.Point(318, 29)
        Me.b_ChangeCameraType.Name = "b_ChangeCameraType"
        Me.b_ChangeCameraType.Size = New System.Drawing.Size(145, 23)
        Me.b_ChangeCameraType.TabIndex = 2
        Me.b_ChangeCameraType.Text = "Change Camera Type"
        Me.b_ChangeCameraType.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "BaseAddress"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 64)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.b_ChangeCameraType)
        Me.Controls.Add(Me.b_Unfreeze)
        Me.Controls.Add(Me.b_Freeze)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Mario 64 Movie Maker 2.0"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents b_Freeze As System.Windows.Forms.Button
    Friend WithEvents b_Unfreeze As System.Windows.Forms.Button
    Friend WithEvents b_ChangeCameraType As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
