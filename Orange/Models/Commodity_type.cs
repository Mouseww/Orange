using System.ComponentModel.DataAnnotations;

namespace Orange.Models
{
    public class Commodity_type
    {
        [Key]
        public int ID { get; set; }
        public string Type_Name { get; set; }
        public string img { get; set; }
        
    }
}