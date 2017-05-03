using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orange.Models
{
    public class Shopcart
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public int Number { get; set; }
        [ForeignKey("Commodity_option1")]
        public virtual int Commodity_option1_Id { get; set; }

        [ForeignKey("Commodity_id")]
        public virtual int Commodity_Id { get; set; }

        [ForeignKey("Commodity_option2")]
        public virtual int Commodity_option2_Id { get; set; }
        public Commodity_option1 Commodity_option1 { get; set; }
        public Commodity_option2 Commodity_option2 { get; set; }
        public Commodity Commodity_id { get; set; }
        


    }
}