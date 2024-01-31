Imports System.IO

Public Class 管理模组

    Public Shared Property 实时分类排序 As New List(Of String)
    Public Shared Property 实时分类排序是否经过修改 As Boolean = False
    Public Shared Property 实时模组项排序 As New List(Of String)
    Public Shared Property 实时模组项排序是否经过修改 As Boolean = False
    Public Shared Property 实时模组项列表内容归属的分类 As String = ""


    Public Shared Sub 初始化()
        AddHandler 管理模组的菜单.菜单项_刷新数据子库.Click, AddressOf 扫描数据子库
        AddHandler 管理模组的菜单.菜单项_刷新分类.Click, AddressOf 扫描分类
        AddHandler Form1.ListView1.KeyDown, Sub(sender, e) 分类列表键盘按下事件(sender, e)
        AddHandler Form1.ListView1.SelectedIndexChanged, Sub(sender, e) 扫描模组项()
        AddHandler Form1.UiButton3.Click, Sub(sender, e) 扫描模组项(True)
        AddHandler Form1.ListView2.KeyDown, Sub(sender, e) 模组项列表键盘按下事件(sender, e)

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
            Dim M1 As New 多项单选对话框("", {"OK"}, "模组数据库路径无效")
            M1.ShowDialog(Form1)
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

        For i = 0 To 分类排序.Count - 1
            If 分类文件夹列表.Contains(分类排序(i)) Then
                Form1.ListView1.Items.Add(分类排序(i))
                实时分类排序.Add(分类排序(i))
                分类文件夹列表.Remove(分类排序(i))
            Else
                分类排序.Remove(分类排序(i))
                i -= 1
                Continue For
            End If
        Next

        If 分类文件夹列表.Count > 0 Then
            For i = 0 To 分类文件夹列表.Count - 1
                Form1.ListView1.Items.Add(分类文件夹列表(i))
                实时分类排序.Add(分类文件夹列表(i))
            Next
            实时分类排序是否经过修改 = True
        End If

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

        For i = 0 To 模组项排序.Count - 1
            If 模组项文件夹列表.Contains(模组项排序(i)) Then
                Form1.ListView2.Items.Add(模组项排序(i))
                实时模组项排序.Add(模组项排序(i))
                模组项文件夹列表.Remove(模组项排序(i))
            Else
                模组项排序.Remove(模组项排序(i))
                i -= 1
                Continue For
            End If
        Next

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
                If Form1.ListView2.Items(i).SubItems.Count <= 4 Then
                    Form1.ListView2.Items(i).SubItems.Add("")
                    Form1.ListView2.Items(i).SubItems.Add("")
                    Form1.ListView2.Items(i).SubItems.Add(Form1.ListView1.Items(Form1.ListView1.SelectedIndices(0)).Text)
                End If
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
                Form1.ListView2.Items(i).ForeColor = Color.Red
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
                    Form1.ListView2.Items.RemoveAt(index)
                    Form1.ListView2.Items.Insert(index - 1, 变动排序的列表视图项)
                    Form1.ListView2.Items(index - 1).Focused = True
                    Dim 变动排序的文本 As String = 实时模组项排序(index)
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
                    Form1.ListView2.Items.RemoveAt(index)
                    Form1.ListView2.Items.Insert(index + 1, 变动排序的列表视图项)
                    Form1.ListView2.Items(index + 1).Focused = True
                    Dim 变动排序的文本 As String = 实时模组项排序(index)
                    实时模组项排序.RemoveAt(index)
                    实时模组项排序.Insert(index + 1, 变动排序的文本)
                    实时模组项排序是否经过修改 = True
                End If
            Next
        End If
    End Sub

    Public Shared Sub 重置模组项信息显示()

    End Sub

End Class
