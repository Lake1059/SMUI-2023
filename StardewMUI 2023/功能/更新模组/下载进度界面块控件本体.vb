Imports System.IO
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports SharpCompress.Archives
Imports SharpCompress.Archives.Rar
Imports SharpCompress.Archives.SevenZip
Imports SharpCompress.Archives.Zip
Imports SharpCompress.Common

Public Class 下载进度界面块控件本体

    Public Property 设置_下载来源 As String
    Public Property 设置_下载地址 As String
    Public Property 设置_模组项绝对路径 As String
    Public Property 设置_N网模组ID As String
    Public Property 设置_结束后自动释放的控件 As New List(Of Control)
    Public Property 设置_其他来源指定文件名 As String
    Public Property 设置_结束后切换到选项卡 As String


    Public Async Sub 开始下载()
        If 设置_下载来源 = "" Then Exit Sub
        If 设置_下载地址 = "" And 设置_下载来源.Equals("nexus", StringComparison.CurrentCultureIgnoreCase) Then Exit Sub
        If 设置_模组项绝对路径 = "" Then Exit Sub
        If 设置_模组项绝对路径.Contains("\\") Then 设置_模组项绝对路径 = 设置_模组项绝对路径.Replace("\\", "\")
        设置_模组项绝对路径 = New String(设置_模组项绝对路径.Where(Function(c) Not Char.IsControl(c)).ToArray)

        Me.Timer1.Enabled = True
        Dim str1 As String
        已下载字节数 = 0 : 总字节数 = 0 : 是否终止下载 = False : 上一秒的已下载字节数 = 0
        Me.Panel3.Width = 0 : Me.Panel3.BackColor = Color.DarkGreen
        Me.Label1.Text = If(FileIO.FileSystem.FileExists(Path.Combine(设置_模组项绝对路径, "Code2")), "更新：", "创建：") & Path.GetFileName(设置_模组项绝对路径)
        Me.Label2.Text = "正在开始 ..."
        If 设置_下载来源.Equals("nexus", StringComparison.CurrentCultureIgnoreCase) Then
            str1 = Await DownloadFileFromNexusAsync(设置_下载地址, 设置.检查并返回数据库下载文件夹路径)
        Else
            str1 = Await DownloadFileAsync(设置_下载地址, Path.Combine(设置.检查并返回数据库下载文件夹路径, 设置_其他来源指定文件名))
        End If
        If str1 <> "" Then
            是否下载成功 = False
            Me.Label1.Text = "下载失败 - " & If(FileIO.FileSystem.FileExists(Path.Combine(设置_模组项绝对路径, "Code2")), "更新：", "创建：") & Path.GetFileName(设置_模组项绝对路径)
            Me.Label2.Text = str1
            Me.Panel3.BackColor = Color.DarkRed
            DebugPrint(str1, Color1.红色)
        Else
            是否下载成功 = True
            Me.Label2.Text = "下载成功，等待开始解压"
            开始解压()
        End If
    End Sub

    Public Property 保存位置 As String = ""
    Public Property 已下载字节数 As Long = 0
    Public Property 总字节数 As Long = 0
    Public Property 是否终止下载 As Boolean = False
    Public Property 是否下载成功 As Boolean = False
    Public Property 上一秒的已下载字节数 As Long = 0

    Public Async Function DownloadFileFromNexusAsync(URL As String, FileDir As String) As Task(Of String)
        Try
            Using httpClient As New HttpClient()
                httpClient.Timeout = TimeSpan.FromSeconds(10)
                Using response As HttpResponseMessage = Await httpClient.GetAsync(URL, HttpCompletionOption.ResponseHeadersRead)
                    If Not response.IsSuccessStatusCode Then
                        Return $"Error: {response.StatusCode} - {response.ReasonPhrase}"
                    End If
                    Dim regex As New Regex("([^\/?]+)(?=\?|$)")
                    Dim match As Match = regex.Match(URL)
                    If match.Success Then
                        保存位置 = Path.Combine(设置.检查并返回数据库下载文件夹路径, match.Value)
                    Else
                        Return "无法获取到文件名"
                        Exit Function
                    End If
                    Using fileStream As New FileStream(保存位置, FileMode.Create, FileAccess.Write, FileShare.None)
                        Using responseStream As Stream = Await response.Content.ReadAsStreamAsync()
                            Dim buffer As Byte() = If(设置.全局设置数据("DownloadFileUseBigBuffer") = "False", New Byte(1023) {}, New Byte(102399) {})
                            Dim bytesRead As Integer
                            总字节数 = If(response.Content.Headers.ContentLength, 0)
                            Do
                                If 是否终止下载 Then
                                    Return $"用户终止下载"
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

    Public Async Function DownloadFileAsync(URL As String, FileName As String) As Task(Of String)
        Try
            Using httpClient As New HttpClient()
                httpClient.Timeout = TimeSpan.FromSeconds(10)
                Using response As HttpResponseMessage = Await httpClient.GetAsync(URL, HttpCompletionOption.ResponseHeadersRead)
                    If Not response.IsSuccessStatusCode Then
                        Return $"Error: {response.StatusCode} - {response.ReasonPhrase}"
                    End If
                    保存位置 = FileName
                    Using fileStream As New FileStream(保存位置, FileMode.Create, FileAccess.Write, FileShare.None)
                        Using responseStream As Stream = Await response.Content.ReadAsStreamAsync()
                            Dim buffer As Byte() = If(设置.全局设置数据("DownloadFileUseBigBuffer") = "False", New Byte(1023) {}, New Byte(102399) {})
                            Dim bytesRead As Integer
                            总字节数 = If(response.Content.Headers.ContentLength, 0)
                            Do
                                If 是否终止下载 Then
                                    Return $"用户终止下载"
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If 是否终止下载 = True Then
            Me.Timer1.Enabled = False
            Exit Sub
        End If
        If 总字节数 = 0 Then Exit Sub
        If 已下载字节数 = 总字节数 And 总字节数 > 0 Then
            Me.Timer1.Enabled = False
            Exit Sub
        End If
        If Format(已下载字节数 / 1024, "0") < 1024 Then
            Me.Label2.Text = Format(已下载字节数 / 1024, "0") & " KB / " & Format(总字节数 / 1024, "0") & " KB"
        Else
            Me.Label2.Text = Format(已下载字节数 / 1024 / 1024, "0.0") & " MB / " & Format(总字节数 / 1024 / 1024, "0.0") & " MB"
        End If

        Dim 速度字节 As Long = 已下载字节数 - 上一秒的已下载字节数

        If 速度字节 > 0 Then
            If Format(速度字节 / 1024, "0") > 1024 Then
                Me.Label2.Text &= "   " & Format(速度字节 / 1024 / 1024, "0.0") & " MB/s"
            Else
                Me.Label2.Text &= "   " & Format(速度字节 / 1024, "0") & " KB/s"
            End If
        End If

        Me.Label2.Text &= "   " & Format(已下载字节数 / 总字节数 * 100, "0.0") & "%"

        If 速度字节 > 0 Then
            Dim 剩余秒数 As Long = (总字节数 - 已下载字节数) / 速度字节
            Select Case 剩余秒数
                Case 0
                Case <= 60
                    Me.Label2.Text &= "   ETA " & 剩余秒数 & "s"
                Case <= 3600
                    Me.Label2.Text &= "   ETA " & 剩余秒数 / 60 & "m " & 剩余秒数 Mod 60 & "s"
                Case <= 86400
                    Me.Label2.Text &= "   ETA " & 剩余秒数 / 3600 & "h " & 剩余秒数 Mod 3600 & "m"
                Case Else
                    Me.Label2.Text &= "   ETA " & 剩余秒数 / 86400 & "d " & 剩余秒数 Mod 86400 & "h"
            End Select
        End If

        Me.Panel3.Width = 已下载字节数 / 总字节数 * Me.Panel3.Parent.Width

        上一秒的已下载字节数 = 已下载字节数
        If 已下载字节数 = 总字节数 And 总字节数 > 0 Then
            Me.Timer1.Enabled = False
        End If
    End Sub

    Public Property 这份实例使用的临时解压目录 As String = Path.Combine(设置.检查并返回数据库解压文件夹路径, Now.Hour & Now.Minute & Now.Second & Now.Millisecond)

    Public Property 是否取消解压 As Boolean = False

    Public Async Sub 开始解压()
        If 是否取消解压 Then Exit Sub
        Try
            If Not FileIO.FileSystem.DirectoryExists(这份实例使用的临时解压目录) Then FileIO.FileSystem.CreateDirectory(这份实例使用的临时解压目录)
            Me.Panel3.BackColor = Color1.蓝色

            Select Case Path.GetExtension(保存位置).ToLower
                Case ".zip"
                    Using archive = ZipArchive.Open(保存位置)
                        Dim files = archive.Entries.Where(Function(entry) Not entry.IsDirectory).ToList()
                        Dim index1 = 0
                        For Each entry In archive.Entries
                            If 是否取消解压 Then Exit Sub
                            If entry.IsDirectory Then Continue For
                            index1 += 1
                            Me.Label2.Text = $"正在解压第 {index1} 个文件，总计 {files.Count} 个文件"
                            Me.Panel3.Width = index1 / files.Count * Me.Panel3.Parent.Width
                            Application.DoEvents()
                            Await Task.Run(Sub() entry.WriteToDirectory(这份实例使用的临时解压目录, New ExtractionOptions() With {.ExtractFullPath = True, .Overwrite = True}))
                        Next
                    End Using
                Case ".7z"
                    Using archive = SevenZipArchive.Open(保存位置)
                        Dim files = archive.Entries.Where(Function(entry) Not entry.IsDirectory).ToList()
                        Dim index1 = 0
                        For Each entry In archive.Entries
                            If 是否取消解压 Then Exit Sub
                            If entry.IsDirectory Then Continue For
                            index1 += 1
                            Me.Label2.Text = $"正在解压第 {index1} 个文件，总计 {files.Count} 个文件"
                            Me.Panel3.Width = index1 / files.Count * Me.Panel3.Parent.Width
                            Application.DoEvents()
                            Await Task.Run(Sub() entry.WriteToDirectory(这份实例使用的临时解压目录, New ExtractionOptions() With {.ExtractFullPath = True, .Overwrite = True}))
                        Next
                    End Using
                Case ".rar"
                    Using archive = RarArchive.Open(保存位置)
                        Dim files = archive.Entries.Where(Function(entry) Not entry.IsDirectory).ToList()
                        Dim index1 = 0
                        For Each entry In archive.Entries
                            If 是否取消解压 Then Exit Sub
                            If entry.IsDirectory Then Continue For
                            index1 += 1
                            Me.Label2.Text = $"正在解压第 {index1} 个文件，总计 {files.Count} 个文件"
                            Me.Panel3.Width = index1 / files.Count * Me.Panel3.Parent.Width
                            Application.DoEvents()
                            Await Task.Run(Sub() entry.WriteToDirectory(这份实例使用的临时解压目录, New ExtractionOptions() With {.ExtractFullPath = True, .Overwrite = True}))
                        Next
                    End Using

            End Select

            开始处理套娃()
        Catch ex As Exception
            Me.Label1.Text = "解压失败"
            Me.Label2.Text = ex.Message
            Me.Panel3.BackColor = Color.DarkRed
            DebugPrint(ex.Message, Color1.红色)
        End Try
    End Sub

    Public Sub 开始处理套娃()
        Me.Label2.Text = "正在检测套娃"
        Dim 解压出的文件夹列表 As New List(Of String)(共享方法.SearchFolderWithoutSub(这份实例使用的临时解压目录))
        If 解压出的文件夹列表.Count = 0 Then
            评估不通过操作("压缩文件内容不包含文件夹，无法继续")
            Exit Sub
        End If

        Dim Code2文件路径 As String = Path.Combine(设置_模组项绝对路径, "Code2")

        If 解压出的文件夹列表.Count = 1 Then
            Dim 第一个文件夹路径 As String = Path.Combine(这份实例使用的临时解压目录, 解压出的文件夹列表(0))
            Dim manifest文件路径 As String = Path.Combine(第一个文件夹路径, "manifest.json")
            If Not FileIO.FileSystem.FileExists(manifest文件路径) And FileIO.FileSystem.FileExists(Code2文件路径) Then
                实际解压路径算起位置 = 第一个文件夹路径
            Else
                实际解压路径算起位置 = 这份实例使用的临时解压目录
            End If
        Else
            实际解压路径算起位置 = 这份实例使用的临时解压目录
        End If

        If FileIO.FileSystem.FileExists(Code2文件路径) Then
            开始处理更新()
        Else
            开始处理新建()
        End If
    End Sub

    Dim 实际解压路径算起位置 As String

    Public Async Sub 开始处理更新()
        Me.Label2.Text = "正在评估下载的内容"
        Application.DoEvents()
        Dim 实际新的文件夹列表 As New List(Of String)(共享方法.SearchFolderWithoutSub(实际解压路径算起位置))

        Dim 安装规划数据 As New List(Of KeyValuePair(Of String, String))
        键值对IO操作.读取键值对文件到列表(安装规划数据, Path.Combine(设置_模组项绝对路径, "Code2"))
        Dim 文件夹计数 As Integer = 0
        For i = 0 To 安装规划数据.Count - 1
            Select Case 安装规划数据(i).Key
                Case "CD-D-MODS"
                    文件夹计数 += 1
                    If Not FileIO.FileSystem.DirectoryExists(Path.Combine(实际解压路径算起位置, 安装规划数据(i).Value)) Then
                        评估不通过操作("下载的内容缺少对应文件夹")
                        DebugPrint("下载的内容缺少对应文件夹", Color1.黄色)
                        Exit Sub
                    End If
                    If Not FileIO.FileSystem.FileExists(Path.Combine(实际解压路径算起位置, 安装规划数据(i).Value, "manifest.json")) Then
                        评估不通过操作("原本的标准 SMAPI 模组文件夹已经不包含清单文件")
                        DebugPrint("原本的标准 SMAPI 模组文件夹已经不包含清单文件", Color1.黄色)
                        Exit Sub
                    End If
                Case "CD-D-MODS-COVER"
                    文件夹计数 += 1
                    If Not FileIO.FileSystem.DirectoryExists(Path.Combine(实际解压路径算起位置, 安装规划数据(i).Value)) Then
                        评估不通过操作("下载的内容缺少对应文件夹")
                        DebugPrint("下载的内容缺少对应文件夹", Color1.黄色)
                        Exit Sub
                    End If
                    If FileIO.FileSystem.FileExists(Path.Combine(实际解压路径算起位置, 安装规划数据(i).Value, "manifest.json")) Then
                        评估不通过操作("原本进行覆盖标准 SMAPI 模组文件夹的文件夹现在却包含了清单文件")
                        DebugPrint("原本进行覆盖标准 SMAPI 模组文件夹的文件夹现在却包含了清单文件", Color1.黄色)
                        Exit Sub
                    End If
                Case "CD-D-ROOT", "CD-D-CONTENT", "CD-F-ADD", "CD-F-ADD-SHA", "CD-F-REP", "CD-F-NULL"
                    评估不通过操作("不支持对应的规划类型，请手动配置")
                    DebugPrint("不支持对应的规划类型，请手动配置", Color1.黄色)
                    Exit Sub
            End Select
        Next

        If 文件夹计数 <> 实际新的文件夹列表.Count Then
            评估不通过操作("文件夹数量和复制到 Mods 类型的规划数量不匹配")
            DebugPrint("文件夹数量和复制到 Mods 类型的规划数量不匹配", Color1.黄色)
            Exit Sub
        End If

        Me.Label2.Text = "评估成功，正在处理数据"
        For i2 = 0 To 安装规划数据.Count - 1
            Me.Panel3.Width = (i2 + 1) / 安装规划数据.Count * Me.Panel3.Parent.Width
            Select Case 安装规划数据(i2).Key
                Case "CD-D-MODS", "CD-D-MODS-COVER"
                    Dim v1 As String = 安装规划数据(i2).Value
                    If FileIO.FileSystem.DirectoryExists(Path.Combine(设置_模组项绝对路径, v1)) Then
                        Await Task.Run(Sub()
                                           Try
                                               FileIO.FileSystem.DeleteDirectory(Path.Combine(设置_模组项绝对路径, v1), FileIO.DeleteDirectoryOption.DeleteAllContents)
                                           Catch ex As Exception
                                               Me.Invoke(Sub() Me.Panel3.BackColor = Color.DarkRed)
                                               If FileIO.FileSystem.DirectoryExists(Path.Combine(设置_模组项绝对路径, v1)) Then
                                                   Me.Invoke(Sub() DebugPrint("删除失败。" & ex.Message, Color1.红色))
                                               Else
                                                   Me.Invoke(Sub() DebugPrint("意外错误，但是已经成功删除。" & ex.Message, Color1.橙色))
                                               End If
                                           End Try
                                       End Sub)
                    End If

                    Await Task.Run(Sub()
                                       Try
                                           FileIO.FileSystem.CopyDirectory(Path.Combine(实际解压路径算起位置, v1), Path.Combine(设置_模组项绝对路径, v1))
                                       Catch ex As Exception
                                           Me.Invoke(Sub() Me.Panel3.BackColor = Color.DarkRed)
                                           Me.Invoke(Sub() DebugPrint("覆盖出错。" & ex.Message, Color1.红色))
                                       End Try
                                   End Sub)
            End Select
        Next

        清理解压数据()

        结束()

    End Sub

    Public Async Sub 开始处理新建()
        Me.Label2.Text = "正在转移内容"
        Application.DoEvents()

        Dim 自动编写的安装规划 As String = ""

        Dim 准备处理的文件夹列表 As New List(Of String)(共享方法.SearchFolderWithoutSub(实际解压路径算起位置))
        Await Task.Run(Sub()
                           For Each folder As String In 准备处理的文件夹列表
                               Dim sourcePath = Path.Combine(实际解压路径算起位置, folder)
                               Dim destPath = Path.Combine(设置_模组项绝对路径, folder)
                               FileIO.FileSystem.MoveDirectory(sourcePath, destPath, True)
                           Next
                       End Sub)
        Await Task.Run(Sub()
                           For Each F1 As FileInfo In New DirectoryInfo(实际解压路径算起位置).GetFiles("*.*")
                               Dim sourcePath = Path.Combine(实际解压路径算起位置, F1.Name)
                               Dim destPath = Path.Combine(设置_模组项绝对路径, F1.Name)
                               FileIO.FileSystem.MoveFile(sourcePath, destPath, True)
                           Next
                       End Sub)

        Me.Label2.Text = "正在评估下载的内容"
        Application.DoEvents()

        If 准备处理的文件夹列表.Count = 0 Then
            评估不通过操作("解压出的内容不包含文件夹或文件夹是空的", False)
            DebugPrint("解压出的内容不包含文件夹或文件夹是空的", Color1.黄色)
            Exit Sub
        End If
        If FileIO.FileSystem.FileExists(Path.Combine(设置_模组项绝对路径, "manifest.json")) Then
            评估不通过操作("检测到 manifest.json 直接存在于解压出的根位置", False)
            DebugPrint("检测到 manifest.json 直接存在于解压出的根位置", Color1.黄色)
            Exit Sub
        End If
        For Each folder As String In 准备处理的文件夹列表
            If folder.Contains("."c) Then Continue For
            If Not FileIO.FileSystem.FileExists(Path.Combine(设置_模组项绝对路径, folder, "manifest.json")) Then
                评估不通过操作("存在多重套娃或者非标准 SMAPI 模组", False)
                DebugPrint("存在多重套娃或者非标准 SMAPI 模组", Color1.黄色)
                Exit Sub
            Else
                自动编写的安装规划 &= If(String.IsNullOrEmpty(自动编写的安装规划), "", vbCrLf) & "CD-D-MODS=" & folder
            End If
        Next
        For Each F1 As FileInfo In New System.IO.DirectoryInfo(设置_模组项绝对路径).GetFiles("*.*")
            Select Case F1.Name.Trim
                Case "README", "Version", "Code", "Code2", "README.rtf", "Font", "NexusFileName"
                Case ".DS_Store"
                Case Else
                    Select Case F1.Extension
                        Case ".txt", ".md", ".log"
                        Case Else
                            评估不通过操作("存在单独的文件，需要用户处理", False)
                            DebugPrint("存在单独的文件，需要用户处理", Color1.黄色)
                            Exit Sub
                    End Select
            End Select
        Next
        Me.Label2.Text = "评估成功，正在写入规划文件"
        Application.DoEvents()
        FileIO.FileSystem.WriteAllText(Path.Combine(设置_模组项绝对路径, "Code2"), 自动编写的安装规划, False, System.Text.Encoding.UTF8)

        清理解压数据()

        结束()

    End Sub

    Public Sub 评估不通过操作(不能自动完成的原因 As String, Optional 是否要打开解压文件夹 As Boolean = True)
        Dim msg1 As New 多项单选对话框("", {"确定"}, "存在验证不通过的内容，为了避免意外情况不能自动完成，请在配置队列中手动操作，程序将自动打开解压目录并添加到配置队列。以下是不能自动完成的因素：" & vbCrLf & vbCrLf & 不能自动完成的原因, 150, 500)
        msg1.ShowDialog(Form1)
        配置队列.添加到配置队列(Path.GetFileName(Path.GetDirectoryName(设置_模组项绝对路径)), Path.GetFileName(设置_模组项绝对路径))
        If 是否要打开解压文件夹 Then Process.Start("explorer.exe", 这份实例使用的临时解压目录)
        结束(False)
    End Sub

    Public Async Sub 清理解压数据()
        If FileIO.FileSystem.DirectoryExists(这份实例使用的临时解压目录) Then
            Me.Label2.Text = "正在清理"
            Application.DoEvents()
            Await Task.Run(Sub() FileIO.FileSystem.DeleteDirectory(这份实例使用的临时解压目录, FileIO.DeleteDirectoryOption.DeleteAllContents))
        End If
    End Sub

    Public Sub 结束(Optional 是否要转选项卡 As Boolean = True)
        For i = 0 To 设置_结束后自动释放的控件.Count - 1
            If 设置_结束后自动释放的控件(i) IsNot Nothing Then 设置_结束后自动释放的控件(i).Dispose()
        Next
        If Form1.Panel37.Controls.Count >= 2 Then
            If TypeOf Form1.Panel37.Controls.Item(1) Is Label Then
                Form1.Panel37.Controls.Item(1).Dispose()
            End If
        End If

        If 是否要转选项卡 Then
            Select Case 设置_结束后切换到选项卡
                Case ""
                    If Form1.Panel37.Controls.Count <= 1 Then
                        Form1.UiTabControl1.SelectedTab = Form1.TabPage管理模组
                        Form1.ListView2.Focus()
                    End If
                Case "checkupdate"
                    If Form1.Panel37.Controls.Count <= 1 Then
                        Form1.UiTabControl1.SelectedTab = Form1.TabPage检查更新
                        Form1.ListView12.Focus()
                    End If
            End Select
        End If
        Me.Dispose()
    End Sub

    Private Sub 取消下载ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 取消下载ToolStripMenuItem.Click
        If 是否下载成功 Then Exit Sub
        If 设置_下载地址 = "" Then Exit Sub
        是否终止下载 = True
        是否下载成功 = False
        Me.Label2.Text = "已标记取消下载，等待下载程序响应"
    End Sub

    Private Sub 开始下载ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 开始下载ToolStripMenuItem.Click
        If 是否下载成功 Then Exit Sub
        If 设置_下载地址 = "" Then Exit Sub
        If 是否终止下载 = False Then Exit Sub
        是否终止下载 = False
        是否取消解压 = False
        开始下载()
    End Sub

    Private Sub 取消操作ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 取消操作ToolStripMenuItem.Click
        是否终止下载 = True
        是否取消解压 = True
        Me.Dispose(True)
    End Sub

End Class
