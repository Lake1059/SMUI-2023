Imports System.IO
Imports System.Text
Imports System.Text.Json
Imports SMUI6.批量分发管理.预设数据结构
Imports Sunny.UI

Public Class 批量分发管理

    <Serializable>
    Public Class 预设数据结构
        Public Property Data As List(Of KeyValuePair(Of String, 预设单片结构))
        Public Structure 预设单片结构
            Public Property 文件列表 As List(Of KeyValuePair(Of String, 文件单片结构))
        End Structure
        Public Structure 文件单片结构
            ''' <summary>
            ''' 1=分类，2=模组项
            ''' </summary>
            ''' <returns></returns>
            Public Property 分类还是模组项 As Integer
            Public Property 包含的相对路径 As List(Of String)
        End Structure

        Public Shared Sub 加载()
            If Not FileIO.FileSystem.FileExists(设置.导出预设数据保存路径) Then Exit Sub
            预设数据 = JsonSerializer.Deserialize(Of 预设数据结构)(FileIO.FileSystem.ReadAllText(设置.导出预设数据保存路径))
        End Sub
        Public Shared Sub 保存()
            FileIO.FileSystem.WriteAllText(设置.导出预设数据保存路径, JsonSerializer.Serialize(预设数据, Json序列化选项), False)
            UIMessageTip.Show("已保存",, 2500)
        End Sub
    End Class

    Public Shared Property 预设数据 As New 预设数据结构 With {.Data = New List(Of KeyValuePair(Of String, 预设单片结构))}

    Public Shared Sub 初始化()
        初始化预设菜单()
        初始化文件菜单()
        初始化包含内容菜单()
        预设数据结构.加载()
        AddHandler Form1.ListView14.KeyDown, Sub(sender, e) 文件列表键盘按下事件(sender, e)
        AddHandler Form1.ListView15.KeyDown, Sub(sender, e) 内容列表键盘按下事件(sender, e)
        AddHandler Form1.UiButton108.Click, AddressOf 预设数据结构.保存
        AddHandler Form1.UiButton41.Click, AddressOf 执行选中预设
        AddHandler Form1.ListView13.SelectedIndexChanged, Sub()
                                                              If Form1.ListView13.SelectedItems.Count = 1 Then
                                                                  菜单项_刷新文件.PerformClick()
                                                              Else
                                                                  Form1.ListView15.Items.Clear()
                                                                  Form1.ListView14.Items.Clear()
                                                              End If
                                                          End Sub
        AddHandler Form1.ListView14.SelectedIndexChanged, Sub()
                                                              If Form1.ListView14.SelectedItems.Count = 1 Then
                                                                  菜单项_刷新内容.PerformClick()
                                                              Else
                                                                  Form1.ListView15.Items.Clear()
                                                              End If
                                                          End Sub

        AddHandler 管理模组的菜单.菜单项_将分类加入导出预设.Click, Sub()
                                                    If Form1.ListView1.SelectedItems.Count = 0 Then Exit Sub
                                                    If Form1.ListView14.SelectedItems.Count <> 1 Then
                                                        Dim a As New 多项单选对话框("", {"OK"}, "在批量分发管理中选中一个导出文件后再使用此功能添加", , 500)
                                                        a.ShowDialog(Form1)
                                                        Exit Sub
                                                    End If
                                                    Dim 选择的预设索引 As String = Form1.ListView13.SelectedIndices(0)
                                                    Dim 选择的文件索引 As String = Form1.ListView14.SelectedIndices(0)
                                                    If 预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.分类还是模组项 = 2 Then
                                                        Dim a As New 多项单选对话框("", {"OK"}, "当前在批量分发管理中所选的文件是模组项的打包文件，只能添加模组项", , 500)
                                                        a.ShowDialog(Form1)
                                                        Exit Sub
                                                    End If
                                                    Dim 当前所使用的子库 As String = 设置.全局设置数据("LastUsedSubLibraryName")
                                                    For Each s_item As ListViewItem In Form1.ListView1.SelectedItems
                                                        For Each item In 预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.包含的相对路径
                                                            If item.Trim.Equals(s_item.Text.Trim, StringComparison.CurrentCultureIgnoreCase) Then GoTo jx1
                                                        Next
                                                        预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.包含的相对路径.Add(当前所使用的子库 & "\" & s_item.Text)
                                                        Form1.ListView15.Items.Add(当前所使用的子库 & "\" & s_item.Text)
jx1:
                                                    Next
                                                    UIMessageTip.Show("已添加，记得去保存",, 2500)
                                                End Sub
        AddHandler 管理模组的菜单.菜单项_将模组项加入导出预设.Click, Sub()
                                                     If Form1.ListView2.SelectedItems.Count = 0 Then Exit Sub
                                                     If Form1.ListView14.SelectedItems.Count <> 1 Then
                                                         Dim a As New 多项单选对话框("", {"OK"}, "在批量分发管理中选中一个导出文件后再使用此功能添加", , 500)
                                                         a.ShowDialog(Form1)
                                                         Exit Sub
                                                     End If
                                                     Dim 选择的预设索引 As String = Form1.ListView13.SelectedIndices(0)
                                                     Dim 选择的文件索引 As String = Form1.ListView14.SelectedIndices(0)
                                                     If 预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.分类还是模组项 = 1 Then
                                                         Dim a As New 多项单选对话框("", {"OK"}, "当前在批量分发管理中所选的文件是分类的打包文件，只能添加分类", , 500)
                                                         a.ShowDialog(Form1)
                                                         Exit Sub
                                                     End If
                                                     Dim 当前所使用的子库 As String = 设置.全局设置数据("LastUsedSubLibraryName")
                                                     For Each s_item As ListViewItem In Form1.ListView2.SelectedItems
                                                         For Each item In 预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.包含的相对路径
                                                             If item.Trim.Equals(s_item.Text.Trim, StringComparison.CurrentCultureIgnoreCase) Then GoTo jx1
                                                         Next
                                                         预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.包含的相对路径.Add(当前所使用的子库 & "\" & s_item.SubItems(3).Text & "\" & s_item.Text)
                                                         Form1.ListView15.Items.Add(当前所使用的子库 & "\" & s_item.SubItems(3).Text & "\" & s_item.Text)
jx1:
                                                     Next
                                                     UIMessageTip.Show("已添加，记得去保存",, 2500)
                                                 End Sub
        AddHandler Form1.UiButton110.Click, Sub()
                                                Dim a As New 多项单选对话框("Windows PowerShell", {"确定"}, "由于新版本 .NET 框架不再提供 ANSI 编码，我无法从命令提示符运行脚本，所以改成了 Windows PowerShell，请确保系统中的 PowerShell 能够正常运行。" & vbCrLf & vbCrLf & "需要在 Windows 设置中打开允许运行未签名的本地脚本：" & vbCrLf & vbCrLf & "Win10：Windows 设置 -> 更新和安全 -> 开发者选项 -> PowerShell -> 勾选：更改执行策略，以允许本地 PowerShell 脚本在未签名的情况下运行。应用即可。" & vbCrLf & vbCrLf & "Win11：Windows 设置 -> 开发者选项 -> PowerShell，然后启用对应选项即可。", 300, 500)
                                                a.ShowDialog(Form1)
                                            End Sub
        AddHandler Form1.UiButton109.Click, Sub()
                                                If 密码本.导入导出密码本.Count = 0 Then Exit Sub
                                                Dim m As New 暗黑菜单条控件本体 With {.ShowImageMargin = False, .ShowCheckMargin = False}
                                                For i = 0 To 密码本.导入导出密码本.Count - 1
                                                    AddHandler m.Items.Add(密码本.导入导出密码本(i)).Click,
                                                        Sub(s1, e1)
                                                            Form1.暗黑文本框13.Text = s1.text
                                                        End Sub
                                                Next
                                                m.Show(Control.MousePosition)
                                            End Sub

        菜单项_刷新预设.PerformClick()
    End Sub


    Public Shared Property 预设菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_刷新预设 As New ToolStripMenuItem With {.Text = "刷新预设", .Image = My.Resources.刷新}
    Public Shared Property 菜单项_新建预设 As New ToolStripMenuItem With {.Text = "新建预设", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_重命名预设 As New ToolStripMenuItem With {.Text = "重命名预设", .Image = My.Resources.文字大小}
    Public Shared Property 菜单项_删除预设 As New ToolStripMenuItem With {.Text = "删除预设", .Image = My.Resources.删除}

    Public Shared Sub 初始化预设菜单()
        预设菜单.Items.Add(菜单项_刷新预设)
        预设菜单.Items.Add(菜单项_新建预设)
        预设菜单.Items.Add(菜单项_重命名预设)
        预设菜单.Items.Add(菜单项_删除预设)
        AddHandler 菜单项_刷新预设.Click, Sub()
                                       清空数据显示()
                                       For Each item In 预设数据.Data
                                           Form1.ListView13.Items.Add(item.Key)
                                       Next
                                   End Sub
        AddHandler 菜单项_新建预设.Click, Sub()
                                       Dim x As New 输入对话框("", "输入新的预设名称")
                                       Dim x1 = x.ShowDialog(Form1).Trim
                                       If x1 = "" Then Exit Sub
                                       For Each item In 预设数据.Data
                                           If item.Key = x1 Then Exit Sub
                                       Next
                                       预设数据.Data.Add(New KeyValuePair(Of String, 预设单片结构)(x1, New 预设单片结构 With {.文件列表 = New List(Of KeyValuePair(Of String, 文件单片结构))}))
                                       Form1.ListView13.Items.Add(x1)
                                   End Sub
        AddHandler 菜单项_重命名预设.Click, Sub()
                                        If Form1.ListView13.SelectedItems.Count <> 1 Then Exit Sub
                                        Dim x As New 输入对话框("", "重命名预设名称", Form1.ListView13.SelectedItems(0).Text)
                                        Dim x1 = x.ShowDialog(Form1).Trim
                                        If x1 = "" Then Exit Sub
                                        For Each item In 预设数据.Data
                                            If item.Key = x1 Then Exit Sub
                                        Next
                                        Dim d1 As New 预设单片结构 With {
                                            .文件列表 = 预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表
                                        }
                                        预设数据.Data(Form1.ListView13.SelectedIndices(0)) = New KeyValuePair(Of String, 预设单片结构)(x1, d1)
                                        Form1.ListView13.SelectedItems(0).Text = x1
                                    End Sub
        AddHandler 菜单项_删除预设.Click, Sub()
                                       If Form1.ListView13.SelectedItems.Count = 0 Then Exit Sub
                                       Dim d1 As New 多项单选对话框("", {"确认删除", "万万不可"}, "确认删除？",, 500)
                                       Dim s1 As String = d1.ShowDialog(Form1)
                                       If s1 <> 0 Then Exit Sub
                                       Dim i As Integer = 0
                                       Do Until i = Form1.ListView13.Items.Count
                                           If Form1.ListView13.Items(i).Selected Then
                                               预设数据.Data.Remove(预设数据.Data(i))
                                               Form1.ListView13.Items(i).Remove()
                                               i -= 1
                                           End If
                                           i += 1
                                       Loop
                                   End Sub
        AddHandler Form1.UiButton107.MouseDown, Sub() 预设菜单.Show(Form1.UiButton107, New Point(0, Form1.UiButton107.Height))
    End Sub

    Public Shared Sub 清空数据显示()
        Form1.ListView15.Items.Clear()
        Form1.ListView14.Items.Clear()
        Form1.ListView13.Items.Clear()
    End Sub

    Public Shared Property 文件菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_刷新文件 As New ToolStripMenuItem With {.Text = "刷新文件", .Image = My.Resources.刷新}
    Public Shared Property 菜单项_新建分类文件 As New ToolStripMenuItem With {.Text = "新建分类打包文件", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_新建模组项文件 As New ToolStripMenuItem With {.Text = "新建模组项打包文件", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_重命名文件 As New ToolStripMenuItem With {.Text = "重命名文件", .Image = My.Resources.文字大小}
    Public Shared Property 菜单项_删除文件 As New ToolStripMenuItem With {.Text = "删除文件", .Image = My.Resources.删除}

    Public Shared Sub 初始化文件菜单()
        文件菜单.Items.Add(菜单项_刷新文件)
        文件菜单.Items.Add(菜单项_新建分类文件)
        文件菜单.Items.Add(菜单项_新建模组项文件)
        文件菜单.Items.Add(菜单项_重命名文件)
        文件菜单.Items.Add(菜单项_删除文件)
        AddHandler 菜单项_刷新文件.Click, Sub()
                                       If Form1.ListView13.SelectedItems.Count <> 1 Then Exit Sub
                                       Form1.ListView15.Items.Clear()
                                       Form1.ListView14.Items.Clear()
                                       If 预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表 IsNot Nothing Then
                                           For Each item In 预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表
                                               Form1.ListView14.Items.Add(item.Key)
                                               If item.Value.分类还是模组项 = 1 Then
                                                   Form1.ListView14.Items(Form1.ListView14.Items.Count - 1).ForeColor = Color1.紫色
                                               Else
                                                   Form1.ListView14.Items(Form1.ListView14.Items.Count - 1).ForeColor = Color1.蓝色
                                               End If
                                           Next
                                       End If
                                   End Sub
        AddHandler 菜单项_新建分类文件.Click, Sub()
                                         If Form1.ListView13.SelectedItems.Count <> 1 Then Exit Sub
                                         Dim x As New 输入对话框("", "输入新的导出文件名称，不含后缀，此文件将作为分类的打包，显示为紫色")
                                         Dim x1 = x.ShowDialog(Form1).Trim
                                         If x1 = "" Then Exit Sub
                                         If 预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表 IsNot Nothing Then
                                             For Each item In 预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表
                                                 If item.Key = x1 Then Exit Sub
                                             Next
                                         End If
                                         预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表.Add(New KeyValuePair(Of String, 文件单片结构)(x1, New 文件单片结构 With {.分类还是模组项 = 1, .包含的相对路径 = New List(Of String)}))
                                         Form1.ListView14.Items.Add(x1)
                                         Form1.ListView14.Items(Form1.ListView14.Items.Count - 1).ForeColor = Color1.紫色
                                     End Sub
        AddHandler 菜单项_新建模组项文件.Click, Sub()
                                          If Form1.ListView13.SelectedItems.Count <> 1 Then Exit Sub
                                          Dim x As New 输入对话框("", "输入新的导出文件名称，不含后缀，此文件将作为模组项的打包，显示为蓝色")
                                          Dim x1 = x.ShowDialog(Form1).Trim
                                          If x1 = "" Then Exit Sub
                                          If 预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表 IsNot Nothing Then
                                              For Each item In 预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表
                                                  If item.Key = x1 Then Exit Sub
                                              Next
                                          End If
                                          预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表.Add(New KeyValuePair(Of String, 文件单片结构)(x1, New 文件单片结构 With {.分类还是模组项 = 2, .包含的相对路径 = New List(Of String)}))
                                          Form1.ListView14.Items.Add(x1)
                                          Form1.ListView14.Items(Form1.ListView14.Items.Count - 1).ForeColor = Color1.蓝色
                                      End Sub
        AddHandler 菜单项_重命名文件.Click, Sub()
                                        If Form1.ListView14.SelectedItems.Count <> 1 Then Exit Sub
                                        Dim x As New 输入对话框("", "重命名导出文件名称", Form1.ListView14.SelectedItems(0).Text)
                                        Dim x1 = x.ShowDialog(Form1).Trim
                                        If x1 = "" Then Exit Sub
                                        If 预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表 IsNot Nothing Then
                                            For Each item In 预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表
                                                If item.Key = x1 Then Exit Sub
                                            Next
                                        End If
                                        Dim d1 As New 文件单片结构 With {
                                                .分类还是模组项 = 预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表(Form1.ListView14.SelectedIndices(0)).Value.分类还是模组项,
                                                .包含的相对路径 = 预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表(Form1.ListView14.SelectedIndices(0)).Value.包含的相对路径
                                        }
                                        预设数据.Data(Form1.ListView13.SelectedIndices(0)).Value.文件列表(Form1.ListView14.SelectedIndices(0)) = New KeyValuePair(Of String, 文件单片结构)(x1, d1)
                                        Form1.ListView14.SelectedItems(0).Text = x1
                                    End Sub
        AddHandler 菜单项_删除文件.Click, Sub()
                                       If Form1.ListView14.SelectedItems.Count = 0 Then Exit Sub
                                       Dim d1 As New 多项单选对话框("", {"确认删除", "万万不可"}, "确认删除？",, 500)
                                       Dim s1 As String = d1.ShowDialog(Form1)
                                       If s1 <> 0 Then Exit Sub
                                       Dim i As Integer = 0
                                       Dim 选择的预设 As String = Form1.ListView13.SelectedIndices(0)
                                       Do Until i = Form1.ListView14.Items.Count
                                           If Form1.ListView14.Items(i).Selected Then
                                               预设数据.Data(选择的预设).Value.文件列表.Remove(预设数据.Data(选择的预设).Value.文件列表(i))
                                               Form1.ListView14.Items(i).Remove()
                                               i -= 1
                                           End If
                                           i += 1
                                       Loop
                                   End Sub
        AddHandler Form1.UiButton111.MouseDown, Sub() 文件菜单.Show(Form1.UiButton111, New Point(0, Form1.UiButton111.Height))
    End Sub

    Public Shared Property 包含内容菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_刷新内容 As New ToolStripMenuItem With {.Text = "刷新内容", .Image = My.Resources.刷新}
    Public Shared Property 菜单项_移除内容 As New ToolStripMenuItem With {.Text = "移除内容", .Image = My.Resources.叉号}

    Public Shared Sub 初始化包含内容菜单()
        包含内容菜单.Items.Add(菜单项_刷新内容)
        包含内容菜单.Items.Add(菜单项_移除内容)
        AddHandler 菜单项_刷新内容.Click, Sub()
                                       If Form1.ListView14.SelectedItems.Count <> 1 Then Exit Sub
                                       Form1.ListView15.Items.Clear()
                                       Dim 选择的预设索引 As String = Form1.ListView13.SelectedIndices(0)
                                       Dim 选择的文件索引 As String = Form1.ListView14.SelectedIndices(0)
                                       If 预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.包含的相对路径 IsNot Nothing Then
                                           For Each item In 预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.包含的相对路径
                                               Form1.ListView15.Items.Add(item)
                                           Next
                                       End If
                                   End Sub
        AddHandler 菜单项_移除内容.Click, Sub()
                                       If Form1.ListView15.SelectedItems.Count = 0 Then Exit Sub
                                       Dim i As Integer = 0
                                       Dim 选择的预设索引 As String = Form1.ListView13.SelectedIndices(0)
                                       Dim 选择的文件索引 As String = Form1.ListView14.SelectedIndices(0)
                                       Do Until i = Form1.ListView15.Items.Count
                                           If Form1.ListView15.Items(i).Selected Then
                                               预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.包含的相对路径.Remove(Form1.ListView15.Items(i).Text)
                                               Form1.ListView15.Items(i).Remove()
                                               i -= 1
                                           End If
                                           i += 1
                                       Loop
                                   End Sub
        AddHandler Form1.UiButton106.MouseDown, Sub() 包含内容菜单.Show(Form1.UiButton106, New Point(0, Form1.UiButton106.Height))
    End Sub

    Public Shared Sub 执行选中预设()
        If Not DLC.DLC解锁标记.DistributionExtension Then
            UIMessageTip.Show("需要激活 DLC 5 才可使用此功能",, 2000)
            Exit Sub
        End If
        If Form1.ListView13.SelectedItems.Count = 0 Then
            UIMessageTip.Show("选中一个预设再使用此功能",, 2000)
            Exit Sub
        End If
        If Form1.ListView13.SelectedItems.Count >= 2 Then
            UIMessageTip.Show("不支持多选，一次只能处理一个预设的执行",, 2000)
            Exit Sub
        End If
        Dim str1 As String = ""
        If Not DirEx.SelectDirEx("选择将这些打包文件输出到哪个文件夹", str1) Then Exit Sub
        Dim str As String = "$host.UI.RawUI.WindowTitle = " & """" & Form1.ListView13.SelectedItems(0).Text & """"
        Dim 选择的预设索引 As String = Form1.ListView13.SelectedIndices(0)
        str &= vbCrLf & My.Resources.DLC5导出时删除存在文件模板
        For Each FileItem In 预设数据.Data(选择的预设索引).Value.文件列表
            Dim 单个导出文件路径 = Path.Combine(str1, FileItem.Key & If(FileItem.Value.分类还是模组项 = 1, ".smuicpak", ".smuimpak"))
            str &= vbCrLf & "Remove-FileToRecycleBin -filePath " & """" & 单个导出文件路径 & """"
            str &= vbCrLf & "& " & """" & Path.Combine(Application.StartupPath, "7za64", "7z.exe") & """"
            str &= " a " & """" & 单个导出文件路径 & """" & " "
            For Each FileCC In FileItem.Value.包含的相对路径
                str &= " " & """" & Path.Combine(设置.全局设置数据("LocalRepositoryPath"), FileCC) & "\" & """"
            Next
            If Form1.UiCheckBox2.Checked = True And Form1.暗黑文本框13.Text <> "" Then
                str &= " -p" & Form1.暗黑文本框13.Text & " -mhe"
            End If
        Next
        If Form1.UiCheckBox2.Checked = True And Form1.暗黑文本框13.Text <> "" Then
            str &= vbCrLf & "Write-Host " & """" & "如果你忘记了设置的密码，可以到用户配置文件夹，用记事本或其他编辑器打开最后的 DLC5.ps1 脚本文件查看即可，但是不要运行它，防止造成意外事故" & """"
            str &= vbCrLf & "Write-Host " & """" & "密码：" & Form1.暗黑文本框13.Text & """"
        End If
        str &= vbCrLf & "pause"
        FileIO.FileSystem.WriteAllText(Path.Combine(设置.用户数据文件夹路径, "DLC5.ps1"), str, False, Encoding.UTF8)
        Process.Start("powershell.exe", "-File " & """" & Path.Combine(设置.用户数据文件夹路径, "DLC5.ps1") & """")
        密码本.添加导入导出密码到密码本中(Form1.暗黑文本框13.Text)
    End Sub

    Public Shared Sub 文件列表键盘按下事件(sender As Object, e As KeyEventArgs)
        e.SuppressKeyPress = True
        Select Case e.KeyCode
            Case Keys.F3
                上移选中的文件()
            Case Keys.F4
                下移选中的文件()
        End Select
    End Sub

    Public Shared Sub 内容列表键盘按下事件(sender As Object, e As KeyEventArgs)
        e.SuppressKeyPress = True
        Select Case e.KeyCode
            Case Keys.F3
                上移选中的内容()
            Case Keys.F4
                下移选中的内容()
        End Select
    End Sub

    Public Shared Sub 上移选中的文件()
        If Form1.ListView14.SelectedIndices.Count > 0 Then
            Dim 选择的预设索引 As String = Form1.ListView13.SelectedIndices(0)
            For i = 0 To Form1.ListView14.SelectedIndices.Count - 1
                Dim index As Integer = Form1.ListView14.SelectedIndices(i)
                If index > 0 Then
                    If Form1.ListView14.SelectedIndices.Contains(index - 1) Then Continue For
                    Dim 变动排序的列表视图项 As ListViewItem = Form1.ListView14.Items(index)
                    Form1.ListView14.Items.RemoveAt(index)
                    Form1.ListView14.Items.Insert(index - 1, 变动排序的列表视图项)
                    Form1.ListView14.Items(index - 1).Focused = True
                    Dim 变动排序的键值对 = 预设数据.Data(选择的预设索引).Value.文件列表(index)
                    预设数据.Data(选择的预设索引).Value.文件列表.RemoveAt(index)
                    预设数据.Data(选择的预设索引).Value.文件列表.Insert(index - 1, 变动排序的键值对)
                End If
            Next
        End If
    End Sub

    Public Shared Sub 下移选中的文件()
        If Form1.ListView14.SelectedIndices.Count > 0 Then
            Dim 选择的预设索引 As String = Form1.ListView13.SelectedIndices(0)
            For i = Form1.ListView14.SelectedIndices.Count - 1 To 0 Step -1
                Dim index As Integer = Form1.ListView14.SelectedIndices(i)
                If index < Form1.ListView14.Items.Count - 1 Then
                    If Form1.ListView14.SelectedIndices.Contains(index + 1) Then Continue For
                    Dim 变动排序的列表视图项 As ListViewItem = Form1.ListView14.Items(index)
                    Form1.ListView14.Items.RemoveAt(index)
                    Form1.ListView14.Items.Insert(index + 1, 变动排序的列表视图项)
                    Form1.ListView14.Items(index + 1).Focused = True
                    Dim 变动排序的键值对 = 预设数据.Data(选择的预设索引).Value.文件列表(index)
                    预设数据.Data(选择的预设索引).Value.文件列表.RemoveAt(index)
                    预设数据.Data(选择的预设索引).Value.文件列表.Insert(index + 1, 变动排序的键值对)
                End If
            Next
        End If
    End Sub

    Public Shared Sub 上移选中的内容()
        If Form1.ListView15.SelectedIndices.Count > 0 Then
            Dim 选择的预设索引 As String = Form1.ListView13.SelectedIndices(0)
            Dim 选择的文件索引 As String = Form1.ListView14.SelectedIndices(0)
            For i = 0 To Form1.ListView15.SelectedIndices.Count - 1
                Dim index As Integer = Form1.ListView15.SelectedIndices(i)
                If index > 0 Then
                    If Form1.ListView15.SelectedIndices.Contains(index - 1) Then Continue For
                    Dim 变动排序的列表视图项 As ListViewItem = Form1.ListView15.Items(index)
                    Form1.ListView15.Items.RemoveAt(index)
                    Form1.ListView15.Items.Insert(index - 1, 变动排序的列表视图项)
                    Form1.ListView15.Items(index - 1).Focused = True
                    Dim 变动排序的元素 = 预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.包含的相对路径(index)
                    预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.包含的相对路径.RemoveAt(index)
                    预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.包含的相对路径.Insert(index - 1, 变动排序的元素)
                End If
            Next
        End If
    End Sub

    Public Shared Sub 下移选中的内容()
        If Form1.ListView15.SelectedIndices.Count > 0 Then
            Dim 选择的预设索引 As String = Form1.ListView13.SelectedIndices(0)
            Dim 选择的文件索引 As String = Form1.ListView14.SelectedIndices(0)
            For i = Form1.ListView15.SelectedIndices.Count - 1 To 0 Step -1
                Dim index As Integer = Form1.ListView15.SelectedIndices(i)
                If index < Form1.ListView15.Items.Count - 1 Then
                    If Form1.ListView15.SelectedIndices.Contains(index + 1) Then Continue For
                    Dim 变动排序的列表视图项 As ListViewItem = Form1.ListView15.Items(index)
                    Form1.ListView15.Items.RemoveAt(index)
                    Form1.ListView15.Items.Insert(index + 1, 变动排序的列表视图项)
                    Form1.ListView15.Items(index + 1).Focused = True
                    Dim 变动排序的元素 = 预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.包含的相对路径(index)
                    预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.包含的相对路径.RemoveAt(index)
                    预设数据.Data(选择的预设索引).Value.文件列表(选择的文件索引).Value.包含的相对路径.Insert(index + 1, 变动排序的元素)
                End If
            Next
        End If
    End Sub


End Class
