Public Class 管理模组的菜单

    Public Shared Property 分类和子库菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_刷新分类 As New ToolStripMenuItem With {.Text = "刷新", .Image = My.Resources.刷新}
    Public Shared Property 菜单项_子库菜单 As New ToolStripMenuItem With {.Text = "数据子库操作", .Image = My.Resources.试验}
    Public Shared Property 菜单项_新建分类 As New ToolStripMenuItem With {.Text = "新建分类", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_转移分类 As New ToolStripMenuItem With {.Text = "转移分类", .Image = My.Resources.右箭头}
    Public Shared Property 菜单项_删除分类 As New ToolStripMenuItem With {.Text = "删除分类", .Image = My.Resources.叉号}
    Public Shared Property 菜单项_导入分类 As New ToolStripMenuItem With {.Text = "导入分类"}
    Public Shared Property 菜单项_导出分类 As New ToolStripMenuItem With {.Text = "导出分类"}
    Public Shared Property 菜单项_更多分类操作 As New ToolStripMenuItem With {.Text = "更多"}
    Public Shared Property 更多分类操作菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_更多分类操作_清除Config缓存 As New ToolStripMenuItem With {.Text = "清除 Config 缓存", .Image = My.Resources.叉号}
    Public Shared Property 菜单项_更多分类操作_转换安装命令到安装规划 As New ToolStripMenuItem With {.Text = "转换安装命令到安装规划", .Image = My.Resources.试验}
    Public Shared Property 菜单项_更多分类操作_转换安装规划到安装命令 As New ToolStripMenuItem With {.Text = "转换安装规划到安装命令", .Image = My.Resources.试验}


    Public Shared Sub 添加分类和子库菜单的所有菜单项()
        分类和子库菜单.Items.Add(菜单项_刷新分类)
        分类和子库菜单.Items.Add(New ToolStripSeparator)
        分类和子库菜单.Items.Add(菜单项_子库菜单)
        分类和子库菜单.Items.Add(New ToolStripSeparator)
        分类和子库菜单.Items.Add(菜单项_新建分类)
        分类和子库菜单.Items.Add(菜单项_转移分类)
        分类和子库菜单.Items.Add(菜单项_删除分类)
        分类和子库菜单.Items.Add(New ToolStripSeparator)
        分类和子库菜单.Items.Add(菜单项_导入分类)
        分类和子库菜单.Items.Add(菜单项_导出分类)
        分类和子库菜单.Items.Add(New ToolStripSeparator)
        分类和子库菜单.Items.Add(菜单项_更多分类操作)
        菜单项_更多分类操作.DropDown = 更多分类操作菜单

        更多分类操作菜单.Items.Add(菜单项_更多分类操作_清除Config缓存)
        更多分类操作菜单.Items.Add(菜单项_更多分类操作_转换安装命令到安装规划)
        更多分类操作菜单.Items.Add(菜单项_更多分类操作_转换安装规划到安装命令)

    End Sub

    Public Shared Sub 初始化所有菜单()
        添加分类和子库菜单的所有菜单项()
    End Sub

    Public Shared Sub 添加菜单的触发()
        初始化所有菜单()
        AddHandler Form1.UiButton1.MouseDown, Sub(sender, e) 分类和子库菜单.Show(sender, New Point(sender.Width - 分类和子库菜单.Width, sender.Height))
    End Sub



End Class
