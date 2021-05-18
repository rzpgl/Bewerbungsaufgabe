using System;
using System.Collections.Generic;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;

namespace BewerbungsAufgabe
{
    public class Search
    {
        private int outputCounter = 0;


        public void startSearch(string configApiKey, string configSearchId, string searchRequest)
        {
            var customSearchService = new CustomsearchService(new BaseClientService.Initializer
            { ApiKey = configApiKey });
            CseResource.ListRequest listRequest = customSearchService.Cse.List();
            listRequest.Cx = configSearchId;
            listRequest.Q = searchRequest;
            IList<Result> resultCache = new List<Result>();
            printSearchResultItems(resultCache, listRequest);
        }

        private void printSearchResultItems(IList<Result> resultCache, CseResource.ListRequest listRequest)
        {
            const int pageSize = 10;
            const int searchEnd = 2;
            int pagePosition = 0;

            while (pagePosition < searchEnd)
            {
                listRequest.Start = pagePosition * pageSize + 1;
                resultCache = listRequest.Execute().Items;
                this.printItems(resultCache);
                pagePosition++;
            }
        }


        private void printItems(IList<Result> resultCache)
        {
            try
            {
                foreach (var item in resultCache)
                {
                    outputCounter++;
                    Console.WriteLine("Ergebnis: " + outputCounter + Environment.NewLine + "Titel: " + item.Title + Environment.NewLine +
                                                  "URL: " + item.Link + Environment.NewLine + "======================================================" +
                                                  Environment.NewLine);
                }
            }
            catch (System.NullReferenceException n)
            {
                Console.WriteLine(Environment.NewLine + "Keine Ergebnisse für diese Suchanfrage." +
                    Environment.NewLine + "Caught: {0}", n.Message + Environment.NewLine);
            }
        }
    }
}