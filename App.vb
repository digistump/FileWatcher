Imports System.IO

Public Class FileWatcher
    Dim modTimes As New Dictionary(Of String, String)


    Private Sub HideBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideBtn.Click
        Me.WindowState = FormWindowState.Minimized
        Me.Hide()
    End Sub

    Private Sub FileWatcher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If My.Settings.Path.Length > 0 And My.Settings.Destination.Length > 0 Then
            Watcher.Path = My.Settings.Path
            Watcher.NotifyFilter = (NotifyFilters.LastAccess Or NotifyFilters.LastWrite Or NotifyFilters.FileName _
                                               Or NotifyFilters.DirectoryName Or NotifyFilters.CreationTime Or _
                                               NotifyFilters.Size Or NotifyFilters.Attributes Or NotifyFilters.Size)
            Watcher.IncludeSubdirectories = True
            Watcher.EnableRaisingEvents = True
            If My.Settings.StartCmd.Length > 0 Then
                Dim ProcID As Integer
                ProcID = Shell(My.Settings.StartCmd, AppWinStyle.NormalFocus)
                Dim startprocess As Process = Process.GetProcessById(ProcID)
                startprocess.WaitForExit()
            End If
        Else
            SettingsWindow.Show()
        End If

        Me.Hide()
    End Sub

    Public Sub WatcherEvent(ByVal sender As System.Object, ByVal e As System.IO.FileSystemEventArgs) Handles Watcher.Changed, Watcher.Deleted, Watcher.Created


        Try
            If e.FullPath.Contains(".svn") Or e.FullPath.Contains(".git") Then
                Skip(e.FullPath)
                Return
            End If


            If modTimes.Count < 1 Then
                modTimes.Add(" ", " ")
            End If

            Dim target As String = e.FullPath.Replace(My.Settings.Path, My.Settings.Destination)

            Dim dir As Boolean = False
            If e.ChangeType = WatcherChangeTypes.Deleted Then
                Try
                    dir = Directory.Exists(target)
                Catch

                End Try
            Else
                dir = Directory.Exists(e.FullPath)
            End If



            If dir Then
                If e.ChangeType = WatcherChangeTypes.Changed Then
                    Skip(e.FullPath)
                    Return
                End If

                Dim dirinfo As DirectoryInfo
                'create or delete
                If e.ChangeType = WatcherChangeTypes.Deleted Then
                    Try
                        dirinfo = New DirectoryInfo(target)
                    Catch

                    End Try
                Else
                    dirinfo = New DirectoryInfo(e.FullPath)
                End If

                If dirinfo.Attributes.HasFlag(FileAttributes.Hidden) Then
                    Skip(e.FullPath)
                    Return
                ElseIf e.ChangeType = WatcherChangeTypes.Created Then
                    'Create
                    Try
                        Directory.CreateDirectory(target)
                        LogList.Items.Add("Create dir: " & e.FullPath)
                    Catch
                        LogList.Items.Add("FAIL - Create dir: " & e.FullPath)
                        TrayIcon.BalloonTipText = "FAIL - Create dir: " & e.FullPath
                        TrayIcon.ShowBalloonTip(2000)
                    End Try

                    'Are we coming out of a move?
                    If (Not (File.GetAttributes(e.FullPath) And FileAttributes.Directory) = 0) Then
                        DiretoryHelper(e.FullPath)
                    End If


                ElseIf e.ChangeType = WatcherChangeTypes.Deleted Then

                    'Delete
                    Try
                        Directory.Delete(target, True)
                        LogList.Items.Add("Del dir: " & e.FullPath)
                    Catch
                        LogList.Items.Add("FAIL - Del dir: " & e.FullPath)
                        TrayIcon.BalloonTipText = "FAIL - Del dir: " & e.FullPath
                        TrayIcon.ShowBalloonTip(2000)
                    End Try
                End If

            ElseIf e.ChangeType = WatcherChangeTypes.Deleted Then
                Try
                    If File.GetAttributes(target).HasFlag(FileAttributes.Hidden) Then
                        Skip(e.FullPath)
                        Return
                    End If
                Catch

                End Try
                'Delete
                Try
                    File.Delete(target)
                    LogList.Items.Add("Del: " & e.FullPath)
                Catch
                    LogList.Items.Add("FAIL - Del: " & e.FullPath)
                    TrayIcon.BalloonTipText = "FAIL - Del: " & e.FullPath
                    TrayIcon.ShowBalloonTip(2000)
                End Try
            ElseIf File.GetAttributes(e.FullPath).HasFlag(FileAttributes.Hidden) Then
                Skip(e.FullPath)
                Return

            ElseIf modTimes.ContainsKey(e.FullPath.ToString) Then
                Dim lastWrite = File.GetLastWriteTime(e.FullPath)
                If modTimes(e.FullPath) <> lastWrite.ToString Then
                    GoTo DoActionLine
                Else
                    Skip(e.FullPath)
                    Return
                End If
            Else
