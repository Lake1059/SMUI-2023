Imports System.ComponentModel
Imports System.IO
Imports Sunny.UI

Public Class Form编辑虚拟组

    Private Sub Form编辑虚拟组_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        暗黑列表视图自绘制.绑定列表视图事件(Me.ListView1)
        暗黑列表视图自绘制.绑定列表视图事件(Me.ListView2)

    End Sub

    Private Sub Form编辑虚拟组_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Panel1.Width = Me.ClientSize.Width * 0.5
        Me.ListView1.Width = Me.ListView1.Parent.Width + 界面控制.程序DPI_垂直滚动条宽度
        Me.ListView2.Width = Me.ListView2.Parent.Width + 界面控制.程序DPI_垂直滚动条宽度
        Me.ColumnHeader1.Width = Me.ListView1.Parent.Width - Me.ListView1.Parent.Padding.Left * 2
        Me.ColumnHeader2.Width = Me.ListView2.Parent.Width - Me.ListView2.Parent.Padding.Left * 2
        Me.UiButton8.Width = UiButton8.Parent.Width * 0.3

        For Each item As String In Form管理虚拟组.虚拟组列表
            Me.ListView2.Items.Add(item)
        Next

        For Each item As ListViewItem In Form1.ListView2.SelectedItems
            Dim 模组项路径 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), item.SubItems(3).Text, item.Text)
            If Not FileIO.FileSystem.FileExists(Path.Combine(模组项路径, "VirtualGroup")) Then Continue For
            Using reader As New StringReader(FileIO.FileSystem.ReadAllText(Path.Combine(模组项路径, "VirtualGroup")))
                Dim line As String = reader.ReadLine()
                While line IsNot Nothing
                    If Not Me.ListView1.ItemExists(line) Then
                        Me.ListView1.Items.Add(line)
                    End If
                    If Not Form管理虚拟组.虚拟组列表.Contains(line) Then
                        Form管理虚拟组.虚拟组列表.Add(line)
                        Me.ListView2.Items.Add(line)
                    End If
                    line = reader.ReadLine()
                End While
            End Using
        Next
    End Sub

    Private Sub Form编辑虚拟组_DpiChanged(sender As Object, e As DpiChangedEventArgs) Handles Me.DpiChanged

    End Sub

    Private Sub Form编辑虚拟组_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub Form编辑虚拟组_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        Me.Panel1.Width = Me.ClientSize.Width * 0.5
        Me.ListView1.Width = Me.ListView1.Parent.Width + 界面控制.程序DPI_垂直滚动条宽度
        Me.ListView2.Width = Me.ListView2.Parent.Width + 界面控制.程序DPI_垂直滚动条宽度
        Me.ColumnHeader1.Width = Me.ListView1.Parent.Width - Me.ListView1.Parent.Padding.Left * 2
        Me.ColumnHeader2.Width = Me.ListView2.Parent.Width - Me.ListView2.Parent.Padding.Left * 2
        Me.UiButton8.Width = UiButton8.Parent.Width * 0.3
    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        For Each item As ListViewItem In Form1.ListView2.SelectedItems
            Dim 虚拟组文件路径 = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), item.SubItems(3).Text, item.Text, "VirtualGroup")
            If ListView1.Items.Count = 0 Then
                If FileIO.FileSystem.FileExists(虚拟组文件路径) Then FileIO.FileSystem.DeleteFile(虚拟组文件路径)
            Else
                Dim 当前模组项的虚拟组列表 As New List(Of String)
                If FileIO.FileSystem.FileExists(虚拟组文件路径) Then
                    Using reader As New StringReader(FileIO.FileSystem.ReadAllText(虚拟组文件路径))
                        Dim line = reader.ReadLine
                        While line IsNot Nothing
                            当前模组项的虚拟组列表.Add(line)
                            line = reader.ReadLine
                        End While
                    End Using
                End If
                For Each newitem As ListViewItem In ListView1.Items
                    If Not 当前模组项的虚拟组列表.Contains(newitem.Text) Then 当前模组项的虚拟组列表.Add(newitem.Text)
                Next
                FileIO.FileSystem.WriteAllText(虚拟组文件路径, String.Join(Environment.NewLine, 当前模组项的虚拟组列表), False)
            End If
        Next
        Close()
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        Dim 当前模组项的虚拟组列表 As New List(Of String)
        For Each newitem As ListViewItem In ListView1.Items
            当前模组项的虚拟组列表.Add(newitem.Text)
        Next
        For Each item As ListViewItem In Form1.ListView2.SelectedItems
            Dim 虚拟组文件路径 = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), item.SubItems(3).Text, item.Text, "VirtualGroup")
            If ListView1.Items.Count = 0 Then
                If FileIO.FileSystem.FileExists(虚拟组文件路径) Then FileIO.FileSystem.DeleteFile(虚拟组文件路径)
            Else
                FileIO.FileSystem.WriteAllText(虚拟组文件路径, String.Join(Environment.NewLine, 当前模组项的虚拟组列表), False)
            End If
        Next
        Close()
    End Sub

    Private Sub UiButton3_Click(sender As Object, e As EventArgs) Handles UiButton3.Click
        For Each item As ListViewItem In Me.ListView2.SelectedItems
            If Not Me.ListView1.ItemExists(item.Text) Then Me.ListView1.Items.Add(item.Text)
        Next
    End Sub

    Private Sub UiButton4_Click(sender As Object, e As EventArgs) Handles UiButton4.Click
        For Each item As ListViewItem In Me.ListView2.Items
            If Not Me.ListView1.ItemExists(item.Text) Then Me.ListView1.Items.Add(item.Text)
        Next
    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged
    End Sub

    Private Sub ListView2_DoubleClick(sender As Object, e As EventArgs) Handles ListView2.DoubleClick
        Me.UiButton3.PerformClick()
    End Sub

    Private Sub UiButton7_Click(sender As Object, e As EventArgs) Handles UiButton7.Click
        Dim a As New 输入对话框("", "输入新的虚拟组名称，如果已存在则不会添加")
        a.TranslateButtonText("添加", "取消")
        Dim b As String = a.ShowDialog(Me)
        If b = "" Then Me.ListView1.Focus() : Exit Sub
        If Me.ListView1.ItemExists(b) Then Me.ListView1.Focus() : Exit Sub
        Me.ListView1.Items.Add(b)
        Me.ListView1.Focus()
    End Sub

    Private Sub UiButton6_Click(sender As Object, e As EventArgs) Handles UiButton6.Click
        If Me.ListView1.SelectedIndices.Count > 0 Then
            For i = 0 To Me.ListView1.SelectedIndices.Count - 1
                Dim index As Integer = Me.ListView1.SelectedIndices(i)
                If index > 0 Then
                    If Me.ListView1.SelectedIndices.Contains(index - 1) Then Continue For
                    Dim 变动排序的列表视图项 As ListViewItem = Me.ListView1.Items(index)
                    Me.ListView1.Items.RemoveAt(index)
                    Me.ListView1.Items.Insert(index - 1, 变动排序的列表视图项)
                    Me.ListView1.Items(index - 1).Focused = True
                End If
            Next
        End If
    End Sub

    Private Sub UiButton5_Click(sender As Object, e As EventArgs) Handles UiButton5.Click
        If Me.ListView1.SelectedIndices.Count > 0 Then
            For i = 0 To Me.ListView1.SelectedIndices.Count - 1 Step -1
                Dim index As Integer = Me.ListView1.SelectedIndices(i)
                If index < Me.ListView1.Items.Count - 1 Then
                    If Me.ListView1.SelectedIndices.Contains(index + 1) Then Continue For
                    Dim 变动排序的列表视图项 As ListViewItem = Me.ListView1.Items(index)
                    Me.ListView1.Items.RemoveAt(index)
                    Me.ListView1.Items.Insert(index + 1, 变动排序的列表视图项)
                    Me.ListView1.Items(index + 1).Focused = True
                End If
            Next
        End If
    End Sub

    Private Sub UiButton9_Click(sender As Object, e As EventArgs) Handles UiButton9.Click
        Dim i As Integer = 0
        Do Until i = Me.ListView1.Items.Count
            If Me.ListView1.Items(i).Selected Then
                Me.ListView1.Items(i).Remove()
                i -= 1
            End If
            i += 1
        Loop
    End Sub

    Private Sub UiButton8_Click(sender As Object, e As EventArgs) Handles UiButton8.Click
        For Each item As ListViewItem In Form1.ListView2.SelectedItems
            Dim 虚拟组文件路径 = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), item.SubItems(3).Text, item.Text, "VirtualGroup")
            If ListView1.Items.Count = 0 Then
                If FileIO.FileSystem.FileExists(虚拟组文件路径) Then FileIO.FileSystem.DeleteFile(虚拟组文件路径)
            Else
                Dim 当前模组项的虚拟组列表 As New List(Of String)
                If FileIO.FileSystem.FileExists(虚拟组文件路径) Then
                    Using reader As New StringReader(FileIO.FileSystem.ReadAllText(虚拟组文件路径))
                        Dim line = reader.ReadLine
                        While line IsNot Nothing
                            当前模组项的虚拟组列表.Add(line)
                            line = reader.ReadLine
                        End While
                    End Using
                End If
                For Each newitem As ListViewItem In ListView1.Items
                    If 当前模组项的虚拟组列表.Contains(newitem.Text) Then 当前模组项的虚拟组列表.Remove(newitem.Text)
                Next
                FileIO.FileSystem.WriteAllText(虚拟组文件路径, String.Join(Environment.NewLine, 当前模组项的虚拟组列表), False)
            End If
        Next
        Close()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        Select Case e.KeyCode
            Case Keys.A
                If e.Control Then Me.UiButton7.PerformClick()
            Case Keys.F3
                Me.UiButton6.PerformClick()
            Case Keys.F4
                Me.UiButton5.PerformClick()
            Case Keys.Delete
                Me.UiButton9.PerformClick()
        End Select

    End Sub
End Class