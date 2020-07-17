using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.Models
{
    public class Genres
    {
        [Column("ID")]
        public int ID { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Games> Games { get; set; }

        public Genres()
        {
            Games = new HashSet<Games>();
        }

        public Genres(string name)
        {
            Games = new HashSet<Games>();
            Name = name;
        }
    }
}