Imports System.IO

Public Class 预览图功能

    Public Shared Sub 初始化()
        AddHandler 管理模组的菜单.菜单项_打开截图文件夹.Click, AddressOf 打开文件夹
        AddHandler 管理模组的菜单.菜单项_复制当前预览图.Click, AddressOf 复制
        AddHandler 管理模组的菜单.菜单项_删除当前预览图.Click, AddressOf 删除当前图
        AddHandler 管理模组的菜单.菜单项_删除全部预览图.Click, AddressOf 删除所有图

        AddHandler Form1.PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove
        AddHandler Form1.PictureBox1.MouseClick, AddressOf PictureBox1_MouseClick
        AddHandler Form1.PictureBox1.MouseDoubleClick, AddressOf PictureBox1_MouseDoubleClick
        AddHandler Form1.PictureBox1.MouseWheel, AddressOf PictureBox1_MouseWheel
    End Sub


    Public Shared Sub 打开文件夹()
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        Dim S1 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text)

        Dim str1 As String = Path.Combine(S1, "Screenshot").Replace("\\", "\")
        If FileIO.FileSystem.DirectoryExists(str1) Then
            Process.Start("explorer.exe", str1)
        Else
            Dim a As New 多项单选对话框("", {"确认创建", "取消"}, "要创建截图文件夹吗？")
            If a.ShowDialog(Form1) = 0 Then
                FileIO.FileSystem.CreateDirectory(str1)
                Process.Start("explorer.exe", str1)
            End If
        End If
    End Sub

    Public Shared Sub 复制()
        Clipboard.SetImage(Form1.PictureBox1.Image)
    End Sub


    Public Shared Sub 删除当前图()
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        Dim S1 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text)

        If FileIO.FileSystem.DirectoryExists(S1 & "\Screenshot") = True Then
            FileIO.FileSystem.DeleteDirectory(S1 & "\Screenshot", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            Form1.PictureBox1.Image = Nothing
            Form1.Panel9.Visible = False
        End If
    End Sub

    Public Shared Sub 删除所有图()
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        Dim S1 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text)

        If 管理模组.当前项信息_预览图文件表.Count < 1 Then Exit Sub
        If FileIO.FileSystem.FileExists(管理模组.当前项信息_预览图文件表(管理模组.当前正在显示的预览图索引)) = True Then
            FileIO.FileSystem.DeleteFile(管理模组.当前项信息_预览图文件表(管理模组.当前正在显示的预览图索引), FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            Form1.PictureBox1.Image = Nothing
            Form1.Panel9.Visible = False
        End If

    End Sub

    Public Shared Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs)
        Select Case e.X / Form1.PictureBox1.Width
            Case <= 0.15
                Form1.PictureBox1.Cursor = Cursors.PanWest
            Case >= 0.85
                Form1.PictureBox1.Cursor = Cursors.PanEast
            Case Else
                Form1.PictureBox1.Cursor = Cursors.Default
        End Select
    End Sub

    Public Shared Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Select Case Form1.PictureBox1.Cursor
                Case Cursors.PanWest
                    Dim a As Integer = 管理模组.当前正在显示的预览图索引 - 1
                    If a < 0 Then Exit Sub
                    管理模组.当前正在显示的预览图索引 -= 1
                    管理模组.加载预览图(管理模组.当前项信息_预览图文件表(管理模组.当前正在显示的预览图索引))
                    Form1.ToolTip1.SetToolTip(Form1.PictureBox1, 管理模组.当前正在显示的预览图索引 + 1 & "/" & 管理模组.当前项信息_预览图文件表.Count)
                Case Cursors.PanEast
                    Dim a As Integer = 管理模组.当前正在显示的预览图索引 + 1
                    If a > 管理模组.当前项信息_预览图文件表.Count - 1 Then Exit Sub
                    管理模组.当前正在显示的预览图索引 += 1
                    管理模组.加载预览图(管理模组.当前项信息_预览图文件表(管理模组.当前正在显示的预览图索引))
                    Form1.ToolTip1.SetToolTip(Form1.PictureBox1, 管理模组.当前正在显示的预览图索引 + 1 & "/" & 管理模组.当前项信息_预览图文件表.Count)
            End Select
        End If
    End Sub

    Public Shared Sub PictureBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Select Case Form1.PictureBox1.Cursor
                Case Cursors.PanWest, Cursors.PanEast
                Case Else
                    Process.Start("explorer.exe", 管理模组.当前项信息_预览图文件表(管理模组.当前正在显示的预览图索引))
            End Select
        End If
    End Sub

    Public Shared Sub PictureBox1_MouseWheel(sender As Object, e As MouseEventArgs)
        Select Case e.Delta
            Case > 0
                Dim a As Integer = 管理模组.当前正在显示的预览图索引 - 1
                If a < 0 Then Exit Sub
                管理模组.当前正在显示的预览图索引 -= 1
                管理模组.加载预览图(管理模组.当前项信息_预览图文件表(管理模组.当前正在显示的预览图索引))
                Form1.ToolTip1.SetToolTip(Form1.PictureBox1, 管理模组.当前正在显示的预览图索引 + 1 & "/" & 管理模组.当前项信息_预览图文件表.Count)
            Case < 0
                Dim a As Integer = 管理模组.当前正在显示的预览图索引 + 1
                If a > 管理模组.当前项信息_预览图文件表.Count - 1 Then Exit Sub
                管理模组.当前正在显示的预览图索引 += 1
                管理模组.加载预览图(管理模组.当前项信息_预览图文件表(管理模组.当前正在显示的预览图索引))
                Form1.ToolTip1.SetToolTip(Form1.PictureBox1, 管理模组.当前正在显示的预览图索引 + 1 & "/" & 管理模组.当前项信息_预览图文件表.Count)
        End Select
    End Sub

End Class
