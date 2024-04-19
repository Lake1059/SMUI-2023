Imports System.Drawing.Imaging
Imports System.IO
Imports SMUI6.项信息读取类
Imports Sunny.UI

Public Class 管理模组

    Public Shared Property 实时分类排序 As New List(Of String)
    Public Shared Property 实时分类排序是否经过修改 As Boolean = False
    Public Shared Property 实时模组项排序 As New List(Of String)
    Public Shared Property 实时模组项排序是否经过修改 As Boolean = False
    Public Shared Property 实时模组项列表内容归属的分类 As String = ""


    Public Shared Sub 初始化()
        AddHandler 管理模组的菜单.菜单项_刷新数据子库.Click, AddressOf 扫描数据子库
        AddHandler 管理模组的菜单.菜单项_刷新分类.Click, AddressOf 扫描分类
        AddHandler 管理模组的菜单.菜单项_新建数据子库.Click, AddressOf 新建数据子库
        AddHandler 管理模组的菜单.菜单项_新建分类.Click, AddressOf 分类操作.新建分类
        AddHandler 管理模组的菜单.菜单项_转移分类.Click, AddressOf 分类操作.转移分类
        AddHandler 管理模组的菜单.菜单项_重命名分类.Click, AddressOf 分类操作.重命名分类
        AddHandler 管理模组的菜单.菜单项_删除分类.Click, AddressOf 分类操作.删除分类

        AddHandler Form1.ListView1.KeyDown, Sub(sender, e) 分类列表键盘按下事件(sender, e)
        AddHandler Form1.ListView1.SelectedIndexChanged, Sub(sender, e) 扫描模组项()
        AddHandler Form1.UiButton3.Click, Sub(sender, e) 扫描模组项(True)
        AddHandler Form1.ListView2.KeyDown, Sub(sender, e) 模组项列表键盘按下事件(sender, e)
        AddHandler Form1.ListView2.SelectedIndexChanged, AddressOf 项列表计数显示
        AddHandler Form1.ListView2.SelectedIndexChanged, AddressOf 读取项信息并显示
        AddHandler Form1.UiButton7.Click,
            Sub()
                If Form依赖项表.Visible = False Then
                    Form依赖项表.Left = Form1.Left + 30 * 界面控制.X轴DPI比率
                    Form依赖项表.Top = Form1.Top + Form1.Height - Form依赖项表.Height - 60 * 界面控制.X轴DPI比率
                    Form依赖项表.Show(Form1)
                Else
                    Form依赖项表.Close()
                End If
            End Sub


        AddHandler 管理模组的菜单.菜单项_打开分类的文件夹.Click, AddressOf 打开分类文件夹

        AddHandler 管理模组的菜单.菜单项_安装.Click, Sub(sender, e) 安装卸载.执行操作(安装卸载.操作类型.安装)
        AddHandler 管理模组的菜单.菜单项_卸载.Click, Sub(sender, e) 安装卸载.执行操作(安装卸载.操作类型.卸载)
        AddHandler 管理模组的菜单.菜单项_打开项的文件夹.Click, AddressOf 打开模组项文件夹

        AddHandler 管理模组的菜单.菜单项_更多分类操作_转换安装命令到安装规划.Click, AddressOf 管理模组3.更新选中分类_从安装命令到安装规划
        AddHandler 管理模组的菜单.菜单项_更多分类操作_转换安装规划到安装命令.Click, AddressOf 管理模组3.更新选中分类_从安装规划到安装命令


        初始化安装状态显示词字典()
        扫描数据子库()
    End Sub

    Public Shared Sub 模块单元在关机时保存数据()
        保存分类排序()
        保存模组项排序()
    End Sub


    Public Shared Sub 扫描数据子库()
        管理模组的菜单.子库列表_选择.Items.Clear()
        管理模组的菜单.子库列表_删除.Items.Clear()
        If Not FileIO.FileSystem.DirectoryExists(设置.全局设置数据("LocalRepositoryPath")) Then
            If Form1.UiTabControl1.SelectedTab Is Form1.TabPage管理模组 Then
                Dim M1 As New 多项单选对话框("", {"OK"}, "模组数据库路径无效")
                M1.ShowDialog(Form1)
            End If
            Exit Sub
        End If
        Dim 子库列表 As List(Of String) = 管理模组2.扫描子库(设置.全局设置数据("LocalRepositoryPath"))
        For i = 0 To 子库列表.Count - 1
            Dim 选择子库单项 As New ToolStripMenuItem With {.Text = 子库列表(i), .Image = My.Resources.数据库}
            Dim 子库索引 As Integer = i
            AddHandler 选择子库单项.Click,
                Sub()
                    Dim 选择的子库 As String = 子库列表(子库索引)
                    设置.全局设置数据("LastUsedSubLibraryName") = 选择的子库
                    For i3 = 0 To 管理模组的菜单.子库列表_选择.Items.Count - 1
                        管理模组的菜单.子库列表_选择.Items(i3).Image = My.Resources.数据库
                    Next
                    选择子库单项.Image = My.Resources.右箭头
                    扫描分类()
                    Form1.Label50.Text = Form1.ListView1.Items.Count
                End Sub
            管理模组的菜单.子库列表_选择.Items.Add(选择子库单项)
            If 设置.全局设置数据("LastUsedSubLibraryName") = 子库列表(i) Then 选择子库单项.PerformClick()

            Dim 删除子库单项 As New ToolStripMenuItem With {.Text = 子库列表(i), .Image = My.Resources.叉号}
            AddHandler 删除子库单项.Click,
                Sub()
                    Dim 选择的子库 As String = 子库列表(子库索引)
                    Dim d2 As New 多项单选对话框("", {"确认", "取消"}, "是否确认删除当前子库，将发送到回收站以防止你反悔，同时将重置子库选择",, 500)
                    If d2.ShowDialog(Form1) = 0 Then
                        My.Computer.FileSystem.DeleteDirectory(设置.全局设置数据("LocalRepositoryPath") & "\" & 选择的子库, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                        管理模组的菜单.子库列表_选择.Items.Remove(删除子库单项)
                        管理模组的菜单.子库列表_删除.Items.Remove(删除子库单项)
                        删除子库单项.Dispose()
                        If 选择的子库 = 设置.全局设置数据("LastUsedSubLibraryName") Then 设置.全局设置数据("LastUsedSubLibraryName") = ""
                    End If
                End Sub
            管理模组的菜单.子库列表_删除.Items.Add(删除子库单项)

        Next
    End Sub

    Public Shared Sub 新建数据子库()
        Dim s1 As String = 管理模组2.检查并返回当前模组数据仓库路径()
        If s1 = "" Then Exit Sub
        Dim a As New 输入对话框("", "新建数据子库名称")
        a.TranslateButtonText("确认", "取消")
Line1:
        Dim s2 As String = a.ShowDialog(Form1)
        If s2 = "" Then Exit Sub
        If FileIO.FileSystem.DirectoryExists(Path.Combine(s1, s2)) Then
            Dim b As New 多项单选对话框("", {"确认"}, "目标文件夹已存在" & vbCrLf & vbCrLf & s1 & "\" & s2,, 500)
            b.ShowDialog(Form1)
            GoTo Line1
        Else
            FileIO.FileSystem.CreateDirectory(Path.Combine(s1, s2))
            扫描数据子库()
        End If
    End Sub


    Public Shared Sub 清除分类列表()
        清除模组项列表()
        保存分类排序()
        Form1.ListView1.Items.Clear()
        Form1.Label50.Text = Form1.ListView1.Items.Count
        实时分类排序.Clear()
        实时分类排序是否经过修改 = False
    End Sub

    Public Shared Sub 扫描分类()
        清除分类列表()
        If 管理模组2.检查并返回当前所选子库路径() = "" Then Exit Sub
        Dim 分类文件夹列表 As List(Of String) = 共享方法.扫描文件夹不包含子目录(Path.Combine(设置.全局设置数据("LocalRepositoryPath"), 设置.全局设置数据("LastUsedSubLibraryName")))
        Dim 分类排序 As New List(Of String)
        Dim 分类排序储存文件路径 As String = Path.Combine(设置.全局设置数据("LocalRepositoryPath"), 设置.全局设置数据("LastUsedSubLibraryName"), "SORT")
        If FileIO.FileSystem.FileExists(分类排序储存文件路径) Then
            Using reader As New StringReader(FileIO.FileSystem.ReadAllText(分类排序储存文件路径))
                Dim line As String = reader.ReadLine()
                While line IsNot Nothing
                    If line.Trim <> "" Then 分类排序.Add(line)
                    line = reader.ReadLine()
                End While
            End Using
        End If

        Dim 排序索引总数 As Integer = 分类排序.Count - 1
        Dim 排序索引实时 As Integer = 0
        Do Until 排序索引实时 = 排序索引总数 + 1
            If 分类文件夹列表.Contains(分类排序(排序索引实时)) Then
                Form1.ListView1.Items.Add(分类排序(排序索引实时))
                实时分类排序.Add(分类排序(排序索引实时))
                分类文件夹列表.Remove(分类排序(排序索引实时))
                排序索引实时 += 1
            Else
                分类排序.Remove(分类排序(排序索引实时))
                实时分类排序是否经过修改 = True
                排序索引总数 -= 1
            End If
        Loop

        If 分类文件夹列表.Count > 0 Then
            For i = 0 To 分类文件夹列表.Count - 1
                Form1.ListView1.Items.Add(分类文件夹列表(i))
                实时分类排序.Add(分类文件夹列表(i))
            Next
            实时分类排序是否经过修改 = True
        End If

        Form1.Label50.Text = Form1.ListView1.Items.Count

        For i = 0 To Form1.ListView1.Items.Count - 1
            Dim 分类颜色文件路径 As String = Path.Combine(设置.全局设置数据("LocalRepositoryPath"), 设置.全局设置数据("LastUsedSubLibraryName"), Form1.ListView1.Items(i).Text, "Color")
            If FileIO.FileSystem.FileExists(分类颜色文件路径) Then
                Select Case FileIO.FileSystem.ReadAllText(分类颜色文件路径)
                    Case "RED"
                        Form1.ListView1.Items(i).ForeColor = Color1.红色
                    Case "ORANGE"
                        Form1.ListView1.Items(i).ForeColor = Color1.橙色
                    Case "YELLOW"
                        Form1.ListView1.Items(i).ForeColor = Color1.黄色
                    Case "GREEN"
                        Form1.ListView1.Items(i).ForeColor = Color1.绿色
                    Case "AQUA"
                        Form1.ListView1.Items(i).ForeColor = Color1.青色
                    Case "BLUE"
                        Form1.ListView1.Items(i).ForeColor = Color1.蓝色
                    Case "PURPLE"
                        Form1.ListView1.Items(i).ForeColor = Color1.紫色
                End Select
            End If

            Dim 分类字体文件路径 As String = Path.Combine(设置.全局设置数据("LocalRepositoryPath"), 设置.全局设置数据("LastUsedSubLibraryName"), Form1.ListView1.Items(i).Text, "Font")
            If FileIO.FileSystem.FileExists(分类字体文件路径) Then
                Select Case FileIO.FileSystem.ReadAllText(分类字体文件路径)
                    Case "BD"
                        Form1.ListView1.Items(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Bold)
                    Case "LC"
                        Form1.ListView1.Items(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Italic)
                    Case "UL"
                        Form1.ListView1.Items(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Underline)
                    Case "SO"
                        Form1.ListView1.Items(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Strikeout)
                End Select
            End If

        Next

    End Sub

    Public Shared Sub 保存分类排序()
        If 实时分类排序是否经过修改 = False Then Exit Sub
        Dim 分类排序储存文件路径 As String = Path.Combine(设置.全局设置数据("LocalRepositoryPath"), 设置.全局设置数据("LastUsedSubLibraryName"), "SORT")
        If Not FileIO.FileSystem.DirectoryExists(IO.Path.GetDirectoryName(分类排序储存文件路径)) Then Exit Sub
        Dim a As String = ""
        For i = 0 To 实时分类排序.Count - 1
            If a = "" Then
                a = 实时分类排序(i)
            Else
                a &= vbCrLf & 实时分类排序(i)
            End If
        Next
        FileIO.FileSystem.WriteAllText(分类排序储存文件路径, a, False)
    End Sub

    Public Shared Sub 分类列表键盘按下事件(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F3
                上移选中的分类()
            Case Keys.F4
                下移选中的分类()
        End Select
    End Sub

    Public Shared Sub 上移选中的分类()
        If Form1.ListView1.SelectedIndices.Count > 0 Then
            For i = 0 To Form1.ListView1.SelectedIndices.Count - 1
                Dim index As Integer = Form1.ListView1.SelectedIndices(i)
                If index > 0 Then
                    If Form1.ListView1.SelectedIndices.Contains(index - 1) Then Continue For
                    Dim 变动排序的列表视图项 As ListViewItem = Form1.ListView1.Items(index)
                    Form1.ListView1.Items.RemoveAt(index)
                    Form1.ListView1.Items.Insert(index - 1, 变动排序的列表视图项)
                    Form1.ListView1.Items(index - 1).Focused = True
                    Dim 变动排序的文本 As String = 实时分类排序(index)
                    实时分类排序.RemoveAt(index)
                    实时分类排序.Insert(index - 1, 变动排序的文本)
                    实时分类排序是否经过修改 = True
                End If
            Next
        End If
    End Sub

    Public Shared Sub 下移选中的分类()
        If Form1.ListView1.SelectedIndices.Count > 0 Then
            For i = Form1.ListView1.SelectedIndices.Count - 1 To 0 Step -1
                Dim index As Integer = Form1.ListView1.SelectedIndices(i)
                If index < Form1.ListView1.Items.Count - 1 Then
                    If Form1.ListView1.SelectedIndices.Contains(index + 1) Then Continue For
                    Dim 变动排序的列表视图项 As ListViewItem = Form1.ListView1.Items(index)
                    Form1.ListView1.Items.RemoveAt(index)
                    Form1.ListView1.Items.Insert(index + 1, 变动排序的列表视图项)
                    Form1.ListView1.Items(index + 1).Focused = True
                    Dim 变动排序的文本 As String = 实时分类排序(index)
                    实时分类排序.RemoveAt(index)
                    实时分类排序.Insert(index + 1, 变动排序的文本)
                    实时分类排序是否经过修改 = True
                End If
            Next
        End If
    End Sub


    Public Shared Sub 清除模组项列表()
        重置模组项信息显示()
        保存模组项排序()
        Form1.ListView2.Items.Clear()
        Form1.Label51.Text = Form1.ListView2.Items.Count
        实时模组项排序.Clear()
        实时模组项排序是否经过修改 = False
        实时模组项列表内容归属的分类 = ""
    End Sub

    Public Shared Sub 扫描模组项(Optional 强制刷新 As Boolean = False)
        If Form1.ListView1.SelectedItems.Count <> 1 Then
            清除模组项列表()
            Exit Sub
        End If
        If 强制刷新 = False Then
            If 实时模组项列表内容归属的分类 = Form1.ListView1.Items(Form1.ListView1.SelectedIndices(0)).Text Then Exit Sub
        End If
        清除模组项列表()
        If 管理模组2.检查并返回当前选择分类路径() = "" Then Exit Sub
        Dim 模组项文件夹列表 As List(Of String) = 共享方法.扫描文件夹不包含子目录(Path.Combine(设置.全局设置数据("LocalRepositoryPath"), 设置.全局设置数据("LastUsedSubLibraryName"), Form1.ListView1.Items(Form1.ListView1.SelectedIndices(0)).Text))
        Dim 模组项排序 As New List(Of String)
        Dim 模组项排序储存文件路径 As String = Path.Combine(设置.全局设置数据("LocalRepositoryPath"), 设置.全局设置数据("LastUsedSubLibraryName"), Form1.ListView1.Items(Form1.ListView1.SelectedIndices(0)).Text, "SORT")
        If FileIO.FileSystem.FileExists(模组项排序储存文件路径) Then
            Using reader As New StringReader(FileIO.FileSystem.ReadAllText(模组项排序储存文件路径))
                Dim line As String = reader.ReadLine()
                While line IsNot Nothing
                    If line.Trim <> "" Then 模组项排序.Add(line)
                    line = reader.ReadLine()
                End While
            End Using
        End If

        Dim 排序索引总数 As Integer = 模组项排序.Count - 1
        Dim 排序索引实时 As Integer = 0
        Do Until 排序索引实时 = 排序索引总数 + 1
            If 模组项文件夹列表.Contains(模组项排序(排序索引实时)) Then
                Form1.ListView2.Items.Add(模组项排序(排序索引实时))
                实时模组项排序.Add(模组项排序(排序索引实时))
                模组项文件夹列表.Remove(模组项排序(排序索引实时))
                排序索引实时 += 1
            Else
                模组项排序.Remove(模组项排序(排序索引实时))
                实时模组项排序是否经过修改 = True
                排序索引总数 -= 1
            End If
        Loop

        If 模组项文件夹列表.Count > 0 Then
            For i = 0 To 模组项文件夹列表.Count - 1
                Form1.ListView2.Items.Add(模组项文件夹列表(i))
                实时模组项排序.Add(模组项文件夹列表(i))
            Next
            实时模组项排序是否经过修改 = True
        End If

        For i = 0 To Form1.ListView2.Items.Count - 1
            Dim 正在计算信息的模组项路径 As String = Path.Combine(设置.全局设置数据("LocalRepositoryPath"), 设置.全局设置数据("LastUsedSubLibraryName"), Form1.ListView1.Items(Form1.ListView1.SelectedIndices(0)).Text, Form1.ListView2.Items(i).Text)
            Dim a As New 项信息读取类
            Dim ct As New 公共对象.项数据计算类型结构 With {.安装状态 = True, .版本 = True, .已安装版本 = True}
            If Not FileIO.FileSystem.FileExists(Path.Combine(正在计算信息的模组项路径, "Code2")) Then
                If FileIO.FileSystem.FileExists(Path.Combine(正在计算信息的模组项路径, "Code")) Then
                    FileIO.FileSystem.WriteAllText(Path.Combine(正在计算信息的模组项路径, "Code2"), 命令规划转换.将安装命令转换到安装规划(FileIO.FileSystem.ReadAllText(Path.Combine(正在计算信息的模组项路径, "Code"))), False)
                End If
            End If
            a.读取项信息(正在计算信息的模组项路径, ct, 设置.全局设置数据("StardewValleyGamePath"))
            If a.错误信息 = "" Then
                Form1.ListView2.Items(i).SubItems.Add("")
                Form1.ListView2.Items(i).SubItems.Add("")
                Form1.ListView2.Items(i).SubItems.Add(Form1.ListView1.Items(Form1.ListView1.SelectedIndices(0)).Text)
                If a.版本.Count > 0 And a.已安装版本.Count > 0 Then
                    If a.版本(0) <> a.已安装版本(0) Then
                        If a.安装状态 = 公共对象.安装状态枚举.安装不完整 Then
                            Form1.ListView2.Items.Item(i).SubItems(1).Text = a.版本(0)
                            GoTo 结束版本号高低判断
                        End If
                        Select Case 共享方法.CompareVersion(a.版本(0), a.已安装版本(0))
                            Case = 0
                                Form1.ListView2.Items(i).SubItems(1).Text = a.版本(0)
                            Case > 0
                                Form1.ListView2.Items(i).SubItems(1).Text = a.版本(0) & " ← " & a.已安装版本(0)
                                Form1.ListView2.Items(i).SubItems(2).Text = "更新可用"
                            Case < 0
                                Form1.ListView2.Items(i).SubItems(1).Text = a.版本(0) & " → " & a.已安装版本(0)
                                Form1.ListView2.Items(i).SubItems(2).Text = "已有新的"
                        End Select
结束版本号高低判断:
                    Else
                        Form1.ListView2.Items(i).SubItems(1).Text = a.版本(0)
                    End If

                Else
                    If a.版本.Count > 0 Then
                        Form1.ListView2.Items(i).SubItems(1).Text = a.版本(0)
                    ElseIf FileIO.FileSystem.FileExists(Path.Combine(正在计算信息的模组项路径, "Version")) = True Then
                        Form1.ListView2.Items(i).SubItems(1).Text = FileIO.FileSystem.ReadAllText(Path.Combine(正在计算信息的模组项路径, "Version"))
                    Else
                        Form1.ListView2.Items(i).SubItems(1).Text = "未知版本"
                    End If
                    Form1.ListView2.Items(i).ForeColor = Color1.白色
                End If


            Else
                Form1.ListView2.Items(i).SubItems.Add("核心错误")
                Form1.ListView2.Items(i).SubItems.Add(a.错误信息)
                Form1.ListView2.Items(i).SubItems.Add(Form1.ListView1.Items(Form1.ListView1.SelectedIndices(0)).Text)
                Form1.ListView2.Items(i).ForeColor = Color1.红色
                DebugPrint(a.错误信息, Color1.红色)
            End If

            Select Case Form1.ListView2.Items(i).SubItems(2).Text
                Case ""
                    Form1.ListView2.Items(i).SubItems(2).Text = 安装状态显示词字典(a.安装状态)
            End Select

            根据安装状态设置项的颜色标记(a.安装状态, Form1.ListView2.Items(i), True)

            Dim 模组项字体文件路径 As String = Path.Combine(正在计算信息的模组项路径, "Font")
            If FileIO.FileSystem.FileExists(模组项字体文件路径) Then
                Select Case FileIO.FileSystem.ReadAllText(模组项字体文件路径)
                    Case "BD"
                        Form1.ListView2.Items(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Bold)
                    Case "LC"
                        Form1.ListView2.Items(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Italic)
                    Case "UL"
                        Form1.ListView2.Items(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Underline)
                    Case "SO"
                        Form1.ListView2.Items(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Strikeout)
                End Select
            End If
        Next
        Form1.Label51.Text = Form1.ListView2.Items.Count
        实时模组项列表内容归属的分类 = Form1.ListView1.Items(Form1.ListView1.SelectedIndices(0)).Text

    End Sub

    Public Shared Property 安装状态显示词字典 As New Dictionary(Of 公共对象.安装状态枚举, String)
    Public Shared Sub 初始化安装状态显示词字典()
        安装状态显示词字典(公共对象.安装状态枚举.未知) = "未知"
        安装状态显示词字典(公共对象.安装状态枚举.未配置) = "未配置"
        安装状态显示词字典(公共对象.安装状态枚举.已安装) = "已安装"
        安装状态显示词字典(公共对象.安装状态枚举.未安装) = "未安装"
        安装状态显示词字典(公共对象.安装状态枚举.安装不完整) = "安装不完整"
        安装状态显示词字典(公共对象.安装状态枚举.文件夹已复制) = "文件夹已复制"
        安装状态显示词字典(公共对象.安装状态枚举.文件夹未复制) = "文件夹未复制"
        安装状态显示词字典(公共对象.安装状态枚举.文件夹部分复制) = "文件夹部分复制"
        安装状态显示词字典(公共对象.安装状态枚举.附加内容) = "附加内容"
        安装状态显示词字典(公共对象.安装状态枚举.文件已替换) = "文件已替换"
        安装状态显示词字典(公共对象.安装状态枚举.文件未替换) = "文件未替换"
        安装状态显示词字典(公共对象.安装状态枚举.文件部分替换) = "文件部分替换"
        安装状态显示词字典(公共对象.安装状态枚举.文件已复制) = "文件已复制"
        安装状态显示词字典(公共对象.安装状态枚举.文件未复制) = "文件未复制"
        安装状态显示词字典(公共对象.安装状态枚举.文件部分复制) = "文件部分复制"
        安装状态显示词字典(公共对象.安装状态枚举.文件已复制并验证) = "文件已复制并验证"
        安装状态显示词字典(公共对象.安装状态枚举.文件已复制但验证失败) = "文件已复制但验证失败"
        安装状态显示词字典(公共对象.安装状态枚举.源文件夹丢失) = "源文件夹丢失"
        安装状态显示词字典(公共对象.安装状态枚举.源文件丢失) = "源文件丢失"
        安装状态显示词字典(公共对象.安装状态枚举.不带判断的文件复制) = "无判断的文件复制"
        安装状态显示词字典(公共对象.安装状态枚举.覆盖Content文件夹) = "覆盖 Content"
    End Sub

    Public Shared Sub 根据安装状态设置项的颜色标记(安装状态 As 公共对象.安装状态枚举, 哪个项 As ListViewItem, Optional 跳过未安装的处理 As Boolean = False)
        Select Case 安装状态
            Case 公共对象.安装状态枚举.未安装
                If 跳过未安装的处理 = True Then Exit Sub
                哪个项.ForeColor = Color1.白色
            Case 公共对象.安装状态枚举.已安装
                哪个项.ForeColor = Color1.绿色
            Case 公共对象.安装状态枚举.安装不完整, 公共对象.安装状态枚举.文件已复制但验证失败
                哪个项.ForeColor = Color1.青色
            Case 公共对象.安装状态枚举.文件夹已复制, 公共对象.安装状态枚举.文件已复制, 公共对象.安装状态枚举.附加内容, 公共对象.安装状态枚举.覆盖Content文件夹, 公共对象.安装状态枚举.文件已复制并验证
                哪个项.ForeColor = Color1.紫色
            Case 公共对象.安装状态枚举.不带判断的文件复制, 公共对象.安装状态枚举.文件已复制但验证失败
                哪个项.ForeColor = Color1.蓝色
            Case 公共对象.安装状态枚举.未配置, 公共对象.安装状态枚举.未知
                哪个项.ForeColor = Color1.红色
        End Select
    End Sub

    Public Shared Sub 保存模组项排序()
        If 实时模组项排序是否经过修改 = False Then Exit Sub
        If 实时模组项列表内容归属的分类 = "" Then Exit Sub
        Dim 模组项排序储存文件路径 As String = Path.Combine(设置.全局设置数据("LocalRepositoryPath"), 设置.全局设置数据("LastUsedSubLibraryName"), 实时模组项列表内容归属的分类, "SORT")
        If Not FileIO.FileSystem.DirectoryExists(IO.Path.GetDirectoryName(模组项排序储存文件路径)) Then Exit Sub
        Dim a As String = ""
        For i = 0 To 实时模组项排序.Count - 1
            If a = "" Then
                a = 实时模组项排序(i)
            Else
                a &= vbCrLf & 实时模组项排序(i)
            End If
        Next
        FileIO.FileSystem.WriteAllText(模组项排序储存文件路径, a, False)
    End Sub

    Public Shared Sub 模组项列表键盘按下事件(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F3
                上移选中的模组项()
            Case Keys.F4
                下移选中的模组项()
        End Select
    End Sub

    Public Shared Sub 上移选中的模组项()
        If Form1.ListView2.SelectedIndices.Count > 0 Then
            For i = 0 To Form1.ListView2.SelectedIndices.Count - 1
                Dim index As Integer = Form1.ListView2.SelectedIndices(i)
                If index > 0 Then
                    If Form1.ListView2.SelectedIndices.Contains(index - 1) Then Continue For
                    Dim 变动排序的列表视图项 As ListViewItem = Form1.ListView2.Items(index)
                    Dim 变动排序的文本 As String = 实时模组项排序(index)
                    Form1.ListView2.Items.RemoveAt(index)
                    Form1.ListView2.Items.Insert(index - 1, 变动排序的列表视图项)
                    Form1.ListView2.Items(index - 1).Focused = True
                    实时模组项排序.RemoveAt(index)
                    实时模组项排序.Insert(index - 1, 变动排序的文本)
                    实时模组项排序是否经过修改 = True
                End If
            Next
        End If
    End Sub

    Public Shared Sub 下移选中的模组项()
        If Form1.ListView2.SelectedIndices.Count > 0 Then
            For i = Form1.ListView2.SelectedIndices.Count - 1 To 0 Step -1
                Dim index As Integer = Form1.ListView2.SelectedIndices(i)
                If index < Form1.ListView2.Items.Count - 1 Then
                    If Form1.ListView2.SelectedIndices.Contains(index + 1) Then Continue For
                    Dim 变动排序的列表视图项 As ListViewItem = Form1.ListView2.Items(index)
                    Dim 变动排序的文本 As String = 实时模组项排序(index)
                    Form1.ListView2.Items.RemoveAt(index)
                    Form1.ListView2.Items.Insert(index + 1, 变动排序的列表视图项)
                    Form1.ListView2.Items(index + 1).Focused = True
                    实时模组项排序.RemoveAt(index)
                    实时模组项排序.Insert(index + 1, 变动排序的文本)
                    实时模组项排序是否经过修改 = True
                End If
            Next
        End If
    End Sub

    Public Shared Property 当前项信息_N网ID列表 As New List(Of String)
    Public Shared Property 当前项信息_呵呵鱼ID列表 As New List(Of String)
    Public Shared Property 当前项信息_Github仓库列表 As New List(Of String)
    Public Shared Property 当前项信息_ModDropID列表 As New List(Of String)
    Public Shared Property 当前项信息_内容包列表 As New Dictionary(Of String, 内容包依赖类型单片结构)
    Public Shared Property 当前项信息_依赖项列表 As New Dictionary(Of String, 其他依赖项类型单片结构)
    Public Shared Property 当前项信息_UniqueID列表 As New List(Of String)
    Public Shared Property 当前项信息_作者列表 As New List(Of String)
    Public Shared Property 当前项信息_预览图文件表 As New List(Of String)
    Public Shared Property 当前正在显示的预览图索引 As Integer = 0

    Public Shared Sub 重置模组项信息显示()
        Form1.UiButton11.Text = "TYPE"
        Form1.UiRichTextBox1.Clear()
        Form1.Panel8.Visible = False
        Form1.Label1.Text = ""
        Form1.Label2.Text = ""
        Form1.UiButton12.Text = 0
        Form1.Panel9.Visible = False
        Form1.UiButton6.Text = "   更新键"
        Form1.UiButton7.Text = "   依赖项表"
        Form1.UiButton8.Text = "   UniqueID 表"
        Form1.UiButton9.Text = "   作者表"
        If Form依赖项表.Visible = True Then
            Form依赖项表.Text = "依赖项表"
            Form依赖项表.ListView1.Items.Clear()
        End If
    End Sub

    Public Shared Sub 读取项信息并显示()
        If Form1.ListView2.SelectedItems.Count <> 1 Then
            重置模组项信息显示()
            Exit Sub
        End If
        Dim 项路径 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.Items(Form1.ListView2.SelectedIndices(0)).SubItems(3).Text, Form1.ListView2.Items(Form1.ListView2.SelectedIndices(0)).Text)
        Dim a As New 项信息读取类
        a.读取项信息(项路径, New 公共对象.项数据计算类型结构 With {.全部 = True}, 设置.全局设置数据("StardewValleyGamePath"))
        If a.错误信息 <> "" Then
            UIMessageTip.Show(a.错误信息,, 2500)
            Exit Sub
        End If
        If FileIO.FileSystem.FileExists(项路径 & "\README.rtf") = True Then
            Form1.UiRichTextBox1.LoadFile(项路径 & "\README.rtf")
            Form1.UiButton11.Text = "RTF"
        ElseIf My.Computer.FileSystem.FileExists(项路径 & "\README") = True Then
            Form1.UiRichTextBox1.Text = My.Computer.FileSystem.ReadAllText(项路径 & "\README")
            Form1.UiButton11.Text = "TXT"
        ElseIf a.描述.Count > 0 Then
            For i = 0 To a.描述.Count - 1
                If i = 0 Then
                    Form1.UiRichTextBox1.Text = a.描述(0)
                Else
                    Form1.UiRichTextBox1.Text &= vbCrLf & vbCrLf & a.描述(i)
                End If
            Next
            Form1.UiButton11.Text = "JSON"
        Else
            Form1.UiButton11.Text = "None"
        End If
        当前项信息_N网ID列表 = a.NexusID
        当前项信息_呵呵鱼ID列表 = a.ChuckleFishID
        当前项信息_Github仓库列表 = a.GitHub
        当前项信息_ModDropID列表 = a.ModDrop
        If a.NexusID.Count > 0 And a.ModDrop.Count > 0 Then
            Form1.UiButton6.Text = " NEXUS: " & a.NexusID(0) & "  ModDrop"
        ElseIf a.NexusID.Count > 0 Then
            Form1.UiButton6.Text = " NEXUS: " & a.NexusID(0)
        ElseIf a.ModDrop.Count > 0 Then
            Form1.UiButton6.Text = " ModDrop: " & a.ModDrop(0)
        ElseIf a.GitHub.Count > 0 Then
            Form1.UiButton6.Text = " GitHub"
        Else
            Form1.UiButton6.Text = " No Update Keys"
        End If
        当前项信息_内容包列表 = a.内容包依赖
        当前项信息_依赖项列表 = a.其他依赖项
        If a.内容包依赖.Count + a.其他依赖项.Count > 0 Then
            Form1.UiButton7.Text = " Requirements: C" & a.内容包依赖.Count & " + R" & a.其他依赖项.Count
        Else
            Form1.UiButton7.Text = " No Requirements"
        End If
        当前项信息_UniqueID列表 = a.UniqueID
        Select Case a.UniqueID.Count
            Case > 1
                Form1.UiButton8.Text = " [" & a.UniqueID.Count & "] UniqueID: " & a.UniqueID(0)
            Case 1
                Form1.UiButton8.Text = " UniqueID: " & a.UniqueID(0)
            Case 0
                Form1.UiButton8.Text = " No UniqueID"
        End Select
        当前项信息_作者列表 = a.作者
        Select Case a.作者.Count
            Case > 1
                Form1.UiButton9.Text = 在指定的宽度内显示文本(Form1.UiButton9.Width, " [" & a.作者.Count & "] " & a.作者(0), Form1.UiButton9.Font)
            Case 1
                Form1.UiButton9.Text = 在指定的宽度内显示文本(Form1.UiButton9.Width, " Author: " & a.作者(0), Form1.UiButton9.Font)
            Case 0
                Form1.UiButton9.Text = " No Author"
        End Select
        If a.版本.Count > 0 And a.已安装版本.Count > 0 Then
            If 共享方法.CompareVersion(a.版本(0), a.已安装版本(0)) <> 0 Then
                Form1.Label1.Text = a.版本(0)
                Form1.Label2.Text = a.已安装版本(0)
                Form1.Panel8.Visible = True
            End If
        End If
        If My.Computer.FileSystem.DirectoryExists(项路径 & "\Screenshot") = True Then
            当前项信息_预览图文件表.Clear()
            当前正在显示的预览图索引 = Nothing
            Dim 文件 As System.IO.FileInfo
            Dim 目录 As New System.IO.DirectoryInfo(项路径 & "\Screenshot")
            For Each 文件 In 目录.GetFiles("*.*")
                当前项信息_预览图文件表.Add(文件.FullName)
            Next
            If 当前项信息_预览图文件表.Count > 0 Then
                加载预览图(当前项信息_预览图文件表(0))
                当前正在显示的预览图索引 = 0
                Form1.UiButton12.Text = 当前项信息_预览图文件表.Count
            End If
        End If
        If Form依赖项表.Visible = True Then Form依赖项表.刷新前置表项()


    End Sub

    Public Shared Sub 项列表计数显示()
        If Form1.ListView2.Items.Count = 0 Then
            Form1.Label51.Text = "0 "
            Exit Sub
        End If
        If Form1.ListView2.SelectedItems.Count > 1 Then
            Form1.Label51.Text = Form1.ListView2.SelectedItems.Count & "/" & Form1.ListView2.Items.Count & " "
        Else
            Form1.Label51.Text = Form1.ListView2.Items.Count & " "
        End If
    End Sub

    Public Shared Function 在指定的宽度内显示文本(最大宽度 As Integer, 你的文本 As String, 使用的字体 As Font) As String
        Dim textSize As Size = TextRenderer.MeasureText(你的文本, 使用的字体)
        If textSize.Width > 最大宽度 Then
            Dim ellipsisWidth As Integer = TextRenderer.MeasureText("...", 使用的字体).Width
            Dim availableWidth As Integer = 最大宽度 - ellipsisWidth
            Dim truncatedText As String = 你的文本
            While TextRenderer.MeasureText(truncatedText, 使用的字体).Width > availableWidth AndAlso truncatedText.Length > 0
                truncatedText = truncatedText.Substring(0, truncatedText.Length - 1)
            End While
            truncatedText &= "..."
            Return truncatedText
        Else
            Return 你的文本
        End If
    End Function


    Public Shared Sub 加载预览图(文件 As String)
        Select Case IO.Path.GetExtension(文件).ToLower
            Case ".jpg", ".jpeg", ".png", ".bmp"
                Using fs As New IO.FileStream(文件, IO.FileMode.Open, IO.FileAccess.Read)
                    Form1.Panel9.Visible = True
                    Form1.PictureBox1.Image = Image.FromStream(fs)
                    fs.Close()
                End Using
            Case ".gif"
                Using img As Image = Image.FromFile(文件)
                    Dim mstr As New IO.MemoryStream()
                    img.Save(mstr, Imaging.ImageFormat.Gif)
                    Form1.Panel9.Visible = True
                    Form1.PictureBox1.Image = Image.FromStream(mstr)
                    img.Dispose()
                End Using
            Case ".webp"
                'Imazen.WebP.Extern.LoadLibrary.LoadByPath(Application.StartupPath & "\libwebp.dll", False)
                Try
                    Dim bytes As Byte() = IO.File.ReadAllBytes(文件)
                    Using img As Bitmap = New Imazen.WebP.SimpleDecoder().DecodeFromBytes(bytes, bytes.Length)
                        Dim s As Integer = img.GetFrameCount(FrameDimension.Page)
                        Dim mstr As New IO.MemoryStream()
                        If s = 1 Then
                            img.Save(mstr, Imaging.ImageFormat.Png)
                            Dim newImagePath As String = IO.Path.GetDirectoryName(文件) & "\" & IO.Path.GetFileNameWithoutExtension(文件) & ".png"
                            Using fs As New FileStream(newImagePath, FileMode.Create)
                                mstr.WriteTo(fs)
                            End Using
                            If FileIO.FileSystem.FileExists(文件) = True Then FileIO.FileSystem.DeleteFile(文件)
                            当前项信息_预览图文件表(当前正在显示的预览图索引) = newImagePath
                        ElseIf s > 1 Then
                            img.Save(mstr, Imaging.ImageFormat.Gif)
                            Dim newImagePath As String = IO.Path.GetDirectoryName(文件) & "\" & IO.Path.GetFileNameWithoutExtension(文件) & ".gif"
                            Using fs As New FileStream(newImagePath, FileMode.Create)
                                mstr.WriteTo(fs)
                            End Using
                            If FileIO.FileSystem.FileExists(文件) = True Then FileIO.FileSystem.DeleteFile(文件)
                            当前项信息_预览图文件表(当前正在显示的预览图索引) = newImagePath
                        Else
                            Exit Try
                        End If
                        Form1.Panel9.Visible = True
                        Form1.PictureBox1.Image = Image.FromStream(mstr)
                        Application.DoEvents()
                        mstr.Dispose()
                    End Using
                Catch ex As Exception
                    Form1.Panel9.Visible = False
                    Form1.PictureBox1.Image = Nothing
                End Try
        End Select
        Form1.ToolTip1.SetToolTip(Form1.PictureBox1, 当前正在显示的预览图索引 + 1 & "/" & 当前项信息_预览图文件表.Count)
    End Sub

    Public Shared Sub 打开分类文件夹()
        If Form1.ListView1.SelectedItems.Count = 1 Then
            Dim 路径 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView1.SelectedItems(0).Text)
            Process.Start("explorer.exe", 路径)
        End If
    End Sub

    Public Shared Sub 打开模组项文件夹()
        If Form1.ListView2.SelectedItems.Count = 1 Then
            Dim 路径 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text).Replace("\\", "\")
            Process.Start("explorer.exe", 路径)
        End If
    End Sub



End Class
