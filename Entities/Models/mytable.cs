using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class mytable
    {
        public int raceId { get; set; }
        public int year { get; set; }
        public int round { get; set; }
        [Key]
        public int roundAll { get; set; }
        public int circuitId { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string circuitRef { get; set; }
        public string circuitName { get; set; }
    }
}