﻿Imports Microsoft.VisualBasic.Devices

Public Class 管理模组的菜单

    Public Shared Property 分类和子库菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_刷新分类 As New ToolStripMenuItem With {.Text = "刷新", .Image = My.Resources.刷新}
    Public Shared Property 菜单项_子库菜单 As New ToolStripMenuItem With {.Text = "数据子库操作", .Image = My.Resources.数据库}

    Public Shared Property 数据子库操作菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_切换数据子库 As New ToolStripMenuItem With {.Text = "切换数据子库", .Image = My.Resources.数据切换}
    Public Shared Property 菜单项_刷新数据子库 As New ToolStripMenuItem With {.Text = "刷新数据子库", .Image = My.Resources.刷新}
    Public Shared Property 菜单项_新建数据子库 As New ToolStripMenuItem With {.Text = "新建数据子库", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_导入数据子库 As New ToolStripMenuItem With {.Text = "导入数据子库", .Image = My.Resources.下载}
    Public Shared Property 菜单项_导出数据子库 As New ToolStripMenuItem With {.Text = "导出数据子库", .Image = My.Resources.上传}
    Public Shared Property 菜单项_删除数据子库 As New ToolStripMenuItem With {.Text = "删除数据子库", .Image = My.Resources.删除}

    Public Shared Property 菜单项_新建分类 As New ToolStripMenuItem With {.Text = "新建分类", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_转移分类 As New ToolStripMenuItem With {.Text = "转移分类", .Image = My.Resources.移动}
    Public Shared Property 菜单项_删除分类 As New ToolStripMenuItem With {.Text = "删除分类", .Image = My.Resources.删除}
    Public Shared Property 菜单项_导入分类 As New ToolStripMenuItem With {.Text = "导入分类", .Image = My.Resources.下载}
    Public Shared Property 菜单项_导出分类 As New ToolStripMenuItem With {.Text = "导出分类", .Image = My.Resources.上传}
    Public Shared Property 菜单项_更多分类操作 As New ToolStripMenuItem With {.Text = "更多", .Image = My.Resources.试验}

    Public Shared Property 更多分类操作菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_更多分类操作_清除Config缓存 As New ToolStripMenuItem With {.Text = "清除 Config 缓存", .Image = My.Resources.删除}
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

    Public Shared Property 分类右键菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_打开分类的文件夹 As New ToolStripMenuItem With {.Text = "文件夹", .Image = My.Resources.文件夹}
    Public Shared Property 菜单项_重命名分类 As New ToolStripMenuItem With {.Text = "重命名"}
    Public Shared Property 菜单项_设置分类的颜色 As New ToolStripMenuItem With {.Text = "设置颜色", .Image = My.Resources.颜色滤镜}
    Public Shared Property 菜单项_设置分类的字体 As New ToolStripMenuItem With {.Text = "设置字体", .Image = My.Resources.文字大小}

    Public Shared Sub 添加分类右键菜单的所有菜单项()
        分类右键菜单.Items.Add(菜单项_打开分类的文件夹)
        分类右键菜单.Items.Add(菜单项_重命名分类)
        分类右键菜单.Items.Add(New ToolStripSeparator)
        分类右键菜单.Items.Add(菜单项_设置分类的颜色)
        分类右键菜单.Items.Add(菜单项_设置分类的字体)
    End Sub

    Public Shared Property 项菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_新建项 As New ToolStripMenuItem With {.Text = "新建项", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_下载并新建项 As New ToolStripMenuItem With {.Text = "下载并新建项", .Image = My.Resources.下载}
    Public Shared Property 菜单项_移动项 As New ToolStripMenuItem With {.Text = "移动项", .Image = My.Resources.移动}
    Public Shared Property 菜单项_删除项 As New ToolStripMenuItem With {.Text = "删除项", .Image = My.Resources.删除}
    Public Shared Property 菜单项_导入项 As New ToolStripMenuItem With {.Text = "导入项", .Image = My.Resources.下载}
    Public Shared Property 菜单项_导出项 As New ToolStripMenuItem With {.Text = "导出项", .Image = My.Resources.上传}
    Public Shared Property 菜单项_批量创建项 As New ToolStripMenuItem With {.Text = "批量创建", .Image = My.Resources.代码文件夹}

    Public Shared Property 菜单项_本地更新项 As New ToolStripMenuItem With {.Text = "本地更新"}
    Public Shared Property 本地更新项菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_从Mods中覆盖到数据库 As New ToolStripMenuItem With {.Text = "从 Mods 中覆盖到数据库", .Image = My.Resources.试验}
    Public Shared Property 菜单项_从Mods中替换到数据库 As New ToolStripMenuItem With {.Text = "从 Mods 中替换到数据库", .Image = My.Resources.试验}

    Public Shared Property 菜单项_设置项字体 As New ToolStripMenuItem With {.Text = "设置字体", .Image = My.Resources.文字大小}
    Public Shared Property 菜单项_切换项所属分类显示 As New ToolStripMenuItem With {.Text = "切换分类列", .Image = My.Resources.切换}


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
        菜单项_本地更新项.DropDown = 本地更新项菜单
        本地更新项菜单.Items.Add(菜单项_从Mods中覆盖到数据库)
        本地更新项菜单.Items.Add(菜单项_从Mods中替换到数据库)

        项菜单.Items.Add(New ToolStripSeparator)
        项菜单.Items.Add(菜单项_设置项字体)
        项菜单.Items.Add(菜单项_切换项所属分类显示)
    End Sub

    Public Shared Property 项右键菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_安装 As New ToolStripMenuItem With {.Text = "安装", .Image = My.Resources.下载, .ShortcutKeys = Keys.F5}
    Public Shared Property 菜单项_卸载 As New ToolStripMenuItem With {.Text = "卸载", .Image = My.Resources.上传, .ShortcutKeys = Keys.F6}
    Public Shared Property 菜单项_配置项 As New ToolStripMenuItem With {.Text = "配置项", .Image = My.Resources.试验}
    Public Shared Property 菜单项_打开项的文件夹 As New ToolStripMenuItem With {.Text = "文件夹", .Image = My.Resources.文件夹, .ShortcutKeys = Keys.F1}
    Public Shared Property 菜单项_编辑项 As New ToolStripMenuItem With {.Text = "编辑"}

    Public Shared Property 编辑项功能菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.X轴DPI比率, 25 * 界面控制.Y轴DPI比率)}
    Public Shared Property 菜单项_重命名项 As New ToolStripMenuItem With {.Text = "重命名", .ShortcutKeys = Keys.F2}
    Public Shared Property 菜单项_用VSC打开 As New ToolStripMenuItem With {.Text = "用 Visual Studio Code 打开", .Image = My.Resources.代码文件夹}
    Public Shared Property 菜单项_用VS打开 As New ToolStripMenuItem With {.Text = "用 Visual Studio 打开", .Image = My.Resources.代码文件夹}
    Public Shared Property 菜单项_编辑项_清除Config缓存 As New ToolStripMenuItem With {.Text = "清除 Config 缓存", .Image = My.Resources.删除}
    Public Shared Property 菜单项_编辑项_转换安装命令到安装规划 As New ToolStripMenuItem With {.Text = "转换安装命令到安装规划", .Image = My.Resources.试验}
    Public Shared Property 菜单项_编辑项_转换安装规划到安装命令 As New ToolStripMenuItem With {.Text = "转换安装规划到安装命令", .Image = My.Resources.试验}

    Public Shared Sub 添加项右键菜单的所有菜单项()
        项右键菜单.Items.Add(菜单项_安装)
        项右键菜单.Items.Add(菜单项_卸载)
        项右键菜单.Items.Add(New ToolStripSeparator)
        项右键菜单.Items.Add(菜单项_配置项)
        项右键菜单.Items.Add(菜单项_打开项的文件夹)

        项右键菜单.Items.Add(菜单项_编辑项)
        菜单项_编辑项.DropDown = 编辑项功能菜单
        编辑项功能菜单.Items.Add(菜单项_重命名项)
        编辑项功能菜单.Items.Add(New ToolStripSeparator)
        编辑项功能菜单.Items.Add(菜单项_用VSC打开)
        编辑项功能菜单.Items.Add(菜单项_用VS打开)
        编辑项功能菜单.Items.Add(New ToolStripSeparator)
        编辑项功能菜单.Items.Add(菜单项_编辑项_清除Config缓存)
        编辑项功能菜单.Items.Add(New ToolStripSeparator)
        编辑项功能菜单.Items.Add(菜单项_编辑项_转换安装命令到安装规划)
        编辑项功能菜单.Items.Add(菜单项_编辑项_转换安装规划到安装命令)
    End Sub


    Public Shared Sub 添加菜单的触发()
        添加分类和子库菜单的所有菜单项()
        添加分类右键菜单的所有菜单项()
        添加项菜单的所有菜单项()
        添加项右键菜单的所有菜单项()
        AddHandler Form1.UiButton1.MouseDown, Sub(sender, e) 分类和子库菜单.Show(sender, New Point(sender.Width - 分类和子库菜单.Width, sender.Height))
        AddHandler Form1.UiButton2.MouseDown, Sub(sender, e) 项菜单.Show(sender, New Point(0, sender.Height))
        AddHandler Form1.ListView1.MouseDown, Sub(sender, e) If e.Button = MouseButtons.Right Then 分类右键菜单.Show(sender, e.X, e.Y)
        AddHandler Form1.ListView2.MouseDown, Sub(sender, e) If e.Button = MouseButtons.Right Then 项右键菜单.Show(sender, e.X, e.Y)
    End Sub



End Class
