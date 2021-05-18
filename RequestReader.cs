using System;

namespace BewerbungsAufgabe
{
    public class RequestReader
    {
        string searchRequest;
        public string ReadSearchRequest()
        {
            Console.WriteLine(Environment.NewLine + "Hallo, wonach möchten Sie suchen?");
            searchRequest = Console.ReadLine();
            while (searchRequest == "")
            {
                Console.WriteLine("Keine Eingabe. Bitte erneut versuchen." + Environment.NewLine);
                this.ReadSearchRequest();
            }
            return searchRequest;
        }
    }
}
