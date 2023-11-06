Public Class 安装卸载任务队列类

    Public 项路径 As String
    Public 游戏路径 As String
    Public 游戏备份路径 As String

    Public Shared Property 任务列表 As List(Of 任务列表结构)

    Public Structure 任务列表结构
        Public 操作类型 As 公共对象.任务队列操作类型枚举
        Public 参数行 As String
        Public 所在行数 As Integer
    End Structure

    Public Shared Property 匹配字典 As New List(Of KeyValuePair(Of String, 匹配操作委托))()
    Delegate Sub 匹配操作委托()

    Public Shared Sub 初始化字典()
        匹配字典.Add(New KeyValuePair(Of String, 匹配操作委托)("CD-D-MODS", AddressOf 匹配到_复制文件夹到Mods))
        匹配字典.Add(New KeyValuePair(Of String, 匹配操作委托)("CD-D-MODS-COVER", AddressOf 匹配到_覆盖文件夹到Mods))
        匹配字典.Add(New KeyValuePair(Of String, 匹配操作委托)("CD-D-ROOT", AddressOf 匹配到_复制文件夹))
        匹配字典.Add(New KeyValuePair(Of String, 匹配操作委托)("CD-D-CONTENT", AddressOf 匹配到_覆盖Content))
        匹配字典.Add(New KeyValuePair(Of String, 匹配操作委托)("CD-F-ADD", AddressOf 匹配到_新增文件))
        匹配字典.Add(New KeyValuePair(Of String, 匹配操作委托)("CD-F-ADD-SHA", AddressOf 匹配到_新增文件并验证))
        匹配字典.Add(New KeyValuePair(Of String, 匹配操作委托)("CD-F-REP", AddressOf 匹配到_替换文件))
        匹配字典.Add(New KeyValuePair(Of String, 匹配操作委托)("CD-F-NULL", AddressOf 匹配到_替换文件且无检测))


    End Sub

    Private Shared Sub 匹配到_复制文件夹到Mods()
        任务列表.Add(New 任务列表结构 With {
                 .操作类型 = 公共对象.任务队列操作类型枚举.复制文件夹到Mods,
                 .参数行 = 安装规划原文本列表对象(当前正在处理的索引).Value,
                 .所在行数 = 当前正在处理的索引 + 1})
    End Sub
    Private Shared Sub 匹配到_覆盖文件夹到Mods()
        任务列表.Add(New 任务列表结构 With {
                 .操作类型 = 公共对象.任务队列操作类型枚举.覆盖文件夹到Mods,
                 .参数行 = 安装规划原文本列表对象(当前正在处理的索引).Value,
                 .所在行数 = 当前正在处理的索引 + 1})
    End Sub
    Private Shared Sub 匹配到_复制文件夹()
        任务列表.Add(New 任务列表结构 With {
                 .操作类型 = 公共对象.任务队列操作类型枚举.复制文件夹,
                 .参数行 = 安装规划原文本列表对象(当前正在处理的索引).Value,
                 .所在行数 = 当前正在处理的索引 + 1})
    End Sub
    Private Shared Sub 匹配到_覆盖Content()
        任务列表.Add(New 任务列表结构 With {
                 .操作类型 = 公共对象.任务队列操作类型枚举.覆盖Content,
                 .参数行 = 安装规划原文本列表对象(当前正在处理的索引).Value,
                 .所在行数 = 当前正在处理的索引 + 1})
    End Sub
    Private Shared Sub 匹配到_新增文件()
        任务列表.Add(New 任务列表结构 With {
                 .操作类型 = 公共对象.任务队列操作类型枚举.新增文件,
                 .参数行 = 安装规划原文本列表对象(当前正在处理的索引).Value,
                 .所在行数 = 当前正在处理的索引 + 1})
    End Sub
    Private Shared Sub 匹配到_新增文件并验证()
        任务列表.Add(New 任务列表结构 With {
                 .操作类型 = 公共对象.任务队列操作类型枚举.新增文件并验证,
                 .参数行 = 安装规划原文本列表对象(当前正在处理的索引).Value,
                 .所在行数 = 当前正在处理的索引 + 1})
    End Sub
    Private Shared Sub 匹配到_替换文件()
        任务列表.Add(New 任务列表结构 With {
                 .操作类型 = 公共对象.任务队列操作类型枚举.替换文件,
                 .参数行 = 安装规划原文本列表对象(当前正在处理的索引).Value,
                 .所在行数 = 当前正在处理的索引 + 1})
    End Sub
    Private Shared Sub 匹配到_替换文件且无检测()
        任务列表.Add(New 任务列表结构 With {
                 .操作类型 = 公共对象.任务队列操作类型枚举.替换文件且无检测,
                 .参数行 = 安装规划原文本列表对象(当前正在处理的索引).Value,
                 .所在行数 = 当前正在处理的索引 + 1})
    End Sub









    Public Shared Property 当前正在处理的索引 As Integer
    Public Shared Property 安装规划原文本列表对象 As New List(Of KeyValuePair(Of String, String))







End Class
