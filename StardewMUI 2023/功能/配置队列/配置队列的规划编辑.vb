Imports System.IO
Imports SMUI6.公共对象
Imports Sunny.UI

Public Class 配置队列的规划编辑

    Public Shared Property 来自_选择文件夹_所选的文件夹 As String

    Public Shared Sub 匹配到_复制文件夹到Mods()
        来自_选择文件夹_所选的文件夹 = ""
        Dim a As New Form编辑规划_选择文件夹 With {.Text = 配置队列.规划显示名称字典(任务队列操作类型枚举.复制文件夹到Mods)}
        For Each mDir As DirectoryInfo In New DirectoryInfo(配置队列.正在编辑规划的项路径).GetDirectories
            If FileIO.FileSystem.FileExists(Path.Combine(mDir.FullName, "manifest.json")) Then
                Select Case mDir.Name
                    Case "Screenshot", ".config"
                    Case Else
                        a.ListView1.Items.Add(mDir.Name)
                End Select
            End If
        Next
        If Form1.ListView7.SelectedItems(0).SubItems(1).Text <> "" Then
            For i = 0 To a.ListView1.Items.Count - 1
                If a.ListView1.Items(i).Text = Form1.ListView7.SelectedItems(0).SubItems(1).Text Then
                    a.ListView1.Items(i).Selected = True
                    Exit For
                End If
            Next
        End If
        显示模式窗体(a, Form1)
        If 来自_选择文件夹_所选的文件夹 <> "" Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = 来自_选择文件夹_所选的文件夹
        End If
        a.Dispose()
    End Sub

    Public Shared Sub 匹配到_覆盖文件夹到Mods()
        来自_选择文件夹_所选的文件夹 = ""
        Dim a As New Form编辑规划_选择文件夹 With {.Text = 配置队列.规划显示名称字典(任务队列操作类型枚举.覆盖文件夹到Mods)}
        For Each mDir As DirectoryInfo In New DirectoryInfo(配置队列.正在编辑规划的项路径).GetDirectories
            Select Case mDir.Name
                Case "Screenshot", ".config"
                Case Else
                    a.ListView1.Items.Add(mDir.Name)
            End Select
        Next
        If Form1.ListView7.SelectedItems(0).SubItems(1).Text <> "" Then
            For i = 0 To a.ListView1.Items.Count - 1
                If a.ListView1.Items(i).Text = Form1.ListView7.SelectedItems(0).SubItems(1).Text Then
                    a.ListView1.Items(i).Selected = True
                    Exit For
                End If
            Next
        End If
        显示模式窗体(a, Form1)
        If 来自_选择文件夹_所选的文件夹 <> "" Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = 来自_选择文件夹_所选的文件夹
        End If
        a.Dispose()
    End Sub

    Public Shared Property 来自_复制文件夹_所选的文件夹 As String
    Public Shared Property 来自_复制文件夹_目标文件夹相对路径 As String

    Public Shared Sub 来自_复制文件夹_通用调用(标题栏 As String, 窗体上文本1 As String, 窗体上文本2 As String, 列表里的选项 As List(Of String))
        来自_复制文件夹_所选的文件夹 = ""
        来自_复制文件夹_目标文件夹相对路径 = ""
        Dim a As New Form编辑规划_复制文件夹 With {.Text = 标题栏}
        a.Label1.Text = 窗体上文本1
        a.Label2.Text = 窗体上文本2
        For i = 0 To 列表里的选项.Count - 1
            a.ListView1.Items.Add(列表里的选项(i))
        Next
        Dim 参数列表 As New List(Of String)(Form1.ListView7.SelectedItems(0).SubItems(1).Text.Split("|").ToList)
        If 参数列表(0) <> "" Then
            For i = 0 To a.ListView1.Items.Count - 1
                If a.ListView1.Items(i).Text = 参数列表(0) Then
                    a.ListView1.Items(i).Selected = True
                    Exit For
                End If
            Next
        End If
        a.暗黑文本框1.Text = 参数列表(1)
        显示模式窗体(a, Form1)
        If 来自_复制文件夹_所选的文件夹 <> "" Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = $"{来自_复制文件夹_所选的文件夹}|{来自_复制文件夹_目标文件夹相对路径}"
        End If
        a.Dispose()
    End Sub

    Public Shared Sub 匹配到_复制文件夹()
        Dim L1 As New List(Of String)
        For Each mDir As DirectoryInfo In New DirectoryInfo(配置队列.正在编辑规划的项路径).GetDirectories
            Select Case mDir.Name
                Case "Screenshot", ".config"
                Case Else
                    L1.Add(mDir.Name)
            End Select
        Next
        来自_复制文件夹_通用调用(配置队列.规划显示名称字典(任务队列操作类型枚举.复制文件夹), "选择文件夹", "复制到目标位置（从游戏根目录算起）", L1)
    End Sub

    Public Shared Sub 匹配到_覆盖Content()
        UIMessageTip.Show($"此规划操作没有可配置的选项",, 1200)
    End Sub

    Public Shared Sub 匹配到_新增文件()
        Dim L1 As New List(Of String)
        For Each mFile As FileInfo In New DirectoryInfo(配置队列.正在编辑规划的项路径).GetFiles
            Select Case mFile.Name
                Case "Code2", "README", "Version", "Code", "README.rtf", "Font", "Color", "SORT"
                Case Else
                    L1.Add(mFile.Name)
            End Select
        Next
        来自_复制文件夹_通用调用(配置队列.规划显示名称字典(任务队列操作类型枚举.新增文件), "选择文件", "新增到目标位置（从游戏根目录算起）", L1)
    End Sub

    Public Shared Sub 匹配到_新增文件并验证()
        Dim L1 As New List(Of String)
        For Each mFile As FileInfo In New DirectoryInfo(配置队列.正在编辑规划的项路径).GetFiles
            Select Case mFile.Name
                Case "Code2", "README", "Version", "Code", "README.rtf", "Font", "Color", "SORT"
                Case Else
                    L1.Add(mFile.Name)
            End Select
        Next
        来自_复制文件夹_通用调用(配置队列.规划显示名称字典(任务队列操作类型枚举.新增文件并验证), "选择文件", "新增到目标位置（从游戏根目录算起）", L1)
    End Sub

    Public Shared Sub 匹配到_替换文件()
        Dim L1 As New List(Of String)
        For Each mFile As FileInfo In New DirectoryInfo(配置队列.正在编辑规划的项路径).GetFiles
            Select Case mFile.Name
                Case "Code2", "README", "Version", "Code", "README.rtf", "Font", "Color", "SORT"
                Case Else
                    L1.Add(mFile.Name)
            End Select
        Next
        来自_复制文件夹_通用调用(配置队列.规划显示名称字典(任务队列操作类型枚举.替换文件), "选择文件", "替换到目标位置（从游戏根目录算起）", L1)
    End Sub

    Public Shared Sub 匹配到_替换文件且无检测()
        Dim L1 As New List(Of String)
        For Each mFile As FileInfo In New DirectoryInfo(配置队列.正在编辑规划的项路径).GetFiles
            Select Case mFile.Name
                Case "Code2", "README", "Version", "Code", "README.rtf", "Font", "Color", "SORT"
                Case Else
                    L1.Add(mFile.Name)
            End Select
        Next
        来自_复制文件夹_通用调用(配置队列.规划显示名称字典(任务队列操作类型枚举.替换文件且无检测), "选择文件", "替换到目标位置（从游戏根目录算起）", L1)
    End Sub




    Public Shared Property 来自_检查存在性_填写的相对路径 As String
    Public Shared Property 来自_检查存在性_要存在还是不存在 As Boolean

    Public Shared Sub 来自_检查存在性_通用调用(标题栏 As String, 窗体上文本1 As String, 对应操作类型 As 任务队列操作类型枚举)
        来自_检查存在性_填写的相对路径 = ""
        来自_检查存在性_要存在还是不存在 = True
        Dim a As New Form编辑规划_检查存在性 With {.Text = 标题栏}
        a.Label1.Text = 窗体上文本1
        Dim 参数列表 As New List(Of String)(Form1.ListView7.SelectedItems(0).SubItems(1).Text.Split("|").ToList)
        a.暗黑文本框1.Text = 参数列表(0)
        If 参数列表(1).ToLower.Trim = "true" Then
            a.UiRadioButton1.Checked = True
            a.UiRadioButton2.Checked = False
        Else
            a.UiRadioButton1.Checked = False
            a.UiRadioButton2.Checked = True
        End If
        Select Case 对应操作类型
            Case 任务队列操作类型枚举.安装时检查文件夹的存在, 任务队列操作类型枚举.卸载时检查文件夹的存在
                a.正在判断文件夹还是文件 = "文件夹"
            Case 任务队列操作类型枚举.安装时检查文件的存在, 任务队列操作类型枚举.卸载时检查文件的存在
                a.正在判断文件夹还是文件 = "文件"
        End Select
        显示模式窗体(a, Form1)
        If 来自_检查存在性_填写的相对路径 <> "" Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = $"{来自_检查存在性_填写的相对路径}|{If(来自_检查存在性_要存在还是不存在, "True", "False")}"
        End If
        a.Dispose()
    End Sub

    Public Shared Sub 匹配到_安装时检查文件夹的存在()
        来自_检查存在性_通用调用(配置队列.规划显示名称字典(任务队列操作类型枚举.安装时检查文件夹的存在), "要进行判断的文件夹（从游戏根目录算起）", 任务队列操作类型枚举.安装时检查文件夹的存在)
    End Sub

    Public Shared Sub 匹配到_卸载时检查文件夹的存在()
        来自_检查存在性_通用调用(配置队列.规划显示名称字典(任务队列操作类型枚举.卸载时检查文件夹的存在), "要进行判断的文件夹（从游戏根目录算起）", 任务队列操作类型枚举.卸载时检查文件夹的存在)
    End Sub

    Public Shared Sub 匹配到_安装时检查文件的存在()
        来自_检查存在性_通用调用(配置队列.规划显示名称字典(任务队列操作类型枚举.安装时检查文件的存在), "要进行判断的文件（从游戏根目录算起）", 任务队列操作类型枚举.安装时检查文件的存在)
    End Sub

    Public Shared Sub 匹配到_卸载时检查文件的存在()
        来自_检查存在性_通用调用(配置队列.规划显示名称字典(任务队列操作类型枚举.卸载时检查文件的存在), "要进行判断的文件（从游戏根目录算起）", 任务队列操作类型枚举.卸载时检查文件的存在)
    End Sub

    Public Shared Sub 匹配到_安装时检查Mods中已安装模组的版本()

    End Sub

    Public Shared Sub 匹配到_卸载时取消操作()

    End Sub

    Public Shared Sub 匹配到_安装时运行可执行文件()

    End Sub

    Public Shared Sub 匹配到_卸载时运行可执行文件()

    End Sub

    Public Shared Sub 匹配到_安装时弹窗()

    End Sub

    Public Shared Sub 匹配到_卸载时弹窗()

    End Sub

    Public Shared Sub 匹配到_声明各种核心功能的启停()

    End Sub


End Class
