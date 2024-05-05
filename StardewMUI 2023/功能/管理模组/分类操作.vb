Imports System.IO
Imports Sunny.UI

Public Class 分类操作

    Public Shared Sub 新建分类()
        Dim a As String = 管理模组2.检查并返回当前所选子库路径()
        If a = "" Then Exit Sub
        Dim d1 As New 输入对话框("", "输入新建分类的名称",, 500)
        d1.TranslateButtonText("确定", "取消")
Line1:
        Dim s1 As String = d1.ShowDialog(Form1)
        If s1 = "" Then Exit Sub
        If FileIO.FileSystem.DirectoryExists(a & "\" & s1) Then
            Dim b As New 多项单选对话框("", {"确定"}, "已经存在目标分类：" & vbCrLf & vbCrLf & a & "\" & s1,, 500)
            b.ShowDialog(Form1)
            GoTo Line1
        Else
            FileIO.FileSystem.CreateDirectory(a & "\" & s1)
            Form1.ListView1.Items.Add(s1)
            管理模组.实时分类排序.Add(s1)
            管理模组.实时分类排序是否经过修改 = True
            Form1.Label50.Text = Form1.ListView1.Items.Count
        End If
    End Sub

    Public Shared Sub 转移分类()
        If Form1.ListView1.SelectedItems.Count <> 1 Then Exit Sub
        Dim d1 As String = 管理模组2.检查并返回当前模组数据仓库路径
        If d1 = "" Then Exit Sub

        Dim newWindow As New Form With {
            .Text = "选择目标子库",
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
        Dim a As New List(Of String)(共享方法.SearchFolderWithoutSub(d1))
        a.Remove(".Download")
        a.Remove(".Decompress")
        For i = 0 To a.Count - 1
            Dim b1 As New Label With {
                .AutoSize = False,
                .Height = 30 * 界面控制.DPI,
                .Text = a(i),
                .TextAlign = ContentAlignment.MiddleLeft,
                .Dock = DockStyle.Top,
                .Padding = New Padding(3, 0, 3, 0)
            }
            AddHandler b1.MouseEnter, Sub(sender, e) sender.BackColor = ColorTranslator.FromWin32(RGB(48, 48, 48))
            AddHandler b1.MouseLeave, Sub(sender, e) sender.BackColor = newWindow.BackColor
            AddHandler b1.MouseDown, Sub(sender, e) sender.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
            AddHandler b1.Click, Sub(sender, e)
                                     管理模组.重置模组项信息显示()
                                     管理模组.清除模组项列表()
                                     Dim i2 As Integer = 0
                                     Do Until i2 = Form1.ListView1.Items.Count
                                         If Form1.ListView1.Items(i2).Selected Then
                                             Dim 当前选择的目标子库 As String = sender.Text
                                             Dim 原路径 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView1.Items(i2).Text)
                                             Dim 目标路径 As String = Path.Combine(管理模组2.检查并返回当前模组数据仓库路径(False), 当前选择的目标子库, Form1.ListView1.Items(i2).Text)
                                             If Not FileIO.FileSystem.DirectoryExists(目标路径) Then
                                                 FileIO.FileSystem.MoveDirectory(原路径, 目标路径)
                                                 Form1.ListView1.Items(i2).Remove()
                                                 管理模组.实时分类排序.RemoveAt(i2)
                                                 管理模组.实时分类排序是否经过修改 = True
                                                 i2 -= 1
                                             End If
                                         End If
                                         i2 += 1
                                     Loop
                                     Form1.Label50.Text = Form1.ListView1.Items.Count
                                     newWindow.Dispose()
                                     sender.Dispose()
                                 End Sub
            newWindow.Controls.Add(b1)
            b1.BringToFront()
        Next
        显示模式窗体(newWindow, Form1)
    End Sub

    Public Shared Sub 重命名分类()
        If Form1.ListView1.SelectedItems.Count <> 1 Then Exit Sub
        Dim a As New 输入对话框("", "重新命名分类：" & Form1.ListView1.SelectedItems(0).Text, Form1.ListView1.SelectedItems(0).Text)
        a.TranslateButtonText("确定", "取消")
Line1:
        Dim s1 As String = a.ShowDialog(Form1)
        If s1 = "" Then Exit Sub
        If FileIO.FileSystem.DirectoryExists(Path.Combine(管理模组2.检查并返回当前所选子库路径(False), s1)) Then
            Dim b As New 多项单选对话框("", {"确定"}, "已经存在目标分类：" & vbCrLf & vbCrLf & s1,, 500)
            b.ShowDialog(Form1)
            GoTo Line1
        Else
            Dim x As String = Form1.ListView1.SelectedItems(0).Text
            FileIO.FileSystem.RenameDirectory(Path.Combine(管理模组2.检查并返回当前所选子库路径(False), x), s1)
            Form1.ListView1.SelectedItems(0).Text = s1
            管理模组.实时分类排序.Item(Form1.ListView1.SelectedIndices(0)) = s1
            管理模组.实时分类排序是否经过修改 = True
            For i = 0 To Form1.ListView2.Items.Count - 1
                If Form1.ListView2.Items(i).SubItems(3).Text = x Then Form1.ListView2.Items(i).SubItems(3).Text = s1
            Next
            For i = 0 To Form1.ListView3.Items.Count - 1
                If Form1.ListView3.Items(i).SubItems(1).Text = x Then
                    Form1.ListView3.Items(i).SubItems(1).Text = s1
                End If
            Next
        End If
    End Sub

    Public Shared Sub 删除分类()
        Dim a As New 多项单选对话框("", {"移至回收站", "彻底删除", "万万不可"}, "确认删除所选择的分类？",, 500)
        Dim s1 As String = a.ShowDialog(Form1)
        If s1 = -1 Or s1 = 2 Then Exit Sub
        Dim i As Integer = 0
        Do Until i = Form1.ListView1.Items.Count
            If Form1.ListView1.Items(i).Selected Then
                Select Case s1
                    Case 0
                        FileIO.FileSystem.DeleteDirectory(Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView1.Items(i).Text), FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
                    Case 1
                        FileIO.FileSystem.DeleteDirectory(Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView1.Items(i).Text), FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
                End Select
                If FileIO.FileSystem.DirectoryExists(Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView1.Items(i).Text)) Then
                    i += 1
                    Continue Do
                End If
                Form1.ListView1.Items(i).Remove()
                管理模组.实时分类排序.RemoveAt(i)
                管理模组.实时分类排序是否经过修改 = True
                i -= 1
            End If
            i += 1
        Loop
        Form1.Label50.Text = Form1.ListView1.Items.Count
    End Sub


End Class
