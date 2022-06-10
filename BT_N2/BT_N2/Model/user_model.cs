using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace BT_N2.Model
{
    public class user_model
    {

            [Required]
            [MaxLength(20)]
            [Unique]
            
            public string username { get; set; }
            public string password { get; set; }
       
           
    }
    public  class User : user_model
    {

        [Key]
        public int id { get; set; }
    }
}
