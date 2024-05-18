Imports System.Runtime.InteropServices

Public Class 全局键盘钩子

    Private Delegate Function HookProc(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    Private Shared ReadOnly hookProc2 As HookProc = AddressOf HookCallback
    Private Shared hHook As IntPtr = IntPtr.Zero

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function SetWindowsHookEx(idHook As Integer, lpfn As HookProc, hMod As IntPtr, dwThreadId As UInteger) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function UnhookWindowsHookEx(hhk As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function CallNextHookEx(hhk As IntPtr, nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function GetModuleHandle(lpModuleName As String) As IntPtr
    End Function

    Private Const WH_KEYBOARD_LL As Integer = 13
    Private Const WM_KEYDOWN As Integer = &H100

    Public Shared Sub SetHook()
        If hHook = IntPtr.Zero Then
            hHook = SetWindowsHookEx(WH_KEYBOARD_LL, hookProc2, GetModuleHandle(Nothing), 0)
        End If
    End Sub

    Public Shared Sub Unhook()
        If hHook <> IntPtr.Zero Then
            UnhookWindowsHookEx(hHook)
            hHook = IntPtr.Zero
        End If
    End Sub

    Private Shared Function HookCallback(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
        If nCode >= 0 AndAlso wParam = CType(WM_KEYDOWN, IntPtr) Then
            RaiseEvent 自定义全局键盘事件(Marshal.ReadInt32(lParam))
        End If
        Return CallNextHookEx(hHook, nCode, wParam, lParam)
    End Function

    Public Shared Event 自定义全局键盘事件(Key As Keys)



End Class
