using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Powers")]
    public class Power
    {
        public int PowerId { get; set; }
        public string PowerName { get; set; }
        public ICollection<HeroPower> Heroes { get; set; }
    }
}