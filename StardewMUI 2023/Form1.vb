Imports System.ComponentModel

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        界面控制.初始化界面()
        设置.启动时加载设置()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub

    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        键值对IO操作.从字典键值对写入文件(设置.全局设置数据, 设置.设置文件存储路径)
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

    End Sub

    Private Sub Form1_DpiChanged(sender As Object, e As DpiChangedEventArgs) Handles MyBase.DpiChanged
        Dim a As New 多项单选对话框("DPI 变化", {"立即重启应用程序（推荐）", "稍后自行重启"}, "SMUI 6 的高 DPI 支持被设计为仅在启动时计算，当中途更改 DPI 时会导致界面错位以及破碎，此时继续使用可能会导致无法预知的故障，建议重新启动应用程序，如果还有尚未保存的工作请先保存后再重启", 150, 500)
        If a.ShowDialog = 0 Then Application.Restart
    End Sub
End Class
