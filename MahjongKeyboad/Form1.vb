Imports System.Runtime.InteropServices
Public Class Form1
    Declare Function GetForegroundWindow Lib "user32" () As Long
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function FindWindow(ByVal lpClassName As String,
    ByVal lpWindowName As String) As IntPtr
    End Function
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function
    Private Const WS_EX_NOACTIVATE As Integer = &H8000000
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            CreateParams = MyBase.CreateParams
            CreateParams.ExStyle = CreateParams.ExStyle And WS_EX_NOACTIVATE
            Return CreateParams
        End Get
    End Property
    Private Const WM_MOUSEACTIVATE As Integer = &H21
    Private Const MA_NOACTIVATE As Integer = &H3
    Protected Overrides Sub WndProc(ByRef m As Message)
        If (m.Msg = WM_MOUSEACTIVATE) Then
            m.Result = MA_NOACTIVATE
        Else
            MyBase.WndProc(m)
        End If
    End Sub
    Dim theHandle As IntPtr
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click,
            Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click,
            Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click,
            Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click,
            Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click,
            Button22.Click, Button23.Click, Button24.Click, Button25.Click, Button26.Click,
            Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click,
            Button32.Click, Button33.Click, Button34.Click, Button35.Click, Button36.Click,
            Button37.Click, Button38.Click, Button39.Click, Button40.Click, Button41.Click,
            Button42.Click, Button43.Click, Button44.Click
        TextSend(sender.Tag)
    End Sub
    Private Sub TextSend(ByVal n As Integer)
        Dim Character() As String =
    {"🀇", "🀈", "🀉", "🀊", "🀋", "🀌", "🀍", "🀎", "🀏",
     "🀙", "🀚", "🀛", "🀜", "🀝", "🀞", "🀟", "🀠", "🀡",
     "🀐", "🀑", "🀒", "🀓", "🀔", "🀕", "🀖", "🀗", "🀘",
     "🀀", "🀁", "🀂", "🀃", "🀆", "🀅", "🀄", "🀪", "🀫",
     "🀢", "🀣", "🀤", "🀥", "🀦", "🀧", "🀨", "🀩"}
        If theHandle <> IntPtr.Zero Then
            SetForegroundWindow(theHandle)
            SendKeys.Send(Character(n))
        End If
    End Sub
    Private Sub Form1_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        If (Form1.ActiveForm Is Nothing) Then
            theHandle = GetForegroundWindow()
        End If
    End Sub
End Class