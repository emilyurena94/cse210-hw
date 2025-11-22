using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    // Class Comment
    class Comment
    {
        private string commenterName;
        private string text;

        public Comment(string commenterName, string text)
        {
            this.commenterName = commenterName;
            this.text = text;
        }

        public string GetCommenterName()
        {
            return commenterName;
        }

        public string GetText()
        {
            return text;
        }
    }

    // Clase Video
    class Video
    {
        private string title;
        private string author;
        private int durationSeconds;
        private List<Comment> comments;

        public Video(string title, string author, int durationSeconds)
        {
            this.title = title;
            this.author = author;
            this.durationSeconds = durationSeconds;
            this.comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return comments.Count;
        }

        public void DisplayVideoInfo()
        {
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Duration: {durationSeconds} seconds");
            Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in comments)
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear videos
            Video video1 = new Video("C# Basics", "Emily Ureña", 600);
            video1.AddComment(new Comment("Alice_pink09", "Great tutorial!"));
            video1.AddComment(new Comment("Bobatea00", "Very helpful, thanks!"));
            video1.AddComment(new Comment("Charchar", "Can you explain loops more?"));

            Video video2 = new Video("Unity Game Dev", "Angel Escobar", 900);
            video2.AddComment(new Comment("Daveeee", "Loved the examples."));
            video2.AddComment(new Comment("Eva_204", "Please do more advanced topics."));
            video2.AddComment(new Comment("Frankysolis", "Amazing content!"));

            Video video3 = new Video("Algorithms in C#", "Angie Torrente", 1200);
            video3.AddComment(new Comment("Grace440", "This helped me a lot."));
            video3.AddComment(new Comment("HannahMontana", "Well explained."));
            video3.AddComment(new Comment("Ian_707", "Thanks for sharing."));

            // Lista de videos
            List<Video> videos = new List<Video> { video1, video2, video3 };

            // Mostrar información de cada video
            foreach (var video in videos)
            {
                video.DisplayVideoInfo();
            }
        }
    }
}
