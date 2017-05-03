using System.ComponentModel.DataAnnotations;

namespace Orange.Models
{
    public class Commodity_1
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public Commodity_type ID_1 { get; set; }
        public string Slogan { get; set; }

    }
}