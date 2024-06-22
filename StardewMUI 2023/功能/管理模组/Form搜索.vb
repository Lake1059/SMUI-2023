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
        管理模组.刷新项列表数据()
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

    Private Sub 暗黑文本框1_KeyDown(sender As Object, e As KeyEventArgs) Handles 暗黑文本框1.KeyDown
        If e.KeyData = Keys.Enter Then Me.UiButton35.PerformClick()
    End Sub
End Class