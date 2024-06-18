Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Microsoft.VisualBasic.FileIO.FileSystem

Public Class SearchItem

    Public Property ST_NotCaseUpperAndLowerLetters As Boolean = False
    Public Property ST_NotCaseCHS_ENG_Symbol As Boolean = False
    Public Property ST_SingleCharacterFuzzySearch As Boolean = False

    ''' <summary>
    ''' Item full path!
    ''' </summary> 
    Public Results As New List(Of String)

    Public Enum SearchType
        ItemName = 1
        NameKey = 2
        AuthorKey = 3
        UniqueID = 4
        ContentPakForAndDependencies = 5
        IncludedFolders = 6
        NexusID = 7
        ModdropID = 8
    End Enum

    Public Function StartSearch(ByVal FolderOneLevelAboveCategoryLevel As String, ByVal SearchWhat As String, ByVal yourSearchType As SearchType) As String
        Try
            Dim mDir As IO.DirectoryInfo
            Dim mDirInfo As New IO.DirectoryInfo(FolderOneLevelAboveCategoryLevel)
            For Each mDir In mDirInfo.GetDirectories
                Dim mDir2 As IO.DirectoryInfo
                Dim mDirInfo2 As New IO.DirectoryInfo(mDir.FullName)
                For Each mDir2 In mDirInfo2.GetDirectories

                    Select Case yourSearchType
                        Case SearchType.ItemName
                            If DetermineWhetherToAddToOutput(mDir2.Name, SearchWhat) = True Then
                                Results.Add(mDir2.FullName)
                            End If
                        Case SearchType.NameKey
                            Dim ManifestFile As New SearchFile
                            ManifestFile.SearchManifests(mDir2.FullName)
                            For i = 0 To ManifestFile.FileCollection.Count - 1
                                Dim a As String = My.Computer.FileSystem.ReadAllText(CombinePath(mDir2.FullName, ManifestFile.FileCollection(i)))
                                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)
                                If JsonData.item("Name") IsNot Nothing Then
                                    If DetermineWhetherToAddToOutput(JsonData.item("Name").ToString, SearchWhat) = True Then
                                        Results.Add(mDir2.FullName)
                                        Exit For
                                    End If
                                End If
                            Next

                        Case SearchType.AuthorKey
                            Dim ManifestFile As New SearchFile
                            ManifestFile.SearchManifests(mDir2.FullName)
                            For i = 0 To ManifestFile.FileCollection.Count - 1
                                Dim a As String = My.Computer.FileSystem.ReadAllText(CombinePath(mDir2.FullName, ManifestFile.FileCollection(i)))
                                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)
                                If JsonData.item("Author") IsNot Nothing Then
                                    If DetermineWhetherToAddToOutput(JsonData.item("Author").ToString, SearchWhat) = True Then
                                        Results.Add(mDir2.FullName)
                                        Exit For
                                    End If
                                End If
                            Next

                        Case SearchType.UniqueID
                            Dim ManifestFile As New SearchFile
                            ManifestFile.SearchManifests(mDir2.FullName)
                            For i = 0 To ManifestFile.FileCollection.Count - 1
                                Dim a As String = My.Computer.FileSystem.ReadAllText(CombinePath(mDir2.FullName, ManifestFile.FileCollection(i)))
                                Dim JsonData As Object = CType(JsonConvert.DeserializeObject(a), JObject)
                                If JsonData.item("UniqueID") IsNot Nothing Then
                                    If DetermineWhetherToAddToOutput(JsonData.item("UniqueID").ToString, SearchWhat) = True Then
                                        Results.Add(mDir2.FullName)
                                        Exit For
                                    End If
                                End If
                            Next

                        Case SearchType.ContentPakForAndDependencies
                            Dim a As New 项信息读取类
                            a.读取项信息(mDir2.FullName, New 公共对象.项数据计算类型结构 With {.内容包依赖 = True, .其他依赖项 = True})
                            For Each b In a.内容包依赖
                                If DetermineWhetherToAddToOutput(b.Key, SearchWhat) = True Then
                                    Results.Add(mDir2.FullName)
                                    GoTo jx1
                                End If
                            Next
                            For Each b In a.其他依赖项
                                If DetermineWhetherToAddToOutput(b.Key, SearchWhat) = True Then
                                    Results.Add(mDir2.FullName)
                                    GoTo jx1
                                End If
                            Next
jx1:
                        Case SearchType.IncludedFolders
                            Dim mDir3 As IO.DirectoryInfo
                            Dim mDirInfo3 As New IO.DirectoryInfo(mDir2.FullName)
                            For Each mDir3 In mDirInfo3.GetDirectories
                                If DetermineWhetherToAddToOutput(mDir3.Name, SearchWhat) = True Then
                                    Results.Add(mDir2.FullName)
                                    Exit For
                                End If
                            Next

                        Case SearchType.NexusID
                            Dim a As New 项信息读取类
                            a.读取项信息(mDir2.FullName, New 公共对象.项数据计算类型结构 With {.更新键 = True})
                            For i = 0 To a.NexusID.Count - 1
                                If DetermineWhetherToAddToOutput(a.NexusID(i), SearchWhat) = True Then
                                    Results.Add(mDir2.FullName)
                                    Exit For
                                End If
                            Next

                        Case SearchType.ModdropID
                            Dim a As New 项信息读取类
                            a.读取项信息(mDir2.FullName, New 公共对象.项数据计算类型结构 With {.更新键 = True})
                            For i = 0 To a.ModDrop.Count - 1
                                If DetermineWhetherToAddToOutput(a.ModDrop(i), SearchWhat) = True Then
                                    Results.Add(mDir2.FullName)
                                    Exit For
                                End If
                            Next

                    End Select

                Next
            Next
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try


    End Function

    Private Function DetermineWhetherToAddToOutput(ByVal StringComparison As String, ByVal SearchWhat As String) As Boolean
        If InStr(StringComparison, SearchWhat) > 0 Then
            Return True : Exit Function
        End If
        If ST_NotCaseUpperAndLowerLetters = True Then
            If CompareNotCaseUpperAndLowerLetters(StringComparison, SearchWhat) = True Then
                Return True : Exit Function
            End If
        End If
        If ST_NotCaseCHS_ENG_Symbol = True Then
            If CompareNotCaseCHS_ENG_Symbol(StringComparison, SearchWhat) = True Then
                Return True : Exit Function
            End If
        End If
        If ST_SingleCharacterFuzzySearch = True Then
            If CompareSingleCharacterFuzzySearch(StringComparison, SearchWhat) = True Then
                Return True : Exit Function
            End If
        End If
        Return False
    End Function

    Private Shared Function CompareNotCaseUpperAndLowerLetters(ByVal StringComparison As String, ByVal SearchWhat As String) As Boolean
        If InStr(StringComparison.ToLower, SearchWhat.ToLower) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Shared Function CompareNotCaseCHS_ENG_Symbol(ByVal StringComparison As String, ByVal SearchWhat As String) As Boolean
        Dim a As String = StringComparison.Replace("，", ",").Replace("。", ".")
        Dim b As String = SearchWhat.Replace("，", ",").Replace("。", ".")

        If InStr(a, b) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function CompareSingleCharacterFuzzySearch(ByVal StringComparison As String, ByVal SearchWhat As String) As Boolean
        Dim a As String
        Dim b As Char()

        If ST_NotCaseUpperAndLowerLetters = True Then
            a = StringComparison.ToLower
            b = SearchWhat.ToLower.ToCharArray
        Else
            a = StringComparison
            b = SearchWhat.ToCharArray
        End If

        For i = 0 To b.Length - 1
            If InStr(a, b(i)) = 0 Then
                Return False
                Exit Function
            End If
        Next
        Return True
    End Function

    Public Class SearchFile
        Public FileCollection As New List(Of String)
        Public ErrorString As String

        Dim _DirectoryToScan As String
        Dim _ScanSubDirectories As Boolean
        Dim _ExtensionName As String

        Public Sub SearchFiles(DirectoryToScan As String, ScanSubDirectories As Boolean, Optional ExtensionName As String = "*.*")
            ErrorString = ""
            FileCollection.Clear()
            Try
                _DirectoryToScan = DirectoryToScan
                _ScanSubDirectories = ScanSubDirectories
                _ExtensionName = ExtensionName
                GetAllFiles(DirectoryToScan)
            Catch ex As Exception
                ErrorString = ex.Message
            End Try
        End Sub

        Public Sub SearchManifests(DirectoryToScan As String, Optional ScanSubDirectories As Boolean = True)
            ErrorString = ""
            FileCollection.Clear()
            Try
                _DirectoryToScan = DirectoryToScan
                _ScanSubDirectories = ScanSubDirectories
                GetAllManifestFiles(DirectoryToScan)
            Catch ex As Exception
                ErrorString = ex.Message
            End Try
        End Sub

        Private Sub GetAllFiles(strDirect As String)
            Dim mFileInfo As System.IO.FileInfo
            Dim mDir As System.IO.DirectoryInfo
            Dim mDirInfo As New System.IO.DirectoryInfo(strDirect)
            For Each mFileInfo In mDirInfo.GetFiles(_ExtensionName)
                Dim a As String = mFileInfo.FullName
                FileCollection.Add(Mid(Replace(mFileInfo.FullName, _DirectoryToScan, ""), 2))
            Next
            If _ScanSubDirectories = True Then
                For Each mDir In mDirInfo.GetDirectories
                    GetAllFiles(mDir.FullName)
                Next
            End If
        End Sub

        Private Sub GetAllManifestFiles(ByVal strDirect As String)
            Dim mFileInfo As System.IO.FileInfo
            Dim mDir As System.IO.DirectoryInfo
            Dim mDirInfo As New System.IO.DirectoryInfo(strDirect)
            For Each mFileInfo In mDirInfo.GetFiles("manifest.json")
                Dim a As String = mFileInfo.FullName
                FileCollection.Add(Mid(Replace(mFileInfo.FullName, _DirectoryToScan, ""), 2))
                Exit Sub
            Next
            If _ScanSubDirectories = True Then
                For Each mDir In mDirInfo.GetDirectories
                    GetAllManifestFiles(mDir.FullName)
                Next
            End If
        End Sub
    End Class

End Class
