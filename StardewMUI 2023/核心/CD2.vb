Imports System.IO
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Sunny.UI

Public Class CD2

    Public Shared Sub 匹配到_复制文件夹到Mods()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        安装卸载.后台线程对象.ReportProgress(1, $"正在复制文件夹到 Mods 中：{参数列表(0)}")
        CopyDirectory(Path.Combine(任务队列.项路径, 参数列表(0)), Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0)), True)
        If 任务队列.是否关闭config自动保留机制 = False Then
            Dim a1 As String = Path.Combine(任务队列.项路径, ".config", 参数列表(0), "config.json")
            Dim a2 As String = Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0), "config.json")
            If FileExists(a1) = True Then
                CopyFile(a1, a2, True)
                安装卸载.后台线程对象.ReportProgress(1, $"已还原 config.json")
            End If
        End If
    End Sub

    Public Shared Sub 匹配到_覆盖文件夹到Mods()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        If DirectoryExists(Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0))) = False Then
            Err.Raise(10590202,, "在 Mods 找不到已安装的文件夹：" & 参数列表(0), Color.OrangeRed, True)
        Else
            安装卸载.后台线程对象.ReportProgress(1, $"正在覆盖 Mods 内已存在文件夹：{参数列表(0)}")
            CopyDirectory(Path.Combine(任务队列.项路径, 参数列表(0)), Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0)), True)
        End If
    End Sub

    Public Shared Sub 匹配到_复制文件夹()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        安装卸载.后台线程对象.ReportProgress(1, $"正在复制文件夹：{参数列表(0)}")
        CopyDirectory(Path.Combine(任务队列.项路径, 参数列表(0)), Path.Combine(任务队列.游戏路径, 参数列表(0)), True)
    End Sub

    Public Shared Sub 匹配到_覆盖Content()
        安装卸载.后台线程对象.ReportProgress(1, $"正在覆盖游戏 Content 文件夹")
        CopyDirectory(Path.Combine(任务队列.项路径, "Content"), Path.Combine(任务队列.游戏路径, "Content"), True)
    End Sub

    Public Shared Sub 匹配到_新增文件()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        安装卸载.后台线程对象.ReportProgress(1, $"正在复制到目标文件：{参数列表(1)}")
        CopyFile(Path.Combine(任务队列.项路径, 参数列表(0)), Path.Combine(任务队列.游戏路径, 参数列表(1)), True)
    End Sub

    Public Shared Sub 匹配到_替换文件()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        安装卸载.后台线程对象.ReportProgress(1, $"正在替换目标文件：{参数列表(1)}")
        CopyFile(Path.Combine(任务队列.项路径, 参数列表(0)), Path.Combine(任务队列.游戏路径, 参数列表(1)), True)
    End Sub

    Public Shared Sub 匹配到_安装时检查文件夹的存在()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        Dim 要存在还是不存在 As Boolean = 参数列表(0) = "True"
        For i = 1 To 参数列表.Count - 1
            If DirectoryExists(Path.Combine(任务队列.游戏路径, 参数列表(i))) = 要存在还是不存在 Then
                Err.Raise(10590202,, "要检查的文件夹的存在性应该为：" & 要存在还是不存在 & "" & 参数列表(i))
                Exit Sub
            End If
        Next
    End Sub

    Public Shared Sub 匹配到_安装时检查文件的存在()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        Dim 要存在还是不存在 As Boolean = 参数列表(0) = "True"
        For i = 1 To 参数列表.Count - 1
            If FileExists(Path.Combine(任务队列.游戏路径, 参数列表(i))) = 要存在还是不存在 Then
                Err.Raise(10590202,, "要检查的文件的存在性应该为：" & 要存在还是不存在 & "：" & 参数列表(i))
                Exit Sub
            End If
        Next
    End Sub

    Public Shared Sub 匹配到_安装时检查Mods中已安装模组的版本()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        If 参数列表.Count <> 3 Then
            Err.Raise(10590201,, "参数数量不正确，请不要擅自修改规划文件")
            Exit Sub
        End If
        If DirectoryExists(Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0))) = True Then
            Err.Raise(10590202,, "要进行版本检查的模组文件夹未安装：" & 参数列表(0))
            Exit Sub
        End If
        If FileExists(Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0), "manifest.json")) = True Then
            Err.Raise(10590202,, "要进行版本检查的模组文件夹中没有清单文件：" & 参数列表(0))
            Exit Sub
        End If
        Dim a As String = ReadAllText(Path.Combine(任务队列.游戏路径, "Mods", 参数列表(0), "manifest.json"))
        Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)
        Dim x As String = JsonData.item("Version")?.ToString
        If x = "" Then
            Err.Raise(10590202,, "目标清单文件中不包含版本信息：" & 参数列表(0))
            Exit Sub
        End If
        Select Case 参数列表(1)
            Case "<"
                If Not 共享方法.CompareVersion(x, 参数列表(2)) < 0 Then
                    Err.Raise(10590202,, "已安装的模组必须小于此版本：" & 参数列表(0) & " " & 参数列表(2))
                    Exit Sub
                End If
            Case "="
                If Not 共享方法.CompareVersion(x, 参数列表(2)) = 0 Then
                    Err.Raise(10590202,, "已安装的模组必须等于此版本：" & 参数列表(0) & " " & 参数列表(2))
                    Exit Sub
                End If
            Case ">"
                If Not 共享方法.CompareVersion(x, 参数列表(2)) > 0 Then
                    Err.Raise(10590202,, "已安装的模组必须大于此版本：" & 参数列表(0) & " " & 参数列表(2))
                    Exit Sub
                End If
            Case "<="
                If Not 共享方法.CompareVersion(x, 参数列表(2)) <= 0 Then
                    Err.Raise(10590202,, "已安装的模组必须小于等于此版本：" & 参数列表(0) & " " & 参数列表(2))
                    Exit Sub
                End If
            Case ">="
                If Not 共享方法.CompareVersion(x, 参数列表(2)) >= 0 Then
                    Err.Raise(10590202,, "已安装的模组必须大于等于此版本：" & 参数列表(0) & " " & 参数列表(2))
                    Exit Sub
                End If
            Case "<>"
                If Not 共享方法.CompareVersion(x, 参数列表(2)) <> 0 Then
                    Err.Raise(10590202,, "已安装的模组必须不相等于此版本：" & 参数列表(0) & " " & 参数列表(2))
                    Exit Sub
                End If
            Case Else
                Err.Raise(10590201,, "无法识别比较参数，请不要擅自修改规划文件")
                Exit Sub
        End Select
    End Sub

    Public Shared Sub 匹配到_安装时运行可执行文件()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        If FileExists(Path.Combine(任务队列.项路径, 参数列表(0))) = False Then
            Err.Raise(10590202,, "指定的可执行文件不存在：" & 参数列表(0))
            Exit Sub
        End If
        Dim a As New Process
        a.StartInfo.WorkingDirectory = Path.GetDirectoryName(Path.Combine(任务队列.项路径, 参数列表(0)))
        a.StartInfo.FileName = Path.Combine(任务队列.项路径, 参数列表(0))
        a.StartInfo.Arguments = 参数列表(1)
        a.StartInfo.WindowStyle = ProcessWindowStyle.Normal
        安装卸载.后台线程对象.ReportProgress(1, $"运行可执行文件：{参数列表(0)}")
        a.Start()
        安装卸载.后台线程对象.ReportProgress(1, $"等待程序结束")
        a.WaitForExitAsync()
    End Sub

    Public Shared Sub 匹配到_安装时弹窗()
        Dim 参数列表 As New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)

    End Sub

    Public Shared Sub 匹配到_声明各种核心功能的启停()

    End Sub

End Class
