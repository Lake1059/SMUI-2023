﻿Imports System.IO

Public Class 模组项操作

    Public Shared Sub 新建模组项()
        If Form1.ListView1.SelectedItems.Count <> 1 Then Exit Sub
        Dim a As String = 管理模组2.检查并返回当前选择分类路径
        If a = "" Then Exit Sub
        Dim d1 As New 输入对话框("", "输入新建模组项的名称",, 500)
        d1.TranslateButtonText("确定", "取消")
Line1:
        Dim s1 As String = d1.ShowDialog(Form1).Trim
        If s1 = "" Then Exit Sub
        If FileIO.FileSystem.DirectoryExists(Path.Combine(a, s1)) Then
            Dim b As New 多项单选对话框("", {"确定"}, "已经存在目标模组项：" & vbCrLf & vbCrLf & a & "\" & s1,, 500)
            b.ShowDialog(Form1)
            GoTo Line1
        Else
            FileIO.FileSystem.CreateDirectory(Path.Combine(a, s1))
            Form1.ListView2.Items.Add(s1)
            Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).ForeColor = Color1.橙色
            Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add("不可用")
            Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add("请完成配置")
            Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add(Form1.ListView1.Items(Form1.ListView1.SelectedIndices(0)).Text)
            管理模组.实时模组项排序.Add(s1)
            管理模组.实时模组项排序是否经过修改 = True

            Form1.ListView3.Items.Add(s1)
            Form1.ListView3.Items(Form1.ListView3.Items.Count - 1).SubItems.Add(Form1.ListView1.Items(Form1.ListView1.SelectedIndices(0)).Text)

            If Form1.ListView3.SelectedItems.Count = 0 Then Form1.ListView3.Items.Item(Form1.ListView3.Items.Count - 1).Selected = True
            If Form1.ListView3.Items.Count = 1 Then Form1.UiTabControl1.SelectedTab = Form1.TabPage配置队列

            Form1.Label51.Text = Form1.ListView2.Items.Count
        End If
    End Sub

    Public Shared Sub 下载并新建项()
        If Form下载并新建项.Visible = True Then Exit Sub
        Dim a As String = 管理模组2.检查并返回当前所选子库路径
        If a = "" Then Exit Sub
        显示窗体(Form下载并新建项, Form1)
    End Sub

    Public Shared Sub 转移模组项()
        Dim d1 As String = 管理模组2.检查并返回当前所选子库路径
        If d1 = "" Then Exit Sub

        Dim newWindow As New Form With {
            .Text = "选择目标分类",
            .BackColor = Form1.BackColor,
            .ForeColor = Form1.ForeColor,
            .AutoScroll = True,
            .StartPosition = FormStartPosition.Manual,
            .Size = New Size(300 * 界面控制.DPI, 500 * 界面控制.DPI),
            .MinimumSize = New Size(300 * 界面控制.DPI, 500 * 界面控制.DPI),
            .Padding = New Padding(10 * 界面控制.DPI),
            .MinimizeBox = False,
            .MaximizeBox = False,
            .SizeGripStyle = False,
            .ShowInTaskbar = False,
            .ShowIcon = False
        }

        For i = 0 To Form1.ListView1.Items.Count - 1
            Dim b1 As New Label With {
                .AutoSize = False,
                .Height = 30 * 界面控制.DPI,
                .Text = Form1.ListView1.Items(i).Text,
                .TextAlign = ContentAlignment.MiddleLeft,
                .Dock = DockStyle.Top,
                .Padding = New Padding(3, 0, 3, 0),
                .ForeColor = Form1.ListView1.Items(i).ForeColor,
                .Font = Form1.ListView1.Items(i).Font
            }
            AddHandler b1.MouseEnter, Sub(sender, e) sender.BackColor = ColorTranslator.FromWin32(RGB(48, 48, 48))
            AddHandler b1.MouseLeave, Sub(sender, e) sender.BackColor = newWindow.BackColor
            AddHandler b1.MouseDown, Sub(sender, e) sender.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
            AddHandler b1.Click, Sub(sender, e)
                                     管理模组.重置模组项信息显示()
                                     Dim i2 As Integer = 0
                                     Do Until i2 = Form1.ListView2.Items.Count
                                         If Form1.ListView2.Items(i2).Selected Then
                                             Dim 当前选择的目标分类 As String = sender.Text
                                             Dim 原路径 As String = Path.Combine(管理模组2.检查并返回当前选择分类路径(False), Form1.ListView2.Items(i2).Text)
                                             Dim 目标路径 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), 当前选择的目标分类, Form1.ListView2.Items(i2).Text)
                                             If Not FileIO.FileSystem.DirectoryExists(目标路径) Then
                                                 FileIO.FileSystem.MoveDirectory(原路径, 目标路径)
                                                 Form1.ListView2.Items(i2).Remove()
                                                 管理模组.实时模组项排序.RemoveAt(i2)
                                                 管理模组.实时模组项排序是否经过修改 = True
                                                 i2 -= 1
                                             End If
                                         End If
                                         i2 += 1
                                     Loop
                                     Form1.Label51.Text = Form1.ListView2.Items.Count
                                     newWindow.Dispose()
                                     sender.Dispose()
                                 End Sub
            newWindow.Controls.Add(b1)
            b1.BringToFront()
        Next
        显示模式窗体(newWindow, Form1)
    End Sub

    Public Shared Sub 重命名模组项()
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        Dim a As New 输入对话框("", "重新命名模组项：" & Form1.ListView2.SelectedItems(0).Text, Form1.ListView2.SelectedItems(0).Text)
        a.TranslateButtonText("确定", "取消")
