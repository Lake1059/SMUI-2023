﻿Public Class Form编辑规划_复制文件夹
    Private Sub Form编辑规划_复制文件夹_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        界面控制.初始化其他列表视图(Me.ListView1)
        调整界面()
    End Sub

    Private Sub Form编辑规划_复制文件夹_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        调整界面()
    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        If Me.ListView1.SelectedItems.Count <> 1 Then Exit Sub
        配置队列的规划编辑.来自_复制文件夹_所选的文件夹 = Me.ListView1.SelectedItems(0).Text
        配置队列的规划编辑.来自_复制文件夹_目标文件夹相对路径 = Me.UiTextBox1.Text
        Me.Close()
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        配置队列的规划编辑.来自_复制文件夹_所选的文件夹 = Me.ListView1.SelectedItems(0).Text
        配置队列的规划编辑.来自_复制文件夹_目标文件夹相对路径 = Me.UiTextBox1.Text
    End Sub

    Private Sub UiButton3_Click(sender As Object, e As EventArgs) Handles UiButton3.Click

    End Sub

    Public Sub 调整界面()
        Me.ListView1.Width = Me.ListView1.Parent.Width - Me.ListView1.Parent.Padding.Left + 界面控制.程序DPI_垂直滚动条宽度
        Me.ColumnHeader1.Width = Me.ListView1.Parent.Width - Me.ListView1.Parent.Padding.Left * 2
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        UiButton1.PerformClick()
    End Sub
End Class