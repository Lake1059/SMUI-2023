Imports Sunny.UI

Public Class Form编辑规划_弹窗
    Private Sub Form编辑规划_弹窗_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form编辑规划_弹窗_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub Form编辑规划_弹窗_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        If UiRadioButton1.Checked Then 配置队列的规划编辑.来自_弹窗_在安装还是卸载中 = "Install"
        If UiRadioButton2.Checked Then 配置队列的规划编辑.来自_弹窗_在安装还是卸载中 = "UnInstall"
        If UiRadioButton7.Checked Then 配置队列的规划编辑.来自_弹窗_在安装还是卸载中 = "All"
        配置队列的规划编辑.来自_弹窗_标题栏 = 暗黑文本框1.Text
        配置队列的规划编辑.来自_弹窗_描述 = 暗黑文本框2.Text
        配置队列的规划编辑.来自_弹窗_是否要正确 = UiCheckBox1.Checked
        If UiNumPadTextBox1.Text.IsNumber Then 配置队列的规划编辑.来自_弹窗_正确序号 = UiNumPadTextBox1.Text
        配置队列的规划编辑.来自_弹窗_选择项 = Me.UiTextBox1.Text.Split(New String() {vbCrLf, vbLf, vbCr}, StringSplitOptions.None).ToList
        Me.Close()
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        配置队列的规划编辑.来自_弹窗_选择项.Clear()
    End Sub
End Class