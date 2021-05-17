﻿using System;

namespace BewerbungsAufgabe
{
    public class IOHelper
    {
        public string ReadSearchRequest()
        {
            Console.WriteLine(Environment.NewLine + "Hallo, wonach möchten Sie suchen?");
            string searchRequest = Console.ReadLine();
            while (searchRequest == "")
            {
                Console.WriteLine("Keine Eingabe. Bitte erneut versuchen." + Environment.NewLine);
                this.ReadSearchRequest();
            }
            return searchRequest;
        }
    }
}