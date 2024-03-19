Imports System.IO
Imports SMUI6.公共对象

Public Class 配置队列的规划编辑

    Public Shared Property 来自_选择文件夹_所选的文件夹 As String


    Public Shared Sub 匹配到_复制文件夹到Mods()
        Dim a As New Form编辑规划_选择文件夹 With {.Text = 配置队列.规划显示名称字典(任务队列操作类型枚举.复制文件夹到Mods)}
        For Each mDir As DirectoryInfo In New DirectoryInfo(配置队列.正在编辑规划的项路径).GetDirectories
            If FileIO.FileSystem.FileExists(Path.Combine(mDir.FullName, "manifest.json")) Then
                a.UiListBox1.Items.Add(mDir.Name)
            End If
        Next
        If Form1.ListView7.SelectedItems(0).SubItems(1).Text <> "" Then
            If a.UiListBox1.Items.Contains(Form1.ListView7.SelectedItems(0).SubItems(1).Text) Then
                a.UiListBox1.SelectedIndex = a.UiListBox1.Items.IndexOf(Form1.ListView7.SelectedItems(0).SubItems(1).Text)
            End If
        End If
        显示模式窗体(a, Form1)
        If 来自_选择文件夹_所选的文件夹 <> "" Then
            Form1.ListView7.SelectedItems(0).SubItems(1).Text = 来自_选择文件夹_所选的文件夹
        End If
        a.Dispose()
    End Sub

    Public Shared Sub 匹配到_覆盖文件夹到Mods()


    End Sub

    Public Shared Sub 匹配到_复制文件夹()

    End Sub

    Public Shared Sub 匹配到_覆盖Content()

    End Sub

    Public Shared Sub 匹配到_新增文件()

    End Sub

    Public Shared Sub 匹配到_新增文件并验证()

    End Sub

    Public Shared Sub 匹配到_替换文件()

    End Sub

    Public Shared Sub 匹配到_替换文件且无检测()

    End Sub

    Public Shared Sub 匹配到_安装时检查文件夹的存在()

    End Sub

    Public Shared Sub 匹配到_卸载时检查文件夹的存在()

    End Sub

    Public Shared Sub 匹配到_安装时检查文件的存在()

    End Sub

    Public Shared Sub 匹配到_卸载时检查文件的存在()

    End Sub

    Public Shared Sub 匹配到_安装时检查Mods中已安装模组的版本()

    End Sub

    Public Shared Sub 匹配到_卸载时取消操作()

    End Sub

    Public Shared Sub 匹配到_安装时运行可执行文件()

    End Sub

    Public Shared Sub 匹配到_卸载时运行可执行文件()

    End Sub

    Public Shared Sub 匹配到_安装时弹窗()

    End Sub

    Public Shared Sub 匹配到_卸载时弹窗()

    End Sub

    Public Shared Sub 匹配到_声明各种核心功能的启停()

    End Sub


End Class
