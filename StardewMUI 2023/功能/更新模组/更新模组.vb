Public Class 更新模组



    Public Shared Async Sub 获取NEXUS文件列表(模组ID As String)

        Dim a As New NEXUS.GetModFileList With {.ST_ApiKey = 设置.全局设置数据("NexusAPI")}
        Dim str1 As String = Await Task.Run(Function() a.StartGet("stardewvalley", 模组ID, NEXUS.FileType.main_optional_updateFile_miscellaneous))






    End Sub


    Public Shared Sub 转到下载文件页面(标题 As String)
        Form1.UiTabControl1.SelectedTab = Form1.TabPage下载更新

    End Sub





End Class
