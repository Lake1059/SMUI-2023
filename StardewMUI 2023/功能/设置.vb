﻿
Imports System.Drawing.Text
Imports System.Reflection

Public Class 设置

    Public Shared Property 全局设置数据 As New Dictionary(Of String, String)

    Public Shared Sub 初始化设置相关操作()
        AddHandler Form1.UiTabControlMenu2.SelectedIndexChanged,
           Sub(sender, e)
               If Form1.UiTabControlMenu2.SelectedTab Is Form1.TabPage19 Then
                   If Form1.UiComboBox5.Items.Count < 2 Then
                       Dim installedFonts As New InstalledFontCollection()
                       Dim fontsArray() As FontFamily = installedFonts.Families
                       For Each font As FontFamily In fontsArray
                           Form1.UiComboBox5.Items.Add(font.Name)
                       Next
                   End If
               End If
           End Sub
        AddHandler Form1.UiComboBox5.SelectedIndexChanged,
            Sub(sender, e)
                Form1.Label5.Font = New Font(Form1.UiComboBox5.Text, Form1.Label5.Font.Size)
                Form1.Label27.Font = New Font(Form1.UiComboBox5.Text, Form1.Label27.Font.Size)
                Form1.Label29.Font = New Font(Form1.UiComboBox5.Text, Form1.Label29.Font.Size)
                Form1.Label28.Font = New Font(Form1.UiComboBox5.Text, Form1.Label28.Font.Size)
                Form1.Label31.Font = New Font(Form1.UiComboBox5.Text, Form1.Label31.Font.Size)
                Form1.Label30.Font = New Font(Form1.UiComboBox5.Text, Form1.Label30.Font.Size)
            End Sub
        AddHandler Form1.UiButton34.Click, AddressOf 保存路径设置
        AddHandler Form1.UiButton28.Click, AddressOf 保存语言和服务器设置
        AddHandler Form1.UiButton32.Click, AddressOf 保存网络API设置
        AddHandler Form1.UiButton31.Click, AddressOf 保存启动项设置
        AddHandler Form1.UiButton35.Click, AddressOf 保存数值和开关设置
        AddHandler Form1.UiButton37.Click, AddressOf 保存字体设置
        AddHandler Form1.UiButton38.Click, AddressOf 保存隐私设置
    End Sub

    Public Shared Sub 启动时加载设置()
        初始化设置相关操作()
        启动时检查用户文件夹()
        键值对IO操作.读取键值对文本到字典(全局设置数据, My.Resources.默认设置文件)
        If FileIO.FileSystem.FileExists(设置文件存储路径) Then
            Dim a As New Dictionary(Of String, String)
            Dim e1 As String = 键值对IO操作.读取键值对文件到字典(a, 设置文件存储路径)
            If e1 <> "" Then
                DebugPrint("读取本地设置文件时故障：" & e1, Color.OrangeRed, True)
            Else
                For Each kvp As KeyValuePair(Of String, String) In a
                    全局设置数据(kvp.Key) = kvp.Value
                Next
                DebugPrint("已加载设置文件", Form1.ForeColor)
            End If
        Else
            DebugPrint("全新启动，创建设置文件", Form1.ForeColor)
            键值对IO操作.读取键值对文本到字典(全局设置数据, My.Resources.默认设置文件)
            Select Case System.Globalization.CultureInfo.CurrentCulture.Name
                Case "zh-CN"
                    If 全局设置数据.ContainsKey("DisplayLanguage") Then 全局设置数据("DisplayLanguage") = "Default"
                    If 全局设置数据.ContainsKey("NewsLanguage") Then 全局设置数据("NewsLanguage") = "简体中文"
                    If 全局设置数据.ContainsKey("NewsSever") Then 全局设置数据("NewsSever") = "Gitee"
                    If 全局设置数据.ContainsKey("UpdateSever") Then 全局设置数据("UpdateSever") = "Gitee"
                Case Else
                    If 全局设置数据.ContainsKey("DisplayLanguage") Then 全局设置数据("DisplayLanguage") = "Default"
                    If 全局设置数据.ContainsKey("NewsLanguage") Then 全局设置数据("NewsLanguage") = "English"
                    If 全局设置数据.ContainsKey("NewsSever") Then 全局设置数据("NewsSever") = "GitHub"
                    If 全局设置数据.ContainsKey("UpdateSever") Then 全局设置数据("UpdateSever") = "GitHub"
            End Select
            键值对IO操作.从字典键值对写入文件(全局设置数据, 设置文件存储路径)
        End If
        If 全局设置数据("SaveUserWindowSize") = "True" Then
            Form1.Width = 全局设置数据("MainWindowWidth")
            Form1.Height = 全局设置数据("MainWindowHeight")
        End If
        刷新设置显示()
    End Sub

    Public Shared Sub 启动时检查用户文件夹()
        If FileIO.FileSystem.DirectoryExists(用户数据文件夹路径) = False Then FileIO.FileSystem.CreateDirectory(用户数据文件夹路径)
        If FileIO.FileSystem.DirectoryExists(DLC文件夹路径) = False Then FileIO.FileSystem.CreateDirectory(DLC文件夹路径)
        If FileIO.FileSystem.DirectoryExists(插件文件夹路径) = False Then FileIO.FileSystem.CreateDirectory(插件文件夹路径)
        If FileIO.FileSystem.DirectoryExists(浏览器缓存路径) = False Then FileIO.FileSystem.CreateDirectory(浏览器缓存路径)
        If FileIO.FileSystem.DirectoryExists(自定义语言包路径) = False Then FileIO.FileSystem.CreateDirectory(自定义语言包路径)
    End Sub

    Public Shared ReadOnly 用户数据文件夹路径 As String = Application.StartupPath & "\UserData"

    Public Shared ReadOnly 设置文件存储路径 As String = Application.StartupPath & "\UserData\Settings"
    Public Shared ReadOnly 安装程序更新下载文件路径 As String = Application.StartupPath & "\UserData\SMUI 6 Installer.exe"

    Public Shared ReadOnly DLC文件夹路径 As String = Application.StartupPath & "\UserData\DLC"
    Public Shared ReadOnly 插件文件夹路径 As String = Application.StartupPath & "\UserData\Plugin"
    Public Shared ReadOnly 浏览器缓存路径 As String = Application.StartupPath & "\UserData\WebCache"
    Public Shared ReadOnly 自定义语言包路径 As String = Application.StartupPath & "\UserData\Language"


    Public Shared Sub 刷新设置显示()
        Form1.UiTextBox2.Text = 全局设置数据("StardewValleyGamePath")
        Form1.UiTextBox3.Text = 全局设置数据("LocalRepositoryPath")
        Form1.UiTextBox4.Text = 全局设置数据("StardewValleyGameBackupPath")
        Form1.UiTextBox7.Text = 全局设置数据("VisualStudioCodeEXE")
        Form1.UiTextBox8.Text = 全局设置数据("VisualStudioEXE")

        Form1.UiComboBox4.Text = 全局设置数据("DisplayLanguage")
        Form1.UiComboBox1.Text = 全局设置数据("NewsLanguage")
        Form1.UiComboBox2.Text = 全局设置数据("NewsSever")
        Form1.UiComboBox3.Text = 全局设置数据("UpdateSever")
        Form1.UiComboBox7.Text = 全局设置数据("AlternativeUpdateSever")

        Form1.UiTextBox9.Text = 全局设置数据("NexusAPI")
        Form1.UiTextBox11.Text = 全局设置数据("GiteeToken")
        Form1.UiTextBox10.Text = 全局设置数据("GithubToken")

        Select Case 全局设置数据("LaunchSelection")
            Case "1"
                Form1.UiRadioButton1.Checked = True
                Form1.UiRadioButton2.Checked = False
            Case "2"
                Form1.UiRadioButton1.Checked = False
                Form1.UiRadioButton2.Checked = True
        End Select
        Form1.UiTextBox12.Text = 全局设置数据("LaunchParameters")
        Form1.UiTextBox13.Text = 全局设置数据("CustomLaunchCMD")

        Form1.UiCheckBox1.Checked = 全局设置数据("SaveUserWindowSize")
        Form1.UiCheckBox7.Checked = 全局设置数据("AutoGetNews")
        Form1.UiCheckBox10.Checked = 全局设置数据("SaveNewsInTodayUse")
        Form1.UiCheckBox9.Checked = 全局设置数据("AutoCheckUpdate")
        Form1.UiCheckBox8.Checked = 全局设置数据("AutoStartDownloadUpdate")
        Form1.UiCheckBox2.Checked = 全局设置数据("AdminDragDropPatch")
        Form1.UiCheckBox4.Checked = 全局设置数据("AutoSelectFirstNexusDownloadSever")
        Form1.UiCheckBox5.Checked = 全局设置数据("AutoConvertWebpToPng")
        Form1.UiCheckBox6.Checked = 全局设置数据("SendDeletedDataToRecycleBin")

        Form1.UiComboBox5.Text = 全局设置数据("FontName")

        Select Case 全局设置数据("UploadUserInfo")
            Case "True"
                Form1.UiRadioButton3.Checked = True
                Form1.UiRadioButton4.Checked = False
            Case "False"
                Form1.UiRadioButton3.Checked = False
                Form1.UiRadioButton4.Checked = True
        End Select
        Form1.UiCheckBox3.Checked = 全局设置数据("UploadWindowsVer")
        Form1.UiCheckBox11.Checked = 全局设置数据("UploadCPU0")
        Form1.UiCheckBox14.Checked = 全局设置数据("UploadRAM")
        Form1.UiCheckBox15.Checked = 全局设置数据("UploadCDiskCapacity")
        Form1.UiCheckBox12.Checked = 全局设置数据("UploadGPU")
        Form1.UiCheckBox13.Checked = 全局设置数据("UploadScreen")
    End Sub

    Public Shared Sub 保存路径设置()
        全局设置数据("StardewValleyGamePath") = Form1.UiTextBox2.Text
        全局设置数据("LocalRepositoryPath") = Form1.UiTextBox3.Text
        全局设置数据("StardewValleyGameBackupPath") = Form1.UiTextBox4.Text
        全局设置数据("VisualStudioCodeEXE") = Form1.UiTextBox7.Text
        全局设置数据("VisualStudioEXE") = Form1.UiTextBox8.Text
    End Sub

    Public Shared Sub 保存语言和服务器设置()
        全局设置数据("DisplayLanguage") = Form1.UiComboBox4.Text
        全局设置数据("NewsLanguage") = Form1.UiComboBox1.Text
        全局设置数据("NewsSever") = Form1.UiComboBox2.Text
        全局设置数据("UpdateSever") = Form1.UiComboBox3.Text
        全局设置数据("AlternativeUpdateSever") = Form1.UiComboBox7.Text
    End Sub

    Public Shared Sub 保存网络API设置()
        全局设置数据("NexusAPI") = Form1.UiTextBox9.Text
        全局设置数据("GiteeToken") = Form1.UiTextBox11.Text
        全局设置数据("GithubToken") = Form1.UiTextBox10.Text
    End Sub

    Public Shared Sub 保存启动项设置()
        If Form1.UiRadioButton1.Checked Then
            全局设置数据("LaunchSelection") = "1"
        Else
            全局设置数据("LaunchSelection") = "2"
        End If
    End Sub

    Public Shared Sub 保存数值和开关设置()
        全局设置数据("SaveUserWindowSize") = Form1.UiCheckBox1.Checked
        全局设置数据("AutoGetNews") = Form1.UiCheckBox7.Checked
        全局设置数据("SaveNewsInTodayUse") = Form1.UiCheckBox10.Checked
        全局设置数据("AutoCheckUpdate") = Form1.UiCheckBox9.Checked
        全局设置数据("AutoStartDownloadUpdate") = Form1.UiCheckBox8.Checked
        全局设置数据("AdminDragDropPatch") = Form1.UiCheckBox2.Checked
        全局设置数据("AutoSelectFirstNexusDownloadSever") = Form1.UiCheckBox4.Checked
        全局设置数据("AutoConvertWebpToPng") = Form1.UiCheckBox5.Checked
        全局设置数据("SendDeletedDataToRecycleBin") = Form1.UiCheckBox6.Checked
    End Sub

    Public Shared Sub 保存字体设置()
        全局设置数据("FontName") = Form1.UiComboBox5.Text
        刷新字体显示(Form1)
    End Sub

    Private Shared Sub 刷新字体显示(parentControl As Control)
        For Each ctrl As Control In parentControl.Controls
            刷新字体显示_检查属性(ctrl)
            If ctrl.HasChildren Then 刷新字体显示(ctrl)
        Next
        管理模组的菜单.设置字体()
    End Sub

    Private Shared Sub 刷新字体显示_检查属性(control As Control)
        Dim controlType As Type = control.GetType()
        Dim propInfo As PropertyInfo = controlType.GetProperty("Font")
        If propInfo IsNot Nothing Then control.Font = New Font(全局设置数据("FontName"), control.Font.Size)
    End Sub

    Public Shared Sub 保存隐私设置()
        If Form1.UiRadioButton3.Checked Then
            全局设置数据("UploadUserInfo") = "True"
        Else
            全局设置数据("UploadUserInfo") = "False"
        End If
        全局设置数据("UploadWindowsVer") = Form1.UiCheckBox3.Checked
        全局设置数据("UploadCPU0") = Form1.UiCheckBox11.Checked
        全局设置数据("UploadRAM") = Form1.UiCheckBox14.Checked
        全局设置数据("UploadCDiskCapacity") = Form1.UiCheckBox15.Checked
        全局设置数据("UploadGPU") = Form1.UiCheckBox12.Checked
        全局设置数据("UploadScreen") = Form1.UiCheckBox13.Checked
    End Sub

End Class
