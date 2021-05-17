using System;

namespace BewerbungsAufgabe
// von Alexander Dräger
{
    public class GoogleSearch
    {
        static bool newSearch = true;

        static void Main(string[] args)
        {
            GoogleSearch newProgram = new GoogleSearch();
            RequestReader request = new RequestReader();
            ConfigReader config = new ConfigReader();
            config.firstRead();
            while (newSearch)
            {
                Search Search = new Search();
                Search.startSearch(config.getApiKey(), config.getSearchId(), request.ReadSearchRequest());
                newProgram.quitProgram();
            }
        }

        public void quitProgram()
        {
            Console.WriteLine("Neue Suche (beliebige Taste) / Suche beenden(n)");
            ConsoleKeyInfo endKey = Console.ReadKey(true);
            if (endKey.Key == ConsoleKey.N) { Environment.Exit(1); }
        }
    }
}
