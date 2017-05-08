using System.ComponentModel.DataAnnotations;
namespace Orange.Models
{
    public class Ress
    {[Key]
    public int id { get; set; }
        public string Province { get; set; }
        public string City { get; set; }

        public string Township { get; set; }
        public string xiangxi { get; set; }

        public User User { get; set; }
        public string telephone { get; set; }
        public string name { get; set; }
        public string moren { get; set; }
    }
}