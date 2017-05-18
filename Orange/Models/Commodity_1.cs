using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orange.Models
{
    public class Commodity_1
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
      
        public Commodity_type ID_1 { get; set; }
        public string Slogan { get; set; }
        public string Time { get; set; }
    }
}