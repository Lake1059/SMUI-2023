
Imports System.IO

Public Class 清理空间

    Public Shared Sub 刷新存储信息()
        Dim s1 As Integer = 0
        s1 += FileIO.FileSystem.GetFileInfo(Application.ExecutablePath).Length
        s1 += FileIO.FileSystem.GetFileInfo(IO.Path.Combine(Application.StartupPath, "SMUI6.dll")).Length
        Form1.ListView10.Items(0).SubItems(2).Text = Format(s1 / 1024, "0") & " KB"

        s1 = 共享方法.GetDirectorySizeWithSub(Application.StartupPath, {"UserData"})
        Form1.ListView10.Items(1).SubItems(2).Text = Format(s1 / 1024 / 1024, "0.0") & " MB"

        s1 = 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(Application.StartupPath, "UserData", "DLC"))
        s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(Application.StartupPath, "UserData", "Plugin"))
        Form1.ListView10.Items(2).SubItems(2).Text = Format(s1 / 1024, "0.0") & " KB"


        If FileIO.FileSystem.FileExists(设置.安装程序更新下载文件路径) Then
            s1 = FileIO.FileSystem.GetFileInfo(设置.安装程序更新下载文件路径).Length
        End If
        If FileIO.FileSystem.FileExists(IO.Path.Combine(设置.安装程序更新下载文件路径, "SMUI 6 Installer.7z.001")) Then
            s1 += FileIO.FileSystem.GetFileInfo(IO.Path.Combine(设置.安装程序更新下载文件路径, "SMUI 6 Installer.7z.001")).Length
        End If
        If FileIO.FileSystem.FileExists(IO.Path.Combine(设置.安装程序更新下载文件路径, "SMUI 6 Installer.7z.002")) Then
            s1 += FileIO.FileSystem.GetFileInfo(IO.Path.Combine(设置.安装程序更新下载文件路径, "SMUI 6 Installer.7z.002")).Length
        End If
        If FileIO.FileSystem.FileExists(IO.Path.Combine(设置.安装程序更新下载文件路径, "SMUI 6 Installer.7z.003")) Then
            s1 += FileIO.FileSystem.GetFileInfo(IO.Path.Combine(设置.安装程序更新下载文件路径, "SMUI 6 Installer.7z.003")).Length
        End If
        Form1.ListView10.Items(3).SubItems(2).Text = Format(s1 / 1024 / 1024, "0") & " MB"

        If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(设置.全局设置数据("LocalRepositoryPath"), ".Download")) Then
            s1 = 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(设置.全局设置数据("LocalRepositoryPath"), ".Download"))
            Form1.ListView10.Items(4).SubItems(2).Text = Format(s1 / 1024 / 1024, "0") & " MB"
        Else
            Form1.ListView10.Items(4).SubItems(2).Text = "无数据"
        End If

        If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(设置.全局设置数据("LocalRepositoryPath"), ".Decompress")) Then
            s1 = 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(设置.全局设置数据("LocalRepositoryPath"), ".Decompress"))
            Form1.ListView10.Items(5).SubItems(2).Text = Format(s1 / 1024 / 1024, "0") & " MB"
        Else
            Form1.ListView10.Items(5).SubItems(2).Text = "无数据"
        End If

        s1 = 0
        Dim edge1 As String = IO.Path.Combine(Application.StartupPath, "UserData", "WebView2Cache", "EBWebView", "Default")
        Dim edge2 As String = IO.Path.Combine(Application.StartupPath, "UserData", "WebView2Cache", "EBWebView")
        If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "Cache")) Then
            s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(edge1, "Cache"))
        End If
        If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "Code Cache")) Then
            s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(edge1, "Code Cache"))
        End If
        If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "DawnCache")) Then
            s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(edge1, "DawnCache"))
        End If
        If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "GPUCache")) Then
            s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(edge1, "GPUCache"))
        End If
        If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "IndexedDB")) Then
            s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(edge1, "IndexedDB"))
        End If

        Form1.ListView10.Items(6).SubItems(2).Text = Format(s1 / 1024 / 1024, "0.0") & " MB"

        s1 = 0
        If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "Network")) Then
            s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(edge1, "Network"))
        End If
        Form1.ListView10.Items(7).SubItems(2).Text = Format(s1 / 1024 / 1024, "0.0") & " MB"

        s1 = 0
        If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "Service Worker")) Then
            s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(edge1, "Service Worker"))
        End If
        Form1.ListView10.Items(8).SubItems(2).Text = Format(s1 / 1024 / 1024, "0.0") & " MB"

        s1 = 0
        If FileIO.FileSystem.DirectoryExists(edge1) Then
            s1 += 共享方法.GetDirectorySizeWithSub(edge1, {"Cache", "Code Cache", "DawnCache", "GPUCache", "IndexedDB", "Network", "Service Worker"})
        End If
        If FileIO.FileSystem.DirectoryExists(edge2) Then
            s1 += 共享方法.GetDirectorySizeWithSub(edge2, {"Default"})
        End If
        Form1.ListView10.Items(9).SubItems(2).Text = Format(s1 / 1024 / 1024, "0.0") & " MB"


        's1 = 0
        'Dim t1 As String = IO.Path.Combine(Application.StartupPath, "UserData", "WebCache")
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "Cache")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "Cache"))
        'End If
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "Code Cache")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "Code Cache"))
        'End If
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "databases")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "databases"))
        'End If
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "DawnCache")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "DawnCache"))
        'End If
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "GPUCache")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "GPUCache"))
        'End If
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "GraphiteDawnCache")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "GraphiteDawnCache"))
        'End If
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "GrShaderCache")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "GrShaderCache"))
        'End If
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "IndexedDB")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "IndexedDB"))
        'End If
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "WebStorage")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "WebStorage"))
        'End If
        'Form1.ListView10.Items(10).SubItems(2).Text = Format(s1 / 1024 / 1024, "0.0") & " MB"

        's1 = 0
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "Network")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "Network"))
        'End If
        'Form1.ListView10.Items(11).SubItems(2).Text = Format(s1 / 1024 / 1024, "0.0") & " MB"

        's1 = 0
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "Service Worker")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "Service Worker"))
        'End If
        'Form1.ListView10.Items(12).SubItems(2).Text = Format(s1 / 1024 / 1024, "0.0") & " MB"

        's1 = 0
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "blob_storage")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "blob_storage"))
        'End If
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "component_crx_cache")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "component_crx_cache"))
        'End If
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "Dictionaries")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "Dictionaries"))
        'End If
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "shared_proto_db")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "shared_proto_db"))
        'End If
        'If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "VideoDecodeStats")) Then
        '    s1 += 共享方法.GetDirectorySizeWithSub(IO.Path.Combine(t1, "VideoDecodeStats"))
        'End If
        'If FileIO.FileSystem.FileExists(IO.Path.Combine(t1, "Visited Links")) Then
        '    s1 += FileIO.FileSystem.GetFileInfo(IO.Path.Combine(t1, "Visited Links")).Length
        'End If
        'Form1.ListView10.Items(13).SubItems(2).Text = Format(s1 / 1024 / 1024, "0.0") & " MB"

    End Sub


    Public Shared Sub 清理选中项()
        On Error Resume Next
        Dim edge1 As String = IO.Path.Combine(Application.StartupPath, "UserData", "WebView2Cache", "EBWebView", "Default")
        Dim edge2 As String = IO.Path.Combine(Application.StartupPath, "UserData", "WebView2Cache", "EBWebView")
        'Dim t1 As String = IO.Path.Combine(Application.StartupPath, "UserData", "WebCache")
        For i = 0 To Form1.ListView10.Items.Count - 1
            If Not Form1.ListView10.Items(i).Selected Then Continue For
            Select Case i
                Case 3
                    If FileIO.FileSystem.FileExists(设置.安装程序更新下载文件路径) Then
                        FileIO.FileSystem.DeleteFile(设置.安装程序更新下载文件路径)
                    End If
                    If FileIO.FileSystem.FileExists(IO.Path.Combine(设置.安装程序更新下载文件路径, "SMUI 6 Installer.7z.001")) Then
                        FileIO.FileSystem.DeleteFile(IO.Path.Combine(设置.安装程序更新下载文件路径, "SMUI 6 Installer.7z.001"))
                    End If
                    If FileIO.FileSystem.FileExists(IO.Path.Combine(设置.安装程序更新下载文件路径, "SMUI 6 Installer.7z.002")) Then
                        FileIO.FileSystem.DeleteFile(IO.Path.Combine(设置.安装程序更新下载文件路径, "SMUI 6 Installer.7z.002"))
                    End If
                    If FileIO.FileSystem.FileExists(IO.Path.Combine(设置.安装程序更新下载文件路径, "SMUI 6 Installer.7z.003")) Then
                        FileIO.FileSystem.DeleteFile(IO.Path.Combine(设置.安装程序更新下载文件路径, "SMUI 6 Installer.7z.003"))
                    End If
                    Form1.ListView10.Items(3).SubItems(2).Text = "已清理"
                Case 4
                    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(设置.全局设置数据("LocalRepositoryPath"), ".Download")) Then
                        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(设置.全局设置数据("LocalRepositoryPath"), ".Download"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                    Form1.ListView10.Items(4).SubItems(2).Text = "已清理"
                Case 5
                    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(设置.全局设置数据("LocalRepositoryPath"), ".Decompress")) Then
                        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(设置.全局设置数据("LocalRepositoryPath"), ".Decompress"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                        Form1.ListView10.Items(5).SubItems(2).Text = "已清理"
                    End If
                Case 6

                    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "Cache")) Then
                        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(edge1, "Cache"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "Code Cache")) Then
                        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(edge1, "Code Cache"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "DawnCache")) Then
                        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(edge1, "DawnCache"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "GPUCache")) Then
                        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(edge1, "GPUCache"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "IndexedDB")) Then
                        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(edge1, "IndexedDB"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                    Form1.ListView10.Items(6).SubItems(2).Text = "已清理"
                Case 7
                    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "Network")) Then
                        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(edge1, "Network"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                    Form1.ListView10.Items(7).SubItems(2).Text = "已清理"
                Case 8
                    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(edge1, "Service Worker")) Then
                        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(edge1, "Service Worker"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                    Form1.ListView10.Items(8).SubItems(2).Text = "已清理"
                Case 9
                    Dim whitelist As New List(Of String)({"Default", "Cache", "Code Cache", "DawnCache", "GPUCache", "IndexedDB", "Network", "Service Worker"})
                    For Each filePath In Directory.GetFiles(edge1)
                        If Not whitelist.Contains(Path.GetFileName(filePath)) Then File.Delete(filePath)
                    Next
                    For Each dirPath In Directory.GetDirectories(edge1)
                        If Not whitelist.Contains(New DirectoryInfo(dirPath).Name) Then Directory.Delete(dirPath, True)
                    Next
                    For Each filePath In Directory.GetFiles(edge2)
                        If Not whitelist.Contains(Path.GetFileName(filePath)) Then File.Delete(filePath)
                    Next
                    For Each dirPath In Directory.GetDirectories(edge2)
                        If Not whitelist.Contains(New DirectoryInfo(dirPath).Name) Then Directory.Delete(dirPath, True)
                    Next
                    Form1.ListView10.Items(9).SubItems(2).Text = "已清理"

                    'Case 10
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "Cache")) Then
                    '        Directory.Delete(IO.Path.Combine(t1, "Cache"), True)
                    '    End If
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "Code Cache")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "Code Cache"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "databases")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "databases"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "DawnCache")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "DawnCache"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "GPUCache")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "GPUCache"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "GraphiteDawnCache")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "GraphiteDawnCache"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "GrShaderCache")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "GrShaderCache"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "IndexedDB")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "IndexedDB"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "WebStorage")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "WebStorage"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    Form1.ListView10.Items(10).SubItems(2).Text = "已清理"

                    'Case 11
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "Network")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "Network"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    Form1.ListView10.Items(11).SubItems(2).Text = "已清理"

                    'Case 12
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "Service Worker")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "Service Worker"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    Form1.ListView10.Items(12).SubItems(2).Text = "已清理"

                    'Case 13
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "Service Worker")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "Service Worker"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "blob_storage")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "blob_storage"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "component_crx_cache")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "component_crx_cache"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "Dictionaries")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "Dictionaries"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "shared_proto_db")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "shared_proto_db"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    If FileIO.FileSystem.DirectoryExists(IO.Path.Combine(t1, "VideoDecodeStats")) Then
                    '        FileIO.FileSystem.DeleteDirectory(IO.Path.Combine(t1, "VideoDecodeStats"), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    '    End If
                    '    If FileIO.FileSystem.FileExists(IO.Path.Combine(t1, "Visited Links")) Then
                    '        File.Delete(IO.Path.Combine(t1, "Visited Links"))
                    '    End If
                    '    Form1.ListView10.Items(13).SubItems(2).Text = "已清理"
            End Select

        Next
    End Sub


    'Public Shared Sub 删除谷歌浏览器全部缓存()
    '    Dim a As New 多项单选对话框("高危操作！", {"确认删除（包括在所有网页上的登录和配置）", "取消"}, "是否确认删除 Chromium 全部缓存？", 100, 600)
    '    If a.ShowDialog(Form1) = 0 Then
    '        On Error Resume Next
    '        Dim t1 As String = IO.Path.Combine(Application.StartupPath, "UserData", "WebCache")
    '        FileIO.FileSystem.DeleteDirectory(t1, FileIO.DeleteDirectoryOption.DeleteAllContents)
    '        Dim b As New 多项单选对话框("删除完成", {"OK"}, "已全部删除")
    '        b.ShowDialog(Form1)
    '    End If
    'End Sub

    Public Shared Sub 计算模组数据库总数据大小()
        Dim s1 As Integer
        If FileIO.FileSystem.DirectoryExists(设置.全局设置数据("LocalRepositoryPath")) Then
            s1 = 共享方法.GetDirectorySizeWithSub(设置.全局设置数据("LocalRepositoryPath"), {".Download", ".Decompress"})
            Form1.UiButton67.Text = "模组数据库总数据大小：" & Format(s1 / 1024 / 1024, "0.0") & " MB"
        Else
            Form1.UiButton67.Text = "无数据"
        End If
    End Sub


End Class
