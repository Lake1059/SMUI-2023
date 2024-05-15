
Imports System.IO
Imports System.Net.Http

Public Class SMAPI安装管理器

    Public Shared Sub 初始化()
        Form1.Panel25.Width = 0
        AddHandler Form1.UiButton22.Click, AddressOf 获取发行版文件列表
        AddHandler Form1.UiButton77.Click, AddressOf 下载选择的文件
        AddHandler Form1.UiButton75.Click, AddressOf 取消下载

        AddHandler Form1.UiButton74.Click, AddressOf 刷新已下载的文件
        AddHandler Form1.UiButton76.Click, AddressOf 运行安装
        AddHandler Form1.UiButton73.Click, AddressOf 运行卸载

        AddHandler Form1.UiButton79.Click, AddressOf 清理解压
        AddHandler Form1.UiButton78.Click, AddressOf 清理下载

        AddHandler Timer1.Tick, AddressOf 下载进度计时器

    End Sub

    Public Shared Property Timer1 As New Timer With {.Interval = 1000, .Enabled = False}

    Public Shared Property 正在进行获取文件列表 As Boolean = False
    Public Shared Async Sub 获取发行版文件列表()
        If 正在进行获取文件列表 Then Exit Sub
        正在进行获取文件列表 = True
        Dim a As New GitAPI.GitHubAllReleaseFile
        Form1.Label55.Text = "正在获取文件列表"
        Dim s1 As String = Await Task.Run(Function() a.获取("Pathoschild/SMAPI"))
        If s1 <> "" Then
            Form1.Label55.Text = "获取失败"
            DebugPrint(s1, Color1.红色)
            正在进行获取文件列表 = False
        End If
        获取到的文件列表.Clear()
        Form1.UiComboBox7.Items.Clear()
        获取到的文件列表 = a.可供下载的文件
        For i = 0 To 获取到的文件列表.Count - 1
            Form1.UiComboBox7.Items.Add(获取到的文件列表(i).Key)
        Next
        Form1.Label55.Text = "获取成功"
        正在进行获取文件列表 = False
        If Form1.UiComboBox7.Items.Count > 1 Then
            If a.可供下载的文件(0).Key.Contains("dev") Then
                Form1.UiComboBox7.SelectedIndex = 1
            Else
                Form1.UiComboBox7.SelectedIndex = 0
            End If
        ElseIf Form1.UiComboBox7.Items.Count > 0 Then
            Form1.UiComboBox7.SelectedIndex = 0
        End If
    End Sub

    Public Shared Property 获取到的文件列表 As New List(Of KeyValuePair(Of String, String))

    Public Shared Property 正在进行下载文件 As Boolean = False
    Public Shared Property 已下载字节数 As Long = 0
    Public Shared Property 总字节数 As Long = 0
    Public Shared Property 是否终止下载 As Boolean = False
    Public Shared Property 上一秒的已下载字节数 As Long = 0
    Public Shared Async Sub 下载选择的文件()
        If 正在进行下载文件 Then Exit Sub
        正在进行下载文件 = True
        Form1.Label55.Text = "开始下载"
        Timer1.Enabled = True
        Dim s1 As String = Await DownloadFileAsync(获取到的文件列表(Form1.UiComboBox7.SelectedIndex).Value, Path.Combine(设置.SMAPI下载路径, 获取到的文件列表(Form1.UiComboBox7.SelectedIndex).Key))
        Timer1.Enabled = False
        If s1 = "" Then
            Form1.Label55.Text = "下载结束"
            Form1.Panel25.Width = Form1.Panel25.Parent.Width
        Else
            Form1.Label55.Text = "下载失败，查看调试选项卡获取详情"
        End If
        正在进行下载文件 = False
    End Sub

    Public Shared Async Function DownloadFileAsync(URL As String, FileName As String) As Task(Of String)
        Try
            Using httpClient As New HttpClient()
                httpClient.Timeout = TimeSpan.FromSeconds(10)
                Using response As HttpResponseMessage = Await httpClient.GetAsync(URL, HttpCompletionOption.ResponseHeadersRead)
                    If Not response.IsSuccessStatusCode Then
                        Return $"Error: {response.StatusCode} - {response.ReasonPhrase}"
                    End If
                    If Path.GetExtension(FileName) = ".rar" Then
                        Err.Raise(105903,, "检测到目标文件后缀为 .rar 不支持该压缩格式，请手动配置。通知作者不要使用该格式，应该使用 zip 或者 7z，由于授权的问题永远不会考虑支持 RAR。")
                    End If
                    Using fileStream As New FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None)
                        Using responseStream As Stream = Await response.Content.ReadAsStreamAsync()
                            Dim buffer As Byte() = If(设置.全局设置数据("DownloadFileUseBigBuffer") = "False", New Byte(1023) {}, New Byte(102399) {})
                            Dim bytesRead As Integer
                            总字节数 = If(response.Content.Headers.ContentLength, 0)
                            Do
                                If 是否终止下载 Then
                                    Return $"User: Stop Download."
                                    Exit Do
                                End If
                                bytesRead = Await responseStream.ReadAsync(buffer)
                                If bytesRead = 0 Then Exit Do
                                Await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead))
                                已下载字节数 += bytesRead
                            Loop While True
                        End Using
                    End Using
                End Using
            End Using
            Return ""
        Catch ex As HttpRequestException
            Return $"HttpRequestException: {ex.Message}"
        Catch ex As TaskCanceledException
            Return $"Timeout: {ex.Message}"
        Catch ex As IOException
            Return $"IOException: {ex.Message}"
        Catch ex As Exception
            Return $"General Exception: {ex.Message}"
        End Try
    End Function

    Public Shared Sub 下载进度计时器()
        If 是否终止下载 = True Then
            Timer1.Enabled = False
            Exit Sub
        End If
        If 总字节数 = 0 Then Exit Sub
        If 已下载字节数 = 总字节数 And 总字节数 > 0 Then
            Timer1.Enabled = False
            Exit Sub
        End If
        If Format(已下载字节数 / 1024, "0") < 1024 Then
            Form1.Label55.Text = Format(已下载字节数 / 1024, "0") & " KB / " & Format(总字节数 / 1024, "0") & " KB"
        Else
            Form1.Label55.Text = Format(已下载字节数 / 1024 / 1024, "0.0") & " MB / " & Format(总字节数 / 1024 / 1024, "0.0") & " MB"
        End If

        Dim 速度字节 As Long = 已下载字节数 - 上一秒的已下载字节数

        If 速度字节 > 0 Then
            If Format(速度字节 / 1024, "0") > 1024 Then
                Form1.Label55.Text &= "   " & Format(速度字节 / 1024 / 1024, "0.0") & " MB/s"
            Else
                Form1.Label55.Text &= "   " & Format(速度字节 / 1024, "0") & " KB/s"
            End If
        End If

        Form1.Label55.Text &= "   " & Format(已下载字节数 / 总字节数 * 100, "0.0") & "%"

        If 速度字节 > 0 Then
            Dim 剩余秒数 As Long = (总字节数 - 已下载字节数) / 速度字节
            Select Case 剩余秒数
                Case 0
                Case <= 60
                    Form1.Label55.Text &= "   ETA " & 剩余秒数 & "s"
                Case <= 3600
                    Form1.Label55.Text &= "   ETA " & 剩余秒数 / 60 & "m " & 剩余秒数 Mod 60 & "s"
                Case <= 86400
                    Form1.Label55.Text &= "   ETA " & 剩余秒数 / 3600 & "h " & 剩余秒数 Mod 3600 & "m"
                Case Else
                    Form1.Label55.Text &= "   ETA " & 剩余秒数 / 86400 & "d " & 剩余秒数 Mod 86400 & "h"
            End Select
        End If

        Form1.Panel25.Width = 已下载字节数 / 总字节数 * Form1.Panel25.Parent.Width

        上一秒的已下载字节数 = 已下载字节数
        If 已下载字节数 = 总字节数 And 总字节数 > 0 Then
            Timer1.Enabled = False
        End If



    End Sub


    Public Shared Sub 取消下载()
        If 正在进行下载文件 = False Then Exit Sub
        是否终止下载 = True
        Form1.Label55.Text = "已标记取消，等待下载程序响应"
    End Sub

    Public Shared Sub 刷新已下载的文件()
        Form1.UiComboBox9.Items.Clear()
        Dim a As New 搜索文件类
        a.搜索文件(设置.SMAPI下载路径, False, "*.zip")
        If a.错误信息 <> "" Then
            Dim m1 As New 多项单选对话框("", {"OK"}, a.错误信息)
            m1.ShowDialog(Form1)
            Exit Sub
        End If
        For i = 0 To a.文件绝对路径集合.Count - 1
            Form1.UiComboBox9.Items.Add(Path.GetFileName(a.文件绝对路径集合(i)))
        Next
        If Form1.UiComboBox9.Items.Count > 1 Then
            If a.文件绝对路径集合(0).Contains("dev") Then
                Form1.UiComboBox9.SelectedIndex = 1
            Else
                Form1.UiComboBox9.SelectedIndex = 0
            End If
        ElseIf Form1.UiComboBox9.Items.Count > 0 Then
            Form1.UiComboBox9.SelectedIndex = 0
        End If
    End Sub

    Public Shared Sub 清理解压()
        If FileIO.FileSystem.DirectoryExists(设置.SMAPI解压路径) Then
            FileIO.FileSystem.DeleteDirectory(设置.SMAPI解压路径, FileIO.DeleteDirectoryOption.DeleteAllContents)
            FileIO.FileSystem.CreateDirectory(设置.SMAPI解压路径)
        Else
            FileIO.FileSystem.CreateDirectory(设置.SMAPI解压路径)
        End If
    End Sub

    Public Shared Sub 清理下载()
        If FileIO.FileSystem.DirectoryExists(设置.SMAPI下载路径) Then
            FileIO.FileSystem.DeleteDirectory(设置.SMAPI下载路径, FileIO.DeleteDirectoryOption.DeleteAllContents)
            FileIO.FileSystem.CreateDirectory(设置.SMAPI下载路径)
        Else
            FileIO.FileSystem.CreateDirectory(设置.SMAPI下载路径)
        End If
    End Sub

    Public Shared Property 正在运行安装卸载 As Boolean = False
    Public Shared Async Sub 运行安装()
        If Not FileIO.FileSystem.FileExists(Path.Combine(设置.SMAPI下载路径, Form1.UiComboBox9.Text)) Then Exit Sub
        If 正在运行安装卸载 Then Exit Sub
        正在运行安装卸载 = True
        Form1.Label55.Text = "正在解压"
        Application.DoEvents()
        清理解压()
        Dim zip1 As New SevenZip.SevenZipExtractor(Path.Combine(设置.SMAPI下载路径, Form1.UiComboBox9.Text))
        For i = 0 To zip1.ArchiveFileData.Count - 1
            zip1.ExtractFiles(设置.SMAPI解压路径 & "\", i)
        Next
        Dim a As New 搜索文件类
        a.搜索文件(设置.SMAPI解压路径, True, "SMAPI.Installer.exe")
        If a.错误信息 <> "" Then
            Dim m1 As New 多项单选对话框("", {"OK"}, a.错误信息)
            m1.ShowDialog(Form1)
            Exit Sub
        End If
        If a.文件绝对路径集合.Count = 0 Then Exit Sub
        Form1.Label55.Text = "正在运行安装"
        Dim p1 As New Process
        p1.StartInfo.FileName = a.文件绝对路径集合(0)
        p1.StartInfo.Arguments = "--no-prompt --install --game-path " & """" & 设置.全局设置数据("StardewValleyGamePath") & """"
        p1.Start()
        Await p1.WaitForExitAsync
        p1.Dispose()
        If FileIO.FileSystem.FileExists(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "StardewModdingAPI.exe")) Then
            Dim fileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "StardewModdingAPI.exe"))
            Dim m1 As New 多项单选对话框("", {"OK"}, "已安装：" & $"SMAPI {fileVersionInfo.FileMajorPart}.{fileVersionInfo.FileMinorPart}.{fileVersionInfo.FileBuildPart}")
            m1.ShowDialog(Form1)
        Else
            Dim m1 As New 多项单选对话框("", {"OK"}, "安装失败，未检测到目标位置的 SMAPI 程序文件")
            m1.ShowDialog(Form1)
        End If
        清理解压()
        Form1.Label55.Text = "操作结束"
        正在运行安装卸载 = False
        状态信息.刷新起始页面状态信息()
    End Sub

    Public Shared Async Sub 运行卸载()
        If Not FileIO.FileSystem.FileExists(Path.Combine(设置.SMAPI下载路径, Form1.UiComboBox9.Text)) Then Exit Sub
        If 正在运行安装卸载 Then Exit Sub
        正在运行安装卸载 = True
        Form1.Label55.Text = "正在解压"
        Application.DoEvents()
        清理解压()
        Dim zip1 As New SevenZip.SevenZipExtractor(Path.Combine(设置.SMAPI下载路径, Form1.UiComboBox9.Text))
        For i = 0 To zip1.ArchiveFileData.Count - 1
            zip1.ExtractFiles(设置.SMAPI解压路径 & "\", i)
        Next
        Dim a As New 搜索文件类
        a.搜索文件(设置.SMAPI解压路径, True, "SMAPI.Installer.exe")
        If a.错误信息 <> "" Then
            Dim m1 As New 多项单选对话框("", {"OK"}, a.错误信息)
            m1.ShowDialog(Form1)
            Exit Sub
        End If
        If a.文件绝对路径集合.Count = 0 Then Exit Sub
        Form1.Label55.Text = "正在运行卸载"
        Dim p1 As New Process
        p1.StartInfo.FileName = a.文件绝对路径集合(0)
        p1.StartInfo.Arguments = "--no-prompt --uninstall --game-path " & """" & 设置.全局设置数据("StardewValleyGamePath") & """"
        p1.Start()
        Await p1.WaitForExitAsync
        p1.Dispose()
        If Not FileIO.FileSystem.FileExists(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "StardewModdingAPI.exe")) Then
            Dim m1 As New 多项单选对话框("", {"OK"}, "卸载完成")
            m1.ShowDialog(Form1)
        Else
            Dim m1 As New 多项单选对话框("", {"OK"}, "卸载失败，目标位置仍然存在 SMAPI 程序文件")
            m1.ShowDialog(Form1)
        End If
        清理解压()
        Form1.Label55.Text = "操作结束"
        正在运行安装卸载 = False
        状态信息.刷新起始页面状态信息()
    End Sub

End Class