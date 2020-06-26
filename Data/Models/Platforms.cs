using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Platforms
    {
        [Column("ID")]
        public int ID { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Games> Games { get; set; }

        public Platforms()
        {
            Games = new HashSet<Games>();
        }

        public Platforms(string name)
        {
            Games = new HashSet<Games>();
            this.Name = name;
        }
    }
}