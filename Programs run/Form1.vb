
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Left = 0
            Me.Top = 0
            Me.Height = 28
            Me.Width = SystemInformation.PrimaryMonitorSize.Width
        Catch ex As Exception
        End Try
    End Sub

    Private Sub StartupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartupToolStripMenuItem.Click
        'كود إظافة البرنامج مع بدأ التشغيل
        If StartupToolStripMenuItem.Checked = True Then
            Dim applicationName As String = Application.ProductName
            Dim applicationPath As String = Application.ExecutablePath
            Dim regKey As Microsoft.Win32.RegistryKey
            regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            regKey.SetValue(applicationName, """" & applicationPath & """")
            regKey.Close()
        Else
            'كود إزالة البرنامج من بدأ التشغيل
            Dim applicationName As String = Application.ProductName
            Dim applicationPath As String = Application.ExecutablePath
            Dim regKey As Microsoft.Win32.RegistryKey
            regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            regKey.DeleteValue(applicationName, False)
            regKey.Close()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ContextMenuStrip1.Show(PictureBox1, 1, PictureBox1.Height)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Diagnostics.Process.Start(ComboBox1.Text)
        Catch ex As Exception
            MsgBox(ex.Message & "", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, ComboBox1.Text)
        End Try
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Process.Start(ComboBox1.Text)
            Catch ex As Exception
                MsgBox("")
            End Try
        End If
    End Sub
End Class
