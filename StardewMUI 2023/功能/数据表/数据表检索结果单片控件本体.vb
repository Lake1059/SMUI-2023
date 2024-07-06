Imports System.ComponentModel
Imports Sunny.UI
Imports Windows.System

Public Class 数据表检索结果单片控件本体

    ''' <summary>
    ''' 主要文本
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True)>
    Public Property Text_Main As String
        Get
            Return Me.Label1.Text
        End Get
        Set(value As String)
            Me.Label1.Text = value
        End Set
    End Property

    ''' <summary>
    ''' 描述词
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True)>
    Public Property Text_Des As String
        Get
            Return Me.Label3.Text
        End Get
        Set(value As String)
            Me.Label3.Text = value
        End Set
    End Property

    <Browsable(True)>
    Public Property Category As String
        Get
            Return Me.Label10.Text
        End Get
        Set(value As String)
            Me.Label10.Text = value
        End Set
    End Property

    ''' <summary>
    ''' SMUI 全自动处理支持级别
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True)>
    Public Property AutoProcess As String
        Get
            Select Case Label13.Text
                Case "全自动"
                    Return 1
                Case "仅更新"
                    Return 2
                Case Else
                    Return 3
            End Select
        End Get
        Set(value As String)
            Select Case value
                Case "全自动"
                    Label13.Text = "全自动"
                    Label13.BackColor = Color.DarkGreen
                Case "仅更新"
                    Label13.Text = "仅更新"
                    Label13.BackColor = Color.RoyalBlue
                Case "需手动"
                    Label13.Text = "需手动"
                    Label13.BackColor = Color.DarkRed
            End Select
        End Set
    End Property

    ''' <summary>
    ''' 存档安全性
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True)>
    Public Property SaveSafe As String
        Get
            Select Case Label8.Text
                Case "安全"
                    Return 1
                Case "影响"
                    Return 2
                Case Else
                    Return 3
            End Select
        End Get
        Set(value As String)
            Select Case value
                Case "安全"
                    Label8.Text = "安全"
                    Label8.BackColor = Color.DarkGreen
                Case "影响"
                    Label8.Text = "影响"
                    Label8.BackColor = Color.SaddleBrown
                Case "危险"
                    Label8.Text = "危险"
                    Label8.BackColor = Color.DarkRed
            End Select
        End Set
    End Property

    ''' <summary>
    ''' 热门程度
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True)>
    Public Property Hot As String
        Get
            Select Case Label6.Text
                Case "安全"
                    Return 1
                Case "影响"
                    Return 2
                Case Else
                    Return 3
            End Select
        End Get
        Set(value As String)
            Select Case value
                Case "热门"
                    Label6.Text = "热门"
                    Label6.BackColor = Color.DarkRed
                Case "普通"
                    Label6.Text = "普通"
                    Label6.BackColor = Color.RoyalBlue
                Case "小众"
                    Label6.Text = "小众"
                    Label6.BackColor = Color.DarkGreen
            End Select
        End Set
    End Property

    Public Property NEXUS As String
    Public Property ModDrop As String
    Public Property GitHub As String
    Public Property UnofficialUpdate As String

    Public Shared Property 非会员免费访问下载次数剩余 As Integer = 3

    Private Sub 数据表检索结果单片控件本体_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If 非会员免费访问下载次数剩余 = 0 Then
            UIMessageTip.Show("DLC 3 未激活，每次启动仅可使用 3 次" & vbCrLf & $"本次启动免费次数已用完，请重启软件重试",, 2500)
            Exit Sub
        End If
        Dim a As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
        If NEXUS <> "" Then
            Dim a1 As New ToolStripMenuItem With {.Text = "从 NEXUS 下载", .Image = My.Resources.NEXUS}
            AddHandler a1.Click, Sub()
                                     Form下载并新建项.拖入的链接 = "https://www.nexusmods.com/stardewvalley/mods/" & NEXUS
                                     管理模组的菜单.菜单项_下载并新建项.PerformClick()
                                     If Not DLC.DLC解锁标记.NewItemExtension Then
                                         非会员免费访问下载次数剩余 -= 1
                                         UIMessageTip.Show("DLC 3 未激活，每次启动仅可使用 3 次" & vbCrLf & $"本次启动还剩余 {非会员免费访问下载次数剩余} 次",, 2000)
                                     End If
                                 End Sub
            a.Items.Add(a1)
        End If
        If ModDrop <> "" Then
            Dim a1 As New ToolStripMenuItem With {.Text = "从 ModDrop 下载", .Image = My.Resources.ModDrop_White32}
            AddHandler a1.Click, Sub()
                                     Form下载并新建项.拖入的链接 = "https://www.moddrop.com/stardew-valley/mods/" & ModDrop
                                     管理模组的菜单.菜单项_下载并新建项.PerformClick()
                                     If Not DLC.DLC解锁标记.NewItemExtension Then
                                         非会员免费访问下载次数剩余 -= 1
                                         UIMessageTip.Show("DLC 3 未激活，每次启动仅可使用 3 次" & vbCrLf & $"本次启动还剩余 {非会员免费访问下载次数剩余} 次",, 2000)
                                     End If
                                 End Sub
            a.Items.Add(a1)
        End If
        If GitHub <> "" Then
            Dim a1 As New ToolStripMenuItem With {.Text = "从 GitHub 下载", .Image = My.Resources.Github}
            AddHandler a1.Click, Sub()
                                     Form下载并新建项.拖入的链接 = "https://github.com/" & GitHub
                                     管理模组的菜单.菜单项_下载并新建项.PerformClick()
                                     If Not DLC.DLC解锁标记.NewItemExtension Then
                                         非会员免费访问下载次数剩余 -= 1
                                         UIMessageTip.Show("DLC 3 未激活，每次启动仅可使用 3 次" & vbCrLf & $"本次启动还剩余 {非会员免费访问下载次数剩余} 次",, 2000)
                                     End If
                                 End Sub
            a.Items.Add(a1)
        End If
        a.Show(MousePosition)
    End Sub

    Private Async Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Await Launcher.LaunchUriAsync(New Uri(UnofficialUpdate))
    End Sub

End Class
