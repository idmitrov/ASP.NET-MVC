namespace PhC.App.Models.ViewModels
{
    using System;

    public class ContestEntryConciseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Upploaded { get; set; }

        public string PhotoUrl { get; set; }

        public string Author { get; set; }

        public int Votes { get; set; }
       
    }
}