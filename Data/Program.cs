using Data.Interfaces;
using Data.Models;
using Data.Utilities;
using System;
using System.Collections.Generic;

namespace Data
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new GameRatingsDbContext())
            {
                ISearcher searcher = new Searcher(db);
                IList<Games> result = searcher.SearchPublishers("Nintendo");

                foreach (Games gm in result)
                {
                    Console.Write(gm.Name + "\t");
                    foreach (Developers d in gm.Developers)
                    {
                        Console.Write(d.Name + "\t");
                    }
                    Console.Write(gm.PubYear + "\t");
                    Console.Write(gm.Publisher.Name + "\t");
                    Console.Write("\n");
                }
                Console.ReadKey();
            }
        }
    }
}