''' <summary>
''' 插件接口，所有专门提供的插件功能都在这里
''' </summary>
Public Class PluginAPI

    ''' <summary>
    ''' 在起始页面的创作者面板中添加交互界面，推荐用自定义控件把界面摆出来
    ''' </summary>
    ''' <param name="panel">任何有 Dock 属性的控件</param>
    Public Shared Sub 添加创作者面板(panel As Control)
        If panel Is Nothing Then Exit Sub
        Form1.TabPage创作者面板.Controls.Add(panel)
        panel.BringToFront()
        panel.Dock = DockStyle.Top
    End Sub

    ''' <summary>
    ''' 向调试界面输出内容，注意在其他线程中使用此方法无效
    ''' </summary>
    ''' <param name="文本"></param>
    ''' <param name="颜色">可以使用 Color1 类中定义好的颜色值</param>
    ''' <param name="是否强制转到调试界面"></param>
    Public Shared Sub 添加调试输出(文本 As String, 颜色 As Color, Optional 是否强制转到调试界面 As Boolean = False)
        DebugPrint(文本, 颜色, 是否强制转到调试界面)
    End Sub



    Public Class 显示窗体
        Public Shared Sub 向主窗口显示模式窗体(哪个窗口 As Form)
            显示模式窗体(哪个窗口, Form1)
        End Sub
        Public Shared Sub 向主窗口显示窗体(哪个窗口 As Form)
            Module1.显示窗体(哪个窗口, Form1)
        End Sub
    End Class


    ''' <summary>
    ''' 添加一个完整支持的安装规划是十分复杂的，如果没有这里的方法那么几乎很难让你的规划正常运行
    ''' </summary>
    Public Class 添加安装规划

        ''' <summary>
        ''' 将你的安装规划添加到安装卸载中，让它实现执行安装和卸载
        ''' <para></para>
        ''' 在安装和卸载操作中遇到不符合要求时需要立刻停止，直接用 Err.Raise 生成报错即可
        ''' </summary>
        ''' <param name="规划Key"></param>
        ''' <param name="识别规划操作">识别规划的作用是把一个安装规划和其参数加入到待执行的列表中
        ''' <para></para>
        ''' 设计目的是当规划类型很多的时候减少匹配时间，不过我这里不好解释这里面要写啥
        ''' <para></para>
        ''' 可以直接从我的演示插件工程或者 SMUI 源码里抄一下然后改一下，C# 语言的让 GPT 翻译一下
        ''' <para></para>
        ''' 这是个委托，你需要把方法挂到这上面，VB 是用 AddressOf，C# 是用赋值的方式
        ''' </param>
        ''' <param name="安装操作">执行安装操作，此方法在后台线程中执行
        ''' <para></para>
        ''' 这是个委托，你需要把方法挂到这上面，VB 是用 AddressOf，C# 是用赋值的方式
        ''' </param>
        ''' <param name="卸载操作">执行卸载操作，此方法在后台线程中执行
        ''' <para></para>
        ''' 这是个委托，你需要把方法挂到这上面，VB 是用 AddressOf，C# 是用赋值的方式
        ''' </param>
        Public Shared Sub 添加安装卸载功能(规划Key As String, 识别规划操作 As 任务队列.DE1, 安装操作 As 任务队列.DE2, 卸载操作 As 任务队列.DE3)
            任务队列.队列键值匹配字典.Add(规划Key, 识别规划操作)
            任务队列.安装操作匹配字典.Add(规划Key, 安装操作)
            任务队列.卸载操作匹配字典.Add(规划Key, 卸载操作)
        End Sub

        ''' <summary>
        ''' 在你的安装和卸载操作中执行，用这个方法获取对应规划步骤的参数
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function 在安装卸载操作中获取参数列表() As List(Of String)
            Return New List(Of String)(任务队列.任务列表(任务队列.当前正在处理的索引).参数行.Split("|").ToList)
        End Function

        ''' <summary>
        ''' 由于安装和卸载操作是在后台线程中执行的，要输出调试信息必须调用此方法
        ''' </summary>
        ''' <param name="颜色">1=白色，2=蓝色，3=红色</param>
        ''' <param name="信息"></param>
        Public Shared Sub 在安装卸载操作中输出调试信息(颜色 As Integer, 信息 As String)
            安装卸载.后台线程对象.ReportProgress(颜色, 信息)
        End Sub

        ''' <summary>
        ''' 将你的安装规划添加到配置队列中，让它在配置队列中运行起来
        ''' </summary>
        ''' <param name="规划Key"></param>
        ''' <param name="显示名称">这个规划在配置队列的列表视图中会显示成什么动作描述，保持简短明确</param>
        ''' <param name="添加规划菜单项">配置队列中添加规划菜单里的菜单项
        ''' <para></para>
        ''' 你需要将其功能绑定上去，才能把新的规划添加到编辑规划的列表视图中
        ''' <para></para>
        ''' 用这个方法：配置队列的菜单.添加新规划通用调用(操作类型 As String, 默认参数 As String)
        ''' </param>
        ''' <param name="编辑规划操作">是一个不带参数的 Sub，一般来讲需要提供一个窗体来让用户编辑规划的参数并要实现其中的全部功能
        ''' <para></para>
        ''' 如果没有让用户编辑的参数也必须提供这个方法，不允许给 Null，可以直接输出一个提示或者干脆就什么都不做
        ''' <para></para>
        ''' 这是个委托，你需要把方法挂到这上面，VB 是用 AddressOf，C# 是用赋值的方式
        ''' <para></para>
        ''' 我知道你会问没有参数那如何获取要用的数据，你需要用添加安装规划类里的其他方法来获取，因为这里不是专门为插件设计的
        ''' </param>
        Public Shared Sub 添加配置队列功能(规划Key As String, 显示名称 As String, 添加规划菜单项 As ToolStripMenuItem, 编辑规划操作 As 配置队列.DE1)
            配置队列.规划显示名称字典.Add(规划Key, 显示名称)
            配置队列的菜单.菜单项_与第三方规划的分隔符.Visible = True
            配置队列的菜单.添加规划菜单.Items.Add(添加规划菜单项)
            配置队列.编辑规划操作字典.Add(规划Key, 编辑规划操作)
        End Sub

        ''' <summary>
        ''' 在你的编辑规划操作中执行，用这个方法获取在编辑规划操作中需要的参数
        ''' </summary>
        ''' <returns>一个字符串的列表对象，每个参数按顺序排列</returns>
        Public Shared Function 获取配置队列中选中规划的参数() As List(Of String)
            Return New List(Of String)(Form1.ListView7.SelectedItems(0).SubItems(1).Text.Split("|").ToList)
        End Function

        ''' <summary>
        ''' 在你的编辑规划操作中执行，如果用户确认了编辑，则调用此方法把参数写到规划列表视图里去
        ''' <para></para>
        ''' 注意空字符串会被自动移除，所有空字符串的值你要想办法改成其他值识别
        ''' </summary>
        ''' <param name="参数列表"></param>
        Public Shared Sub 将用户编辑好的参数写回去(参数列表 As List(Of String))
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = String.Join("|", 参数列表.Where(Function(s) Not String.IsNullOrWhiteSpace(s)))
        End Sub


        Public Shared Function 获取项内容中的文件夹列表() As List(Of String)
            Dim a As New List(Of String)
            For i = 0 To Form1.ListView6.Items.Count - 1
                If Form1.ListView6.Items(i).SubItems(1).Text = "文件夹" Then
                    a.Add(Form1.ListView6.Items(i).Text)
                End If
            Next
            Return a
        End Function

        Public Shared Function 获取项内容中的文件列表() As List(Of String)
            Dim a As New List(Of String)
            For i = 0 To Form1.ListView6.Items.Count - 1
                If Form1.ListView6.Items(i).SubItems(1).Text = "文件" Then
                    a.Add(Form1.ListView6.Items(i).Text)
                End If
            Next
            Return a
        End Function


        ''' <summary>
        ''' 将你的安装规划的的安装判断程序加入到项信息读取中，以实现你自己的安装状态判断
        ''' <para></para>
        ''' 注意还需要调用添加安装状态值，这里只是添加程序
        ''' </summary>
        ''' <param name="规划Key"></param>
        ''' <param name="程序"></param>
        Public Shared Sub 添加安装状态判断程序(规划Key As String, 程序 As 项信息读取类.DE1)
            项信息读取类.第三方安装判断执行字典.Add(规划Key, 程序)
        End Sub

        ''' <summary>
        ''' 添加安装规划的安装状态值，例如已安装、未安装等，当然你不要真的添加我举例的这些
        ''' </summary>
        ''' <param name="安装状态Key">例如 Installed、UnInstalled 这些值已经由 SMUI 定义，请添加自己的独特状态Key，重复添加的值不会生效</param>
        ''' <param name="显示给用户的状态字符串">对应的安装状态要在界面上显示成什么</param>
        '''     ''' <param name="模组项的文字颜色">设置单个安装状态要让模组项的文字显示成什么颜色，可以使用 Color1 类中的预设颜色值</param>
        Public Shared Sub 添加安装状态值(安装状态Key As String, 显示给用户的状态字符串 As String, 模组项的文字颜色 As Color)
            项信息读取类.安装状态字典.Add(安装状态Key, 显示给用户的状态字符串)
            管理模组.第三方安装状态颜色值.Add(安装状态Key, 模组项的文字颜色)
        End Sub
        ''' <summary>
        ''' 添加安装规划的安装状态值，例如已安装、未安装等，当然你不要真的添加我举例的这些
        ''' </summary>
        ''' <param name="安装状态Key">例如 Installed、UnInstalled 这些值已经由 SMUI 定义，请添加自己的独特状态Key，重复添加的值不会生效</param>
        ''' <param name="显示给用户的状态字符串">对应的安装状态要在界面上显示成什么</param>
        Public Shared Sub 添加安装状态值(安装状态Key As String, 显示给用户的状态字符串 As String)
            项信息读取类.安装状态字典.Add(安装状态Key, 显示给用户的状态字符串)
        End Sub

    End Class


End Class
