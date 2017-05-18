using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orange.Models
{
    public class Commodity_2
    {
        public int ID { get; set; }
        public string Name { get; set; }
       
        public Commodity_1 ID_1 { get; set; }
        public string Time { get; set; }

    }
}