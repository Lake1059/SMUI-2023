
Imports System.IO
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports System.Windows.Forms
Imports SMUI6
Imports SMUI6.����Ϣ��ȡ��

Public Class Entry

    Public Shared Sub Entry()
        AddHandler ������ӹ滮_�˵���_�ļ��и߼���װ.Click, Sub()
                                                 SMUI6.���ö��еĲ˵�.����¹滮ͨ�õ���("CD-D-Advanced", "<�Ƿ�Ҫ��ԭ>|<��λ�ԭ>|<Ҫ��װ���ļ���>|<Ŀ��λ��>")
                                             End Sub

        SMUI6.PluginAPI.��Ӱ�װ�滮.������ö��й���("CD-D-Advanced", "�ļ��и߼���װ", ������ӹ滮_�˵���_�ļ��и߼���װ, AddressOf �༭����_ƥ�䵽_�ļ��и߼���װ)

        SMUI6.PluginAPI.��Ӱ�װ�滮.��Ӱ�װ״ֵ̬("ExistedFolder", "�Ѵ��ڵ��ļ���", Color1.��ɫ)
        SMUI6.PluginAPI.��Ӱ�װ�滮.��Ӱ�װ״ֵ̬("FolderNotInstall", "�ļ���δ��װ")

        SMUI6.PluginAPI.��Ӱ�װ�滮.��Ӱ�װ״̬�жϳ���("CD-D-Advanced", AddressOf �жϰ�װ״̬_�ļ��и߼���װ)

        SMUI6.PluginAPI.��Ӱ�װ�滮.��Ӱ�װж�ع���("CD-D-Advanced",
                                        AddressOf ����ִ���б�_�ļ��и߼���װ,
                                        AddressOf ִ�а�װ����_�ļ��и߼���װ,
                                        AddressOf ִ��ж�ز���_�ļ��и߼���װ)

    End Sub


    Public Shared Property ������ӹ滮_�˵���_�ļ��и߼���װ As New ToolStripMenuItem With {.Text = "�ļ��и߼���װ"}


    Public Shared Property ����_�ļ��и߼���װ_Ҫ��װ�ĸ��ļ��� As String
    Public Shared Property ����_�ļ��и߼���װ_Ŀ��λ�� As String
    Public Shared Property ����_�ļ��и߼���װ_ж��ʱ��β��� As String
    Public Shared Property ����_�ļ��и߼���װ_��ԭ��ʽ As String

    Public Shared Sub �༭����_ƥ�䵽_�ļ��и߼���װ()
        ����_�ļ��и߼���װ_ж��ʱ��β��� = ""
        ����_�ļ��и߼���װ_��ԭ��ʽ = ""
        ����_�ļ��и߼���װ_Ҫ��װ�ĸ��ļ��� = ""
        ����_�ļ��и߼���װ_Ŀ��λ�� = ""
        Dim a As New Form�༭�滮_�ļ��и߼���װ
        Dim �����б� = SMUI6.PluginAPI.��Ӱ�װ�滮.��ȡ���ö�����ѡ�й滮�Ĳ���
        Select Case �����б�(0).Trim.ToLower
            Case "restore"
                a.UiRadioButton1.Checked = True
                a.UiRadioButton2.Checked = False
            Case "delete"
                a.UiRadioButton1.Checked = False
                a.UiRadioButton2.Checked = True
        End Select
        Select Case �����б�(1).Trim.ToLower
            Case "delete-copy"
                a.UiRadioButton3.Checked = True
                a.UiRadioButton4.Checked = False
            Case "cover"
                a.UiRadioButton3.Checked = False
                a.UiRadioButton4.Checked = True
        End Select
        If Not �����б�(2).Contains("<"c) Then a.�����ı���1.Text = �����б�(2)
        If Not �����б�(3).Contains("<"c) Then a.�����ı���2.Text = �����б�(3)
        SMUI6.PluginAPI.��ʾ����.����������ʾģʽ����(a)
        If ����_�ļ��и߼���װ_Ҫ��װ�ĸ��ļ��� <> "" Then
            Dim b As New List(Of String) From {
                ����_�ļ��и߼���װ_ж��ʱ��β���,
                ����_�ļ��и߼���װ_��ԭ��ʽ,
                ����_�ļ��и߼���װ_Ҫ��װ�ĸ��ļ���,
                ����_�ļ��и߼���װ_Ŀ��λ��
            }
            SMUI6.PluginAPI.��Ӱ�װ�滮.���û��༭�õĲ���д��ȥ(b)
        End If
        a.Dispose()
    End Sub

    Public Shared Function �жϰ�װ״̬_�ļ��и߼���װ(��·�� As String, ��Ϸ·�� As String, �����б� As String(), �������� As �����ݼ������ͽṹ, ��ǰ�İ�װ״̬ As String) As String
        If ��������.��װ״̬ = False Then
            Return ""
            Exit Function
        End If
        If ��ǰ�İ�װ״̬ = "UnKnow" Then
            If DirectoryExists(Path.Combine(��Ϸ·��, �����б�(3))) Then
                Return "ExistedFolder"
            Else
                Return "FolderNotInstall"
            End If
        Else
            Return ""
        End If
    End Function

    Public Shared Sub ����ִ���б�_�ļ��и߼���װ()
        �������.�����б�.Add(New �������.�����б�ṹ With {
                   .�滮���� = "CD-D-Advanced",
                   .������ = �������.��װ�滮ԭ�ı��б����(�������.��ǰ���ڴ��������).Value})
    End Sub

    Public Shared Sub ִ�а�װ����_�ļ��и߼���װ()
        Dim �����б� = SMUI6.PluginAPI.��Ӱ�װ�滮.�ڰ�װж�ز����л�ȡ�����б�
        SMUI6.PluginAPI.��Ӱ�װ�滮.�ڰ�װж�ز��������������Ϣ(1, $"���ڰ�װ�ļ��У�{�����б�(3)}")
        CopyDirectory(Path.Combine(�������.��·��, �����б�(2)), Path.Combine(�������.��Ϸ·��, �����б�(3)), True)
    End Sub

    Public Shared Sub ִ��ж�ز���_�ļ��и߼���װ()
        Dim �����б� = SMUI6.PluginAPI.��Ӱ�װ�滮.�ڰ�װж�ز����л�ȡ�����б�
        If �����б�(0).Trim.Equals("ReStore", StringComparison.CurrentCultureIgnoreCase) Then
            If DirectoryExists(Path.Combine(�������.��Ϸ����·��, �����б�(3))) Then
                If �����б�(1).Trim.Equals("Delete-Copy", StringComparison.CurrentCultureIgnoreCase) Then
                    SMUI6.PluginAPI.��Ӱ�װ�滮.�ڰ�װж�ز��������������Ϣ(1, $"����ɾ���ļ��У�{�����б�(3)}")
                    DeleteDirectory(Path.Combine(�������.��Ϸ·��, �����б�(3)), FileIO.DeleteDirectoryOption.DeleteAllContents)
                    SMUI6.PluginAPI.��Ӱ�װ�滮.�ڰ�װж�ز��������������Ϣ(1, $"���ڴӱ����л�ԭ��{�����б�(3)}")
                    CopyDirectory(Path.Combine(�������.��·��, �����б�(3)), Path.Combine(�������.��Ϸ·��, �����б�(3)), True)
                Else
                    SMUI6.PluginAPI.��Ӱ�װ�滮.�ڰ�װж�ز��������������Ϣ(1, $"���ڴӱ����и��ǣ�{�����б�(3)}")
                    CopyDirectory(Path.Combine(�������.��·��, �����б�(3)), Path.Combine(�������.��Ϸ·��, �����б�(3)), True)
                End If
            Else
                SMUI6.PluginAPI.��Ӱ�װ�滮.�ڰ�װж�ز��������������Ϣ(1, $"�Ҳ�����Ӧ���ļ��б��ݣ�{�����б�(3)}��ֻ��ֱ��ɾ����ע������������������")
            End If
        Else
            SMUI6.PluginAPI.��Ӱ�װ�滮.�ڰ�װж�ز��������������Ϣ(1, $"����ɾ���ļ��У�{�����б�(3)}")
            DeleteDirectory(Path.Combine(�������.��Ϸ·��, �����б�(3)), FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
    End Sub


End Class
