Imports System.IO
Imports Microsoft.VisualBasic.FileIO.FileSystem

Public Class CD3

    Public Shared Sub 匹配到_复制文件夹到Mods()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        If 任务队列.是否关闭config自动保留机制 = False Then
            Dim a1 As String = Path.Combine(任务队列.项路径, ".config", 参数列表(0), "config.json")
            Dim a2 As String = Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0), "config.json")
            If FileExists(a1) = True Then
                CopyFile(a2, a1, True)
                安装卸载.后台线程对象.ReportProgress(1, $"已备份 config.json")
            End If
        End If
        安装卸载.后台线程对象.ReportProgress(1, $"正在删除 Mods 中的文件夹：{参数列表(0)}")
        DeleteDirectory(Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0)), FileIO.DeleteDirectoryOption.DeleteAllContents)
    End Sub

    Public Shared Sub 匹配到_复制文件夹()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        安装卸载.后台线程对象.ReportProgress(1, $"正在删除文件夹：{参数列表(0)}")
        DeleteDirectory(Path.Combine(任务队列.游戏路径, 参数列表(1)), FileIO.DeleteDirectoryOption.DeleteAllContents)
    End Sub

    Public Shared Sub 匹配到_覆盖Content()
        Dim a As String = Path.GetFileName(任务队列.项路径)
        Dim b As String = Path.GetFileName(Path.GetDirectoryName(任务队列.项路径))
        安装卸载.后台线程对象.ReportProgress(1, $"正在按照 Content 结构卸载文件")
        卸载CDVD(Path.Combine(任务队列.项路径, "Content"), b, a)
    End Sub

    Public Shared Sub 匹配到_新增文件()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        安装卸载.后台线程对象.ReportProgress(1, $"正在删除目标文件：{参数列表(1)}")
        DeleteFile(Path.Combine(任务队列.游戏路径, 参数列表(1)))
    End Sub

    Public Shared Sub 匹配到_替换文件()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        If FileExists(Path.Combine(任务队列.游戏备份路径, 参数列表(1))) = True Then
            安装卸载.后台线程对象.ReportProgress(1, $"找到备份，正在还原目标文件：{参数列表(1)}")
            CopyFile(Path.Combine(任务队列.游戏备份路径, 参数列表(1)), Path.Combine(任务队列.游戏路径, 参数列表(1)), True)
        Else
            安装卸载.后台线程对象.ReportProgress(1, $"未找到备份，正在删除目标文件：{参数列表(1)}")
            DeleteFile(Path.Combine(任务队列.游戏路径, 参数列表(1)))
        End If
    End Sub

    Public Shared Sub 匹配到_卸载时检查文件夹的存在()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        Dim 要存在还是不存在 As Boolean = 参数列表(0) = "True"
        For i = 1 To 参数列表.Count - 1
            If DirectoryExists(Path.Combine(任务队列.游戏路径, 参数列表(i))) = 要存在还是不存在 Then
                Err.Raise(10590202,, "要检查的文件夹的存在性应该为：" & 要存在还是不存在 & "" & 参数列表(i))
                Exit Sub
            End If
        Next
    End Sub

    Public Shared Sub 匹配到_卸载时检查文件的存在()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        Dim 要存在还是不存在 As Boolean = 参数列表(0) = "True"
        For i = 1 To 参数列表.Count - 1
            If FileExists(Path.Combine(任务队列.游戏路径, 参数列表(i))) = 要存在还是不存在 Then
                Err.Raise(10590202,, "要检查的文件的存在性应该为：" & 要存在还是不存在 & "：" & 参数列表(i))
                Exit Sub
            End If
        Next
    End Sub

    Public Shared Sub 匹配到_卸载时取消操作()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        Select Case 参数列表(0)
            Case "ERROR"
                Err.Raise(10590204,, "此项禁止卸载")
            Case "CANCEL"
                安装卸载.后台线程对象.ReportProgress(1, $"规划数据设定取消卸载操作")
                任务队列.是否取消了操作 = True
        End Select
    End Sub

    Public Shared Sub 匹配到_卸载时运行可执行文件()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        If FileExists(Path.Combine(任务队列.项路径, 参数列表(0))) = False Then
            Err.Raise(10590202,, "指定的可执行文件不存在：" & 参数列表(0))
            Exit Sub
        End If
        Dim a As New Process
        a.StartInfo.UseShellExecute = False
        a.StartInfo.WorkingDirectory = Path.GetDirectoryName(Path.Combine(任务队列.游戏路径, 参数列表(0)))
        a.StartInfo.FileName = Path.Combine(任务队列.游戏路径, 参数列表(0))
        a.StartInfo.Arguments = 参数列表(1)
        a.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        安装卸载.后台线程对象.ReportProgress(1, $"运行可执行文件：{参数列表(0)}")
        a.Start()
        安装卸载.后台线程对象.ReportProgress(1, $"等待程序结束")
        a.WaitForExit()
        安装卸载.后台线程对象.ReportProgress(1, $"程序结束")
    End Sub

    Public Shared Sub 匹配到_卸载时弹窗()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

    End Sub

    Public Shared Sub 匹配到_声明各种核心功能的启停()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)


    End Sub

    Private Shared Sub 卸载CDVD(ByVal PathInLibrary As String, ByVal CategoryInLibrary As String, ByVal NameInLibrary As String)
        If DirectoryExists(PathInLibrary) = True Then
            Dim mDirectory As New System.IO.DirectoryInfo(PathInLibrary)
            For Each sFile In mDirectory.GetFiles("*.*")
                Try
                    Dim relativePath As String = Mid(Replace(PathInLibrary, 任务队列.项路径, ""), 2)
                    Dim filePathInGameBackup As String = Path.Combine(任务队列.游戏备份路径, relativePath, sFile.Name)
                    If FileExists(filePathInGameBackup) Then
                        安装卸载.后台线程对象.ReportProgress(1, $"找到备份，正在还原：{Path.Combine(relativePath, sFile.Name)}")
                        CopyFile(filePathInGameBackup, Path.Combine(任务队列.游戏路径, relativePath, sFile.Name), True)
                    Else
                        安装卸载.后台线程对象.ReportProgress(1, $"找不到备份，正在删除：{Path.Combine(relativePath, sFile.Name)}")
                        DeleteFile(Path.Combine(任务队列.游戏路径, relativePath, sFile.Name))
                    End If
                Catch ex As Exception

                End Try
            Next
            For Each sSubDirectory In mDirectory.GetDirectories
                卸载CDVD(sSubDirectory.FullName, CategoryInLibrary, NameInLibrary)
            Next
        End If
    End Sub




End Class
