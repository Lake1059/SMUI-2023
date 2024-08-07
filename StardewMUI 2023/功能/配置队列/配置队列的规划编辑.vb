Imports System.IO
Imports Sunny.UI

Public Class 配置队列的规划编辑

    Public Shared Property 来自_选择文件夹_所选的文件夹 As String

    Public Shared Sub 匹配到_复制文件夹到Mods()
        来自_选择文件夹_所选的文件夹 = ""
        Dim a As New Form编辑规划_选择文件夹 With {.Text = 配置队列.规划显示名称字典("CD-D-MODS")}
        Dim ModsAMD As Boolean = False
        If 配置队列.当前项的规划操作列表.Contains("CORE-CLASS") Then
            Dim 控制参数 As New List(Of String)(Form1.ListView7.Items(配置队列.当前项的规划操作列表.IndexOf("CORE-CLASS")).SubItems(1).Text.Split("|").ToList)
            If 控制参数.Contains("Mods-AMD") Then ModsAMD = True
        End If
        For Each mDir As DirectoryInfo In New DirectoryInfo(配置队列.正在编辑规划的项路径).GetDirectories
            If ModsAMD Then
                Select Case mDir.Name
                    Case "Screenshot", ".config"
                    Case Else
                        a.ListView1.Items.Add(mDir.Name)
                End Select
            Else
                If FileIO.FileSystem.FileExists(Path.Combine(mDir.FullName, "manifest.json")) Then
                    Select Case mDir.Name
                        Case "Screenshot", ".config"
                        Case Else
                            a.ListView1.Items.Add(mDir.Name)
                    End Select
                End If
            End If
        Next
        If Form1.ListView7.SelectedItems(0).SubItems(1).Text <> "" Then
            For i = 0 To a.ListView1.Items.Count - 1
                If a.ListView1.Items(i).Text = Form1.ListView7.SelectedItems(0).SubItems(1).Text Then
                    a.ListView1.Items(i).Selected = True
                    Exit For
                End If
            Next
        End If
        显示模式窗体(a, Form1)
        If 来自_选择文件夹_所选的文件夹 <> "" Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = 来自_选择文件夹_所选的文件夹
        End If
        a.Dispose()
    End Sub

    Public Shared Sub 匹配到_覆盖文件夹到Mods()
        来自_选择文件夹_所选的文件夹 = ""
        Dim a As New Form编辑规划_选择文件夹 With {.Text = 配置队列.规划显示名称字典("CD-D-MODS-COVER")}
        For Each mDir As DirectoryInfo In New DirectoryInfo(配置队列.正在编辑规划的项路径).GetDirectories
            Select Case mDir.Name
                Case "Screenshot", ".config"
                Case Else
                    a.ListView1.Items.Add(mDir.Name)
            End Select
        Next
        If Form1.ListView7.SelectedItems(0).SubItems(1).Text <> "" Then
            For i = 0 To a.ListView1.Items.Count - 1
                If a.ListView1.Items(i).Text = Form1.ListView7.SelectedItems(0).SubItems(1).Text Then
                    a.ListView1.Items(i).Selected = True
                    Exit For
                End If
            Next
        End If
        显示模式窗体(a, Form1)
        If 来自_选择文件夹_所选的文件夹 <> "" Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = 来自_选择文件夹_所选的文件夹
        End If
        a.Dispose()
    End Sub

    Public Shared Property 来自_复制文件夹_所选的文件夹 As String
    Public Shared Property 来自_复制文件夹_目标文件夹相对路径 As String

    Public Shared Sub 来自_复制文件夹_通用调用(标题栏 As String, 窗体上文本1 As String, 窗体上文本2 As String, 列表里的选项 As List(Of String))
        来自_复制文件夹_所选的文件夹 = ""
        来自_复制文件夹_目标文件夹相对路径 = ""
        Dim a As New Form编辑规划_复制文件夹 With {.Text = 标题栏}
        a.Label1.Text = 窗体上文本1
        a.Label2.Text = 窗体上文本2
        For i = 0 To 列表里的选项.Count - 1
            a.ListView1.Items.Add(列表里的选项(i))
        Next
        Dim 参数列表 As New List(Of String)(Form1.ListView7.SelectedItems(0).SubItems(1).Text.Split("|").ToList)
        If 参数列表(0) <> "" Then
            For i = 0 To a.ListView1.Items.Count - 1
                If a.ListView1.Items(i).Text = 参数列表(0) Then
                    a.ListView1.Items(i).Selected = True
                    Exit For
                End If
            Next
        End If
        If Not 参数列表(1).Contains("<"c) Then a.暗黑文本框1.Text = 参数列表(1)
        显示模式窗体(a, Form1)
        If 来自_复制文件夹_所选的文件夹 <> "" Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = $"{来自_复制文件夹_所选的文件夹}|{来自_复制文件夹_目标文件夹相对路径}"
        End If
        a.Dispose()
    End Sub

    Public Shared Sub 匹配到_复制文件夹()
        Dim L1 As New List(Of String)
        For Each mDir As DirectoryInfo In New DirectoryInfo(配置队列.正在编辑规划的项路径).GetDirectories
            Select Case mDir.Name
                Case "Screenshot", ".config"
                Case Else
                    L1.Add(mDir.Name)
            End Select
        Next
        来自_复制文件夹_通用调用("复制文件夹", "选择文件夹", "复制到目标位置（从游戏根目录算起）", L1)
    End Sub

    Public Shared Sub 匹配到_覆盖Content()
        UIMessageTip.Show($"此规划操作没有可配置的选项",, 1200)
    End Sub

    Public Shared Property 来自_安装单个文件_要安装哪个文件 As String
    Public Shared Property 来自_安装单个文件_目标位置 As String
    Public Shared Property 来自_安装单个文件_卸载时是否还原 As Boolean
    Public Shared Property 来自_安装单个文件_是否判断安装情况 As Boolean
    Public Shared Property 来自_安装单个文件_是否验证SHA256 As Boolean
    Public Shared Sub 匹配到_安装单个文件()
        来自_安装单个文件_要安装哪个文件 = ""
        来自_安装单个文件_目标位置 = ""
        来自_安装单个文件_卸载时是否还原 = False
        来自_安装单个文件_是否判断安装情况 = False
        来自_安装单个文件_是否验证SHA256 = False
        Dim a As New Form编辑规划_安装单个文件
        Dim 参数列表 As New List(Of String)(Form1.ListView7.SelectedItems(0).SubItems(1).Text.Split("|").ToList)
        If 参数列表(0).Trim.Equals("True", StringComparison.CurrentCultureIgnoreCase) Then
            a.UiRadioButton1.Checked = True
            a.UiRadioButton2.Checked = False
        Else
            a.UiRadioButton1.Checked = False
            a.UiRadioButton2.Checked = True
        End If
        If 参数列表(1).Trim.Equals("True", StringComparison.CurrentCultureIgnoreCase) Then
            a.UiRadioButton3.Checked = True
            a.UiRadioButton4.Checked = False
        Else
            a.UiRadioButton3.Checked = False
            a.UiRadioButton4.Checked = True
        End If
        If 参数列表(2).Trim.Equals("True", StringComparison.CurrentCultureIgnoreCase) Then
            a.UiRadioButton5.Checked = True
            a.UiRadioButton6.Checked = False
        Else
            a.UiRadioButton5.Checked = False
            a.UiRadioButton6.Checked = True
        End If
        If Not 参数列表(3).Contains("<"c) Then a.暗黑文本框1.Text = 参数列表(3)
        If Not 参数列表(4).Contains("<"c) Then a.暗黑文本框2.Text = 参数列表(4)
        显示模式窗体(a, Form1)
        If 来自_安装单个文件_要安装哪个文件 <> "" Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = $"{来自_安装单个文件_卸载时是否还原}|{来自_安装单个文件_是否判断安装情况}|{来自_安装单个文件_是否验证SHA256}|{来自_安装单个文件_要安装哪个文件}|{来自_安装单个文件_目标位置}"
        End If
        a.Dispose()
    End Sub

    Public Shared Property 来自_检查存在性_在安装还是卸载中进行 As String
    Public Shared Property 来自_检查存在性_文件夹还是文件 As String
    Public Shared Property 来自_检查存在性_要存在还是不存在 As Boolean
    Public Shared Property 来自_检查存在性_填写的相对路径 As New List(Of String)

    Public Shared Sub 匹配到_检查存在性()
        来自_检查存在性_在安装还是卸载中进行 = ""
        来自_检查存在性_文件夹还是文件 = ""
        来自_检查存在性_要存在还是不存在 = True
        来自_检查存在性_填写的相对路径.Clear()
        Dim a As New Form编辑规划_检查存在性
        Dim 参数列表 As New List(Of String)(Form1.ListView7.SelectedItems(0).SubItems(1).Text.Split("|").ToList)
        Select Case 参数列表(0).Trim.ToLower
            Case "install"
                a.UiRadioButton1.Checked = True
                a.UiRadioButton2.Checked = False
                a.UiRadioButton7.Checked = False
            Case "uninstall"
                a.UiRadioButton1.Checked = False
                a.UiRadioButton2.Checked = True
                a.UiRadioButton7.Checked = False
            Case "all"
                a.UiRadioButton1.Checked = False
                a.UiRadioButton2.Checked = False
                a.UiRadioButton7.Checked = True
        End Select
        Select Case 参数列表(1).Trim.ToLower
            Case "folder"
                a.UiRadioButton3.Checked = True
                a.UiRadioButton4.Checked = False
            Case "file"
                a.UiRadioButton3.Checked = False
                a.UiRadioButton4.Checked = True
        End Select
        Select Case 参数列表(2).Trim.ToLower
            Case "true"
                a.UiRadioButton5.Checked = True
                a.UiRadioButton6.Checked = False
            Case "false"
                a.UiRadioButton5.Checked = False
                a.UiRadioButton6.Checked = True
        End Select
        For i = 3 To 参数列表.Count - 1
            If i = 3 Then
                a.UiTextBox1.Text = 参数列表(3)
            Else
                a.UiTextBox1.Text &= "|" & 参数列表(i)
            End If
        Next
        显示模式窗体(a, Form1)
        If 来自_检查存在性_填写的相对路径.Count > 0 Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = $"{来自_检查存在性_在安装还是卸载中进行}|{来自_检查存在性_文件夹还是文件}|{来自_检查存在性_要存在还是不存在}|{String.Join("|", 来自_检查存在性_填写的相对路径.Where(Function(s) Not String.IsNullOrWhiteSpace(s)))}"
        End If
        a.Dispose()
    End Sub

    Public Shared Property 来自_检查已安装模组版本_判断符号 As String
    Public Shared Property 来自_检查已安装模组版本_版本号 As String
    Public Shared Property 来自_检查已安装模组版本_指定模组文件夹 As String
    Public Shared Sub 匹配到_安装时检查Mods中已安装模组的版本()
        来自_检查已安装模组版本_判断符号 = ""
        来自_检查已安装模组版本_版本号 = ""
        来自_检查已安装模组版本_指定模组文件夹 = ""
        Dim a As New Form编辑规划_检查已安装模组版本号
        Dim 参数列表 As New List(Of String)(Form1.ListView7.SelectedItems(0).SubItems(1).Text.Split("|").ToList)
        If Not 参数列表(0).Contains("判断符") Then a.UiComboBox1.Text = 参数列表(0).Trim
        If Not 参数列表(1).Contains("<"c) Then a.暗黑文本框2.Text = 参数列表(1)
        If Not 参数列表(2).Contains("<"c) Then a.暗黑文本框1.Text = 参数列表(2)
        显示模式窗体(a, Form1)
        If 来自_检查已安装模组版本_指定模组文件夹 <> "" Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = $"{来自_检查已安装模组版本_判断符号}|{来自_检查已安装模组版本_版本号}|{来自_检查已安装模组版本_指定模组文件夹}"
        End If
        a.Dispose()
    End Sub

    Public Shared Sub 匹配到_卸载时取消操作()
        Dim a As New Form编辑规划_卸载时取消操作
        Dim 参数列表 As String = Form1.ListView7.SelectedItems(0).SubItems(1).Text
        Select Case 参数列表
            Case "CANCEL"
                a.UiRadioButton1.Checked = True
                a.UiRadioButton2.Checked = False
            Case "ERROR"
                a.UiRadioButton1.Checked = False
                a.UiRadioButton2.Checked = True
        End Select
        显示模式窗体(a, Form1)
        If a.UiRadioButton1.Checked Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = "CANCEL"
        ElseIf a.UiRadioButton2.Checked Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = "ERROR"
        End If
        a.Dispose()
    End Sub

    Public Shared Property 来自_运行可执行文件_在安装还是卸载中进行 As String
    Public Shared Property 来自_运行可执行文件_可执行文件 As String
    Public Shared Property 来自_运行可执行文件_传递参数 As String
    Public Shared Property 来自_运行可执行文件_是否等待 As Boolean
    Public Shared Sub 匹配到_运行可执行文件()
        来自_运行可执行文件_可执行文件 = ""
        来自_运行可执行文件_传递参数 = ""
        来自_运行可执行文件_是否等待 = False
        Dim a As New Form编辑规划_运行可执行文件
        Dim 参数列表 As New List(Of String)(Form1.ListView7.SelectedItems(0).SubItems(1).Text.Split("|").ToList)
        Select Case 参数列表(0).Trim.ToLower
            Case "install"
                a.UiRadioButton1.Checked = True
                a.UiRadioButton2.Checked = False
                a.UiRadioButton7.Checked = False
            Case "uninstall"
                a.UiRadioButton1.Checked = False
                a.UiRadioButton2.Checked = True
                a.UiRadioButton7.Checked = False
            Case "all"
                a.UiRadioButton1.Checked = False
                a.UiRadioButton2.Checked = False
                a.UiRadioButton7.Checked = True
        End Select
        If Not 参数列表(1).Contains("<"c) Then a.暗黑文本框1.Text = 参数列表(1)
        If Not 参数列表(2).Contains("<"c) Then a.暗黑文本框2.Text = 参数列表(2)
        If 参数列表(3).Trim.Equals("True", StringComparison.CurrentCultureIgnoreCase) Then a.UiCheckBox1.Checked = True
        显示模式窗体(a, Form1)
        If 来自_运行可执行文件_可执行文件 <> "" Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = $"{来自_运行可执行文件_在安装还是卸载中进行}|{来自_运行可执行文件_可执行文件}|{来自_运行可执行文件_传递参数}|{来自_运行可执行文件_是否等待}"
        End If
        a.Dispose()
    End Sub

    Public Shared Property 来自_弹窗_在安装还是卸载中 As String
    Public Shared Property 来自_弹窗_标题栏 As String
    Public Shared Property 来自_弹窗_描述 As String
    Public Shared Property 来自_弹窗_是否要正确 As Boolean
    Public Shared Property 来自_弹窗_正确序号 As Integer
    Public Shared Property 来自_弹窗_选择项 As New List(Of String)
    Public Shared Sub 匹配到_弹窗()
        来自_弹窗_在安装还是卸载中 = ""
        来自_弹窗_标题栏 = ""
        来自_弹窗_描述 = ""
        来自_弹窗_是否要正确 = False
        来自_弹窗_正确序号 = -1
        来自_弹窗_选择项.Clear()
        Dim a As New Form编辑规划_弹窗
        Dim 参数列表 As New List(Of String)(Form1.ListView7.SelectedItems(0).SubItems(1).Text.Split("|").ToList)
        Select Case 参数列表(0).Trim.ToLower
            Case "install"
                a.UiRadioButton1.Checked = True
                a.UiRadioButton2.Checked = False
                a.UiRadioButton7.Checked = False
            Case "uninstall"
                a.UiRadioButton1.Checked = False
                a.UiRadioButton2.Checked = True
                a.UiRadioButton7.Checked = False
            Case "all"
                a.UiRadioButton1.Checked = False
                a.UiRadioButton2.Checked = False
                a.UiRadioButton7.Checked = True
        End Select
        If Not 参数列表(1).Contains("<"c) Then a.暗黑文本框1.Text = 参数列表(1)
        If Not 参数列表(2).Contains("<"c) Then a.暗黑文本框2.Text = 参数列表(2)
        If 参数列表(3).Trim.Equals("True", StringComparison.CurrentCultureIgnoreCase) Then
            a.UiCheckBox1.Checked = True
        End If
        If 参数列表(4).IsNumber Then a.UiNumPadTextBox1.Text = 参数列表(4)
        For i = 5 To 参数列表.Count - 1
            If i = 5 Then
                a.UiTextBox1.Text = 参数列表(5)
            Else
                a.UiTextBox1.Text &= vbCrLf & 参数列表(i)
            End If
        Next
        显示模式窗体(a, Form1)
        If 来自_弹窗_选择项.Count > 0 Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = $"{来自_弹窗_在安装还是卸载中}|{来自_弹窗_标题栏}|{来自_弹窗_描述}|{来自_弹窗_是否要正确}|{来自_弹窗_正确序号}|{String.Join("|", 来自_弹窗_选择项.Where(Function(s) Not String.IsNullOrWhiteSpace(s)))}"
        End If
        a.Dispose()
    End Sub

    Public Shared Sub 匹配到_声明各种核心功能的启停()
        Dim a As New Form编辑规划_核心功能启停
        Dim 参数列表 As New List(Of String)(Form1.ListView7.SelectedItems(0).SubItems(1).Text.Split("|").ToList)
        For i = 0 To 参数列表.Count - 1
            Select Case 参数列表(i)
                Case "Mods-AMD"
                    a.UiCheckBox1.Checked = True
                Case "CG-DB"
                    a.UiCheckBox2.Checked = True
                Case "FILE-ALLOW-ALL"
                    a.UiCheckBox3.Checked = True
            End Select
        Next
        显示模式窗体(a, Form1)
        Dim 参数列表2 As String = ""
        If a.UiCheckBox1.Checked Then 添加参数(参数列表2, "Mods-AMD")
        If a.UiCheckBox2.Checked Then 添加参数(参数列表2, "CG-DB")
        If a.UiCheckBox3.Checked Then 添加参数(参数列表2, "FILE-ALLOW-ALL")
        Form1.ListView7.SelectedItems(0).SubItems(1).Text = 参数列表2
        a.Dispose()
    End Sub

    Shared Sub 添加参数(ByRef 参数对象 As String, 添加的参数 As String)
        If 参数对象 = "" Then
            参数对象 = 添加的参数
        Else
            参数对象 &= "|" & 添加的参数
        End If
    End Sub

End Class
