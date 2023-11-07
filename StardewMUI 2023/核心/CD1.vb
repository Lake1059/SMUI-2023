﻿Public Class CD1

    Public Shared Sub 匹配到_复制文件夹到Mods()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.复制文件夹到Mods,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_覆盖文件夹到Mods()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.覆盖文件夹到Mods,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_复制文件夹()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.复制文件夹,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_覆盖Content()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.覆盖Content,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_新增文件()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.新增文件,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_新增文件并验证()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.新增文件并验证,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_替换文件()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.替换文件,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_替换文件且无检测()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.替换文件且无检测,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_安装时检查文件夹的存在()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.安装时检查文件夹的存在,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_卸载时检查文件夹的存在()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.卸载时检查文件夹的存在,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_安装时检查文件的存在()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.安装时检查文件的存在,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_卸载时检查文件的存在()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.卸载时检查文件的存在,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_在安装时检查Mods中的排斥文件夹()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.在安装时检查Mods中的排斥文件夹,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_在安装时检查Mods中已安装模组的版本()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.在安装时检查Mods中已安装模组的版本,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_卸载时取消操作()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.卸载时取消操作,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_安装时运行可执行文件()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.安装时运行可执行文件,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_卸载时运行可执行文件()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.卸载时运行可执行文件,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_安装时弹窗()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                     .操作类型 = 公共对象.任务队列操作类型枚举.安装时弹窗,
                     .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_卸载时弹窗()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                    .操作类型 = 公共对象.任务队列操作类型枚举.卸载时弹窗,
                    .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub
    Public Shared Sub 匹配到_声明各种核心功能的启停()
        任务队列.任务列表.Add(New 任务队列.任务列表结构 With {
                    .操作类型 = 公共对象.任务队列操作类型枚举.声明各种核心功能的启停,
                    .参数行 = 任务队列.安装规划原文本列表对象(任务队列.当前正在处理的索引).Value})
    End Sub


End Class


