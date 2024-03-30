Public Class Form编辑规划_复制文件夹

    Dim MyDPI As Integer = Me.CreateGraphics.DpiX / 96

    Private Sub Form编辑规划_复制文件夹_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        界面控制.初始化其他列表视图(Me.ListView1)
        调整界面()
        If MyDPI <> 1 Then DPI兼容调整()
    End Sub

    Private Sub Form编辑规划_复制文件夹_Shown(sender As Object, e As EventArgs) Handles Me.Shown

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
        配置队列的规划编辑.来自_复制文件夹_所选的文件夹 = ""
        配置队列的规划编辑.来自_复制文件夹_目标文件夹相对路径 = ""
    End Sub

    Private Sub UiButton3_Click(sender As Object, e As EventArgs) Handles UiButton3.Click
        If Me.ListView1.SelectedItems.Count <> 1 Then Exit Sub
        Me.UiTextBox1.Text &= Me.ListView1.SelectedItems(0).Text
    End Sub

    Public Sub 调整界面()
        Me.ListView1.Width = Me.ListView1.Parent.Width - Me.ListView1.Parent.Padding.Left + 30 * MyDPI
        Me.ColumnHeader1.Width = Me.ListView1.Parent.Width - Me.ListView1.Parent.Padding.Left * 2
    End Sub

    Public Sub DPI兼容调整()
        Me.MinimumSize = New Size(500 * MyDPI, 500 * MyDPI)
        Me.Size = Me.MinimumSize
        Me.ImageList1.ImageSize = New Size(1, 29 * MyDPI)
        Me.UiTextBox1.Left = 19 * MyDPI : Me.UiTextBox1.Top = 353 * MyDPI : Me.UiTextBox1.Width = 446 * MyDPI : Me.UiTextBox1.Height = 30 * MyDPI
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        UiButton1.PerformClick()
    End Sub

    Private Sub Form编辑规划_复制文件夹_DpiChanged(sender As Object, e As DpiChangedEventArgs) Handles Me.DpiChanged
        MyDPI = e.DeviceDpiNew / 96
        DPI兼容调整()
    End Sub

End Class