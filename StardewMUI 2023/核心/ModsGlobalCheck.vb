
Imports Newtonsoft.Json.Linq
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports SMUI6.SearchItem
Imports System.Xml

Public Class ModsGlobalCheck

    Public Structure Data_NoContentPackType
        Public UniqueID As String
        Public TargetUniqueID As String
    End Structure
    Public Structure Data_NoDependencyType
        Public UniqueID As String
        Public TargetUniqueID As String
    End Structure
    Public Structure Data_DependencyVersionLowType
        Public UniqueID As String
        Public TargetUniqueID As String
        Public MinimumVersion As String
    End Structure
    Public Structure Data_NeedUpdateSmapiType
        Public Name As String
        Public UniqueID As String
        Public MinimumApiVersion As String
    End Structure
    Public Structure Data_MultiLevelFolderType
        Public Name As String
        Public UniqueID As String
        Public Path As String
    End Structure

    Public Data_Name As New List(Of String)
    Public Data_UniqueID As New List(Of String)
    Public Data_UniqueIDVerison As New List(Of String)
    Public Data_UniqueIDMinimumApiVersion As New List(Of String)

    Public Data_NoContentPackMods As New List(Of Data_NoContentPackType)
    Public Data_NoDependencyMods As New List(Of Data_NoDependencyType)
    Public Data_DependencyVersionLowMods As New List(Of Data_DependencyVersionLowType)
    Public Data_NeedUpdateSmapiMods As New List(Of Data_NeedUpdateSmapiType)
    Public Data_MultiLevelFolderMods As New List(Of Data_MultiLevelFolderType)
    Public Data_NoUniqueIDMods As New List(Of String)
    Public Data_MeaninglessFolder As New List(Of String)
    Public Data_MeaninglessFile As New List(Of String)

    Public Enum RealTimeOutputType
        MultiLine = 0
        Line = 1
    End Enum

    Public SetRealTimeOutputType As RealTimeOutputType = RealTimeOutputType.MultiLine

    Public Function StartCheck(ModsFolder As String, Optional ByRef RealTimeOutput As String = "", Optional SmapiVerison As String = "", Optional SystemPathConnector As String = "\") As String
        Try
            RealTimeOutput = ""
            If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                RealTimeOutput &= "Scanning manifest files. . ." & vbCrLf
            Else
                RealTimeOutput = "Scanning manifest files. . ."
            End If
            Application.DoEvents()
            Dim a1 As New SearchFile
            a1.SearchManifests(ModsFolder, True)
            If a1.ErrorString <> "" Then
                RealTimeOutput = a1.ErrorString
                Return a1.ErrorString
                Exit Function
            End If

            Dim ManifestsList As List(Of String) = a1.FileCollection

            If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                RealTimeOutput &= "Reading manifest data. . ." & vbCrLf
            Else
                RealTimeOutput = "Reading manifest data. . ."
            End If
            Application.DoEvents()
            For i = 0 To ManifestsList.Count - 1
                Dim a As String = ReadAllText(CombinePath(ModsFolder, ManifestsList(i)))
                Dim JsonData As JObject = JObject.Parse(a)
                Dim str1 As String = JsonData.GetValue("Name", StringComparison.OrdinalIgnoreCase)?.ToString
                If str1 <> "" Then
                    Data_Name.Add(str1)
                Else
                    Continue For
                End If
                Dim str2 As String = JsonData.GetValue("UniqueID", StringComparison.OrdinalIgnoreCase)?.ToString
                If str2 <> "" Then
                    Data_UniqueID.Add(str2)
                Else
                    Data_NoUniqueIDMods.Add(ManifestsList(i))
                End If
                Dim str3 As String = JsonData.GetValue("Version", StringComparison.OrdinalIgnoreCase)?.ToString
                If str3 <> "" Then
                    Data_UniqueIDVerison.Add(str3)
                Else
                    Data_UniqueIDVerison.Add("")
                End If
                Dim str4 As String = JsonData.GetValue("MinimumApiVersion", StringComparison.OrdinalIgnoreCase)?.ToString
                If str4 <> "" Then
                    Data_UniqueIDMinimumApiVersion.Add(str4)
                Else
                    Data_UniqueIDMinimumApiVersion.Add("")
                End If
                If ManifestsList(i).Split(SystemPathConnector).ToList.Count > 3 Then
                    Dim x1 As New Data_MultiLevelFolderType With {
                        .Name = Data_Name(i),
                        .UniqueID = Data_UniqueID(i),
                        .Path = IO.Path.GetDirectoryName(ManifestsList(i))
                    }
                    Data_MultiLevelFolderMods.Add(x1)
                End If
            Next


            If SmapiVerison <> "" Then
                If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                    RealTimeOutput &= "Comparing SMAPI versions. . ." & vbCrLf
                Else
                    RealTimeOutput = "Comparing SMAPI versions. . ."
                End If
                Application.DoEvents()
                For i = 0 To Data_UniqueID.Count - 1
                    If Data_UniqueIDMinimumApiVersion(i) <> "" Then
                        If 共享方法.CompareVersion(Data_UniqueIDMinimumApiVersion(i), SmapiVerison) > 0 Then
                            Dim x1 As New Data_NeedUpdateSmapiType With {
                                .Name = Data_Name(i),
                                .UniqueID = Data_UniqueID(i),
                                .MinimumApiVersion = Data_UniqueIDMinimumApiVersion(i)
                             }
                            Data_NeedUpdateSmapiMods.Add(x1)
                        End If
                    End If
                Next
            End If

            If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                RealTimeOutput &= "Checking dependencies. . ." & vbCrLf
            Else
                RealTimeOutput = "Checking dependencies. . ."
            End If
            Application.DoEvents()
            For i = 0 To ManifestsList.Count - 1
                Dim a As String = ReadAllText(CombinePath(ModsFolder, ManifestsList(i)))
                Dim JsonData As JObject = JObject.Parse(a)
                If JsonData.GetValue("Name", StringComparison.OrdinalIgnoreCase)?.ToString = "" Then Continue For

                Dim UniqueIDString As String = JsonData.GetValue("UniqueID", StringComparison.OrdinalIgnoreCase)?.ToString
                If UniqueIDString = "" Then Continue For

                If JsonData.GetValue("ContentPackFor", StringComparison.OrdinalIgnoreCase)?.ToString = "" Then GoTo jx1
                Dim ContentPackFor As JObject = JsonData.GetValue("ContentPackFor", StringComparison.OrdinalIgnoreCase)
                Dim ContentPackString As String = ContentPackFor.GetValue("UniqueID", StringComparison.OrdinalIgnoreCase)?.ToString
                If ContentPackString = "" Then GoTo jx1

                For i3 = 0 To Data_UniqueID.Count - 1
                    If Data_UniqueID(i3).Equals(ContentPackString, StringComparison.CurrentCultureIgnoreCase) Then GoTo jx1
                Next
                Dim x1 As New Data_NoContentPackType With {
                    .UniqueID = UniqueIDString,
                    .TargetUniqueID = ContentPackString
                }
                Data_NoContentPackMods.Add(x1)
jx1:
                Dim Dependencies As JArray = JsonData.GetValue("Dependencies", StringComparison.OrdinalIgnoreCase)
                If Dependencies Is Nothing Then Continue For
                For Each dependency As JObject In Dependencies
                    Dim str1 As String = dependency.GetValue("UniqueID", StringComparison.OrdinalIgnoreCase)?.ToString
                    If str1 = "" Then Continue For
                    Dim isRequired As Boolean = Boolean.Parse(If(dependency.GetValue("IsRequired", StringComparison.OrdinalIgnoreCase)?.ToString, "false"))
                    If Not isRequired Then Continue For

                    Dim dependencyFound As Boolean = False
                    For Each uid In Data_UniqueID
                        If String.Equals(uid, str1, StringComparison.CurrentCultureIgnoreCase) Then
                            dependencyFound = True
                            Exit For
                        End If
                    Next
                    If Not dependencyFound Then
                        Dim x2 As New Data_NoDependencyType With {
                                .UniqueID = JsonData.GetValue("UniqueID", StringComparison.OrdinalIgnoreCase)?.ToString,
                                .TargetUniqueID = str1
                            }
                        Data_NoDependencyMods.Add(x2)
                        Continue For
                    End If

                    For i7 = 0 To Data_UniqueID.Count - 1
                        If Data_UniqueID(i7).Equals(str1, StringComparison.CurrentCultureIgnoreCase) Then
                            Dim MinimumVersion As String = dependency.GetValue("MinimumVersion", StringComparison.OrdinalIgnoreCase)?.ToString
                            If MinimumVersion <> "" Then
                                If 共享方法.CompareVersion(Data_UniqueIDVerison(i7), MinimumVersion) < 0 Then
                                    Dim v1 As New Data_DependencyVersionLowType With {
                                        .UniqueID = str1,
                                        .TargetUniqueID = str1,
                                        .MinimumVersion = MinimumVersion
                                    }
                                    Data_DependencyVersionLowMods.Add(v1)
                                End If
                            Else
                                Exit For
                            End If
                            Exit For
                        End If
                    Next
jx3:
                Next
jx2:
            Next

            If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                RealTimeOutput &= "Scanning meaningless folders. . ." & vbCrLf
            Else
                RealTimeOutput = "Scanning meaningless folders. . ."
            End If
            Application.DoEvents()
            Dim p1 As List(Of String) = 共享方法.SearchFolderWithoutSub(ModsFolder)
            Dim p1s1 As New List(Of Boolean)
            For i = 0 To ManifestsList.Count - 1
                For i3 = 0 To p1.Count - 1
                    If InStr(ManifestsList(i3), p1(i3)) = 1 And ManifestsList(i3) <> p1(i3) Then
                        p1s1.Add(True)
                        GoTo jx5
                    Else
                        p1s1.Add(False)
                    End If
                Next
jx5:
            Next
            For i = 0 To p1s1.Count - 1
                If p1s1(i) = False Then
                    Data_MeaninglessFolder.Add(p1(i))
                End If
            Next

            If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                RealTimeOutput &= "Scanning meaningless files. . ." & vbCrLf
            Else
                RealTimeOutput = "Scanning meaningless files. . ."
            End If
            Application.DoEvents()
            Dim sf1 As New SearchFile
            sf1.SearchFiles(ModsFolder, False)
            If sf1.ErrorString <> "" Then
                If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                    RealTimeOutput &= "An error occurred while scanning meaningless files: " & sf1.ErrorString & vbCrLf
                Else
                    RealTimeOutput = "An error occurred while scanning meaningless files: " & sf1.ErrorString
                End If
                Application.DoEvents()
                GoTo ed1
            End If
            For i = 0 To sf1.FileCollection.Count - 1
                Data_MeaninglessFile.Add(sf1.FileCollection(i))
            Next
ed1:
            If SetRealTimeOutputType = RealTimeOutputType.MultiLine Then
                RealTimeOutput &= "Done."
            Else
                RealTimeOutput = "Done."
            End If
            Application.DoEvents()
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

End Class
