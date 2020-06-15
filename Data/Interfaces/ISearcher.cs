using Data.Models;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface ISearcher
    {
        IList<Games> SearchDevelopers(string search, bool descending = false);

        IList<Games> SearchNames(string search, bool descending = false);

        IList<Games> SearchGenres(string search, bool descending = false);

        IList<Games> SearchPlatforms(string search, bool descending = false);

        IList<Games> SearchPublishers(string search, bool descending = false);
    }
}