
Imports System.IO
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports System.Windows.Forms
Imports SMUI6
Imports SMUI6.项信息读取类

Public Class Entry

    Public Shared Sub Entry()
        AddHandler 用于添加规划_菜单项_文件夹高级安装.Click, Sub()
                                                 SMUI6.配置队列的菜单.添加新规划通用调用("CD-D-Advanced", "<是否要还原>|<如何还原>|<要安装的文件夹>|<目标位置>")
                                             End Sub

        SMUI6.PluginAPI.添加安装规划.添加配置队列功能("CD-D-Advanced", "文件夹高级安装", 用于添加规划_菜单项_文件夹高级安装, AddressOf 编辑参数_匹配到_文件夹高级安装)

        SMUI6.PluginAPI.添加安装规划.添加安装状态值("ExistedFolder", "已存在的文件夹", Color1.紫色)
        SMUI6.PluginAPI.添加安装规划.添加安装状态值("FolderNotInstall", "文件夹未安装")

        SMUI6.PluginAPI.添加安装规划.添加安装状态判断程序("CD-D-Advanced", AddressOf 判断安装状态_文件夹高级安装)

        SMUI6.PluginAPI.添加安装规划.添加安装卸载功能("CD-D-Advanced",
                                        AddressOf 加入执行列表_文件夹高级安装,
                                        AddressOf 执行安装操作_文件夹高级安装,
                                        AddressOf 执行卸载操作_文件夹高级安装)

    End Sub


    Public Shared Property 用于添加规划_菜单项_文件夹高级安装 As New ToolStripMenuItem With {.Text = "文件夹高级安装"}


    Public Shared Property 来自_文件夹高级安装_要安装哪个文件夹 As String
    Public Shared Property 来自_文件夹高级安装_目标位置 As String
    Public Shared Property 来自_文件夹高级安装_卸载时如何操作 As String
    Public Shared Property 来自_文件夹高级安装_还原方式 As String

    Public Shared Sub 编辑参数_匹配到_文件夹高级安装()
        来自_文件夹高级安装_卸载时如何操作 = ""
        来自_文件夹高级安装_还原方式 = ""
        来自_文件夹高级安装_要安装哪个文件夹 = ""
        来自_文件夹高级安装_目标位置 = ""
        Dim a As New Form编辑规划_文件夹高级安装
        Dim 参数列表 = SMUI6.PluginAPI.添加安装规划.获取配置队列中选中规划的参数
        Select Case 参数列表(0).Trim.ToLower
            Case "restore"
                a.UiRadioButton1.Checked = True
                a.UiRadioButton2.Checked = False
            Case "delete"
                a.UiRadioButton1.Checked = False
                a.UiRadioButton2.Checked = True
        End Select
        Select Case 参数列表(1).Trim.ToLower
            Case "delete-copy"
                a.UiRadioButton3.Checked = True
                a.UiRadioButton4.Checked = False
            Case "cover"
                a.UiRadioButton3.Checked = False
                a.UiRadioButton4.Checked = True
        End Select
        If Not 参数列表(2).Contains("<"c) Then a.暗黑文本框1.Text = 参数列表(2)
        If Not 参数列表(3).Contains("<"c) Then a.暗黑文本框2.Text = 参数列表(3)
        SMUI6.PluginAPI.显示窗体.向主窗口显示模式窗体(a)
        If 来自_文件夹高级安装_要安装哪个文件夹 <> "" Then
            Dim b As New List(Of String) From {
                来自_文件夹高级安装_卸载时如何操作,
                来自_文件夹高级安装_还原方式,
                来自_文件夹高级安装_要安装哪个文件夹,
                来自_文件夹高级安装_目标位置
            }
            SMUI6.PluginAPI.添加安装规划.将用户编辑好的参数写回去(b)
        End If
        a.Dispose()
    End Sub

    Public Shared Function 判断安装状态_文件夹高级安装(项路径 As String, 游戏路径 As String, 参数列表 As String(), 计算类型 As 项数据计算类型结构, 当前的安装状态 As String) As String
        If 计算类型.安装状态 = False Then
            Return ""
            Exit Function
        End If
        If 当前的安装状态 = "UnKnow" Then
            If DirectoryExists(Path.Combine(游戏路径, 参数列表(3))) Then
                Return "ExistedFolder"
            Else
                Return "FolderNotInstall"
            End If
        Else
            Return ""
        End If
    End Function

    Public Shared Sub 加入执行列表_文件夹高级安装()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                   .规划名称 = "CD-D-Advanced",
                   .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub

    Public Shared Sub 执行安装操作_文件夹高级安装()
        Dim 参数列表 = SMUI6.PluginAPI.添加安装规划.在安装卸载操作中获取参数列表
        SMUI6.PluginAPI.添加安装规划.在安装卸载操作中输出调试信息(1, $"正在安装文件夹：{参数列表(3)}")
        CopyDirectory(Path.Combine(任务队列.项路径, 参数列表(2)), Path.Combine(任务队列.游戏路径, 参数列表(3)), True)
    End Sub

    Public Shared Sub 执行卸载操作_文件夹高级安装()
        Dim 参数列表 = SMUI6.PluginAPI.添加安装规划.在安装卸载操作中获取参数列表
        If 参数列表(0).Trim.Equals("ReStore", StringComparison.CurrentCultureIgnoreCase) Then
            If DirectoryExists(Path.Combine(任务队列.游戏备份路径, 参数列表(3))) Then
                If 参数列表(1).Trim.Equals("Delete-Copy", StringComparison.CurrentCultureIgnoreCase) Then
                    SMUI6.PluginAPI.添加安装规划.在安装卸载操作中输出调试信息(1, $"正在删除文件夹：{参数列表(3)}")
                    DeleteDirectory(Path.Combine(任务队列.游戏路径, 参数列表(3)), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    SMUI6.PluginAPI.添加安装规划.在安装卸载操作中输出调试信息(1, $"正在从备份中还原：{参数列表(3)}")
                    CopyDirectory(Path.Combine(任务队列.项路径, 参数列表(3)), Path.Combine(任务队列.游戏路径, 参数列表(3)), True)
                Else
                    SMUI6.PluginAPI.添加安装规划.在安装卸载操作中输出调试信息(1, $"正在从备份中覆盖：{参数列表(3)}")
                    CopyDirectory(Path.Combine(任务队列.项路径, 参数列表(3)), Path.Combine(任务队列.游戏路径, 参数列表(3)), True)
                End If
            Else
                SMUI6.PluginAPI.添加安装规划.在安装卸载操作中输出调试信息(1, $"找不到对应的文件夹备份：{参数列表(3)}，只能直接删除，注意这可能引发意外情况")
            End If
        Else
            SMUI6.PluginAPI.添加安装规划.在安装卸载操作中输出调试信息(1, $"正在删除文件夹：{参数列表(3)}")
            DeleteDirectory(Path.Combine(任务队列.游戏路径, 参数列表(3)), FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
    End Sub


End Class
