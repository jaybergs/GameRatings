using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Links
    {
        [Column("ID")]
        public int ID { get; set; }

        public string Link { get; set; }
        public virtual ICollection<Games> Games { get; set; }

        public Links()
        {
            Games = new HashSet<Games>();
        }
    }
}