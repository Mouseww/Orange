using System.ComponentModel.DataAnnotations;

namespace Orange.Models
{
    public class Commodity_option1
    {
        [Key]
        public int Id { get; set; }
        
        public Commodity Commodity { get; set; }
        public string option { get; set; }
        public string type_name { get; set; }

    }
}