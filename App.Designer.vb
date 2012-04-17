<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileWatcher
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileWatcher))
        Me.HideBtn = New System.Windows.Forms.Button()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ResetTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Watcher = New System.IO.FileSystemWatcher()
        Me.LogList = New System.Windows.Forms.ListBox()
        Me.SettingsBtn = New System.Windows.Forms.Button()
        CType(Me.Watcher, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HideBtn
        '
        Me.HideBtn.Location = New System.Drawing.Point(102, 490)
        Me.HideBtn.Name = "HideBtn"
        Me.HideBtn.Size = New System.Drawing.Size(600, 38)
        Me.HideBtn.TabIndex = 1
        Me.HideBtn.Text = "Hide"
        Me.HideBtn.UseVisualStyleBackColor = True
        '
        'TrayIcon
        '
        Me.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "FileWatcher"
        Me.TrayIcon.Visible = True
        '
        'ResetTimer
        '
        Me.ResetTimer.Enabled = True
        Me.ResetTimer.Interval = 1800000
        '
        'Watcher
        '
        Me.Watcher.EnableRaisingEvents = True
        Me.Watcher.IncludeSubdirectories = True
        Me.Watcher.NotifyFilter = CType((((System.IO.NotifyFilters.FileName Or System.IO.NotifyFilters.DirectoryName) _
                    Or System.IO.NotifyFilters.LastWrite) _
                    Or System.IO.NotifyFilters.LastAccess), System.IO.NotifyFilters)
        Me.Watcher.SynchronizingObject = Me
        '
        'LogList
        '
        Me.LogList.BackColor = System.Drawing.SystemColors.Control
        Me.LogList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LogList.FormattingEnabled = True
        Me.LogList.Location = New System.Drawing.Point(12, 12)
        Me.LogList.Name = "LogList"
        Me.LogList.Size = New System.Drawing.Size(690, 468)
        Me.LogList.TabIndex = 2
        '
        'SettingsBtn
        '
        Me.SettingsBtn.Location = New System.Drawing.Point(12, 490)
        Me.SettingsBtn.Name = "SettingsBtn"
        Me.SettingsBtn.Size = New System.Drawing.Size(84, 37)
        Me.SettingsBtn.TabIndex = 3
        Me.SettingsBtn.Text = "Settings"
        Me.SettingsBtn.UseVisualStyleBackColor = True
        '
        'FileWatcher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 540)
        Me.Controls.Add(Me.SettingsBtn)
        Me.Controls.Add(Me.HideBtn)
        Me.Controls.Add(Me.LogList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FileWatcher"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FileWatcher"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.Watcher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HideBtn As System.Windows.Forms.Button
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents ResetTimer As System.Windows.Forms.Timer
    Friend WithEvents Watcher As System.IO.FileSystemWatcher
    Friend WithEvents LogList As System.Windows.Forms.ListBox
    Friend WithEvents SettingsBtn As System.Windows.Forms.Button

End Class
