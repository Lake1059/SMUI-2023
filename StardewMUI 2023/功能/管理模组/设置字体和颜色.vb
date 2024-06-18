Imports System.IO

Public Class 设置字体和颜色

    Public Shared Sub 初始化()
        AddHandler 管理模组的菜单.菜单项_字体_标准.Click, Sub() 设置字体_通用调用(FontStyle.Regular)
        AddHandler 管理模组的菜单.菜单项_字体_粗体.Click, Sub() 设置字体_通用调用(FontStyle.Bold)
        AddHandler 管理模组的菜单.菜单项_字体_斜体.Click, Sub() 设置字体_通用调用(FontStyle.Italic)
        AddHandler 管理模组的菜单.菜单项_字体_下划线.Click, Sub() 设置字体_通用调用(FontStyle.Underline)
        AddHandler 管理模组的菜单.菜单项_字体_删除线.Click, Sub() 设置字体_通用调用(FontStyle.Strikeout)

        AddHandler 管理模组的菜单.菜单项_颜色_白色.Click, Sub() 设置颜色_通用调用(Color1.白色)
        AddHandler 管理模组的菜单.菜单项_颜色_红色.Click, Sub() 设置颜色_通用调用(Color1.红色)
        AddHandler 管理模组的菜单.菜单项_颜色_橙色.Click, Sub() 设置颜色_通用调用(Color1.橙色)
        AddHandler 管理模组的菜单.菜单项_颜色_黄色.Click, Sub() 设置颜色_通用调用(Color1.黄色)
        AddHandler 管理模组的菜单.菜单项_颜色_绿色.Click, Sub() 设置颜色_通用调用(Color1.绿色)
        AddHandler 管理模组的菜单.菜单项_颜色_青色.Click, Sub() 设置颜色_通用调用(Color1.青色)
        AddHandler 管理模组的菜单.菜单项_颜色_蓝色.Click, Sub() 设置颜色_通用调用(Color1.蓝色)
        AddHandler 管理模组的菜单.菜单项_颜色_紫色.Click, Sub() 设置颜色_通用调用(Color1.紫色)
    End Sub

    Public Shared Sub 设置字体_通用调用(字体样式 As FontStyle)
        Select Case 管理模组的菜单.打开了分类还是模组项的菜单
            Case 1
                If Form1.ListView1.SelectedItems.Count = 0 Then Exit Sub
                Dim x As String = 管理模组2.检查并返回当前所选子库路径()
                If x = "" Then Exit Sub
                For i = 0 To Form1.ListView1.SelectedItems.Count - 1
                    Dim a As String = Path.Combine(x, Form1.ListView1.SelectedItems(i).Text, "Font")
                    Select Case 字体样式
                        Case FontStyle.Regular
                            If FileIO.FileSystem.FileExists(a) = True Then FileIO.FileSystem.DeleteFile(a)
                        Case FontStyle.Bold
                            FileIO.FileSystem.WriteAllText(a, "BD", False)
                        Case FontStyle.Italic
                            FileIO.FileSystem.WriteAllText(a, "LC", False)
                        Case FontStyle.Underline
                            FileIO.FileSystem.WriteAllText(a, "UL", False)
                        Case FontStyle.Strikeout
                            FileIO.FileSystem.WriteAllText(a, "SO", False)
                    End Select
                    Form1.ListView1.SelectedItems(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, 字体样式)
                Next
            Case 2
                If Form1.ListView2.SelectedItems.Count = 0 Then Exit Sub
                Dim x As String = 管理模组2.检查并返回当前所选子库路径
                If x = "" Then Exit Sub
                For i = 0 To Form1.ListView2.SelectedItems.Count - 1
                    Dim a As String = Path.Combine(x, Form1.ListView2.SelectedItems(i).SubItems(3).Text, Form1.ListView2.SelectedItems(i).Text, "Font")
                    Select Case 字体样式
                        Case FontStyle.Regular
                            If FileIO.FileSystem.FileExists(a) = True Then FileIO.FileSystem.DeleteFile(a)
                        Case FontStyle.Bold
                            FileIO.FileSystem.WriteAllText(a, "BD", False)
                        Case FontStyle.Italic
                            FileIO.FileSystem.WriteAllText(a, "LC", False)
                        Case FontStyle.Underline
                            FileIO.FileSystem.WriteAllText(a, "UL", False)
                        Case FontStyle.Strikeout
                            FileIO.FileSystem.WriteAllText(a, "SO", False)
                    End Select
                    Form1.ListView2.SelectedItems(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, 字体样式)
                Next
        End Select
    End Sub


    Public Shared Sub 设置颜色_通用调用(颜色 As Color)
        If Form1.ListView1.SelectedItems.Count = 0 Then Exit Sub
        Dim x As String = 管理模组2.检查并返回当前所选子库路径()
        If x = "" Then Exit Sub
        For i = 0 To Form1.ListView1.SelectedItems.Count - 1
            Dim a As String = Path.Combine(x, Form1.ListView1.SelectedItems(i).Text, "Color")
            Select Case 颜色
                Case Color1.白色
                    If FileIO.FileSystem.FileExists(a) = True Then FileIO.FileSystem.DeleteFile(a)
                Case Color1.红色
                    FileIO.FileSystem.WriteAllText(a, "RED", False)
                Case Color1.橙色
                    FileIO.FileSystem.WriteAllText(a, "ORANGE", False)
                Case Color1.黄色
                    FileIO.FileSystem.WriteAllText(a, "YELLOW", False)
                Case Color1.绿色
                    FileIO.FileSystem.WriteAllText(a, "GREEN", False)
                Case Color1.青色
                    FileIO.FileSystem.WriteAllText(a, "AQUA", False)
                Case Color1.蓝色
                    FileIO.FileSystem.WriteAllText(a, "BLUE", False)
                Case Color1.紫色
                    FileIO.FileSystem.WriteAllText(a, "PURPLE", False)
            End Select
            Form1.ListView1.SelectedItems(i).ForeColor = 颜色
        Next
    End Sub



End Class
