Imports System.ComponentModel
Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SevenZip.SevenZipBase.SetLibraryPath(Application.StartupPath & "\7zFull64.dll")
        界面控制.DPI = Me.CreateGraphics().DpiX / 96
        状态信息.判断应用程序启动模式()
        状态信息.初始化性能计数定时器()
        状态信息.初始化SMAPI运行态定时器()
        设置.启动时加载设置()
        界面控制.初始化界面()
        管理模组.初始化()
        任务队列.全部字典初始化()
        配置队列.初始化()
        DLC.初始化()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If 界面控制.DPI <> 1 Then 界面控制.主界面高DPI兼容()
        界面控制.主界面元素尺寸动态调整()
        If 设置.全局设置数据("AutoCheckUpdate") = "True" Then 检查更新.运行后台服务器检查更新()
        If 设置.全局设置数据("AutoGetNews") = "True" Then 新闻列表.获取新闻()
        状态信息.刷新起始页面状态信息()
        Dim a As New 多项单选对话框("早期测试", {"OK"}, "当前版本还无法满足日常需求，请继续用五代产品。", 100, 500)
        a.ShowDialog(Me)
    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        界面控制.主界面元素尺寸动态调整()
    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        键值对IO操作.从字典键值对写入文件(设置.全局设置数据, 设置.设置文件存储路径)
        管理模组.模块单元在关机时保存数据()

        If 检查更新.在退出后安装更新 Then
            If FileIO.FileSystem.FileExists(设置.安装程序更新下载文件路径) Then
                ShellExecute(Nothing, "", 设置.安装程序更新下载文件路径, "/qb", Path.GetDirectoryName(设置.安装程序更新下载文件路径), Nothing)
            Else
                MsgBox("找不到下载的安装程序文件！", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed

    End Sub

    Private Sub Form1_DpiChanged(sender As Object, e As DpiChangedEventArgs) Handles MyBase.DpiChanged
        界面控制.DPI = e.DeviceDpiNew / 96
        界面控制.主界面高DPI兼容()
    End Sub

    Private Sub UiTabControlMenu2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UiTabControlMenu2.SelectedIndexChanged

    End Sub
End Class
