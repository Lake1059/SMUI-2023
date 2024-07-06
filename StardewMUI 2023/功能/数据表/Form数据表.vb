Imports System.IO
Imports CsvHelper
Imports System.Globalization
Imports Sunny.UI
Imports Windows.ApplicationModel.Appointments.AppointmentsProvider
Imports Windows.System
Imports SharpCompress.Common
Imports System.Security.Policy

Public Class Form数据表

    Public Class CsvRecord
        Public Property NEXUS As String
        Public Property ModName As String
        Public Property Author As String
        Public Property UniqueID As String
        Public Property Auto As String
        Public Property Hot As String
        Public Property Category As String
        Public Property SaveSafe As String
        Public Property Descriptor As String
        Public Property ModDrop As String
        Public Property GitHub As String
        Public Property UnofficialUpdateLink As String
    End Class

    Private Sub Form数据表_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler 暗黑文本框1.TextBox1.TextChanged, Sub()
                                                    If 暗黑文本框1.TextBox1.Text = "" Then
                                                        Me.UiCheckBox1.Checked = False
                                                    Else
                                                        Me.UiCheckBox1.Checked = True
                                                    End If
                                                End Sub
        AddHandler 暗黑文本框2.TextBox1.TextChanged, Sub()
                                                    If 暗黑文本框2.TextBox1.Text = "" Then
                                                        Me.UiCheckBox2.Checked = False
                                                    Else
                                                        Me.UiCheckBox2.Checked = True
                                                    End If
                                                End Sub
        AddHandler 暗黑文本框3.TextBox1.TextChanged, Sub()
                                                    If 暗黑文本框3.TextBox1.Text = "" Then
                                                        Me.UiCheckBox3.Checked = False
                                                    Else
                                                        Me.UiCheckBox3.Checked = True
                                                    End If
                                                End Sub
        AddHandler 暗黑文本框4.TextBox1.TextChanged, Sub()
                                                    If 暗黑文本框4.TextBox1.Text = "" Then
                                                        Me.UiCheckBox4.Checked = False
                                                    Else
                                                        Me.UiCheckBox4.Checked = True
                                                    End If
                                                End Sub
        AddHandler 暗黑文本框5.TextBox1.TextChanged, Sub()
                                                    If 暗黑文本框5.TextBox1.Text = "" Then
                                                        Me.UiCheckBox5.Checked = False
                                                    Else
                                                        Me.UiCheckBox5.Checked = True
                                                    End If
                                                End Sub

    End Sub

    Private Sub UiButton34_Click(sender As Object, e As EventArgs) Handles UiButton34.Click
        Dim csvFile As String = ""
        If FileIO.FileSystem.FileExists(设置.下载的数据表文件) Then
            csvFile = 设置.下载的数据表文件
        ElseIf FileIO.FileSystem.FileExists("ModsCoordinationDataBase.csv") Then
            csvFile = "ModsCoordinationDataBase.csv"
        Else
            UIMessageTip.Show($"找不到可用的数据表文件",, 2000)
            Exit Sub
        End If
        If UiCheckBox4.Checked Then
            Select Case 暗黑文本框4.Text.Trim
                Case ",", "，"
                    UIMessageTip.Show($"不允许只搜一个逗号",, 2000)
                    Exit Sub
            End Select
        End If

        Dim records As List(Of CsvRecord)
        Using reader As New StreamReader(csvFile)
            Using csv As New CsvReader(reader, CultureInfo.InvariantCulture)
                records = csv.GetRecords(Of CsvRecord)().ToList
            End Using
        End Using
        If UiCheckBox6.Checked Then
            records = records.Where(Function(r) r.GetType().GetProperty("Category").GetValue(r, Nothing).ToString = UiComboBox1.Text).ToList
        End If
        If UiCheckBox5.Checked And UiComboBox4.Text.Equals("nexus", StringComparison.CurrentCultureIgnoreCase) Then
            records = records.Where(Function(r) r.GetType().GetProperty("NEXUS").GetValue(r, Nothing).ToString = 暗黑文本框5.Text).ToList
        End If
        If UiCheckBox5.Checked And UiComboBox4.Text.Equals("moddrop", StringComparison.CurrentCultureIgnoreCase) Then
            records = records.Where(Function(r) r.GetType().GetProperty("ModDrop").GetValue(r, Nothing).ToString = 暗黑文本框5.Text).ToList
        End If
        If UiCheckBox5.Checked And UiComboBox4.Text.Equals("github", StringComparison.CurrentCultureIgnoreCase) Then
            records = records.Where(Function(r) r.GetType().GetProperty("GitHub").GetValue(r, Nothing).ToString = 暗黑文本框5.Text).ToList
        End If
        If UiCheckBox1.Checked Then
            records = records.Where(Function(r) r.GetType().GetProperty("ModName").GetValue(r, Nothing).ToString.Contains(暗黑文本框1.Text)).ToList
        End If
        If UiCheckBox2.Checked Then
            records = records.Where(Function(r) r.GetType().GetProperty("Author").GetValue(r, Nothing).ToString.Contains(暗黑文本框2.Text)).ToList
        End If
        If UiCheckBox3.Checked Then
            records = records.Where(Function(r) r.GetType().GetProperty("UniqueID").GetValue(r, Nothing).ToString.Contains(暗黑文本框3.Text)).ToList
        End If
        If UiCheckBox4.Checked Then
            records = records.Where(Function(r) r.GetType().GetProperty("Descriptor").GetValue(r, Nothing).ToString.Contains(暗黑文本框4.Text)).ToList
        End If

        If records.Count > 10 Then
            UIMessageTip.Show($"搜索结果有 {records.Count} 个，为节约性能只显示前 10 个",, 2000)
        End If

        Me.Panel9.Visible = False
        Me.Panel9.Controls.Clear()
        For i = 0 To records.Count - 1
            If i = 10 Then Exit For
            Dim a As New 数据表检索结果单片控件本体 With {
                .Dock = DockStyle.Top,
                .Text_Main = records(i).ModName & " - " & records(i).Author,
                .Text_Des = records(i).Descriptor,
                .AutoProcess = records(i).Auto,
                .Category = records(i).Category,
                .SaveSafe = records(i).SaveSafe,
                .Hot = records(i).Hot,
                .NEXUS = records(i).NEXUS,
                .ModDrop = records(i).ModDrop,
                .GitHub = records(i).GitHub,
                .UnofficialUpdate = records(i).UnofficialUpdateLink
            }
            Me.Panel9.Controls.Add(a)
            a.BringToFront()
        Next
        Me.Panel9.Visible = True
    End Sub

    Private Sub UiButton1_Click(sender As Object, e As EventArgs) Handles UiButton1.Click
        If 设置.全局设置数据("GiteeToken") = "" Then
            Dim m1 As New 多项单选对话框("立即联网更新数据表", {"OK"}, "由于 Gitee 限制不允许匿名访问 raw 文件流，请先设置 Gitee Personal Access Token", 100, 500)
            m1.ShowDialog(Me)
            Exit Sub
        End If
        UiButton1.Enabled = False
        Dim x As New GitAPI.TextFileString
        x.获取文本文件数据(GitAPI.GitApiObject.开源代码平台.Gitee, "Lake1059/SMUI-2023", "master", "ModsCoordinationDataBase.csv", 设置.全局设置数据("GiteeToken"), False)
        If x.ErrorString = "" Then
            FileIO.FileSystem.WriteAllText(设置.下载的数据表文件, x.网页返回字符串, False)
            UIMessageTip.Show($"成功更新了数据表",, 2000)
        Else
            UIMessageTip.Show($"获取更新数据失败：{x.网页返回字符串}",, 2000)
            DebugPrint(x.网页返回字符串, Color1.红色)
        End If
        UiButton1.Enabled = True
    End Sub

    Private Sub UiButton2_Click(sender As Object, e As EventArgs) Handles UiButton2.Click
        Me.UiCheckBox1.Checked = False
        Me.UiCheckBox2.Checked = False
        Me.UiCheckBox3.Checked = False
        Me.UiCheckBox4.Checked = False
        Me.UiCheckBox5.Checked = False
        Me.UiCheckBox6.Checked = False
        Me.暗黑文本框1.Text = ""
        Me.暗黑文本框2.Text = ""
        Me.暗黑文本框3.Text = ""
        Me.暗黑文本框4.Text = ""
        Me.暗黑文本框5.Text = ""
        Me.UiComboBox4.SelectedIndex = -1
        Me.UiComboBox1.SelectedIndex = -1
    End Sub

    Private Async Sub UiButton3_Click(sender As Object, e As EventArgs) Handles UiButton3.Click
        Dim csvFile As String
        If FileIO.FileSystem.FileExists(设置.下载的数据表文件) Then
            csvFile = 设置.下载的数据表文件
        ElseIf FileIO.FileSystem.FileExists("ModsCoordinationDataBase.csv") Then
            csvFile = Path.Combine(Application.StartupPath, "ModsCoordinationDataBase.csv")
        Else
            UIMessageTip.Show($"找不到可用的数据表文件",, 2000)
            Exit Sub
        End If
        Await Launcher.LaunchFileAsync(Await Windows.Storage.StorageFile.GetFileFromPathAsync(csvFile))
    End Sub

    Private Sub UiComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UiComboBox1.SelectedIndexChanged
        If UiComboBox1.SelectedIndex <> -1 Then
            UiCheckBox6.Checked = True
        End If
    End Sub

    Private Async Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Await Launcher.LaunchUriAsync(New Uri("https://afdian.net/order/create?plan_id=049e088e3b5411ef935e5254001e7c00"))
    End Sub
End Class