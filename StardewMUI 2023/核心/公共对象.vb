Public Class 公共对象

    Public Enum 安装状态枚举
        未知 = -1

        未配置 = 0
        已安装 = 1
        未安装 = 2
        安装不完整 = 3

        文件夹已复制 = 10
        文件夹未复制 = 11
        文件夹部分复制 = 12

        附加内容 = 19

        文件已替换 = 20
        文件未替换 = 21
        文件部分替换 = 22

        文件已复制 = 30
        文件未复制 = 31
        文件部分复制 = 32
        文件已复制并验证 = 35
        文件已复制但验证失败 = 36

        源文件夹丢失 = 101
        源文件丢失 = 102

        不带判断的文件复制 = 40

        覆盖Content文件夹 = 50

    End Enum

    Public Structure 项数据计算类型结构
        Dim 全部 As Boolean
        Dim 安装状态 As Boolean
        Dim 名称 As Boolean
        Dim 作者 As Boolean
        Dim 版本 As Boolean
        Dim 已安装版本 As Boolean
        Dim 最低SMAPI版本 As Boolean
        Dim 描述 As Boolean
        Dim UniqueID As Boolean
        Dim 更新键 As Boolean
        Dim 内容包依赖 As Boolean
        Dim 其他依赖项 As Boolean
    End Structure

    Public Enum 任务队列操作类型枚举
        复制文件夹到Mods = 1
        覆盖文件夹到Mods = 2
        复制文件夹 = 6
        覆盖Content = 9
        新增文件 = 11
        新增文件并验证 = 12
        替换文件 = 16
        替换文件且无检测 = 19

        安装时检查文件夹的存在 = 51
        卸载时检查文件夹的存在 = 52
        安装时检查文件的存在 = 53
        卸载时检查文件的存在 = 54

        安装时检查Mods中已安装模组的版本 = 61

        卸载时取消操作 = 71
        安装时运行可执行文件 = 73
        卸载时运行可执行文件 = 74

        安装时弹窗 = 81
        卸载时弹窗 = 82

        声明各种核心功能的启停 = 91

    End Enum

End Class
