Imports System.IO

Public Class Form编辑规划_运行可执行文件
    Private Sub Form编辑规划_运行可执行文件_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form编辑规划_运行可执行文件_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.UiCheckBox1.CheckBoxSize = 20 * 界面控制.DPI
    End Sub

    Private Sub Form编辑规划_运行可执行文件_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        If UiRadioButton1.Checked Then 配置队列的规划编辑.来自_运行可执行文件_在安装还是卸载中进行 = "Install"
        If UiRadioButton2.Checked Then 配置队列的规划编辑.来自_运行可执行文件_在安装还是卸载中进行 = "UnInstall"
        If UiRadioButton7.Checked Then 配置队列的规划编辑.来自_运行可执行文件_在安装还是卸载中进行 = "All"
        配置队列的规划编辑.来自_运行可执行文件_可执行文件 = Me.暗黑文本框1.Text
        配置队列的规划编辑.来自_运行可执行文件_传递参数 = Me.暗黑文本框2.Text
        配置队列的规划编辑.来自_运行可执行文件_是否等待 = Me.UiCheckBox1.Checked
        Me.Close()
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        配置队列的规划编辑.来自_运行可执行文件_可执行文件 = ""
    End Sub

    Private Sub UiButton3_Click(sender As Object, e As EventArgs) Handles UiButton3.Click
        Dim a As New 暗黑菜单条控件本体
        For i = 0 To Form1.ListView6.Items.Count - 1
            Select Case Path.GetExtension(Form1.ListView6.Items(i).Text)
                Case ".exe", ".bat", ".ps1", ".cmd"
                    Dim x As New ToolStripMenuItem With {.Text = Form1.ListView6.Items(i).Text}
                    AddHandler x.Click, Sub(s1, e1) Me.暗黑文本框1.Text &= s1.Text
                    a.Items.Add(x)
            End Select
        Next
        a.Show(MousePosition)
    End Sub
End Class