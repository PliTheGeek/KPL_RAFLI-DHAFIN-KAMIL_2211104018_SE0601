
Public Class SayaTubeVideo
    Private id As Integer
    Private title As String
    Private playCount As Integer

    Public Sub New(title As String)
        Me.id = New Random().Next(10000, 99999)
        Me.title = title
        Me.playCount = 0
    End Sub

    Public Sub IncreasePlayCount(count As Integer)
        playCount += count
    End Sub

    Public Sub PrintVideoDetails()
        Console.WriteLine("Video ID: " & id)
        Console.WriteLine("Title: " & title)
        Console.WriteLine("Play Count: " & playCount)
    End Sub

    Public ReadOnly Property GetPlayCount As Integer
        Get
            Return playCount
        End Get

    End Property
    Public ReadOnly Property GetTitle As String
        Get
            Return title
        End Get
    End Property


End Class


