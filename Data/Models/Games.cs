using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Games
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Publisher_ID { get; set; }
        public int PubYear { get; set; }
        public string Description { get; set; }
        public int Rating_ID { get; set; }
        public int Link_ID { get; set; }

        [ForeignKey("Publisher_ID")]
        public virtual Publishers Publisher { get; set; }

        [ForeignKey("Rating_ID")]
        public virtual Ratings Rating { get; set; }

        [ForeignKey("Link_ID")]
        public virtual Links Link { get; set; }

        public virtual ICollection<Developers> Developers { get; set; }
        public virtual ICollection<Genres> Genres { get; set; }
        public virtual ICollection<Platforms> Platforms { get; set; }

        public Games()
        {
            Developers = new HashSet<Developers>();
            Genres = new HashSet<Genres>();
            Platforms = new HashSet<Platforms>();
        }
    }
}