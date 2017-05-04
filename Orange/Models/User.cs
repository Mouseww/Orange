using System.ComponentModel.DataAnnotations;

namespace Orange.Models
{
    public class User
    {  [Key]
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        
        public User_IN User_IN { get; set; }
    }
}