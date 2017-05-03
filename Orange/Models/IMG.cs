using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orange.Models
{
    public class IMG
    {
        [Key]
        public int Id { get; set; }
        public string img { get; set; }
        public string type { get; set; }
       
        public  Commodity Commodity { get; set; }
        public string describe1 { get; set; }
        public string describe2 { get; set; }
    }
}