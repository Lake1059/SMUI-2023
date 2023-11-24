Imports System.ComponentModel

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        界面控制.初始化界面()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub

    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing

    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

    End Sub
End Class
