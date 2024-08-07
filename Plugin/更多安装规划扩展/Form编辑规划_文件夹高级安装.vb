
Imports System.Windows.Forms
Imports SMUI6

Public Class Form编辑规划_文件夹高级安装
    Private Sub Form编辑规划_文件夹高级安装_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form编辑规划_文件夹高级安装_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        UiRadioButton1.RadioButtonSize = 20 * 界面控制.DPI
        UiRadioButton2.RadioButtonSize = 20 * 界面控制.DPI
        UiRadioButton3.RadioButtonSize = 20 * 界面控制.DPI
        UiRadioButton4.RadioButtonSize = 20 * 界面控制.DPI
    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        If UiRadioButton1.Checked Then Entry.来自_文件夹高级安装_卸载时如何操作 = "ReStore"
        If UiRadioButton2.Checked Then Entry.来自_文件夹高级安装_卸载时如何操作 = "Delete"
        If UiRadioButton3.Checked Then Entry.来自_文件夹高级安装_还原方式 = "Delete-Copy"
        If UiRadioButton4.Checked Then Entry.来自_文件夹高级安装_还原方式 = "Cover"
        If Entry.来自_文件夹高级安装_卸载时如何操作 = "" Then Entry.来自_文件夹高级安装_卸载时如何操作 = "Delete"
        If Entry.来自_文件夹高级安装_还原方式 = "" Then Entry.来自_文件夹高级安装_还原方式 = "Null"
        Entry.来自_文件夹高级安装_要安装哪个文件夹 = 暗黑文本框1.Text
        Entry.来自_文件夹高级安装_目标位置 = 暗黑文本框2.Text
        Me.Close()
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        Entry.来自_文件夹高级安装_要安装哪个文件夹 = ""
    End Sub

    Private Sub UiButton3_Click(sender As Object, e As EventArgs) Handles UiButton3.Click
        Dim a As New 暗黑菜单条控件本体
        Dim b = SMUI6.PluginAPI.添加安装规划.获取项内容中的文件夹列表
        For i = 0 To b.Count - 1
            Dim x As New ToolStripMenuItem With {.Text = b(i)}
            AddHandler x.Click, Sub(s1, e1) Me.暗黑文本框1.Text &= s1.Text
            a.Items.Add(x)
        Next
        a.Show(MousePosition)
    End Sub

    Private Sub UiButton4_Click(sender As Object, e As EventArgs) Handles UiButton4.Click
        Dim a As New 暗黑菜单条控件本体
        Dim b = SMUI6.PluginAPI.添加安装规划.获取项内容中的文件夹列表
        For i = 0 To b.Count - 1
            Dim x As New ToolStripMenuItem With {.Text = b(i)}
            AddHandler x.Click, Sub(s1, e1) Me.暗黑文本框2.Text &= s1.Text
            a.Items.Add(x)
        Next
        a.Show(MousePosition)
    End Sub

End Class