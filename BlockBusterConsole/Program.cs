using BlockBuster.Models;
using System;

namespace BlockBusterConsole
{
    class Program
    {

        private static string _outputType;
        private static string _query;
        //private static string _thirdParm;

        static void Main()
        {

            string[] args = Environment.GetCommandLineArgs();
            AreArgumentsValid(args);

            // running queries and storing result in variables
            var all = BlockBuster.BlockBusterBasicFunctions.GetAllMovie();
            var checkedout = BlockBuster.BlockBusterBasicFunctions.GetAllCheckedOutMovies();
            var thirdParm = args[3];
            if (int.TryParse(thirdParm, out int num))
            {
                _ = new Movie(); Movie byId = BlockBuster.BlockBusterBasicFunctions.GetMovieById(Convert.ToInt32(args[3]));
            }
            
            var byGenre = BlockBuster.BlockBusterBasicFunctions.GetAllMoviesByGenre(args[3]);
            var byDirectorLast = BlockBuster.BlockBusterBasicFunctions.GetAllMoviesByDirectorLastName(args[3]);



            var oh = new OutputHelper();
            switch (_outputType)
            {
                case "con":
                    if (_query == "moviesall") { oh.WriteToConsole(all); }
                    if (_query == "moviescheckedout") { oh.WriteToConsole(checkedout); }
                    //if (_query == "moviesbyid") { oh.WriteMovieToConsole(byId); }
                    if (_query == "moviesbygenre") { oh.WriteToConsole(byGenre); }
                    if (_query == "moviesbydirlast") { oh.WriteToConsole(byDirectorLast); }
                    break;

                case "csv":
                    if (_query == "moviesall") { oh.WriteToCSV(all); }
                    if (_query == "moviescheckedout") { oh.WriteToCSV(checkedout); }
                    //if (_query == "moviesbyid") { oh.WriteMovieToCSV(byId); }
                    if (_query == "moviesbygenre") { oh.WriteToCSV(byGenre); }
                    if (_query == "moviesbydirlast") { oh.WriteToCSV(byDirectorLast); }
                    break;
                   
                default:
                    Console.WriteLine($"{_outputType} is not a valid output type. Only con or csv.");
                    break;

            }
        }

        private static void AreArgumentsValid(string[] args)
        {
           _outputType = args[1].ToLower();
           _query = args[2].ToLower();
            //_thirdParm = args[3].ToLower(); // we need a third parameter for queries that passes any parameters, having issues here since it could be Int or strings

            var oType = "con csv";
            var queries = "moviesall moviesbyid moviescheckedout moviesbygenre moviesbydirlast";

             if (oType.Contains(_outputType) && queries.Contains(_query))
             {
                //_thirdParm =  NumParser(args[3]); 
                Console.WriteLine("All arguments are valid");
             }
             
            else
            {
                Console.WriteLine("Not all arguments are valid");
            }
        }

        public static double NumParser(string arg)
        {
            double number;
            if (Double.TryParse(arg, out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine($"Unable to parse {arg}.");
                Environment.Exit(99);
            }
            return 0;
        }
    }
}
