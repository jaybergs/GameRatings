using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Publishers
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Games> Games { get; set; }

        public Publishers()
        {
            Games = new HashSet<Games>();
        }
    }
}