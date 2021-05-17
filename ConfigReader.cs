using System;
using System.IO;

namespace BewerbungsAufgabe
{
    public class ConfigReader
    {
        private string apiKey;
        private string searchId;
        private string filePath;


        public void getPath()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            string filename = "config.txt";
            filePath = Path.GetFullPath(Path.Combine(path, @"../../../", filename));
        }

        public void runRead()
        { this.readConfig(); }

        public void firstRead()
        {
            Console.WriteLine("config wird eingelesen..." + Environment.NewLine +
                              "config erfolgreich eingelesen." + Environment.NewLine);
        }

        private void readConfig()
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                apiKey = lines[0];
                searchId = lines[1];
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("Config ist nicht im entsprechenden Verzeichnis. Bitte in Projektordner kopieren." +
                    Environment.NewLine + "Caught: {0}", e.Message);
                Environment.Exit(1);
            }
            catch (System.IndexOutOfRangeException i)
            {
                Console.WriteLine("Config konnte nicht eingelesen werden, da diese leer ist. Bite Datei kontrollieren." +
                    Environment.NewLine + "Caught: {0}", i.Message);
                Environment.Exit(1);
            }
        }

        public string getApiKey() { return apiKey; }
        public string getSearchId() { return searchId; }
    }
}