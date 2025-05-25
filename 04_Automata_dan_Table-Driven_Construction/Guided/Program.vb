Imports System

Public Class Program
    Enum State
        START
        GAME
        PAUSE
        KELUAR
    End Enum

    Public Shared Sub Main()
        Dim state As State = State.START
        Dim screenName() As String = {"START", "GAME", "PAUSE", "KELUAR"}

        While state <> State.KELUAR
            Console.WriteLine(screenName(CInt(state)) & " SCREEN")
            Console.Write("Enter Command : ")
            Dim command As String = Console.ReadLine()

            Select Case state
                Case State.START
                    If command = "ENTER" Then
                        state = State.GAME
                    ElseIf command = "QUIT" Then
                        state = State.KELUAR
                    Else
                        state = State.START
                    End If

                Case State.GAME
                    If command = "ESC" Then
                        state = State.PAUSE
                    Else
                        state = State.GAME
                    End If

                Case State.PAUSE
                    If command = "BACK" Then
                        state = State.GAME
                    ElseIf command = "HOME" Then
                        state = State.START
                    ElseIf command = "QUIT" Then
                        state = State.KELUAR
                    Else
                        state = State.PAUSE
                    End If
            End Select
        End While

        Console.WriteLine("EXIT SCREEN")
    End Sub
End Class
