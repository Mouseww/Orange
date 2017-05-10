using System.ComponentModel.DataAnnotations;

namespace Orange.Models
{
    public class Commodity_attribute
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public Commodity Commodity { get; set; }
        public Commodity_option1 Commodity_option1 { get; set; }
        public Commodity_option2 Commodity_option2 { get; set; }

        public double Price { get; set; }
        public double Price_old { get; set; }
    }
}