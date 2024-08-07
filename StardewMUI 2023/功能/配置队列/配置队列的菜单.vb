Public Class 配置队列的菜单

    Public Shared Property 内容右键菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_重命名 As New ToolStripMenuItem With {.Text = "重命名", .Image = My.Resources.代码文件夹, .ShortcutKeys = Keys.F2}
    Public Shared Property 菜单项_删除 As New ToolStripMenuItem With {.Text = "删除", .Image = My.Resources.删除, .ShortcutKeys = Keys.Delete}
    Public Shared Property 菜单项_上移内容 As New ToolStripMenuItem With {.Text = "上移（F3）", .Image = My.Resources.上箭头}
    Public Shared Property 菜单项_下移内容 As New ToolStripMenuItem With {.Text = "下移（F4）", .Image = My.Resources.下箭头}
    Public Shared Property 菜单项_提取压缩包 As New ToolStripMenuItem With {.Text = "提取压缩包", .Image = My.Resources.试验}
    Public Shared Property 菜单项_拿出内容 As New ToolStripMenuItem With {.Text = "拿出内容", .Image = My.Resources.试验}
    Public Shared Property 菜单项_内容套层 As New ToolStripMenuItem With {.Text = "内容套层", .Image = My.Resources.试验}

    Public Shared Sub 添加内容菜单的所有菜单项()
        内容右键菜单.Items.Add(菜单项_重命名)
        内容右键菜单.Items.Add(菜单项_删除)
        内容右键菜单.Items.Add(New ToolStripSeparator)
        内容右键菜单.Items.Add(菜单项_上移内容)
        内容右键菜单.Items.Add(菜单项_下移内容)
        内容右键菜单.Items.Add(New ToolStripSeparator)
        内容右键菜单.Items.Add(菜单项_提取压缩包)
        内容右键菜单.Items.Add(菜单项_拿出内容)
        内容右键菜单.Items.Add(菜单项_内容套层)

        AddHandler 菜单项_重命名.Click, AddressOf 配置队列.重命名内容
        AddHandler 菜单项_删除.Click, AddressOf 配置队列.删除内容
        AddHandler 菜单项_提取压缩包.Click, AddressOf 配置队列.提取压缩包
        AddHandler 菜单项_拿出内容.Click, AddressOf 配置队列.拿出内容
        AddHandler 菜单项_内容套层.Click, AddressOf 配置队列.内容套层
        AddHandler 菜单项_上移内容.Click, AddressOf 配置队列.上移内容
        AddHandler 菜单项_下移内容.Click, AddressOf 配置队列.下移内容
    End Sub

    Public Shared Property 规划右键菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_编辑规划 As New ToolStripMenuItem With {.Text = "编辑规划（双击）", .Image = My.Resources.试验}
    Public Shared Property 菜单项_删除规划 As New ToolStripMenuItem With {.Text = "删除规划", .Image = My.Resources.删除, .ShortcutKeys = Keys.Delete}
    Public Shared Property 菜单项_上移规划 As New ToolStripMenuItem With {.Text = "上移（F3）", .Image = My.Resources.上箭头}
    Public Shared Property 菜单项_下移规划 As New ToolStripMenuItem With {.Text = "下移（F4）", .Image = My.Resources.下箭头}

    Public Shared Sub 添加规划右键菜单的所有菜单项()
        规划右键菜单.Items.Add(菜单项_编辑规划)
        AddHandler 菜单项_编辑规划.Click, Sub(sender, e) 配置队列.编辑选中的规划()
        规划右键菜单.Items.Add(菜单项_删除规划)
        AddHandler 菜单项_删除规划.Click, Sub()
                                       If Form1.ListView3.SelectedItems.Count <> 1 Or 配置队列.正在编辑规划的项路径 = "" Then Exit Sub
                                       Dim i As Integer = 0
                                       Do Until i = Form1.ListView7.Items.Count
                                           If Form1.ListView7.Items(i).Selected Then
                                               Form1.ListView7.Items(i).Remove() : 配置队列.当前项的规划操作列表.RemoveAt(i)
                                               Continue Do
                                           End If
                                           i += 1
                                       Loop
                                   End Sub
        规划右键菜单.Items.Add(New ToolStripSeparator)
        规划右键菜单.Items.Add(菜单项_上移规划)
        AddHandler 菜单项_上移规划.Click, AddressOf 配置队列.上移规划
        规划右键菜单.Items.Add(菜单项_下移规划)
        AddHandler 菜单项_下移规划.Click, AddressOf 配置队列.下移规划
    End Sub

    Public Shared Property 添加规划菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(23 * 界面控制.DPI, 23 * 界面控制.DPI), .DropShadowEnabled = False}
    Public Shared Property 菜单项_复制文件夹到Mods As New ToolStripMenuItem With {.Text = "复制文件夹到 Mods", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_覆盖Mods中的文件夹 As New ToolStripMenuItem With {.Text = "覆盖 Mods 中的文件夹", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_复制文件夹到根位置 As New ToolStripMenuItem With {.Text = "复制文件夹", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_覆盖Content文件夹 As New ToolStripMenuItem With {.Text = "覆盖 Content 文件夹", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_安装单个文件 As New ToolStripMenuItem With {.Text = "安装单个文件", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_检查存在性 As New ToolStripMenuItem With {.Text = "检查存在性", .Image = My.Resources.试验}
    Public Shared Property 菜单项_安装时检查模组的版本 As New ToolStripMenuItem With {.Text = "安装时检查模组版本", .Image = My.Resources.试验}
    Public Shared Property 菜单项_卸载时取消操作 As New ToolStripMenuItem With {.Text = "卸载时取消操作", .Image = My.Resources.试验}
    Public Shared Property 菜单项_运行可执行文件 As New ToolStripMenuItem With {.Text = "运行可执行文件", .Image = My.Resources.试验}
    Public Shared Property 菜单项_弹窗 As New ToolStripMenuItem With {.Text = "弹窗", .Image = My.Resources.试验}
    Public Shared Property 菜单项_声明核心功能的启停 As New ToolStripMenuItem With {.Text = "声明核心功能的启停", .Image = My.Resources.六个点}
    Public Shared Property 菜单项_与第三方规划的分隔符 As New ToolStripSeparator With {.Visible = False}

    Public Shared Sub 添加添加规划菜单的所有菜单项()
        添加规划菜单.Items.Add(菜单项_复制文件夹到Mods)
        AddHandler 菜单项_复制文件夹到Mods.Click, Sub() 添加新规划通用调用("CD-D-MODS", "<模组文件夹>")
        添加规划菜单.Items.Add(菜单项_覆盖Mods中的文件夹)
        AddHandler 菜单项_覆盖Mods中的文件夹.Click, Sub() 添加新规划通用调用("CD-D-MODS-COVER", "<在 Mods 中的同名文件夹>")
        添加规划菜单.Items.Add(菜单项_复制文件夹到根位置)
        AddHandler 菜单项_复制文件夹到根位置.Click, Sub() 添加新规划通用调用("CD-D-ROOT", "<文件夹>|<目标位置>")
        添加规划菜单.Items.Add(菜单项_覆盖Content文件夹)
        AddHandler 菜单项_覆盖Content文件夹.Click, Sub() 添加新规划通用调用("CD-D-CONTENT", "0")
        添加规划菜单.Items.Add(菜单项_安装单个文件)
        AddHandler 菜单项_安装单个文件.Click, Sub() 添加新规划通用调用("CD-F", "<是否需要还原>|<是否需要判断>|<是否需要验证>|<文件>|<目标位置>")
        添加规划菜单.Items.Add(New ToolStripSeparator)
        添加规划菜单.Items.Add(菜单项_检查存在性)
        AddHandler 菜单项_检查存在性.Click, Sub() 添加新规划通用调用("CR-Check-EXIST", "<在安装还是卸载中>|<文件夹还是文件>|<要存在还是不存在>|<无限参数：文件夹或文件>")
        添加规划菜单.Items.Add(菜单项_安装时检查模组的版本)
        AddHandler 菜单项_安装时检查模组的版本.Click, Sub() 添加新规划通用调用("CR-IN-MODS-VER", "<判断符>|<版本号>|<模组文件夹>")
        添加规划菜单.Items.Add(菜单项_卸载时取消操作)
        AddHandler 菜单项_卸载时取消操作.Click, Sub() 添加新规划通用调用("CR-UN", "<要取消还是报错>")
        添加规划菜单.Items.Add(菜单项_运行可执行文件)
        AddHandler 菜单项_运行可执行文件.Click, Sub() 添加新规划通用调用("CR-SHELL", "<在安装还是卸载中>|<可执行文件>|<传递参数>|<是否等待>")
        添加规划菜单.Items.Add(菜单项_弹窗)
        AddHandler 菜单项_弹窗.Click, Sub() 添加新规划通用调用("CR-MSGBOX", "<在安装还是卸载中>|<标题>|<描述>|<是否要正确>|<正确序号>|<无限参数：选择项>")
        添加规划菜单.Items.Add(菜单项_声明核心功能的启停)
        AddHandler 菜单项_声明核心功能的启停.Click, Sub() 添加新规划通用调用("CORE-CLASS", "<在编辑配置中勾选>")

        添加规划菜单.Items.Add(菜单项_与第三方规划的分隔符)
    End Sub

    Public Shared Sub 添加新规划通用调用(操作类型 As String, 默认参数 As String)
        If Form1.ListView3.SelectedItems.Count <> 1 Or 配置队列.正在编辑规划的项路径 = "" Then Exit Sub
        Form1.ListView7.Items.Add(配置队列.规划显示名称字典(操作类型))
        Form1.ListView7.Items(Form1.ListView7.Items.Count - 1).SubItems.Add(默认参数)
        配置队列.当前项的规划操作列表.Add(操作类型)
    End Sub

    Public Shared Sub 添加菜单的触发()
        添加内容菜单的所有菜单项()
        添加规划右键菜单的所有菜单项()
        添加添加规划菜单的所有菜单项()
        Form1.ListView6.ContextMenuStrip = 内容右键菜单
        Form1.ListView7.ContextMenuStrip = 规划右键菜单
        AddHandler Form1.UiButton20.MouseDown, Sub(sender, e) 添加规划菜单.Show(sender, New Point(sender.Width - 添加规划菜单.Width, sender.Height))
    End Sub

End Class
