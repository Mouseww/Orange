using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orange.Models
{
    public class Commodity_option2
    {[Key]
        public int Id { get; set; }
    
        public Commodity Commodity { get; set; }
        public string option { get; set; }
        public string type_name { get; set; }
        public string Time { get; set; }
    }
}