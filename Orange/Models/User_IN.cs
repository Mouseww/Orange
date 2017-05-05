using System.ComponentModel.DataAnnotations;

namespace Orange.Models
{
    public class User_IN
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public string nikename { get; set; }
        public string telephone { get; set; }
        public Gender sex { get; set; }
         public string birthday { get; set; }

        public string username { get; set; }

    }

    public enum Gender
    {
        男 =1,
        女=2
    }
}