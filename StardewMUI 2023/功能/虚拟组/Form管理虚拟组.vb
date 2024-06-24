Imports System.ComponentModel
Imports System.IO
Imports Sunny.UI

Public Class Form管理虚拟组
    Private Sub Form管理虚拟组_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        暗黑列表视图自绘制.绑定列表视图事件(Me.ListView1)

    End Sub

    Private Sub Form管理虚拟组_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.ListView1.Width = Me.ListView1.Parent.Width + 界面控制.程序DPI_垂直滚动条宽度
        Me.ColumnHeader1.Width = Me.ListView1.Parent.Width - Me.ListView1.Parent.Padding.Left * 2

        If 虚拟组列表.Count > 0 Then
            For Each item As String In 虚拟组列表
                Me.ListView1.Items.Add(item)
            Next
        End If

    End Sub

    Private Sub Form管理虚拟组_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        Me.ListView1.Width = Me.ListView1.Parent.Width + 界面控制.程序DPI_垂直滚动条宽度
        Me.ColumnHeader1.Width = Me.ListView1.Parent.Width - Me.ListView1.Parent.Padding.Left * 2
    End Sub

    Private Sub Form管理虚拟组_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Public Shared Property 虚拟组列表 As New List(Of String)

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        Try
            虚拟组列表.Clear()
            Me.ListView1.Items.Clear()
            Dim mDir As DirectoryInfo
            Dim mDirInfo As New DirectoryInfo(管理模组2.检查并返回当前所选子库路径(False))
            For Each mDir In mDirInfo.GetDirectories
                Dim mDir2 As DirectoryInfo
                Dim mDirInfo2 As New DirectoryInfo(mDir.FullName)
                For Each mDir2 In mDirInfo2.GetDirectories
                    If Not FileIO.FileSystem.FileExists(Path.Combine(mDir2.FullName, "VirtualGroup")) Then Continue For
                    Using reader As New StringReader(FileIO.FileSystem.ReadAllText(Path.Combine(mDir2.FullName, "VirtualGroup")))
                        Dim line As String = reader.ReadLine()
                        While line IsNot Nothing
                            If Not 虚拟组列表.Contains(line) Then 虚拟组列表.Add(line)
                            line = reader.ReadLine()
                        End While
                    End Using
                Next
            Next
            For Each gitem In 虚拟组列表
                Me.ListView1.Items.Add(gitem)
            Next
        Catch ex As Exception
            DebugPrint(ex.Message, Color1.红色)
            UIMessageTip.Show(ex.Message,, 2000)
        End Try
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        If Not PromptForWindowsCredentials(Me.Handle, "继续执行此操作需要验证你的身份", "SMUI 6 正在批量删除虚拟组") Then Exit Sub
        Try
            Dim mDir As DirectoryInfo
            Dim mDirInfo As New DirectoryInfo(管理模组2.检查并返回当前所选子库路径(False))
            For Each mDir In mDirInfo.GetDirectories
                Dim mDir2 As DirectoryInfo
                Dim mDirInfo2 As New DirectoryInfo(mDir.FullName)
                For Each mDir2 In mDirInfo2.GetDirectories
                    If Not FileIO.FileSystem.FileExists(Path.Combine(mDir2.FullName, "VirtualGroup")) Then Continue For
                    Dim 当前模组项的虚拟组列表 As New List(Of String)
                    Using reader As New StringReader(FileIO.FileSystem.ReadAllText(Path.Combine(mDir2.FullName, "VirtualGroup")))
                        Dim line As String = reader.ReadLine()
                        While line IsNot Nothing
                            当前模组项的虚拟组列表.Add(line)
                            line = reader.ReadLine()
                        End While
                    End Using
                    For Each item As ListViewItem In Me.ListView1.SelectedItems
                        If 当前模组项的虚拟组列表.Contains(item.Text) Then
                            当前模组项的虚拟组列表.Remove(item.Text)
                        End If
                    Next
                    If 当前模组项的虚拟组列表.Count > 0 Then
                        FileIO.FileSystem.WriteAllText(Path.Combine(mDir2.FullName, "VirtualGroup"), String.Join(Environment.NewLine, 当前模组项的虚拟组列表), False)
                    Else
                        FileIO.FileSystem.DeleteFile(Path.Combine(mDir2.FullName, "VirtualGroup"))
                    End If
                Next
            Next
            Dim i As Integer = 0
            Do Until i = Me.ListView1.Items.Count
                If Me.ListView1.Items(i).Selected Then
                    虚拟组列表.Remove(Me.ListView1.Items(i).Text)
                    Me.ListView1.Items(i).Remove()
                    i -= 1
                End If
                i += 1
            Loop
            UIMessageTip.Show("已删除",, 2500)
        Catch ex As Exception
            DebugPrint(ex.Message, Color1.红色)
            UIMessageTip.Show(ex.Message,, 2000)
        End Try
    End Sub

    Private Sub UiButton3_Click(sender As Object, e As EventArgs) Handles UiButton3.Click
        If Me.ListView1.SelectedItems.Count = 0 Then Exit Sub
        管理模组.清除模组项列表()
        Try
            Dim mDir As DirectoryInfo
            Dim mDirInfo As New DirectoryInfo(管理模组2.检查并返回当前所选子库路径(False))
            For Each mDir In mDirInfo.GetDirectories
                Dim mDir2 As DirectoryInfo
                Dim mDirInfo2 As New DirectoryInfo(mDir.FullName)
                For Each mDir2 In mDirInfo2.GetDirectories
                    If Not FileIO.FileSystem.FileExists(Path.Combine(mDir2.FullName, "VirtualGroup")) Then Continue For
                    Dim 当前模组项的虚拟组列表 As New List(Of String)
                    Using reader As New StringReader(FileIO.FileSystem.ReadAllText(Path.Combine(mDir2.FullName, "VirtualGroup")))
                        Dim line As String = reader.ReadLine()
                        While line IsNot Nothing
                            当前模组项的虚拟组列表.Add(line)
                            line = reader.ReadLine()
                        End While
                    End Using

                    For Each item As ListViewItem In Me.ListView1.SelectedItems
                        If Not 当前模组项的虚拟组列表.Contains(item.Text) Then
                            GoTo jx1
                        End If
                    Next

                    For Each item As String In 当前模组项的虚拟组列表
                        Dim i3 As ListViewItem = Me.ListView1.Items.Find(item, False).FirstOrDefault
                        If i3 Is Nothing Then GoTo jx1
                        If Not i3.Checked Then GoTo jx1
                    Next

                    Form1.ListView2.Items.Add(Path.GetFileName(mDir2.FullName))
                    Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add("")
                    Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add("")
                    Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add(Path.GetFileName(Path.GetDirectoryName(mDir2.FullName)))
