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

        不带验证的文件复制 = 40

        覆盖Content文件夹 = 50
    End Enum

    Public Structure 项数据计算类型枚举
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

    Public Enum CDTask
        CDCD = 1

        CDGCD = 10

        CDMAD = 20

        CDGRF = 30
        CDGRF_SHA = 31
        CDGRF_SHA_BYTE = 32

        CDGCF = 40
        CDGCF_SHA = 41
        CDGCF_SHA_BYTE = 42

        CDF = 50

        CDVD = 60

        RQ_D = 71
        RQ_D_IN = 72
        RQ_D_UN = 73
        RQ_F = 74
        RQ_F_IN = 75
        RQ_F_UN = 76

        CR_UN_OFF = 80
        CR_CG_DB = 81
        CR_UN_CANCEL = 82

        CR_APP_SHELL_IN = 100
        CR_APP_SHELL_UN = 101
        CR_APP_SHELL_P_IN = 102
        CR_APP_SHELL_P_UN = 103

        SUB_D_EX_IN = 200

    End Enum



End Class
