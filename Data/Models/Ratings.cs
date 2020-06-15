using System.Collections.Generic;

namespace Data.Models
{
    public class Ratings
    {
        public int ID { get; set; }
        public int Score { get; set; }
        public virtual ICollection<Games> Games { get; set; }

        public Ratings()
        {
            Games = new HashSet<Games>();
        }
    }
}