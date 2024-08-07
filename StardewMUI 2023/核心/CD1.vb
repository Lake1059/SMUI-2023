Public Class CD1

    Public Shared Sub 匹配到_复制文件夹到Mods()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .规划名称 = "CD-D-MODS",
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_覆盖文件夹到Mods()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .规划名称 = "CD-D-MODS-COVER",
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_复制文件夹()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .规划名称 = "CD-D-ROOT",
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_覆盖Content()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .规划名称 = "CD-D-CONTENT",
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_安装单个文件()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .规划名称 = "CD-F",
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_检查存在性()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .规划名称 = "CR-Check-EXIST",
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_安装时检查Mods中已安装模组的版本()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .规划名称 = "CR-IN-MODS-VER",
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_卸载时取消操作()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .规划名称 = "CR-UN",
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_运行可执行文件()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .规划名称 = "CR-SHELL",
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_弹窗()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .规划名称 = "CR-MSGBOX",
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub

End Class


