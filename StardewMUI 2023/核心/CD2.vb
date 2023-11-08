Imports System.IO
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports Microsoft.VisualBasic.FileIO.FileSystem

Public Class CD2

    Public Shared Sub 匹配到_复制文件夹到Mods()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        CopyDirectory(Path.Combine(任务队列.项路径, 参数列表(0)), Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0)), True)
        If 任务队列.是否关闭config自动保留机制 = False Then
            Dim a1 As String = Path.Combine(任务队列.项路径, ".config", 参数列表(0), "config.json")
            Dim a2 As String = Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0), "config.json")
            If FileExists(a1) = True Then CopyFile(a1, a2, True)
        End If
    End Sub

    Public Shared Sub 匹配到_覆盖文件夹到Mods()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        If DirectoryExists(Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0))) = False Then
            Err.Raise(10590202,, "在 Mods 找不到已安装的文件夹：" & 参数列表(0), Color.OrangeRed, True)
        Else
            CopyDirectory(Path.Combine(任务队列.项路径, 参数列表(0)), Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0)), True)
        End If
    End Sub

    Public Shared Sub 匹配到_复制文件夹()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        CopyDirectory(Path.Combine(任务队列.项路径, 参数列表(0)), Path.Combine(任务队列.游戏路径, 参数列表(0)), True)
    End Sub

    Public Shared Sub 匹配到_覆盖Content()
        'Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)  '没有参数，不需要计算
        CopyDirectory(Path.Combine(任务队列.项路径, "Content"), Path.Combine(任务队列.游戏路径, "Content"), True)
    End Sub

    Public Shared Sub 匹配到_新增文件()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        CopyFile(Path.Combine(任务队列.项路径, 参数列表(0)), Path.Combine(任务队列.游戏路径, 参数列表(1)), True)
    End Sub

    Public Shared Sub 匹配到_替换文件()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        CopyFile(Path.Combine(任务队列.项路径, 参数列表(0)), Path.Combine(任务队列.游戏路径, 参数列表(1)), True)
    End Sub

    Public Shared Sub 匹配到_安装时检查文件夹的存在()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        For i = 0 To 参数列表.Count - 1
            If DirectoryExists(Path.Combine(任务队列.游戏路径, 参数列表(i))) = False Then
                Err.Raise(10590203,, "要检查的文件夹不存在：" & 参数列表(i))
                Exit Sub
            End If
        Next
    End Sub

    Public Shared Sub 匹配到_安装时检查文件的存在()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

    End Sub

    Public Shared Sub 匹配到_安装时检查Mods中的排斥文件夹()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

    End Sub

    Public Shared Sub 匹配到_安装时检查Mods中已安装模组的版本()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

    End Sub

    Public Shared Sub 匹配到_安装时运行可执行文件()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

    End Sub

    Public Shared Sub 匹配到_安装时弹窗()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

    End Sub

    Public Shared Sub 匹配到_声明各种核心功能的启停()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

    End Sub

End Class
