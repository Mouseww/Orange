using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orange.Models
{
    public class User
    {  [Key]
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        [ForeignKey("User_IN")]
        public virtual int User_IN_Id { get; set; }
        public User_IN User_IN { get; set; }
    }
}