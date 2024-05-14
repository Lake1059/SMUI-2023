Imports System.IO

Public Class Form从管理器下载触发下载

    Public Property 模组ID As String
    Public Property 文件ID As String
    Public Property Key As String
    Public Property Expires As String



    Private Sub Form从管理器下载触发下载_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To Form1.ListView1.Items.Count - 1
            Me.UiComboBox1.Items.Add(Form1.ListView1.Items(i).Text)
        Next
        If Form1.ListView1.SelectedItems.Count = 1 Then
            Me.UiComboBox1.Text = Form1.ListView1.SelectedItems(0).Text
        End If
        Me.Label1.Text = "模组：" & 模组ID & " 文件：" & 文件ID
        Me.Label2.Text = Key & "  - " & Expires

    End Sub

    Private Async Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        If Me.暗黑文本框1.Text = "" Then Exit Sub
        If Me.UiComboBox1.Text = "" Then Exit Sub
        Dim a As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Me.UiComboBox1.Text, Me.暗黑文本框1.Text)

        If FileIO.FileSystem.DirectoryExists(a) Then
            Dim b As New 多项单选对话框("", {"确定"}, "目标模组项已存在，请重新取名",, 500)
            b.ShowDialog(Me)
            Exit Sub
        End If

        FileIO.FileSystem.CreateDirectory(a)
        If Await 更新模组.获取服务器列表(模组ID, 文件ID, a, Me.Label5, Key, Expires) Then Me.Dispose()
    End Sub



End Class