using System.ComponentModel.DataAnnotations;

namespace Orange.Models
{
    public class Commodity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }
        public double Price_old { get; set; }
        public Commodity_2 ID { get; set; }
        public string img { get; set; }
        public string img_small { get; set; }
     
        public string jieshao { get; set; }





    }
}