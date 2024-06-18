Imports System.IO
Imports System.Xml
Imports Sunny.UI

Public Class 存档编辑器

    Public Shared Sub 初始化()
        Using reader As New StringReader(FileIO.FileSystem.ReadAllText("Assets\SaveEditorItems"))
            Dim line As String = reader.ReadLine()
            While line IsNot Nothing
                Dim items As String() = line.Split("|"c)
                If items.Length = 4 Then
                    Dim listViewItem As New ListViewItem(items)
                    Form1.ListView5.Items.Add(listViewItem)
                End If
                line = reader.ReadLine()
            End While
        End Using

        If FileIO.FileSystem.FileExists(Path.Combine(设置.用户数据文件夹路径, "UserSaveEditorItems.txt")) Then
            Using reader As New StringReader(FileIO.FileSystem.ReadAllText(Path.Combine(设置.用户数据文件夹路径, "UserSaveEditorItems.txt")))
                Dim line As String = reader.ReadLine()
                While line IsNot Nothing
                    Dim items As String() = line.Split("|"c)
                    If items.Length = 4 Then
                        Dim listViewItem As New ListViewItem(items)
                        Form1.ListView5.Items.Add(listViewItem)
                    End If
                    line = reader.ReadLine()
                End While
            End Using
        End If

        AddHandler Form1.UiButton99.Click, AddressOf 扫描存档
        AddHandler Form1.UiButton100.MouseClick, Sub() 存档列表菜单.Show(Form1.UiButton100, 0, Form1.UiButton100.Height)
        AddHandler Form1.ListView5.DoubleClick, AddressOf 修改值
        AddHandler Form1.UiButton101.Click, AddressOf 保存改动
        AddHandler Form1.UiButton102.Click, AddressOf 释放内存
        AddHandler Form1.ListView5.KeyDown, Sub(sender, e)
                                                Select Case e.KeyCode
                                                    Case Keys.C
                                                        If Form1.ListView5.SelectedItems.Count <> 1 Then Exit Sub
                                                        If e.Control Then Clipboard.SetText(Form1.ListView5.SelectedItems(0).SubItems(2).Text)
                                                End Select
                                            End Sub
    End Sub

    Public Shared ReadOnly Property Wsh As New IWshRuntimeLibrary.IWshShell_Class
    Public Shared Property 存档路径 As String = Wsh.SpecialFolders.Item("AppData") & "\StardewValley\Saves"
    Public Shared Property 存档列表菜单 As New 暗黑菜单条控件本体
    Public Shared Property Xmldoc1 As XmlDocument
    Public Shared Property Xmldoc2 As XmlDocument

    Public Shared Sub 扫描存档()
        释放内存()
        存档列表菜单.Items.Clear()
        Dim mDir As IO.DirectoryInfo
        Dim mDirInfo As New IO.DirectoryInfo(存档路径)
        For Each mDir In mDirInfo.GetDirectories
            Dim a As New ToolStripMenuItem With {
                .Text = mDir.Name
            }
            存档列表菜单.Items.Add(a)
            AddHandler a.Click,
                Sub(s1, e1)
                    Form1.UiButton100.Text = s1.Text
                    Application.DoEvents()
                    读取存档()
                End Sub
        Next
        UIMessageTip.Show($"扫描到 {存档列表菜单.Items.Count } 个存档",, 1500)
    End Sub

    Public Shared Sub 读取存档()
        If Form1.UiButton100.Text = "选择存档" Or FileIO.FileSystem.DirectoryExists(存档路径 & "\" & Form1.UiButton100.Text) = False Then
            释放内存()
            Exit Sub
        End If
        Xmldoc1 = New XmlDocument
        Xmldoc2 = New XmlDocument
        Xmldoc1.Load(存档路径 & "\" & Form1.UiButton100.Text & "\" & "SaveGameInfo")
        Xmldoc2.Load(存档路径 & "\" & Form1.UiButton100.Text & "\" & Form1.UiButton100.Text)
        For i = 0 To Form1.ListView5.Items.Count - 1
            Select Case Form1.ListView5.Items(i).SubItems(1).Text
                Case "SaveGameInfo"
                    If Xmldoc1.SelectSingleNode(Form1.ListView5.Items(i).SubItems(2).Text) Is Nothing Then
                        Form1.ListView5.Items(i).SubItems(3).Text = "找不到此节点"
                        Continue For
                    End If
                    Form1.ListView5.Items(i).SubItems(3).Text = Xmldoc1.SelectSingleNode(Form1.ListView5.Items(i).SubItems(2).Text).InnerText
                Case "[game]"
                    If Xmldoc2.SelectSingleNode(Form1.ListView5.Items(i).SubItems(2).Text) Is Nothing Then
                        Form1.ListView5.Items(i).SubItems(3).Text = "找不到此节点"
                        Continue For
                    End If
                    Form1.ListView5.Items(i).SubItems(3).Text = Xmldoc2.SelectSingleNode(Form1.ListView5.Items(i).SubItems(2).Text).InnerText
            End Select
        Next
        GC.Collect()
    End Sub

    Public Shared Sub 修改值()
        If Form1.UiButton100.Text = "选择存档" Or Form1.ListView5.SelectedItems.Count <> 1 Then Exit Sub
        Select Case Form1.ListView5.SelectedItems(0).SubItems(1).Text
            Case "SaveGameInfo"
                If Xmldoc1.SelectSingleNode(Form1.ListView5.SelectedItems(0).SubItems(2).Text) Is Nothing Then Exit Sub
            Case "[game]"
                If Xmldoc2.SelectSingleNode(Form1.ListView5.SelectedItems(0).SubItems(2).Text) Is Nothing Then Exit Sub
        End Select
        Dim a As New 输入对话框("", "输入新的值", Form1.ListView5.SelectedItems(0).SubItems(3).Text)
        Dim s1 As String = a.ShowDialog(Form1)
        If s1 <> "" Then
            Select Case Form1.ListView5.SelectedItems(0).SubItems(1).Text
                Case "SaveGameInfo"
                    Xmldoc1.SelectSingleNode(Form1.ListView5.SelectedItems(0).SubItems(2).Text).InnerText = s1
                Case "[game]"
                    Xmldoc2.SelectSingleNode(Form1.ListView5.SelectedItems(0).SubItems(2).Text).InnerText = s1
            End Select
            Form1.ListView5.SelectedItems(0).SubItems(3).Text = s1
        End If
    End Sub

    Public Shared Sub 保存改动()
        If Form1.UiButton100.Text = "选择存档" Then Exit Sub
        If FileIO.FileSystem.DirectoryExists(存档路径 & "\" & Form1.UiButton100.Text) = True Then
            Xmldoc1.Save(存档路径 & "\" & Form1.UiButton100.Text & "\" & "SaveGameInfo")
            Xmldoc2.Save(存档路径 & "\" & Form1.UiButton100.Text & "\" & Form1.UiButton100.Text)
            UIMessageTip.Show("已保存到：" & Form1.UiButton100.Text,, 2000)
        Else
            UIMessageTip.Show("存档文件夹不存在，无法保存" & Form1.UiButton100.Text,, 2000)
        End If
    End Sub

    Public Shared Sub 释放内存()
        Xmldoc1 = Nothing
        Xmldoc2 = Nothing
        GC.Collect()
        GC.WaitForPendingFinalizers()
        For i = 0 To Form1.ListView5.Items.Count - 1
            Form1.ListView5.Items(i).SubItems(3).Text = ""
        Next
        Form1.UiButton100.Text = "选择存档"
    End Sub

End Class
