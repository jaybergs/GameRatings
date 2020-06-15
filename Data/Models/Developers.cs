using System.Collections.Generic;

namespace Data.Models
{
    public class Developers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Games> Games { get; set; }

        public Developers()
        {
            Games = new HashSet<Games>();
        }
    }
}