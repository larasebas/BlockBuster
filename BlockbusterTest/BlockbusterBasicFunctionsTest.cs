using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlockbusterTest
{
    public class BlockbusterBasicFunctionsTest
    {
        [Fact]
        public void GetMovieByIdTest()
        {
            var result = BlockBuster.BlockBusterBasicFunctions.GetMovieById(11);
            Assert.True(result.Title == "Vertigo");
            Assert.True(result.ReleaseYear == 1958);
        }

        [Fact]
        public void GetAllMoviesTest()
        {
            var result = BlockBuster.BlockBusterBasicFunctions.GetAllMovie();
            Assert.True(result.Count == 50);
        }

        [Fact]
        public void GetAllCheckedOutMovies()
        {
            var result = BlockBuster.BlockBusterBasicFunctions.GetAllCheckedOutMovies();
            Assert.True(result.Count == 3);
        }

        [Fact]
        public void GetAllMoviesByGenre()
        {
            var result = BlockBuster.BlockBusterBasicFunctions.GetAllMoviesByGenre("Drama");
            Assert.True(result.Count == 30);
        }

        [Fact]
        public void GetAllMoviesByDirectorLastName()
        {
            var result = BlockBuster.BlockBusterBasicFunctions.GetAllMoviesByDirectorLastName("Coppola");
            Assert.True(result.Count == 3);
        }

    }
}
