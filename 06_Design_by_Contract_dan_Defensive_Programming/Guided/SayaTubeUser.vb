Public Class SayaTubeUser
    Private id As Integer
    Private uploadedVideos As List(Of SayaTubeVideo)
    Public Property Username As String

    Public Sub New(username As String)
        Me.id = New Random().Next(10000, 99999)
        Me.Username = username
        Me.uploadedVideos = New List(Of SayaTubeVideo)()
    End Sub

    Public Sub AddVideo(video As SayaTubeVideo)
        uploadedVideos.Add(video)
    End Sub

    Public Function GetTotalVideoPlayCount() As Integer
        Dim total As Integer = 0
        For Each video In uploadedVideos
            total += video.GetPlayCount
        Next
        Return total
    End Function

    Public Sub PrintAllVideoPlaycount()
        Console.WriteLine("User: " & Username)
        For i As Integer = 0 To uploadedVideos.Count - 1
            Console.WriteLine("Video " & (i + 1) & " judul: " & uploadedVideos(i).GetTitle)
        Next
    End Sub
End Class
