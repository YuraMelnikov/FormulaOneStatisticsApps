using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class mytable
    {
        public int year { get; set; }
        public int round { get; set; }
        public string driver { get; set; }
        public int lap { get; set; }
        public int position { get; set; }
        public string time { get; set; }
        [Key]
        public int id { get; set; }
    }
}