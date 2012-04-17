Imports Microsoft.Win32

Public Class SettingsWindow

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        My.Settings.Path = PathFolder.SelectedPath.ToString
        My.Settings.Destination = DestFolder.SelectedPath.ToString
        My.Settings.StartCmd = StartCmd.Text

        If My.Settings.Path.Length > 0 And My.Settings.Destination.Length > 0 Then
            If My.Settings.Path.Substring(My.Settings.Path.Length - 1) <> "\" Then
                My.Settings.Path = My.Settings.Path & "\"
            End If
            If My.Settings.Destination.Substring(My.Settings.Destination.Length - 1) <> "\" Then
                My.Settings.Destination = My.Settings.Destination & "\"
            End If

            If StartWithWindows.Checked Then
                Dim regKey As RegistryKey
                regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                regKey.SetValue("FileWatcher", Application.ExecutablePath)
                regKey.Close()
            Else
                Dim regKey As RegistryKey
                regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                regKey.DeleteValue("FileWatcher", False)
                regKey.Close()
            End If
        End If
        My.Settings.Save()

        MsgBox("FileWatcher will now restart to apply the settings.")
        Application.Restart()

        Me.Hide()
    End Sub

    Private Sub SettingsWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PathFolder.SelectedPath = My.Settings.Path
        DestFolder.SelectedPath = My.Settings.Destination
        StartCmd.Text = My.Settings.StartCmd

        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        If regKey.GetValue("FileWatcher") Is Nothing Then
        Else
            StartWithWindows.Checked = True
        End If
        regKey.Close()

    End Sub

    Private Sub PathSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PathSelect.Click
        PathFolder.ShowDialog()

    End Sub

    Private Sub DestSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DestSelect.Click
        DestFolder.ShowDialog()

    End Sub
End Class