
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form批量创建

    Public Property 此窗口的DPI As Single = 1

    Private Sub Form批量创建_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(Me.MinimumSize.Width * 此窗口的DPI, Me.MinimumSize.Height * 此窗口的DPI)
        此窗口的DPI = Me.CreateGraphics.DpiX / 96
        Me.ImageList1.ImageSize = New Size(1, 25 * 此窗口的DPI)
        暗黑列表视图自绘制.绑定列表视图事件(Me.ListView1)

        For Each item As ListViewItem In Form1.ListView1.Items
            Me.UiComboBox1.Items.Add(item.Text)
        Next
        Dim s2 As List(Of String) = 共享方法.SearchFolderWithoutSub(设置.全局设置数据("StardewValleyGamePath") & "\Mods")
        '这里已经有斜杠了，下边的拼接不要加
        Dim str2 As String = 设置.全局设置数据("StardewValleyGamePath") & "\Mods\"
        For i = 0 To s2.Count - 1
            Select Case s2(i)
                Case "ConsoleCommands", "ErrorHandler", "SaveBackup"
                    Continue For
            End Select

            Me.ListView1.Items.Add(s2(i))
            If My.Computer.FileSystem.FileExists(str2 & s2(i) & "\manifest.json") = True Then
                Dim b As String = ""
                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(My.Computer.FileSystem.ReadAllText(str2 & s2(i) & "\manifest.json")), JObject)
                If JsonData.item("EntryDll") IsNot Nothing Then
                    b &= "EntryDll - "
                Else
                    b &= "Content Pak - "
                End If
                If JsonData.item("Version") IsNot Nothing Then
                    b &= "v" & JsonData.item("Version").ToString
                Else
                    b &= "unknow"
                End If
                Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add(b)
                Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add("可以操作")
            Else
                Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add("不是标准模组或者套娃放置")
                Me.ListView1.Items(Me.ListView1.Items.Count - 1).SubItems.Add("不能操作")
                Me.ListView1.Items(Me.ListView1.Items.Count - 1).ForeColor = Color1.红色
            End If
        Next


    End Sub

    Private Sub Form批量创建_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        调整界面()
    End Sub

    Private Sub Form批量创建_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        调整界面()
    End Sub

    Private Sub Form批量创建_DpiChanged(sender As Object, e As DpiChangedEventArgs) Handles Me.DpiChanged
        此窗口的DPI = e.DeviceDpiNew / 96
        调整界面()
    End Sub

    Sub 调整界面()
        Me.UiRadioButton1.Height = Me.UiButton1.Height * 0.5
        Me.UiRadioButton2.Height = Me.UiButton1.Height * 0.5
        Me.UiComboBox1.Height = 30 * 此窗口的DPI
        Me.UiComboBox1.Left = 20 * 此窗口的DPI
        Me.UiComboBox1.Top = 154 * 此窗口的DPI

        Me.ColumnHeader1.Width = (Me.ListView1.Width - 30 * 此窗口的DPI) * 0.5
        Me.ColumnHeader2.Width = (Me.ListView1.Width - 30 * 此窗口的DPI) * 0.3
        Me.ColumnHeader3.Width = (Me.ListView1.Width - 30 * 此窗口的DPI) * 0.2
    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        If Me.UiRadioButton1.Checked = False And Me.UiRadioButton2.Checked = False Then
            Dim a As New 多项单选对话框("", {"确定"}, "没选择操作类型", 100, 500)
            a.ShowDialog(Me) : Exit Sub
        End If
        If Me.UiRadioButton2.Checked = True And Me.暗黑文本框1.Text = "" Then
            Dim a As New 多项单选对话框("", {"确定"}, "选择多个文件夹创建成一个项时没填项名称", 100, 500)
            a.ShowDialog(Me) : Exit Sub
        End If
        If Me.UiComboBox1.Text = "" Then
            Dim a As New 多项单选对话框("", {"确定"}, "没有选择分类", 100, 500)
            a.ShowDialog(Me) : Exit Sub
        End If
        Dim d1 As New 多项单选对话框("", {"开始", "取消"}, "是否开始批量创建", 100, 500)
        Dim back1 As Integer = d1.ShowDialog(Me)
        If back1 <> 0 Then Exit Sub

        If Me.UiRadioButton1.Checked = True Then
            Form1.UiTabControl1.SelectedTab = Form1.TabPage调试输出
            开始批量创建项()
        End If
        If Me.UiRadioButton2.Checked = True Then
            Form1.UiTabControl1.SelectedTab = Form1.TabPage调试输出
            开始创建一个项()
        End If
    End Sub

    Sub 开始批量创建项()
        Dim 要批量创建项的路径数据列表 As New List(Of String)
        For Each item As ListViewItem In Me.ListView1.SelectedItems
            要批量创建项的路径数据列表.Add(设置.全局设置数据("StardewValleyGamePath") & "\Mods\" & item.Text)
        Next

        For i = 0 To 要批量创建项的路径数据列表.Count - 1
            Dim str1 As String = 管理模组2.检查并返回当前所选子库路径(False) & "\" & Me.UiComboBox1.Text & "\" & IO.Path.GetFileName(要批量创建项的路径数据列表(i))
            Dim str2 As String = IO.Path.GetFileName(要批量创建项的路径数据列表(i))
            If FileIO.FileSystem.DirectoryExists(str1) = True Then
                DebugPrint("目标模组项已存在，跳过：" & str2, Color1.黄色)
            Else
                DebugPrint("正在创建模组项：" & str2, Color1.紫色)
                FileIO.FileSystem.CreateDirectory(str1)
                DebugPrint("正在复制文件夹：" & str2, Color1.白色)
                FileIO.FileSystem.CopyDirectory(要批量创建项的路径数据列表(i), str1 & "\" & str2)
                DebugPrint("正在编写安装规划数据：" & str2, Color1.白色)
                FileIO.FileSystem.WriteAllText(str1 & "\Code2", "CD-D-MODS=" & str2, False)
                DebugPrint("创建成功：" & str2, Color1.绿色)
            End If
        Next

    End Sub

    Sub 开始创建一个项()
        Dim 要创建一个项的路径数据列表 As New List(Of String)
        For Each item As ListViewItem In Me.ListView1.SelectedItems
            要创建一个项的路径数据列表.Add(设置.全局设置数据("StardewValleyGamePath") & "\Mods\" & item.Text)
        Next

        Dim str_1 As String = 管理模组2.检查并返回当前所选子库路径(False) & "\" & Me.UiComboBox1.Text & "\" & Me.暗黑文本框1.Text
        Dim str_2 As String = Me.暗黑文本框1.Text
        If FileIO.FileSystem.DirectoryExists(str_1) = True Then
            DebugPrint("目标模组项已存在，跳过：" & str_2, Color1.黄色)
        Else
            DebugPrint("正在将多个文件夹创建为一个模组项：" & Me.暗黑文本框1.Text, Color1.紫色)
            FileIO.FileSystem.CreateDirectory(str_1)
            For i = 0 To 要创建一个项的路径数据列表.Count - 1
                Dim str_3 As String = IO.Path.GetFileName(要创建一个项的路径数据列表(i))
                DebugPrint("正在复制文件夹：" & str_3, Color1.白色)
                FileIO.FileSystem.CopyDirectory(要创建一个项的路径数据列表(i), str_1 & "\" & str_3)
            Next
            DebugPrint("正在编写安装规划数据：" & str_2, Color1.白色)
            Dim str_安装命令 As String = ""
            For i = 0 To 要创建一个项的路径数据列表.Count - 1
                If str_安装命令 = "" Then
                    str_安装命令 = "CD-D-MODS=" & vbCrLf & IO.Path.GetFileName(要创建一个项的路径数据列表(i))
                Else
                    str_安装命令 &= vbCrLf & "CD-D-MODS=" & vbCrLf & IO.Path.GetFileName(要创建一个项的路径数据列表(i))
                End If
            Next
            FileIO.FileSystem.WriteAllText(str_1 & "\Code2", str_安装命令, False)
            DebugPrint("创建成功：" & str_2, Color1.绿色)
        End If
    End Sub



End Class