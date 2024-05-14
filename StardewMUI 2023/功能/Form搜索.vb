Imports System.ComponentModel
Imports System.IO
Imports Sunny.UI

Public Class Form搜索
    Private Sub Form搜索_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Dim 搜索历史 As New List(Of String)
    Dim 搜索结果 As New List(Of String)
    Dim 搜索类型 As SearchItem.SearchType

    Private Sub UiButton35_Click(sender As Object, e As EventArgs) Handles UiButton35.Click
        If 管理模组2.检查并返回当前所选子库路径(True) = "" Then Exit Sub
        If Me.BackgroundWorker1.IsBusy = True Then Exit Sub
        If Me.UiRadioButton1.Checked = True Then
            搜索类型 = SearchItem.SearchType.ItemName
        ElseIf Me.UiRadioButton2.Checked = True Then
            搜索类型 = SearchItem.SearchType.NameKey
        ElseIf Me.UiRadioButton3.Checked = True Then
            搜索类型 = SearchItem.SearchType.AuthorKey
        ElseIf Me.UiRadioButton4.Checked = True Then
            搜索类型 = SearchItem.SearchType.UniqueID
        ElseIf Me.UiRadioButton5.Checked = True Then
            搜索类型 = SearchItem.SearchType.ContentPakForAndDependencies
        ElseIf Me.UiRadioButton6.Checked = True Then
            搜索类型 = SearchItem.SearchType.IncludedFolders
        ElseIf Me.UiRadioButton7.Checked = True Then
            搜索类型 = SearchItem.SearchType.NexusID
        ElseIf Me.UiRadioButton8.Checked = True Then
            搜索类型 = SearchItem.SearchType.NexusID
        End If
        管理模组.清除模组项列表()
        Me.Text = "正在搜索"
        Application.DoEvents()
        Me.BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim a As New SearchItem
        If Me.UiCheckBox1.Checked = True Then a.ST_NotCaseUpperAndLowerLetters = True
        If Me.UiCheckBox2.Checked = True Then a.ST_NotCaseCHS_ENG_Symbol = True
        If Me.UiCheckBox3.Checked = True Then a.ST_SingleCharacterFuzzySearch = True
        Dim stra As String = a.StartSearch(管理模组2.检查并返回当前所选子库路径(False), Me.暗黑文本框1.Text, 搜索类型)
        搜索结果 = a.Results
        e.Result = stra
        If Not 搜索历史.Contains(Me.暗黑文本框1.Text) Then 搜索历史.Add(Me.暗黑文本框1.Text)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Result <> "" Then
            MsgBox(e.Result, MsgBoxStyle.Critical)
            Exit Sub
        End If
        For i = 0 To 搜索结果.Count - 1
            Form1.ListView2.Items.Add(Path.GetFileName(搜索结果(i)))
            Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add("")
            Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add("")
            Form1.ListView2.Items(Form1.ListView2.Items.Count - 1).SubItems.Add(Path.GetFileName(Path.GetDirectoryName(搜索结果(i))))
        Next
        Me.Text = "搜索完成"
        刷新项列表数据()
        Form1.Label51.Text = Form1.ListView2.Items.Count
    End Sub


    ReadOnly a As New 暗黑菜单条控件本体 With {
        .ShowImageMargin = False,
        .DropShadowEnabled = False,
        .ShowCheckMargin = False
    }

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        a.Items.Clear()
        For i = 0 To 搜索历史.Count - 1
            AddHandler a.Items.Add(搜索历史(i)).Click,
                Sub(s1, e1)
                    Me.暗黑文本框1.Text = s1.Text
                End Sub
        Next
        a.Show(MousePosition)
    End Sub

    Sub 刷新项列表数据()
        For i = 0 To Form1.ListView2.Items.Count - 1
            Dim 项路径 As String = Path.Combine(管理模组2.检查并返回当前所选子库路径(False), Form1.ListView2.Items(i).SubItems(3).Text, Form1.ListView2.Items(i).Text)
            Dim a As New 项信息读取类
            Dim ct As New 公共对象.项数据计算类型结构 With {.安装状态 = True, .版本 = True, .已安装版本 = True}
            If Not FileIO.FileSystem.FileExists(Path.Combine(项路径, "Code2")) Then
                If FileIO.FileSystem.FileExists(Path.Combine(项路径, "Code")) Then
                    FileIO.FileSystem.WriteAllText(Path.Combine(项路径, "Code2"), 命令规划转换.将安装命令转换到安装规划(FileIO.FileSystem.ReadAllText(Path.Combine(项路径, "Code"))), False)
                End If
            End If
            a.读取项信息(项路径, ct, 设置.全局设置数据("StardewValleyGamePath"))
            If a.错误信息 <> "" Then Continue For
            If a.版本.Count > 0 And a.已安装版本.Count > 0 Then
                If a.版本(0) <> a.已安装版本(0) Then
                    If a.安装状态 = 公共对象.安装状态枚举.安装不完整 Then
                        Form1.ListView2.Items(i).SubItems(1).Text = a.版本(0)
                        GoTo 结束版本号高低判断
                    End If
                    Select Case 共享方法.CompareVersion(a.版本(0), a.已安装版本(0))
                        Case = 0
                            Form1.ListView2.Items(i).SubItems(1).Text = a.版本(0)
                        Case > 0
                            Form1.ListView2.Items(i).SubItems(1).Text = a.版本(0) & " ← " & a.已安装版本(0)
                            Form1.ListView2.Items(i).SubItems(2).Text = "更新可用"
                        Case < 0
                            Form1.ListView2.Items(i).SubItems(1).Text = a.版本(0) & " → " & a.已安装版本(0)
                            Form1.ListView2.Items(i).SubItems(2).Text = "已有新的"
                    End Select
                Else
                    Form1.ListView2.Items(i).SubItems(1).Text = a.版本(0)
                End If
