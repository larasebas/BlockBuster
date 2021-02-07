using BlockBuster.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace BlockBusterConsole
{
    class OutputHelper
    {

        public void WriteToConsole(List<Movie> movies)
        {
            Console.WriteLine("List of Movies:");
            foreach(var m in movies)
            {
                Console.WriteLine($"MovieId: {m.MovieId}\tTitle: {m.Title}\tRelease Year: {m.ReleaseYear}");
            }
        }

        public void WriteMovieToConsole(Movie m)
        {
            Console.WriteLine($"Movie found by ID: {m.MovieId}");
            Console.WriteLine($"Title:  {m.Title}");
        }

        public void WriteToCSV(List<Movie> movies)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(movies);
            }
        }
        public void WriteMovieToCSV(Movie m)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(m.Title);
            }
        }


    }
}
