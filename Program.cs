namespace BewerbungsAufgabe
// von Alexander Dräger
{
    public class GoogleSearch
    {
        static bool newSearch = true;

        static void Main(string[] args)
        {
            bool firstSearch = true;
            while (newSearch)
            {
                IOHelper iOHelper = new IOHelper();
                ConfigReader config = new ConfigReader();
                if (firstSearch is true) { config.firstRead(); }
                config.getPath();
                config.runRead();
                Search Search = new Search();
                Search.startSearch(config.getApiKey(), config.getSearchId(), iOHelper.ReadSearchRequest());
                Search.quitProgram();
                firstSearch = false;
            }

        }
    }
}