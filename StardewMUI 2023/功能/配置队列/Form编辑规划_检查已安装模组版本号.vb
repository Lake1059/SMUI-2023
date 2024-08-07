Imports System.IO
Imports Sunny.UI

Public Class Form编辑规划_检查已安装模组版本号
    Private Sub Form编辑规划_检查已安装模组版本号_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form编辑规划_检查已安装模组版本号_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub Form编辑规划_检查已安装模组版本号_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.UiComboBox1.Width = 200 * 界面控制.DPI
        Me.UiComboBox1.Height = 30 * 界面控制.DPI
        Me.UiComboBox1.Left = 19 * 界面控制.DPI
        Me.UiComboBox1.Top = 136 * 界面控制.DPI
        Me.UiComboBox1.ItemHeight = 30 * 界面控制.DPI
    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        配置队列的规划编辑.来自_检查已安装模组版本_判断符号 = UiComboBox1.Text
        配置队列的规划编辑.来自_检查已安装模组版本_版本号 = 暗黑文本框2.Text
        配置队列的规划编辑.来自_检查已安装模组版本_指定模组文件夹 = 暗黑文本框1.Text
        Me.Close()
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        配置队列的规划编辑.来自_检查已安装模组版本_指定模组文件夹 = ""
    End Sub

    Private Sub UiButton3_Click(sender As Object, e As EventArgs) Handles UiButton3.Click
        Dim str1 As String = ""
        If DirEx.SelectDirEx("选择文件夹", str1) Then
            Me.暗黑文本框1.Text &= Path.GetFileName(str1)
        End If
    End Sub

End Class