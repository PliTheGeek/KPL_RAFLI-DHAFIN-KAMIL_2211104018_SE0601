Module Program
    Sub Main()
        Dim user As New SayaTubeUser("Rafli Dhafin Kamil")
        Dim titles As String() = {
            "Review Film Interstellar oleh Rafli Dhafin Kamil",
            "Review Film Inception oleh Rafli Dhafin Kamil",
            "Review Film The Matrix oleh Rafli Dhafin Kamil",
            "Review Film Parasite oleh Rafli Dhafin Kamil",
            "Review Film The Godfather oleh Rafli Dhafin Kamil",
            "Review Film Spirited Away oleh Rafli Dhafin Kamil",
            "Review Film The Dark Knight oleh Rafli Dhafin Kamil",
            "Review Film Suzume oleh Rafli Dhafin Kamil",
            "Review Film La La Land oleh Rafli Dhafin Kamil",
            "Review Film The Prestige oleh Rafli Dhafin Kamil"
        }
        For Each t In titles
            Dim video As New SayaTubeVideo(t)
            video.IncreasePlayCount(10)
            user.AddVideo(video)
        Next
        user.PrintAllVideoPlaycount()
        Console.WriteLine("Total Play Count: " & user.GetTotalVideoPlayCount())
    End Sub
End Module
