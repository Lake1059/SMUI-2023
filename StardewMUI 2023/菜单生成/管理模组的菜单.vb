Public Class 管理模组的菜单

    Public Shared Property 分类和子库菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_刷新分类 As New ToolStripMenuItem With {.Text = "刷新", .Image = My.Resources.刷新}
    Public Shared Property 菜单项_子库菜单 As New ToolStripMenuItem With {.Text = "数据子库操作", .Image = My.Resources.试验}

    Public Shared Property 数据子库操作菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_切换数据子库 As New ToolStripMenuItem With {.Text = "切换数据子库", .Image = My.Resources.移动}
    Public Shared Property 菜单项_刷新数据子库 As New ToolStripMenuItem With {.Text = "刷新数据子库", .Image = My.Resources.刷新}
    Public Shared Property 菜单项_新建数据子库 As New ToolStripMenuItem With {.Text = "新建数据子库", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_导入数据子库 As New ToolStripMenuItem With {.Text = "导入数据子库"}
    Public Shared Property 菜单项_导出数据子库 As New ToolStripMenuItem With {.Text = "导出数据子库"}
    Public Shared Property 菜单项_删除数据子库 As New ToolStripMenuItem With {.Text = "删除数据子库", .Image = My.Resources.叉号}

    Public Shared Property 菜单项_新建分类 As New ToolStripMenuItem With {.Text = "新建分类", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_转移分类 As New ToolStripMenuItem With {.Text = "转移分类", .Image = My.Resources.右箭头}
    Public Shared Property 菜单项_删除分类 As New ToolStripMenuItem With {.Text = "删除分类", .Image = My.Resources.叉号}
    Public Shared Property 菜单项_导入分类 As New ToolStripMenuItem With {.Text = "导入分类"}
    Public Shared Property 菜单项_导出分类 As New ToolStripMenuItem With {.Text = "导出分类"}
    Public Shared Property 菜单项_更多分类操作 As New ToolStripMenuItem With {.Text = "更多", .Image = My.Resources.试验}

    Public Shared Property 更多分类操作菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_更多分类操作_清除Config缓存 As New ToolStripMenuItem With {.Text = "清除 Config 缓存", .Image = My.Resources.叉号}
    Public Shared Property 菜单项_更多分类操作_转换安装命令到安装规划 As New ToolStripMenuItem With {.Text = "转换安装命令到安装规划", .Image = My.Resources.试验}
    Public Shared Property 菜单项_更多分类操作_转换安装规划到安装命令 As New ToolStripMenuItem With {.Text = "转换安装规划到安装命令", .Image = My.Resources.试验}


    Public Shared Sub 添加分类和子库菜单的所有菜单项()
        分类和子库菜单.Items.Add(菜单项_刷新分类)
        分类和子库菜单.Items.Add(New ToolStripSeparator)
        分类和子库菜单.Items.Add(菜单项_子库菜单)

        菜单项_子库菜单.DropDown = 数据子库操作菜单
        数据子库操作菜单.Items.Add(菜单项_切换数据子库)
        数据子库操作菜单.Items.Add(New ToolStripSeparator)
        数据子库操作菜单.Items.Add(菜单项_刷新数据子库)
        数据子库操作菜单.Items.Add(菜单项_新建数据子库)
        数据子库操作菜单.Items.Add(New ToolStripSeparator)
        数据子库操作菜单.Items.Add(菜单项_导入数据子库)
        数据子库操作菜单.Items.Add(菜单项_导出数据子库)
        数据子库操作菜单.Items.Add(New ToolStripSeparator)
        数据子库操作菜单.Items.Add(菜单项_删除数据子库)

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

    Public Shared Property 项菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_新建项 As New ToolStripMenuItem With {.Text = "新建项", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_下载并新建项 As New ToolStripMenuItem With {.Text = "下载并新建项", .Image = My.Resources.下载}
    Public Shared Property 菜单项_移动项 As New ToolStripMenuItem With {.Text = "移动项", .Image = My.Resources.移动}
    Public Shared Property 菜单项_删除项 As New ToolStripMenuItem With {.Text = "删除项", .Image = My.Resources.叉号}
    Public Shared Property 菜单项_导入项 As New ToolStripMenuItem With {.Text = "导入项"}
    Public Shared Property 菜单项_导出项 As New ToolStripMenuItem With {.Text = "导出项"}
    Public Shared Property 菜单项_批量创建项 As New ToolStripMenuItem With {.Text = "批量创建", .Image = My.Resources.代码文件夹}
    Public Shared Property 菜单项_本地更新项 As New ToolStripMenuItem With {.Text = "本地更新"}
    Public Shared Property 菜单项_设置项字体 As New ToolStripMenuItem With {.Text = "设置字体"}
    Public Shared Property 菜单项_切换项所属分类显示 As New ToolStripMenuItem With {.Text = "切换分类列"}


    Public Shared Sub 添加项菜单的所有菜单项()
        项菜单.Items.Add(菜单项_新建项)
        项菜单.Items.Add(菜单项_下载并新建项)
        项菜单.Items.Add(New ToolStripSeparator)
        项菜单.Items.Add(菜单项_移动项)
        项菜单.Items.Add(菜单项_删除项)
        项菜单.Items.Add(New ToolStripSeparator)
        项菜单.Items.Add(菜单项_导入项)
        项菜单.Items.Add(菜单项_导出项)
        项菜单.Items.Add(New ToolStripSeparator)
        项菜单.Items.Add(菜单项_批量创建项)
        项菜单.Items.Add(菜单项_本地更新项)
        项菜单.Items.Add(New ToolStripSeparator)
        项菜单.Items.Add(菜单项_设置项字体)
        项菜单.Items.Add(菜单项_切换项所属分类显示)
    End Sub


    Public Shared Sub 添加菜单的触发()
        添加分类和子库菜单的所有菜单项()
        添加项菜单的所有菜单项()
        AddHandler Form1.UiButton1.MouseDown, Sub(sender, e) 分类和子库菜单.Show(sender, New Point(sender.Width - 分类和子库菜单.Width, sender.Height))
        AddHandler Form1.UiButton2.MouseDown, Sub(sender, e) 项菜单.Show(sender, New Point(0, sender.Height))
    End Sub



End Class
