Imports System.IO
Imports System.Text

Public Class Form导入

    Private Sub Form导入_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        界面控制.初始化其他列表视图(Me.ListView1)
        Me.ImageList1.ImageSize = New Size(1, 29 * 界面控制.DPI)
    End Sub

    Private Sub Form导入_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        Me.ColumnHeader1.Width = Me.ListView1.Width - 界面控制.程序DPI_垂直滚动条宽度 * 2
    End Sub

    Private Sub ListView1_DragEnter(sender As Object, e As DragEventArgs) Handles ListView1.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub Form导入_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.ColumnHeader1.Width = Me.ListView1.Width - 界面控制.程序DPI_垂直滚动条宽度 * 2
        Me.UiCheckBox1.CheckBoxSize = 20 * 界面控制.DPI
        Me.UiCheckBox2.CheckBoxSize = 20 * 界面控制.DPI
    End Sub

    Private Sub ListView1_DragDrop(sender As Object, e As DragEventArgs) Handles ListView1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) = True Then
            Dim files As String() = e.Data.GetData(DataFormats.FileDrop)
            For x = 0 To files.Length - 1
                Select Case Me.Text
                    Case "导入数据子库"
                        If Not Path.GetExtension(files(x)).Equals(".smuispak", StringComparison.CurrentCultureIgnoreCase) Then Continue For
                    Case "导入分类"
                        If Not Path.GetExtension(files(x)).Equals(".smuicpak", StringComparison.CurrentCultureIgnoreCase) Then Continue For
                    Case "导入模组项"
                        If Not Path.GetExtension(files(x)).Equals(".smuimpak", StringComparison.CurrentCultureIgnoreCase) Then Continue For
                End Select
                For i = 0 To Me.ListView1.Items.Count - 1
                    If Me.ListView1.Items.Item(i).Text = files(x) Then
                        GoTo jx1
                    End If
                Next
                Me.ListView1.Items.Add(files(x))
jx1:
            Next
        End If
    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        Dim a As New OpenFileDialog
        Select Case Me.Text
            Case "导入数据子库"
                a.Filter = "Sublibrary package file|*.smuispak"
            Case "导入分类"
                a.Filter = "Category package file|*.smuicpak"
            Case "导入模组项"
                a.Filter = "Item package file|*.smuimpak"
        End Select
        a.Multiselect = True
        a.ShowDialog()
        If a.FileNames.Length = 0 Then Exit Sub
        For i3 = 0 To a.FileNames.Length - 1
            For i = 0 To Me.ListView1.Items.Count - 1
                If Me.ListView1.Items(i).Text = a.FileNames(i3) Then
                    GoTo jx1
                End If
            Next
            Me.ListView1.Items.Add(a.FileNames(i3))
