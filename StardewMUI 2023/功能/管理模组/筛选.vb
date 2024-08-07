
Imports System.IO

Public Class 筛选

    Public Shared Sub 初始化()
        AddHandler 管理模组的菜单.菜单项_全选.Click, AddressOf 全选
        AddHandler 管理模组的菜单.菜单项_反选.Click, AddressOf 反选
        AddHandler 管理模组的菜单.菜单项_选中所有已安装.Click, AddressOf 选中所有已安装
        AddHandler 管理模组的菜单.菜单项_选中所有未安装.Click, AddressOf 选中所有未安装
        AddHandler 管理模组的菜单.菜单项_选中所有非标项.Click, AddressOf 选中所有非标项
        AddHandler 管理模组的菜单.菜单项_选中所有更新可用.Click, AddressOf 选中所有更新可用
        AddHandler 管理模组的菜单.菜单项_选中所有已有新的.Click, AddressOf 选中所有已有新的
        AddHandler 管理模组的菜单.菜单项_扫描当前子库所有已安装.Click, AddressOf 扫描当前子库所有已安装
        AddHandler 管理模组的菜单.菜单项_扫描当前子库所有未安装.Click, AddressOf 扫描当前子库所有未安装
        AddHandler 管理模组的菜单.菜单项_扫描当前子库所有非标项.Click, AddressOf 扫描当前子库所有非标项
    End Sub

    Public Shared Sub 全选()
        For i = 0 To Form1.ListView2.Items.Count - 1
            Form1.ListView2.Items(i).Selected = True
        Next
    End Sub
    Public Shared Sub 反选()
        For i = 0 To Form1.ListView2.Items.Count - 1
            If Form1.ListView2.Items(i).Selected = True Then
                Form1.ListView2.Items(i).Selected = False
            Else
                Form1.ListView2.Items(i).Selected = True
            End If
        Next
    End Sub

    Public Shared Sub 选中所有已安装()
        For i = 0 To Form1.ListView2.Items.Count - 1
            If Form1.ListView2.Items(i).SubItems(2).Text = "已安装" Then
                Form1.ListView2.Items(i).Selected = True
            Else
                Form1.ListView2.Items(i).Selected = False
            End If
        Next
        If Form1.ListView2.SelectedItems.Count > 0 Then
            Form1.ListView2.SelectedItems(0).EnsureVisible()
        End If
    End Sub
    Public Shared Sub 选中所有未安装()
        For i = 0 To Form1.ListView2.Items.Count - 1
            If Form1.ListView2.Items(i).SubItems(2).Text = "未安装" Then
                Form1.ListView2.Items(i).Selected = True
            Else
                Form1.ListView2.Items(i).Selected = False
            End If
        Next
        If Form1.ListView2.SelectedItems.Count > 0 Then
            Form1.ListView2.SelectedItems(0).EnsureVisible()
        End If
    End Sub
    Public Shared Sub 选中所有非标项()
        For i = 0 To Form1.ListView2.Items.Count - 1
            Select Case Form1.ListView2.Items(i).SubItems(2).Text
                Case "文件夹已复制", "文件夹未复制", "文件夹部分复制", "附加内容", "文件已替换", "文件未替换", "文件部分替换", "文件已复制", "文件未复制", "文件部分复制", "文件已复制并验证", "文件已复制但验证失败", "不带判断的文件复制", "覆盖Content文件夹"
                    Form1.ListView2.Items(i).Selected = True
                Case Else
                    Form1.ListView2.Items(i).Selected = False
            End Select
        Next
        If Form1.ListView2.SelectedItems.Count > 0 Then
            Form1.ListView2.SelectedItems(0).EnsureVisible()
        End If
    End Sub

    Public Shared Sub 选中所有更新可用()
        For i = 0 To Form1.ListView2.Items.Count - 1
            If Form1.ListView2.Items(i).SubItems(2).Text = "更新可用" Then
                Form1.ListView2.Items(i).Selected = True
            Else
                Form1.ListView2.Items(i).Selected = False
            End If
        Next
        If Form1.ListView2.SelectedItems.Count > 0 Then
            Form1.ListView2.SelectedItems(0).EnsureVisible()
        End If
    End Sub
    Public Shared Sub 选中所有已有新的()
        For i = 0 To Form1.ListView2.Items.Count - 1
            If Form1.ListView2.Items(i).SubItems(2).Text = "已有新的" Then
                Form1.ListView2.Items(i).Selected = True
            Else
                Form1.ListView2.Items(i).Selected = False
            End If
        Next
        If Form1.ListView2.SelectedItems.Count > 0 Then
            Form1.ListView2.SelectedItems(0).EnsureVisible()
        End If
    End Sub

    Public Shared Sub 扫描当前子库所有已安装()
        扫描当前子库({"Installed"})
    End Sub
    Public Shared Sub 扫描当前子库所有未安装()
        扫描当前子库({"UnInstalled"})
    End Sub
    Public Shared Sub 扫描当前子库所有非标项()
        扫描当前子库({"FolderCopied", "FolderNoCopied", "IncompleteFolderCopied", "Additional", "FileInstalled", "FileUnInstalled", "FileIncomplete", "FileInstalledVerified", "FileInstalledVerifyfailed", "File", "CoverContent"})
    End Sub

    Shared Sub 扫描当前子库(安装状态集合 As String())
        管理模组.清除模组项列表()
        For i = 0 To Form1.ListView1.Items.Count - 1
            Dim mDir2 As IO.DirectoryInfo
            Dim mDirInfo2 As New IO.DirectoryInfo(Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView1.Items(i).Text))
            For Each mDir2 In mDirInfo2.GetDirectories
                Dim a As New 项信息读取类
                Dim ct As New 项信息读取类.项数据计算类型结构 With {.安装状态 = True, .版本 = True, .已安装版本 = True}
                If Not FileIO.FileSystem.FileExists(Path.Combine(mDir2.FullName, "Code2")) Then
                    If FileIO.FileSystem.FileExists(Path.Combine(mDir2.FullName, "Code")) Then
                        FileIO.FileSystem.WriteAllText(Path.Combine(mDir2.FullName, "Code2"), 命令规划转换.将安装命令转换到安装规划(FileIO.FileSystem.ReadAllText(Path.Combine(mDir2.FullName, "Code"))), False)
                    End If
                End If
                a.读取项信息(mDir2.FullName, ct, 设置.全局设置数据("StardewValleyGamePath"))
                If a.错误信息 <> "" Then Continue For
                If Not 安装状态集合.Contains(a.安装状态) Then Continue For

                Form1.ListView2.Items.Add(mDir2.Name)
                Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add("")
                Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add("")
                Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add(Form1.ListView1.Items(i).Text)

                If a.版本.Count > 0 And a.已安装版本.Count > 0 Then
                    If a.版本(0) <> a.已安装版本(0) Then
                        If a.安装状态 = "Incomplete" Then
                            Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems(1).Text = a.版本(0)
                            GoTo 结束版本号高低判断
                        End If
                        Select Case 共享方法.CompareVersion(a.版本(0), a.已安装版本(0))
                            Case = 0
                                Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems(1).Text = a.版本(0)
                            Case > 0
                                Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems(1).Text = a.版本(0) & " ← " & a.已安装版本(0)
                                Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems(2).Text = "更新可用"
                            Case < 0
                                Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems(1).Text = a.版本(0) & " → " & a.已安装版本(0)
                                Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems(2).Text = "已有新的"
                        End Select