结束版本号高低判断:
            Else
                If a.版本.Count > 0 Then
                    Form1.ListView2.Items(i).SubItems(1).Text = a.版本(0)
                ElseIf FileIO.FileSystem.FileExists(Path.Combine(项路径, "Version")) = True Then
                    Form1.ListView2.Items(i).SubItems(1).Text = FileIO.FileSystem.ReadAllText(Path.Combine(项路径, "Version"))
                Else
                    Form1.ListView2.Items(i).SubItems(1).Text = "未知版本"
                End If
                Form1.ListView2.Items(i).ForeColor = Color1.白色
            End If

            Select Case Form1.ListView2.Items(i).SubItems(2).Text
                Case ""
                    Form1.ListView2.Items(i).SubItems(2).Text = 管理模组.安装状态显示词字典(a.安装状态)
            End Select

            管理模组.根据安装状态设置项的颜色标记(a.安装状态, Form1.ListView2.Items(i), True)

            Dim 模组项字体文件路径 As String = Path.Combine(项路径, "Font")
            If FileIO.FileSystem.FileExists(模组项字体文件路径) Then
                Select Case FileIO.FileSystem.ReadAllText(模组项字体文件路径)
                    Case "BD"
                        Form1.ListView2.Items(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Bold)
                    Case "LC"
                        Form1.ListView2.Items(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Italic)
                    Case "UL"
                        Form1.ListView2.Items(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Underline)
                    Case "SO"
                        Form1.ListView2.Items(i).Font = New Font(Form1.Font.Name, Form1.Font.Size, FontStyle.Strikeout)
                End Select
            End If
        Next
    End Sub

    Private Sub 暗黑文本框1_KeyDown(sender As Object, e As KeyEventArgs) Handles 暗黑文本框1.KeyDown
        If e.KeyData = Keys.Enter Then Me.UiButton35.PerformClick()
    End Sub
End Class