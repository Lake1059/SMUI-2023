Imports System.IO
Imports SMUI6.公共对象

Public Class 配置队列



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

    Public Shared Property 编辑规划操作字典 As New Dictionary(Of 任务队列操作类型枚举, DE1)()
    Delegate Sub DE1()
    Public Shared Sub 初始化编辑规划操作字典()
        编辑规划操作字典.Add(任务队列操作类型枚举.复制文件夹到Mods, AddressOf 配置队列的规划编辑.匹配到_复制文件夹到Mods)






    End Sub

    Public Shared Property 规划显示名称字典 As New Dictionary(Of 任务队列操作类型枚举, String)()
    Public Shared Sub 初始化规划显示名称字典()
        规划显示名称字典.Add(任务队列操作类型枚举.复制文件夹到Mods, "安装标准 SMAPI 模组")
        规划显示名称字典.Add(任务队列操作类型枚举.覆盖文件夹到Mods, "覆盖 Mods 中的文件夹")
        规划显示名称字典.Add(任务队列操作类型枚举.复制文件夹, "复制文件夹到根位置")
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
        初始化识别规划操作字典()
        初始化编辑规划操作字典()
        初始化规划显示名称字典()
        AddHandler Form1.UiButton19.Click, AddressOf 移除全部
        AddHandler Form1.UiButton16.Click, AddressOf 移除选中
        AddHandler Form1.UiButton23.Click, AddressOf 重新扫描项的数据内容
        AddHandler 管理模组的菜单.菜单项_配置项.Click, AddressOf 添加到配置队列
        AddHandler Form1.ListView3.SelectedIndexChanged,
            Sub()
                If Form1.ListView3.SelectedItems.Count <> 1 Then
                    重置配置队列()
                Else
                    读取选中项()
                End If
            End Sub
        AddHandler Form1.ListView7.DoubleClick, AddressOf 编辑选中的规划
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
        Form1.ListView8.Items.Clear()
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
            DebugPrint("意外故障，无法在字典中匹配到操作，这在理论上不可能发生", Color1.红色, True)
        End If
    End Sub

    Public Shared Sub 重新扫描项的数据内容()
        Form1.ListView6.Items.Clear()
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(正在编辑规划的项路径)
        For Each mDir In mDirInfo.GetDirectories
            Select Case mDir.Name
                Case "Screenshot", ".config"
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
                Case "README", "Version", "Code", "Code2", "README.rtf", "Font"
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


End Class
