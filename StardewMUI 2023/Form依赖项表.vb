
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Xml.Xsl
Imports Windows.Win32.UI.Input

Public Class Form依赖项表
    Private Sub Form依赖项表_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        界面控制.初始化依赖项窗口()
    End Sub

    Private Sub Form依赖项表_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        刷新前置表项()
    End Sub

    Public Sub 刷新前置表项()
        Me.ListView1.Items.Clear()
        Dim 内容包键列表 As New List(Of String)(管理模组.当前项信息_内容包列表.Keys.ToList)

        For i = 0 To 内容包键列表.Count - 1
            Me.ListView1.Items.Add(内容包键列表(i))
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(管理模组.当前项信息_内容包列表(内容包键列表(i)).最低版本号)
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("内容包")
        Next

        Dim 依赖项键列表 As New List(Of String)(管理模组.当前项信息_依赖项列表.Keys.ToList)

        For i = 0 To 依赖项键列表.Count - 1
            If 管理模组.当前项信息_内容包列表.ContainsKey(依赖项键列表(i)) Then Continue For
            Me.ListView1.Items.Add(依赖项键列表(i))
            Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add(管理模组.当前项信息_依赖项列表(依赖项键列表(i)).依赖项最低版本号)
            If 管理模组.当前项信息_依赖项列表(依赖项键列表(i)).依赖项必须性 = True Then
                Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("必须")
            Else
                Me.ListView1.Items.Item(Me.ListView1.Items.Count - 1).SubItems.Add("可选")
            End If
        Next

        For i = 0 To Me.ListView1.Items.Count - 1
            Me.ListView1.Items.Item(i).SubItems.Add("")
        Next

        Me.Label51.Text = Me.ListView1.Items.Count
    End Sub

    Private Sub UiButton刷新_Click(sender As Object, e As EventArgs) Handles UiButton刷新.Click
        If Form1.ListView2.SelectedItems.Count <> 1 Then Exit Sub
        刷新前置表项()
    End Sub

    Private Sub UiButton检查_Click(sender As Object, e As EventArgs) Handles UiButton检查.Click
        If Me.ListView1.Items.Count = 0 Then Exit Sub
        For i = 0 To Me.ListView1.Items.Count - 1
            Me.ListView1.Items.Item(i).SubItems(3).Text = ""
        Next
        Dim x1 As New 搜索文件类
        x1.搜索清单文件(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "Mods"))
        If x1.错误信息 <> "" Then
            DebugPrint(x1.错误信息, Color1.红色, True)
            Exit Sub
        End If
        Me.Text = "正在扫描"
        Application.DoEvents()
        For i = 0 To x1.文件绝对路径集合.Count - 1
            Dim JsonData As Object = CType(JsonConvert.DeserializeObject(FileIO.FileSystem.ReadAllText(x1.文件绝对路径集合(i))), JObject)
            If JsonData.item("UniqueID") IsNot Nothing Then
                For i2 = 0 To Me.ListView1.Items.Count - 1
                    If Me.ListView1.Items.Item(i2).Text.ToUpper.Trim = JsonData.item("UniqueID").ToString.ToUpper.Trim Then
                        Me.ListView1.Items.Item(i2).SubItems(3).Text = "已安装"
                        Me.ListView1.Items.Item(i2).ForeColor = Color1.绿色
                        Exit For
                    End If
                Next
            End If
        Next
        For i = 0 To Me.ListView1.Items.Count - 1
            If Me.ListView1.Items.Item(i).SubItems(3).Text = "" Then
                If Me.ListView1.Items.Item(i).SubItems(2).Text = "可选" Then
                    Me.ListView1.Items.Item(i).SubItems(3).Text = "未安装"
                    Me.ListView1.Items.Item(i).ForeColor = Color1.白色
                Else
                    Me.ListView1.Items.Item(i).SubItems(3).Text = "未安装"
                    Me.ListView1.Items.Item(i).ForeColor = Color1.红色
                End If
            End If
        Next
        Me.Text = "依赖项表"
    End Sub
End Class