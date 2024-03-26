
Public Class 管理模组的菜单

    Public Shared Property 分类和子库菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_刷新分类 As New ToolStripMenuItem With {.Text = "刷新", .Image = My.Resources.刷新}

    Public Shared Property 菜单项_子库菜单 As New ToolStripMenuItem With {.Text = "数据子库操作", .Image = My.Resources.数据库}
    Public Shared Property 数据子库操作菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
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
    Public Shared Property 更多分类操作菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_更多分类操作_转换安装命令到安装规划 As New ToolStripMenuItem With {.Text = "转换安装命令到安装规划", .Image = My.Resources.试验}
    Public Shared Property 菜单项_更多分类操作_转换安装规划到安装命令 As New ToolStripMenuItem With {.Text = "转换安装规划到安装命令", .Image = My.Resources.试验}
    Public Shared Property 菜单项_更多分类操作_清除Config缓存 As New ToolStripMenuItem With {.Text = "清除 Config 缓存", .Image = My.Resources.删除}
    Public Shared Property 菜单项_更多分类操作_删除分类排序 As New ToolStripMenuItem With {.Text = "删除排序数据以重置顺序", .Image = My.Resources.删除}

    Public Shared Property 子库列表_选择 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 子库列表_删除 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}

    Public Shared Sub 添加分类和子库菜单的所有菜单项()
        分类和子库菜单.Items.Add(菜单项_刷新分类)
        分类和子库菜单.Items.Add(New ToolStripSeparator)
        分类和子库菜单.Items.Add(菜单项_子库菜单)

        菜单项_子库菜单.DropDown = 数据子库操作菜单
        数据子库操作菜单.Items.Add(菜单项_切换数据子库)
        菜单项_切换数据子库.DropDown = 子库列表_选择
        数据子库操作菜单.Items.Add(New ToolStripSeparator)
        数据子库操作菜单.Items.Add(菜单项_刷新数据子库)
        数据子库操作菜单.Items.Add(菜单项_新建数据子库)
        数据子库操作菜单.Items.Add(New ToolStripSeparator)
        数据子库操作菜单.Items.Add(菜单项_导入数据子库)
        数据子库操作菜单.Items.Add(菜单项_导出数据子库)
        数据子库操作菜单.Items.Add(New ToolStripSeparator)
        数据子库操作菜单.Items.Add(菜单项_删除数据子库)
        菜单项_删除数据子库.DropDown = 子库列表_删除

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
        更多分类操作菜单.Items.Add(菜单项_更多分类操作_转换安装命令到安装规划)
        更多分类操作菜单.Items.Add(菜单项_更多分类操作_转换安装规划到安装命令)
        更多分类操作菜单.Items.Add(菜单项_更多分类操作_清除Config缓存)
        更多分类操作菜单.Items.Add(菜单项_更多分类操作_删除分类排序)
    End Sub

    Public Shared Property 分类右键菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_打开分类的文件夹 As New ToolStripMenuItem With {.Text = "文件夹", .Image = My.Resources.文件夹}
    Public Shared Property 菜单项_重命名分类 As New ToolStripMenuItem With {.Text = "重命名"}

    Public Shared Property 菜单项_分类上下移动菜单 As New ToolStripMenuItem With {.Text = "排序", .Image = My.Resources.移动}
    Public Shared Property 分类上下移动菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_将分类上移 As New ToolStripMenuItem With {.Text = "上移（F3）", .Image = My.Resources.上箭头}
    Public Shared Property 菜单项_将分类下移 As New ToolStripMenuItem With {.Text = "下移（F4）", .Image = My.Resources.下箭头}
    Public Shared Property 菜单项_删除选中分类中的项排序 As New ToolStripMenuItem With {.Text = "删除其中的项排序", .Image = My.Resources.删除}

    Public Shared Property 菜单项_设置分类的颜色 As New ToolStripMenuItem With {.Text = "设置颜色", .Image = My.Resources.颜色滤镜}
    Public Shared Property 菜单项_设置分类的字体 As New ToolStripMenuItem With {.Text = "设置字体", .Image = My.Resources.文字大小}

    Public Shared Sub 添加分类右键菜单的所有菜单项()
        分类右键菜单.Items.Add(菜单项_打开分类的文件夹)
        分类右键菜单.Items.Add(菜单项_重命名分类)
        分类右键菜单.Items.Add(New ToolStripSeparator)
        分类右键菜单.Items.Add(菜单项_设置分类的颜色)
        分类右键菜单.Items.Add(菜单项_设置分类的字体)

        分类右键菜单.Items.Add(菜单项_分类上下移动菜单)
        菜单项_分类上下移动菜单.DropDown = 分类上下移动菜单
        分类上下移动菜单.Items.Add(菜单项_将分类上移)
        分类上下移动菜单.Items.Add(菜单项_将分类下移)
        分类上下移动菜单.Items.Add(New ToolStripSeparator)
        分类上下移动菜单.Items.Add(菜单项_删除选中分类中的项排序)


    End Sub

    Public Shared Property 项菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_新建项 As New ToolStripMenuItem With {.Text = "新建项", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_下载并新建项 As New ToolStripMenuItem With {.Text = "下载并新建项", .Image = My.Resources.下载}
    Public Shared Property 菜单项_移动项 As New ToolStripMenuItem With {.Text = "移动项", .Image = My.Resources.移动}
    Public Shared Property 菜单项_删除项 As New ToolStripMenuItem With {.Text = "删除项", .Image = My.Resources.删除}
    Public Shared Property 菜单项_导入项 As New ToolStripMenuItem With {.Text = "导入项", .Image = My.Resources.下载}
    Public Shared Property 菜单项_导出项 As New ToolStripMenuItem With {.Text = "导出项", .Image = My.Resources.上传}
    Public Shared Property 菜单项_批量创建项 As New ToolStripMenuItem With {.Text = "批量创建", .Image = My.Resources.代码文件夹}

    Public Shared Property 菜单项_本地更新项 As New ToolStripMenuItem With {.Text = "本地更新"}
    Public Shared Property 本地更新项菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_从Mods中覆盖到数据库 As New ToolStripMenuItem With {.Text = "从 Mods 中覆盖到数据库", .Image = My.Resources.试验}
    Public Shared Property 菜单项_从Mods中替换到数据库 As New ToolStripMenuItem With {.Text = "从 Mods 中替换到数据库", .Image = My.Resources.试验}

    Public Shared Property 菜单项_设置项字体 As New ToolStripMenuItem With {.Text = "设置字体", .Image = My.Resources.文字大小}
    Public Shared Property 菜单项_切换项所属分类显示 As New ToolStripMenuItem With {.Text = "切换分类列", .Image = My.Resources.切换}
    Public Shared Property 菜单项_管理虚拟组 As New ToolStripMenuItem With {.Text = "管理虚拟组", .Image = My.Resources.六个点}


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
        项菜单.Items.Add(菜单项_管理虚拟组)
    End Sub

    Public Shared Property 项右键菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_安装 As New ToolStripMenuItem With {.Text = "安装", .Image = My.Resources.下载, .ShortcutKeys = Keys.F5}
    Public Shared Property 菜单项_卸载 As New ToolStripMenuItem With {.Text = "卸载", .Image = My.Resources.上传, .ShortcutKeys = Keys.F6}
    Public Shared Property 菜单项_配置项 As New ToolStripMenuItem With {.Text = "配置项", .Image = My.Resources.试验}
    Public Shared Property 菜单项_打开项的文件夹 As New ToolStripMenuItem With {.Text = "文件夹", .Image = My.Resources.文件夹, .ShortcutKeys = Keys.F1}
    Public Shared Property 菜单项_编辑项 As New ToolStripMenuItem With {.Text = "编辑"}

    Public Shared Property 编辑项功能菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_重命名项 As New ToolStripMenuItem With {.Text = "重命名", .ShortcutKeys = Keys.F2}
    Public Shared Property 菜单项_用VSC打开 As New ToolStripMenuItem With {.Text = "用 Visual Studio Code 打开", .Image = My.Resources.代码文件夹}
    Public Shared Property 菜单项_用VS打开 As New ToolStripMenuItem With {.Text = "用 Visual Studio 打开", .Image = My.Resources.代码文件夹}
    Public Shared Property 菜单项_编辑项_清除Config缓存 As New ToolStripMenuItem With {.Text = "清除 Config 缓存", .Image = My.Resources.删除}
    Public Shared Property 菜单项_编辑项_转换安装命令到安装规划 As New ToolStripMenuItem With {.Text = "转换安装命令到安装规划", .Image = My.Resources.试验}
    Public Shared Property 菜单项_编辑项_转换安装规划到安装命令 As New ToolStripMenuItem With {.Text = "转换安装规划到安装命令", .Image = My.Resources.试验}
    Public Shared Property 菜单项_将项上移 As New ToolStripMenuItem With {.Text = "上移（F3）", .Image = My.Resources.上箭头}
    Public Shared Property 菜单项_将项下移 As New ToolStripMenuItem With {.Text = "下移（F4）", .Image = My.Resources.下箭头}

    Public Shared Property 菜单项_设置虚拟组 As New ToolStripMenuItem With {.Text = "设置虚拟组", .Image = My.Resources.六个点}

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
        编辑项功能菜单.Items.Add(New ToolStripSeparator)
        编辑项功能菜单.Items.Add(菜单项_将项上移)
        编辑项功能菜单.Items.Add(菜单项_将项下移)

        项右键菜单.Items.Add(菜单项_设置虚拟组)
    End Sub

    Public Shared Property 项筛选菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_全选 As New ToolStripMenuItem With {.Text = "全选", .Image = My.Resources.全选}
    Public Shared Property 菜单项_反选 As New ToolStripMenuItem With {.Text = "反选"}

    Public Shared Property 菜单项_选中所有已安装 As New ToolStripMenuItem With {.Text = "选中所有已安装"}
    Public Shared Property 菜单项_选中所有未安装 As New ToolStripMenuItem With {.Text = "选中所有未安装"}
    Public Shared Property 菜单项_选中所有非标项 As New ToolStripMenuItem With {.Text = "选中所有非标项"}
    Public Shared Property 菜单项_扫描当前子库所有已安装 As New ToolStripMenuItem With {.Text = "扫描当前子库所有已安装"}
    Public Shared Property 菜单项_扫描当前子库所有未安装 As New ToolStripMenuItem With {.Text = "扫描当前子库所有未安装"}
    Public Shared Property 菜单项_扫描当前子库所有非标项 As New ToolStripMenuItem With {.Text = "扫描当前子库所有非标项"}


    Public Shared Sub 添加项筛选菜单的所有菜单项()
        项筛选菜单.Items.Add(菜单项_全选)
        项筛选菜单.Items.Add(菜单项_反选)
        项筛选菜单.Items.Add(New ToolStripSeparator)
        项筛选菜单.Items.Add(菜单项_选中所有已安装)
        项筛选菜单.Items.Add(菜单项_选中所有未安装)
        项筛选菜单.Items.Add(菜单项_选中所有非标项)
        项筛选菜单.Items.Add(New ToolStripSeparator)
        项筛选菜单.Items.Add(菜单项_扫描当前子库所有已安装)
        项筛选菜单.Items.Add(菜单项_扫描当前子库所有未安装)
        项筛选菜单.Items.Add(菜单项_扫描当前子库所有非标项)
    End Sub



    Public Shared Property 描述菜单 As New 暗黑菜单条控件本体 With {.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)}
    Public Shared Property 菜单项_保存描述到纯文本 As New ToolStripMenuItem With {.Text = "保存到纯文本", .Image = My.Resources.保存}
    Public Shared Property 菜单项_保存描述到富文本 As New ToolStripMenuItem With {.Text = "保存到富文本", .Image = My.Resources.保存}
    Public Shared Property 菜单项_新建富文本文档 As New ToolStripMenuItem With {.Text = "新建富文本文档", .Image = My.Resources.添加带圆圈}
    Public Shared Property 菜单项_在写字板中编辑富文本 As New ToolStripMenuItem With {.Text = "用写字板编辑富文本"}
    Public Shared Property 菜单项_删除所有自定义描述 As New ToolStripMenuItem With {.Text = "删除所有自定义描述", .Image = My.Resources.删除}
    Public Shared Property 菜单项_切换描述栏富文本框的滚动条显示 As New ToolStripMenuItem With {.Text = "切换滚动条显示", .Image = My.Resources.切换}
    Public Shared Property 菜单项_设置选中内容的字体 As New ToolStripMenuItem With {.Text = "设置字体", .Image = My.Resources.文字大小}
    Public Shared Property 菜单项_设置选中内容的文字颜色 As New ToolStripMenuItem With {.Text = "设置文字颜色", .Image = My.Resources.颜色滤镜}
    Public Shared Property 菜单项_设置选中内容的背景颜色 As New ToolStripMenuItem With {.Text = "设置文字背景颜色", .Image = My.Resources.颜色滤镜}
    Public Shared Property 菜单项_清除所有格式 As New ToolStripMenuItem With {.Text = "清除所有格式", .Image = My.Resources.删除}

    Public Shared Sub 添加描述菜单的所有菜单项()
        描述菜单.Items.Add(菜单项_保存描述到纯文本)
        描述菜单.Items.Add(菜单项_保存描述到富文本)
        描述菜单.Items.Add(New ToolStripSeparator)
        描述菜单.Items.Add(菜单项_新建富文本文档)
        描述菜单.Items.Add(菜单项_在写字板中编辑富文本)
        描述菜单.Items.Add(New ToolStripSeparator)
        描述菜单.Items.Add(菜单项_删除所有自定义描述)
        描述菜单.Items.Add(New ToolStripSeparator)
        描述菜单.Items.Add(菜单项_切换描述栏富文本框的滚动条显示)
        描述菜单.Items.Add(New ToolStripSeparator)
        描述菜单.Items.Add(菜单项_设置选中内容的字体)
        描述菜单.Items.Add(菜单项_设置选中内容的文字颜色)
        描述菜单.Items.Add(菜单项_设置选中内容的背景颜色)
        描述菜单.Items.Add(New ToolStripSeparator)
        描述菜单.Items.Add(菜单项_清除所有格式)
    End Sub




    Public Shared Sub 添加菜单的触发()
        添加分类和子库菜单的所有菜单项()
        添加分类右键菜单的所有菜单项()
        添加项菜单的所有菜单项()
        添加项右键菜单的所有菜单项()
        添加项筛选菜单的所有菜单项()
        添加描述菜单的所有菜单项()
        AddHandler Form1.UiButton1.MouseDown, Sub(sender, e) 分类和子库菜单.Show(sender, New Point(sender.Width - 分类和子库菜单.Width, sender.Height))
        AddHandler Form1.UiButton2.MouseDown, Sub(sender, e) 项菜单.Show(sender, New Point(0, sender.Height))
        AddHandler Form1.ListView1.MouseDown, Sub(sender, e) If e.Button = MouseButtons.Right Then 分类右键菜单.Show(sender, e.X, e.Y)
        AddHandler Form1.ListView2.MouseDown, Sub(sender, e) If e.Button = MouseButtons.Right Then 项右键菜单.Show(sender, e.X, e.Y)
        AddHandler Form1.UiButton5.MouseDown, Sub(sender, e) 项筛选菜单.Show(sender, New Point(0, sender.Height))
        AddHandler Form1.UiButton10.MouseDown, Sub(sender, e) 描述菜单.Show(sender, New Point(0, sender.Height))
    End Sub

    Public Shared Sub 设置字体()
        分类和子库菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
        数据子库操作菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
        更多分类操作菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
        分类右键菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
        分类上下移动菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
        项菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
        本地更新项菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
        项右键菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
        编辑项功能菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
        项筛选菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
        描述菜单.Font = New Font(设置.全局设置数据("FontName"), Form1.Font.Size)
    End Sub

    Public Shared Sub 调整DPI()
        分类和子库菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
        数据子库操作菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
        更多分类操作菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
        分类右键菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
        分类上下移动菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
        项菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
        本地更新项菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
        项右键菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
        编辑项功能菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
        项筛选菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
        描述菜单.ImageScalingSize = New Size(25 * 界面控制.DPI, 25 * 界面控制.DPI)
    End Sub

End Class
