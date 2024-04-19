Public Class Form编辑规划_检查存在性
    Private Sub Form编辑规划_检查存在性_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form编辑规划_检查存在性_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub Form编辑规划_检查存在性_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        配置队列的规划编辑.来自_检查存在性_填写的相对路径 = Me.暗黑文本框1.Text
        If Me.UiRadioButton1.Checked Then
            配置队列的规划编辑.来自_检查存在性_要存在还是不存在 = True
        Else
            配置队列的规划编辑.来自_检查存在性_要存在还是不存在 = False
        End If
        Me.Close()
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        配置队列的规划编辑.来自_检查存在性_填写的相对路径 = ""
    End Sub

    Public 正在判断文件夹还是文件 As String = ""

    Private Sub UiButton3_Click(sender As Object, e As EventArgs) Handles UiButton3.Click
        Dim a As New 暗黑菜单条控件本体
        For i = 0 To Form1.ListView6.Items.Count - 1
            Select Case 正在判断文件夹还是文件
                Case "文件夹"
                    If Form1.ListView6.Items(i).SubItems(1).Text = "文件夹" Then
                        Dim x As New ToolStripMenuItem With {.Text = Form1.ListView6.Items(i).Text}
                        AddHandler x.Click, Sub(s1, e1) Me.暗黑文本框1.Text &= s1.Text
                        a.Items.Add(x)
                    End If
                Case "文件"
                    If Form1.ListView6.Items(i).SubItems(1).Text = "文件" Then
                        Dim x As New ToolStripMenuItem With {.Text = Form1.ListView6.Items(i).Text}
                        AddHandler x.Click, Sub(s1, e1) Me.暗黑文本框1.Text &= s1.Text
                        a.Items.Add(x)
                    End If
            End Select
        Next
        a.Show(MousePosition)
    End Sub
End Class