DoActionLine:
                'do action
                Dim lastWrite = File.GetLastWriteTime(e.FullPath)
                If modTimes.ContainsKey(e.FullPath) Then
                    modTimes(e.FullPath.ToString) = lastWrite.ToString
                Else
                    modTimes.Add(e.FullPath, lastWrite)
                End If

                If e.ChangeType = WatcherChangeTypes.Changed Then
                    Try
                        File.Copy(e.FullPath, target, True)
                        LogList.Items.Add("Change: " & e.FullPath)
                    Catch
                        LogList.Items.Add("FAIL - Change: " & e.FullPath)
                        TrayIcon.BalloonTipText = "FAIL - Change: " & e.FullPath
                        TrayIcon.ShowBalloonTip(2000)
                    End Try
                ElseIf e.ChangeType = WatcherChangeTypes.Created Then
                    'Create
                    Try
                        File.Copy(e.FullPath, target, True)
                        LogList.Items.Add("Create: " & e.FullPath)
                    Catch
                        LogList.Items.Add("FAIL - Create: " & e.FullPath)
                        TrayIcon.BalloonTipText = "FAIL - Create: " & e.FullPath
                        TrayIcon.ShowBalloonTip(2000)

                    End Try
                Else
                    LogList.Items.Add("Unknown: " & e.FullPath)

                End If

            End If

        Catch

        End Try


    End Sub
    Private Sub DiretoryHelper(ByVal dirName As String)
        Try
            For Each subDir In Directory.GetDirectories(dirName)
                Dim target As String = subDir.Replace(My.Settings.Path, My.Settings.Destination)
                Try
                    Directory.CreateDirectory(target)
                    LogList.Items.Add("Create dir: " & subDir)
                Catch
                    LogList.Items.Add("FAIL - Create dir: " & subDir)
                    TrayIcon.BalloonTipText = "FAIL - Create dir: " & subDir
                    TrayIcon.ShowBalloonTip(2000)
                End Try
                DiretoryHelper(subDir)
            Next

            For Each fileName In Directory.GetFiles(dirName)
                Dim target As String = fileName.Replace(My.Settings.Path, My.Settings.Destination)
                Try
                    File.Copy(fileName, target, True)
                    LogList.Items.Add("Change: " & fileName)
                Catch
                    LogList.Items.Add("FAIL - Change: " & fileName)
                    TrayIcon.BalloonTipText = "FAIL - Change: " & fileName
                    TrayIcon.ShowBalloonTip(2000)
                End Try
            Next

        Catch

        End Try
    End Sub
    Private Sub WatcherRenameEvent(ByVal sender As System.Object, ByVal e As System.IO.RenamedEventArgs) Handles Watcher.Renamed

        If e.FullPath.Contains(".svn") Or e.FullPath.Contains(".git") Then
            Skip(e.FullPath)
            Return
        End If

        Dim target As String = e.FullPath.Replace(My.Settings.Path, My.Settings.Destination)
        Dim oldtarget As String = e.OldFullPath.Replace(My.Settings.Path, My.Settings.Destination)

        Dim dir As Boolean = Directory.Exists(e.FullPath)

        If dir Then
            Dim dirinfo As DirectoryInfo = New DirectoryInfo(e.FullPath)
            If dirinfo.Attributes.HasFlag(FileAttributes.Hidden) Then
                Skip(e.FullPath)
                Return
            End If
            Try
                Directory.Move(oldtarget, target)
                LogList.Items.Add("Rename dir: " & e.FullPath)
            Catch
                LogList.Items.Add("FAIL - Rename dir: " & e.FullPath)
                TrayIcon.BalloonTipText = "FAIL - Rename dir: " & e.FullPath
                TrayIcon.ShowBalloonTip(2000)
            End Try

        Else
            If File.GetAttributes(e.FullPath).HasFlag(FileAttributes.Hidden) Then
                Skip(e.FullPath)
                Return
            End If
            Try
                File.Move(oldtarget, target)
                LogList.Items.Add("Rename: " & e.FullPath)
            Catch
                LogList.Items.Add("FAIL - Rename: " & e.FullPath)
                TrayIcon.BalloonTipText = "FAIL - Rename: " & e.FullPath
                TrayIcon.ShowBalloonTip(2000)
            End Try

        End If

    End Sub


    Function Skip(ByVal path As String)
        LogList.Items.Add("Skip: " & path)
        Return Nothing

    End Function

    Private Sub ResetTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetTimer.Tick
        modTimes.Clear()
        LogList.Items.Clear()
    End Sub

    Private Sub TrayIcon_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrayIcon.MouseClick
        If e.Button = MouseButtons.Left Then
            If Me.Visible = False Then
                Me.Show()
                Me.WindowState = FormWindowState.Normal
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub SettingsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsBtn.Click
        SettingsWindow.Show()
    End Sub


    Private Sub TrayIcon_BalloonTipClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrayIcon.BalloonTipClicked
        If Me.Visible = False Then
            Me.Show()
            Me.WindowState = FormWindowState.Normal
        End If

    End Sub
End Class


