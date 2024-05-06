Imports System.IO
Imports System.Text

Public Class Form导出
    Private Sub Form导出_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Form导出_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        选择文件保存位置()
    End Sub

    Function 选择文件保存位置() As String
        Dim a As New SaveFileDialog
        Select Case Me.Text
            Case "导出数据子库"
                a.Filter = "Sublibrary package file|*.smuispak"
                a.FileName = 管理模组2.检查并返回当前所选子库路径(False) & ".smuispak"
            Case "导出分类"
                a.Filter = "Category package file|*.smuicpak"
                If Form1.ListView1.SelectedItems.Count > 1 Then
                    a.FileName = Form1.ListView1.SelectedItems(0).Text & " etc. " & Form1.ListView1.SelectedItems.Count & " categories.smuicpak"
                Else
                    a.FileName = Form1.ListView1.SelectedItems(0).Text & ".smuicpak"
                End If
            Case "导出模组项"
                a.Filter = "Item package file|*.smuimpak"
                If Form1.ListView2.SelectedItems.Count > 1 Then
                    a.FileName = Form1.ListView2.SelectedItems(0).Text & " etc. " & Form1.ListView2.SelectedItems.Count & " items.smuimpak"
                Else
                    a.FileName = Form1.ListView2.SelectedItems(0).Text & ".smuimpak"
                End If
        End Select

        a.CheckFileExists = False
        a.AddExtension = True
        Select Case a.ShowDialog()
            Case DialogResult.OK
                Me.暗黑文本框1.Text = a.FileName
                Return a.FileName
            Case Else
                Return ""
        End Select

    End Function

    Private Sub UiButton6_Click(sender As Object, e As EventArgs) Handles UiButton6.Click
        选择文件保存位置()
    End Sub

    Private Sub UiButton3_MouseDown(sender As Object, e As MouseEventArgs) Handles UiButton3.MouseDown
        If 密码本.导入导出密码本.Count = 0 Then Exit Sub
        Dim m As New 暗黑菜单条控件本体 With {.ShowImageMargin = False, .ShowCheckMargin = False}
        For i = 0 To 密码本.导入导出密码本.Count - 1
            AddHandler m.Items.Add(密码本.导入导出密码本(i)).Click,
                Sub(s1, e1)
                    暗黑文本框2.Text = s1.text
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

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        Select Case Me.暗黑文本框2.PasswordChar
            Case "●"
                Me.暗黑文本框2.PasswordChar = ""
            Case Else
                Me.暗黑文本框2.PasswordChar = "●"
        End Select
    End Sub

    Private Sub UiButton4_Click(sender As Object, e As EventArgs) Handles UiButton4.Click
        If FileIO.FileSystem.FileExists(Me.暗黑文本框1.Text) = True Then
            Dim a As New 多项单选对话框("", {"是", "否"}, "目标文件存在，是否要删除目标文件再进行导出？",, 500)
            Dim a2 As Integer = a.ShowDialog(Me)

            Select Case a2
                Case -1, 1
                    Exit Sub
                Case 0
                    FileIO.FileSystem.DeleteFile(Me.暗黑文本框1.Text, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            End Select
        End If

        Dim str As String = "$host.UI.RawUI.WindowTitle = " & """" & Me.Text & """"
        str &= vbCrLf & "& " & """" & Path.Combine(Application.StartupPath, "7za64", "7za.exe") & """"
        str &= " a " & """" & Me.暗黑文本框1.Text & """" & " "

        Select Case Me.Text
            Case "导出数据子库"
                str &= """" & 管理模组2.检查并返回当前所选子库路径(False) & "\" & """"
            Case "导出分类"
                For i = 0 To Form1.ListView1.SelectedItems.Count - 1
                    str &= " " & """" & 管理模组2.检查并返回当前所选子库路径(False) & "\" & Form1.ListView1.SelectedItems(i).Text & "\" & """"
                Next
            Case "导出模组项"
                For i = 0 To Form1.ListView2.SelectedItems.Count - 1
                    str &= " " & """" & 管理模组2.检查并返回当前所选子库路径(False) & "\" & Form1.ListView2.SelectedItems(i).SubItems(3).Text & "\" & Form1.ListView2.SelectedItems(i).Text & "\" & """"
                Next
        End Select

        If UiCheckBox1.Checked = True Then
            str &= " -p" & Me.暗黑文本框2.Text & " -mhe"
        End If

        If UiCheckBox1.Checked = True And UiCheckBox2.Checked = False Then
            str &= vbCrLf & "Write-Host " & """" & "如果你忘记了设置的密码，可以到用户配置文件夹，用记事本或其他编辑器打开最后的 7za.ps1 脚本文件查看即可，但是不要运行它，防止造成意外事故" & """"
            str &= vbCrLf & "Write-Host " & """" & "密码：" & Me.暗黑文本框2.Text & """"
        End If

        If UiCheckBox2.Checked = False Then
            str &= vbCrLf & "pause"
        End If

        FileIO.FileSystem.WriteAllText(Path.Combine(设置.用户数据文件夹路径, "7za.ps1"), str, False, Encoding.UTF8)
        Process.Start("powershell.exe", "-File " & """" & Path.Combine(设置.用户数据文件夹路径, "7za.ps1") & """")
        Me.Close()

    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        Dim a As New 多项单选对话框("Windows PowerShell", {"确定"}, "由于新版本 .NET 框架不再提供 ANSI 编码，我无法从命令提示符运行脚本，所以改成了 Windows PowerShell，请确保系统中的 PowerShell 能够正常运行。" & vbCrLf & vbCrLf & "需要在 Windows 设置中打开允许运行未签名的本地脚本：Windows 设置 -> 更新和安全 -> 开发者选项 -> PowerShell -> 勾选：更改执行策略，以允许本地 PowerShell 脚本在未签名的情况下运行。应用即可", 200, 500)
        a.ShowDialog(Me)
    End Sub
End Class