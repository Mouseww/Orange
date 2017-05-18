using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orange.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Commodity")]
        public virtual int Commodity_Id { get; set; }
        public Commodity_attribute Commodity { get; set; }
        [ForeignKey("user")]
        public  virtual int user_id { get; set; }
        public User user { get; set; }

        public int BuyNum { get; set; }
        public string sendAddress { get; set; }
        public string ManName { get; set; }
        public string Manphone { get; set; }
        public string Post { get; set; }
        public string Time { get; set; }
        public string State { get; set; }//订单状态

    }
}