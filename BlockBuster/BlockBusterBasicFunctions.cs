using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockBuster
{
    public class BlockBusterBasicFunctions
    {
        public static Movie GetMovieById(int id)
        {
           using(var db = new SE407_BlockbusterContext())
            {
                return db.Movies.Find(id);
            }
        }

        public static List<Movie> GetAllMovie()
        {
            using (var db = new SE407_BlockbusterContext())
            {
                return db.Movies.ToList();
            }
        }

        public static List<Movie> GetAllCheckedOutMovies()
        {
            using(var db = new SE407_BlockbusterContext())
            {
                return db.Movies
                    .Join(db.Transactions,
                    m => m.MovieId,
                    t => t.Movie.MovieId,
                    (m, t) => new
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectoId = m.DirectorId,
                        CheckedIn = t.CheckedIn
                    }).Where(w => w.CheckedIn == "N")
                    .Select(m => new Movie
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectoId
                    }).ToList();
            }
        }

        public static List<Movie> GetAllMoviesByGenre(string genre)
        {
            using(var db = new SE407_BlockbusterContext())
            {
                return db.Movies                            // your starting point - table in the "from" statement
                    .Join(db.Genres,                        // the source table of the inner join
                    m => m.GenreId,                         // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                    t => t.GenreId,                         // Select the foreign key (the second part of the "on" clause)
                    (m, t) => new { M = m, T = t })         // Selection
                    .Where(w => w.T.GenreDescr == genre)    // Where statement
                    .Select(m => new Movie
                    {
                        MovieId = m.M.MovieId,
                        Title = m.M.Title,
                        ReleaseYear = m.M.ReleaseYear,
                        GenreId = m.M.GenreId,
                        DirectorId = m.M.DirectorId
                    }).ToList();                                 
            }
        }

        public static List<Movie> GetAllMoviesByDirectorLastName(string lastName)
        {
            using(var db = new SE407_BlockbusterContext())
            {
                return db.Movies
                .Join(db.Directors,
                m => m.DirectorId,
                t => t.DirectorId,
                (m, t) => new { M = m, T = t })
                .Where(w => w.T.LastName == lastName)
                .Select(m => new Movie
                {
                    MovieId = m.M.MovieId,
                    Title = m.M.Title,
                    ReleaseYear = m.M.ReleaseYear,
                    GenreId = m.M.GenreId,
                    DirectorId = m.M.DirectorId
                }).ToList();
                
            }
        }
    }
}
