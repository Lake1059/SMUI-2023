Public Class 检查更新

    Public Shared Sub 运行后台服务器检查更新()
        If FileIO.FileSystem.FileExists(Application.StartupPath & "\steam_appid.txt") Then Exit Sub
        If FileIO.FileSystem.FileExists(Application.StartupPath & "\Portable") Then Exit Sub
        Form1.UiListBox3.Items(0) = "正在连接到服务器"
    End Sub


End Class