jx1：
                Next
            Next
        Catch ex As Exception
            DebugPrint(ex.Message, Color1.红色)
            UIMessageTip.Show(ex.Message,, 2000)
        End Try
        Form1.Label51.Text = Form1.ListView2.Items.Count
        管理模组.刷新项列表数据()
    End Sub

    Private Sub UiButton4_Click(sender As Object, e As EventArgs) Handles UiButton4.Click
        If Me.ListView1.SelectedItems.Count = 0 Then Exit Sub
        管理模组.清除模组项列表()
        Try
            Dim mDir As DirectoryInfo
            Dim mDirInfo As New DirectoryInfo(管理模组2.检查并返回当前所选子库路径(False))
            For Each mDir In mDirInfo.GetDirectories
                Dim mDir2 As DirectoryInfo
                Dim mDirInfo2 As New DirectoryInfo(mDir.FullName)
                For Each mDir2 In mDirInfo2.GetDirectories
                    If Not FileIO.FileSystem.FileExists(Path.Combine(mDir2.FullName, "VirtualGroup")) Then Continue For
                    Dim 当前模组项的虚拟组列表 As New List(Of String)
                    Using reader As New StringReader(FileIO.FileSystem.ReadAllText(Path.Combine(mDir2.FullName, "VirtualGroup")))
                        Dim line As String = reader.ReadLine()
                        While line IsNot Nothing
                            当前模组项的虚拟组列表.Add(line)
                            line = reader.ReadLine()
                        End While
                    End Using

                    For Each item As ListViewItem In Me.ListView1.SelectedItems
                        If Not 当前模组项的虚拟组列表.Contains(item.Text) Then
                            GoTo jx1
                        End If
                    Next

                    Form1.ListView2.Items.Add(Path.GetFileName(mDir2.FullName))
                    Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add("")
                    Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add("")
                    Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add(Path.GetFileName(Path.GetDirectoryName(mDir2.FullName)))
jx1:
                Next
            Next
        Catch ex As Exception
            DebugPrint(ex.Message, Color1.红色)
            UIMessageTip.Show(ex.Message,, 2000)
        End Try
        Form1.Label51.Text = Form1.ListView2.Items.Count
        管理模组.刷新项列表数据()
    End Sub

    Private Sub UiButton5_Click(sender As Object, e As EventArgs) Handles UiButton5.Click
        If Me.ListView1.SelectedItems.Count = 0 Then Exit Sub
        管理模组.清除模组项列表()
        Try
            Dim mDir As DirectoryInfo
            Dim mDirInfo As New DirectoryInfo(管理模组2.检查并返回当前所选子库路径(False))
            For Each mDir In mDirInfo.GetDirectories
                Dim mDir2 As DirectoryInfo
                Dim mDirInfo2 As New DirectoryInfo(mDir.FullName)
                For Each mDir2 In mDirInfo2.GetDirectories
                    If Not FileIO.FileSystem.FileExists(Path.Combine(mDir2.FullName, "VirtualGroup")) Then Continue For
                    Dim 当前模组项的虚拟组列表 As New List(Of String)
                    Using reader As New StringReader(FileIO.FileSystem.ReadAllText(Path.Combine(mDir2.FullName, "VirtualGroup")))
                        Dim line As String = reader.ReadLine()
                        While line IsNot Nothing
                            当前模组项的虚拟组列表.Add(line)
                            line = reader.ReadLine()
                        End While
                    End Using

                    For Each item As ListViewItem In Me.ListView1.SelectedItems
                        If 当前模组项的虚拟组列表.Contains(item.Text) Then
                            GoTo jx1
                        End If
                    Next

                    Form1.ListView2.Items.Add(Path.GetFileName(mDir2.FullName))
                    Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add("")
                    Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add("")
                    Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add(Path.GetFileName(Path.GetDirectoryName(mDir2.FullName)))
jx1:
                Next
            Next
        Catch ex As Exception
            DebugPrint(ex.Message, Color1.红色)
            UIMessageTip.Show(ex.Message,, 2000)
        End Try
        Form1.Label51.Text = Form1.ListView2.Items.Count
        管理模组.刷新项列表数据()
    End Sub

    Private Sub UiButton8_Click(sender As Object, e As EventArgs) Handles UiButton8.Click
        Me.ListView1.Sorting = SortOrder.Ascending
        Me.ListView1.Sorting = SortOrder.None
    End Sub

    Private Sub UiButton9_Click(sender As Object, e As EventArgs) Handles UiButton9.Click
        Me.ListView1.Sorting = SortOrder.Descending
        Me.ListView1.Sorting = SortOrder.None
    End Sub


End Class