jx1:
        Next
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        Dim i As Integer = 0
        Do Until i = Me.ListView1.Items.Count
            If Me.ListView1.Items(i).Selected = True Then
                Me.ListView1.Items(i).Remove()
                i -= 1
            End If
            i += 1
        Loop
    End Sub

    Private Sub UiButton3_MouseDown(sender As Object, e As MouseEventArgs) Handles UiButton3.MouseDown
        If 密码本.导入导出密码本.Count = 0 Then Exit Sub
        Dim m As New 暗黑菜单条控件本体 With {.ShowImageMargin = False, .ShowCheckMargin = False}
        For i = 0 To 密码本.导入导出密码本.Count - 1
            AddHandler m.Items.Add(密码本.导入导出密码本(i)).Click,
                Sub(s1, e1)
                    暗黑文本框1.Text = s1.text
                End Sub
        Next
        m.Show(MousePosition)
    End Sub

    Private Sub UiButton5_Click(sender As Object, e As EventArgs) Handles UiButton5.Click
        If FileIO.FileSystem.FileExists(Path.Combine(设置.用户数据文件夹路径, "Keys")) = False Then
            Dim a As New 多项单选对话框("", {"OK"}, "未找到密码本")
            a.ShowDialog()
        Else
            FileIO.FileSystem.DeleteFile(Path.Combine(设置.用户数据文件夹路径, "Keys"), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
            密码本.导入导出密码本.Clear()
            Dim a As New 多项单选对话框("", {"OK"}, "已删除")
            a.ShowDialog()
        End If
    End Sub

    Private Sub UiButton6_Click(sender As Object, e As EventArgs) Handles UiButton6.Click
        Select Case Me.暗黑文本框1.PasswordChar
            Case "●"
                Me.暗黑文本框1.PasswordChar = ""
            Case Else
                Me.暗黑文本框1.PasswordChar = "●"
        End Select
    End Sub

    Private Sub UiButton4_Click(sender As Object, e As EventArgs) Handles UiButton4.Click
        Dim str As String = "$host.UI.RawUI.WindowTitle = " & """" & Me.Text & """"
        Dim 压缩程序路径 As String = "& " & """" & Application.StartupPath & "\7za64\7za.exe" & """"

        Select Case Me.Text
            Case "导入数据子库"
                For i = 0 To Me.ListView1.Items.Count - 1
                    str &= vbCrLf & 压缩程序路径 & " x " & """" & Me.ListView1.Items(i).Text & """" & " -o" & """" & 管理模组2.检查并返回当前模组数据仓库路径(False) & """"
                    If UiCheckBox1.Checked = True Then
                        密码本.添加导入导出密码到密码本中(Me.暗黑文本框1.Text)
                        str &= " -p" & Me.暗黑文本框1.Text & " -y"
                    End If
                Next
            Case "导入分类"
                For i = 0 To Me.ListView1.Items.Count - 1
                    str &= vbCrLf & 压缩程序路径 & " x " & """" & Me.ListView1.Items(i).Text & """" & " -o" & """" & 管理模组2.检查并返回当前所选子库路径(False) & """"
                    If UiCheckBox1.Checked = True Then
                        密码本.添加导入导出密码到密码本中(Me.暗黑文本框1.Text)
                        str &= " -p" & Me.暗黑文本框1.Text & " -y"
                    End If
                Next
            Case "导入模组项"
                For i = 0 To Me.ListView1.Items.Count - 1
                    str &= vbCrLf & 压缩程序路径 & " x " & """" & Me.ListView1.Items(i).Text & """" & " -o" & """" & 管理模组2.检查并返回当前所选子库路径(False) & "\" & Form1.ListView1.SelectedItems(0).Text & """"
                    If UiCheckBox1.Checked = True Then
                        密码本.添加导入导出密码到密码本中(Me.暗黑文本框1.Text)
                        str &= " -p" & Me.暗黑文本框1.Text & " -y"
                    End If
                Next
        End Select

        If UiCheckBox2.Checked = False Then
            str &= vbCrLf & "pause"
        End If

        FileIO.FileSystem.WriteAllText(Path.Combine(设置.用户数据文件夹路径, "7za.ps1"), str, False, Encoding.UTF8)
        Process.Start("powershell.exe", "-File " & """" & Path.Combine(设置.用户数据文件夹路径, "7za.ps1") & """")
        Me.Close()

    End Sub

    Private Sub UiButton3_Click(sender As Object, e As EventArgs) Handles UiButton3.Click

    End Sub

    Private Sub UiButton7_Click(sender As Object, e As EventArgs) Handles UiButton7.Click
        Dim a As New 多项单选对话框("Windows PowerShell", {"确定"}, "由于新版本 .NET 框架不再提供 ANSI 编码，我无法从命令提示符运行脚本，所以改成了 Windows PowerShell，请确保系统中的 PowerShell 能够正常运行。" & vbCrLf & vbCrLf & "需要在 Windows 设置中打开允许运行未签名的本地脚本：" & vbCrLf & vbCrLf & "Win10：Windows 设置 -> 更新和安全 -> 开发者选项 -> PowerShell -> 勾选：更改执行策略，以允许本地 PowerShell 脚本在未签名的情况下运行。应用即可。" & vbCrLf & vbCrLf & "Win11：Windows 设置 -> 开发者选项 -> PowerShell，然后启用对应选项即可。", 300, 500)
        a.ShowDialog(Me)
    End Sub
End Class