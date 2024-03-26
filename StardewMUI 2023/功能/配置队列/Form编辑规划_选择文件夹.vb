Public Class Form编辑规划_选择文件夹

    Public Sub New()
        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        Me.UiListBox1.Items.Clear()
        Me.UiListBox1.ItemHeight *= 界面控制.DPI
    End Sub


    Private Sub Form编辑规划_选择文件夹_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        调整界面()
    End Sub

    Private Sub Form编辑规划_选择文件夹_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub Form编辑规划_选择文件夹_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        调整界面()
    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        配置队列的规划编辑.来自_选择文件夹_所选的文件夹 = Me.UiListBox1.Text
        Me.Close()
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        配置队列的规划编辑.来自_选择文件夹_所选的文件夹 = ""
    End Sub

    Private Sub UiListBox1_DoubleClick(sender As Object, e As EventArgs) Handles UiListBox1.DoubleClick
        UiButton1.PerformClick()
    End Sub

    Public Sub 调整界面()
        Me.UiListBox1.Left = 19 * 界面控制.DPI : Me.UiListBox1.Top = 60 * 界面控制.DPI : Me.UiListBox1.Width = 466 * 界面控制.DPI : Me.UiListBox1.Height = 232 * 界面控制.DPI

        If Me.UiListBox1.ItemHeight * Me.UiListBox1.Items.Count + Me.UiListBox1.Padding.Top + Me.UiListBox1.Padding.Bottom <= Me.UiListBox1.Height Then
            Me.UiListBox1.Padding = New Padding(10)
        Else
            Me.UiListBox1.Padding = New Padding(10, 10, 2, 10)
        End If

    End Sub


End Class