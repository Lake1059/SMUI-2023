
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
                    a &= If(a = "", "", vbCrLf) & "CD-F-ADD=" & x(i + 1) & "|" & x(i + 2)
                    i += 2
                Case "CDGCF-SHA"
                    If i = x.Count - 1 Or i = x.Count - 2 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CD-F-ADD-SHA=" & x(i + 1) & "|" & x(i + 2)
                    i += 2
                Case "CDGRF"
                    If i = x.Count - 1 Or i = x.Count - 2 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CD-F-REP=" & x(i + 1) & "|" & x(i + 2)
                    i += 2
                Case "CDF"
                    If i = x.Count - 1 Or i = x.Count - 2 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CD-F-NULL=" & x(i + 1) & "|" & x(i + 2)
                    i += 2
                Case "RQ-D-IN"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CR-IN-D-CHECK=True|" & x(i + 1)
                    i += 1
                Case "RQ-D-UN"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CR-UN-D-CHECK=True|" & x(i + 1)
                    i += 1
                Case "RQ-F-IN"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CR-IN-F-CHECK=True|" & x(i + 1)
                    i += 1
                Case "RQ-F-UN"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CR-UN-F-CHECK=True|" & x(i + 1)
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
                Case "CR-APP-SHELL-IN"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CR-IN-SHELL=" & x(i + 1) & "|"
                    i += 1
                Case "CR-APP-SHELL-P-IN"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CR-IN-SHELL=" & x(i + 1) & "|" & x(i + 2)
                    i += 2
                Case "CR-APP-SHELL-UN"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CR-UN-SHELL=" & x(i + 1) & "|"
                    i += 1
                Case "CR-APP-SHELL-P-UN"
                    If i = x.Count - 1 Then Exit For
                    a &= If(a = "", "", vbCrLf) & "CR-UN-SHELL=" & x(i + 1) & "|" & x(i + 2)
                    i += 2

                Case "SUB D-EX-IN"
                    Dim s1 As String = "True"
                    Dim ie As Integer = i + 1
                    For i3 = i + 1 To x.Count - 1
                        ie = i3
                        If x(i3) = "END SUB" Then Exit For
                        s1 &= "|" & x(i3)
                    Next
                    a &= "CR-IN-D-CHECK=" & s1
                    i = ie
            End Select
        Next

        If CORE_CLASS_Str = "" Then
            Return a
        Else
            Return "CORE-CLASS=" & CORE_CLASS_Str & vbCrLf & a
        End If

    End Function


    Public Shared Function 将安装规划转换到安装命令(安装规划文本 As String) As String




    End Function

End Class
