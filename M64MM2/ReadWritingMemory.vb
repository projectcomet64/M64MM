Module ReadWritingMemory
    Private Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Integer, ByVal dwProcessId As Integer) As Integer

    Private Declare Function WriteProcessMemory1 Lib "kernel32" Alias "WriteProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As UInteger, ByRef lpBuffer As Integer, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Integer
    Private Declare Function WriteProcessMemory2 Lib "kernel32" Alias "WriteProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As UInteger, ByRef lpBuffer As Single, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Single
    Private Declare Function WriteProcessMemory3 Lib "kernel32" Alias "WriteProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As UInteger, ByRef lpBuffer As Long, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As Long
    Private Declare Function WriteProcessMemory4 Lib "kernel32" Alias "WriteProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As UInteger, ByRef lpBuffer As UInteger, ByVal nSize As Integer, ByRef lpNumberOfBytesWritten As Integer) As UInteger

    Private Declare Function ReadProcessMemory1 Lib "kernel32" Alias "ReadProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As UInteger, ByRef lpBuffer As Integer, ByVal nSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Integer
    Private Declare Function ReadProcessMemory2 Lib "kernel32" Alias "ReadProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As UInteger, ByRef lpBuffer As Single, ByVal nSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Single
    Private Declare Function ReadProcessMemory3 Lib "kernel32" Alias "ReadProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As UInteger, ByRef lpBuffer As Long, ByVal nSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Long
    Private Declare Function ReadProcessMemory4 Lib "kernel32" Alias "ReadProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As UInteger, ByVal lpBuffer() As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Boolean
    Private Declare Function ReadProcessMemory5 Lib "kernel32" Alias "ReadProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As UInteger, ByVal lpBuffer As Byte, ByVal iSize As Integer, ByRef lpNumberOfBytesRead As Integer) As Byte
    Private Declare Function ReadProcessMemory6 Lib "kernel32" Alias "ReadProcessMemory" (ByVal hProcess As Integer, ByVal lpBaseAddress As UInteger, ByRef lpBuffer As UInteger, ByVal nSize As Integer, ByRef lpNumberOfBytesRead As Integer) As UInteger

    Const PROCESS_ALL_ACCESS = &H1F0FF

    Public Sub WriteXBytes(ByVal ProcessName As String, ByVal Address As Long, ByVal Value As String)
        Dim hProcess As IntPtr = GetEmuProcess("Project64")
        If hProcess = Nothing Then Exit Sub

        Dim C As Integer
        Dim B As Integer
        Dim D As Integer
        Dim V As Byte

        B = 0
        D = 1
        For C = 1 To Math.Round((Len(Value) / 2))
            V = Val("&H" & Mid$(Value, D, 2))
            Call WriteProcessMemory1(hProcess, Address + B, V, 1, 0&)
            B = B + 1
            D = D + 2
        Next C

    End Sub

    Public Sub WriteInteger(ByVal ProcessName As String, ByVal Address As UInteger, ByVal Value As Integer, Optional ByVal nsize As Integer = 4)
        Dim hProcess As IntPtr = GetEmuProcess("Project64")
        If hProcess = Nothing Then Exit Sub

        Dim hAddress, vBuffer As Integer
        hAddress = Address
        vBuffer = Value
        WriteProcessMemory1(hProcess, hAddress, CInt(vBuffer), nsize, 0)
    End Sub

    Public Sub WriteUInteger(ByVal ProcessName As String, ByVal Address As UInteger, ByVal Value As UInteger, Optional ByVal nsize As Integer = 4)
        Dim hProcess As IntPtr = GetEmuProcess("Project64")
        If hProcess = Nothing Then Exit Sub

        Dim hAddress, vBuffer As UInteger
        hAddress = Address
        vBuffer = Value
        WriteProcessMemory4(hProcess, hAddress, vBuffer, nsize, 0)
    End Sub

    Public Sub WriteFloat(ByVal ProcessName As String, ByVal Address As UInteger, ByVal Value As Single, Optional ByVal nsize As Integer = 4)
        Dim hProcess As IntPtr = GetEmuProcess("Project64")
        If hProcess = Nothing Then Exit Sub

        Dim hAddress As Integer
        Dim vBuffer As Single

        hAddress = Address
        vBuffer = Value
        WriteProcessMemory2(hProcess, hAddress, vBuffer, nsize, 0)
    End Sub

    Public Sub WriteLong(ByVal ProcessName As String, ByVal Address As UInteger, ByVal Value As Long, Optional ByVal nsize As Integer = 4)
        Dim hProcess As IntPtr = GetEmuProcess("Project64")
        If hProcess = Nothing Then Exit Sub

        Dim hAddress As Integer
        Dim vBuffer As Long

        hAddress = Address
        vBuffer = Value
        WriteProcessMemory3(hProcess, hAddress, vBuffer, nsize, 0)
    End Sub

    Public Function ReadByte(ByVal ProcessName As String, ByVal Address As UInteger, Optional ByVal nsize As Integer = 1) As Byte()
        Dim hProcess As IntPtr = GetEmuProcess("Project64")
        If hProcess = Nothing Then Return Nothing

        Dim hAddress As Integer
        Dim vBuffer(0) As Byte

        hAddress = Address
        ReadProcessMemory4(hProcess, Address, vBuffer, nsize, 0)
        Return vBuffer
    End Function

    Public Function ReadXBytes(ByVal ProcessName As String, ByVal Address As UInteger, Optional ByVal count As Integer = 1) As Byte()
        Dim hProcess As IntPtr = GetEmuProcess("Project64")
        If hProcess = Nothing Then Return Nothing

        Dim hAddress As Integer
        Dim vBuffer(count) As Byte

        hAddress = Address
        ReadProcessMemory4(hProcess, hAddress, vBuffer, count, 0)
        Return vBuffer
    End Function

    Public Function ReadInteger(ByVal ProcessName As String, ByVal Address As UInteger, Optional ByVal nsize As Integer = 4) As Integer
        Dim hProcess As IntPtr = GetEmuProcess("Project64")
        If hProcess = Nothing Then Return Nothing

        Dim hAddress, vBuffer As Integer
        hAddress = Address
        ReadProcessMemory1(hProcess, hAddress, vBuffer, nsize, 0)
        Return vBuffer
    End Function

    Public Function ReadUInteger(ByVal ProcessName As String, ByVal Address As UInteger, Optional ByVal nsize As Integer = 4) As UInteger
        Dim hProcess As IntPtr = GetEmuProcess("Project64")
        If hProcess = Nothing Then Return Nothing

        Dim hAddress, vBuffer As UInteger
        hAddress = Address
        ReadProcessMemory6(hProcess, hAddress, vBuffer, nsize, 0)
        Return vBuffer
    End Function

    Public Function ReadFloat(ByVal ProcessName As String, ByVal Address As UInteger, Optional ByVal nsize As Integer = 4) As Single
        Dim hProcess As IntPtr = GetEmuProcess("Project64")
        If hProcess = Nothing Then Return Nothing

        Dim hAddress As Integer
        Dim vBuffer As Single

        hAddress = Address
        ReadProcessMemory2(hProcess, hAddress, vBuffer, nsize, 0)
        Return vBuffer
    End Function

    Public Function ReadLong(ByVal ProcessName As String, ByVal Address As UInteger, Optional ByVal nsize As Integer = 4) As Long
        Dim hProcess As IntPtr = GetEmuProcess("Project64")
        If hProcess = Nothing Then Return Nothing

        Dim hAddress As Integer
        Dim vBuffer As Long

        hAddress = Address
        ReadProcessMemory3(hProcess, hAddress, vBuffer, nsize, 0)
        Return vBuffer
    End Function

    Public Function GetEmuProcess(ProcessName As String) As IntPtr
        If ProcessName.EndsWith(".exe") Then
            ProcessName = ProcessName.Replace(".exe", "")
        End If
        Dim MyP As Process() = Process.GetProcessesByName(ProcessName)
        If MyP.Length = 0 Then
            Return Nothing
        End If
        Dim hProcess As IntPtr = OpenProcess(PROCESS_ALL_ACCESS, 0, MyP(0).Id)
        If hProcess = IntPtr.Zero Then
            MessageBox.Show("Failed to open " & ProcessName & "!")
            Return Nothing
        End If
        Return hProcess
    End Function

    Public Function GetBaseAddress(ByVal ProcessName As String, Optional scanStep As Integer = &H10000, Optional ByVal nsize As Integer = 4) As Integer

        Dim hProcess As IntPtr = GetEmuProcess("Project64")
        If hProcess = Nothing Then Return 0

        Dim vBuffer As Integer
        Dim startPoint As Integer = &H10000000

        'If scanStep < &H1000 And scanStep >= &H100 Then
        '    startPoint = &H20000000
        'ElseIf scanStep < &H100 Then
        '    startPoint = &H15000000
        'End If

        For x = startPoint To &H70000000 Step scanStep
            ReadProcessMemory1(hProcess, x, vBuffer, nsize, 0)

            If vBuffer = &H3C1A8032 Then Return x
        Next

        Return 0
    End Function
End Module
