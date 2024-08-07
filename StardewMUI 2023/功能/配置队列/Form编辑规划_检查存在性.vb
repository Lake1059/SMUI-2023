Public Class Form编辑规划_检查存在性
    Private Sub Form编辑规划_检查存在性_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form编辑规划_检查存在性_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.UiRadioButton1.RadioButtonSize = 20 * 界面控制.DPI
        Me.UiRadioButton2.RadioButtonSize = 20 * 界面控制.DPI
        Me.UiRadioButton3.RadioButtonSize = 20 * 界面控制.DPI
        Me.UiRadioButton4.RadioButtonSize = 20 * 界面控制.DPI
        Me.UiRadioButton5.RadioButtonSize = 20 * 界面控制.DPI
        Me.UiRadioButton6.RadioButtonSize = 20 * 界面控制.DPI
        Me.UiRadioButton7.RadioButtonSize = 20 * 界面控制.DPI
    End Sub

    Private Sub Form编辑规划_检查存在性_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        If UiRadioButton1.Checked Then 配置队列的规划编辑.来自_检查存在性_在安装还是卸载中进行 = "Install"
        If UiRadioButton2.Checked Then 配置队列的规划编辑.来自_检查存在性_在安装还是卸载中进行 = "UnInstall"
        If UiRadioButton7.Checked Then 配置队列的规划编辑.来自_检查存在性_在安装还是卸载中进行 = "All"
        If UiRadioButton3.Checked = True Then 配置队列的规划编辑.来自_检查存在性_文件夹还是文件 = "Folder"
        If UiRadioButton4.Checked = True Then 配置队列的规划编辑.来自_检查存在性_文件夹还是文件 = "File"
        If UiRadioButton5.Checked = True Then 配置队列的规划编辑.来自_检查存在性_要存在还是不存在 = "True"
        If UiRadioButton6.Checked = True Then 配置队列的规划编辑.来自_检查存在性_要存在还是不存在 = "False"
        配置队列的规划编辑.来自_检查存在性_填写的相对路径 = Me.UiTextBox1.Text.Split(New String() {vbCrLf, vbLf, vbCr}, StringSplitOptions.None).ToList
        Me.Close()
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        配置队列的规划编辑.来自_检查存在性_填写的相对路径.Clear()
    End Sub

    Public 正在判断文件夹还是文件 As String = ""

    Private Sub UiButton3_Click(sender As Object, e As EventArgs) Handles UiButton3.Click
        Dim a As New 暗黑菜单条控件本体
        For i = 0 To Form1.ListView6.Items.Count - 1
            Dim x As New ToolStripMenuItem With {.Text = Form1.ListView6.Items(i).Text}
            AddHandler x.Click, Sub(s1, e1) Me.UiTextBox1.Text &= s1.Text
            a.Items.Add(x)
        Next
        a.Show(MousePosition)
    End Sub
End Class