﻿
using System.Collections.Generic;

namespace WebSite.Models
{
    public class GamesViewModel
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public string Developers { get; set; }
        public string Publisher { get; set; }
        public string Genres { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Link2 { get; set; }

        public List<string> DevList { get; set; }
        public List<string> GenreList { get; set; }
        public List<string> PlatformList { get; set; }
        public List<string> PublisherList { get; set; }
    }
}