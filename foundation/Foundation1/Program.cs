using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();
        
        Video video1 = new Video("My first love", "Mi-ann Wirjosentono", 400);
        video1.addComment("Kathy Sokromo", "Nice video. I look forward to more!");
        video1.addComment("Alice", "Great movie!");
        video1.addComment("Bob", "Mind-blowing!");

        Video video2 = new Video("Love at Uni", "SunSun", 300);
        video2.addComment("John Doe", "Incredible storytelling! I was hooked from start to finish!");
        video2.addComment("Sarah Smith", "The visuals were stunning! Great job!");
        video2.addComment("Mike Johnson", "I didn't expect that twist at the end!");

        Video video3 = new Video("Daughter of a King", "Willow", 500);
        video3.addComment("Emily Davis", "Absolutely loved the soundtrack. It complemented the movie perfectly!");
        video3.addComment("Chris Lee", "A must-watch for any film enthusiast!");
        video3.addComment("Jessica Taylor", "Can’t wait for the sequel! This movie was fantastic!");

         // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display video information and comments
        foreach (var video in videos)
        {
            video.Display();
            Console.WriteLine($"Number of comments: {video.commentAmount()}");
            video.displayComments();
            Console.WriteLine(); // Blank line for better readability
        }
    }
}