Imports System.IO
Imports System.Text.RegularExpressions

Public Class Form下载并新建项

    Public Shared Property 上一次填写的模组项名称 As String
    Public Shared Property 拖入的链接 As String

    Public Shared Sub 模组项列表视图DragDrop(sender As Object, e As DragEventArgs)
        If DLC.DLC解锁标记.NewItemExtension Then
            If e.Data.GetDataPresent(DataFormats.Text) Then
                拖入的链接 = e.Data.GetData(DataFormats.Text).ToString()
                管理模组的菜单.菜单项_下载并新建项.PerformClick()
            End If
        End If
    End Sub

    Private Sub Form下载并新建项_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To Form1.ListView1.Items.Count - 1
            Me.UiComboBox1.Items.Add(Form1.ListView1.Items(i).Text)
        Next
        If Form1.ListView1.SelectedItems.Count = 1 Then
            Me.UiComboBox1.Text = Form1.ListView1.SelectedItems(0).Text
        End If
        Me.暗黑文本框1.Text = 上一次填写的模组项名称

    End Sub

    Private Sub Form下载并新建项_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If 拖入的链接 <> "" Then
            Me.暗黑文本框2.Text = 处理拖入的链接(拖入的链接)
            拖入的链接 = ""
        End If
        UiComboBox1.Left = 20 * 界面控制.DPI : UiComboBox1.Top = 142 * 界面控制.DPI : UiComboBox1.Width = 344 * 界面控制.DPI : UiComboBox1.Height = 30 * 界面控制.DPI
    End Sub

    Private Sub UiButton28_Click(sender As Object, e As EventArgs) Handles UiButton28.Click
        If Me.暗黑文本框1.Text = "" Then Exit Sub
        If Me.暗黑文本框2.Text = "" Then Exit Sub
        If Me.UiComboBox1.Text = "" Then Exit Sub
        Dim a As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Me.UiComboBox1.Text, Me.暗黑文本框1.Text)

        If FileIO.FileSystem.DirectoryExists(a) Then
            Dim b As New 多项单选对话框("", {"确定"}, "目标模组项已存在，请重新取名",, 500)
            b.ShowDialog(Me)
            Exit Sub
        End If

        FileIO.FileSystem.CreateDirectory(a)
        更新模组.获取NEXUS文件列表(Me.暗黑文本框2.Text, a)
        Me.Close()
    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        If Me.暗黑文本框1.Text = "" Then Exit Sub
        If Me.暗黑文本框2.Text = "" Then Exit Sub
        If Me.UiComboBox1.Text = "" Then Exit Sub
        Dim a As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Me.UiComboBox1.Text, Me.暗黑文本框1.Text)

        If FileIO.FileSystem.DirectoryExists(a) Then
            Dim b As New 多项单选对话框("", {"确定"}, "目标模组项已存在，请重新取名",, 500)
            b.ShowDialog(Me)
            Exit Sub
        End If

        FileIO.FileSystem.CreateDirectory(a)
        更新模组.转到浏览器等待ModDrop下载链接(Me.暗黑文本框2.Text, a)

        Me.Close()
    End Sub

    Private Sub 暗黑文本框1_DragEnter(sender As Object, e As DragEventArgs) Handles 暗黑文本框1.DragEnter
        e.Effect = DragDropEffects.Link
    End Sub

    Private Sub 暗黑文本框1_DragDrop(sender As Object, e As DragEventArgs) Handles 暗黑文本框1.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            暗黑文本框1.Text = e.Data.GetData(DataFormats.Text).ToString()
        End If
    End Sub

    Private Sub 暗黑文本框2_DragEnter(sender As Object, e As DragEventArgs) Handles 暗黑文本框2.DragEnter
        e.Effect = DragDropEffects.Link
    End Sub

    Private Sub 暗黑文本框2_DragDrop(sender As Object, e As DragEventArgs) Handles 暗黑文本框2.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            暗黑文本框2.Text = 处理拖入的链接(e.Data.GetData(DataFormats.Text).ToString())
        End If
    End Sub

    Public Shared Function 处理拖入的链接(原文本 As String) As String
        Dim match As Match = Regex.Match(原文本, "mods/(\d+)")
        If match.Success Then
            Return match.Groups(1).Value
        End If
        Dim match2 As Match = Regex.Match(原文本, "github\.com\/([^\/]+\/[^\/]+)")
        If match2.Success Then
            Return match2.Groups(1).Value
        End If
        Return ""
    End Function

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        If Me.暗黑文本框1.Text = "" Then Exit Sub
        If Me.暗黑文本框2.Text = "" Then Exit Sub
        If Me.UiComboBox1.Text = "" Then Exit Sub
        Dim a As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Me.UiComboBox1.Text, Me.暗黑文本框1.Text)

        If FileIO.FileSystem.DirectoryExists(a) Then
            Dim b As New 多项单选对话框("", {"确定"}, "目标模组项已存在，请重新取名",, 500)
            b.ShowDialog(Me)
            Exit Sub
        End If

        FileIO.FileSystem.CreateDirectory(a)
        更新模组.获取Github文件列表(Me.暗黑文本框2.Text, a)
        Me.Close()
    End Sub
End Class