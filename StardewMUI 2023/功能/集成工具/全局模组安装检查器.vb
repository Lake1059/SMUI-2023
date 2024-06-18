
Imports System.IO

Public Class 全局模组安装检查器

    Public Shared Sub 初始化()
        AddHandler Form1.UiButton98.Click, AddressOf 开始扫描
    End Sub

    Public Shared Sub Print(文本 As String, 颜色 As Color)
        If 文本 = "" Then Exit Sub
        Form1.RichTextBox3.AppendText(vbCrLf & 文本)
        Form1.RichTextBox3.Select(Form1.RichTextBox3.TextLength - Len(文本), Len(文本))
        Form1.RichTextBox3.SelectionColor = 颜色
        Form1.RichTextBox3.Select(Form1.RichTextBox3.TextLength, 0)
        Form1.RichTextBox3.ScrollToCaret()
    End Sub

    Public Shared Sub 开始扫描()

        If Not FileIO.FileSystem.DirectoryExists(设置.全局设置数据("StardewValleyGamePath")) Then Exit Sub

        Form1.UiButton98.Enabled = False
        Form1.RichTextBox3.Text = "这里输出扫描结果"

        Dim m1 As New ModsGlobalCheck
        Dim smapiver As String = ""
        If FileIO.FileSystem.FileExists(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "StardewModdingAPI.exe")) Then
            Dim fileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "StardewModdingAPI.exe"))
            smapiver = $"{fileVersionInfo.FileMajorPart}.{fileVersionInfo.FileMinorPart}.{fileVersionInfo.FileBuildPart}"
        End If

        Dim e1 As String = m1.StartCheck(Path.Combine(设置.全局设置数据("StardewValleyGamePath"), "Mods"), Form1.RichTextBox3.Text, smapiver, "\")
        If e1 <> "" Then
            MsgBox(e1, MsgBoxStyle.Critical)
            Exit Sub
        End If

        Print("扫描到的 UniqueID 数量：" & m1.Data_UniqueID.Count, Color1.白色)

        For i = 0 To m1.Data_NoContentPackMods.Count - 1
            Print($"【未安装内容包依赖】{m1.Data_NoContentPackMods(i).UniqueID} 需要目标对象：{m1.Data_NoContentPackMods(i).TargetUniqueID}", Color1.红色)
        Next

        For i = 0 To m1.Data_NoDependencyMods.Count - 1
            Print($"【未安装其他依赖】{m1.Data_NoDependencyMods(i).UniqueID} 需要目标对象：{m1.Data_NoDependencyMods(i).TargetUniqueID}", Color1.红色)
        Next

        For i = 0 To m1.Data_DependencyVersionLowMods.Count - 1
            Print($"【其他依赖的版本过低】{m1.Data_DependencyVersionLowMods(i).UniqueID} 需要目标对象：{m1.Data_DependencyVersionLowMods(i).TargetUniqueID} 需要至少 {m1.Data_DependencyVersionLowMods(i).MinimumVersion} 版本", Color1.红色)
        Next

        For i = 0 To m1.Data_NeedUpdateSmapiMods.Count - 1
            Print($"【需要更新 SMAPI】{m1.Data_NeedUpdateSmapiMods(i).UniqueID} 需要至少 {m1.Data_NeedUpdateSmapiMods(i).MinimumApiVersion} 版本", Color1.红色)
        Next

        If m1.Data_MultiLevelFolderMods.Count > 0 Then
            Print($"【强烈不推荐套娃】除非遇到极特殊情况，否则不要对标准 SMAPI 模组进行套娃，这可能导致意外行为，SMUI 没有对此设计足够的兼容预测。请充分利用 SMUI 的机制。套娃指的是 Mods\[模组文件夹]\manifest.json 文件没有直接存在，要在[模组文件夹]中的子文件夹中才能找到 manifest.json。", Color1.红色)
        End If
        For i = 0 To m1.Data_MultiLevelFolderMods.Count - 1
            Print($"【套娃的模组文件夹】{m1.Data_MultiLevelFolderMods(i).UniqueID} 名称： {m1.Data_MultiLevelFolderMods(i).Name} 路径：{m1.Data_MultiLevelFolderMods(i).Path}", Color1.红色)
        Next

        If m1.Data_NoUniqueIDMods.Count > 0 Then
            Print($"【没有 UniqueID 的模组】可能会影响各种数据计算，建议作者补充上。 ", Color1.红色)
        End If
        For i = 0 To m1.Data_NoUniqueIDMods.Count - 1
            Print($"【没有 UniqueID 的模组】{m1.Data_NoUniqueIDMods(i)}", Color1.红色)
        Next

        For i = 0 To m1.Data_MeaninglessFolder.Count - 1
            Print($"【无意义的文件夹，请删除】{m1.Data_MeaninglessFolder(i)}", Color1.红色)
        Next

        For i = 0 To m1.Data_MeaninglessFile.Count - 1
            Print($"【无意义的文件，请删除】{m1.Data_MeaninglessFile(i)}", Color1.红色)
        Next

        Print($"程序结束", Color1.白色)
        Form1.UiButton98.Enabled = True
    End Sub

End Class
