Public Class 搜索文件类
    Public 文件绝对路径集合 As List(Of String)
    Public 错误信息 As String

    Dim 设置_要扫描的路径 As String
    Dim 设置_是否搜索子目录 As Boolean
    Dim 设置_指定搜索扩展名 As String

    Public Sub 搜索文件(DirectoryToScan As String, ScanSubDirectories As Boolean, Optional ExtensionName As String = "*.*")
        错误信息 = ""
        文件绝对路径集合.Clear()
        Try
            设置_要扫描的路径 = DirectoryToScan
            设置_是否搜索子目录 = ScanSubDirectories
            设置_指定搜索扩展名 = ExtensionName
            GetAllFiles(DirectoryToScan)
        Catch ex As Exception
            错误信息 = ex.Message
        End Try
    End Sub

    Public Sub 搜索清单文件(DirectoryToScan As String, Optional ScanSubDirectories As Boolean = True)
        错误信息 = ""
        文件绝对路径集合.Clear()
        Try
            设置_要扫描的路径 = DirectoryToScan
            设置_是否搜索子目录 = ScanSubDirectories
            GetAllManifestFiles(DirectoryToScan)
        Catch ex As Exception
            错误信息 = ex.Message
        End Try
    End Sub

    Private Sub GetAllFiles(strDirect As String)
        Dim mFileInfo As System.IO.FileInfo
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(strDirect)
        For Each mFileInfo In mDirInfo.GetFiles(设置_指定搜索扩展名)
            文件绝对路径集合.Add(mFileInfo.FullName)
        Next
        If 设置_是否搜索子目录 = True Then
            For Each mDir In mDirInfo.GetDirectories
                GetAllFiles(mDir.FullName)
            Next
        End If
    End Sub

    Private Sub GetAllManifestFiles(strDirect As String)
        Dim mFileInfo As System.IO.FileInfo
        Dim mDir As System.IO.DirectoryInfo
        Dim mDirInfo As New System.IO.DirectoryInfo(strDirect)
        For Each mFileInfo In mDirInfo.GetFiles("manifest.json")
            文件绝对路径集合.Add(mFileInfo.FullName)
            Exit Sub
        Next
        If 设置_是否搜索子目录 = True Then
            For Each mDir In mDirInfo.GetDirectories
                GetAllManifestFiles(mDir.FullName)
            Next
        End If
    End Sub

End Class
