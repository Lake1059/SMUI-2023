Imports System.IO
Imports Sunny.UI

Public Class 自定义描述功能

    Public Shared Sub 初始化()
        AddHandler 管理模组的菜单.菜单项_保存描述到纯文本.Click, AddressOf 保存到纯文本
        AddHandler 管理模组的菜单.菜单项_保存描述到富文本.Click, AddressOf 保存到富文本
        AddHandler 管理模组的菜单.菜单项_新建富文本文档.Click, AddressOf 保存到纯文本
        AddHandler 管理模组的菜单.菜单项_在写字板中编辑富文本.Click, AddressOf 用写字板编辑富文本
        AddHandler 管理模组的菜单.菜单项_删除所有自定义描述.Click, AddressOf 删除所有自定义描述
        AddHandler 管理模组的菜单.菜单项_设置选中内容的字体.Click, AddressOf 设置字体
        AddHandler 管理模组的菜单.菜单项_设置选中内容的文字颜色.Click, AddressOf 设置文字颜色
        AddHandler 管理模组的菜单.菜单项_设置选中内容的背景颜色.Click, AddressOf 设置文字背景颜色
        AddHandler 管理模组的菜单.菜单项_清除所有格式.Click, AddressOf 清除所有格式


    End Sub


    Public Shared Sub 保存到纯文本()
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        Dim a As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text)

        FileIO.FileSystem.WriteAllText(a & "\README", Form1.UiRichTextBox1.Text, False)
        If FileIO.FileSystem.FileExists(a & "\README.rtf") = True Then FileIO.FileSystem.DeleteFile(a & "\README.rtf", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
        Form1.UiButton11.Text = "TXT"
        UIMessageTip.Show("已保存",, 1200)
    End Sub

    Public Shared Sub 保存到富文本()
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        Dim a As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text)

        Form1.UiRichTextBox1.SaveFile(a & "\README.rtf")
        If FileIO.FileSystem.FileExists(a & "\README") = True Then FileIO.FileSystem.DeleteFile(a & "\README", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
        Form1.UiButton11.Text = "RTF"
        UIMessageTip.Show("已保存",, 1200)
    End Sub

    Public Shared Sub 新建富文本文档()
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        Form1.UiRichTextBox1.LoadFile(Application.StartupPath & "\newrtf.rtf")
    End Sub

    Public Shared Sub 用写字板编辑富文本()
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        Dim a As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text)

        If Not FileIO.FileSystem.FileExists(Path.Combine(a, "README.rtf")) Then
            Dim x As New 多项单选对话框("", {"确认创建", "取消"}, "此模组项不包含富文本描述文件，是否创建？")
            Select Case x.ShowDialog(Form1)
                Case -1, 1
                    Exit Sub
                Case 0
                    FileIO.FileSystem.CopyFile(Path.Combine(Application.StartupPath, "newrtf.rtf"), Path.Combine(a, "README.rtf"))
            End Select
        End If
        If FileIO.FileSystem.FileExists("C:\Program Files\Windows NT\Accessories\wordpad.exe") Then
            Shell("""" & "C:\Program Files\Windows NT\Accessories\wordpad.exe" & """" & " " & """" & a & "\README.rtf" & """", AppWinStyle.NormalFocus)
            Exit Sub
        End If
        If FileIO.FileSystem.FileExists("C:\Program Files (x86)\Windows NT\Accessories\wordpad.exe") Then
            Shell("""" & "C:\Program Files (x86)\Windows NT\Accessories\wordpad.exe" & """" & " " & """" & a & "\README.rtf" & """", AppWinStyle.NormalFocus)
            Exit Sub
        End If
        Dim b As New 多项单选对话框("", {"确定"}, "无法在 [Program Files]\Windows NT\Accessories\wordpad.exe 找到写字板应用程序")
        b.ShowDialog(Form1)
    End Sub

    Public Shared Sub 删除所有自定义描述()
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        Dim a As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.SelectedItems(0).SubItems(3).Text, Form1.ListView2.SelectedItems(0).Text)

        If FileIO.FileSystem.FileExists(a & "\README") = True Then FileIO.FileSystem.DeleteFile(a & "\README", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
        If FileIO.FileSystem.FileExists(a & "\README.txt") = True Then FileIO.FileSystem.DeleteFile(a & "\README.txt", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
        If FileIO.FileSystem.FileExists(a & "\README.rtf") = True Then FileIO.FileSystem.DeleteFile(a & "\README.rtf", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
        Form1.UiButton11.Text = "None"
        UIMessageTip.Show("已删除",, 1200)
    End Sub

    Public Shared Sub 设置字体()
        Dim a As New FontDialog
        a.ShowDialog(Form1)
        If a.Font IsNot Nothing Then Form1.UiRichTextBox1.SelectionFont = a.Font
    End Sub

    Public Shared Sub 设置文字颜色()
        Dim a As New ColorDialog
        a.ShowDialog(Form1)
        If a.Color <> Nothing Then Form1.UiRichTextBox1.SelectionColor = a.Color
    End Sub

    Public Shared Sub 设置文字背景颜色()
        Dim a As New ColorDialog
        a.ShowDialog(Form1)
        If a.Color <> Nothing Then Form1.UiRichTextBox1.SelectionBackColor = a.Color
    End Sub

    Public Shared Sub 清除所有格式()
        Form1.UiRichTextBox1.SelectionAlignment = HorizontalAlignment.Left
        Form1.UiRichTextBox1.SelectionBackColor = Form1.UiRichTextBox1.BackColor
        Form1.UiRichTextBox1.SelectionColor = Form1.UiRichTextBox1.ForeColor
        Form1.UiRichTextBox1.SelectionFont = Form1.UiRichTextBox1.Font
        Form1.UiRichTextBox1.SelectionIndent = 0
    End Sub



End Class
