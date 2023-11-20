Imports System.IO
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class CD3

    Public Shared Sub 匹配到_复制文件夹到Mods()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        If 任务队列.是否关闭config自动保留机制 = False Then
            Dim a1 As String = Path.Combine(任务队列.项路径, ".config", 参数列表(0), "config.json")
            Dim a2 As String = Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0), "config.json")
            If FileExists(a1) = True Then CopyFile(a2, a1, True)
        End If
        DeleteDirectory(Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0)), FileIO.DeleteDirectoryOption.DeleteAllContents)
    End Sub

    Public Shared Sub 匹配到_复制文件夹()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        DeleteDirectory(Path.Combine(任务队列.游戏路径, 参数列表(1)), FileIO.DeleteDirectoryOption.DeleteAllContents)
    End Sub

    Public Shared Sub 匹配到_覆盖Content()
        Dim a As String = Path.GetFileName(任务队列.项路径)
        Dim b As String = Path.GetFileName(Path.GetDirectoryName(任务队列.项路径))
        卸载CDVD(Path.Combine(任务队列.项路径, "Content"), b, a)
    End Sub

    Public Shared Sub 匹配到_新增文件()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

    End Sub

    Public Shared Sub 匹配到_替换文件()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

    End Sub

    Public Shared Sub 匹配到_卸载时检查文件夹的存在()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

    End Sub

    Public Shared Sub 匹配到_卸载时检查文件的存在()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

    End Sub

    Public Shared Sub 匹配到_卸载时取消操作()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

    End Sub

    Public Shared Sub 匹配到_卸载时运行可执行文件()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

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
                        CopyFile(filePathInGameBackup, Path.Combine(任务队列.游戏路径, relativePath, sFile.Name), True)
                    Else
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
