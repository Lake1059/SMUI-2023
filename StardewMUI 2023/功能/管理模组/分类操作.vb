Imports System.IO
Imports System.Xml.Xsl
Imports Microsoft.VisualBasic.Devices
Imports Sunny.UI

Public Class 分类操作

    Public Shared Sub 新建分类()
        Dim a As String = 管理模组2.检查并返回当前所选子库路径()
        If a = "" Then Exit Sub
        Dim d1 As New 输入对话框("", "输入新建分类的名称",, 500)
        d1.TranslateButtonText("确定", "取消")
Line1:
        Dim s1 As String = d1.ShowDialog(Form1)
        If s1 = "" Then Exit Sub
        If FileIO.FileSystem.DirectoryExists(a & "\" & s1) Then
            Dim b As New 多项单选对话框("", {"确定"}, "已经存在目标分类：" & vbCrLf & vbCrLf & a & "\" & s1,, 500)
            b.ShowDialog(Form1)
            GoTo Line1
        Else
            FileIO.FileSystem.CreateDirectory(a & "\" & s1)
            Form1.ListView1.Items.Add(s1)
            Form1.Label50.Text = Form1.ListView1.Items.Count
        End If
    End Sub

    Public Shared Sub 转移分类()
        Dim newWindow As New Form With {
            .Text = "选择目标分类",
            .BackColor = Form1.BackColor,
            .ForeColor = Form1.ForeColor,
            .AutoScroll = True,
            .StartPosition = FormStartPosition.Manual,
            .Size = New Size(300, 500),
            .Padding = New Padding(10),
            .MinimizeBox = False,
            .MaximizeBox = False,
            .SizeGripStyle = False
        }
        Dim a As New List(Of String)(共享方法.SearchFolderWithoutSub(管理模组2.检查并返回当前模组数据仓库路径))
        a.Remove(".Download")
        a.Remove(".Decompress")
        For i = 0 To a.Count - 1
            Dim b1 As New Label With {
                .AutoSize = False,
                .Height = 30,
                .Text = a(i),
                .TextAlign = ContentAlignment.MiddleLeft,
                .Dock = DockStyle.Top,
                .Padding = New Padding(3, 0, 3, 0)
            }
            AddHandler b1.MouseEnter, Sub(sender, e) sender.BackColor = ColorTranslator.FromWin32(RGB(48, 48, 48))
            AddHandler b1.MouseLeave, Sub(sender, e) sender.BackColor = newWindow.BackColor
            AddHandler b1.MouseDown, Sub(sender, e) sender.BackColor = ColorTranslator.FromWin32(RGB(64, 64, 64))
            AddHandler b1.Click, Sub(sender, e)
                                     管理模组.重置模组项信息显示()
                                     管理模组.清除模组项列表()
                                     Dim i2 As Integer = 0
                                     Do Until i2 = Form1.ListView1.Items.Count
                                         If Form1.ListView1.Items(i2).Selected Then
                                             Dim 当前选择的目标子库 As String = sender.Text
                                             Dim 原路径 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView1.Items(i2).Text)
                                             Dim 目标路径 As String = Path.Combine(管理模组2.检查并返回当前模组数据仓库路径(False), 当前选择的目标子库, Form1.ListView1.Items(i2).Text)
                                             If Not FileIO.FileSystem.DirectoryExists(目标路径) Then
                                                 FileIO.FileSystem.MoveDirectory(原路径, 目标路径)
                                                 Form1.ListView1.Items(i2).Remove()
                                                 i2 -= 1
                                             End If
                                         End If
                                         i2 += 1
                                     Loop
                                     Form1.Label50.Text = Form1.ListView1.Items.Count
                                     newWindow.Dispose()
                                     sender.Dispose()
                                 End Sub
            newWindow.Controls.Add(b1)
        Next
        显示模式窗体(newWindow, Form1)
    End Sub

    Public Shared Sub 重命名分类()

    End Sub

    Public Shared Sub 删除分类()

    End Sub


End Class