Line1:
        Dim s1 As String = a.ShowDialog(Form1).Trim
        If s1 = "" Then Exit Sub
        If FileIO.FileSystem.DirectoryExists(Path.Combine(管理模组2.检查并返回当前选择分类路径(False), s1)) Then
            Dim b As New 多项单选对话框("", {"确定"}, "已经存在目标模组项：" & vbCrLf & vbCrLf & s1,, 500)
            b.ShowDialog(Form1)
            GoTo Line1
        Else
            Dim x As String = Form1.ListView2.SelectedItems(0).Text
            FileIO.FileSystem.RenameDirectory(Path.Combine(管理模组2.检查并返回当前选择分类路径(False), x), s1)
            Form1.ListView2.SelectedItems(0).Text = s1
            管理模组.实时模组项排序.Item(Form1.ListView2.SelectedIndices(0)) = s1
            管理模组.实时模组项排序是否经过修改 = True
            For i = 0 To Form1.ListView3.Items.Count - 1
                If Form1.ListView3.Items(i).Text = x Then
                    Form1.ListView3.Items(i).Text = s1
                    If Form1.UiTextBox6.Text = x Then Form1.UiTextBox6.Text = s1
                    Exit For
                End If
            Next
        End If
    End Sub

    Public Shared Sub 删除模组项()
        Dim a As New 多项单选对话框("", {"移至回收站", "彻底删除", "万万不可"}, "确认删除所选择的模组项？",, 500)
        Dim s1 As String = a.ShowDialog(Form1)
        If s1 = -1 Or s1 = 2 Then Exit Sub
        Dim i As Integer = 0
        Do Until i = Form1.ListView2.Items.Count
            If Form1.ListView2.Items(i).Selected Then
                Select Case s1
                    Case 0
                        FileIO.FileSystem.DeleteDirectory(Path.Combine(管理模组2.检查并返回当前选择分类路径(False), Form1.ListView2.Items(i).Text), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                    Case 1
                        FileIO.FileSystem.DeleteDirectory(Path.Combine(管理模组2.检查并返回当前选择分类路径(False), Form1.ListView2.Items(i).Text), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                End Select
                If FileIO.FileSystem.DirectoryExists(Path.Combine(管理模组2.检查并返回当前选择分类路径(False), Form1.ListView2.Items(i).Text)) Then
                    i += 1
                    Continue Do
                End If
                Form1.ListView2.Items(i).Remove()
                管理模组.实时模组项排序.RemoveAt(i)
                管理模组.实时模组项排序是否经过修改 = True
                i -= 1
            End If
            i += 1
        Loop
        Form1.Label51.Text = Form1.ListView2.Items.Count
    End Sub

    Public Shared Sub 删除排序()
        If Form1.ListView1.SelectedItems.Count = 0 Then Exit Sub
        Dim a As New 多项单选对话框("", {"删除", "取消"}, "确认删除排序文件？",, 500)
        Dim s1 As String = a.ShowDialog(Form1)
        If s1 <> 0 Then Exit Sub
        管理模组.实时模组项排序是否经过修改 = False
        管理模组.实时模组项列表内容归属的分类 = ""
        管理模组.实时模组项排序.Clear()
        管理模组.清除模组项列表()
        For i = 0 To Form1.ListView1.SelectedItems.Count - 1
            Dim path1 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView1.SelectedItems(i).Text, "SORT")
            If FileIO.FileSystem.FileExists(path1) Then
                FileIO.FileSystem.DeleteFile(path1)
            End If
        Next
    End Sub

    Public Shared Sub 清除Config缓存()
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        Dim a As New 多项单选对话框("", {"删除", "取消"}, "确认清除选中模组项的已有 Config 缓存？",, 500)
        Dim s1 As String = a.ShowDialog(Form1)
        If s1 <> 0 Then Exit Sub
        For i = 0 To Form1.ListView2.SelectedItems.Count - 1
            Dim path1 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(i).SubItems(3).Text, Form1.ListView2.SelectedItems(i).Text, ".config")
            If FileIO.FileSystem.DirectoryExists(path1) Then
                FileIO.FileSystem.DeleteDirectory(path1, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If
        Next
    End Sub

End Class
