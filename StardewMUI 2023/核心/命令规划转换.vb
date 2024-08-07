
Public Class 命令规划转换

    Public Shared Function 将安装命令转换到安装规划(安装命令文本 As String) As String
        Dim a As String = ""
        Dim CORE_CLASS_Str As String = ""
        Dim x As List(Of String) = 安装命令文本.Split(vbCrLf).ToList
        For i = 0 To x.Count - 1
            Select Case x(i)
                Case "CDCD", "CDCP"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CD-D-MODS=" & x(i + 1)
                    i += 1
                Case "CDMAD"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CD-D-MODS-COVER=" & x(i + 1)
                    i += 1
                Case "CDGCD"
                    If i = x.Count - 1 Or i = x.Count - 2 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CD-D-ROOT=" & x(i + 1) & "|" & x(i + 2)
                    i += 2
                Case "CDCC", "CDVD"
                    a &= If(a = "", "", vbCrLf) & "CD-D-CONTENT=0"
                Case "CDGCF"
                    If i = x.Count - 1 Or i = x.Count - 2 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CD-F=False|True|False|" & x(i + 1) & "|" & x(i + 2)
                    i += 2
                Case "CDGCF-SHA"
                    If i = x.Count - 1 Or i = x.Count - 2 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CD-F=False|True|True|" & x(i + 1) & "|" & x(i + 2)
                    i += 2
                Case "CDGRF"
                    If i = x.Count - 1 Or i = x.Count - 2 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CD-F=True|True|True|" & x(i + 1) & "|" & x(i + 2)
                    i += 2
                Case "CDF"
                    If i = x.Count - 1 Or i = x.Count - 2 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CD-F=True|False|False|" & x(i + 1) & "|" & x(i + 2)
                    i += 2
                Case "RQ-D-IN"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CR-Check-EXIST=Install|Folder|True|" & x(i + 1)
                    i += 1
                Case "RQ-D-UN"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CR-Check-EXIST=UnInstall|Folder|True|" & x(i + 1)
                    i += 1
                Case "RQ-F-IN"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CR-Check-EXIST=Install|File|True|" & x(i + 1)
                    i += 1
                Case "RQ-F-UN"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CR-Check-EXIST=UnInstall|File|True|" & x(i + 1)
                    i += 1

                Case "CR-UN-OFF"
                    a &= If(a = "", "", vbCrLf) & "CR-UN=ERROR"
                Case "CR-UN-CANCEL"
                    a &= If(a = "", "", vbCrLf) & "CR-UN=CANCEL"

                Case "CR-CG-DB"
                    CORE_CLASS_Str &= If(CORE_CLASS_Str = "", "CG-DB", "|CG-DB")
                Case "CR-CDS-CDCD-AMD"
                    CORE_CLASS_Str &= If(CORE_CLASS_Str = "", "Mods-AMD", "|Mods-AMD")
                Case "CR-FILE-ALLOW-ALL"
                    CORE_CLASS_Str &= If(CORE_CLASS_Str = "", "FILE-ALLOW-ALL", "|FILE-ALLOW-ALL")

            End Select
        Next

        If CORE_CLASS_Str = "" Then
            Return a
        Else
            Return "CORE-CLASS=" & CORE_CLASS_Str & vbCrLf & a
        End If

    End Function

End Class
