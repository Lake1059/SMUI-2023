
Public Class Form编辑规划_安装单个文件
    Private Sub Form编辑规划_安装单个文件_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form编辑规划_安装单个文件_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.UiRadioButton1.RadioButtonSize = 20 * 界面控制.DPI
        Me.UiRadioButton2.RadioButtonSize = 20 * 界面控制.DPI
        Me.UiRadioButton3.RadioButtonSize = 20 * 界面控制.DPI
        Me.UiRadioButton4.RadioButtonSize = 20 * 界面控制.DPI
        Me.UiRadioButton5.RadioButtonSize = 20 * 界面控制.DPI
        Me.UiRadioButton6.RadioButtonSize = 20 * 界面控制.DPI
    End Sub

    Private Sub Form编辑规划_安装单个文件_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        配置队列的规划编辑.来自_安装单个文件_要安装哪个文件 = 暗黑文本框1.Text
        配置队列的规划编辑.来自_安装单个文件_目标位置 = 暗黑文本框2.Text
        配置队列的规划编辑.来自_安装单个文件_卸载时是否还原 = UiRadioButton1.Checked
        配置队列的规划编辑.来自_安装单个文件_是否判断安装情况 = UiRadioButton3.Checked
        配置队列的规划编辑.来自_安装单个文件_是否验证SHA256 = UiRadioButton5.Checked
        Me.Close()
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        配置队列的规划编辑.来自_安装单个文件_要安装哪个文件 = ""
    End Sub

    Private Sub UiButton3_Click(sender As Object, e As EventArgs) Handles UiButton3.Click
        Dim a As New 暗黑菜单条控件本体
        For i = 0 To Form1.ListView6.Items.Count - 1
            If Form1.ListView6.Items(i).SubItems(1).Text = "文件" Then
                Dim x As New ToolStripMenuItem With {.Text = Form1.ListView6.Items(i).Text}
                AddHandler x.Click, Sub(s1, e1) Me.暗黑文本框1.Text &= s1.Text
                a.Items.Add(x)
            End If
        Next
        a.Show(MousePosition)
    End Sub

    Private Sub UiButton4_Click(sender As Object, e As EventArgs) Handles UiButton4.Click
        Dim a As New 暗黑菜单条控件本体
        For i = 0 To Form1.ListView6.Items.Count - 1
            If Form1.ListView6.Items(i).SubItems(1).Text = "文件" Then
                Dim x As New ToolStripMenuItem With {.Text = Form1.ListView6.Items(i).Text}
                AddHandler x.Click, Sub(s1, e1) Me.暗黑文本框2.Text &= s1.Text
                a.Items.Add(x)
            End If
        Next
        a.Show(MousePosition)
    End Sub
End Class