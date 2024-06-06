Imports System.IO
Imports SMUI6.公共对象
Imports Sunny.UI

Public Class 配置队列

    Public Shared Property 保存规划代码字典 As New Dictionary(Of 任务队列操作类型枚举, String)
    Public Shared Sub 初始化保存规划代码字典()
        保存规划代码字典.Add(任务队列操作类型枚举.复制文件夹到Mods, "CD-D-MODS")
        保存规划代码字典.Add(任务队列操作类型枚举.覆盖文件夹到Mods, "CD-D-MODS-COVER")
        保存规划代码字典.Add(任务队列操作类型枚举.复制文件夹, "CD-D-ROOT")
        保存规划代码字典.Add(任务队列操作类型枚举.覆盖Content, "CD-D-CONTENT")
        保存规划代码字典.Add(任务队列操作类型枚举.新增文件, "CD-F-ADD")
        保存规划代码字典.Add(任务队列操作类型枚举.新增文件并验证, "CD-F-ADD-SHA")
        保存规划代码字典.Add(任务队列操作类型枚举.替换文件, "CD-F-REP")
        保存规划代码字典.Add(任务队列操作类型枚举.替换文件且无检测, "CD-F-NULL")
        保存规划代码字典.Add(任务队列操作类型枚举.安装时检查文件夹的存在, "CR-IN-D-CHECK")
        保存规划代码字典.Add(任务队列操作类型枚举.安装时检查文件的存在, "CR-IN-F-CHECK")
        保存规划代码字典.Add(任务队列操作类型枚举.安装时检查Mods中已安装模组的版本, "CR-IN-MODS-VER")
        保存规划代码字典.Add(任务队列操作类型枚举.安装时运行可执行文件, "CR-IN-SHELL")
        保存规划代码字典.Add(任务队列操作类型枚举.安装时弹窗, "CR-IN-MSGBOX")
        保存规划代码字典.Add(任务队列操作类型枚举.卸载时检查文件夹的存在, "CR-UN-D-CHECK")
        保存规划代码字典.Add(任务队列操作类型枚举.卸载时检查文件的存在, "CR-UN-F-CHECK")
        保存规划代码字典.Add(任务队列操作类型枚举.卸载时取消操作, "CR-UN")
        保存规划代码字典.Add(任务队列操作类型枚举.卸载时运行可执行文件, "CR-UN-SHELL")
        保存规划代码字典.Add(任务队列操作类型枚举.卸载时弹窗, "CR-UN-MSGBOX")
        保存规划代码字典.Add(任务队列操作类型枚举.声明各种核心功能的启停, "CORE-CLASS")
    End Sub

    Public Shared Property 识别规划操作字典 As New Dictionary(Of String, 任务队列操作类型枚举)()
    Public Shared Sub 初始化识别规划操作字典()
        识别规划操作字典.Add("CD-D-MODS", 任务队列操作类型枚举.复制文件夹到Mods)
        识别规划操作字典.Add("CD-D-MODS-COVER", 任务队列操作类型枚举.覆盖文件夹到Mods)
        识别规划操作字典.Add("CD-D-ROOT", 任务队列操作类型枚举.复制文件夹)
        识别规划操作字典.Add("CD-D-CONTENT", 任务队列操作类型枚举.覆盖Content)
        识别规划操作字典.Add("CD-F-ADD", 任务队列操作类型枚举.新增文件)
        识别规划操作字典.Add("CD-F-ADD-SHA", 任务队列操作类型枚举.新增文件并验证)
        识别规划操作字典.Add("CD-F-REP", 任务队列操作类型枚举.替换文件)
        识别规划操作字典.Add("CD-F-NULL", 任务队列操作类型枚举.替换文件且无检测)
        识别规划操作字典.Add("CR-IN-D-CHECK", 任务队列操作类型枚举.安装时检查文件夹的存在)
        识别规划操作字典.Add("CR-IN-F-CHECK", 任务队列操作类型枚举.安装时检查文件的存在)
        识别规划操作字典.Add("CR-IN-MODS-VER", 任务队列操作类型枚举.安装时检查Mods中已安装模组的版本)
        识别规划操作字典.Add("CR-IN-SHELL", 任务队列操作类型枚举.安装时运行可执行文件)
        识别规划操作字典.Add("CR-IN-MSGBOX", 任务队列操作类型枚举.安装时弹窗)
        识别规划操作字典.Add("CR-UN-D-CHECK", 任务队列操作类型枚举.卸载时检查文件夹的存在)
        识别规划操作字典.Add("CR-UN-F-CHECK", 任务队列操作类型枚举.卸载时检查文件的存在)
        识别规划操作字典.Add("CR-UN", 任务队列操作类型枚举.卸载时取消操作)
        识别规划操作字典.Add("CR-UN-SHELL", 任务队列操作类型枚举.卸载时运行可执行文件)
        识别规划操作字典.Add("CR-UN-MSGBOX", 任务队列操作类型枚举.卸载时弹窗)
        识别规划操作字典.Add("CORE-CLASS", 任务队列操作类型枚举.声明各种核心功能的启停)
    End Sub

    Public Shared Property 编辑规划操作字典 As New Dictionary(Of 任务队列操作类型枚举, DE1)
    Delegate Sub DE1()
    Public Shared Sub 初始化编辑规划操作字典()
        编辑规划操作字典.Add(任务队列操作类型枚举.复制文件夹到Mods, AddressOf 配置队列的规划编辑.匹配到_复制文件夹到Mods)
        编辑规划操作字典.Add(任务队列操作类型枚举.覆盖文件夹到Mods, AddressOf 配置队列的规划编辑.匹配到_覆盖文件夹到Mods)
        编辑规划操作字典.Add(任务队列操作类型枚举.复制文件夹, AddressOf 配置队列的规划编辑.匹配到_复制文件夹)
        编辑规划操作字典.Add(任务队列操作类型枚举.覆盖Content, AddressOf 配置队列的规划编辑.匹配到_覆盖Content)
        编辑规划操作字典.Add(任务队列操作类型枚举.新增文件, AddressOf 配置队列的规划编辑.匹配到_新增文件)
        编辑规划操作字典.Add(任务队列操作类型枚举.新增文件并验证, AddressOf 配置队列的规划编辑.匹配到_新增文件并验证)
        编辑规划操作字典.Add(任务队列操作类型枚举.替换文件, AddressOf 配置队列的规划编辑.匹配到_替换文件)
        编辑规划操作字典.Add(任务队列操作类型枚举.替换文件且无检测, AddressOf 配置队列的规划编辑.匹配到_替换文件且无检测)
        编辑规划操作字典.Add(任务队列操作类型枚举.安装时检查文件夹的存在, AddressOf 配置队列的规划编辑.匹配到_安装时检查文件夹的存在)
        编辑规划操作字典.Add(任务队列操作类型枚举.卸载时检查文件夹的存在, AddressOf 配置队列的规划编辑.匹配到_卸载时检查文件夹的存在)
        编辑规划操作字典.Add(任务队列操作类型枚举.安装时检查文件的存在, AddressOf 配置队列的规划编辑.匹配到_安装时检查文件的存在)
        编辑规划操作字典.Add(任务队列操作类型枚举.卸载时检查文件的存在, AddressOf 配置队列的规划编辑.匹配到_卸载时检查文件的存在)


        编辑规划操作字典.Add(任务队列操作类型枚举.卸载时取消操作, AddressOf 配置队列的规划编辑.匹配到_卸载时取消操作)


        编辑规划操作字典.Add(任务队列操作类型枚举.声明各种核心功能的启停, AddressOf 配置队列的规划编辑.匹配到_声明各种核心功能的启停)
    End Sub

    Public Shared Property 规划显示名称字典 As New Dictionary(Of 任务队列操作类型枚举, String)
    Public Shared Sub 初始化规划显示名称字典()
        规划显示名称字典.Add(任务队列操作类型枚举.复制文件夹到Mods, "安装标准 SMAPI 模组")
        规划显示名称字典.Add(任务队列操作类型枚举.覆盖文件夹到Mods, "覆盖 Mods 中的文件夹")
        规划显示名称字典.Add(任务队列操作类型枚举.复制文件夹, "复制文件夹")
        规划显示名称字典.Add(任务队列操作类型枚举.覆盖Content, "覆盖 Content 文件夹")
        规划显示名称字典.Add(任务队列操作类型枚举.新增文件, "新增文件")
        规划显示名称字典.Add(任务队列操作类型枚举.新增文件并验证, "新增文件并验证")
        规划显示名称字典.Add(任务队列操作类型枚举.替换文件, "替换文件")
        规划显示名称字典.Add(任务队列操作类型枚举.替换文件且无检测, "替换文件且无检测")
        规划显示名称字典.Add(任务队列操作类型枚举.安装时检查文件夹的存在, "安装时检查文件夹")
        规划显示名称字典.Add(任务队列操作类型枚举.安装时检查文件的存在, "安装时检查文件")
        规划显示名称字典.Add(任务队列操作类型枚举.安装时检查Mods中已安装模组的版本, "安装时检查模组版本")
        规划显示名称字典.Add(任务队列操作类型枚举.安装时运行可执行文件, "安装时运行程序")
        规划显示名称字典.Add(任务队列操作类型枚举.安装时弹窗, "安装时弹窗")
        规划显示名称字典.Add(任务队列操作类型枚举.卸载时检查文件夹的存在, "卸载时检查文件夹")
        规划显示名称字典.Add(任务队列操作类型枚举.卸载时检查文件的存在, "卸载时检查文件")
        规划显示名称字典.Add(任务队列操作类型枚举.卸载时取消操作, "卸载时取消")
        规划显示名称字典.Add(任务队列操作类型枚举.卸载时运行可执行文件, "卸载时运行程序")
        规划显示名称字典.Add(任务队列操作类型枚举.卸载时弹窗, "卸载时弹窗")
        规划显示名称字典.Add(任务队列操作类型枚举.声明各种核心功能的启停, "声明核心功能启停")
    End Sub

    Public Shared Sub 初始化()
        初始化保存规划代码字典()
        初始化识别规划操作字典()
        初始化编辑规划操作字典()
        初始化规划显示名称字典()
        AddHandler Form1.UiButton19.Click, AddressOf 移除全部
        AddHandler Form1.UiButton16.Click, AddressOf 移除选中
        AddHandler Form1.UiButton17.Click, AddressOf 保存改动并移除
        AddHandler Form1.UiButton15.Click, AddressOf 仅保存
        AddHandler Form1.UiButton23.Click, AddressOf 重新扫描项的数据内容
        AddHandler Form1.UiButton18.Click, AddressOf 添加文件
        AddHandler Form1.UiButton21.Click, AddressOf 添加文件夹
        AddHandler Form1.UiButton24.Click, AddressOf 自动完成

        AddHandler 管理模组的菜单.菜单项_配置项.Click, AddressOf 添加到配置队列
        AddHandler Form1.ListView3.SelectedIndexChanged,
            Sub()
                If Form1.ListView3.SelectedItems.Count <> 1 Then
                    重置配置队列()
                Else
                    读取选中项()
                End If
            End Sub
        AddHandler Form1.ListView6.KeyDown, Sub(sender, e) 内容列表键盘按下事件(sender, e)
        AddHandler Form1.ListView6.DragEnter, Sub(sender, e) 内容列表视图DragEnter(sender, e)
        AddHandler Form1.ListView6.DragDrop, Sub(sender, e) 内容列表视图DragDrop(sender, e)
        AddHandler Form1.ListView7.DoubleClick, AddressOf 编辑选中的规划
        AddHandler Form1.ListView7.KeyDown, Sub(sender, e) 规划列表键盘按下事件(sender, e)

    End Sub

    Public Shared Property 正在编辑规划的项路径 As String
    Public Shared Property 当前项的规划操作列表 As New List(Of 任务队列操作类型枚举)
    Public Shared Property 安装规划检查器 As New Timer With {.Interval = 1000, .Enabled = False}

    Public Shared Sub 重置配置队列()
        安装规划检查器.Enabled = False
        Form1.UiTextBox6.Text = ""
        Form1.UiTextBox1.Text = ""
        Form1.ListView6.Items.Clear()
        Form1.ListView7.Items.Clear()
        'Form1.ListView8.Items.Clear()
        当前项的规划操作列表.Clear()
    End Sub

    Public Shared Sub 添加到配置队列()
        Dim 是否要转到配置队列 As Boolean = Form1.ListView3.Items.Count = 0
        For i = 0 To Form1.ListView2.SelectedItems.Count - 1
            For i2 = 0 To Form1.ListView3.Items.Count - 1
                If Form1.ListView2.SelectedItems(i).Text = Form1.ListView3.Items(i2).Text And Form1.ListView2.SelectedItems(i).SubItems(3).Text = Form1.ListView3.Items(i2).SubItems(1).Text Then
                    GoTo jx1
                End If
            Next
            Form1.ListView3.Items.Add(Form1.ListView2.SelectedItems(i).Text)
            Form1.ListView3.Items(Form1.ListView3.Items.Count - 1).SubItems.Add(Form1.ListView2.SelectedItems(i).SubItems(3).Text)
