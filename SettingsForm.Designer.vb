<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsWindow
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PathFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.PathSelect = New System.Windows.Forms.Button()
        Me.DestSelect = New System.Windows.Forms.Button()
        Me.DestFolder = New System.Windows.Forms.FolderBrowserDialog()
        Me.OK = New System.Windows.Forms.Button()
        Me.StartCmd = New System.Windows.Forms.TextBox()
        Me.StartCmdLabel = New System.Windows.Forms.Label()
        Me.StartWithWindows = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Path"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Destination"
        '
        'PathSelect
        '
        Me.PathSelect.Location = New System.Drawing.Point(78, 32)
        Me.PathSelect.Name = "PathSelect"
        Me.PathSelect.Size = New System.Drawing.Size(149, 37)
        Me.PathSelect.TabIndex = 2
        Me.PathSelect.Text = "Select"
        Me.PathSelect.UseVisualStyleBackColor = True
        '
        'DestSelect
        '
        Me.DestSelect.Location = New System.Drawing.Point(78, 75)
        Me.DestSelect.Name = "DestSelect"
        Me.DestSelect.Size = New System.Drawing.Size(149, 37)
        Me.DestSelect.TabIndex = 3
        Me.DestSelect.Text = "Select"
        Me.DestSelect.UseVisualStyleBackColor = True
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(154, 211)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(75, 23)
        Me.OK.TabIndex = 4
        Me.OK.Text = "OK"
        Me.OK.UseVisualStyleBackColor = True
        '
        'StartCmd
        '
        Me.StartCmd.Location = New System.Drawing.Point(15, 185)
        Me.StartCmd.Name = "StartCmd"
        Me.StartCmd.Size = New System.Drawing.Size(212, 20)
        Me.StartCmd.TabIndex = 5
        '
        'StartCmdLabel
        '
        Me.StartCmdLabel.AutoSize = True
        Me.StartCmdLabel.Location = New System.Drawing.Point(12, 169)
        Me.StartCmdLabel.Name = "StartCmdLabel"
        Me.StartCmdLabel.Size = New System.Drawing.Size(103, 13)
        Me.StartCmdLabel.TabIndex = 6
        Me.StartCmdLabel.Text = "Run Cmd on Startup"
        '
        'StartWithWindows
        '
        Me.StartWithWindows.AutoSize = True
        Me.StartWithWindows.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartWithWindows.Location = New System.Drawing.Point(15, 135)
        Me.StartWithWindows.Name = "StartWithWindows"
        Me.StartWithWindows.Size = New System.Drawing.Size(152, 17)
        Me.StartWithWindows.TabIndex = 9
        Me.StartWithWindows.Text = "Start FileWatcher on Login"
        Me.StartWithWindows.UseVisualStyleBackColor = True
        '
        'SettingsWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(241, 255)
        Me.ControlBox = False
        Me.Controls.Add(Me.StartWithWindows)
        Me.Controls.Add(Me.StartCmdLabel)
        Me.Controls.Add(Me.StartCmd)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.DestSelect)
        Me.Controls.Add(Me.PathSelect)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "SettingsWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PathFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents PathSelect As System.Windows.Forms.Button
    Friend WithEvents DestSelect As System.Windows.Forms.Button
    Friend WithEvents DestFolder As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents StartCmd As System.Windows.Forms.TextBox
    Friend WithEvents StartCmdLabel As System.Windows.Forms.Label
    Friend WithEvents StartWithWindows As System.Windows.Forms.CheckBox
End Class