结束版本号高低判断:
                    Else
                        Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems(1).Text = a.版本(0)
                    End If

                Else
                    If a.版本.Count > 0 Then
                        Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems(1).Text = a.版本(0)
                    ElseIf FileIO.FileSystem.FileExists(Path.Combine(mDir2.FullName, "Version")) = True Then
                        Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems(1).Text = FileIO.FileSystem.ReadAllText(Path.Combine(mDir2.FullName, "Version"))
                    Else
                        Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems(1).Text = "未知版本"
                    End If
                    Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).ForeColor = Color1.白色
                End If

                Select Case Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems(2).Text
                    Case ""
                        Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems(2).Text = 项信息读取类.安装状态字典(a.安装状态)
                End Select

                管理模组.根据安装状态设置项的颜色标记(a.安装状态, Form1.ListView2.Items(Form1.ListView2.Items.Count - 1), True)

                Dim 模组项字体文件路径 As String = Path.Combine(mDir2.FullName, "Font")
                If FileIO.FileSystem.FileExists(模组项字体文件路径) Then
                    Select Case FileIO.FileSystem.ReadAllText(模组项字体文件路径)
                        Case "BD"
                            Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Bold)
                        Case "LC"
                            Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Italic)
                        Case "UL"
                            Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Underline)
                        Case "SO"
                            Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Strikeout)
                    End Select
                End If
            Next
        Next
        Form1.Label51.Text = Form1.ListView2.Items.Count

    End Sub


End Class