jx1:
        Next
        If 是否要转到配置队列 = True Then
            Form1.UiTabControl1.SelectedTab = Form1.TabPage配置队列
            Form1.ListView3.Items(0).Selected = True
        End If
    End Sub

    Public Shared Sub 添加到配置队列(分类 As String, 模组项 As String)
        Dim 是否要转到配置队列 As Boolean = Form1.ListView3.Items.Count = 0
        For i2 = 0 To Form1.ListView3.Items.Count - 1
            If 模组项 = Form1.ListView3.Items(i2).Text And 分类 = Form1.ListView3.Items(i2).SubItems(1).Text Then
                Exit Sub
            End If
        Next
        Form1.ListView3.Items.Add(模组项)
        Form1.ListView3.Items(Form1.ListView3.Items.Count - 1).SubItems.Add(分类)

        If 是否要转到配置队列 = True Then
            Form1.UiTabControl1.SelectedTab = Form1.TabPage配置队列
            Form1.ListView3.Items(0).Selected = True
        End If
    End Sub

    Public Shared Sub 读取选中项()
        正在编辑规划的项路径 = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView3.SelectedItems(0).SubItems(1).Text, Form1.ListView3.SelectedItems(0).Text)
        重新扫描项的数据内容()
        Form1.UiTextBox6.Text = Form1.ListView3.SelectedItems(0).Text
        If FileIO.FileSystem.FileExists(Path.Combine(正在编辑规划的项路径, "Version")) Then
            Form1.UiTextBox1.Text = FileIO.FileSystem.ReadAllText(Path.Combine(正在编辑规划的项路径, "Version"))
        Else
            Form1.UiTextBox1.Text = ""
        End If
        If FileIO.FileSystem.FileExists(Path.Combine(正在编辑规划的项路径, "Code2")) Then
            Dim a As New List(Of KeyValuePair(Of String, String))
            键值对IO操作.读取键值对文件到列表(a, Path.Combine(正在编辑规划的项路径, "Code2"))
            For i = 0 To a.Count - 1
                当前项的规划操作列表.Add(识别规划操作字典(a(i).Key))
                Form1.ListView7.Items.Add(规划显示名称字典(当前项的规划操作列表(i)))
                Form1.ListView7.Items(Form1.ListView7.Items.Count - 1).SubItems.Add(a(i).Value)
            Next
        End If
    End Sub

    Public Shared Sub 编辑选中的规划()
        If Not FileIO.FileSystem.DirectoryExists(正在编辑规划的项路径) Then Exit Sub
        If Form1.ListView7.SelectedItems.Count <> 1 Then Exit Sub
        Dim value As DE1 = Nothing
        If 编辑规划操作字典.TryGetValue(当前项的规划操作列表(Form1.ListView7.SelectedIndices(0)), value) Then
            Dim operation As DE1 = value
            operation.Invoke()
        Else
            DebugPrint("意外故障，无法在字典中匹配到操作，这在理论上不可能发生，除非我还没做对应的规划编辑", Color1.红色, True)
        End If
    End Sub

    Public Shared Sub 重新扫描项的数据内容()
        If Form1.ListView3.SelectedItems.Count <> 1 Then Exit Sub
        Form1.ListView6.Items.Clear()
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(正在编辑规划的项路径)
        For Each mDir In mDirInfo.GetDirectories
            Select Case mDir.Name
                Case "Screenshot", ".config", "_MACOSX"
                Case Else
                    If InStr(mDir.Name, ".") = 1 Then Continue For
                    Form1.ListView6.Items.Add(mDir.Name)
                    Form1.ListView6.Items.Item(Form1.ListView6.Items.Count - 1).SubItems.Add("文件夹")
                    If FileIO.FileSystem.FileExists(Path.Combine(mDir.FullName, "manifest.json")) = True Then
                        Form1.ListView6.Items.Item(Form1.ListView6.Items.Count - 1).ForeColor = Color1.绿色
                    ElseIf mDir.Name = "assets" Then
                        Form1.ListView6.Items.Item(Form1.ListView6.Items.Count - 1).ForeColor = Color1.红色
                    ElseIf mDir.Name = "Content" Then
                        Form1.ListView6.Items.Item(Form1.ListView6.Items.Count - 1).ForeColor = Color1.紫色
                    Else
                        Form1.ListView6.Items.Item(Form1.ListView6.Items.Count - 1).ForeColor = Color1.白色
                    End If
            End Select
        Next

        Dim 文件 As System.IO.FileInfo
        Dim 目录 As New System.IO.DirectoryInfo(正在编辑规划的项路径)
        For Each 文件 In 目录.GetFiles("*.*")
            Select Case 文件.Name
                Case "README", "Version", "Code", "Code2", "README.rtf", "Font", "NexusFileName"
                Case Else
                    Form1.ListView6.Items.Add(文件.Name)
                    Form1.ListView6.Items.Item(Form1.ListView6.Items.Count - 1).SubItems.Add("文件")
                    Select Case 文件.Name
                        Case "manifest.json", "content.json", "config.json"
                            Form1.ListView6.Items.Item(Form1.ListView6.Items.Count - 1).ForeColor = Color1.红色
                            Continue For
                    End Select
                    Select Case 文件.Extension.ToLower
                        Case ".zip", ".rar", ".7z"
                            Form1.ListView6.Items.Item(Form1.ListView6.Items.Count - 1).ForeColor = Color1.青色
                            Continue For
                    End Select
                    Form1.ListView6.Items.Item(Form1.ListView6.Items.Count - 1).ForeColor = Color1.紫色
            End Select
        Next
    End Sub

    Public Shared Sub 移除选中()
        Dim i As Integer = 0
        Do Until i = Form1.ListView3.Items.Count
            If Form1.ListView3.Items(i).Selected = True Then
                Form1.ListView3.Items(i).Remove()
                i -= 1
            End If
            i += 1
        Loop
        重置配置队列()
        If Form1.ListView3.Items.Count = 0 Then Form1.UiTabControl1.SelectedTab = Form1.TabPage管理模组
    End Sub

    Public Shared Sub 移除全部()
        重置配置队列()
        Form1.ListView3.Items.Clear()
        Form1.UiTabControl1.SelectedTab = Form1.TabPage管理模组
    End Sub

    Public Shared Sub 保存改动并移除()
        仅保存()
        重置配置队列()
        Form1.ListView3.SelectedItems(0).Remove()
        If Form1.ListView3.Items.Count = 0 Then Form1.UiTabControl1.SelectedTab = Form1.TabPage管理模组
    End Sub

    Public Shared Sub 仅保存()
        If Form1.ListView3.SelectedItems.Count <> 1 Then Exit Sub
        If 正在编辑规划的项路径 = "" Then Exit Sub
        If Not FileIO.FileSystem.DirectoryExists(正在编辑规划的项路径) Then
            UIMessageTip.Show($"{Path.GetFileName(正在编辑规划的项路径)} 此项已不存在，无法保存",, 2000)
        End If
        If Form1.ListView3.SelectedItems(0).Text <> Form1.UiTextBox6.Text Then
            FileIO.FileSystem.RenameDirectory(正在编辑规划的项路径, Form1.UiTextBox6.Text)
            正在编辑规划的项路径 = Path.Combine(Path.GetDirectoryName(正在编辑规划的项路径), Form1.UiTextBox6.Text)
        End If
        If Form1.UiTextBox1.Text = "" Then
            If FileIO.FileSystem.FileExists(Path.Combine(正在编辑规划的项路径, "Version")) Then
                FileIO.FileSystem.DeleteFile(Path.Combine(正在编辑规划的项路径, "Version"))
            End If
        Else
            FileIO.FileSystem.WriteAllText(Path.Combine(正在编辑规划的项路径, "Version"), Form1.UiTextBox1.Text, False)
        End If
        Dim code As New List(Of KeyValuePair(Of String, String))
        For i = 0 To Form1.ListView7.Items.Count - 1
            code.Add(New KeyValuePair(Of String, String)(保存规划代码字典(当前项的规划操作列表(i)), Form1.ListView7.Items(i).SubItems(1).Text))
        Next
        键值对IO操作.从列表键值对写入文件(code, Path.Combine(正在编辑规划的项路径, "Code2"))
        UIMessageTip.Show("已保存",, 1200)
    End Sub


    Public Shared Sub 内容列表键盘按下事件(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F3
                上移内容()
            Case Keys.F4
                下移内容()
        End Select
    End Sub

    Public Shared Sub 上移内容()
        If Form1.ListView6.SelectedIndices.Count > 0 Then
            For i = 0 To Form1.ListView6.SelectedIndices.Count - 1
                Dim index As Integer = Form1.ListView6.SelectedIndices(i)
                If index <= 0 Then Continue For
                If Form1.ListView6.SelectedIndices.Contains(index - 1) Then Continue For
                Dim 变动排序的列表视图项 As ListViewItem = Form1.ListView6.Items(index)
                Form1.ListView6.Items.RemoveAt(index)
                Form1.ListView6.Items.Insert(index - 1, 变动排序的列表视图项)
                Form1.ListView6.Items(index - 1).Focused = True
            Next
        End If
    End Sub

    Public Shared Sub 下移内容()
        If Form1.ListView6.SelectedIndices.Count > 0 Then
            For i = Form1.ListView6.SelectedIndices.Count - 1 To 0 Step -1
                Dim index As Integer = Form1.ListView6.SelectedIndices(i)
                If index >= Form1.ListView6.Items.Count - 1 Then Continue For
                If Form1.ListView6.SelectedIndices.Contains(index + 1) Then Continue For
                Dim 变动排序的列表视图项 As ListViewItem = Form1.ListView6.Items(index)
                Form1.ListView6.Items.RemoveAt(index)
                Form1.ListView6.Items.Insert(index + 1, 变动排序的列表视图项)
                Form1.ListView6.Items(index + 1).Focused = True
            Next
        End If
    End Sub

    Public Shared Sub 内容列表视图DragEnter(sender As Object, e As DragEventArgs)
        If Form1.ListView3.SelectedItems.Count <> 1 Then Exit Sub
        e.Effect = DragDropEffects.Copy
    End Sub

    Public Shared Sub 内容列表视图DragDrop(sender As Object, e As DragEventArgs)
        If Form1.ListView3.SelectedItems.Count <> 1 Then Exit Sub
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim 允许所有文件 As Boolean = False
            If 当前项的规划操作列表.Contains(任务队列操作类型枚举.声明各种核心功能的启停) Then
                Dim 控制参数 As New List(Of String)(Form1.ListView7.Items(当前项的规划操作列表.IndexOf(任务队列操作类型枚举.声明各种核心功能的启停)).SubItems(1).Text.Split("|").ToList)
                If 控制参数.Contains("FILE-ALLOW-ALL") Then 允许所有文件 = True
            End If
            Dim 要复制的文件和文件夹列表 As String() = e.Data.GetData(DataFormats.FileDrop)
            For i = 0 To 要复制的文件和文件夹列表.Length - 1
                Dim a As String = 要复制的文件和文件夹列表(i)
                Select Case Path.GetFileName(a)
                    Case "Code2", "README", "Version", "Code", "README.rtf", "Font", "Color", "SORT", "NexusFileName"
                        Continue For
                    Case "manifest.json", "config.json"
                        If 允许所有文件 = False Then Continue For
                End Select
                If Directory.Exists(a) = True Then
                    FileIO.FileSystem.CopyDirectory(a, Path.Combine(正在编辑规划的项路径, Path.GetFileName(a)), FileIO.UIOption.AllDialogs)
                Else
                    FileIO.FileSystem.CopyFile(a, Path.Combine(正在编辑规划的项路径, Path.GetFileName(a)), FileIO.UIOption.AllDialogs)
                End If
            Next

            重新扫描项的数据内容()
        End If
    End Sub

    Public Shared Sub 添加文件()
        If Form1.ListView3.SelectedItems.Count <> 1 Then Exit Sub
        Dim 允许所有文件 As Boolean = False
        If 当前项的规划操作列表.Contains(任务队列操作类型枚举.声明各种核心功能的启停) Then
            Dim 控制参数 As New List(Of String)(Form1.ListView7.Items(当前项的规划操作列表.IndexOf(任务队列操作类型枚举.声明各种核心功能的启停)).SubItems(1).Text.Split("|").ToList)
            If 控制参数.Contains("FILE-ALLOW-ALL") Then 允许所有文件 = True
        End If
        Dim x As New OpenFileDialog With {.Multiselect = True}
        x.ShowDialog(Form1)
        If x.FileNames.Length = 0 Then Exit Sub
        For i = 0 To x.FileNames.Length - 1
            Dim a As String = x.FileNames(i)
            Select Case Path.GetFileName(a)
                Case "Code2", "README", "Version", "Code", "README.rtf", "Font", "Color", "SORT", "NexusFileName"
                    Continue For
                Case "manifest.json", "config.json"
                    If 允许所有文件 = False Then Continue For
            End Select
            FileIO.FileSystem.CopyFile(a, Path.Combine(正在编辑规划的项路径, Path.GetFileName(a)), FileIO.UIOption.AllDialogs)
        Next
        重新扫描项的数据内容()
    End Sub

    Public Shared Sub 添加文件夹()
        If Form1.ListView3.SelectedItems.Count <> 1 Then Exit Sub
        Dim str1 As String = ""
        If Not DirEx.SelectDirEx("选择要添加的文件夹（由于五代相关组件无法在这里正常运行，所以目前无法批量选择）", str1) Then Exit Sub
        If str1.EndsWith("\"c) Then str1 = str1.Substring(0, str1.Length - 1)
        FileIO.FileSystem.CopyDirectory(str1, Path.Combine(正在编辑规划的项路径, Path.GetFileName(str1)), FileIO.UIOption.AllDialogs)
        重新扫描项的数据内容()
    End Sub

    Public Shared Sub 重命名内容()
        If Form1.ListView6.SelectedItems.Count <> 1 Then Exit Sub
        Select Case Form1.ListView6.SelectedItems(0).SubItems(1).Text
            Case "文件夹"
                Dim a As New 输入对话框("", "重命名文件夹", Form1.ListView6.SelectedItems(0).Text)
                a.TranslateButtonText("确定", "取消")
返回1:
                Dim x As String = a.ShowDialog(Form1)
                If x = "" Then Exit Sub
                If FileIO.FileSystem.DirectoryExists(Path.Combine(正在编辑规划的项路径, x)) Then
                    Dim b As New 多项单选对话框("", {"确定"}, "目标文件夹已存在")
                    b.ShowDialog(Form1)
                    GoTo 返回1
                Else
                    FileIO.FileSystem.RenameDirectory(Path.Combine(正在编辑规划的项路径, Form1.ListView6.SelectedItems(0).Text), x)
                    Form1.ListView6.SelectedItems(0).Text = x
                End If
            Case "文件"
                Dim a As New 输入对话框("", "重命名文件", Form1.ListView4.SelectedItems(0).Text)
                a.TranslateButtonText("确定", "取消")
返回2:
                Dim x As String = a.ShowDialog(Form1)
                If x = "" Then Exit Sub
                If FileIO.FileSystem.FileExists(Path.Combine(正在编辑规划的项路径, x)) Then
                    Dim b As New 多项单选对话框("", {"确定"}, "目标文件已存在")
                    b.ShowDialog(Form1)
                    GoTo 返回2
                Else
                    FileIO.FileSystem.RenameFile(Path.Combine(正在编辑规划的项路径, Form1.ListView6.SelectedItems(0).Text), x)
                    Form1.ListView6.SelectedItems(0).Text = x
                End If
        End Select

    End Sub

    Public Shared Sub 删除内容()
        If Form1.ListView6.SelectedItems.Count = 0 Then Exit Sub
        Dim i As Integer = 0
        Do Until i = Form1.ListView6.Items.Count
            If Form1.ListView6.Items(i).Selected Then
                Select Case Form1.ListView6.Items(i).SubItems(1).Text
                    Case "文件夹"
                        FileIO.FileSystem.DeleteDirectory(Path.Combine(正在编辑规划的项路径, Form1.ListView6.Items(i).Text), FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
                        Application.DoEvents()
                        Form1.ListView6.Items(i).Remove()
                        i -= 1
                    Case "文件"
                        FileIO.FileSystem.DeleteFile(Path.Combine(正在编辑规划的项路径, Form1.ListView6.Items(i).Text), FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
                        Application.DoEvents()
                        Form1.ListView6.Items(i).Remove()
                        i -= 1
                End Select
            End If
            i += 1
        Loop
    End Sub

    Public Shared Sub 提取压缩包()
        If Form1.ListView6.SelectedItems.Count <> 1 Then Exit Sub
        If Form1.ListView6.SelectedItems(0).SubItems(1).Text <> "文件" Then Exit Sub
        Dim 压缩包路径 As String = Path.Combine(正在编辑规划的项路径, Form1.ListView6.SelectedItems(0).Text)
        Select Case IO.Path.GetExtension(压缩包路径)
            Case ".7z", ".zip"
                Dim zip1 As New SevenZip.SevenZipExtractor(压缩包路径)
                For i As Integer = 0 To zip1.ArchiveFileData.Count - 1
                    zip1.ExtractFiles(正在编辑规划的项路径 & "\", zip1.ArchiveFileData(i).Index)
                Next
                zip1.Dispose()
        End Select
        重新扫描项的数据内容()
    End Sub

    Public Shared Sub 拿出内容()
        If Form1.ListView6.SelectedItems.Count <> 1 Then Exit Sub
        If Form1.ListView6.SelectedItems(0).SubItems(1).Text <> "文件夹" Then Exit Sub
        Dim 文件夹路径 As String = Path.Combine(正在编辑规划的项路径, Form1.ListView6.SelectedItems(0).Text)
        Dim mFileInfo As System.IO.FileInfo
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(文件夹路径)
        For Each mDir In mDirInfo.GetDirectories
            FileIO.FileSystem.MoveDirectory(mDir.FullName, Path.Combine(正在编辑规划的项路径, mDir.Name), True)
        Next
        For Each mFileInfo In mDirInfo.GetFiles("*.*")
            FileIO.FileSystem.MoveFile(mFileInfo.FullName, Path.Combine(正在编辑规划的项路径, mFileInfo.Name), True)
        Next
        重新扫描项的数据内容()
    End Sub

    Public Shared Sub 内容套层()
        If Form1.ListView6.SelectedItems.Count <> 1 Then Exit Sub
        Dim a As New 输入对话框("", "新建文件夹名称")
        Dim b As String = a.ShowDialog(Form1)
        If b = "" Then Exit Sub
        Dim 新文件夹路径 As String = Path.Combine(正在编辑规划的项路径, b)
        If Not FileIO.FileSystem.DirectoryExists(新文件夹路径) Then FileIO.FileSystem.CreateDirectory(新文件夹路径)
        For i = 0 To Form1.ListView6.SelectedItems.Count - 1
            Select Case Form1.ListView6.SelectedItems(i).SubItems(1).Text
                Case "文件夹"
                    FileIO.FileSystem.MoveDirectory(Path.Combine(正在编辑规划的项路径, Form1.ListView6.SelectedItems(i).Text), Path.Combine(新文件夹路径, Form1.ListView6.SelectedItems(i).Text), True)
                Case "文件"
                    FileIO.FileSystem.MoveFile(Path.Combine(正在编辑规划的项路径, Form1.ListView6.SelectedItems(i).Text), Path.Combine(新文件夹路径, Form1.ListView6.SelectedItems(i).Text), True)
            End Select
        Next
        重新扫描项的数据内容()
    End Sub

    Public Shared Sub 规划列表键盘按下事件(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F3
                上移规划()
            Case Keys.F4
                下移规划()
        End Select
    End Sub

    Public Shared Sub 上移规划()
        If Form1.ListView7.SelectedIndices.Count > 0 Then
            For i = 0 To Form1.ListView7.SelectedIndices.Count - 1
                Dim index As Integer = Form1.ListView7.SelectedIndices(i)
                If index <= 0 Then Continue For
                If Form1.ListView7.SelectedIndices.Contains(index - 1) Then Continue For
                Dim 变动排序的列表视图项 As ListViewItem = Form1.ListView7.Items(index)
                Form1.ListView7.Items.RemoveAt(index)
                Form1.ListView7.Items.Insert(index - 1, 变动排序的列表视图项)
                Form1.ListView7.Items(index - 1).Focused = True
                Dim 变动排序的安装规划类型 As 任务队列操作类型枚举 = 当前项的规划操作列表(index)
                当前项的规划操作列表.RemoveAt(index)
                当前项的规划操作列表.Insert(index - 1, 变动排序的安装规划类型)
            Next
        End If
    End Sub

    Public Shared Sub 下移规划()
        If Form1.ListView7.SelectedIndices.Count > 0 Then
            For i = Form1.ListView7.SelectedIndices.Count - 1 To 0 Step -1
                Dim index As Integer = Form1.ListView7.SelectedIndices(i)
                If index >= Form1.ListView7.Items.Count - 1 Then Continue For
                If Form1.ListView7.SelectedIndices.Contains(index + 1) Then Continue For
                Dim 变动排序的列表视图项 As ListViewItem = Form1.ListView7.Items(index)
                Form1.ListView7.Items.RemoveAt(index)
                Form1.ListView7.Items.Insert(index + 1, 变动排序的列表视图项)
                Form1.ListView7.Items(index + 1).Focused = True
                Dim 变动排序的安装规划类型 As 任务队列操作类型枚举 = 当前项的规划操作列表(index)
                当前项的规划操作列表.RemoveAt(index)
                当前项的规划操作列表.Insert(index + 1, 变动排序的安装规划类型)
            Next
        End If
    End Sub

    Public Shared Sub 自动完成()
        If Form1.ListView3.SelectedItems.Count <> 1 Then Exit Sub
        If Form1.ListView7.Items.Count <> 0 Then
            Dim msg1 As New 多项单选对话框("", {"放弃已有规划，继续执行自动规划", "万万不可"}, "自动规划功能需要清除现有规划数据，是否继续？",, 500)
            If msg1.ShowDialog(Form1) <> 0 Then Exit Sub
        End If
        Form1.ListView7.Items.Clear() : 当前项的规划操作列表.Clear()
        Dim 是否有对象未生成规划 As Boolean = False
        For i = 0 To Form1.ListView6.Items.Count - 1
            Select Case Form1.ListView6.Items(i).SubItems(1).Text
                Case "文件夹"
                    Select Case Form1.ListView6.Items(i).Text
                        Case "Content"
                            配置队列的菜单.添加新规划通用调用(任务队列操作类型枚举.覆盖Content, "0")
                        Case Else
                            If FileIO.FileSystem.FileExists(Path.Combine(正在编辑规划的项路径, Form1.ListView6.Items(i).Text, "manifest.json")) Then
                                配置队列的菜单.添加新规划通用调用(任务队列操作类型枚举.复制文件夹到Mods, Form1.ListView6.Items(i).Text)
                            Else
                                是否有对象未生成规划 = True
                            End If
                    End Select
                Case Else
                    是否有对象未生成规划 = True
            End Select
        Next

        If 是否有对象未生成规划 Then
            Dim msg2 As New 多项单选对话框("", {"确定"}, "自动规划已完成，还存在未生成规划的对象，请手动完成那些",, 500)
            msg2.ShowDialog(Form1)
        End If

    End Sub






End Class
