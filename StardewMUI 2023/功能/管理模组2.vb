

Public Class 管理模组2



    Public Shared Function 扫描子库(路径 As String) As List(Of String)
        Dim mDir As IO.DirectoryInfo
        Dim mDirInfo As New IO.DirectoryInfo(路径)
        Dim a As New List(Of String)
        For Each mDir In mDirInfo.GetDirectories
            If InStrRev(mDir.Name, ".") = 1 Then Continue For
            a.Add(mDir.Name)
        Next
        Return a
    End Function


    Public Shared Function 检查并返回当前选择分类路径(Optional 显示不可用对话框 As Boolean = True) As String
        Dim a As String = 检查并返回当前所选子库路径(显示不可用对话框)
        If a = "" Then
            Return "" : Exit Function
        Else
            If Form1.ListView1.SelectedItems.Count = 1 Then
                Return a & "\" & Form1.ListView1.Items.Item(Form1.ListView1.SelectedIndices(0)).Text
            Else
                If 显示不可用对话框 = False Then Return "" : Exit Function
                Dim d1 As New 多项单选对话框("", {"OK"}, "当前所选分类不可用")
                d1.ShowDialog(Form1)
                Return ""
            End If
        End If
    End Function

    Public Shared Function 检查并返回当前所选子库路径(Optional 显示不可用对话框 As Boolean = True) As String
        If FileIO.FileSystem.DirectoryExists(设置.全局设置数据("LocalRepositoryPath")) = False Then
            If 显示不可用对话框 = False Then Return "" : Exit Function
            Dim d1 As New 多项单选对话框("", {"OK"}, "当前数据仓库不可用")
            d1.ShowDialog(Form1)
            Return ""
            Exit Function
        End If
        If 设置.全局设置数据("LastUsedSubLibraryName") = "" Then
            If 显示不可用对话框 = False Then Return "" : Exit Function
            Dim d1 As New 多项单选对话框("", {"OK"}, "当前选择的数据子库不可用")
            d1.ShowDialog(Form1)
            Return ""
            Exit Function
        End If
        Return 设置.全局设置数据("LocalRepositoryPath") & "\" & 设置.全局设置数据("LastUsedSubLibraryName")
    End Function
    Public Shared Function 检查并返回当前模组数据仓库路径(Optional 显示不可用对话框 As Boolean = True) As String
        If FileIO.FileSystem.DirectoryExists(设置.全局设置数据("LocalRepositoryPath")) = False Then
            If 显示不可用对话框 = False Then Return "" : Exit Function
            Dim d1 As New 多项单选对话框("", {"OK"}, "当前数据仓库不可用")
            d1.ShowDialog(Form1)
            Return ""
        Else
            Return 设置.全局设置数据("LocalRepositoryPath")
        End If
    End Function
End Class
