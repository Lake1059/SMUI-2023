Imports System.Runtime.InteropServices
Imports Windows.UI.Input

Module Module1
    'Win32 API
    Public Declare Auto Function ReleaseCapture Lib "user32.dll" Alias "ReleaseCapture" () As Boolean
    Public Declare Auto Function SendMessage Lib "user32.dll" Alias "SendMessage" (hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer) As IntPtr
    'Win32 Message
    Public Const WM_SYSCOMMAND As Integer = &H112&
    Public Const SC_MOVE As Integer = &HF010&
    Public Const HTCAPTION As Integer = &H2&

    Public Const WM_USER As Integer = &H400
    Public Const EM_GETPARAFORMAT As Integer = WM_USER + 61
    Public Const EM_SETPARAFORMAT As Integer = WM_USER + 71
    Public Const MAX_TAB_STOPS As Long = 32
    Public Const PFM_LINESPACING As UInteger = &H100

    <StructLayout(LayoutKind.Sequential)>
    Public Structure PARAFORMAT2
        Public cbSize As Integer
        Public dwMask As UInteger
        Public wNumbering As Short
        Public wReserved As Short
        Public dxStartIndent As Integer
        Public dxRightIndent As Integer
        Public dxOffset As Integer
        Public wAlignment As Short
        Public cTabCount As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)>
        Public rgxTabs As Integer()
        Public dySpaceBefore As Integer
        Public dySpaceAfter As Integer
        Public dyLineSpacing As Integer
        Public sStyle As Short
        Public bLineSpacingRule As Byte
        Public bOutlineLevel As Byte
        Public wShadingWeight As Short
        Public wShadingStyle As Short
        Public wNumberingStart As Short
        Public wNumberingStyle As Short
        Public wNumberingTab As Short
        Public wBorderSpace As Short
        Public wBorderWidth As Short
        Public wBorders As Short
    End Structure

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Function SendMessage(hWnd As HandleRef, msg As Integer, wParam As Integer, ByRef lParam As PARAFORMAT2) As IntPtr
    End Function

    Public Sub DebugPrint(文本 As String, 颜色 As Color, Optional 是否需要转到调试选项卡 As Boolean = False)
        If 文本 = "" Then Exit Sub
        Form1.UiRichTextBox2.AppendText(vbCrLf & 文本)
        Form1.UiRichTextBox2.Select(Form1.UiRichTextBox2.TextLength - Len(文本), Len(文本))
        Form1.UiRichTextBox2.SelectionColor = 颜色
        Form1.UiRichTextBox2.Select(Form1.UiRichTextBox2.TextLength, 0)
        Form1.UiRichTextBox2.ScrollToCaret()
        If 是否需要转到调试选项卡 = True Then
            Form1.UiTabControl1.SelectedTab = Form1.TabPage调试输出
        End If
    End Sub

    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2

    Public Function GetScrollBarWidth() As Integer
        Dim dpiScaleFactor As Single = 1.0F
        Using g As Graphics = Form1.CreateGraphics()
            dpiScaleFactor = g.DpiX / 96.0F
        End Using
        Dim systemScrollBarWidth As Integer = SystemInformation.VerticalScrollBarWidth
        Dim scaledScrollBarWidth As Integer = systemScrollBarWidth * dpiScaleFactor
        Return scaledScrollBarWidth
    End Function

    <DllImport("shell32.dll")>
    Public Function ShellExecute(hwnd As IntPtr, lpOperation As String, lpFile As String, lpParameters As String, lpDirectory As String, nShowCmd As Integer) As IntPtr
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Public Structure DISPLAY_DEVICE
        Public cb As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Public DeviceName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)>
        Public DeviceString As String
        Public StateFlags As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)>
        Public DeviceID As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)>
        Public DeviceKey As String
    End Structure

    <DllImport("User32.dll")>
    Public Function EnumDisplayDevices(
            ByVal lpDevice As String,
            ByVal iDevNum As UInteger,
            ByRef lpDisplayDevice As DISPLAY_DEVICE,
            ByVal dwFlags As UInteger
        ) As Boolean
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Public Function TerminateProcess(hProcess As IntPtr, uExitCode As UInteger) As Boolean
    End Function

    Public Sub 显示模式窗体(哪个窗口 As Form, 以谁为基准显示 As Form)
        哪个窗口.Left = (以谁为基准显示.Width - 哪个窗口.Width) * 0.5 + 以谁为基准显示.Left
        哪个窗口.Top = (以谁为基准显示.Height - 哪个窗口.Height) * 0.5 + 以谁为基准显示.Top
        哪个窗口.ShowDialog(以谁为基准显示)
    End Sub

    Public Sub 显示窗体(哪个窗口 As Form, 以谁为基准显示 As Form)
        If 哪个窗口.Visible = True Then
            哪个窗口.Focus()
            哪个窗口.Left = (以谁为基准显示.Width - 哪个窗口.Width) * 0.5 + 以谁为基准显示.Left
            哪个窗口.Top = (以谁为基准显示.Height - 哪个窗口.Height) * 0.5 + 以谁为基准显示.Top
        Else
            哪个窗口.Left = (以谁为基准显示.Width - 哪个窗口.Width) * 0.5 + 以谁为基准显示.Left
            哪个窗口.Top = (以谁为基准显示.Height - 哪个窗口.Height) * 0.5 + 以谁为基准显示.Top
            哪个窗口.Show(以谁为基准显示)
        End If
    End Sub

    Public Delegate Sub Delegate_DebugPrint(文本 As String, 颜色 As Color, 是否需要转到调试选项卡 As Boolean)

    Public Sub DebugPrintInvoke(文本 As String, 颜色 As Color, Optional 是否需要转到调试选项卡 As Boolean = False)
        If Form1.InvokeRequired Then
            Dim d As New Delegate_DebugPrint(AddressOf DebugPrintInvoke)
            Form1.Invoke(d, New Object() {文本, 颜色, 是否需要转到调试选项卡})
        Else
            DebugPrint(文本, 颜色, 是否需要转到调试选项卡)
        End If
    End Sub



End Module
